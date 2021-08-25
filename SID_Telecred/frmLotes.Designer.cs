namespace SID_Telecred
{
    partial class frmLotes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLotes));
            this.txtLote = new System.Windows.Forms.TextBox();
            this.lblLote = new System.Windows.Forms.Label();
            this.grpLotes = new System.Windows.Forms.GroupBox();
            this.grdLotes = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.grpImagens = new System.Windows.Forms.GroupBox();
            this.lstImagens = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboServico = new System.Windows.Forms.ComboBox();
            this.fbdImagens = new System.Windows.Forms.FolderBrowserDialog();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnCarregar = new System.Windows.Forms.Button();
            this.grpLotes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLotes)).BeginInit();
            this.grpImagens.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLote
            // 
            this.txtLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtLote.Location = new System.Drawing.Point(316, 44);
            this.txtLote.MaxLength = 20;
            this.txtLote.Name = "txtLote";
            this.txtLote.Size = new System.Drawing.Size(140, 22);
            this.txtLote.TabIndex = 12;
            this.txtLote.TabStop = false;
            this.txtLote.Leave += new System.EventHandler(this.txtLote_Leave);
            // 
            // lblLote
            // 
            this.lblLote.AutoSize = true;
            this.lblLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblLote.Location = new System.Drawing.Point(271, 47);
            this.lblLote.Name = "lblLote";
            this.lblLote.Size = new System.Drawing.Size(34, 16);
            this.lblLote.TabIndex = 11;
            this.lblLote.Text = "Lote";
            this.lblLote.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpLotes
            // 
            this.grpLotes.Controls.Add(this.grdLotes);
            this.grpLotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.grpLotes.Location = new System.Drawing.Point(12, 12);
            this.grpLotes.Name = "grpLotes";
            this.grpLotes.Size = new System.Drawing.Size(245, 401);
            this.grpLotes.TabIndex = 13;
            this.grpLotes.TabStop = false;
            this.grpLotes.Text = "Lotes Cadastrados";
            // 
            // grdLotes
            // 
            this.grdLotes.AllowUserToAddRows = false;
            this.grdLotes.AllowUserToDeleteRows = false;
            this.grdLotes.AllowUserToResizeColumns = false;
            this.grdLotes.AllowUserToResizeRows = false;
            this.grdLotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdLotes.DefaultCellStyle = dataGridViewCellStyle1;
            this.grdLotes.Location = new System.Drawing.Point(6, 25);
            this.grdLotes.MultiSelect = false;
            this.grdLotes.Name = "grdLotes";
            this.grdLotes.ReadOnly = true;
            this.grdLotes.RowHeadersVisible = false;
            this.grdLotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdLotes.Size = new System.Drawing.Size(233, 369);
            this.grdLotes.TabIndex = 0;
            this.grdLotes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdLotes_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.Location = new System.Drawing.Point(271, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Total Imagens";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtTotal.Location = new System.Drawing.Point(380, 76);
            this.txtTotal.MaxLength = 20;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(76, 22);
            this.txtTotal.TabIndex = 16;
            this.txtTotal.TabStop = false;
            // 
            // grpImagens
            // 
            this.grpImagens.Controls.Add(this.lstImagens);
            this.grpImagens.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.grpImagens.Location = new System.Drawing.Point(263, 108);
            this.grpImagens.Name = "grpImagens";
            this.grpImagens.Size = new System.Drawing.Size(338, 305);
            this.grpImagens.TabIndex = 21;
            this.grpImagens.TabStop = false;
            this.grpImagens.Text = "Imagens Carregadas";
            // 
            // lstImagens
            // 
            this.lstImagens.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lstImagens.FormattingEnabled = true;
            this.lstImagens.ItemHeight = 16;
            this.lstImagens.Location = new System.Drawing.Point(6, 22);
            this.lstImagens.Name = "lstImagens";
            this.lstImagens.Size = new System.Drawing.Size(326, 276);
            this.lstImagens.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.Location = new System.Drawing.Point(268, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "Serviço";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboServico
            // 
            this.cboServico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboServico.FormattingEnabled = true;
            this.cboServico.Location = new System.Drawing.Point(328, 12);
            this.cboServico.Name = "cboServico";
            this.cboServico.Size = new System.Drawing.Size(275, 24);
            this.cboServico.TabIndex = 24;
            this.cboServico.SelectedIndexChanged += new System.EventHandler(this.cboServico_SelectedIndexChanged);
            // 
            // btnFechar
            // 
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnFechar.Image = global::SID_Telecred.Properties.Resources.delete;
            this.btnFechar.Location = new System.Drawing.Point(235, 419);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(141, 40);
            this.btnFechar.TabIndex = 20;
            this.btnFechar.Text = "Cancelar";
            this.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnLimpar.Image = global::SID_Telecred.Properties.Resources.Eraser;
            this.btnLimpar.Location = new System.Drawing.Point(12, 419);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(141, 40);
            this.btnLimpar.TabIndex = 19;
            this.btnLimpar.Text = "Limpar Campos";
            this.btnLimpar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnGravar
            // 
            this.btnGravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnGravar.Image = global::SID_Telecred.Properties.Resources.FloppyDisks;
            this.btnGravar.Location = new System.Drawing.Point(460, 419);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(141, 40);
            this.btnGravar.TabIndex = 17;
            this.btnGravar.Text = "Gravar Lote";
            this.btnGravar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnCarregar
            // 
            this.btnCarregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnCarregar.Image = global::SID_Telecred.Properties.Resources.Image;
            this.btnCarregar.Location = new System.Drawing.Point(462, 51);
            this.btnCarregar.Name = "btnCarregar";
            this.btnCarregar.Size = new System.Drawing.Size(141, 40);
            this.btnCarregar.TabIndex = 14;
            this.btnCarregar.Text = "Carregar Imagens";
            this.btnCarregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCarregar.UseVisualStyleBackColor = true;
            this.btnCarregar.Click += new System.EventHandler(this.btnCarregar_Click);
            // 
            // frmLotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 470);
            this.Controls.Add(this.cboServico);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grpImagens);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCarregar);
            this.Controls.Add(this.grpLotes);
            this.Controls.Add(this.txtLote);
            this.Controls.Add(this.lblLote);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLotes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Lotes";
            this.Load += new System.EventHandler(this.frmLotes_Load);
            this.grpLotes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLotes)).EndInit();
            this.grpImagens.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLote;
        private System.Windows.Forms.Label lblLote;
        private System.Windows.Forms.GroupBox grpLotes;
        private System.Windows.Forms.DataGridView grdLotes;
        private System.Windows.Forms.Button btnCarregar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.GroupBox grpImagens;
        private System.Windows.Forms.ListBox lstImagens;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboServico;
        private System.Windows.Forms.FolderBrowserDialog fbdImagens;
    }
}