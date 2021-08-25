namespace SID_Telecred
{
    partial class frmConfigurarServico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigurarServico));
            this.btnRemItem = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.txtServico = new System.Windows.Forms.TextBox();
            this.lblServico = new System.Windows.Forms.Label();
            this.grpConfiguracao = new System.Windows.Forms.GroupBox();
            this.grpComboBox = new System.Windows.Forms.GroupBox();
            this.lstOpcoes = new System.Windows.Forms.ListBox();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.grpAlphanumerico = new System.Windows.Forms.GroupBox();
            this.nudTamanho = new System.Windows.Forms.NumericUpDown();
            this.lblTamanho = new System.Windows.Forms.Label();
            this.txtFormato = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboFormato = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grpNumericUpDown = new System.Windows.Forms.GroupBox();
            this.nudDecimais = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.chkMilhar = new System.Windows.Forms.CheckBox();
            this.nudMinimo = new System.Windows.Forms.NumericUpDown();
            this.nudMaximo = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grpHora = new System.Windows.Forms.GroupBox();
            this.cboFormatoHora = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpDateTimePicker = new System.Windows.Forms.GroupBox();
            this.cboFormatoData = new System.Windows.Forms.ComboBox();
            this.lblFormato = new System.Windows.Forms.Label();
            this.dtpMaxima = new System.Windows.Forms.DateTimePicker();
            this.dtpMinima = new System.Windows.Forms.DateTimePicker();
            this.lblMinDate = new System.Windows.Forms.Label();
            this.lblMaxDate = new System.Windows.Forms.Label();
            this.chkChave = new System.Windows.Forms.CheckBox();
            this.rdbOpcional = new System.Windows.Forms.RadioButton();
            this.rdbObrigatorio = new System.Windows.Forms.RadioButton();
            this.lblPreenchimento = new System.Windows.Forms.Label();
            this.cboTipoCampo = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.txtCampo = new System.Windows.Forms.TextBox();
            this.lblCampo = new System.Windows.Forms.Label();
            this.btnBaixo = new System.Windows.Forms.Button();
            this.btnCima = new System.Windows.Forms.Button();
            this.btnRemTodos = new System.Windows.Forms.Button();
            this.btnRemCampo = new System.Windows.Forms.Button();
            this.btnAddCampo = new System.Windows.Forms.Button();
            this.lstCampos = new System.Windows.Forms.ListBox();
            this.cboServico = new System.Windows.Forms.ComboBox();
            this.lblServicos = new System.Windows.Forms.Label();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.grpConfiguracao.SuspendLayout();
            this.grpComboBox.SuspendLayout();
            this.grpAlphanumerico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTamanho)).BeginInit();
            this.grpNumericUpDown.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDecimais)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinimo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximo)).BeginInit();
            this.grpHora.SuspendLayout();
            this.grpDateTimePicker.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRemItem
            // 
            this.btnRemItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnRemItem.Image = global::SID_Telecred.Properties.Resources.delete;
            this.btnRemItem.Location = new System.Drawing.Point(319, 119);
            this.btnRemItem.Name = "btnRemItem";
            this.btnRemItem.Size = new System.Drawing.Size(40, 40);
            this.btnRemItem.TabIndex = 14;
            this.btnRemItem.UseVisualStyleBackColor = true;
            this.btnRemItem.Click += new System.EventHandler(this.btnRemItem_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnAddItem.Image = global::SID_Telecred.Properties.Resources.Add;
            this.btnAddItem.Location = new System.Drawing.Point(319, 20);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(40, 40);
            this.btnAddItem.TabIndex = 11;
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // txtServico
            // 
            this.txtServico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtServico.Location = new System.Drawing.Point(180, 66);
            this.txtServico.Name = "txtServico";
            this.txtServico.Size = new System.Drawing.Size(275, 22);
            this.txtServico.TabIndex = 2;
            // 
            // lblServico
            // 
            this.lblServico.AutoSize = true;
            this.lblServico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblServico.Location = new System.Drawing.Point(113, 70);
            this.lblServico.Name = "lblServico";
            this.lblServico.Size = new System.Drawing.Size(54, 16);
            this.lblServico.TabIndex = 14;
            this.lblServico.Text = "Serviço";
            this.lblServico.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpConfiguracao
            // 
            this.grpConfiguracao.Controls.Add(this.grpComboBox);
            this.grpConfiguracao.Controls.Add(this.grpAlphanumerico);
            this.grpConfiguracao.Controls.Add(this.grpNumericUpDown);
            this.grpConfiguracao.Controls.Add(this.grpHora);
            this.grpConfiguracao.Controls.Add(this.grpDateTimePicker);
            this.grpConfiguracao.Controls.Add(this.chkChave);
            this.grpConfiguracao.Controls.Add(this.rdbOpcional);
            this.grpConfiguracao.Controls.Add(this.rdbObrigatorio);
            this.grpConfiguracao.Controls.Add(this.lblPreenchimento);
            this.grpConfiguracao.Controls.Add(this.cboTipoCampo);
            this.grpConfiguracao.Controls.Add(this.lblTipo);
            this.grpConfiguracao.Controls.Add(this.txtCampo);
            this.grpConfiguracao.Controls.Add(this.lblCampo);
            this.grpConfiguracao.Controls.Add(this.btnBaixo);
            this.grpConfiguracao.Controls.Add(this.btnCima);
            this.grpConfiguracao.Controls.Add(this.btnRemTodos);
            this.grpConfiguracao.Controls.Add(this.btnRemCampo);
            this.grpConfiguracao.Controls.Add(this.btnAddCampo);
            this.grpConfiguracao.Controls.Add(this.lstCampos);
            this.grpConfiguracao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.grpConfiguracao.Location = new System.Drawing.Point(10, 98);
            this.grpConfiguracao.Name = "grpConfiguracao";
            this.grpConfiguracao.Size = new System.Drawing.Size(845, 328);
            this.grpConfiguracao.TabIndex = 3;
            this.grpConfiguracao.TabStop = false;
            this.grpConfiguracao.Text = "Configuração de Campos";
            // 
            // grpComboBox
            // 
            this.grpComboBox.Controls.Add(this.btnRemItem);
            this.grpComboBox.Controls.Add(this.lstOpcoes);
            this.grpComboBox.Controls.Add(this.btnAddItem);
            this.grpComboBox.Controls.Add(this.txtItem);
            this.grpComboBox.Controls.Add(this.label7);
            this.grpComboBox.Location = new System.Drawing.Point(17, 148);
            this.grpComboBox.Name = "grpComboBox";
            this.grpComboBox.Size = new System.Drawing.Size(369, 171);
            this.grpComboBox.TabIndex = 40;
            this.grpComboBox.TabStop = false;
            this.grpComboBox.Text = "Configuração campo Opções";
            // 
            // lstOpcoes
            // 
            this.lstOpcoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lstOpcoes.FormattingEnabled = true;
            this.lstOpcoes.ItemHeight = 16;
            this.lstOpcoes.Location = new System.Drawing.Point(53, 59);
            this.lstOpcoes.Name = "lstOpcoes";
            this.lstOpcoes.Size = new System.Drawing.Size(260, 100);
            this.lstOpcoes.TabIndex = 12;
            // 
            // txtItem
            // 
            this.txtItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtItem.Location = new System.Drawing.Point(53, 29);
            this.txtItem.MaxLength = 25;
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(260, 22);
            this.txtItem.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label7.Location = new System.Drawing.Point(10, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "Item";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpAlphanumerico
            // 
            this.grpAlphanumerico.Controls.Add(this.nudTamanho);
            this.grpAlphanumerico.Controls.Add(this.lblTamanho);
            this.grpAlphanumerico.Controls.Add(this.txtFormato);
            this.grpAlphanumerico.Controls.Add(this.label6);
            this.grpAlphanumerico.Controls.Add(this.cboFormato);
            this.grpAlphanumerico.Controls.Add(this.label5);
            this.grpAlphanumerico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.grpAlphanumerico.Location = new System.Drawing.Point(17, 148);
            this.grpAlphanumerico.Name = "grpAlphanumerico";
            this.grpAlphanumerico.Size = new System.Drawing.Size(258, 130);
            this.grpAlphanumerico.TabIndex = 38;
            this.grpAlphanumerico.TabStop = false;
            this.grpAlphanumerico.Text = "Configuração campo Alphanumérico";
            // 
            // nudTamanho
            // 
            this.nudTamanho.Enabled = false;
            this.nudTamanho.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.nudTamanho.Location = new System.Drawing.Point(80, 90);
            this.nudTamanho.Maximum = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            this.nudTamanho.Name = "nudTamanho";
            this.nudTamanho.Size = new System.Drawing.Size(68, 22);
            this.nudTamanho.TabIndex = 25;
            this.nudTamanho.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            // 
            // lblTamanho
            // 
            this.lblTamanho.AutoSize = true;
            this.lblTamanho.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblTamanho.Location = new System.Drawing.Point(8, 92);
            this.lblTamanho.Name = "lblTamanho";
            this.lblTamanho.Size = new System.Drawing.Size(66, 16);
            this.lblTamanho.TabIndex = 24;
            this.lblTamanho.Text = "Tamanho";
            this.lblTamanho.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFormato
            // 
            this.txtFormato.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtFormato.Location = new System.Drawing.Point(80, 63);
            this.txtFormato.MaxLength = 25;
            this.txtFormato.Name = "txtFormato";
            this.txtFormato.ReadOnly = true;
            this.txtFormato.Size = new System.Drawing.Size(157, 22);
            this.txtFormato.TabIndex = 23;
            this.txtFormato.Text = "000.000.000-00";
            this.txtFormato.TextChanged += new System.EventHandler(this.txtFormato_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label6.Location = new System.Drawing.Point(13, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 16);
            this.label6.TabIndex = 22;
            this.label6.Text = "Máscara";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboFormato
            // 
            this.cboFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormato.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboFormato.FormattingEnabled = true;
            this.cboFormato.Location = new System.Drawing.Point(80, 35);
            this.cboFormato.Name = "cboFormato";
            this.cboFormato.Size = new System.Drawing.Size(133, 24);
            this.cboFormato.TabIndex = 21;
            this.cboFormato.SelectedIndexChanged += new System.EventHandler(this.cboFormato_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label5.Location = new System.Drawing.Point(16, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "Formato";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpNumericUpDown
            // 
            this.grpNumericUpDown.Controls.Add(this.nudDecimais);
            this.grpNumericUpDown.Controls.Add(this.label4);
            this.grpNumericUpDown.Controls.Add(this.chkMilhar);
            this.grpNumericUpDown.Controls.Add(this.nudMinimo);
            this.grpNumericUpDown.Controls.Add(this.nudMaximo);
            this.grpNumericUpDown.Controls.Add(this.label2);
            this.grpNumericUpDown.Controls.Add(this.label3);
            this.grpNumericUpDown.Location = new System.Drawing.Point(17, 148);
            this.grpNumericUpDown.Name = "grpNumericUpDown";
            this.grpNumericUpDown.Size = new System.Drawing.Size(241, 163);
            this.grpNumericUpDown.TabIndex = 37;
            this.grpNumericUpDown.TabStop = false;
            this.grpNumericUpDown.Text = "Configuração campo Numérico";
            // 
            // nudDecimais
            // 
            this.nudDecimais.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.nudDecimais.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudDecimais.InterceptArrowKeys = false;
            this.nudDecimais.Location = new System.Drawing.Point(120, 92);
            this.nudDecimais.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudDecimais.Name = "nudDecimais";
            this.nudDecimais.Size = new System.Drawing.Size(53, 22);
            this.nudDecimais.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label4.Location = new System.Drawing.Point(7, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 16);
            this.label4.TabIndex = 28;
            this.label4.Text = "Casas Decimais";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkMilhar
            // 
            this.chkMilhar.AutoSize = true;
            this.chkMilhar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkMilhar.Location = new System.Drawing.Point(13, 123);
            this.chkMilhar.Name = "chkMilhar";
            this.chkMilhar.Size = new System.Drawing.Size(150, 20);
            this.chkMilhar.TabIndex = 28;
            this.chkMilhar.Text = "Separador de Milhar";
            this.chkMilhar.UseVisualStyleBackColor = true;
            // 
            // nudMinimo
            // 
            this.nudMinimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.nudMinimo.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMinimo.InterceptArrowKeys = false;
            this.nudMinimo.Location = new System.Drawing.Point(107, 35);
            this.nudMinimo.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudMinimo.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.nudMinimo.Name = "nudMinimo";
            this.nudMinimo.Size = new System.Drawing.Size(120, 22);
            this.nudMinimo.TabIndex = 25;
            this.nudMinimo.Value = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            // 
            // nudMaximo
            // 
            this.nudMaximo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.nudMaximo.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMaximo.InterceptArrowKeys = false;
            this.nudMaximo.Location = new System.Drawing.Point(107, 64);
            this.nudMaximo.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudMaximo.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.nudMaximo.Name = "nudMaximo";
            this.nudMaximo.Size = new System.Drawing.Size(120, 22);
            this.nudMaximo.TabIndex = 26;
            this.nudMaximo.Value = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.Location = new System.Drawing.Point(8, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 24;
            this.label2.Text = "Valor Mínimo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label3.Location = new System.Drawing.Point(8, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 16);
            this.label3.TabIndex = 23;
            this.label3.Text = "Valor Máximo";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpHora
            // 
            this.grpHora.Controls.Add(this.cboFormatoHora);
            this.grpHora.Controls.Add(this.label1);
            this.grpHora.Location = new System.Drawing.Point(17, 148);
            this.grpHora.Name = "grpHora";
            this.grpHora.Size = new System.Drawing.Size(227, 86);
            this.grpHora.TabIndex = 23;
            this.grpHora.TabStop = false;
            this.grpHora.Text = "Configuração campo Hora";
            // 
            // cboFormatoHora
            // 
            this.cboFormatoHora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormatoHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboFormatoHora.FormattingEnabled = true;
            this.cboFormatoHora.Items.AddRange(new object[] {
            "12:00",
            "24:00"});
            this.cboFormatoHora.Location = new System.Drawing.Point(77, 34);
            this.cboFormatoHora.Name = "cboFormatoHora";
            this.cboFormatoHora.Size = new System.Drawing.Size(124, 24);
            this.cboFormatoHora.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.Location = new System.Drawing.Point(15, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 26;
            this.label1.Text = "Formato";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpDateTimePicker
            // 
            this.grpDateTimePicker.Controls.Add(this.cboFormatoData);
            this.grpDateTimePicker.Controls.Add(this.lblFormato);
            this.grpDateTimePicker.Controls.Add(this.dtpMaxima);
            this.grpDateTimePicker.Controls.Add(this.dtpMinima);
            this.grpDateTimePicker.Controls.Add(this.lblMinDate);
            this.grpDateTimePicker.Controls.Add(this.lblMaxDate);
            this.grpDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.grpDateTimePicker.Location = new System.Drawing.Point(17, 148);
            this.grpDateTimePicker.Name = "grpDateTimePicker";
            this.grpDateTimePicker.Size = new System.Drawing.Size(241, 137);
            this.grpDateTimePicker.TabIndex = 39;
            this.grpDateTimePicker.TabStop = false;
            this.grpDateTimePicker.Text = "Configuração campo Data";
            // 
            // cboFormatoData
            // 
            this.cboFormatoData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormatoData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboFormatoData.FormattingEnabled = true;
            this.cboFormatoData.Items.AddRange(new object[] {
            "DD/MM/YYYY",
            "MM/DD/YYYY",
            "YYYY/MM/DD",
            "DD/MM/YY",
            "MM/DD/YY",
            "YY/MM/DD",
            "DD-MM-YYYY",
            "MM-DD-YYYY",
            "YYYY-MM-DD",
            "DD-MM-YY",
            "MM-DD-YY",
            "YY-MM-DD"});
            this.cboFormatoData.Location = new System.Drawing.Point(103, 93);
            this.cboFormatoData.Name = "cboFormatoData";
            this.cboFormatoData.Size = new System.Drawing.Size(124, 24);
            this.cboFormatoData.TabIndex = 25;
            // 
            // lblFormato
            // 
            this.lblFormato.AutoSize = true;
            this.lblFormato.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblFormato.Location = new System.Drawing.Point(30, 96);
            this.lblFormato.Name = "lblFormato";
            this.lblFormato.Size = new System.Drawing.Size(58, 16);
            this.lblFormato.TabIndex = 24;
            this.lblFormato.Text = "Formato";
            this.lblFormato.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpMaxima
            // 
            this.dtpMaxima.CustomFormat = "dd/MM/yy";
            this.dtpMaxima.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpMaxima.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.dtpMaxima.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpMaxima.Location = new System.Drawing.Point(103, 65);
            this.dtpMaxima.Name = "dtpMaxima";
            this.dtpMaxima.Size = new System.Drawing.Size(124, 22);
            this.dtpMaxima.TabIndex = 22;
            this.dtpMaxima.Value = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            // 
            // dtpMinima
            // 
            this.dtpMinima.CustomFormat = "yyyy-MM-dd";
            this.dtpMinima.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpMinima.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.dtpMinima.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpMinima.Location = new System.Drawing.Point(103, 36);
            this.dtpMinima.Name = "dtpMinima";
            this.dtpMinima.Size = new System.Drawing.Size(124, 22);
            this.dtpMinima.TabIndex = 21;
            this.dtpMinima.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            // 
            // lblMinDate
            // 
            this.lblMinDate.AutoSize = true;
            this.lblMinDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblMinDate.Location = new System.Drawing.Point(15, 42);
            this.lblMinDate.Name = "lblMinDate";
            this.lblMinDate.Size = new System.Drawing.Size(83, 16);
            this.lblMinDate.TabIndex = 18;
            this.lblMinDate.Text = "Data Mínima";
            this.lblMinDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMaxDate
            // 
            this.lblMaxDate.AutoSize = true;
            this.lblMaxDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblMaxDate.Location = new System.Drawing.Point(10, 70);
            this.lblMaxDate.Name = "lblMaxDate";
            this.lblMaxDate.Size = new System.Drawing.Size(87, 16);
            this.lblMaxDate.TabIndex = 17;
            this.lblMaxDate.Text = "Data Máxima";
            this.lblMaxDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkChave
            // 
            this.chkChave.AutoSize = true;
            this.chkChave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkChave.Location = new System.Drawing.Point(348, 101);
            this.chkChave.Name = "chkChave";
            this.chkChave.Size = new System.Drawing.Size(121, 20);
            this.chkChave.TabIndex = 4;
            this.chkChave.Text = "Chave Consulta";
            this.chkChave.UseVisualStyleBackColor = true;
            // 
            // rdbOpcional
            // 
            this.rdbOpcional.AutoSize = true;
            this.rdbOpcional.Checked = true;
            this.rdbOpcional.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.rdbOpcional.Location = new System.Drawing.Point(248, 99);
            this.rdbOpcional.Name = "rdbOpcional";
            this.rdbOpcional.Size = new System.Drawing.Size(80, 20);
            this.rdbOpcional.TabIndex = 3;
            this.rdbOpcional.TabStop = true;
            this.rdbOpcional.Text = "Opcional";
            this.rdbOpcional.UseVisualStyleBackColor = true;
            // 
            // rdbObrigatorio
            // 
            this.rdbObrigatorio.AutoSize = true;
            this.rdbObrigatorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.rdbObrigatorio.Location = new System.Drawing.Point(137, 99);
            this.rdbObrigatorio.Name = "rdbObrigatorio";
            this.rdbObrigatorio.Size = new System.Drawing.Size(93, 20);
            this.rdbObrigatorio.TabIndex = 2;
            this.rdbObrigatorio.Text = "Obrigatório";
            this.rdbObrigatorio.UseVisualStyleBackColor = true;
            // 
            // lblPreenchimento
            // 
            this.lblPreenchimento.AutoSize = true;
            this.lblPreenchimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblPreenchimento.Location = new System.Drawing.Point(14, 102);
            this.lblPreenchimento.Name = "lblPreenchimento";
            this.lblPreenchimento.Size = new System.Drawing.Size(98, 16);
            this.lblPreenchimento.TabIndex = 13;
            this.lblPreenchimento.Text = "Preenchimento";
            this.lblPreenchimento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboTipoCampo
            // 
            this.cboTipoCampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoCampo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboTipoCampo.FormattingEnabled = true;
            this.cboTipoCampo.Location = new System.Drawing.Point(140, 67);
            this.cboTipoCampo.Name = "cboTipoCampo";
            this.cboTipoCampo.Size = new System.Drawing.Size(232, 24);
            this.cboTipoCampo.TabIndex = 1;
            this.cboTipoCampo.SelectedIndexChanged += new System.EventHandler(this.cboTipoCampo_SelectedIndexChanged);
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblTipo.Location = new System.Drawing.Point(18, 70);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(102, 16);
            this.lblTipo.TabIndex = 11;
            this.lblTipo.Text = "Tipo de Campo";
            this.lblTipo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCampo
            // 
            this.txtCampo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtCampo.Location = new System.Drawing.Point(140, 35);
            this.txtCampo.MaxLength = 50;
            this.txtCampo.Name = "txtCampo";
            this.txtCampo.Size = new System.Drawing.Size(232, 22);
            this.txtCampo.TabIndex = 0;
            // 
            // lblCampo
            // 
            this.lblCampo.AutoSize = true;
            this.lblCampo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblCampo.Location = new System.Drawing.Point(6, 38);
            this.lblCampo.Name = "lblCampo";
            this.lblCampo.Size = new System.Drawing.Size(111, 16);
            this.lblCampo.TabIndex = 7;
            this.lblCampo.Text = "Nome do Campo";
            this.lblCampo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBaixo
            // 
            this.btnBaixo.Image = global::SID_Telecred.Properties.Resources.DownArrow;
            this.btnBaixo.Location = new System.Drawing.Point(792, 76);
            this.btnBaixo.Name = "btnBaixo";
            this.btnBaixo.Size = new System.Drawing.Size(40, 40);
            this.btnBaixo.TabIndex = 9;
            this.btnBaixo.UseVisualStyleBackColor = true;
            this.btnBaixo.Click += new System.EventHandler(this.btnBaixo_Click);
            // 
            // btnCima
            // 
            this.btnCima.Image = global::SID_Telecred.Properties.Resources.UpArrow1;
            this.btnCima.Location = new System.Drawing.Point(792, 25);
            this.btnCima.Name = "btnCima";
            this.btnCima.Size = new System.Drawing.Size(40, 40);
            this.btnCima.TabIndex = 8;
            this.btnCima.UseVisualStyleBackColor = true;
            this.btnCima.Click += new System.EventHandler(this.btnCima_Click);
            // 
            // btnRemTodos
            // 
            this.btnRemTodos.Image = global::SID_Telecred.Properties.Resources.DocumentClear;
            this.btnRemTodos.Location = new System.Drawing.Point(475, 277);
            this.btnRemTodos.Name = "btnRemTodos";
            this.btnRemTodos.Size = new System.Drawing.Size(40, 40);
            this.btnRemTodos.TabIndex = 7;
            this.btnRemTodos.UseVisualStyleBackColor = true;
            this.btnRemTodos.Click += new System.EventHandler(this.btnRemTodos_Click);
            // 
            // btnRemCampo
            // 
            this.btnRemCampo.Image = global::SID_Telecred.Properties.Resources.DocumentOut;
            this.btnRemCampo.Location = new System.Drawing.Point(475, 76);
            this.btnRemCampo.Name = "btnRemCampo";
            this.btnRemCampo.Size = new System.Drawing.Size(40, 40);
            this.btnRemCampo.TabIndex = 6;
            this.btnRemCampo.UseVisualStyleBackColor = true;
            this.btnRemCampo.Click += new System.EventHandler(this.btnRemCampo_Click);
            // 
            // btnAddCampo
            // 
            this.btnAddCampo.Image = global::SID_Telecred.Properties.Resources.DocumentInto;
            this.btnAddCampo.Location = new System.Drawing.Point(475, 25);
            this.btnAddCampo.Name = "btnAddCampo";
            this.btnAddCampo.Size = new System.Drawing.Size(40, 40);
            this.btnAddCampo.TabIndex = 5;
            this.btnAddCampo.UseVisualStyleBackColor = true;
            this.btnAddCampo.Click += new System.EventHandler(this.btnAddCampo_Click);
            // 
            // lstCampos
            // 
            this.lstCampos.Font = new System.Drawing.Font("Courier New", 10F);
            this.lstCampos.FormattingEnabled = true;
            this.lstCampos.HorizontalScrollbar = true;
            this.lstCampos.ItemHeight = 16;
            this.lstCampos.Location = new System.Drawing.Point(526, 25);
            this.lstCampos.Name = "lstCampos";
            this.lstCampos.ScrollAlwaysVisible = true;
            this.lstCampos.Size = new System.Drawing.Size(260, 292);
            this.lstCampos.TabIndex = 0;
            // 
            // cboServico
            // 
            this.cboServico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboServico.FormattingEnabled = true;
            this.cboServico.Location = new System.Drawing.Point(180, 21);
            this.cboServico.Name = "cboServico";
            this.cboServico.Size = new System.Drawing.Size(315, 24);
            this.cboServico.TabIndex = 0;
            this.cboServico.SelectedIndexChanged += new System.EventHandler(this.cboServico_SelectedIndexChanged);
            // 
            // lblServicos
            // 
            this.lblServicos.AutoSize = true;
            this.lblServicos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblServicos.Location = new System.Drawing.Point(10, 24);
            this.lblServicos.Name = "lblServicos";
            this.lblServicos.Size = new System.Drawing.Size(142, 16);
            this.lblServicos.TabIndex = 10;
            this.lblServicos.Text = "Serviços Cadastrados";
            this.lblServicos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnLimpar
            // 
            this.btnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnLimpar.Image = global::SID_Telecred.Properties.Resources.Eraser;
            this.btnLimpar.Location = new System.Drawing.Point(10, 432);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(141, 40);
            this.btnLimpar.TabIndex = 6;
            this.btnLimpar.Text = "&Limpar Campos";
            this.btnLimpar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnGravar
            // 
            this.btnGravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnGravar.Image = global::SID_Telecred.Properties.Resources.FloppyDisks;
            this.btnGravar.Location = new System.Drawing.Point(714, 432);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(141, 40);
            this.btnGravar.TabIndex = 4;
            this.btnGravar.Text = "&Gravar";
            this.btnGravar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnNovo.Image = global::SID_Telecred.Properties.Resources.NewJob;
            this.btnNovo.Location = new System.Drawing.Point(501, 12);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(141, 40);
            this.btnNovo.TabIndex = 1;
            this.btnNovo.Text = "&Novo Serviço";
            this.btnNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnFechar.Image = global::SID_Telecred.Properties.Resources.delete;
            this.btnFechar.Location = new System.Drawing.Point(536, 432);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(141, 40);
            this.btnFechar.TabIndex = 5;
            this.btnFechar.Text = "&Cancelar";
            this.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // frmConfigurarServico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 480);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.txtServico);
            this.Controls.Add(this.lblServico);
            this.Controls.Add(this.grpConfiguracao);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.cboServico);
            this.Controls.Add(this.lblServicos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfigurarServico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuração de Serviços";
            this.Load += new System.EventHandler(this.frmConfiguracao_Load);
            this.grpConfiguracao.ResumeLayout(false);
            this.grpConfiguracao.PerformLayout();
            this.grpComboBox.ResumeLayout(false);
            this.grpComboBox.PerformLayout();
            this.grpAlphanumerico.ResumeLayout(false);
            this.grpAlphanumerico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTamanho)).EndInit();
            this.grpNumericUpDown.ResumeLayout(false);
            this.grpNumericUpDown.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDecimais)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinimo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximo)).EndInit();
            this.grpHora.ResumeLayout(false);
            this.grpHora.PerformLayout();
            this.grpDateTimePicker.ResumeLayout(false);
            this.grpDateTimePicker.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.TextBox txtServico;
        private System.Windows.Forms.Label lblServico;
        private System.Windows.Forms.GroupBox grpConfiguracao;
        private System.Windows.Forms.GroupBox grpDateTimePicker;
        private System.Windows.Forms.ComboBox cboFormatoData;
        private System.Windows.Forms.Label lblFormato;
        private System.Windows.Forms.DateTimePicker dtpMaxima;
        private System.Windows.Forms.DateTimePicker dtpMinima;
        private System.Windows.Forms.Label lblMinDate;
        private System.Windows.Forms.Label lblMaxDate;
        private System.Windows.Forms.GroupBox grpAlphanumerico;
        private System.Windows.Forms.NumericUpDown nudTamanho;
        private System.Windows.Forms.Label lblTamanho;
        private System.Windows.Forms.TextBox txtFormato;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboFormato;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpNumericUpDown;
        private System.Windows.Forms.NumericUpDown nudDecimais;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkMilhar;
        private System.Windows.Forms.NumericUpDown nudMinimo;
        private System.Windows.Forms.NumericUpDown nudMaximo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpHora;
        private System.Windows.Forms.ComboBox cboFormatoHora;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbOpcional;
        private System.Windows.Forms.RadioButton rdbObrigatorio;
        private System.Windows.Forms.Label lblPreenchimento;
        private System.Windows.Forms.ComboBox cboTipoCampo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.TextBox txtCampo;
        private System.Windows.Forms.Label lblCampo;
        private System.Windows.Forms.Button btnBaixo;
        private System.Windows.Forms.Button btnCima;
        private System.Windows.Forms.Button btnRemTodos;
        private System.Windows.Forms.Button btnRemCampo;
        private System.Windows.Forms.Button btnAddCampo;
        private System.Windows.Forms.ListBox lstCampos;
        private System.Windows.Forms.GroupBox grpComboBox;
        private System.Windows.Forms.Button btnRemItem;
        private System.Windows.Forms.ListBox lstOpcoes;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.ComboBox cboServico;
        private System.Windows.Forms.Label lblServicos;
        private System.Windows.Forms.CheckBox chkChave;
        private System.Windows.Forms.Button btnFechar;

    }
}

