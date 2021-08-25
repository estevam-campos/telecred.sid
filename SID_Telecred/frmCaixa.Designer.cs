namespace SID_Telecred
{
    partial class frmCaixa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCaixa));
            this.label1 = new System.Windows.Forms.Label();
            this.cboServico = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCaixa = new System.Windows.Forms.TextBox();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.grdCaixas = new System.Windows.Forms.DataGridView();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnRemoverCaixa = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQtde = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdCaixas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 54;
            this.label1.Text = "Caixa";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboServico
            // 
            this.cboServico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboServico.FormattingEnabled = true;
            this.cboServico.Location = new System.Drawing.Point(79, 12);
            this.cboServico.Name = "cboServico";
            this.cboServico.Size = new System.Drawing.Size(268, 24);
            this.cboServico.TabIndex = 51;
            this.cboServico.SelectedIndexChanged += new System.EventHandler(this.cboServico_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.Location = new System.Drawing.Point(18, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 53;
            this.label2.Text = "Serviço";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 55;
            this.label3.Text = "Empresa";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCaixa
            // 
            this.txtCaixa.Location = new System.Drawing.Point(79, 44);
            this.txtCaixa.Name = "txtCaixa";
            this.txtCaixa.Size = new System.Drawing.Size(114, 20);
            this.txtCaixa.TabIndex = 56;
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.Location = new System.Drawing.Point(79, 75);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Size = new System.Drawing.Size(221, 20);
            this.txtEmpresa.TabIndex = 57;
            // 
            // grdCaixas
            // 
            this.grdCaixas.AllowUserToAddRows = false;
            this.grdCaixas.AllowUserToDeleteRows = false;
            this.grdCaixas.AllowUserToResizeColumns = false;
            this.grdCaixas.AllowUserToResizeRows = false;
            this.grdCaixas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCaixas.Location = new System.Drawing.Point(12, 101);
            this.grdCaixas.Name = "grdCaixas";
            this.grdCaixas.ReadOnly = true;
            this.grdCaixas.RowHeadersVisible = false;
            this.grdCaixas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdCaixas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCaixas.Size = new System.Drawing.Size(335, 262);
            this.grdCaixas.TabIndex = 58;
            this.grdCaixas.TabStop = false;
            this.grdCaixas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCaixas_CellClick);
            // 
            // btnFechar
            // 
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnFechar.Image = global::SID_Telecred.Properties.Resources.delete;
            this.btnFechar.Location = new System.Drawing.Point(12, 369);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(141, 40);
            this.btnFechar.TabIndex = 59;
            this.btnFechar.Text = "&Cancelar";
            this.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnGravar
            // 
            this.btnGravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnGravar.Image = global::SID_Telecred.Properties.Resources.FloppyDisks;
            this.btnGravar.Location = new System.Drawing.Point(206, 369);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(141, 40);
            this.btnGravar.TabIndex = 60;
            this.btnGravar.Text = "&Gravar";
            this.btnGravar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpar.Image")));
            this.btnLimpar.Location = new System.Drawing.Point(306, 44);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(41, 51);
            this.btnLimpar.TabIndex = 61;
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnRemoverCaixa
            // 
            this.btnRemoverCaixa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoverCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnRemoverCaixa.Image = global::SID_Telecred.Properties.Resources.MetapackageRem;
            this.btnRemoverCaixa.Location = new System.Drawing.Point(160, 369);
            this.btnRemoverCaixa.Name = "btnRemoverCaixa";
            this.btnRemoverCaixa.Size = new System.Drawing.Size(40, 40);
            this.btnRemoverCaixa.TabIndex = 62;
            this.btnRemoverCaixa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRemoverCaixa.UseVisualStyleBackColor = true;
            this.btnRemoverCaixa.Click += new System.EventHandler(this.btnRemoverCaixa_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(200, 45);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 63;
            this.label4.Text = "Imagens";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtQtde
            // 
            this.txtQtde.Location = new System.Drawing.Point(267, 44);
            this.txtQtde.Name = "txtQtde";
            this.txtQtde.ReadOnly = true;
            this.txtQtde.Size = new System.Drawing.Size(33, 20);
            this.txtQtde.TabIndex = 64;
            this.txtQtde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 421);
            this.Controls.Add(this.txtQtde);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnRemoverCaixa);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.grdCaixas);
            this.Controls.Add(this.txtEmpresa);
            this.Controls.Add(this.txtCaixa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboServico);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCaixa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Caixas";
            this.Load += new System.EventHandler(this.frmCaixa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdCaixas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboServico;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCaixa;
        private System.Windows.Forms.TextBox txtEmpresa;
        private System.Windows.Forms.DataGridView grdCaixas;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnRemoverCaixa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQtde;
    }
}