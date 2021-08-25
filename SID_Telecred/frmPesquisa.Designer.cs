namespace SID_Telecred
{
    partial class frmPesquisa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPesquisa));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkLike = new System.Windows.Forms.CheckBox();
            this.cboCampo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grdPesquisa = new System.Windows.Forms.DataGridView();
            this.txtTabela = new System.Windows.Forms.TextBox();
            this.txtCampos = new System.Windows.Forms.TextBox();
            this.txtCampoBusca = new System.Windows.Forms.TextBox();
            this.txtCampoRetorno = new System.Windows.Forms.TextBox();
            this.txtAssunto = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSelecionar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPesquisa)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkLike);
            this.groupBox1.Controls.Add(this.cboCampo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPesquisa);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.grdPesquisa);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(612, 343);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados de Pesquisa";
            // 
            // chkLike
            // 
            this.chkLike.AutoSize = true;
            this.chkLike.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkLike.Location = new System.Drawing.Point(325, 28);
            this.chkLike.Name = "chkLike";
            this.chkLike.Size = new System.Drawing.Size(73, 20);
            this.chkLike.TabIndex = 1;
            this.chkLike.Text = "Contém";
            this.chkLike.UseVisualStyleBackColor = true;
            this.chkLike.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkLike_KeyDown);
            // 
            // cboCampo
            // 
            this.cboCampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCampo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboCampo.FormattingEnabled = true;
            this.cboCampo.Location = new System.Drawing.Point(464, 26);
            this.cboCampo.Name = "cboCampo";
            this.cboCampo.Size = new System.Drawing.Size(130, 24);
            this.cboCampo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.Location = new System.Drawing.Point(407, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Campo";
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtPesquisa.Location = new System.Drawing.Point(88, 26);
            this.txtPesquisa.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(225, 22);
            this.txtPesquisa.TabIndex = 0;
            this.txtPesquisa.TextChanged += new System.EventHandler(this.txtPesquisa_TextChanged);
            this.txtPesquisa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPesquisa_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.Location = new System.Drawing.Point(15, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Pesquisar";
            // 
            // grdPesquisa
            // 
            this.grdPesquisa.AllowUserToAddRows = false;
            this.grdPesquisa.AllowUserToDeleteRows = false;
            this.grdPesquisa.AllowUserToResizeColumns = false;
            this.grdPesquisa.AllowUserToResizeRows = false;
            this.grdPesquisa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdPesquisa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPesquisa.Location = new System.Drawing.Point(5, 59);
            this.grdPesquisa.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.grdPesquisa.MultiSelect = false;
            this.grdPesquisa.Name = "grdPesquisa";
            this.grdPesquisa.ReadOnly = true;
            this.grdPesquisa.RowHeadersVisible = false;
            this.grdPesquisa.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.grdPesquisa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPesquisa.Size = new System.Drawing.Size(602, 278);
            this.grdPesquisa.TabIndex = 2;
            this.grdPesquisa.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPesquisa_CellDoubleClick);
            this.grdPesquisa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdPesquisa_KeyDown);
            // 
            // txtTabela
            // 
            this.txtTabela.Location = new System.Drawing.Point(158, 382);
            this.txtTabela.Name = "txtTabela";
            this.txtTabela.Size = new System.Drawing.Size(100, 20);
            this.txtTabela.TabIndex = 15;
            this.txtTabela.Text = "Tabela";
            this.txtTabela.Visible = false;
            // 
            // txtCampos
            // 
            this.txtCampos.Location = new System.Drawing.Point(264, 382);
            this.txtCampos.Name = "txtCampos";
            this.txtCampos.Size = new System.Drawing.Size(100, 20);
            this.txtCampos.TabIndex = 16;
            this.txtCampos.Text = "Campos Select";
            this.txtCampos.Visible = false;
            // 
            // txtCampoBusca
            // 
            this.txtCampoBusca.Location = new System.Drawing.Point(370, 382);
            this.txtCampoBusca.Name = "txtCampoBusca";
            this.txtCampoBusca.Size = new System.Drawing.Size(100, 20);
            this.txtCampoBusca.TabIndex = 17;
            this.txtCampoBusca.Text = "Campo Busca";
            this.txtCampoBusca.Visible = false;
            // 
            // txtCampoRetorno
            // 
            this.txtCampoRetorno.Location = new System.Drawing.Point(370, 356);
            this.txtCampoRetorno.Name = "txtCampoRetorno";
            this.txtCampoRetorno.Size = new System.Drawing.Size(100, 20);
            this.txtCampoRetorno.TabIndex = 18;
            this.txtCampoRetorno.Text = "Campo Retorno";
            this.txtCampoRetorno.Visible = false;
            // 
            // txtAssunto
            // 
            this.txtAssunto.Location = new System.Drawing.Point(158, 356);
            this.txtAssunto.Name = "txtAssunto";
            this.txtAssunto.Size = new System.Drawing.Size(100, 20);
            this.txtAssunto.TabIndex = 19;
            this.txtAssunto.Text = "Evento";
            this.txtAssunto.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnCancelar.Image = global::SID_Telecred.Properties.Resources.delete;
            this.btnCancelar.Location = new System.Drawing.Point(11, 356);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(141, 40);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Fechar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnSelecionar.Image = global::SID_Telecred.Properties.Resources.selection_view;
            this.btnSelecionar.Location = new System.Drawing.Point(482, 356);
            this.btnSelecionar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(141, 40);
            this.btnSelecionar.TabIndex = 2;
            this.btnSelecionar.Text = "Selecionar";
            this.btnSelecionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelecionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelecionar.UseVisualStyleBackColor = true;
            this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionar_Click);
            // 
            // frmPesquisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(630, 403);
            this.Controls.Add(this.txtAssunto);
            this.Controls.Add(this.txtCampoRetorno);
            this.Controls.Add(this.txtCampoBusca);
            this.Controls.Add(this.txtCampos);
            this.Controls.Add(this.txtTabela);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSelecionar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPesquisa";
            this.Text = "Reembolso - Pesquisa";
            this.Load += new System.EventHandler(this.frmPesquisa_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPesquisa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grdPesquisa;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSelecionar;
        public System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtTabela;
        public System.Windows.Forms.TextBox txtCampos;
        public System.Windows.Forms.TextBox txtCampoBusca;
        public System.Windows.Forms.TextBox txtCampoRetorno;
        private System.Windows.Forms.ComboBox cboCampo;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.CheckBox chkLike;
        public System.Windows.Forms.TextBox txtAssunto;
    }
}