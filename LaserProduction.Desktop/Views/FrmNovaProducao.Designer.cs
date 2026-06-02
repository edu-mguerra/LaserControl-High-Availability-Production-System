namespace LaserProduction.Desktop.Views
{
    partial class FrmNovaProducao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnCancelar = new ReaLTaiizor.Controls.MaterialButton();
            btnSalvar = new ReaLTaiizor.Controls.MaterialButton();
            tableLayoutPanel1 = new TableLayoutPanel();
            txtQuantidade = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            txtCliente = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            txtPedido = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            cmbMaquina = new ReaLTaiizor.Controls.MaterialComboBox();
            flowLayoutPanel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnCancelar);
            flowLayoutPanel1.Controls.Add(btnSalvar);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(3, 741);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1479, 74);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // btnCancelar
            // 
            btnCancelar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCancelar.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnCancelar.Depth = 0;
            btnCancelar.HighEmphasis = true;
            btnCancelar.Icon = null;
            btnCancelar.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnCancelar.Location = new Point(1339, 6);
            btnCancelar.Margin = new Padding(4, 6, 4, 6);
            btnCancelar.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnCancelar.Name = "btnCancelar";
            btnCancelar.NoAccentTextColor = Color.Empty;
            btnCancelar.Size = new Size(136, 54);
            btnCancelar.TabIndex = 0;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnCancelar.UseAccentColor = false;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSalvar.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSalvar.Depth = 0;
            btnSalvar.HighEmphasis = true;
            btnSalvar.Icon = null;
            btnSalvar.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnSalvar.Location = new Point(1108, 6);
            btnSalvar.Margin = new Padding(4, 6, 4, 6);
            btnSalvar.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnSalvar.Name = "btnSalvar";
            btnSalvar.NoAccentTextColor = Color.Empty;
            btnSalvar.Size = new Size(223, 54);
            btnSalvar.TabIndex = 1;
            btnSalvar.Text = "INICIAR PRODUÇÃO";
            btnSalvar.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSalvar.UseAccentColor = false;
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(txtQuantidade, 0, 2);
            tableLayoutPanel1.Controls.Add(txtCliente, 0, 1);
            tableLayoutPanel1.Controls.Add(txtPedido, 0, 0);
            tableLayoutPanel1.Controls.Add(cmbMaquina, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(3, 93);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Size = new Size(1479, 642);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // txtQuantidade
            // 
            txtQuantidade.AnimateReadOnly = false;
            txtQuantidade.AutoCompleteMode = AutoCompleteMode.None;
            txtQuantidade.AutoCompleteSource = AutoCompleteSource.None;
            txtQuantidade.BackgroundImageLayout = ImageLayout.None;
            txtQuantidade.CharacterCasing = CharacterCasing.Normal;
            txtQuantidade.Depth = 0;
            txtQuantidade.Dock = DockStyle.Fill;
            txtQuantidade.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtQuantidade.HideSelection = true;
            txtQuantidade.LeadingIcon = null;
            txtQuantidade.Location = new Point(3, 323);
            txtQuantidade.MaxLength = 32767;
            txtQuantidade.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtQuantidade.Name = "txtQuantidade";
            txtQuantidade.PasswordChar = '\0';
            txtQuantidade.PrefixSuffixText = null;
            txtQuantidade.ReadOnly = false;
            txtQuantidade.RightToLeft = RightToLeft.No;
            txtQuantidade.SelectedText = "";
            txtQuantidade.SelectionLength = 0;
            txtQuantidade.SelectionStart = 0;
            txtQuantidade.ShortcutsEnabled = true;
            txtQuantidade.Size = new Size(1473, 72);
            txtQuantidade.TabIndex = 2;
            txtQuantidade.TabStop = false;
            txtQuantidade.Text = "Quantidade de TAG's";
            txtQuantidade.TextAlign = HorizontalAlignment.Left;
            txtQuantidade.TrailingIcon = null;
            txtQuantidade.UseSystemPasswordChar = false;
            // 
            // txtCliente
            // 
            txtCliente.AnimateReadOnly = false;
            txtCliente.AutoCompleteMode = AutoCompleteMode.None;
            txtCliente.AutoCompleteSource = AutoCompleteSource.None;
            txtCliente.BackgroundImageLayout = ImageLayout.None;
            txtCliente.CharacterCasing = CharacterCasing.Normal;
            txtCliente.Depth = 0;
            txtCliente.Dock = DockStyle.Fill;
            txtCliente.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtCliente.HideSelection = true;
            txtCliente.LeadingIcon = null;
            txtCliente.Location = new Point(3, 163);
            txtCliente.MaxLength = 32767;
            txtCliente.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtCliente.Name = "txtCliente";
            txtCliente.PasswordChar = '\0';
            txtCliente.PrefixSuffixText = null;
            txtCliente.ReadOnly = false;
            txtCliente.RightToLeft = RightToLeft.No;
            txtCliente.SelectedText = "";
            txtCliente.SelectionLength = 0;
            txtCliente.SelectionStart = 0;
            txtCliente.ShortcutsEnabled = true;
            txtCliente.Size = new Size(1473, 72);
            txtCliente.TabIndex = 1;
            txtCliente.TabStop = false;
            txtCliente.Text = "Nome do Cliente";
            txtCliente.TextAlign = HorizontalAlignment.Left;
            txtCliente.TrailingIcon = null;
            txtCliente.UseSystemPasswordChar = false;
            // 
            // txtPedido
            // 
            txtPedido.AnimateReadOnly = false;
            txtPedido.AutoCompleteMode = AutoCompleteMode.None;
            txtPedido.AutoCompleteSource = AutoCompleteSource.None;
            txtPedido.BackgroundImageLayout = ImageLayout.None;
            txtPedido.CharacterCasing = CharacterCasing.Normal;
            txtPedido.Depth = 0;
            txtPedido.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtPedido.HideSelection = true;
            txtPedido.LeadingIcon = null;
            txtPedido.Location = new Point(3, 3);
            txtPedido.MaxLength = 32767;
            txtPedido.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtPedido.Name = "txtPedido";
            txtPedido.PasswordChar = '\0';
            txtPedido.PrefixSuffixText = null;
            txtPedido.ReadOnly = false;
            txtPedido.RightToLeft = RightToLeft.No;
            txtPedido.SelectedText = "";
            txtPedido.SelectionLength = 0;
            txtPedido.SelectionStart = 0;
            txtPedido.ShortcutsEnabled = true;
            txtPedido.Size = new Size(1393, 72);
            txtPedido.TabIndex = 0;
            txtPedido.TabStop = false;
            txtPedido.Text = "Número do Pedido";
            txtPedido.TextAlign = HorizontalAlignment.Left;
            txtPedido.TrailingIcon = null;
            txtPedido.UseSystemPasswordChar = false;
            // 
            // cmbMaquina
            // 
            cmbMaquina.AutoResize = false;
            cmbMaquina.BackColor = Color.FromArgb(255, 255, 255);
            cmbMaquina.Depth = 0;
            cmbMaquina.DrawMode = DrawMode.OwnerDrawVariable;
            cmbMaquina.DropDownHeight = 263;
            cmbMaquina.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMaquina.DropDownWidth = 121;
            cmbMaquina.Font = new Font("Microsoft Sans Serif", 21F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbMaquina.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbMaquina.FormattingEnabled = true;
            cmbMaquina.IntegralHeight = false;
            cmbMaquina.ItemHeight = 65;
            cmbMaquina.Location = new Point(3, 483);
            cmbMaquina.MaxDropDownItems = 4;
            cmbMaquina.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            cmbMaquina.Name = "cmbMaquina";
            cmbMaquina.Size = new Size(355, 71);
            cmbMaquina.StartIndex = 0;
            cmbMaquina.TabIndex = 3;
            // 
            // FrmNovaProducao
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1485, 818);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(tableLayoutPanel1);
            Name = "FrmNovaProducao";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nova Producao";
            Load += FrmNovaProducao_Load;
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private ReaLTaiizor.Controls.MaterialButton btnCancelar;
        private ReaLTaiizor.Controls.MaterialButton btnSalvar;
        private TableLayoutPanel tableLayoutPanel1;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit txtPedido;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit txtCliente;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit MaterialTextBoxEdit;
        private ReaLTaiizor.Controls.MaterialComboBox cmbMaquina;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit txtQuantidade;
    }
}