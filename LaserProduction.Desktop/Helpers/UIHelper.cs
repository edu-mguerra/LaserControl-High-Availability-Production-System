using ReaLTaiizor.Controls;



namespace LaserProduction.Desktop.Helpers
{
    public static class UIHelper
    {
        public static void ConfigurarGrid(DataGridView grid)
        {
            if (grid == null) return;

            grid.Columns.Clear();
            grid.AutoGenerateColumns = false;

            grid.DefaultCellStyle.Font = new Font("Segoe UI", 12);
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            grid.ColumnHeadersHeight = 45;
            grid.RowTemplate.Height = 40;
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grid.Columns.Add("Data", "Data e Hora");
            grid.Columns.Add("Pedido", "Pedido (Order)");
            grid.Columns.Add("TAG", "TAG (Número da Produção)");
            grid.Columns.Add("Cliente", "Cliente");
            grid.Columns.Add("Usuario", "Usuário");
            grid.Columns.Add("Status", "Status");

            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            grid.Columns["TAG"].FillWeight = 150;
            grid.Columns["Cliente"].FillWeight = 120;

            grid.Columns["Pedido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public static void ConfigurarComboStatus(MaterialComboBox comboStatus)
        {
            if (comboStatus == null) return;

            comboStatus.Items.Clear();
            comboStatus.Items.Add("Todos os Status");
            comboStatus.Items.Add("Aguardando");
            comboStatus.Items.Add("Em Andamento");
            comboStatus.Items.Add("Finalizado");
            comboStatus.SelectedIndex = 0;
        }

        public static void ConfigurarComboUsuario(MaterialComboBox comboUsuario)
        {
            if (comboUsuario == null) return;

            comboUsuario.Items.Clear();
            comboUsuario.Items.Add("Todos os Usuários");
            comboUsuario.Items.Add("Admin");
            comboUsuario.Items.Add("Operador 1");
            comboUsuario.SelectedIndex = 0;
        }

      

        public static void ConfigurarComboPerfil(ReaLTaiizor.Controls.MaterialComboBox comboPerfil)
        {
            if (comboPerfil == null) return;

            comboPerfil.Items.Clear();
            comboPerfil.Items.Add("COMUM");
            comboPerfil.Items.Add("MASTER");
            comboPerfil.SelectedIndex = 0; 
        }

        public static void ConfigurarColunasManual(DataGridView gridProducoes)
        {
            gridProducoes.AutoGenerateColumns = false; 
            gridProducoes.Columns.Clear(); 

          
            gridProducoes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Data", DataPropertyName = "DataRegistro", Width = 150 });
            gridProducoes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Pedido", DataPropertyName = "Pedido", Width = 100 });
            gridProducoes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "TAG", DataPropertyName = "NumeroTag", Width = 120 });
            gridProducoes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Cliente", DataPropertyName = "Cliente", Width = 200 });
            gridProducoes.Columns.Add(new DataGridViewTextBoxColumn {HeaderText = "Usuário", DataPropertyName = "NomeUsuario",  Width = 150  });
            gridProducoes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Status", DataPropertyName = "Status", Width = 120 });
        }

        public static string SolicitarTag(string tagEsperada)
        {
            System.Windows.Forms.Form prompt = new System.Windows.Forms.Form()
            {
                Width = 450,
                Height = 220,
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog,
                Text = "Confirmação de Segurança",
                StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = System.Drawing.Color.White
            };

            System.Drawing.Font fonteMaior = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
            System.Drawing.Font fonteBotao = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            System.Windows.Forms.Label lblTexto = new System.Windows.Forms.Label()
            {
                Left = 20,
                Top = 20,
                AutoSize = true,
                Text = $"Digite a TAG para confirmar:",
                Font = fonteMaior
            };

            System.Windows.Forms.TextBox txtTag = new System.Windows.Forms.TextBox()
            {
                Left = 20,
                Top = 60,
                Width = 390,
                Font = fonteMaior,
                CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            };

            System.Windows.Forms.Button btnCancelar = new System.Windows.Forms.Button()
            {
                Text = "CANCELAR",
                Left = 90,
                Width = 150,
                Height = 40,
                Top = 115,
                DialogResult = System.Windows.Forms.DialogResult.Cancel,
                Font = fonteBotao,
                Cursor = System.Windows.Forms.Cursors.Hand,
                BackColor = System.Drawing.Color.WhiteSmoke
            };

            System.Windows.Forms.Button btnOk = new System.Windows.Forms.Button()
            {
                Text = "CONFIRMAR",
                Left = 260,
                Width = 150,
                Height = 40,
                Top = 115,
                DialogResult = System.Windows.Forms.DialogResult.OK,
                Font = fonteBotao,
                Cursor = System.Windows.Forms.Cursors.Hand,
                BackColor = System.Drawing.Color.FromArgb(63, 81, 181),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat
            };
            btnOk.FlatAppearance.BorderSize = 0;

            prompt.Controls.Add(lblTexto);
            prompt.Controls.Add(txtTag);
            prompt.Controls.Add(btnOk);
            prompt.Controls.Add(btnCancelar);
            prompt.AcceptButton = btnOk;

            return prompt.ShowDialog() == System.Windows.Forms.DialogResult.OK ? txtTag.Text : "";
        }


        public static void ConfigurarGridUsuarios(System.Windows.Forms.DataGridView grid)
        {
            grid.AutoGenerateColumns = false;
            grid.Columns.Clear();

            grid.BackgroundColor = System.Drawing.Color.White;
            grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            grid.RowHeadersVisible = false;

            grid.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(63, 81, 181);
            grid.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            grid.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            grid.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            grid.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);

            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(0, 188, 212);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);

            grid.ColumnHeadersHeight = 45;
            grid.RowTemplate.Height = 40;
            grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.ReadOnly = true;

            grid.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
            {
                Name = "colNome",
                HeaderText = "Nome Completo",
                DataPropertyName = "Nome",
                AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            });

            grid.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
            {
                Name = "colLogin",
                HeaderText = "Usuário (Login)",
                DataPropertyName = "Login",
                Width = 250
            });

            grid.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
            {
                Name = "colPerfil",
                HeaderText = "Perfil de Acesso",
                DataPropertyName = "Perfil",
                Width = 200
            });
        }


    }
}