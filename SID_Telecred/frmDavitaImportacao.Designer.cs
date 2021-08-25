namespace SID_Telecred
{
    partial class frmDavitaImportacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDavitaImportacao));
            this.ofdArquivo = new System.Windows.Forms.OpenFileDialog();
            this.lblAndamento = new System.Windows.Forms.Label();
            this.pgbImportacao = new System.Windows.Forms.ProgressBar();
            this.tabPlanilha = new System.Windows.Forms.TabControl();
            this.pgbPlanilhas = new System.Windows.Forms.ProgressBar();
            this.lblPlanilhas = new System.Windows.Forms.Label();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.btnRemoverAba = new System.Windows.Forms.Button();
            this.btnLote = new System.Windows.Forms.Button();
            this.btnCarregarPlanilha = new System.Windows.Forms.Button();
            this.btnReplicar = new System.Windows.Forms.Button();
            this.btnRemItem = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnDefinirCabecalho = new System.Windows.Forms.Button();
            this.btnProcessar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkCabecalho = new System.Windows.Forms.CheckBox();
            this.chkLote = new System.Windows.Forms.CheckBox();
            this.fbdDavita = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdArquivo
            // 
            this.ofdArquivo.Filter = "Arquivos Excel|*.xlsx;*.xls|Todos Arquivos|*.*";
            // 
            // lblAndamento
            // 
            this.lblAndamento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAndamento.Location = new System.Drawing.Point(12, 563);
            this.lblAndamento.Name = "lblAndamento";
            this.lblAndamento.Size = new System.Drawing.Size(487, 16);
            this.lblAndamento.TabIndex = 25;
            this.lblAndamento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pgbImportacao
            // 
            this.pgbImportacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pgbImportacao.Location = new System.Drawing.Point(12, 534);
            this.pgbImportacao.Name = "pgbImportacao";
            this.pgbImportacao.Size = new System.Drawing.Size(487, 22);
            this.pgbImportacao.TabIndex = 24;
            this.pgbImportacao.Visible = false;
            // 
            // tabPlanilha
            // 
            this.tabPlanilha.Location = new System.Drawing.Point(15, 13);
            this.tabPlanilha.Name = "tabPlanilha";
            this.tabPlanilha.SelectedIndex = 0;
            this.tabPlanilha.Size = new System.Drawing.Size(1103, 478);
            this.tabPlanilha.TabIndex = 26;
            this.tabPlanilha.Visible = false;
            this.tabPlanilha.SelectedIndexChanged += new System.EventHandler(this.tabPlanilha_SelectedIndexChanged);
            // 
            // pgbPlanilhas
            // 
            this.pgbPlanilhas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pgbPlanilhas.Location = new System.Drawing.Point(12, 506);
            this.pgbPlanilhas.Name = "pgbPlanilhas";
            this.pgbPlanilhas.Size = new System.Drawing.Size(487, 22);
            this.pgbPlanilhas.TabIndex = 29;
            this.pgbPlanilhas.Visible = false;
            // 
            // lblPlanilhas
            // 
            this.lblPlanilhas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPlanilhas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblPlanilhas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPlanilhas.Location = new System.Drawing.Point(505, 511);
            this.lblPlanilhas.Name = "lblPlanilhas";
            this.lblPlanilhas.Size = new System.Drawing.Size(83, 13);
            this.lblPlanilhas.TabIndex = 31;
            this.lblPlanilhas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPlanilhas.Visible = false;
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblRegistros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblRegistros.Location = new System.Drawing.Point(505, 538);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(83, 13);
            this.lblRegistros.TabIndex = 32;
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRegistros.Visible = false;
            // 
            // btnRemoverAba
            // 
            this.btnRemoverAba.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoverAba.Enabled = false;
            this.btnRemoverAba.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnRemoverAba.Image = global::SID_Telecred.Properties.Resources.table2_delete1;
            this.btnRemoverAba.Location = new System.Drawing.Point(728, 543);
            this.btnRemoverAba.Name = "btnRemoverAba";
            this.btnRemoverAba.Size = new System.Drawing.Size(126, 40);
            this.btnRemoverAba.TabIndex = 38;
            this.btnRemoverAba.Text = "&Remover Aba";
            this.btnRemoverAba.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRemoverAba.UseVisualStyleBackColor = true;
            this.btnRemoverAba.Click += new System.EventHandler(this.btnRemoverAba_Click);
            // 
            // btnLote
            // 
            this.btnLote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLote.Enabled = false;
            this.btnLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnLote.Image = global::SID_Telecred.Properties.Resources.table_row_add_before;
            this.btnLote.Location = new System.Drawing.Point(860, 497);
            this.btnLote.Name = "btnLote";
            this.btnLote.Size = new System.Drawing.Size(126, 40);
            this.btnLote.TabIndex = 37;
            this.btnLote.Text = "&Definir Unidade";
            this.btnLote.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLote.UseVisualStyleBackColor = true;
            this.btnLote.Click += new System.EventHandler(this.btnLote_Click);
            // 
            // btnCarregarPlanilha
            // 
            this.btnCarregarPlanilha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCarregarPlanilha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnCarregarPlanilha.Image = global::SID_Telecred.Properties.Resources.Excel;
            this.btnCarregarPlanilha.Location = new System.Drawing.Point(728, 497);
            this.btnCarregarPlanilha.Name = "btnCarregarPlanilha";
            this.btnCarregarPlanilha.Size = new System.Drawing.Size(126, 40);
            this.btnCarregarPlanilha.TabIndex = 1;
            this.btnCarregarPlanilha.Text = "&Carregar Planilha";
            this.btnCarregarPlanilha.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCarregarPlanilha.UseVisualStyleBackColor = true;
            this.btnCarregarPlanilha.Click += new System.EventHandler(this.btnCarregarPlanilha_Click);
            // 
            // btnReplicar
            // 
            this.btnReplicar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnReplicar.Image = global::SID_Telecred.Properties.Resources.preferences;
            this.btnReplicar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReplicar.Location = new System.Drawing.Point(937, 442);
            this.btnReplicar.Name = "btnReplicar";
            this.btnReplicar.Size = new System.Drawing.Size(126, 40);
            this.btnReplicar.TabIndex = 36;
            this.btnReplicar.Text = "&Replicar Associação";
            this.btnReplicar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReplicar.UseVisualStyleBackColor = true;
            this.btnReplicar.Visible = false;
            this.btnReplicar.Click += new System.EventHandler(this.btnReplicar_Click);
            // 
            // btnRemItem
            // 
            this.btnRemItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnRemItem.Image = global::SID_Telecred.Properties.Resources.delete;
            this.btnRemItem.Location = new System.Drawing.Point(1069, 442);
            this.btnRemItem.Name = "btnRemItem";
            this.btnRemItem.Size = new System.Drawing.Size(40, 40);
            this.btnRemItem.TabIndex = 35;
            this.btnRemItem.UseVisualStyleBackColor = true;
            this.btnRemItem.Visible = false;
            this.btnRemItem.Click += new System.EventHandler(this.btnRemItem_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnAddItem.Image = global::SID_Telecred.Properties.Resources.Add;
            this.btnAddItem.Location = new System.Drawing.Point(1069, 220);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(40, 40);
            this.btnAddItem.TabIndex = 34;
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Visible = false;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnDefinirCabecalho
            // 
            this.btnDefinirCabecalho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDefinirCabecalho.Enabled = false;
            this.btnDefinirCabecalho.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnDefinirCabecalho.Image = global::SID_Telecred.Properties.Resources.table_row_add_before;
            this.btnDefinirCabecalho.Location = new System.Drawing.Point(860, 543);
            this.btnDefinirCabecalho.Name = "btnDefinirCabecalho";
            this.btnDefinirCabecalho.Size = new System.Drawing.Size(126, 40);
            this.btnDefinirCabecalho.TabIndex = 33;
            this.btnDefinirCabecalho.Text = "&Definir Cabeçalho";
            this.btnDefinirCabecalho.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDefinirCabecalho.UseVisualStyleBackColor = true;
            this.btnDefinirCabecalho.Click += new System.EventHandler(this.btnDefinirCabecalho_Click);
            // 
            // btnProcessar
            // 
            this.btnProcessar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnProcessar.Enabled = false;
            this.btnProcessar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnProcessar.Image = global::SID_Telecred.Properties.Resources.GearOnly;
            this.btnProcessar.Location = new System.Drawing.Point(992, 497);
            this.btnProcessar.Name = "btnProcessar";
            this.btnProcessar.Size = new System.Drawing.Size(126, 40);
            this.btnProcessar.TabIndex = 30;
            this.btnProcessar.Text = "Processar";
            this.btnProcessar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProcessar.UseVisualStyleBackColor = true;
            this.btnProcessar.Click += new System.EventHandler(this.btnProcessar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnFechar.Image = global::SID_Telecred.Properties.Resources.delete;
            this.btnFechar.Location = new System.Drawing.Point(992, 543);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(126, 40);
            this.btnFechar.TabIndex = 28;
            this.btnFechar.Text = "&Cancelar";
            this.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.BtnFechar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkCabecalho);
            this.groupBox1.Controls.Add(this.chkLote);
            this.groupBox1.Location = new System.Drawing.Point(594, 497);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(128, 86);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preferências";
            // 
            // chkCabecalho
            // 
            this.chkCabecalho.Checked = true;
            this.chkCabecalho.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCabecalho.Location = new System.Drawing.Point(5, 49);
            this.chkCabecalho.Name = "chkCabecalho";
            this.chkCabecalho.Size = new System.Drawing.Size(119, 31);
            this.chkCabecalho.TabIndex = 1;
            this.chkCabecalho.Text = "Replicar Cabeçalho para TODOS";
            this.chkCabecalho.UseVisualStyleBackColor = true;
            // 
            // chkLote
            // 
            this.chkLote.Checked = true;
            this.chkLote.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLote.Location = new System.Drawing.Point(5, 15);
            this.chkLote.Name = "chkLote";
            this.chkLote.Size = new System.Drawing.Size(116, 32);
            this.chkLote.TabIndex = 0;
            this.chkLote.Text = "Replicar Unidade para TODOS";
            this.chkLote.UseVisualStyleBackColor = true;
            // 
            // frmDavitaImportacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 591);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRemoverAba);
            this.Controls.Add(this.btnLote);
            this.Controls.Add(this.btnCarregarPlanilha);
            this.Controls.Add(this.btnReplicar);
            this.Controls.Add(this.btnRemItem);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.btnDefinirCabecalho);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.lblPlanilhas);
            this.Controls.Add(this.btnProcessar);
            this.Controls.Add(this.pgbPlanilhas);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.lblAndamento);
            this.Controls.Add(this.pgbImportacao);
            this.Controls.Add(this.tabPlanilha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDavitaImportacao";
            this.Text = "Importação Planilhas Davita";
            this.Load += new System.EventHandler(this.frmDavitaImportacao_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCarregarPlanilha;
        private System.Windows.Forms.OpenFileDialog ofdArquivo;
        private System.Windows.Forms.Label lblAndamento;
        private System.Windows.Forms.ProgressBar pgbImportacao;
        private System.Windows.Forms.TabControl tabPlanilha;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.ProgressBar pgbPlanilhas;
        private System.Windows.Forms.Button btnProcessar;
        private System.Windows.Forms.Label lblPlanilhas;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Button btnDefinirCabecalho;
        private System.Windows.Forms.Button btnRemItem;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnReplicar;
        private System.Windows.Forms.Button btnLote;
        private System.Windows.Forms.Button btnRemoverAba;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkCabecalho;
        private System.Windows.Forms.CheckBox chkLote;
        private System.Windows.Forms.FolderBrowserDialog fbdDavita;
    }
}