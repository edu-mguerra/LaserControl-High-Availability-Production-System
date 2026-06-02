namespace LaserProduction.Desktop.Views
{
    partial class FrmTransferir
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
            lblInfo = new ReaLTaiizor.Controls.MaterialLabel();
            cmbMaquinas = new ReaLTaiizor.Controls.MaterialComboBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnCancelar = new ReaLTaiizor.Controls.MaterialButton();
            btnTransferir_Click = new ReaLTaiizor.Controls.MaterialButton();
            clbTags = new CheckedListBox();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Depth = 0;
            lblInfo.Font = new Font("Roboto", 21F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblInfo.Location = new Point(6, 313);
            lblInfo.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(201, 29);
            lblInfo.TabIndex = 0;
            lblInfo.Text = "Transferindo TAG: ";
            // 
            // cmbMaquinas
            // 
            cmbMaquinas.AutoResize = false;
            cmbMaquinas.BackColor = Color.FromArgb(255, 255, 255);
            cmbMaquinas.Depth = 0;
            cmbMaquinas.DrawMode = DrawMode.OwnerDrawVariable;
            cmbMaquinas.DropDownHeight = 263;
            cmbMaquinas.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMaquinas.DropDownWidth = 121;
            cmbMaquinas.Font = new Font("Microsoft Sans Serif", 21F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbMaquinas.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbMaquinas.FormattingEnabled = true;
            cmbMaquinas.IntegralHeight = false;
            cmbMaquinas.ItemHeight = 65;
            cmbMaquinas.Location = new Point(6, 345);
            cmbMaquinas.MaxDropDownItems = 4;
            cmbMaquinas.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            cmbMaquinas.Name = "cmbMaquinas";
            cmbMaquinas.Size = new Size(337, 71);
            cmbMaquinas.StartIndex = 0;
            cmbMaquinas.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnCancelar);
            flowLayoutPanel1.Controls.Add(btnTransferir_Click);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(3, 481);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(821, 70);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // btnCancelar
            // 
            btnCancelar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCancelar.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnCancelar.Depth = 0;
            btnCancelar.HighEmphasis = true;
            btnCancelar.Icon = null;
            btnCancelar.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnCancelar.Location = new Point(681, 6);
            btnCancelar.Margin = new Padding(4, 6, 4, 6);
            btnCancelar.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnCancelar.Name = "btnCancelar";
            btnCancelar.NoAccentTextColor = Color.Empty;
            btnCancelar.Size = new Size(136, 54);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            btnCancelar.UseAccentColor = false;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += materialButton2_Click;
            // 
            // btnTransferir_Click
            // 
            btnTransferir_Click.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnTransferir_Click.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnTransferir_Click.Depth = 0;
            btnTransferir_Click.HighEmphasis = true;
            btnTransferir_Click.Icon = null;
            btnTransferir_Click.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnTransferir_Click.Location = new Point(524, 6);
            btnTransferir_Click.Margin = new Padding(4, 6, 4, 6);
            btnTransferir_Click.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnTransferir_Click.Name = "btnTransferir_Click";
            btnTransferir_Click.NoAccentTextColor = Color.Empty;
            btnTransferir_Click.Size = new Size(149, 54);
            btnTransferir_Click.TabIndex = 3;
            btnTransferir_Click.Text = "CONFIRMAR";
            btnTransferir_Click.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            btnTransferir_Click.UseAccentColor = false;
            btnTransferir_Click.UseVisualStyleBackColor = true;
            btnTransferir_Click.Click += btnTransferir_Click_Click;
            // 
            // clbTags
            // 
            clbTags.FormattingEnabled = true;
            clbTags.Location = new Point(6, 107);
            clbTags.Name = "clbTags";
            clbTags.Size = new Size(814, 172);
            clbTags.TabIndex = 4;
            // 
            // FrmTransferir
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(827, 554);
            Controls.Add(clbTags);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(cmbMaquinas);
            Controls.Add(lblInfo);
            Name = "FrmTransferir";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TRANSFERIR MAQUINA";
            Load += FrmTransferir_Load;
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ReaLTaiizor.Controls.MaterialLabel lblInfo;
        private ReaLTaiizor.Controls.MaterialComboBox cmbMaquinas;
        private FlowLayoutPanel flowLayoutPanel1;
        private ReaLTaiizor.Controls.MaterialButton btnCancelar;
        private ReaLTaiizor.Controls.MaterialButton btnTransferir_Click;
        private ReaLTaiizor.Controls.MaterialLabel txtTag;
        private ReaLTaiizor.Controls.MaterialCheckBox chkAlterarTag;
        private CheckedListBox clbTags;
    }
}