namespace SID_Telecred
{
    partial class frmAssociacaoCampos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAssociacaoCampos));
            this.cboServico = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboLayout = new System.Windows.Forms.ComboBox();
            this.lblBanco = new System.Windows.Forms.Label();
            this.grpServico = new System.Windows.Forms.GroupBox();
            this.lstServico = new System.Windows.Forms.ListBox();
            this.grpLayout = new System.Windows.Forms.GroupBox();
            this.lstLayout = new System.Windows.Forms.ListBox();
            this.grpAssociacao = new System.Windows.Forms.GroupBox();
            this.lstCamposAssociados = new System.Windows.Forms.ListBox();
            this.btnLimparCampos = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnAssociar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.grpServico.SuspendLayout();
            this.grpLayout.SuspendLayout();
            this.grpAssociacao.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboServico
            // 
            this.cboServico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboServico.FormattingEnabled = true;
            this.cboServico.Location = new System.Drawing.Point(71, 26);
            this.cboServico.Name = "cboServico";
            this.cboServico.Size = new System.Drawing.Size(173, 24);
            this.cboServico.TabIndex = 0;
            this.cboServico.SelectedIndexChanged += new System.EventHandler(this.cboServico_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.Location = new System.Drawing.Point(10, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 28;
            this.label2.Text = "Serviço";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboLayout
            // 
            this.cboLayout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLayout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboLayout.FormattingEnabled = true;
            this.cboLayout.Location = new System.Drawing.Point(306, 26);
            this.cboLayout.Name = "cboLayout";
            this.cboLayout.Size = new System.Drawing.Size(180, 24);
            this.cboLayout.TabIndex = 1;
            this.cboLayout.SelectedIndexChanged += new System.EventHandler(this.cboLayout_SelectedIndexChanged);
            // 
            // lblBanco
            // 
            this.lblBanco.AutoSize = true;
            this.lblBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblBanco.Location = new System.Drawing.Point(251, 29);
            this.lblBanco.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBanco.Name = "lblBanco";
            this.lblBanco.Size = new System.Drawing.Size(48, 16);
            this.lblBanco.TabIndex = 30;
            this.lblBanco.Text = "Layout";
            this.lblBanco.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpServico
            // 
            this.grpServico.Controls.Add(this.lstServico);
            this.grpServico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.grpServico.Location = new System.Drawing.Point(12, 56);
            this.grpServico.Name = "grpServico";
            this.grpServico.Size = new System.Drawing.Size(232, 223);
            this.grpServico.TabIndex = 2;
            this.grpServico.TabStop = false;
            this.grpServico.Text = "Campos do Serviço";
            // 
            // lstServico
            // 
            this.lstServico.FormattingEnabled = true;
            this.lstServico.ItemHeight = 16;
            this.lstServico.Location = new System.Drawing.Point(10, 19);
            this.lstServico.Name = "lstServico";
            this.lstServico.Size = new System.Drawing.Size(214, 196);
            this.lstServico.Sorted = true;
            this.lstServico.TabIndex = 0;
            // 
            // grpLayout
            // 
            this.grpLayout.Controls.Add(this.lstLayout);
            this.grpLayout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.grpLayout.Location = new System.Drawing.Point(254, 56);
            this.grpLayout.Name = "grpLayout";
            this.grpLayout.Size = new System.Drawing.Size(232, 223);
            this.grpLayout.TabIndex = 3;
            this.grpLayout.TabStop = false;
            this.grpLayout.Text = "Campos do Banco de Dados";
            // 
            // lstLayout
            // 
            this.lstLayout.FormattingEnabled = true;
            this.lstLayout.ItemHeight = 16;
            this.lstLayout.Location = new System.Drawing.Point(9, 21);
            this.lstLayout.Name = "lstLayout";
            this.lstLayout.Size = new System.Drawing.Size(216, 196);
            this.lstLayout.Sorted = true;
            this.lstLayout.TabIndex = 0;
            // 
            // grpAssociacao
            // 
            this.grpAssociacao.Controls.Add(this.lstCamposAssociados);
            this.grpAssociacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.grpAssociacao.Location = new System.Drawing.Point(13, 333);
            this.grpAssociacao.Name = "grpAssociacao";
            this.grpAssociacao.Size = new System.Drawing.Size(473, 216);
            this.grpAssociacao.TabIndex = 6;
            this.grpAssociacao.TabStop = false;
            this.grpAssociacao.Text = "Campos Associados";
            // 
            // lstCamposAssociados
            // 
            this.lstCamposAssociados.FormattingEnabled = true;
            this.lstCamposAssociados.ItemHeight = 16;
            this.lstCamposAssociados.Location = new System.Drawing.Point(8, 21);
            this.lstCamposAssociados.Name = "lstCamposAssociados";
            this.lstCamposAssociados.Size = new System.Drawing.Size(458, 180);
            this.lstCamposAssociados.TabIndex = 0;
            // 
            // btnLimparCampos
            // 
            this.btnLimparCampos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimparCampos.Image = global::SID_Telecred.Properties.Resources.Eraser;
            this.btnLimparCampos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimparCampos.Location = new System.Drawing.Point(13, 556);
            this.btnLimparCampos.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimparCampos.Name = "btnLimparCampos";
            this.btnLimparCampos.Size = new System.Drawing.Size(141, 40);
            this.btnLimparCampos.TabIndex = 9;
            this.btnLimparCampos.Text = "&Limpar Campos";
            this.btnLimparCampos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimparCampos.UseVisualStyleBackColor = true;
            this.btnLimparCampos.Click += new System.EventHandler(this.btnLimparCampos_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = global::SID_Telecred.Properties.Resources.FormAdd;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(13, 286);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(141, 40);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "&Associonar Campos";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemover.Image = global::SID_Telecred.Properties.Resources.FormRem;
            this.btnRemover.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemover.Location = new System.Drawing.Point(345, 286);
            this.btnRemover.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(141, 40);
            this.btnRemover.TabIndex = 5;
            this.btnRemover.Text = "&Remover Campos";
            this.btnRemover.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnAssociar
            // 
            this.btnAssociar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssociar.Image = global::SID_Telecred.Properties.Resources.FormCheck;
            this.btnAssociar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAssociar.Location = new System.Drawing.Point(345, 556);
            this.btnAssociar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAssociar.Name = "btnAssociar";
            this.btnAssociar.Size = new System.Drawing.Size(141, 40);
            this.btnAssociar.TabIndex = 7;
            this.btnAssociar.Text = "&Gravar Associações";
            this.btnAssociar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAssociar.UseVisualStyleBackColor = true;
            this.btnAssociar.Click += new System.EventHandler(this.btnAssociar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnFechar.Image = global::SID_Telecred.Properties.Resources.delete;
            this.btnFechar.Location = new System.Drawing.Point(181, 556);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(141, 40);
            this.btnFechar.TabIndex = 8;
            this.btnFechar.Text = "&Cancelar";
            this.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // frmAssociacaoCampos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 605);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnLimparCampos);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.btnAssociar);
            this.Controls.Add(this.grpAssociacao);
            this.Controls.Add(this.grpLayout);
            this.Controls.Add(this.grpServico);
            this.Controls.Add(this.cboLayout);
            this.Controls.Add(this.lblBanco);
            this.Controls.Add(this.cboServico);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAssociacaoCampos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Associação de Campos com o Banco de Dados";
            this.Load += new System.EventHandler(this.frmAssociacaoCampos_Load);
            this.grpServico.ResumeLayout(false);
            this.grpLayout.ResumeLayout(false);
            this.grpAssociacao.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboServico;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboLayout;
        private System.Windows.Forms.Label lblBanco;
        private System.Windows.Forms.GroupBox grpServico;
        private System.Windows.Forms.ListBox lstServico;
        private System.Windows.Forms.GroupBox grpLayout;
        private System.Windows.Forms.ListBox lstLayout;
        private System.Windows.Forms.GroupBox grpAssociacao;
        private System.Windows.Forms.ListBox lstCamposAssociados;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnAssociar;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnLimparCampos;
        private System.Windows.Forms.Button btnFechar;
    }
}