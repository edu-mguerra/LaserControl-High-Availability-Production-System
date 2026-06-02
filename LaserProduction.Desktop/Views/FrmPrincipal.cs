using LaserProduction.Desktop.Services;
using LaserProduction.Desktop.Views;
using LaserProduction.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LaserProduction.Desktop
{
    public partial class FrmPrincipal : ReaLTaiizor.Forms.MaterialForm
    {
        private string _perfilLogado;
        private readonly ProducaoService _producaoService;

        public FrmPrincipal(string perfilUsuario)
        {
            InitializeComponent();
            _perfilLogado = perfilUsuario;
            _producaoService = new ProducaoService();
        }

        private async void FrmPrincipal_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Helpers.UIHelper.ConfigurarGrid(gridProducoes);

            Helpers.UIHelper.ConfigurarComboStatus(cmbFiltroStatus);
            Helpers.UIHelper.ConfigurarComboUsuario(cmbFiltroUsuario);
            Helpers.SecurityHelper.ConfigurarAcesso(_perfilLogado,
                btnRegravar,
                btnTransferir,
                btnUsuarios,
                btnParametros,
                cmbFiltroStatus);
            Helpers.UIHelper.ConfigurarColunasManual(gridProducoes);
            timerSincronizacao.Start();

            await CarregarDadosProducao();
        }

        private async Task CarregarDadosProducao()
        {
            try
            {
                List<ProducaoDto> producoes = await _producaoService.ObterTodasAsync();

                gridProducoes.DataSource = producoes;

                int aguardando = producoes.Count(p => p.Status == "AGUARDANDO INÍCIO");
                int andamento = producoes.Count(p => p.Status == "EM ANDAMENTO");
                int finalizados = producoes.Count(p => p.Status == "FINALIZADO");

                AtualizarCardsTempoReal(aguardando, andamento, finalizados);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar as produções: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AtualizarCardsTempoReal(int aguardando, int andamento, int finalizados)
        {
            lblTotalAguardando.Text = aguardando.ToString();
            lblTotalAndamento.Text = andamento.ToString();
            lblTotalFinalizado.Text = finalizados.ToString();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            if (_perfilLogado == "MASTER")
            {
                FrmUsuarios formUsuarios = new FrmUsuarios();
                formUsuarios.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acesso Negado. Apenas usuários MASTER possuem permissão para gerenciar usuários.",
                                "Bloqueio de Segurança", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnParametros_Click(object sender, EventArgs e)
        {
            if (_perfilLogado == "MASTER")
            {
                FrmParametros formParametros = new FrmParametros();
                formParametros.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acesso Negado. Apenas usuários MASTER possuem permissão para alterar os parâmetros.",
                                "Segurança", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnTransferir_Click(object sender, EventArgs e)
        {
            if (_perfilLogado == "MASTER")
            {
                if (gridProducoes.CurrentRow != null)
                {
                    var selecionado = (ProducaoDto)gridProducoes.CurrentRow.DataBoundItem;

                    string tag = selecionado.NumeroTag ?? "Desconhecida";

                    FrmTransferir formTransferir = new FrmTransferir(tag);

                    if (formTransferir.ShowDialog() == DialogResult.OK)
                    {
                        await CarregarDadosProducao();
                    }
                }
                else
                {
                    MessageBox.Show("Selecione uma produção na tabela antes de clicar em Transferir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Acesso Negado. Apenas usuários MASTER possuem permissão para transferir produções.", "Segurança", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnNovaProducao_Click(object sender, EventArgs e)
        {
            using (FrmNovaProducao formNova = new FrmNovaProducao())
            {
                formNova.ShowDialog();
            }

            try
            {
                await CarregarDadosProducao();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar o painel: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblTotalAguardando_Click(object sender, EventArgs e)
        {
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (gridProducoes.DataSource == null || ((List<ProducaoDto>)gridProducoes.DataSource).Count == 0)
            {
                MessageBox.Show("Não há dados na tela para exportar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog salvar = new SaveFileDialog
            {
                Filter = "Arquivo CSV (*.csv)|*.csv|Arquivo XML (*.xml)|*.xml",
                Title = "Exportar Painel de Produção",
                FileName = $"Producoes_{DateTime.Now:ddMMyyyy_HHmm}"
            };

            if (salvar.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var lista = (List<ProducaoDto>)gridProducoes.DataSource;

                    if (salvar.FilterIndex == 1)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("Data;Pedido;TAG;Cliente;Usuário;Status");

                        foreach (var item in lista)
                        {
                            string dataFormatada = item.DataRegistro.ToString("dd/MM/yyyy HH:mm");
                            sb.AppendLine($"{dataFormatada};{item.Pedido};{item.NumeroTag};{item.Cliente};{item.NomeUsuario};{item.Status}");
                        }
                        File.WriteAllText(salvar.FileName, sb.ToString(), Encoding.UTF8);
                    }
                    else if (salvar.FilterIndex == 2)
                    {
                        System.Xml.Linq.XElement xml = new System.Xml.Linq.XElement("Producoes",
                            from item in lista
                            select new System.Xml.Linq.XElement("Producao",
                                new System.Xml.Linq.XElement("Data", item.DataRegistro.ToString("yyyy-MM-ddTHH:mm:ss")),
                                new System.Xml.Linq.XElement("Pedido", item.Pedido),
                                new System.Xml.Linq.XElement("Tag", item.NumeroTag),
                                new System.Xml.Linq.XElement("Cliente", item.Cliente),
                                new System.Xml.Linq.XElement("Usuario", item.NomeUsuario),
                                new System.Xml.Linq.XElement("Status", item.Status)
                            )
                        );

                        xml.Save(salvar.FileName);
                    }

                    MessageBox.Show("Arquivo exportado com sucesso!", "Exportação Concluída", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao tentar exportar o arquivo: " + ex.Message, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnRegravar_Click(object sender, EventArgs e)
        {
            string tagDigitada = Helpers.UIHelper.SolicitarTag("Digite a TAG que deseja regravar:");

            if (string.IsNullOrWhiteSpace(tagDigitada)) return;

            var listaProducoes = (List<ProducaoDto>)gridProducoes.DataSource;
            var producaoAlvo = listaProducoes.FirstOrDefault(p => p.NumeroTag.Trim().ToUpper() == tagDigitada.Trim().ToUpper());

            if (producaoAlvo == null)
            {
                MessageBox.Show($"A TAG '{tagDigitada}' não foi encontrada na lista do painel.\nVerifique se digitou corretamente.", "Não Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool sucesso = await _producaoService.RegravarAsync(producaoAlvo.Id);

                if (sucesso)
                {
                    MessageBox.Show($"A TAG {producaoAlvo.NumeroTag} foi enviada para regravação com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CarregarDadosProducao();
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro na API e não foi possível regravar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar regravar: " + ex.Message, "Falha de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnFiltrar(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                var listaCompleta = await _producaoService.ObterTodasAsync();
                var query = listaCompleta.AsEnumerable();



                if (!string.IsNullOrWhiteSpace(txtFiltroPedido.Text) && !txtFiltroPedido.Text.Contains("Digite o Pedido"))
                {
                    query = query.Where(p => p.Pedido != null && p.Pedido.ToString().IndexOf(txtFiltroPedido.Text, StringComparison.OrdinalIgnoreCase) >= 0);
                }

                if (!string.IsNullOrWhiteSpace(txtFiltroCliente.Text) && !txtFiltroCliente.Text.Contains("Digite o Cliente"))
                {
                    query = query.Where(p => p.Cliente != null && p.Cliente.ToString().IndexOf(txtFiltroCliente.Text, StringComparison.OrdinalIgnoreCase) >= 0);
                }

                if (!string.IsNullOrWhiteSpace(txtFiltroTag.Text) && !txtFiltroTag.Text.Contains("Informe a TAG"))
                {
                    query = query.Where(p => p.NumeroTag != null && p.NumeroTag.ToString().IndexOf(txtFiltroTag.Text, StringComparison.OrdinalIgnoreCase) >= 0);
                }

                // Troque a comparação do Status para isto:
                if (cmbFiltroStatus.SelectedIndex > 0)
                {
                    string statusSelecionado = cmbFiltroStatus.Text.Trim();
                    query = query.Where(p => p.Status != null && p.Status.Trim().Equals(statusSelecionado, StringComparison.OrdinalIgnoreCase));
                }

                if (cmbFiltroUsuario.SelectedIndex > 0)
                {
                    string usuarioSelecionado = cmbFiltroUsuario.Text.Trim();
                    query = query.Where(p => p.NomeUsuario != null && p.NomeUsuario.Trim().Equals(usuarioSelecionado, StringComparison.OrdinalIgnoreCase));
                }

                DateTime dataInicio = dtpDataInicial.Value.Date;
                DateTime dataFim = dtpDataFinal.Value.Date.AddDays(1).AddTicks(-1);

                query = query.Where(p => p.DataRegistro >= dataInicio && p.DataRegistro <= dataFim);

                var listaFiltrada = query.ToList();

                gridProducoes.DataSource = listaFiltrada;

                int aguardando = listaFiltrada.Count(p => p.Status == "AGUARDANDO INÍCIO");
                int andamento = listaFiltrada.Count(p => p.Status == "EM ANDAMENTO");
                int finalizados = listaFiltrada.Count(p => p.Status == "FINALIZADO");
                AtualizarCardsTempoReal(aguardando, andamento, finalizados);

                // Debug: ver quantos itens sobraram
                MessageBox.Show($"O filtro encontrou {listaFiltrada.Count} registros.", "Debug do Filtro");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao filtrar os dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private async void timerSincronizacao_Tick(object sender, EventArgs e)
        {
            timerSincronizacao.Stop();

            try
            {
                var dbLocal = new DatabaseLocalService();
                await dbLocal.SincronizarTudoAsync(_producaoService);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                timerSincronizacao.Start();
            }
        }
    }
}