namespace SID_Telecred
{
    partial class frmMigracaoPegPortal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMigracaoPegPortal));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdPegs = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFim = new System.Windows.Forms.DateTimePicker();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.btnMigrar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.sfdArquivo = new System.Windows.Forms.SaveFileDialog();
            this.lblAndamento = new System.Windows.Forms.Label();
            this.pgbProgress = new System.Windows.Forms.ProgressBar();
            this.txtArquivo = new System.Windows.Forms.TextBox();
            this.txtTratativa = new System.Windows.Forms.TextBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPegs)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdPegs);
            this.groupBox1.Location = new System.Drawing.Point(10, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(720, 332);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Digitação Pegs";
            // 
            // grdPegs
            // 
            this.grdPegs.AllowUserToAddRows = false;
            this.grdPegs.AllowUserToDeleteRows = false;
            this.grdPegs.AllowUserToResizeColumns = false;
            this.grdPegs.AllowUserToResizeRows = false;
            this.grdPegs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdPegs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPegs.Location = new System.Drawing.Point(6, 19);
            this.grdPegs.MultiSelect = false;
            this.grdPegs.Name = "grdPegs";
            this.grdPegs.ReadOnly = true;
            this.grdPegs.RowHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.grdPegs.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdPegs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdPegs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPegs.Size = new System.Drawing.Size(703, 306);
            this.grdPegs.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Período de";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "até";
            // 
            // dtpFim
            // 
            this.dtpFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFim.Location = new System.Drawing.Point(201, 17);
            this.dtpFim.Name = "dtpFim";
            this.dtpFim.Size = new System.Drawing.Size(85, 20);
            this.dtpFim.TabIndex = 33;
            this.dtpFim.ValueChanged += new System.EventHandler(this.dtpFim_ValueChanged);
            // 
            // dtpInicio
            // 
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(82, 17);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(85, 20);
            this.dtpInicio.TabIndex = 32;
            this.dtpInicio.ValueChanged += new System.EventHandler(this.dtpInicio_ValueChanged);
            // 
            // btnMigrar
            // 
            this.btnMigrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnMigrar.Image = global::SID_Telecred.Properties.Resources.DocumentInto;
            this.btnMigrar.Location = new System.Drawing.Point(10, 384);
            this.btnMigrar.Name = "btnMigrar";
            this.btnMigrar.Size = new System.Drawing.Size(141, 40);
            this.btnMigrar.TabIndex = 30;
            this.btnMigrar.Text = "&Migrar";
            this.btnMigrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMigrar.UseVisualStyleBackColor = true;
            this.btnMigrar.Click += new System.EventHandler(this.btnMigrar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnFechar.Image = global::SID_Telecred.Properties.Resources.delete;
            this.btnFechar.Location = new System.Drawing.Point(10, 430);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(141, 40);
            this.btnFechar.TabIndex = 29;
            this.btnFechar.Text = "&Cancelar";
            this.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // sfdArquivo
            // 
            this.sfdArquivo.FileName = "*.csv";
            this.sfdArquivo.Filter = "Arquivos csv|*.csv";
            // 
            // lblAndamento
            // 
            this.lblAndamento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAndamento.Location = new System.Drawing.Point(159, 455);
            this.lblAndamento.Name = "lblAndamento";
            this.lblAndamento.Size = new System.Drawing.Size(571, 16);
            this.lblAndamento.TabIndex = 38;
            this.lblAndamento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pgbProgress
            // 
            this.pgbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pgbProgress.Location = new System.Drawing.Point(156, 438);
            this.pgbProgress.Name = "pgbProgress";
            this.pgbProgress.Size = new System.Drawing.Size(574, 14);
            this.pgbProgress.TabIndex = 37;
            // 
            // txtArquivo
            // 
            this.txtArquivo.Location = new System.Drawing.Point(156, 387);
            this.txtArquivo.Name = "txtArquivo";
            this.txtArquivo.ReadOnly = true;
            this.txtArquivo.Size = new System.Drawing.Size(574, 20);
            this.txtArquivo.TabIndex = 36;
            // 
            // txtTratativa
            // 
            this.txtTratativa.Location = new System.Drawing.Point(156, 412);
            this.txtTratativa.Name = "txtTratativa";
            this.txtTratativa.ReadOnly = true;
            this.txtTratativa.Size = new System.Drawing.Size(574, 20);
            this.txtTratativa.TabIndex = 39;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnPesquisar.Image = global::SID_Telecred.Properties.Resources.DocumentRefresh;
            this.btnPesquisar.Location = new System.Drawing.Point(307, 7);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(141, 40);
            this.btnPesquisar.TabIndex = 40;
            this.btnPesquisar.Text = "&Atualizar";
            this.btnPesquisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // frmMigracaoPegPortal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 476);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.txtTratativa);
            this.Controls.Add(this.lblAndamento);
            this.Controls.Add(this.pgbProgress);
            this.Controls.Add(this.txtArquivo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFim);
            this.Controls.Add(this.dtpInicio);
            this.Controls.Add(this.btnMigrar);
            this.Controls.Add(this.btnFechar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMigracaoPegPortal";
            this.Text = "Migração Pegs Portal";
            this.Load += new System.EventHandler(this.frmMigracaoPegPortal_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPegs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grdPegs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFim;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Button btnMigrar;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.SaveFileDialog sfdArquivo;
        private System.Windows.Forms.Label lblAndamento;
        private System.Windows.Forms.ProgressBar pgbProgress;
        private System.Windows.Forms.TextBox txtArquivo;
        private System.Windows.Forms.TextBox txtTratativa;
        private System.Windows.Forms.Button btnPesquisar;
    }
}