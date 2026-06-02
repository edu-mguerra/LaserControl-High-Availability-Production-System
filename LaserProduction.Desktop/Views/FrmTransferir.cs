using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LaserProduction.Desktop.Services;
using LaserProduction.Shared.DTOs;

namespace LaserProduction.Desktop.Views
{
    public partial class FrmTransferir : ReaLTaiizor.Forms.MaterialForm
    {
        private string _tagInicial;
        private ProducaoService _producaoService;

        public FrmTransferir(string tag)
        {
            InitializeComponent();
            _tagInicial = tag;
            _producaoService = new ProducaoService();
        }

        private async void FrmTransferir_Load(object sender, EventArgs e)
        {
            lblInfo.Text = "Selecione as TAGs que deseja transferir:";

            var maquinas = await _producaoService.ObterMaquinasAtivasAsync();

            if (maquinas != null && maquinas.Count > 0)
            {
                cmbMaquinas.DataSource = maquinas;
                cmbMaquinas.DisplayMember = "Nome";
                cmbMaquinas.ValueMember = "Id";
            }
            else
            {
                MessageBox.Show("Nenhuma máquina ativa encontrada no sistema.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            await CarregarTagsDisponiveis();
        }

        private async Task CarregarTagsDisponiveis()
        {
            try
            {
                clbTags.Items.Clear();

                var producoes = await _producaoService.ObterTodasAsync();

                var tagsAtivas = producoes
    .Where(p => p.Status != "FINALIZADO" && !string.IsNullOrWhiteSpace(p.NumeroTag))
    .Select(p => p.NumeroTag)
    .Distinct()
    .ToList();

                foreach (var tag in tagsAtivas)
                {
                    clbTags.Items.Add(tag);

                    if (!string.IsNullOrEmpty(_tagInicial) && tag.Trim().Equals(_tagInicial.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        int index = clbTags.Items.Count - 1;
                        clbTags.SetItemChecked(index, true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar as TAGs disponíveis: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private async void btnTransferir_Click_Click(object sender, EventArgs e)
        {
            if (clbTags.CheckedItems.Count == 0)
            {
                MessageBox.Show("Por favor, marque pelo menos uma TAG na lista para transferir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbMaquinas.SelectedValue == null)
            {
                MessageBox.Show("Por favor, selecione a máquina de destino antes de confirmar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idMaquinaDestino = (int)cmbMaquinas.SelectedValue;
            string nomeMaquinaDestino = cmbMaquinas.Text;

            int sucessoContador = 0;
            List<string> falhas = new List<string>();

            foreach (var item in clbTags.CheckedItems)
            {
                string tagAtual = item.ToString();
                string resultado = await _producaoService.TransferirMaquinaAsync(tagAtual, idMaquinaDestino);

                if (resultado == "OK")
                {
                    sucessoContador++;
                }
                else
                {
                    falhas.Add($"{tagAtual} ({resultado})");
                }
            }

            if (falhas.Count == 0)
            {
                MessageBox.Show($"{sucessoContador} TAG(s) transferida(s) para a '{nomeMaquinaDestino}' com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Processo concluído com avisos.\nSucessos: {sucessoContador}\nFalhas:\n{string.Join("\n", falhas)}", "Aviso de Transferência", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}