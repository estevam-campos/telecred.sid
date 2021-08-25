namespace SID_Telecred
{
    partial class frmImportarDigitalizados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportarDigitalizados));
            this.ofdArquivo = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cboCaixas = new System.Windows.Forms.ComboBox();
            this.grpCaixa = new System.Windows.Forms.GroupBox();
            this.lstCaixa = new System.Windows.Forms.ListBox();
            this.grpDocumentos = new System.Windows.Forms.GroupBox();
            this.pctDocumento = new System.Windows.Forms.PictureBox();
            this.lblDocumentos = new System.Windows.Forms.Label();
            this.cboLote = new System.Windows.Forms.ComboBox();
            this.lblLote = new System.Windows.Forms.Label();
            this.btnComparar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnLiberarLote = new System.Windows.Forms.Button();
            this.pgbProcesso = new System.Windows.Forms.ProgressBar();
            this.cboServico = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstImagens = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pctImagens = new System.Windows.Forms.PictureBox();
            this.lblImagens = new System.Windows.Forms.Label();
            this.grpCaixa.SuspendLayout();
            this.grpDocumentos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctDocumento)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctImagens)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 32;
            this.label1.Text = "Caixa";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboCaixas
            // 
            this.cboCaixas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCaixas.FormattingEnabled = true;
            this.cboCaixas.Location = new System.Drawing.Point(66, 37);
            this.cboCaixas.Name = "cboCaixas";
            this.cboCaixas.Size = new System.Drawing.Size(165, 21);
            this.cboCaixas.TabIndex = 1;
            this.cboCaixas.SelectedIndexChanged += new System.EventHandler(this.cboCaixas_SelectedIndexChanged);
            // 
            // grpCaixa
            // 
            this.grpCaixa.Controls.Add(this.lstCaixa);
            this.grpCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.grpCaixa.Location = new System.Drawing.Point(10, 64);
            this.grpCaixa.Name = "grpCaixa";
            this.grpCaixa.Size = new System.Drawing.Size(471, 285);
            this.grpCaixa.TabIndex = 6;
            this.grpCaixa.TabStop = false;
            this.grpCaixa.Text = "Documentos";
            // 
            // lstCaixa
            // 
            this.lstCaixa.FormattingEnabled = true;
            this.lstCaixa.ItemHeight = 16;
            this.lstCaixa.Location = new System.Drawing.Point(10, 19);
            this.lstCaixa.Name = "lstCaixa";
            this.lstCaixa.Size = new System.Drawing.Size(455, 260);
            this.lstCaixa.TabIndex = 0;
            // 
            // grpDocumentos
            // 
            this.grpDocumentos.Controls.Add(this.pctDocumento);
            this.grpDocumentos.Controls.Add(this.lblDocumentos);
            this.grpDocumentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.grpDocumentos.Location = new System.Drawing.Point(487, 130);
            this.grpDocumentos.Name = "grpDocumentos";
            this.grpDocumentos.Size = new System.Drawing.Size(141, 55);
            this.grpDocumentos.TabIndex = 36;
            this.grpDocumentos.TabStop = false;
            this.grpDocumentos.Text = "Não Localizados";
            // 
            // pctDocumento
            // 
            this.pctDocumento.Image = global::SID_Telecred.Properties.Resources.check;
            this.pctDocumento.Location = new System.Drawing.Point(106, 17);
            this.pctDocumento.Name = "pctDocumento";
            this.pctDocumento.Size = new System.Drawing.Size(27, 32);
            this.pctDocumento.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctDocumento.TabIndex = 41;
            this.pctDocumento.TabStop = false;
            this.pctDocumento.Visible = false;
            // 
            // lblDocumentos
            // 
            this.lblDocumentos.Location = new System.Drawing.Point(7, 21);
            this.lblDocumentos.Name = "lblDocumentos";
            this.lblDocumentos.Size = new System.Drawing.Size(126, 20);
            this.lblDocumentos.TabIndex = 39;
            this.lblDocumentos.Text = "-";
            this.lblDocumentos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboLote
            // 
            this.cboLote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLote.FormattingEnabled = true;
            this.cboLote.Location = new System.Drawing.Point(293, 37);
            this.cboLote.Name = "cboLote";
            this.cboLote.Size = new System.Drawing.Size(187, 21);
            this.cboLote.TabIndex = 2;
            this.cboLote.SelectedIndexChanged += new System.EventHandler(this.cboLote_SelectedIndexChanged);
            // 
            // lblLote
            // 
            this.lblLote.AutoSize = true;
            this.lblLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLote.Location = new System.Drawing.Point(245, 38);
            this.lblLote.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLote.Name = "lblLote";
            this.lblLote.Size = new System.Drawing.Size(41, 16);
            this.lblLote.TabIndex = 39;
            this.lblLote.Text = "Lotes";
            this.lblLote.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnComparar
            // 
            this.btnComparar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComparar.Image = global::SID_Telecred.Properties.Resources.ImageReplace;
            this.btnComparar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnComparar.Location = new System.Drawing.Point(487, 13);
            this.btnComparar.Margin = new System.Windows.Forms.Padding(4);
            this.btnComparar.Name = "btnComparar";
            this.btnComparar.Size = new System.Drawing.Size(141, 40);
            this.btnComparar.TabIndex = 3;
            this.btnComparar.Text = "&Vincular Imagens";
            this.btnComparar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnComparar.UseVisualStyleBackColor = true;
            this.btnComparar.Click += new System.EventHandler(this.btnComparar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnFechar.Image = global::SID_Telecred.Properties.Resources.delete;
            this.btnFechar.Location = new System.Drawing.Point(487, 607);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(141, 40);
            this.btnFechar.TabIndex = 5;
            this.btnFechar.Text = "&Cancelar";
            this.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnLiberarLote
            // 
            this.btnLiberarLote.Enabled = false;
            this.btnLiberarLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLiberarLote.Image = global::SID_Telecred.Properties.Resources.LightBrowBoxOk;
            this.btnLiberarLote.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLiberarLote.Location = new System.Drawing.Point(487, 83);
            this.btnLiberarLote.Margin = new System.Windows.Forms.Padding(4);
            this.btnLiberarLote.Name = "btnLiberarLote";
            this.btnLiberarLote.Size = new System.Drawing.Size(141, 40);
            this.btnLiberarLote.TabIndex = 4;
            this.btnLiberarLote.Text = "&Liberar Lote";
            this.btnLiberarLote.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLiberarLote.UseVisualStyleBackColor = true;
            this.btnLiberarLote.Click += new System.EventHandler(this.btnLiberarLote_Click);
            // 
            // pgbProcesso
            // 
            this.pgbProcesso.Location = new System.Drawing.Point(10, 653);
            this.pgbProcesso.Name = "pgbProcesso";
            this.pgbProcesso.Size = new System.Drawing.Size(614, 6);
            this.pgbProcesso.TabIndex = 42;
            this.pgbProcesso.Visible = false;
            // 
            // cboServico
            // 
            this.cboServico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboServico.FormattingEnabled = true;
            this.cboServico.Location = new System.Drawing.Point(66, 7);
            this.cboServico.Name = "cboServico";
            this.cboServico.Size = new System.Drawing.Size(414, 24);
            this.cboServico.TabIndex = 0;
            this.cboServico.SelectedIndexChanged += new System.EventHandler(this.cboServico_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.Location = new System.Drawing.Point(12, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 43;
            this.label2.Text = "Serviço";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstImagens);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(10, 355);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(471, 292);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Imagens";
            // 
            // lstImagens
            // 
            this.lstImagens.FormattingEnabled = true;
            this.lstImagens.ItemHeight = 16;
            this.lstImagens.Location = new System.Drawing.Point(10, 19);
            this.lstImagens.Name = "lstImagens";
            this.lstImagens.ScrollAlwaysVisible = true;
            this.lstImagens.Size = new System.Drawing.Size(455, 260);
            this.lstImagens.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pctImagens);
            this.groupBox2.Controls.Add(this.lblImagens);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.groupBox2.Location = new System.Drawing.Point(487, 355);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(141, 55);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Não Localizados";
            // 
            // pctImagens
            // 
            this.pctImagens.Image = global::SID_Telecred.Properties.Resources.check;
            this.pctImagens.Location = new System.Drawing.Point(106, 17);
            this.pctImagens.Name = "pctImagens";
            this.pctImagens.Size = new System.Drawing.Size(27, 32);
            this.pctImagens.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctImagens.TabIndex = 41;
            this.pctImagens.TabStop = false;
            this.pctImagens.Visible = false;
            // 
            // lblImagens
            // 
            this.lblImagens.Location = new System.Drawing.Point(7, 21);
            this.lblImagens.Name = "lblImagens";
            this.lblImagens.Size = new System.Drawing.Size(126, 20);
            this.lblImagens.TabIndex = 39;
            this.lblImagens.Text = "-";
            this.lblImagens.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmImportarDigitalizados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 668);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cboServico);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pgbProcesso);
            this.Controls.Add(this.btnComparar);
            this.Controls.Add(this.cboLote);
            this.Controls.Add(this.lblLote);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.grpDocumentos);
            this.Controls.Add(this.grpCaixa);
            this.Controls.Add(this.cboCaixas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLiberarLote);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImportarDigitalizados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importação de Imagens Digitalizadas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmImportarDigitalizados_FormClosing);
            this.Load += new System.EventHandler(this.frmImportarDigitalizados_Load);
            this.grpCaixa.ResumeLayout(false);
            this.grpDocumentos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctDocumento)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctImagens)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLiberarLote;
        private System.Windows.Forms.OpenFileDialog ofdArquivo;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCaixas;
        private System.Windows.Forms.GroupBox grpCaixa;
        private System.Windows.Forms.ListBox lstCaixa;
        private System.Windows.Forms.GroupBox grpDocumentos;
        private System.Windows.Forms.Label lblDocumentos;
        private System.Windows.Forms.PictureBox pctDocumento;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.ComboBox cboLote;
        private System.Windows.Forms.Label lblLote;
        private System.Windows.Forms.Button btnComparar;
        private System.Windows.Forms.ProgressBar pgbProcesso;
        private System.Windows.Forms.ComboBox cboServico;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstImagens;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pctImagens;
        private System.Windows.Forms.Label lblImagens;
    }
}