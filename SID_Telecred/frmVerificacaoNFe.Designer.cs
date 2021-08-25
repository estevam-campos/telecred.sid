namespace SID_Telecred
{
    partial class frmVerificacaoNFe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVerificacaoNFe));
            this.lblAndamento = new System.Windows.Forms.Label();
            this.pgbImportacao = new System.Windows.Forms.ProgressBar();
            this.txtArquivo = new System.Windows.Forms.TextBox();
            this.grpNfe = new System.Windows.Forms.GroupBox();
            this.pctNfe = new System.Windows.Forms.PictureBox();
            this.webNotaFiscal = new System.Windows.Forms.WebBrowser();
            this.ofdArquivo = new System.Windows.Forms.OpenFileDialog();
            this.lblQtde = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkVisualizar = new System.Windows.Forms.CheckBox();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnLimparCampos = new System.Windows.Forms.Button();
            this.btnImportar = new System.Windows.Forms.Button();
            this.btnAbrirArquivo = new System.Windows.Forms.Button();
            this.grpNfe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctNfe)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAndamento
            // 
            this.lblAndamento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAndamento.Location = new System.Drawing.Point(15, 388);
            this.lblAndamento.Name = "lblAndamento";
            this.lblAndamento.Size = new System.Drawing.Size(650, 16);
            this.lblAndamento.TabIndex = 25;
            this.lblAndamento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pgbImportacao
            // 
            this.pgbImportacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pgbImportacao.Location = new System.Drawing.Point(12, 371);
            this.pgbImportacao.Name = "pgbImportacao";
            this.pgbImportacao.Size = new System.Drawing.Size(653, 14);
            this.pgbImportacao.TabIndex = 24;
            // 
            // txtArquivo
            // 
            this.txtArquivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtArquivo.Location = new System.Drawing.Point(12, 345);
            this.txtArquivo.Name = "txtArquivo";
            this.txtArquivo.ReadOnly = true;
            this.txtArquivo.Size = new System.Drawing.Size(653, 20);
            this.txtArquivo.TabIndex = 23;
            // 
            // grpNfe
            // 
            this.grpNfe.Controls.Add(this.pctNfe);
            this.grpNfe.Location = new System.Drawing.Point(4, 4);
            this.grpNfe.Name = "grpNfe";
            this.grpNfe.Size = new System.Drawing.Size(532, 333);
            this.grpNfe.TabIndex = 29;
            this.grpNfe.TabStop = false;
            this.grpNfe.Text = "NFe";
            // 
            // pctNfe
            // 
            this.pctNfe.Image = global::SID_Telecred.Properties.Resources.document_delete;
            this.pctNfe.Location = new System.Drawing.Point(8, 19);
            this.pctNfe.Name = "pctNfe";
            this.pctNfe.Size = new System.Drawing.Size(518, 304);
            this.pctNfe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctNfe.TabIndex = 30;
            this.pctNfe.TabStop = false;
            // 
            // webNotaFiscal
            // 
            this.webNotaFiscal.Location = new System.Drawing.Point(542, 379);
            this.webNotaFiscal.MinimumSize = new System.Drawing.Size(20, 20);
            this.webNotaFiscal.Name = "webNotaFiscal";
            this.webNotaFiscal.Size = new System.Drawing.Size(123, 375);
            this.webNotaFiscal.TabIndex = 31;
            this.webNotaFiscal.Visible = false;
            this.webNotaFiscal.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WebNotaFiscal_DocumentCompleted);
            // 
            // ofdArquivo
            // 
            this.ofdArquivo.Filter = "Arquivos Texto|*.csv;*.txt|Todos Arquivos|*.*";
            // 
            // lblQtde
            // 
            this.lblQtde.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtde.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblQtde.Location = new System.Drawing.Point(542, 296);
            this.lblQtde.Name = "lblQtde";
            this.lblQtde.Size = new System.Drawing.Size(123, 41);
            this.lblQtde.TabIndex = 44;
            this.lblQtde.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(556, 280);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "Analisando NFe";
            // 
            // chkVisualizar
            // 
            this.chkVisualizar.AutoSize = true;
            this.chkVisualizar.Checked = true;
            this.chkVisualizar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVisualizar.Location = new System.Drawing.Point(548, 356);
            this.chkVisualizar.Name = "chkVisualizar";
            this.chkVisualizar.Size = new System.Drawing.Size(93, 17);
            this.chkVisualizar.TabIndex = 45;
            this.chkVisualizar.Text = "Visualizar NFe";
            this.chkVisualizar.UseVisualStyleBackColor = true;
            this.chkVisualizar.Visible = false;
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnFechar.Image = global::SID_Telecred.Properties.Resources.delete;
            this.btnFechar.Location = new System.Drawing.Point(541, 213);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(126, 59);
            this.btnFechar.TabIndex = 27;
            this.btnFechar.Text = "&Cancelar";
            this.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.BtnFechar_Click);
            // 
            // btnLimparCampos
            // 
            this.btnLimparCampos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimparCampos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimparCampos.Image = global::SID_Telecred.Properties.Resources.Eraser;
            this.btnLimparCampos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimparCampos.Location = new System.Drawing.Point(541, 147);
            this.btnLimparCampos.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimparCampos.Name = "btnLimparCampos";
            this.btnLimparCampos.Size = new System.Drawing.Size(126, 59);
            this.btnLimparCampos.TabIndex = 26;
            this.btnLimparCampos.Text = "&Limpar Campos";
            this.btnLimparCampos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimparCampos.UseVisualStyleBackColor = true;
            this.btnLimparCampos.Click += new System.EventHandler(this.BtnLimparCampos_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportar.Image = global::SID_Telecred.Properties.Resources.TableReplace;
            this.btnImportar.Location = new System.Drawing.Point(541, 80);
            this.btnImportar.Margin = new System.Windows.Forms.Padding(4);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(126, 59);
            this.btnImportar.TabIndex = 28;
            this.btnImportar.Text = "&Verificar NFe";
            this.btnImportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.BtnImportar_Click);
            // 
            // btnAbrirArquivo
            // 
            this.btnAbrirArquivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbrirArquivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirArquivo.Image = global::SID_Telecred.Properties.Resources.Folder;
            this.btnAbrirArquivo.Location = new System.Drawing.Point(541, 13);
            this.btnAbrirArquivo.Margin = new System.Windows.Forms.Padding(4);
            this.btnAbrirArquivo.Name = "btnAbrirArquivo";
            this.btnAbrirArquivo.Size = new System.Drawing.Size(126, 59);
            this.btnAbrirArquivo.TabIndex = 22;
            this.btnAbrirArquivo.Text = "&Abrir Arquivo";
            this.btnAbrirArquivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAbrirArquivo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAbrirArquivo.UseVisualStyleBackColor = true;
            this.btnAbrirArquivo.Click += new System.EventHandler(this.BtnAbrirArquivo_Click);
            // 
            // frmVerificacaoNFe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 413);
            this.Controls.Add(this.lblQtde);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnLimparCampos);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.lblAndamento);
            this.Controls.Add(this.pgbImportacao);
            this.Controls.Add(this.txtArquivo);
            this.Controls.Add(this.btnAbrirArquivo);
            this.Controls.Add(this.grpNfe);
            this.Controls.Add(this.chkVisualizar);
            this.Controls.Add(this.webNotaFiscal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVerificacaoNFe";
            this.Text = "Verificar NFe";
            this.grpNfe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctNfe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAndamento;
        private System.Windows.Forms.ProgressBar pgbImportacao;
        private System.Windows.Forms.TextBox txtArquivo;
        private System.Windows.Forms.Button btnAbrirArquivo;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnLimparCampos;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.GroupBox grpNfe;
        private System.Windows.Forms.PictureBox pctNfe;
        private System.Windows.Forms.WebBrowser webNotaFiscal;
        private System.Windows.Forms.OpenFileDialog ofdArquivo;
        private System.Windows.Forms.Label lblQtde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkVisualizar;
    }
}