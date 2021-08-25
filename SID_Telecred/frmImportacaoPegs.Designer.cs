namespace SID_Telecred
{
    partial class frmImportacaoPegs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportacaoPegs));
            this.ofdArquivo = new System.Windows.Forms.OpenFileDialog();
            this.grdImportacao = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtArquivo = new System.Windows.Forms.TextBox();
            this.pgbImportacao = new System.Windows.Forms.ProgressBar();
            this.lblAndamento = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnLimparCampos = new System.Windows.Forms.Button();
            this.btnImportar = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdImportacao)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdArquivo
            // 
            this.ofdArquivo.FileName = "*.xlsx";
            this.ofdArquivo.Filter = "Arquivos Excel|*.xlsx;*.xls|Todos Arquivos|*.*";
            // 
            // grdImportacao
            // 
            this.grdImportacao.AllowUserToAddRows = false;
            this.grdImportacao.AllowUserToDeleteRows = false;
            this.grdImportacao.AllowUserToResizeColumns = false;
            this.grdImportacao.AllowUserToResizeRows = false;
            this.grdImportacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdImportacao.Location = new System.Drawing.Point(6, 19);
            this.grdImportacao.MultiSelect = false;
            this.grdImportacao.Name = "grdImportacao";
            this.grdImportacao.ReadOnly = true;
            this.grdImportacao.RowHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.grdImportacao.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdImportacao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdImportacao.Size = new System.Drawing.Size(1148, 406);
            this.grdImportacao.TabIndex = 17;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdImportacao);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1160, 431);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Histórico de Importações";
            // 
            // txtArquivo
            // 
            this.txtArquivo.Location = new System.Drawing.Point(12, 450);
            this.txtArquivo.Name = "txtArquivo";
            this.txtArquivo.ReadOnly = true;
            this.txtArquivo.Size = new System.Drawing.Size(653, 20);
            this.txtArquivo.TabIndex = 19;
            // 
            // pgbImportacao
            // 
            this.pgbImportacao.Location = new System.Drawing.Point(12, 476);
            this.pgbImportacao.Name = "pgbImportacao";
            this.pgbImportacao.Size = new System.Drawing.Size(653, 14);
            this.pgbImportacao.TabIndex = 20;
            // 
            // lblAndamento
            // 
            this.lblAndamento.Location = new System.Drawing.Point(15, 493);
            this.lblAndamento.Name = "lblAndamento";
            this.lblAndamento.Size = new System.Drawing.Size(650, 16);
            this.lblAndamento.TabIndex = 21;
            this.lblAndamento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFechar
            // 
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnFechar.Image = global::SID_Telecred.Properties.Resources.delete;
            this.btnFechar.Location = new System.Drawing.Point(1070, 450);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(102, 59);
            this.btnFechar.TabIndex = 15;
            this.btnFechar.Text = "&Cancelar";
            this.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnLimparCampos
            // 
            this.btnLimparCampos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimparCampos.Image = global::SID_Telecred.Properties.Resources.Eraser;
            this.btnLimparCampos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimparCampos.Location = new System.Drawing.Point(938, 450);
            this.btnLimparCampos.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimparCampos.Name = "btnLimparCampos";
            this.btnLimparCampos.Size = new System.Drawing.Size(126, 59);
            this.btnLimparCampos.TabIndex = 14;
            this.btnLimparCampos.Text = "&Limpar Campos";
            this.btnLimparCampos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimparCampos.UseVisualStyleBackColor = true;
            this.btnLimparCampos.Click += new System.EventHandler(this.btnLimparCampos_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportar.Image = global::SID_Telecred.Properties.Resources.TableReplace;
            this.btnImportar.Location = new System.Drawing.Point(805, 450);
            this.btnImportar.Margin = new System.Windows.Forms.Padding(4);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(126, 59);
            this.btnImportar.TabIndex = 16;
            this.btnImportar.Text = "&Importar Dados";
            this.btnImportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = global::SID_Telecred.Properties.Resources.Folder;
            this.btnAdd.Location = new System.Drawing.Point(672, 450);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(126, 59);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "&Abrir Arquivo";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmImportacaoPegs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 515);
            this.Controls.Add(this.lblAndamento);
            this.Controls.Add(this.pgbImportacao);
            this.Controls.Add(this.txtArquivo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnLimparCampos);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImportacaoPegs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importação Pegs Portal";
            this.Load += new System.EventHandler(this.frmImportacaoPegs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdImportacao)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnLimparCampos;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.OpenFileDialog ofdArquivo;
        private System.Windows.Forms.DataGridView grdImportacao;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtArquivo;
        private System.Windows.Forms.ProgressBar pgbImportacao;
        private System.Windows.Forms.Label lblAndamento;
    }
}