namespace FormsCadastroPessoa
{
    partial class formCadastro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formCadastro));
            lblNome = new Label();
            lblData = new Label();
            lblAltura = new Label();
            txtNome = new TextBox();
            btnImprimir = new Button();
            dropDownAltura = new NumericUpDown();
            cBoxPopUp = new CheckBox();
            cBoxPainel = new CheckBox();
            dateCalendario = new MonthCalendar();
            btnLimpar = new Button();
            lblResposta = new Label();
            btnSalvar = new Button();
            sfdSalvar = new SaveFileDialog();
            ofdAbrir = new OpenFileDialog();
            fbdAbrirPasta = new FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)dropDownAltura).BeginInit();
            SuspendLayout();
            // 
            // lblNome
            // 
            resources.ApplyResources(lblNome, "lblNome");
            lblNome.Name = "lblNome";
            // 
            // lblData
            // 
            resources.ApplyResources(lblData, "lblData");
            lblData.Name = "lblData";
            // 
            // lblAltura
            // 
            resources.ApplyResources(lblAltura, "lblAltura");
            lblAltura.Name = "lblAltura";
            // 
            // txtNome
            // 
            resources.ApplyResources(txtNome, "txtNome");
            txtNome.AccessibleRole = AccessibleRole.Text;
            txtNome.Cursor = Cursors.Hand;
            txtNome.Name = "txtNome";
            txtNome.TextChanged += txtNome_TextChanged;
            txtNome.KeyPress += txtNome_KeyPress;
            // 
            // btnImprimir
            // 
            resources.ApplyResources(btnImprimir, "btnImprimir");
            btnImprimir.BackColor = SystemColors.ButtonFace;
            btnImprimir.Cursor = Cursors.Hand;
            btnImprimir.Name = "btnImprimir";
            btnImprimir.UseVisualStyleBackColor = false;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // dropDownAltura
            // 
            resources.ApplyResources(dropDownAltura, "dropDownAltura");
            dropDownAltura.Cursor = Cursors.Hand;
            dropDownAltura.DecimalPlaces = 2;
            dropDownAltura.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            dropDownAltura.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            dropDownAltura.Name = "dropDownAltura";
            dropDownAltura.Value = new decimal(new int[] { 150, 0, 0, 131072 });
            // 
            // cBoxPopUp
            // 
            resources.ApplyResources(cBoxPopUp, "cBoxPopUp");
            cBoxPopUp.Cursor = Cursors.Hand;
            cBoxPopUp.Name = "cBoxPopUp";
            cBoxPopUp.UseVisualStyleBackColor = true;
            cBoxPopUp.CheckedChanged += cBoxPopUp_CheckedChanged;
            // 
            // cBoxPainel
            // 
            resources.ApplyResources(cBoxPainel, "cBoxPainel");
            cBoxPainel.Cursor = Cursors.Hand;
            cBoxPainel.Name = "cBoxPainel";
            cBoxPainel.UseVisualStyleBackColor = true;
            cBoxPainel.CheckedChanged += cBoxPainel_CheckedChanged;
            // 
            // dateCalendario
            // 
            resources.ApplyResources(dateCalendario, "dateCalendario");
            dateCalendario.BackColor = SystemColors.Control;
            dateCalendario.CausesValidation = false;
            dateCalendario.Cursor = Cursors.Hand;
            dateCalendario.ForeColor = SystemColors.Control;
            dateCalendario.MaxSelectionCount = 1;
            dateCalendario.Name = "dateCalendario";
            dateCalendario.ShowToday = false;
            dateCalendario.ShowTodayCircle = false;
            dateCalendario.TitleBackColor = SystemColors.Control;
            dateCalendario.TrailingForeColor = SystemColors.ActiveCaptionText;
            // 
            // btnLimpar
            // 
            resources.ApplyResources(btnLimpar, "btnLimpar");
            btnLimpar.BackColor = SystemColors.ButtonFace;
            btnLimpar.Cursor = Cursors.Hand;
            btnLimpar.Name = "btnLimpar";
            btnLimpar.UseVisualStyleBackColor = false;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // lblResposta
            // 
            resources.ApplyResources(lblResposta, "lblResposta");
            lblResposta.AllowDrop = true;
            lblResposta.Name = "lblResposta";
            lblResposta.UseCompatibleTextRendering = true;
            // 
            // btnSalvar
            // 
            resources.ApplyResources(btnSalvar, "btnSalvar");
            btnSalvar.BackColor = SystemColors.ButtonFace;
            btnSalvar.Name = "btnSalvar";
            btnSalvar.UseVisualStyleBackColor = false;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // sfdSalvar
            // 
            resources.ApplyResources(sfdSalvar, "sfdSalvar");
            sfdSalvar.InitialDirectory = "C:\\Users\\AmandaMarquesPardinh\\Desktop";
            // 
            // ofdAbrir
            // 
            resources.ApplyResources(ofdAbrir, "ofdAbrir");
            ofdAbrir.InitialDirectory = "C:\\Users\\AmandaMarquesPardinh\\Desktop";
            // 
            // fbdAbrirPasta
            // 
            resources.ApplyResources(fbdAbrirPasta, "fbdAbrirPasta");
            // 
            // formCadastro
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnSalvar);
            Controls.Add(lblResposta);
            Controls.Add(btnLimpar);
            Controls.Add(dateCalendario);
            Controls.Add(cBoxPainel);
            Controls.Add(cBoxPopUp);
            Controls.Add(dropDownAltura);
            Controls.Add(btnImprimir);
            Controls.Add(txtNome);
            Controls.Add(lblAltura);
            Controls.Add(lblData);
            Controls.Add(lblNome);
            Cursor = Cursors.IBeam;
            MaximizeBox = false;
            Name = "formCadastro";
            ((System.ComponentModel.ISupportInitialize)dropDownAltura).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void btnImprimr_Click(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Label lblNome;
        private Label lblData;
        private Label lblAltura;
        private TextBox txtNome;
        private Button btnImprimir;
        private NumericUpDown dropDownAltura;
        private CheckBox cBoxPopUp;
        private CheckBox cBoxPainel;
        private MonthCalendar dateCalendario;
        private Button btnLimpar;
        private Label lblResposta;
        private Button btnSalvar;
        private SaveFileDialog sfdSalvar;
        private OpenFileDialog ofdAbrir;
        private FolderBrowserDialog fbdAbrirPasta;
    }
}