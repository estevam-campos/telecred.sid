namespace SID_Telecred
{
    partial class frmCriacaoLotes
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCriacaoLotes));
            this.lblCaixa = new System.Windows.Forms.Label();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.grpDocumentos = new System.Windows.Forms.GroupBox();
            this.lstDocumentos = new System.Windows.Forms.ListBox();
            this.cboCaixa = new System.Windows.Forms.ComboBox();
            this.cboLote = new System.Windows.Forms.ComboBox();
            this.lblLote = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.btnRemoverCaixa = new System.Windows.Forms.Button();
            this.btnGravarCaixa = new System.Windows.Forms.Button();
            this.btnAbrirCaixa = new System.Windows.Forms.Button();
            this.btnRemoverLote = new System.Windows.Forms.Button();
            this.btnFecharLote = new System.Windows.Forms.Button();
            this.btnAbrirLote = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnAddFilho = new System.Windows.Forms.Button();
            this.btnRemFilho = new System.Windows.Forms.Button();
            this.cboServico = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpAutomatico = new System.Windows.Forms.GroupBox();
            this.txtPrefixo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnProcessar = new System.Windows.Forms.Button();
            this.nudFim = new System.Windows.Forms.NumericUpDown();
            this.nudInicio = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpFilho = new System.Windows.Forms.GroupBox();
            this.txtFilho = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lstFilhos = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTotalCaixa = new System.Windows.Forms.TextBox();
            this.txtDocumentosCaixa = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.grpFormalizacao = new System.Windows.Forms.GroupBox();
            this.chkTodos = new System.Windows.Forms.CheckBox();
            this.chkData = new System.Windows.Forms.CheckBox();
            this.chkAssinatura = new System.Windows.Forms.CheckBox();
            this.chkTelefone = new System.Windows.Forms.CheckBox();
            this.chkCarimbo = new System.Windows.Forms.CheckBox();
            this.chkAltura = new System.Windows.Forms.CheckBox();
            this.chkApto = new System.Windows.Forms.CheckBox();
            this.chkPCMSO = new System.Windows.Forms.CheckBox();
            this.chkImpresso = new System.Windows.Forms.CheckBox();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkDocumentoPai = new System.Windows.Forms.CheckBox();
            this.chkDigital = new System.Windows.Forms.CheckBox();
            this.grpDocumentos.SuspendLayout();
            this.grpAutomatico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInicio)).BeginInit();
            this.grpFilho.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grpFormalizacao.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCaixa
            // 
            this.lblCaixa.AutoSize = true;
            this.lblCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblCaixa.Location = new System.Drawing.Point(37, 45);
            this.lblCaixa.Name = "lblCaixa";
            this.lblCaixa.Size = new System.Drawing.Size(60, 16);
            this.lblCaixa.TabIndex = 11;
            this.lblCaixa.Text = "Nº Caixa";
            this.lblCaixa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblDocumento.Location = new System.Drawing.Point(10, 140);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(95, 16);
            this.lblDocumento.TabIndex = 13;
            this.lblDocumento.Text = "Nº Documento";
            this.lblDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpDocumentos
            // 
            this.grpDocumentos.Controls.Add(this.lstDocumentos);
            this.grpDocumentos.Enabled = false;
            this.grpDocumentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.grpDocumentos.Location = new System.Drawing.Point(7, 165);
            this.grpDocumentos.Name = "grpDocumentos";
            this.grpDocumentos.Size = new System.Drawing.Size(263, 366);
            this.grpDocumentos.TabIndex = 13;
            this.grpDocumentos.TabStop = false;
            this.grpDocumentos.Text = "Documentos Lidos - 0";
            // 
            // lstDocumentos
            // 
            this.lstDocumentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lstDocumentos.FormattingEnabled = true;
            this.lstDocumentos.ItemHeight = 16;
            this.lstDocumentos.Location = new System.Drawing.Point(6, 29);
            this.lstDocumentos.Name = "lstDocumentos";
            this.lstDocumentos.Size = new System.Drawing.Size(250, 324);
            this.lstDocumentos.Sorted = true;
            this.lstDocumentos.TabIndex = 0;
            this.lstDocumentos.SelectedIndexChanged += new System.EventHandler(this.lstDocumentos_SelectedIndexChanged);
            this.lstDocumentos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstDocumentos_KeyDown);
            // 
            // cboCaixa
            // 
            this.cboCaixa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCaixa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCaixa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCaixa.Enabled = false;
            this.cboCaixa.FormattingEnabled = true;
            this.cboCaixa.Location = new System.Drawing.Point(112, 44);
            this.cboCaixa.Name = "cboCaixa";
            this.cboCaixa.Size = new System.Drawing.Size(285, 21);
            this.cboCaixa.TabIndex = 1;
            this.cboCaixa.SelectedIndexChanged += new System.EventHandler(this.cboCaixa_SelectedIndexChanged);
            this.cboCaixa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboCaixa_KeyDown);
            // 
            // cboLote
            // 
            this.cboLote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLote.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboLote.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboLote.Enabled = false;
            this.cboLote.FormattingEnabled = true;
            this.cboLote.Location = new System.Drawing.Point(112, 106);
            this.cboLote.Name = "cboLote";
            this.cboLote.Size = new System.Drawing.Size(285, 21);
            this.cboLote.TabIndex = 5;
            this.cboLote.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboLote_KeyDown);
            // 
            // lblLote
            // 
            this.lblLote.AutoSize = true;
            this.lblLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblLote.Location = new System.Drawing.Point(45, 107);
            this.lblLote.Name = "lblLote";
            this.lblLote.Size = new System.Drawing.Size(52, 16);
            this.lblLote.TabIndex = 25;
            this.lblLote.Text = "Nº Lote";
            this.lblLote.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDocumento
            // 
            this.txtDocumento.Enabled = false;
            this.txtDocumento.Location = new System.Drawing.Point(112, 139);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(151, 20);
            this.txtDocumento.TabIndex = 9;
            this.txtDocumento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDocumento_KeyDown);
            // 
            // btnRemoverCaixa
            // 
            this.btnRemoverCaixa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoverCaixa.Enabled = false;
            this.btnRemoverCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnRemoverCaixa.Image = global::SID_Telecred.Properties.Resources.MetapackageRem;
            this.btnRemoverCaixa.Location = new System.Drawing.Point(495, 41);
            this.btnRemoverCaixa.Name = "btnRemoverCaixa";
            this.btnRemoverCaixa.Size = new System.Drawing.Size(40, 40);
            this.btnRemoverCaixa.TabIndex = 4;
            this.btnRemoverCaixa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnRemoverCaixa, "Excluir Caixa");
            this.btnRemoverCaixa.UseVisualStyleBackColor = true;
            this.btnRemoverCaixa.Click += new System.EventHandler(this.btnRemoverCaixa_Click);
            // 
            // btnGravarCaixa
            // 
            this.btnGravarCaixa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGravarCaixa.Enabled = false;
            this.btnGravarCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnGravarCaixa.Image = global::SID_Telecred.Properties.Resources.MetapackageSave;
            this.btnGravarCaixa.Location = new System.Drawing.Point(449, 41);
            this.btnGravarCaixa.Name = "btnGravarCaixa";
            this.btnGravarCaixa.Size = new System.Drawing.Size(40, 40);
            this.btnGravarCaixa.TabIndex = 3;
            this.btnGravarCaixa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnGravarCaixa, "Fechar Caixa");
            this.btnGravarCaixa.UseVisualStyleBackColor = true;
            this.btnGravarCaixa.Click += new System.EventHandler(this.btnGravarCaixa_Click);
            // 
            // btnAbrirCaixa
            // 
            this.btnAbrirCaixa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbrirCaixa.Enabled = false;
            this.btnAbrirCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnAbrirCaixa.Image = global::SID_Telecred.Properties.Resources.MetapackageOk;
            this.btnAbrirCaixa.Location = new System.Drawing.Point(403, 41);
            this.btnAbrirCaixa.Name = "btnAbrirCaixa";
            this.btnAbrirCaixa.Size = new System.Drawing.Size(40, 40);
            this.btnAbrirCaixa.TabIndex = 2;
            this.btnAbrirCaixa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnAbrirCaixa, "Abrir Caixa");
            this.btnAbrirCaixa.UseVisualStyleBackColor = true;
            this.btnAbrirCaixa.Click += new System.EventHandler(this.btnAbrirCaixa_Click);
            // 
            // btnRemoverLote
            // 
            this.btnRemoverLote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoverLote.Enabled = false;
            this.btnRemoverLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnRemoverLote.Image = global::SID_Telecred.Properties.Resources.LightBrowBoxRem;
            this.btnRemoverLote.Location = new System.Drawing.Point(495, 87);
            this.btnRemoverLote.Name = "btnRemoverLote";
            this.btnRemoverLote.Size = new System.Drawing.Size(40, 40);
            this.btnRemoverLote.TabIndex = 8;
            this.btnRemoverLote.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnRemoverLote, "Excluir Lote");
            this.btnRemoverLote.UseVisualStyleBackColor = true;
            this.btnRemoverLote.Click += new System.EventHandler(this.btnRemoverLote_Click);
            // 
            // btnFecharLote
            // 
            this.btnFecharLote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFecharLote.Enabled = false;
            this.btnFecharLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnFecharLote.Image = global::SID_Telecred.Properties.Resources.LightBrowBoxSave;
            this.btnFecharLote.Location = new System.Drawing.Point(449, 87);
            this.btnFecharLote.Name = "btnFecharLote";
            this.btnFecharLote.Size = new System.Drawing.Size(40, 40);
            this.btnFecharLote.TabIndex = 7;
            this.btnFecharLote.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnFecharLote, "Fechar Lote");
            this.btnFecharLote.UseVisualStyleBackColor = true;
            this.btnFecharLote.Click += new System.EventHandler(this.btnFecharLote_Click);
            // 
            // btnAbrirLote
            // 
            this.btnAbrirLote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbrirLote.Enabled = false;
            this.btnAbrirLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnAbrirLote.Image = global::SID_Telecred.Properties.Resources.LightBrowBoxOk;
            this.btnAbrirLote.Location = new System.Drawing.Point(403, 87);
            this.btnAbrirLote.Name = "btnAbrirLote";
            this.btnAbrirLote.Size = new System.Drawing.Size(40, 40);
            this.btnAbrirLote.TabIndex = 6;
            this.btnAbrirLote.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnAbrirLote, "Abrir Lote");
            this.btnAbrirLote.UseVisualStyleBackColor = true;
            this.btnAbrirLote.Click += new System.EventHandler(this.btnAbrirLote_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.Enabled = false;
            this.btnRemover.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnRemover.Image = global::SID_Telecred.Properties.Resources.DocumentClear;
            this.btnRemover.Location = new System.Drawing.Point(276, 191);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(40, 40);
            this.btnRemover.TabIndex = 11;
            this.btnRemover.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnRemover, "Remover Documento");
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnFechar.Image = global::SID_Telecred.Properties.Resources.delete;
            this.btnFechar.Location = new System.Drawing.Point(13, 542);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(141, 40);
            this.btnFechar.TabIndex = 14;
            this.btnFechar.Text = "&Cancelar";
            this.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Image = global::SID_Telecred.Properties.Resources.DocumentAdd;
            this.btnAdd.Location = new System.Drawing.Point(276, 140);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(40, 40);
            this.btnAdd.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btnAdd, "Adicionar Documento");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAddFilho
            // 
            this.btnAddFilho.Image = global::SID_Telecred.Properties.Resources.DocumentAdd;
            this.btnAddFilho.Location = new System.Drawing.Point(163, 30);
            this.btnAddFilho.Name = "btnAddFilho";
            this.btnAddFilho.Size = new System.Drawing.Size(40, 40);
            this.btnAddFilho.TabIndex = 39;
            this.toolTip1.SetToolTip(this.btnAddFilho, "Adicionar Documento");
            this.btnAddFilho.UseVisualStyleBackColor = true;
            this.btnAddFilho.Click += new System.EventHandler(this.btnAddFilho_Click);
            // 
            // btnRemFilho
            // 
            this.btnRemFilho.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnRemFilho.Image = global::SID_Telecred.Properties.Resources.DocumentClear;
            this.btnRemFilho.Location = new System.Drawing.Point(206, 30);
            this.btnRemFilho.Name = "btnRemFilho";
            this.btnRemFilho.Size = new System.Drawing.Size(40, 40);
            this.btnRemFilho.TabIndex = 40;
            this.btnRemFilho.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnRemFilho, "Remover Documento");
            this.btnRemFilho.UseVisualStyleBackColor = true;
            this.btnRemFilho.Click += new System.EventHandler(this.btnRemFilho_Click);
            // 
            // cboServico
            // 
            this.cboServico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboServico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboServico.FormattingEnabled = true;
            this.cboServico.Location = new System.Drawing.Point(112, 11);
            this.cboServico.Name = "cboServico";
            this.cboServico.Size = new System.Drawing.Size(423, 24);
            this.cboServico.TabIndex = 0;
            this.cboServico.SelectedIndexChanged += new System.EventHandler(this.cboServico_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.Location = new System.Drawing.Point(43, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 33;
            this.label2.Text = "Serviço";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpAutomatico
            // 
            this.grpAutomatico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAutomatico.Controls.Add(this.txtPrefixo);
            this.grpAutomatico.Controls.Add(this.label4);
            this.grpAutomatico.Controls.Add(this.btnProcessar);
            this.grpAutomatico.Controls.Add(this.nudFim);
            this.grpAutomatico.Controls.Add(this.nudInicio);
            this.grpAutomatico.Controls.Add(this.label3);
            this.grpAutomatico.Controls.Add(this.label1);
            this.grpAutomatico.Enabled = false;
            this.grpAutomatico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.grpAutomatico.Location = new System.Drawing.Point(322, 133);
            this.grpAutomatico.Name = "grpAutomatico";
            this.grpAutomatico.Size = new System.Drawing.Size(422, 98);
            this.grpAutomatico.TabIndex = 12;
            this.grpAutomatico.TabStop = false;
            this.grpAutomatico.Text = "Automático";
            // 
            // txtPrefixo
            // 
            this.txtPrefixo.Enabled = false;
            this.txtPrefixo.Location = new System.Drawing.Point(56, 28);
            this.txtPrefixo.MaxLength = 3;
            this.txtPrefixo.Name = "txtPrefixo";
            this.txtPrefixo.Size = new System.Drawing.Size(36, 22);
            this.txtPrefixo.TabIndex = 1;
            this.txtPrefixo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label4.Location = new System.Drawing.Point(6, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 16);
            this.label4.TabIndex = 39;
            this.label4.Text = "Prefixo";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnProcessar
            // 
            this.btnProcessar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcessar.Enabled = false;
            this.btnProcessar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnProcessar.Image = global::SID_Telecred.Properties.Resources.Gear;
            this.btnProcessar.Location = new System.Drawing.Point(278, 15);
            this.btnProcessar.Name = "btnProcessar";
            this.btnProcessar.Size = new System.Drawing.Size(135, 40);
            this.btnProcessar.TabIndex = 4;
            this.btnProcessar.Text = "&Processar";
            this.btnProcessar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProcessar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProcessar.UseVisualStyleBackColor = true;
            this.btnProcessar.Click += new System.EventHandler(this.btnProcessar_Click);
            // 
            // nudFim
            // 
            this.nudFim.Enabled = false;
            this.nudFim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudFim.Location = new System.Drawing.Point(166, 61);
            this.nudFim.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudFim.Name = "nudFim";
            this.nudFim.Size = new System.Drawing.Size(67, 22);
            this.nudFim.TabIndex = 3;
            // 
            // nudInicio
            // 
            this.nudInicio.Enabled = false;
            this.nudInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudInicio.Location = new System.Drawing.Point(54, 61);
            this.nudInicio.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudInicio.Name = "nudInicio";
            this.nudInicio.Size = new System.Drawing.Size(67, 22);
            this.nudInicio.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label3.Location = new System.Drawing.Point(130, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 16);
            this.label3.TabIndex = 37;
            this.label3.Text = "Fim";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.Location = new System.Drawing.Point(11, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 16);
            this.label1.TabIndex = 36;
            this.label1.Text = "Início";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpFilho
            // 
            this.grpFilho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFilho.Controls.Add(this.btnRemFilho);
            this.grpFilho.Controls.Add(this.btnAddFilho);
            this.grpFilho.Controls.Add(this.txtFilho);
            this.grpFilho.Controls.Add(this.label5);
            this.grpFilho.Controls.Add(this.lstFilhos);
            this.grpFilho.Enabled = false;
            this.grpFilho.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.grpFilho.Location = new System.Drawing.Point(489, 237);
            this.grpFilho.Name = "grpFilho";
            this.grpFilho.Size = new System.Drawing.Size(255, 294);
            this.grpFilho.TabIndex = 34;
            this.grpFilho.TabStop = false;
            this.grpFilho.Text = "Documentos Filhos";
            // 
            // txtFilho
            // 
            this.txtFilho.Location = new System.Drawing.Point(6, 48);
            this.txtFilho.Name = "txtFilho";
            this.txtFilho.Size = new System.Drawing.Size(151, 22);
            this.txtFilho.TabIndex = 37;
            this.txtFilho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFilho_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 16);
            this.label5.TabIndex = 38;
            this.label5.Text = "Nº Documento Filho";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lstFilhos
            // 
            this.lstFilhos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lstFilhos.FormattingEnabled = true;
            this.lstFilhos.ItemHeight = 16;
            this.lstFilhos.Location = new System.Drawing.Point(6, 85);
            this.lstFilhos.Name = "lstFilhos";
            this.lstFilhos.Size = new System.Drawing.Size(240, 196);
            this.lstFilhos.Sorted = true;
            this.lstFilhos.TabIndex = 0;
            this.lstFilhos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstFilhos_KeyDown);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtTotalCaixa);
            this.groupBox3.Controls.Add(this.txtDocumentosCaixa);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.groupBox3.Location = new System.Drawing.Point(541, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(202, 71);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Documentos x Caixa";
            // 
            // txtTotalCaixa
            // 
            this.txtTotalCaixa.Location = new System.Drawing.Point(96, 44);
            this.txtTotalCaixa.Name = "txtTotalCaixa";
            this.txtTotalCaixa.ReadOnly = true;
            this.txtTotalCaixa.Size = new System.Drawing.Size(78, 22);
            this.txtTotalCaixa.TabIndex = 42;
            this.txtTotalCaixa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDocumentosCaixa
            // 
            this.txtDocumentosCaixa.Location = new System.Drawing.Point(96, 19);
            this.txtDocumentosCaixa.Name = "txtDocumentosCaixa";
            this.txtDocumentosCaixa.ReadOnly = true;
            this.txtDocumentosCaixa.Size = new System.Drawing.Size(78, 22);
            this.txtDocumentosCaixa.TabIndex = 41;
            this.txtDocumentosCaixa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label7.Location = new System.Drawing.Point(13, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 16);
            this.label7.TabIndex = 40;
            this.label7.Text = "Esta Caixa";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label6.Location = new System.Drawing.Point(42, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 16);
            this.label6.TabIndex = 39;
            this.label6.Text = "Limite";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpFormalizacao
            // 
            this.grpFormalizacao.Controls.Add(this.chkDigital);
            this.grpFormalizacao.Controls.Add(this.chkTodos);
            this.grpFormalizacao.Controls.Add(this.chkData);
            this.grpFormalizacao.Controls.Add(this.chkAssinatura);
            this.grpFormalizacao.Controls.Add(this.chkTelefone);
            this.grpFormalizacao.Controls.Add(this.chkCarimbo);
            this.grpFormalizacao.Controls.Add(this.chkAltura);
            this.grpFormalizacao.Controls.Add(this.chkApto);
            this.grpFormalizacao.Controls.Add(this.chkPCMSO);
            this.grpFormalizacao.Controls.Add(this.chkImpresso);
            this.grpFormalizacao.Enabled = false;
            this.grpFormalizacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.grpFormalizacao.Location = new System.Drawing.Point(276, 237);
            this.grpFormalizacao.Name = "grpFormalizacao";
            this.grpFormalizacao.Size = new System.Drawing.Size(208, 294);
            this.grpFormalizacao.TabIndex = 36;
            this.grpFormalizacao.TabStop = false;
            this.grpFormalizacao.Text = "Formalização por Funcionário";
            // 
            // chkTodos
            // 
            this.chkTodos.AutoSize = true;
            this.chkTodos.Location = new System.Drawing.Point(20, 260);
            this.chkTodos.Name = "chkTodos";
            this.chkTodos.Size = new System.Drawing.Size(112, 20);
            this.chkTodos.TabIndex = 8;
            this.chkTodos.Text = "Marcar Todos";
            this.chkTodos.UseVisualStyleBackColor = true;
            this.chkTodos.CheckedChanged += new System.EventHandler(this.chkTodos_CheckedChanged);
            this.chkTodos.Click += new System.EventHandler(this.chkTodos_Click);
            // 
            // chkData
            // 
            this.chkData.AutoSize = true;
            this.chkData.Location = new System.Drawing.Point(20, 208);
            this.chkData.Name = "chkData";
            this.chkData.Size = new System.Drawing.Size(158, 20);
            this.chkData.TabIndex = 7;
            this.chkData.Text = "Data Exames Clínicos";
            this.chkData.UseVisualStyleBackColor = true;
            this.chkData.CheckedChanged += new System.EventHandler(this.chkData_CheckedChanged);
            // 
            // chkAssinatura
            // 
            this.chkAssinatura.AutoSize = true;
            this.chkAssinatura.Location = new System.Drawing.Point(20, 182);
            this.chkAssinatura.Name = "chkAssinatura";
            this.chkAssinatura.Size = new System.Drawing.Size(163, 20);
            this.chkAssinatura.TabIndex = 6;
            this.chkAssinatura.Text = "Assinatura Funcionário";
            this.chkAssinatura.UseVisualStyleBackColor = true;
            this.chkAssinatura.CheckedChanged += new System.EventHandler(this.chkAssinatura_CheckedChanged);
            // 
            // chkTelefone
            // 
            this.chkTelefone.AutoSize = true;
            this.chkTelefone.Location = new System.Drawing.Point(20, 156);
            this.chkTelefone.Name = "chkTelefone";
            this.chkTelefone.Size = new System.Drawing.Size(145, 20);
            this.chkTelefone.TabIndex = 5;
            this.chkTelefone.Text = "Tel/Contato Médico";
            this.chkTelefone.UseVisualStyleBackColor = true;
            this.chkTelefone.CheckedChanged += new System.EventHandler(this.chkTelefone_CheckedChanged);
            // 
            // chkCarimbo
            // 
            this.chkCarimbo.AutoSize = true;
            this.chkCarimbo.Location = new System.Drawing.Point(20, 130);
            this.chkCarimbo.Name = "chkCarimbo";
            this.chkCarimbo.Size = new System.Drawing.Size(153, 20);
            this.chkCarimbo.TabIndex = 4;
            this.chkCarimbo.Text = "Ass/Carimbo Médico";
            this.chkCarimbo.UseVisualStyleBackColor = true;
            this.chkCarimbo.CheckedChanged += new System.EventHandler(this.chkCarimbo_CheckedChanged);
            // 
            // chkAltura
            // 
            this.chkAltura.AutoSize = true;
            this.chkAltura.Location = new System.Drawing.Point(20, 104);
            this.chkAltura.Name = "chkAltura";
            this.chkAltura.Size = new System.Drawing.Size(142, 20);
            this.chkAltura.TabIndex = 3;
            this.chkAltura.Text = "Aptidão para Altura";
            this.chkAltura.UseVisualStyleBackColor = true;
            this.chkAltura.CheckedChanged += new System.EventHandler(this.chkAltura_CheckedChanged);
            // 
            // chkApto
            // 
            this.chkApto.AutoSize = true;
            this.chkApto.Location = new System.Drawing.Point(20, 78);
            this.chkApto.Name = "chkApto";
            this.chkApto.Size = new System.Drawing.Size(124, 20);
            this.chkApto.TabIndex = 2;
            this.chkApto.Text = "APTO / INAPTO";
            this.chkApto.UseVisualStyleBackColor = true;
            this.chkApto.CheckedChanged += new System.EventHandler(this.chkApto_CheckedChanged);
            // 
            // chkPCMSO
            // 
            this.chkPCMSO.AutoSize = true;
            this.chkPCMSO.Location = new System.Drawing.Point(20, 52);
            this.chkPCMSO.Name = "chkPCMSO";
            this.chkPCMSO.Size = new System.Drawing.Size(118, 20);
            this.chkPCMSO.TabIndex = 1;
            this.chkPCMSO.Text = "Coord. PCMSO";
            this.chkPCMSO.UseVisualStyleBackColor = true;
            this.chkPCMSO.CheckedChanged += new System.EventHandler(this.chkPCMSO_CheckedChanged);
            // 
            // chkImpresso
            // 
            this.chkImpresso.AutoSize = true;
            this.chkImpresso.Location = new System.Drawing.Point(20, 26);
            this.chkImpresso.Name = "chkImpresso";
            this.chkImpresso.Size = new System.Drawing.Size(130, 20);
            this.chkImpresso.TabIndex = 0;
            this.chkImpresso.Text = "Impresso Correto";
            this.chkImpresso.UseVisualStyleBackColor = true;
            this.chkImpresso.CheckedChanged += new System.EventHandler(this.chkImpresso_CheckedChanged);
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmpresa.Enabled = false;
            this.txtEmpresa.Location = new System.Drawing.Point(112, 76);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.ReadOnly = true;
            this.txtEmpresa.Size = new System.Drawing.Size(285, 20);
            this.txtEmpresa.TabIndex = 59;
            this.txtEmpresa.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(34, 77);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 16);
            this.label8.TabIndex = 58;
            this.label8.Text = "Empresa";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkDocumentoPai
            // 
            this.chkDocumentoPai.AutoSize = true;
            this.chkDocumentoPai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkDocumentoPai.Location = new System.Drawing.Point(553, 98);
            this.chkDocumentoPai.Name = "chkDocumentoPai";
            this.chkDocumentoPai.Size = new System.Drawing.Size(182, 20);
            this.chkDocumentoPai.TabIndex = 60;
            this.chkDocumentoPai.Text = "Somente documentos PAI";
            this.chkDocumentoPai.UseVisualStyleBackColor = true;
            // 
            // chkDigital
            // 
            this.chkDigital.AutoSize = true;
            this.chkDigital.Location = new System.Drawing.Point(20, 234);
            this.chkDigital.Name = "chkDigital";
            this.chkDigital.Size = new System.Drawing.Size(132, 20);
            this.chkDigital.TabIndex = 9;
            this.chkDigital.Text = "Formulário Digital";
            this.chkDigital.UseVisualStyleBackColor = true;
            this.chkDigital.CheckedChanged += new System.EventHandler(this.chkDigital_CheckedChanged);
            // 
            // frmCriacaoLotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 594);
            this.Controls.Add(this.chkDocumentoPai);
            this.Controls.Add(this.txtEmpresa);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.grpFormalizacao);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grpFilho);
            this.Controls.Add(this.grpAutomatico);
            this.Controls.Add(this.cboServico);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRemoverCaixa);
            this.Controls.Add(this.btnGravarCaixa);
            this.Controls.Add(this.btnAbrirCaixa);
            this.Controls.Add(this.btnRemoverLote);
            this.Controls.Add(this.btnFecharLote);
            this.Controls.Add(this.btnAbrirLote);
            this.Controls.Add(this.txtDocumento);
            this.Controls.Add(this.lblLote);
            this.Controls.Add(this.cboLote);
            this.Controls.Add(this.cboCaixa);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.grpDocumentos);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblDocumento);
            this.Controls.Add(this.lblCaixa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCriacaoLotes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Lotes e Imagens";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAberturaCaixa_FormClosing);
            this.Load += new System.EventHandler(this.frmAberturaCaixa_Load);
            this.grpDocumentos.ResumeLayout(false);
            this.grpAutomatico.ResumeLayout(false);
            this.grpAutomatico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInicio)).EndInit();
            this.grpFilho.ResumeLayout(false);
            this.grpFilho.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.grpFormalizacao.ResumeLayout(false);
            this.grpFormalizacao.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCaixa;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox grpDocumentos;
        private System.Windows.Forms.ListBox lstDocumentos;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.ComboBox cboCaixa;
        private System.Windows.Forms.ComboBox cboLote;
        private System.Windows.Forms.Label lblLote;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Button btnAbrirLote;
        private System.Windows.Forms.Button btnFecharLote;
        private System.Windows.Forms.Button btnRemoverLote;
        private System.Windows.Forms.Button btnRemoverCaixa;
        private System.Windows.Forms.Button btnGravarCaixa;
        private System.Windows.Forms.Button btnAbrirCaixa;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox cboServico;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpAutomatico;
        private System.Windows.Forms.TextBox txtPrefixo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnProcessar;
        private System.Windows.Forms.NumericUpDown nudFim;
        private System.Windows.Forms.NumericUpDown nudInicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpFilho;
        private System.Windows.Forms.Button btnRemFilho;
        private System.Windows.Forms.Button btnAddFilho;
        private System.Windows.Forms.TextBox txtFilho;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstFilhos;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtTotalCaixa;
        private System.Windows.Forms.TextBox txtDocumentosCaixa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox grpFormalizacao;
        private System.Windows.Forms.CheckBox chkData;
        private System.Windows.Forms.CheckBox chkAssinatura;
        private System.Windows.Forms.CheckBox chkTelefone;
        private System.Windows.Forms.CheckBox chkCarimbo;
        private System.Windows.Forms.CheckBox chkAltura;
        private System.Windows.Forms.CheckBox chkApto;
        private System.Windows.Forms.CheckBox chkPCMSO;
        private System.Windows.Forms.CheckBox chkImpresso;
        private System.Windows.Forms.CheckBox chkTodos;
        private System.Windows.Forms.TextBox txtEmpresa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkDocumentoPai;
        private System.Windows.Forms.CheckBox chkDigital;
    }
}