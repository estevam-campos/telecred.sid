namespace SID_Telecred
{
    partial class frmDigitacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDigitacao));
            this.lblLote = new System.Windows.Forms.Label();
            this.txtServico = new System.Windows.Forms.TextBox();
            this.txtLote = new System.Windows.Forms.TextBox();
            this.grpImagem = new System.Windows.Forms.GroupBox();
            this.pdfDocumento = new AxAcroPDFLib.AxAcroPDF();
            this.lblServico = new System.Windows.Forms.Label();
            this.grpServico = new System.Windows.Forms.GroupBox();
            this.btnAbrirLote = new System.Windows.Forms.Button();
            this.cboLote = new System.Windows.Forms.ComboBox();
            this.cboServico = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.stsStatus = new System.Windows.Forms.StatusStrip();
            this.lblContadorRegistros = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblProgresso = new System.Windows.Forms.ToolStripStatusLabel();
            this.pgbProgresso = new System.Windows.Forms.ToolStripProgressBar();
            this.tmrFocus = new System.Windows.Forms.Timer(this.components);
            this.grpFilho = new System.Windows.Forms.GroupBox();
            this.pdfFilho = new AxAcroPDFLib.AxAcroPDF();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnFilho = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnIlegivel = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.grpImagem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pdfDocumento)).BeginInit();
            this.grpServico.SuspendLayout();
            this.stsStatus.SuspendLayout();
            this.grpFilho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pdfFilho)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLote
            // 
            this.lblLote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblLote.Location = new System.Drawing.Point(520, 57);
            this.lblLote.Name = "lblLote";
            this.lblLote.Size = new System.Drawing.Size(164, 20);
            this.lblLote.TabIndex = 11;
            this.lblLote.Text = "Lote";
            this.lblLote.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblLote.Visible = false;
            // 
            // txtServico
            // 
            this.txtServico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtServico.Location = new System.Drawing.Point(689, 26);
            this.txtServico.Name = "txtServico";
            this.txtServico.ReadOnly = true;
            this.txtServico.Size = new System.Drawing.Size(275, 22);
            this.txtServico.TabIndex = 10;
            this.txtServico.TabStop = false;
            this.txtServico.Visible = false;
            // 
            // txtLote
            // 
            this.txtLote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtLote.Location = new System.Drawing.Point(689, 56);
            this.txtLote.Name = "txtLote";
            this.txtLote.ReadOnly = true;
            this.txtLote.Size = new System.Drawing.Size(275, 22);
            this.txtLote.TabIndex = 9;
            this.txtLote.TabStop = false;
            this.txtLote.Visible = false;
            // 
            // grpImagem
            // 
            this.grpImagem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpImagem.Controls.Add(this.pdfDocumento);
            this.grpImagem.Font = new System.Drawing.Font("Arial", 12F);
            this.grpImagem.Location = new System.Drawing.Point(12, 12);
            this.grpImagem.Name = "grpImagem";
            this.grpImagem.Size = new System.Drawing.Size(502, 574);
            this.grpImagem.TabIndex = 8;
            this.grpImagem.TabStop = false;
            this.grpImagem.Text = "Nome da Imagem";
            this.grpImagem.Visible = false;
            // 
            // pdfDocumento
            // 
            this.pdfDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pdfDocumento.Enabled = true;
            this.pdfDocumento.Location = new System.Drawing.Point(6, 20);
            this.pdfDocumento.Name = "pdfDocumento";
            this.pdfDocumento.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pdfDocumento.OcxState")));
            this.pdfDocumento.Size = new System.Drawing.Size(490, 548);
            this.pdfDocumento.TabIndex = 0;
            this.pdfDocumento.TabStop = false;
            // 
            // lblServico
            // 
            this.lblServico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblServico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblServico.Location = new System.Drawing.Point(520, 27);
            this.lblServico.Name = "lblServico";
            this.lblServico.Size = new System.Drawing.Size(164, 20);
            this.lblServico.TabIndex = 7;
            this.lblServico.Text = "Serviço";
            this.lblServico.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblServico.Visible = false;
            // 
            // grpServico
            // 
            this.grpServico.Controls.Add(this.btnAbrirLote);
            this.grpServico.Controls.Add(this.cboLote);
            this.grpServico.Controls.Add(this.cboServico);
            this.grpServico.Controls.Add(this.label2);
            this.grpServico.Controls.Add(this.label1);
            this.grpServico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.grpServico.Location = new System.Drawing.Point(12, 12);
            this.grpServico.Name = "grpServico";
            this.grpServico.Size = new System.Drawing.Size(402, 100);
            this.grpServico.TabIndex = 19;
            this.grpServico.TabStop = false;
            this.grpServico.Text = "Seleção de Serviço";
            // 
            // btnAbrirLote
            // 
            this.btnAbrirLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnAbrirLote.Image = global::SID_Telecred.Properties.Resources.DocumentEdit;
            this.btnAbrirLote.Location = new System.Drawing.Point(255, 53);
            this.btnAbrirLote.Name = "btnAbrirLote";
            this.btnAbrirLote.Size = new System.Drawing.Size(141, 40);
            this.btnAbrirLote.TabIndex = 34;
            this.btnAbrirLote.Text = "&Abrir Lote";
            this.btnAbrirLote.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAbrirLote.UseVisualStyleBackColor = true;
            this.btnAbrirLote.Click += new System.EventHandler(this.btnAbrirLote_Click);
            // 
            // cboLote
            // 
            this.cboLote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboLote.FormattingEnabled = true;
            this.cboLote.Location = new System.Drawing.Point(72, 62);
            this.cboLote.Name = "cboLote";
            this.cboLote.Size = new System.Drawing.Size(177, 24);
            this.cboLote.TabIndex = 33;
            // 
            // cboServico
            // 
            this.cboServico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboServico.FormattingEnabled = true;
            this.cboServico.Location = new System.Drawing.Point(72, 23);
            this.cboServico.Name = "cboServico";
            this.cboServico.Size = new System.Drawing.Size(324, 24);
            this.cboServico.TabIndex = 32;
            this.cboServico.SelectedIndexChanged += new System.EventHandler(this.cboServico_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.Location = new System.Drawing.Point(10, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 31;
            this.label2.Text = "Serviço";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.Location = new System.Drawing.Point(32, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 16);
            this.label1.TabIndex = 30;
            this.label1.Text = "Lote";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // stsStatus
            // 
            this.stsStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblContadorRegistros,
            this.lblProgresso,
            this.pgbProgresso});
            this.stsStatus.Location = new System.Drawing.Point(0, 591);
            this.stsStatus.Name = "stsStatus";
            this.stsStatus.Size = new System.Drawing.Size(976, 22);
            this.stsStatus.TabIndex = 22;
            this.stsStatus.Text = "statusStrip1";
            this.stsStatus.Visible = false;
            // 
            // lblContadorRegistros
            // 
            this.lblContadorRegistros.AutoSize = false;
            this.lblContadorRegistros.Name = "lblContadorRegistros";
            this.lblContadorRegistros.Size = new System.Drawing.Size(245, 17);
            this.lblContadorRegistros.Spring = true;
            this.lblContadorRegistros.Text = "Registros Incluídos: 0000";
            this.lblContadorRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProgresso
            // 
            this.lblProgresso.Name = "lblProgresso";
            this.lblProgresso.Size = new System.Drawing.Size(214, 17);
            this.lblProgresso.Text = "Progresso do Lote: 0000 de 0000 (000%)";
            this.lblProgresso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pgbProgresso
            // 
            this.pgbProgresso.Name = "pgbProgresso";
            this.pgbProgresso.Size = new System.Drawing.Size(500, 16);
            // 
            // tmrFocus
            // 
            this.tmrFocus.Interval = 1000;
            this.tmrFocus.Tick += new System.EventHandler(this.tmrFocus_Tick);
            // 
            // grpFilho
            // 
            this.grpFilho.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFilho.Controls.Add(this.pdfFilho);
            this.grpFilho.Font = new System.Drawing.Font("Arial", 12F);
            this.grpFilho.Location = new System.Drawing.Point(14, 12);
            this.grpFilho.Name = "grpFilho";
            this.grpFilho.Size = new System.Drawing.Size(500, 574);
            this.grpFilho.TabIndex = 25;
            this.grpFilho.TabStop = false;
            this.grpFilho.Visible = false;
            // 
            // pdfFilho
            // 
            this.pdfFilho.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pdfFilho.Enabled = true;
            this.pdfFilho.Location = new System.Drawing.Point(6, 20);
            this.pdfFilho.Name = "pdfFilho";
            this.pdfFilho.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pdfFilho.OcxState")));
            this.pdfFilho.Size = new System.Drawing.Size(490, 548);
            this.pdfFilho.TabIndex = 0;
            this.pdfFilho.TabStop = false;
            this.pdfFilho.OnError += new System.EventHandler(this.pdfFilho_OnError);
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.Image = global::SID_Telecred.Properties.Resources.exit;
            this.btnFechar.Location = new System.Drawing.Point(532, 486);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(140, 44);
            this.btnFechar.TabIndex = 21;
            this.btnFechar.Text = "&Fechar";
            this.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Visible = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnFilho
            // 
            this.btnFilho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilho.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilho.Image = global::SID_Telecred.Properties.Resources.DocumentsChange;
            this.btnFilho.Location = new System.Drawing.Point(678, 536);
            this.btnFilho.Name = "btnFilho";
            this.btnFilho.Size = new System.Drawing.Size(140, 44);
            this.btnFilho.TabIndex = 26;
            this.btnFilho.Text = "&Exibir Filho";
            this.btnFilho.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFilho.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFilho.UseVisualStyleBackColor = true;
            this.btnFilho.Visible = false;
            this.btnFilho.Click += new System.EventHandler(this.btnFilho_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = global::SID_Telecred.Properties.Resources.DocumentRefresh;
            this.btnRefresh.Location = new System.Drawing.Point(532, 536);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(140, 44);
            this.btnRefresh.TabIndex = 24;
            this.btnRefresh.Text = "&Recarregar Imagem";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Visible = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnIlegivel
            // 
            this.btnIlegivel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIlegivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIlegivel.Image = global::SID_Telecred.Properties.Resources.DocumentClear;
            this.btnIlegivel.Location = new System.Drawing.Point(824, 486);
            this.btnIlegivel.Name = "btnIlegivel";
            this.btnIlegivel.Size = new System.Drawing.Size(140, 44);
            this.btnIlegivel.TabIndex = 23;
            this.btnIlegivel.Text = "&Imagem Ilegível";
            this.btnIlegivel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIlegivel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIlegivel.UseVisualStyleBackColor = true;
            this.btnIlegivel.Visible = false;
            this.btnIlegivel.Click += new System.EventHandler(this.btnIlegivel_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Image = global::SID_Telecred.Properties.Resources.Eraser;
            this.btnLimpar.Location = new System.Drawing.Point(678, 486);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(140, 44);
            this.btnLimpar.TabIndex = 18;
            this.btnLimpar.Text = "&Limpar Campos";
            this.btnLimpar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Visible = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnGravar
            // 
            this.btnGravar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGravar.Image = global::SID_Telecred.Properties.Resources.FloppyDisks;
            this.btnGravar.Location = new System.Drawing.Point(824, 536);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(140, 44);
            this.btnGravar.TabIndex = 17;
            this.btnGravar.Text = "&Gravar Registro";
            this.btnGravar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGravar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Visible = false;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // frmDigitacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnFechar;
            this.ClientSize = new System.Drawing.Size(976, 613);
            this.Controls.Add(this.btnFilho);
            this.Controls.Add(this.grpFilho);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnIlegivel);
            this.Controls.Add(this.stsStatus);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.lblLote);
            this.Controls.Add(this.txtServico);
            this.Controls.Add(this.txtLote);
            this.Controls.Add(this.lblServico);
            this.Controls.Add(this.grpServico);
            this.Controls.Add(this.grpImagem);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDigitacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "9";
            this.Text = "Digitação";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDigitacao_FormClosing);
            this.Load += new System.EventHandler(this.frmDigitacao_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDigitacao_KeyDown);
            this.grpImagem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pdfDocumento)).EndInit();
            this.grpServico.ResumeLayout(false);
            this.grpServico.PerformLayout();
            this.stsStatus.ResumeLayout(false);
            this.stsStatus.PerformLayout();
            this.grpFilho.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pdfFilho)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLote;
        private System.Windows.Forms.GroupBox grpImagem;
        private AxAcroPDFLib.AxAcroPDF pdfDocumento;
        private System.Windows.Forms.Label lblServico;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnLimpar;
        public System.Windows.Forms.TextBox txtLote;
        public System.Windows.Forms.TextBox txtServico;
        private System.Windows.Forms.GroupBox grpServico;
        private System.Windows.Forms.Button btnAbrirLote;
        private System.Windows.Forms.ComboBox cboLote;
        private System.Windows.Forms.ComboBox cboServico;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.StatusStrip stsStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblContadorRegistros;
        private System.Windows.Forms.ToolStripStatusLabel lblProgresso;
        private System.Windows.Forms.ToolStripProgressBar pgbProgresso;
        private System.Windows.Forms.Button btnIlegivel;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Timer tmrFocus;
        private System.Windows.Forms.GroupBox grpFilho;
        private AxAcroPDFLib.AxAcroPDF pdfFilho;
        private System.Windows.Forms.Button btnFilho;
    }
}