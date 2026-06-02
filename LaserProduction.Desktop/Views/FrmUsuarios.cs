using LaserProduction.Desktop.Services;
using LaserProduction.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LaserProduction.Desktop
{
    public partial class FrmUsuarios : ReaLTaiizor.Forms.MaterialForm
    {
        private readonly UsuarioService _usuarioService;
        private int _idUsuarioSelecionado = 0;

        public FrmUsuarios()
        {
            InitializeComponent();
            _usuarioService = new UsuarioService();
        }

        private async void FrmUsuarios_Load(object sender, EventArgs e)
        {
            Helpers.UIHelper.ConfigurarGridUsuarios(gridUsuarios);
            Helpers.UIHelper.ConfigurarComboPerfil(cmbPerfil);

            gridUsuarios.CellClick += GridUsuarios_CellClick;

            await CarregarUsuarios();
        }

        private async System.Threading.Tasks.Task CarregarUsuarios()
        {
            try
            {
                var usuarios = await _usuarioService.ObterTodosAsync();
                gridUsuarios.DataSource = usuarios;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GridUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridUsuarios.CurrentRow != null)
            {
                var selecionado = (UsuarioDto)gridUsuarios.CurrentRow.DataBoundItem;
                _idUsuarioSelecionado = selecionado.Id;
                txtNome.Text = selecionado.Nome;
                txtLogin.Text = selecionado.Login;

                txtSenha.Text = string.Empty;
                cmbPerfil.Text = selecionado.Perfil;
            }
        }

        private void LimparCampos()
        {
            _idUsuarioSelecionado = 0;
            txtNome.Text = string.Empty;
            txtLogin.Text = string.Empty;
            txtSenha.Text = string.Empty;
            cmbPerfil.SelectedIndex = -1;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) || string.IsNullOrWhiteSpace(txtLogin.Text) || string.IsNullOrWhiteSpace(txtSenha.Text) || string.IsNullOrWhiteSpace(cmbPerfil.Text))
            {
                MessageBox.Show("Preencha todos os campos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dto = new UsuarioDto
            {
                Id = _idUsuarioSelecionado,
                Nome = txtNome.Text.Trim(),
                Login = txtLogin.Text.Trim(),
                Senha = txtSenha.Text,
                Perfil = cmbPerfil.Text.Trim(),
                Ativo = 1
            };

            try
            {
                bool sucesso = _idUsuarioSelecionado == 0
                    ? await _usuarioService.CriarAsync(dto)
                    : await _usuarioService.AtualizarAsync(dto);

                if (sucesso)
                {
                    LimparCampos();
                    await CarregarUsuarios();
                    MessageBox.Show("Salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            if (_idUsuarioSelecionado == 0)
            {
                MessageBox.Show("Selecione um usuário na tabela para excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Deseja realmente excluir este usuário?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    bool sucesso = await _usuarioService.ExcluirAsync(_idUsuarioSelecionado);
                    if (sucesso)
                    {
                        LimparCampos();
                        await CarregarUsuarios();
                        MessageBox.Show("Excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    
    }
}