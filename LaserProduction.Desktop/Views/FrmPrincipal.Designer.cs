namespace LaserProduction.Desktop
{
    partial class FrmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            pnlFiltros = new ReaLTaiizor.Controls.MaterialCard();
            tableLayoutPanel = new TableLayoutPanel();
            btnFiltrar_Click = new ReaLTaiizor.Controls.AirButton();
            txtFiltroPedido = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            txtFiltroTag = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            cmbFiltroUsuario = new ReaLTaiizor.Controls.MaterialComboBox();
            txtFiltroCliente = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            cmbFiltroStatus = new ReaLTaiizor.Controls.MaterialComboBox();
            dtpDataInicial = new DateTimePicker();
            dtpDataFinal = new DateTimePicker();
            pnlRodape = new ReaLTaiizor.Controls.MaterialCard();
            flowLayoutPanel2 = new FlowLayoutPanel();
            btnUsuarios = new ReaLTaiizor.Controls.MaterialButton();
            btnParametros = new ReaLTaiizor.Controls.MaterialButton();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnNovaProducao = new ReaLTaiizor.Controls.MaterialButton();
            btnExportar = new ReaLTaiizor.Controls.MaterialButton();
            btnTransferir = new ReaLTaiizor.Controls.MaterialButton();
            btnRegravar = new ReaLTaiizor.Controls.MaterialButton();
            pnlGrid = new ReaLTaiizor.Controls.MaterialCard();
            gridProducoes = new ReaLTaiizor.Controls.PoisonDataGridView();
            tableLayoutPanel1 = new TableLayoutPanel();
            materialCard4 = new ReaLTaiizor.Controls.MaterialCard();
            lblTotalFinalizado = new ReaLTaiizor.Controls.MaterialLabel();
            FINALIZADOS = new ReaLTaiizor.Controls.MaterialLabel();
            materialCard3 = new ReaLTaiizor.Controls.MaterialCard();
            lblTotalAndamento = new ReaLTaiizor.Controls.MaterialLabel();
            materialLabel2 = new ReaLTaiizor.Controls.MaterialLabel();
            materialCard1 = new ReaLTaiizor.Controls.MaterialCard();
            lblTotalAguardando = new ReaLTaiizor.Controls.MaterialLabel();
            materialLabel1 = new ReaLTaiizor.Controls.MaterialLabel();
            timerSincronizacao = new System.Windows.Forms.Timer(components);
            pnlFiltros.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            pnlRodape.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridProducoes).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            materialCard4.SuspendLayout();
            materialCard3.SuspendLayout();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlFiltros
            // 
            pnlFiltros.BackColor = Color.FromArgb(255, 255, 255);
            pnlFiltros.Controls.Add(tableLayoutPanel);
            pnlFiltros.Depth = 0;
            pnlFiltros.Dock = DockStyle.Top;
            pnlFiltros.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlFiltros.Location = new Point(3, 93);
            pnlFiltros.Margin = new Padding(21);
            pnlFiltros.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Padding = new Padding(21);
            pnlFiltros.Size = new Size(1696, 120);
            pnlFiltros.TabIndex = 0;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 7;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.Controls.Add(btnFiltrar_Click, 6, 0);
            tableLayoutPanel.Controls.Add(txtFiltroPedido, 0, 0);
            tableLayoutPanel.Controls.Add(txtFiltroTag, 2, 0);
            tableLayoutPanel.Controls.Add(cmbFiltroUsuario, 4, 0);
            tableLayoutPanel.Controls.Add(txtFiltroCliente, 1, 0);
            tableLayoutPanel.Controls.Add(cmbFiltroStatus, 3, 0);
            tableLayoutPanel.Controls.Add(dtpDataInicial, 5, 0);
            tableLayoutPanel.Controls.Add(dtpDataFinal, 5, 1);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(21, 21);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel.Size = new Size(1654, 78);
            tableLayoutPanel.TabIndex = 0;
            // 
            // btnFiltrar_Click
            // 
            btnFiltrar_Click.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w==";
            btnFiltrar_Click.Dock = DockStyle.Right;
            btnFiltrar_Click.Font = new Font("Segoe UI", 9F);
            btnFiltrar_Click.Image = null;
            btnFiltrar_Click.Location = new Point(1501, 3);
            btnFiltrar_Click.Name = "btnFiltrar_Click";
            btnFiltrar_Click.NoRounding = false;
            btnFiltrar_Click.Size = new Size(150, 33);
            btnFiltrar_Click.TabIndex = 4;
            btnFiltrar_Click.Text = "Filtrar";
            btnFiltrar_Click.Transparent = false;
            btnFiltrar_Click.Click += btnFiltrar;
            // 
            // txtFiltroPedido
            // 
            txtFiltroPedido.AnimateReadOnly = false;
            txtFiltroPedido.AutoCompleteMode = AutoCompleteMode.None;
            txtFiltroPedido.AutoCompleteSource = AutoCompleteSource.None;
            txtFiltroPedido.BackgroundImageLayout = ImageLayout.None;
            txtFiltroPedido.CharacterCasing = CharacterCasing.Normal;
            txtFiltroPedido.Depth = 0;
            txtFiltroPedido.Dock = DockStyle.Fill;
            txtFiltroPedido.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtFiltroPedido.HideSelection = true;
            txtFiltroPedido.LeadingIcon = null;
            txtFiltroPedido.Location = new Point(3, 3);
            txtFiltroPedido.MaxLength = 32767;
            txtFiltroPedido.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtFiltroPedido.Name = "txtFiltroPedido";
            txtFiltroPedido.PasswordChar = '\0';
            txtFiltroPedido.PrefixSuffixText = null;
            txtFiltroPedido.ReadOnly = false;
            txtFiltroPedido.RightToLeft = RightToLeft.No;
            txtFiltroPedido.SelectedText = "";
            txtFiltroPedido.SelectionLength = 0;
            txtFiltroPedido.SelectionStart = 0;
            txtFiltroPedido.ShortcutsEnabled = true;
            txtFiltroPedido.Size = new Size(230, 72);
            txtFiltroPedido.TabIndex = 3;
            txtFiltroPedido.TabStop = false;
            txtFiltroPedido.Text = "Digite o Pedido";
            txtFiltroPedido.TextAlign = HorizontalAlignment.Left;
            txtFiltroPedido.TrailingIcon = null;
            txtFiltroPedido.UseSystemPasswordChar = false;
            // 
            // txtFiltroTag
            // 
            txtFiltroTag.AnimateReadOnly = false;
            txtFiltroTag.AutoCompleteMode = AutoCompleteMode.None;
            txtFiltroTag.AutoCompleteSource = AutoCompleteSource.None;
            txtFiltroTag.BackgroundImageLayout = ImageLayout.None;
            txtFiltroTag.CharacterCasing = CharacterCasing.Normal;
            txtFiltroTag.Depth = 0;
            txtFiltroTag.Dock = DockStyle.Fill;
            txtFiltroTag.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtFiltroTag.HideSelection = true;
            txtFiltroTag.LeadingIcon = null;
            txtFiltroTag.Location = new Point(475, 3);
            txtFiltroTag.MaxLength = 32767;
            txtFiltroTag.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtFiltroTag.Name = "txtFiltroTag";
            txtFiltroTag.PasswordChar = '\0';
            txtFiltroTag.PrefixSuffixText = null;
            txtFiltroTag.ReadOnly = false;
            txtFiltroTag.RightToLeft = RightToLeft.No;
            txtFiltroTag.SelectedText = "";
            txtFiltroTag.SelectionLength = 0;
            txtFiltroTag.SelectionStart = 0;
            txtFiltroTag.ShortcutsEnabled = true;
            txtFiltroTag.Size = new Size(230, 72);
            txtFiltroTag.TabIndex = 5;
            txtFiltroTag.TabStop = false;
            txtFiltroTag.Text = "Informe a TAG";
            txtFiltroTag.TextAlign = HorizontalAlignment.Left;
            txtFiltroTag.TrailingIcon = null;
            txtFiltroTag.UseSystemPasswordChar = false;
            // 
            // cmbFiltroUsuario
            // 
            cmbFiltroUsuario.AutoResize = false;
            cmbFiltroUsuario.BackColor = Color.FromArgb(255, 255, 255);
            cmbFiltroUsuario.Depth = 0;
            cmbFiltroUsuario.Dock = DockStyle.Fill;
            cmbFiltroUsuario.DrawMode = DrawMode.OwnerDrawVariable;
            cmbFiltroUsuario.DropDownHeight = 263;
            cmbFiltroUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroUsuario.DropDownWidth = 121;
            cmbFiltroUsuario.Font = new Font("Microsoft Sans Serif", 21F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbFiltroUsuario.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbFiltroUsuario.FormattingEnabled = true;
            cmbFiltroUsuario.IntegralHeight = false;
            cmbFiltroUsuario.ItemHeight = 65;
            cmbFiltroUsuario.Location = new Point(947, 3);
            cmbFiltroUsuario.MaxDropDownItems = 4;
            cmbFiltroUsuario.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            cmbFiltroUsuario.Name = "cmbFiltroUsuario";
            cmbFiltroUsuario.Size = new Size(230, 71);
            cmbFiltroUsuario.StartIndex = 0;
            cmbFiltroUsuario.TabIndex = 7;
            // 
            // txtFiltroCliente
            // 
            txtFiltroCliente.AnimateReadOnly = false;
            txtFiltroCliente.AutoCompleteMode = AutoCompleteMode.None;
            txtFiltroCliente.AutoCompleteSource = AutoCompleteSource.None;
            txtFiltroCliente.BackgroundImageLayout = ImageLayout.None;
            txtFiltroCliente.CharacterCasing = CharacterCasing.Normal;
            txtFiltroCliente.Depth = 0;
            txtFiltroCliente.Dock = DockStyle.Fill;
            txtFiltroCliente.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtFiltroCliente.HideSelection = true;
            txtFiltroCliente.LeadingIcon = null;
            txtFiltroCliente.Location = new Point(239, 3);
            txtFiltroCliente.MaxLength = 32767;
            txtFiltroCliente.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtFiltroCliente.Name = "txtFiltroCliente";
            txtFiltroCliente.PasswordChar = '\0';
            txtFiltroCliente.PrefixSuffixText = null;
            txtFiltroCliente.ReadOnly = false;
            txtFiltroCliente.RightToLeft = RightToLeft.No;
            txtFiltroCliente.SelectedText = "";
            txtFiltroCliente.SelectionLength = 0;
            txtFiltroCliente.SelectionStart = 0;
            txtFiltroCliente.ShortcutsEnabled = true;
            txtFiltroCliente.Size = new Size(230, 72);
            txtFiltroCliente.TabIndex = 4;
            txtFiltroCliente.TabStop = false;
            txtFiltroCliente.Text = "Digite o Cliente";
            txtFiltroCliente.TextAlign = HorizontalAlignment.Left;
            txtFiltroCliente.TrailingIcon = null;
            txtFiltroCliente.UseSystemPasswordChar = false;
            // 
            // cmbFiltroStatus
            // 
            cmbFiltroStatus.AutoResize = false;
            cmbFiltroStatus.BackColor = Color.FromArgb(255, 255, 255);
            cmbFiltroStatus.Depth = 0;
            cmbFiltroStatus.Dock = DockStyle.Fill;
            cmbFiltroStatus.DrawMode = DrawMode.OwnerDrawVariable;
            cmbFiltroStatus.DropDownHeight = 263;
            cmbFiltroStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroStatus.DropDownWidth = 121;
            cmbFiltroStatus.Font = new Font("Microsoft Sans Serif", 21F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbFiltroStatus.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbFiltroStatus.FormattingEnabled = true;
            cmbFiltroStatus.IntegralHeight = false;
            cmbFiltroStatus.ItemHeight = 65;
            cmbFiltroStatus.Location = new Point(711, 3);
            cmbFiltroStatus.MaxDropDownItems = 4;
            cmbFiltroStatus.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            cmbFiltroStatus.Name = "cmbFiltroStatus";
            cmbFiltroStatus.Size = new Size(230, 71);
            cmbFiltroStatus.StartIndex = 0;
            cmbFiltroStatus.TabIndex = 6;
            // 
            // dtpDataInicial
            // 
            dtpDataInicial.Format = DateTimePickerFormat.Short;
            dtpDataInicial.Location = new Point(1183, 3);
            dtpDataInicial.Name = "dtpDataInicial";
            dtpDataInicial.Size = new Size(230, 31);
            dtpDataInicial.TabIndex = 3;
            // 
            // dtpDataFinal
            // 
            dtpDataFinal.Format = DateTimePickerFormat.Short;
            dtpDataFinal.Location = new Point(1183, 42);
            dtpDataFinal.Name = "dtpDataFinal";
            dtpDataFinal.Size = new Size(230, 31);
            dtpDataFinal.TabIndex = 4;
            // 
            // pnlRodape
            // 
            pnlRodape.BackColor = Color.FromArgb(255, 255, 255);
            pnlRodape.Controls.Add(flowLayoutPanel2);
            pnlRodape.Controls.Add(flowLayoutPanel1);
            pnlRodape.Depth = 0;
            pnlRodape.Dock = DockStyle.Bottom;
            pnlRodape.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlRodape.Location = new Point(3, 818);
            pnlRodape.Margin = new Padding(21);
            pnlRodape.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            pnlRodape.Name = "pnlRodape";
            pnlRodape.Padding = new Padding(21);
            pnlRodape.Size = new Size(1696, 105);
            pnlRodape.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(btnUsuarios);
            flowLayoutPanel2.Controls.Add(btnParametros);
            flowLayoutPanel2.Dock = DockStyle.Left;
            flowLayoutPanel2.Location = new Point(21, 21);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(450, 63);
            flowLayoutPanel2.TabIndex = 1;
            // 
            // btnUsuarios
            // 
            btnUsuarios.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnUsuarios.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnUsuarios.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnUsuarios.Depth = 0;
            btnUsuarios.HighEmphasis = true;
            btnUsuarios.Icon = null;
            btnUsuarios.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnUsuarios.Location = new Point(4, 6);
            btnUsuarios.Margin = new Padding(4, 6, 4, 6);
            btnUsuarios.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.NoAccentTextColor = Color.Empty;
            btnUsuarios.Size = new Size(254, 54);
            btnUsuarios.TabIndex = 0;
            btnUsuarios.Text = "GERENCIAR USUÁRIOS";
            btnUsuarios.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnUsuarios.UseAccentColor = false;
            btnUsuarios.UseVisualStyleBackColor = true;
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // btnParametros
            // 
            btnParametros.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnParametros.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnParametros.Depth = 0;
            btnParametros.HighEmphasis = true;
            btnParametros.Icon = null;
            btnParametros.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnParametros.Location = new Point(266, 6);
            btnParametros.Margin = new Padding(4, 6, 4, 6);
            btnParametros.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnParametros.Name = "btnParametros";
            btnParametros.NoAccentTextColor = Color.Empty;
            btnParametros.Size = new Size(168, 54);
            btnParametros.TabIndex = 1;
            btnParametros.Text = "PARÂMETROS";
            btnParametros.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnParametros.UseAccentColor = false;
            btnParametros.UseVisualStyleBackColor = true;
            btnParametros.Click += btnParametros_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnNovaProducao);
            flowLayoutPanel1.Controls.Add(btnExportar);
            flowLayoutPanel1.Controls.Add(btnTransferir);
            flowLayoutPanel1.Controls.Add(btnRegravar);
            flowLayoutPanel1.Dock = DockStyle.Right;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(477, 21);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1198, 63);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // btnNovaProducao
            // 
            btnNovaProducao.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnNovaProducao.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnNovaProducao.Depth = 0;
            btnNovaProducao.HighEmphasis = true;
            btnNovaProducao.Icon = null;
            btnNovaProducao.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnNovaProducao.Location = new Point(971, 6);
            btnNovaProducao.Margin = new Padding(4, 6, 4, 6);
            btnNovaProducao.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnNovaProducao.Name = "btnNovaProducao";
            btnNovaProducao.NoAccentTextColor = Color.Empty;
            btnNovaProducao.Size = new Size(223, 54);
            btnNovaProducao.TabIndex = 1;
            btnNovaProducao.Text = "+ NOVA PRODUÇÃO";
            btnNovaProducao.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            btnNovaProducao.UseAccentColor = false;
            btnNovaProducao.UseVisualStyleBackColor = true;
            btnNovaProducao.Click += btnNovaProducao_Click;
            // 
            // btnExportar
            // 
            btnExportar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnExportar.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnExportar.Depth = 0;
            btnExportar.HighEmphasis = true;
            btnExportar.Icon = null;
            btnExportar.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnExportar.Location = new Point(828, 6);
            btnExportar.Margin = new Padding(4, 6, 4, 6);
            btnExportar.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnExportar.Name = "btnExportar";
            btnExportar.NoAccentTextColor = Color.Empty;
            btnExportar.Size = new Size(135, 54);
            btnExportar.TabIndex = 0;
            btnExportar.Text = "EXPORTAR";
            btnExportar.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            btnExportar.UseAccentColor = false;
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // btnTransferir
            // 
            btnTransferir.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnTransferir.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnTransferir.Depth = 0;
            btnTransferir.HighEmphasis = true;
            btnTransferir.Icon = null;
            btnTransferir.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnTransferir.Location = new Point(435, 6);
            btnTransferir.Margin = new Padding(4, 6, 4, 6);
            btnTransferir.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnTransferir.Name = "btnTransferir";
            btnTransferir.NoAccentTextColor = Color.Empty;
            btnTransferir.Size = new Size(385, 54);
            btnTransferir.TabIndex = 4;
            btnTransferir.Text = "Tranferir para outra Maquina";
            btnTransferir.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnTransferir.UseAccentColor = false;
            btnTransferir.UseVisualStyleBackColor = true;
            btnTransferir.Click += btnTransferir_Click;
            // 
            // btnRegravar
            // 
            btnRegravar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRegravar.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnRegravar.Depth = 0;
            btnRegravar.HighEmphasis = true;
            btnRegravar.Icon = null;
            btnRegravar.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnRegravar.Location = new Point(291, 6);
            btnRegravar.Margin = new Padding(4, 6, 4, 6);
            btnRegravar.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnRegravar.Name = "btnRegravar";
            btnRegravar.NoAccentTextColor = Color.Empty;
            btnRegravar.Size = new Size(136, 54);
            btnRegravar.TabIndex = 2;
            btnRegravar.Text = "REGRAVAR";
            btnRegravar.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnRegravar.UseAccentColor = false;
            btnRegravar.UseVisualStyleBackColor = true;
            btnRegravar.Click += btnRegravar_Click;
            // 
            // pnlGrid
            // 
            pnlGrid.BackColor = Color.FromArgb(255, 255, 255);
            pnlGrid.Controls.Add(gridProducoes);
            pnlGrid.Controls.Add(tableLayoutPanel1);
            pnlGrid.Depth = 0;
            pnlGrid.Dock = DockStyle.Fill;
            pnlGrid.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlGrid.Location = new Point(3, 213);
            pnlGrid.Margin = new Padding(21);
            pnlGrid.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Padding = new Padding(21);
            pnlGrid.Size = new Size(1696, 605);
            pnlGrid.TabIndex = 1;
            // 
            // gridProducoes
            // 
            gridProducoes.AllowUserToAddRows = false;
            gridProducoes.AllowUserToDeleteRows = false;
            gridProducoes.AllowUserToResizeRows = false;
            gridProducoes.BackgroundColor = Color.FromArgb(255, 255, 255);
            gridProducoes.BorderStyle = BorderStyle.None;
            gridProducoes.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
            gridProducoes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gridProducoes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gridProducoes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(136, 136, 136);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            gridProducoes.DefaultCellStyle = dataGridViewCellStyle2;
            gridProducoes.Dock = DockStyle.Fill;
            gridProducoes.EnableHeadersVisualStyles = false;
            gridProducoes.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            gridProducoes.GridColor = Color.FromArgb(255, 255, 255);
            gridProducoes.Location = new Point(21, 121);
            gridProducoes.Name = "gridProducoes";
            gridProducoes.ReadOnly = true;
            gridProducoes.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            gridProducoes.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            gridProducoes.RowHeadersWidth = 62;
            gridProducoes.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            gridProducoes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridProducoes.Size = new Size(1654, 463);
            gridProducoes.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel1.Controls.Add(materialCard4, 2, 0);
            tableLayoutPanel1.Controls.Add(materialCard3, 1, 0);
            tableLayoutPanel1.Controls.Add(materialCard1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(21, 21);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1654, 100);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // materialCard4
            // 
            materialCard4.BackColor = Color.FromArgb(255, 255, 255);
            materialCard4.Controls.Add(lblTotalFinalizado);
            materialCard4.Controls.Add(FINALIZADOS);
            materialCard4.Depth = 0;
            materialCard4.Dock = DockStyle.Fill;
            materialCard4.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard4.Location = new Point(1123, 21);
            materialCard4.Margin = new Padding(21);
            materialCard4.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialCard4.Name = "materialCard4";
            materialCard4.Padding = new Padding(21);
            materialCard4.Size = new Size(510, 58);
            materialCard4.TabIndex = 5;
            // 
            // lblTotalFinalizado
            // 
            lblTotalFinalizado.AutoSize = true;
            lblTotalFinalizado.Depth = 0;
            lblTotalFinalizado.Dock = DockStyle.Right;
            lblTotalFinalizado.Font = new Font("Roboto", 21F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblTotalFinalizado.Location = new Point(475, 21);
            lblTotalFinalizado.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblTotalFinalizado.Name = "lblTotalFinalizado";
            lblTotalFinalizado.Size = new Size(14, 29);
            lblTotalFinalizado.TabIndex = 6;
            lblTotalFinalizado.Text = "0";
            // 
            // FINALIZADOS
            // 
            FINALIZADOS.AutoSize = true;
            FINALIZADOS.Depth = 0;
            FINALIZADOS.Font = new Font("Roboto", 21F, FontStyle.Regular, GraphicsUnit.Pixel);
            FINALIZADOS.Location = new Point(24, 21);
            FINALIZADOS.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            FINALIZADOS.Name = "FINALIZADOS";
            FINALIZADOS.Size = new Size(151, 29);
            FINALIZADOS.TabIndex = 7;
            FINALIZADOS.Text = "FINALIZADOS";
            FINALIZADOS.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // materialCard3
            // 
            materialCard3.BackColor = Color.FromArgb(255, 255, 255);
            materialCard3.Controls.Add(lblTotalAndamento);
            materialCard3.Controls.Add(materialLabel2);
            materialCard3.Depth = 0;
            materialCard3.Dock = DockStyle.Fill;
            materialCard3.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard3.Location = new Point(572, 21);
            materialCard3.Margin = new Padding(21);
            materialCard3.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialCard3.Name = "materialCard3";
            materialCard3.Padding = new Padding(21);
            materialCard3.Size = new Size(509, 58);
            materialCard3.TabIndex = 4;
            // 
            // lblTotalAndamento
            // 
            lblTotalAndamento.AutoSize = true;
            lblTotalAndamento.Depth = 0;
            lblTotalAndamento.Dock = DockStyle.Right;
            lblTotalAndamento.Font = new Font("Roboto", 21F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblTotalAndamento.Location = new Point(474, 21);
            lblTotalAndamento.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblTotalAndamento.Name = "lblTotalAndamento";
            lblTotalAndamento.Size = new Size(14, 29);
            lblTotalAndamento.TabIndex = 5;
            lblTotalAndamento.Text = "0";
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 21F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(15, 21);
            materialLabel2.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(190, 29);
            materialLabel2.TabIndex = 5;
            materialLabel2.Text = "EM ANDAMENTO";
            materialLabel2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(lblTotalAguardando);
            materialCard1.Controls.Add(materialLabel1);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(21, 21);
            materialCard1.Margin = new Padding(21);
            materialCard1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(21);
            materialCard1.Size = new Size(509, 58);
            materialCard1.TabIndex = 0;
            // 
            // lblTotalAguardando
            // 
            lblTotalAguardando.AutoSize = true;
            lblTotalAguardando.Depth = 0;
            lblTotalAguardando.Dock = DockStyle.Right;
            lblTotalAguardando.Font = new Font("Roboto", 21F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblTotalAguardando.Location = new Point(474, 21);
            lblTotalAguardando.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblTotalAguardando.Name = "lblTotalAguardando";
            lblTotalAguardando.Size = new Size(14, 29);
            lblTotalAguardando.TabIndex = 4;
            lblTotalAguardando.Text = "0";
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 21F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(9, 21);
            materialLabel1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(239, 29);
            materialLabel1.TabIndex = 4;
            materialLabel1.Text = "AGUARDANDO INÍCIO";
            materialLabel1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timerSincronizacao
            // 
            timerSincronizacao.Interval = 60000;
            timerSincronizacao.Tick += timerSincronizacao_Tick;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1702, 926);
            Controls.Add(pnlGrid);
            Controls.Add(pnlRodape);
            Controls.Add(pnlFiltros);
            Name = "FrmPrincipal";
            Text = "Painel de Produção";
            Load += FrmPrincipal_Load;
            pnlFiltros.ResumeLayout(false);
            tableLayoutPanel.ResumeLayout(false);
            pnlRodape.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridProducoes).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            materialCard4.ResumeLayout(false);
            materialCard4.PerformLayout();
            materialCard3.ResumeLayout(false);
            materialCard3.PerformLayout();
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.MaterialCard pnlFiltros;
        private ReaLTaiizor.Controls.MaterialCard pnlRodape;
        private ReaLTaiizor.Controls.MaterialCard pnlGrid;
        private ReaLTaiizor.Controls.PoisonDataGridView gridProducoes;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit txtFiltroTag;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit txtFiltroPedido;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit txtFiltroCliente;
        private ReaLTaiizor.Controls.MaterialComboBox cmbFiltroStatus;
        private ReaLTaiizor.Controls.MaterialComboBox cmbFiltroUsuario;
        private DateTimePicker dtpDataInicial;
        private DateTimePicker dtpDataFinal;
        private TableLayoutPanel tableLayoutPanel;
        private FlowLayoutPanel flowLayoutPanel1;
        private ReaLTaiizor.Controls.MaterialButton btnExportar;
        private ReaLTaiizor.Controls.MaterialButton btnNovaProducao;
        private ReaLTaiizor.Controls.MaterialButton btnTransferir;
        private ReaLTaiizor.Controls.MaterialButton btnReimprimir;
        private ReaLTaiizor.Controls.MaterialButton btnRegravar;
        private FlowLayoutPanel flowLayoutPanel2;
        private ReaLTaiizor.Controls.MaterialButton btnUsuarios;
        private ReaLTaiizor.Controls.MaterialButton btnParametros;
        private TableLayoutPanel tableLayoutPanel1;
        private ReaLTaiizor.Controls.MaterialCard materialCard1;
        private ReaLTaiizor.Controls.MaterialCard materialCard4;
        private ReaLTaiizor.Controls.MaterialCard materialCard3;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel1;
        private ReaLTaiizor.Controls.MaterialLabel lblTotalAguardando;
        private ReaLTaiizor.Controls.MaterialLabel lblTotalAndamento;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel2;
        private ReaLTaiizor.Controls.MaterialLabel FINALIZADOS;
        private ReaLTaiizor.Controls.MaterialLabel lblTotalFinalizado;
        private ReaLTaiizor.Controls.AirButton btnFiltrar_Click;
        private System.Windows.Forms.Timer timerSincronizacao;
    }
}
