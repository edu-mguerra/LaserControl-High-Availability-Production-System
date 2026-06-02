using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Json;
using LaserProduction.Shared.DTOs;
using LaserProduction.Shared.Models;
using System.Threading.Tasks;

namespace LaserProduction.Desktop.Views
{
    public partial class FrmLogin : ReaLTaiizor.Forms.MaterialForm
    {
        public FrmLogin()
        {
            InitializeComponent();
        }



        private async void btnEntrar_Click(object sender, EventArgs e)
        {
            string usuarioDigitado = txtUsuario.Text.Trim();
            string senhaDigitada = txtSenha.Text.Trim();

            if (string.IsNullOrWhiteSpace(usuarioDigitado) || string.IsNullOrWhiteSpace(senhaDigitada))
            {
                MessageBox.Show("Por favor, preencha o usuário ou a senha.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return;
            }

            try
            {
                btnEntrar.Text = "AGUARDE...";
                btnEntrar.Enabled = false;

                var requestData = new LoginDto
                {
                    Login = usuarioDigitado,
                    Senha = senhaDigitada
                };

                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(8);

                    string urlApi = "https://localhost:7075/api/auth/login";

                    HttpResponseMessage response = await client.PostAsJsonAsync(urlApi, requestData);

                    if (response.IsSuccessStatusCode)
                    {
                        Usuario usuarioLogado = await response.Content.ReadFromJsonAsync<Usuario>();

                        FrmPrincipal formPrincipal = new FrmPrincipal(usuarioLogado.Perfil);
                        this.Hide();
                        formPrincipal.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Usuário ou senha inválidos. Tente novamente.", "Erro de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        txtSenha.Clear();
                        txtSenha.Focus();

                        btnEntrar.Text = "ENTRAR";
                        btnEntrar.Enabled = true;
                    }
                }
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Não foi possível conectar ao servidor de autenticação.\nVerifique se a API do sistema está rodando.", "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetarBotaoLogin();
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("O servidor demorou muito para responder. Verifique sua conexão e tente novamente.", "Tempo Limite Excedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetarBotaoLogin();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao tentar realizar o login: " + ex.Message, "Erro Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetarBotaoLogin();
            }
        }

        private void ResetarBotaoLogin()
        {
            btnEntrar.Text = "ENTRAR";
            btnEntrar.Enabled = true;
            txtSenha.Clear();
            txtSenha.Focus();
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnEntrar.PerformClick();
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}