namespace SID_Telecred
{
    partial class frmPermissaoPeg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPermissaoPeg));
            this.cboUsuario = new System.Windows.Forms.ComboBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnAddTodos = new System.Windows.Forms.Button();
            this.btnRemTodos = new System.Windows.Forms.Button();
            this.btnRemPermissao = new System.Windows.Forms.Button();
            this.btnAddPermissao = new System.Windows.Forms.Button();
            this.grpSelecionados = new System.Windows.Forms.GroupBox();
            this.lstSelecionados = new System.Windows.Forms.ListBox();
            this.groDisponiveis = new System.Windows.Forms.GroupBox();
            this.lstDisponiveis = new System.Windows.Forms.ListBox();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboConvenio = new System.Windows.Forms.ComboBox();
            this.grpSelecionados.SuspendLayout();
            this.groDisponiveis.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboUsuario
            // 
            this.cboUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboUsuario.FormattingEnabled = true;
            this.cboUsuario.Location = new System.Drawing.Point(74, 12);
            this.cboUsuario.Name = "cboUsuario";
            this.cboUsuario.Size = new System.Drawing.Size(294, 24);
            this.cboUsuario.TabIndex = 50;
            this.cboUsuario.SelectedIndexChanged += new System.EventHandler(this.cboUsuario_SelectedIndexChanged);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblUsuario.Location = new System.Drawing.Point(13, 15);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(55, 16);
            this.lblUsuario.TabIndex = 49;
            this.lblUsuario.Text = "Usuário";
            // 
            // btnAddTodos
            // 
            this.btnAddTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTodos.Image = global::SID_Telecred.Properties.Resources.AddAll;
            this.btnAddTodos.Location = new System.Drawing.Point(193, 217);
            this.btnAddTodos.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddTodos.Name = "btnAddTodos";
            this.btnAddTodos.Size = new System.Drawing.Size(175, 40);
            this.btnAddTodos.TabIndex = 77;
            this.btnAddTodos.Text = "Adicionar Todos";
            this.btnAddTodos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddTodos.UseVisualStyleBackColor = true;
            this.btnAddTodos.Click += new System.EventHandler(this.btnAddTodos_Click);
            // 
            // btnRemTodos
            // 
            this.btnRemTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemTodos.Image = global::SID_Telecred.Properties.Resources.RemAll;
            this.btnRemTodos.Location = new System.Drawing.Point(193, 265);
            this.btnRemTodos.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemTodos.Name = "btnRemTodos";
            this.btnRemTodos.Size = new System.Drawing.Size(175, 40);
            this.btnRemTodos.TabIndex = 78;
            this.btnRemTodos.Text = "Remover Todos";
            this.btnRemTodos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRemTodos.UseVisualStyleBackColor = true;
            this.btnRemTodos.Click += new System.EventHandler(this.btnRemTodos_Click);
            // 
            // btnRemPermissao
            // 
            this.btnRemPermissao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemPermissao.Image = global::SID_Telecred.Properties.Resources.Remove;
            this.btnRemPermissao.Location = new System.Drawing.Point(193, 169);
            this.btnRemPermissao.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemPermissao.Name = "btnRemPermissao";
            this.btnRemPermissao.Size = new System.Drawing.Size(175, 40);
            this.btnRemPermissao.TabIndex = 76;
            this.btnRemPermissao.Text = "Remover Item";
            this.btnRemPermissao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRemPermissao.UseVisualStyleBackColor = true;
            this.btnRemPermissao.Click += new System.EventHandler(this.btnRemPermissao_Click);
            // 
            // btnAddPermissao
            // 
            this.btnAddPermissao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPermissao.Image = global::SID_Telecred.Properties.Resources.Add_1;
            this.btnAddPermissao.Location = new System.Drawing.Point(193, 121);
            this.btnAddPermissao.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddPermissao.Name = "btnAddPermissao";
            this.btnAddPermissao.Size = new System.Drawing.Size(175, 40);
            this.btnAddPermissao.TabIndex = 75;
            this.btnAddPermissao.Text = "Adicionar Item";
            this.btnAddPermissao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddPermissao.UseVisualStyleBackColor = true;
            this.btnAddPermissao.Click += new System.EventHandler(this.btnAddPermissao_Click);
            // 
            // grpSelecionados
            // 
            this.grpSelecionados.Controls.Add(this.lstSelecionados);
            this.grpSelecionados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.grpSelecionados.Location = new System.Drawing.Point(375, 42);
            this.grpSelecionados.Name = "grpSelecionados";
            this.grpSelecionados.Size = new System.Drawing.Size(291, 293);
            this.grpSelecionados.TabIndex = 79;
            this.grpSelecionados.TabStop = false;
            this.grpSelecionados.Text = "Acessos Selecionados";
            // 
            // lstSelecionados
            // 
            this.lstSelecionados.FormattingEnabled = true;
            this.lstSelecionados.ItemHeight = 16;
            this.lstSelecionados.Location = new System.Drawing.Point(6, 22);
            this.lstSelecionados.Name = "lstSelecionados";
            this.lstSelecionados.Size = new System.Drawing.Size(279, 260);
            this.lstSelecionados.Sorted = true;
            this.lstSelecionados.TabIndex = 0;
            this.lstSelecionados.DoubleClick += new System.EventHandler(this.lstSelecionados_DoubleClick);
            // 
            // groDisponiveis
            // 
            this.groDisponiveis.Controls.Add(this.lstDisponiveis);
            this.groDisponiveis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.groDisponiveis.Location = new System.Drawing.Point(12, 42);
            this.groDisponiveis.Name = "groDisponiveis";
            this.groDisponiveis.Size = new System.Drawing.Size(172, 293);
            this.groDisponiveis.TabIndex = 74;
            this.groDisponiveis.TabStop = false;
            this.groDisponiveis.Text = "Acessos Disponíveis";
            // 
            // lstDisponiveis
            // 
            this.lstDisponiveis.FormattingEnabled = true;
            this.lstDisponiveis.ItemHeight = 16;
            this.lstDisponiveis.Location = new System.Drawing.Point(6, 22);
            this.lstDisponiveis.Name = "lstDisponiveis";
            this.lstDisponiveis.Size = new System.Drawing.Size(160, 260);
            this.lstDisponiveis.Sorted = true;
            this.lstDisponiveis.TabIndex = 0;
            this.lstDisponiveis.DoubleClick += new System.EventHandler(this.lstDisponiveis_DoubleClick);
            // 
            // btnFechar
            // 
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnFechar.Image = global::SID_Telecred.Properties.Resources.delete;
            this.btnFechar.Location = new System.Drawing.Point(10, 341);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(141, 40);
            this.btnFechar.TabIndex = 80;
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
            this.btnGravar.Location = new System.Drawing.Point(525, 341);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(141, 40);
            this.btnGravar.TabIndex = 81;
            this.btnGravar.Text = "&Gravar";
            this.btnGravar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.Location = new System.Drawing.Point(190, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 82;
            this.label1.Text = "Convênio";
            // 
            // cboConvenio
            // 
            this.cboConvenio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConvenio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboConvenio.FormattingEnabled = true;
            this.cboConvenio.Location = new System.Drawing.Point(193, 72);
            this.cboConvenio.Name = "cboConvenio";
            this.cboConvenio.Size = new System.Drawing.Size(175, 24);
            this.cboConvenio.TabIndex = 83;
            // 
            // frmPermissaoPeg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 391);
            this.Controls.Add(this.cboConvenio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.btnAddTodos);
            this.Controls.Add(this.btnRemTodos);
            this.Controls.Add(this.btnRemPermissao);
            this.Controls.Add(this.btnAddPermissao);
            this.Controls.Add(this.grpSelecionados);
            this.Controls.Add(this.groDisponiveis);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.cboUsuario);
            this.Controls.Add(this.lblUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPermissaoPeg";
            this.Text = "Permissões Digitação PEG";
            this.Load += new System.EventHandler(this.frmPermissaoPeg_Load);
            this.grpSelecionados.ResumeLayout(false);
            this.groDisponiveis.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button btnAddTodos;
        private System.Windows.Forms.Button btnRemTodos;
        private System.Windows.Forms.Button btnRemPermissao;
        private System.Windows.Forms.Button btnAddPermissao;
        private System.Windows.Forms.GroupBox grpSelecionados;
        private System.Windows.Forms.ListBox lstSelecionados;
        private System.Windows.Forms.GroupBox groDisponiveis;
        private System.Windows.Forms.ListBox lstDisponiveis;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboConvenio;
    }
}