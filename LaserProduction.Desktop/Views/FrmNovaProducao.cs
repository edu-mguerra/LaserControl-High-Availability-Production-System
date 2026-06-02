using LaserProduction.Desktop.Core;
using LaserProduction.Desktop.Services;
using LaserProduction.Shared.DTOs;

namespace LaserProduction.Desktop.Views
{
    public partial class FrmNovaProducao : ReaLTaiizor.Forms.MaterialForm
    {
        private readonly ProducaoService _producaoService;
        private readonly ParametrosService _parametrosService;
        private readonly DatabaseLocalService _databaseLocalService = new DatabaseLocalService();

        public FrmNovaProducao()
        {
            InitializeComponent();

            _producaoService = new ProducaoService();
            _parametrosService = new ParametrosService();
        }






        private void FrmNovaProducao_Load(object sender, EventArgs e)
        {
            cmbMaquina.Hint = "Máquina Inicial";
            cmbMaquina.Items.Clear();
            cmbMaquina.Items.AddRange(new string[] { "Máquina Laser 01", "Máquina Laser 02", "Máquina Laser 03" });
            cmbMaquina.SelectedIndex = 0;
        }



        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtQuantidade.Text, out int qtdTotal) || qtdTotal <= 0)
            {
                MessageBox.Show("Informe uma quantidade válida para produzir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantidade.Focus();
                return;
            }

            btnSalvar.Enabled = false;
            btnSalvar.Text = "INICIANDO LOTE...";

            try
            {
                var parametros = await _parametrosService.ObterParametrosAsync();
                string portaCom = (parametros?.PortaLaser ?? "").Trim();

                bool modoSimulacao = portaCom.Equals("SIMULADOR", StringComparison.OrdinalIgnoreCase);

                if (!modoSimulacao)
                {
                    var resposta = MessageBox.Show($"O sistema achou a porta '{portaCom}' configurada.\nComo você está apenas testando, deseja FORÇAR o modo SIMULADOR agora?", "Modo de Teste", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resposta == DialogResult.Yes)
                    {
                        modoSimulacao = true;
                    }
                }
               

                var dadosBatch = new NovaProducaoDto
                {
                    Pedido = txtPedido.Text.Trim(),
                    Cliente = txtCliente.Text.Trim(),
                    MaquinaAtual = string.IsNullOrWhiteSpace(cmbMaquina.Text) ? "Máquina Laser 01" : cmbMaquina.Text,
                    UsuarioId = Sessao.UsuarioId
                };

                await Task.Run(async () =>
                {
                    try
                    {
                        using (System.IO.Ports.SerialPort serial = modoSimulacao ? null : new System.IO.Ports.SerialPort(portaCom, 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One))
                        {
                            if (!modoSimulacao)
                            {
                                serial.ReadTimeout = 2000;
                                serial.WriteTimeout = 2000;
                                serial.Open();
                            }

                            for (int i = 0; i < qtdTotal; i++)
                            {
                                this.Invoke((MethodInvoker)delegate
                                {
                                    btnSalvar.Text = $"GRAVANDO {i + 1} DE {qtdTotal}...";
                                });

                                string tagGerada = "";
                                int idReg = 0;
                                bool modoOnlineSucesso = false;

                                try
                                {
                                    var resultado = await _producaoService.GerarProximaTagAsync(dadosBatch);
                                    System.Text.Json.JsonElement elemento = (System.Text.Json.JsonElement)resultado;
                                    idReg = elemento.GetProperty("id").GetInt32();
                                    tagGerada = elemento.GetProperty("tag").GetString();
                                    modoOnlineSucesso = true;
                                }
                                catch (Exception ex)
                                {
                                    modoOnlineSucesso = false;
                                    tagGerada = $"OFF-{DateTime.Now.ToString("yyyyMMddHHmmss")}-{i + 1}";
                                    _databaseLocalService.SalvarOffline(dadosBatch, tagGerada);

                                }

                                if (modoSimulacao)
                                {
                                    await Task.Delay(2000);
                                }
                                else
                                {
                                    try
                                    {
                                        serial.WriteLine(tagGerada);
                                        serial.ReadLine();
                                    }
                                    catch
                                    {
                                        modoSimulacao = true;
                                        await Task.Delay(2000);
                                    }
                                }

                                if (modoOnlineSucesso)
                                {
                                    try
                                    {
                                        await _producaoService.FinalizarTagAsync(idReg);
                                    }
                                    catch
                                    {
                                    }
                                }
                            }

                            this.Invoke((MethodInvoker)delegate
                            {
                                MessageBox.Show("Produção concluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            MessageBox.Show($"Erro na gravação: {ex.Message}", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnSalvar.Enabled = true;
                            btnSalvar.Text = "INICIAR PRODUÇÃO";
                        });
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha de configuração: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSalvar.Enabled = true;
                btnSalvar.Text = "INICIAR PRODUÇÃO";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (!btnSalvar.Enabled)
            {
                var confirm = MessageBox.Show("Existe uma produção em andamento. Se cancelar agora, a gravação da peça atual pode ser interrompida. Deseja realmente cancelar?",
                                              "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.No) return;
            }

            this.Close();
        }
    }
}