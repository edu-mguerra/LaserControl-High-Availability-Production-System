namespace LaserProduction.Desktop.Views
{
    partial class FrmParametros
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
            cmbPortaLaser = new ReaLTaiizor.Controls.MaterialComboBox();
            txtPrefixoLote = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            txtPastaBackup = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            btnSalvar = new ReaLTaiizor.Controls.MaterialButton();
            btnCancelar = new ReaLTaiizor.Controls.MaterialButton();
            flowLayoutPanel1 = new FlowLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // cmbPortaLaser
            // 
            cmbPortaLaser.AutoResize = false;
            cmbPortaLaser.BackColor = Color.FromArgb(255, 255, 255);
            cmbPortaLaser.Depth = 0;
            cmbPortaLaser.Dock = DockStyle.Fill;
            cmbPortaLaser.DrawMode = DrawMode.OwnerDrawVariable;
            cmbPortaLaser.DropDownHeight = 263;
            cmbPortaLaser.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPortaLaser.DropDownWidth = 121;
            cmbPortaLaser.Font = new Font("Microsoft Sans Serif", 21F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbPortaLaser.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbPortaLaser.FormattingEnabled = true;
            cmbPortaLaser.IntegralHeight = false;
            cmbPortaLaser.ItemHeight = 65;
            cmbPortaLaser.Items.AddRange(new object[] { "COM1", "COM2 ", "COM3 ", "COM4" });
            cmbPortaLaser.Location = new Point(10, 262);
            cmbPortaLaser.Margin = new Padding(10);
            cmbPortaLaser.MaxDropDownItems = 4;
            cmbPortaLaser.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            cmbPortaLaser.Name = "cmbPortaLaser";
            cmbPortaLaser.Size = new Size(1263, 71);
            cmbPortaLaser.StartIndex = 0;
            cmbPortaLaser.TabIndex = 0;
            // 
            // txtPrefixoLote
            // 
            txtPrefixoLote.AnimateReadOnly = false;
            txtPrefixoLote.AutoCompleteMode = AutoCompleteMode.None;
            txtPrefixoLote.AutoCompleteSource = AutoCompleteSource.None;
            txtPrefixoLote.BackgroundImageLayout = ImageLayout.None;
            txtPrefixoLote.CharacterCasing = CharacterCasing.Normal;
            txtPrefixoLote.Depth = 0;
            txtPrefixoLote.Dock = DockStyle.Fill;
            txtPrefixoLote.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtPrefixoLote.HideSelection = true;
            txtPrefixoLote.LeadingIcon = null;
            txtPrefixoLote.Location = new Point(10, 10);
            txtPrefixoLote.Margin = new Padding(10);
            txtPrefixoLote.MaxLength = 32767;
            txtPrefixoLote.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtPrefixoLote.Name = "txtPrefixoLote";
            txtPrefixoLote.PasswordChar = '\0';
            txtPrefixoLote.PrefixSuffixText = null;
            txtPrefixoLote.ReadOnly = false;
            txtPrefixoLote.RightToLeft = RightToLeft.No;
            txtPrefixoLote.SelectedText = "";
            txtPrefixoLote.SelectionLength = 0;
            txtPrefixoLote.SelectionStart = 0;
            txtPrefixoLote.ShortcutsEnabled = true;
            txtPrefixoLote.Size = new Size(1263, 72);
            txtPrefixoLote.TabIndex = 1;
            txtPrefixoLote.TabStop = false;
            txtPrefixoLote.Text = "Digite o Prefixo deo Lote (Ex: LT-)";
            txtPrefixoLote.TextAlign = HorizontalAlignment.Left;
            txtPrefixoLote.TrailingIcon = null;
            txtPrefixoLote.UseSystemPasswordChar = false;
            // 
            // txtPastaBackup
            // 
            txtPastaBackup.AnimateReadOnly = false;
            txtPastaBackup.AutoCompleteMode = AutoCompleteMode.None;
            txtPastaBackup.AutoCompleteSource = AutoCompleteSource.None;
            txtPastaBackup.BackgroundImageLayout = ImageLayout.None;
            txtPastaBackup.CharacterCasing = CharacterCasing.Normal;
            txtPastaBackup.Depth = 0;
            txtPastaBackup.Dock = DockStyle.Fill;
            txtPastaBackup.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtPastaBackup.HideSelection = true;
            txtPastaBackup.LeadingIcon = null;
            txtPastaBackup.Location = new Point(10, 136);
            txtPastaBackup.Margin = new Padding(10);
            txtPastaBackup.MaxLength = 32767;
            txtPastaBackup.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtPastaBackup.Name = "txtPastaBackup";
            txtPastaBackup.PasswordChar = '\0';
            txtPastaBackup.PrefixSuffixText = null;
            txtPastaBackup.ReadOnly = false;
            txtPastaBackup.RightToLeft = RightToLeft.No;
            txtPastaBackup.SelectedText = "";
            txtPastaBackup.SelectionLength = 0;
            txtPastaBackup.SelectionStart = 0;
            txtPastaBackup.ShortcutsEnabled = true;
            txtPastaBackup.Size = new Size(1263, 72);
            txtPastaBackup.TabIndex = 2;
            txtPastaBackup.TabStop = false;
            txtPastaBackup.Text = "Digite Caminho do Backup Offline (Ex: C:\\Laser\\)";
            txtPastaBackup.TextAlign = HorizontalAlignment.Left;
            txtPastaBackup.TrailingIcon = null;
            txtPastaBackup.UseSystemPasswordChar = false;
            // 
            // btnSalvar
            // 
            btnSalvar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSalvar.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSalvar.Depth = 0;
            btnSalvar.HighEmphasis = true;
            btnSalvar.Icon = null;
            btnSalvar.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnSalvar.Location = new Point(1029, 6);
            btnSalvar.Margin = new Padding(4, 6, 4, 6);
            btnSalvar.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnSalvar.Name = "btnSalvar";
            btnSalvar.NoAccentTextColor = Color.Empty;
            btnSalvar.Size = new Size(106, 54);
            btnSalvar.TabIndex = 3;
            btnSalvar.Text = "SALVAR";
            btnSalvar.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSalvar.UseAccentColor = false;
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCancelar.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnCancelar.Depth = 0;
            btnCancelar.HighEmphasis = true;
            btnCancelar.Icon = null;
            btnCancelar.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnCancelar.Location = new Point(1143, 6);
            btnCancelar.Margin = new Padding(4, 6, 4, 6);
            btnCancelar.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnCancelar.Name = "btnCancelar";
            btnCancelar.NoAccentTextColor = Color.Empty;
            btnCancelar.Size = new Size(136, 54);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnCancelar.UseAccentColor = false;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnCancelar);
            flowLayoutPanel1.Controls.Add(btnSalvar);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(3, 732);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1283, 67);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(txtPastaBackup, 0, 1);
            tableLayoutPanel1.Controls.Add(cmbPortaLaser, 0, 2);
            tableLayoutPanel1.Controls.Add(txtPrefixoLote, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(3, 93);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Size = new Size(1283, 380);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // FrmParametros
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1289, 802);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(tableLayoutPanel1);
            Name = "FrmParametros";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Parametros";
            Load += FrmParametros_Load;
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.MaterialComboBox cmbPortaLaser;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit txtPrefixoLote;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit txtPastaBackup;
        private ReaLTaiizor.Controls.MaterialButton btnSalvar;
        private ReaLTaiizor.Controls.MaterialButton btnCancelar;
        private FlowLayoutPanel flowLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel1;
    }
}