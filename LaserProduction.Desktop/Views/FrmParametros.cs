using LaserProduction.Desktop.Services;
using LaserProduction.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaserProduction.Desktop.Views
{
    public partial class FrmParametros : ReaLTaiizor.Forms.MaterialForm
    {
        private readonly ParametrosService _parametrosService;

        public FrmParametros()
        {
            InitializeComponent();
            _parametrosService = new ParametrosService();
        }

        private async void FrmParametros_Load(object sender, EventArgs e)
        {
            cmbPortaLaser.Hint = "Porta da Máquina Laser";
            cmbPortaLaser.Items.Clear();
            cmbPortaLaser.Items.AddRange(new string[] { "COM1", "COM2", "COM3", "COM4", "COM5" });
            cmbPortaLaser.SelectedIndex = 0;

            try
            {
                ParametrosDto param = await _parametrosService.ObterParametrosAsync();

                if (cmbPortaLaser.Items.Contains(param.PortaLaser))
                {
                    cmbPortaLaser.SelectedItem = param.PortaLaser;
                }
                else
                {
                    cmbPortaLaser.Text = param.PortaLaser;
                }

                txtPrefixoLote.Text = param.PrefixoLote;
                txtPastaBackup.Text = param.CaminhoBackup;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os parâmetros: " + ex.Message, "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            btnSalvar.Enabled = false;
            btnSalvar.Text = "SALVANDO...";

            try
            {
                var paramAtualizado = new ParametrosDto
                {
                    PortaLaser = cmbPortaLaser.SelectedItem?.ToString() ?? cmbPortaLaser.Text,
                    PrefixoLote = txtPrefixoLote.Text.Trim(),
                    CaminhoBackup = txtPastaBackup.Text.Trim()
                };

                await _parametrosService.AtualizarParametrosAsync(paramAtualizado);

                MessageBox.Show("Parâmetros salvos com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar os parâmetros: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSalvar.Enabled = true;
                btnSalvar.Text = "SALVAR";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}