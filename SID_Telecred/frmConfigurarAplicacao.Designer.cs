namespace SID_Telecred
{
    partial class frmConfigurarAplicacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigurarAplicacao));
            this.grpBancoDados = new System.Windows.Forms.GroupBox();
            this.txtInitialCatalog = new System.Windows.Forms.TextBox();
            this.grpUsuarioSenha = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.lblInitialCatalog = new System.Windows.Forms.Label();
            this.lblDatasource = new System.Windows.Forms.Label();
            this.txtDataSource = new System.Windows.Forms.TextBox();
            this.lblBancoDados = new System.Windows.Forms.Label();
            this.lblAplicacao = new System.Windows.Forms.Label();
            this.grpAplicacao = new System.Windows.Forms.GroupBox();
            this.nudDocumentos = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.nudInatividade = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCaminho = new System.Windows.Forms.TextBox();
            this.fbdImagens = new System.Windows.Forms.FolderBrowserDialog();
            this.tipConfiguracao = new System.Windows.Forms.ToolTip(this.components);
            this.btnGravar = new System.Windows.Forms.Button();
            this.lblPermissoes = new System.Windows.Forms.Label();
            this.grpPermissoes = new System.Windows.Forms.GroupBox();
            this.trwDisponiveis = new System.Windows.Forms.TreeView();
            this.cboUsuario = new System.Windows.Forms.ComboBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.grpBancoDados.SuspendLayout();
            this.grpUsuarioSenha.SuspendLayout();
            this.grpAplicacao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDocumentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInatividade)).BeginInit();
            this.grpPermissoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBancoDados
            // 
            this.grpBancoDados.Controls.Add(this.txtInitialCatalog);
            this.grpBancoDados.Controls.Add(this.grpUsuarioSenha);
            this.grpBancoDados.Controls.Add(this.lblInitialCatalog);
            this.grpBancoDados.Controls.Add(this.lblDatasource);
            this.grpBancoDados.Controls.Add(this.txtDataSource);
            this.grpBancoDados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.grpBancoDados.Location = new System.Drawing.Point(12, 24);
            this.grpBancoDados.Name = "grpBancoDados";
            this.grpBancoDados.Size = new System.Drawing.Size(410, 172);
            this.grpBancoDados.TabIndex = 0;
            this.grpBancoDados.TabStop = false;
            // 
            // txtInitialCatalog
            // 
            this.txtInitialCatalog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtInitialCatalog.Location = new System.Drawing.Point(220, 51);
            this.txtInitialCatalog.Name = "txtInitialCatalog";
            this.txtInitialCatalog.Size = new System.Drawing.Size(175, 22);
            this.txtInitialCatalog.TabIndex = 29;
            // 
            // grpUsuarioSenha
            // 
            this.grpUsuarioSenha.Controls.Add(this.label4);
            this.grpUsuarioSenha.Controls.Add(this.label3);
            this.grpUsuarioSenha.Controls.Add(this.txtPassword);
            this.grpUsuarioSenha.Controls.Add(this.txtUserId);
            this.grpUsuarioSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.grpUsuarioSenha.Location = new System.Drawing.Point(18, 76);
            this.grpUsuarioSenha.Name = "grpUsuarioSenha";
            this.grpUsuarioSenha.Size = new System.Drawing.Size(377, 83);
            this.grpUsuarioSenha.TabIndex = 30;
            this.grpUsuarioSenha.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Senha (Password)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Usuário (User Id)";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(148, 45);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(190, 22);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(139, 19);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(190, 22);
            this.txtUserId.TabIndex = 4;
            // 
            // lblInitialCatalog
            // 
            this.lblInitialCatalog.AutoSize = true;
            this.lblInitialCatalog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblInitialCatalog.Location = new System.Drawing.Point(16, 54);
            this.lblInitialCatalog.Name = "lblInitialCatalog";
            this.lblInitialCatalog.Size = new System.Drawing.Size(201, 16);
            this.lblInitialCatalog.TabIndex = 32;
            this.lblInitialCatalog.Text = "Banco de Dados (Initial Catalog)";
            // 
            // lblDatasource
            // 
            this.lblDatasource.AutoSize = true;
            this.lblDatasource.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblDatasource.Location = new System.Drawing.Point(16, 28);
            this.lblDatasource.Name = "lblDatasource";
            this.lblDatasource.Size = new System.Drawing.Size(176, 16);
            this.lblDatasource.TabIndex = 31;
            this.lblDatasource.Text = "Instância SQL (Data Source)";
            // 
            // txtDataSource
            // 
            this.txtDataSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtDataSource.Location = new System.Drawing.Point(198, 25);
            this.txtDataSource.Name = "txtDataSource";
            this.txtDataSource.Size = new System.Drawing.Size(176, 22);
            this.txtDataSource.TabIndex = 28;
            // 
            // lblBancoDados
            // 
            this.lblBancoDados.AutoSize = true;
            this.lblBancoDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBancoDados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblBancoDados.ForeColor = System.Drawing.Color.Red;
            this.lblBancoDados.Location = new System.Drawing.Point(12, 9);
            this.lblBancoDados.Name = "lblBancoDados";
            this.lblBancoDados.Size = new System.Drawing.Size(112, 18);
            this.lblBancoDados.TabIndex = 1;
            this.lblBancoDados.Text = "Banco de Dados";
            this.lblBancoDados.Click += new System.EventHandler(this.lblBancoDados_Click);
            // 
            // lblAplicacao
            // 
            this.lblAplicacao.AutoSize = true;
            this.lblAplicacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAplicacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblAplicacao.Location = new System.Drawing.Point(130, 9);
            this.lblAplicacao.Name = "lblAplicacao";
            this.lblAplicacao.Size = new System.Drawing.Size(71, 18);
            this.lblAplicacao.TabIndex = 2;
            this.lblAplicacao.Text = "Aplicação";
            this.lblAplicacao.Click += new System.EventHandler(this.lblAplicacao_Click);
            // 
            // grpAplicacao
            // 
            this.grpAplicacao.Controls.Add(this.nudDocumentos);
            this.grpAplicacao.Controls.Add(this.label5);
            this.grpAplicacao.Controls.Add(this.btnPesquisar);
            this.grpAplicacao.Controls.Add(this.nudInatividade);
            this.grpAplicacao.Controls.Add(this.label1);
            this.grpAplicacao.Controls.Add(this.label2);
            this.grpAplicacao.Controls.Add(this.txtCaminho);
            this.grpAplicacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.grpAplicacao.Location = new System.Drawing.Point(12, 24);
            this.grpAplicacao.Name = "grpAplicacao";
            this.grpAplicacao.Size = new System.Drawing.Size(410, 172);
            this.grpAplicacao.TabIndex = 3;
            this.grpAplicacao.TabStop = false;
            this.grpAplicacao.Visible = false;
            // 
            // nudDocumentos
            // 
            this.nudDocumentos.Location = new System.Drawing.Point(164, 112);
            this.nudDocumentos.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudDocumentos.Name = "nudDocumentos";
            this.nudDocumentos.Size = new System.Drawing.Size(55, 22);
            this.nudDocumentos.TabIndex = 38;
            this.nudDocumentos.Value = new decimal(new int[] {
            900,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 16);
            this.label5.TabIndex = 37;
            this.label5.Text = "Documentos por Caixa";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnPesquisar.Image = global::SID_Telecred.Properties.Resources.Folder;
            this.btnPesquisar.Location = new System.Drawing.Point(254, 39);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(141, 40);
            this.btnPesquisar.TabIndex = 36;
            this.btnPesquisar.Text = "Abrir Pasta";
            this.btnPesquisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // nudInatividade
            // 
            this.nudInatividade.Location = new System.Drawing.Point(166, 80);
            this.nudInatividade.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudInatividade.Name = "nudInatividade";
            this.nudInatividade.Size = new System.Drawing.Size(55, 22);
            this.nudInatividade.TabIndex = 12;
            this.nudInatividade.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Limite Inatividade (min)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Caminho das Imagens";
            // 
            // txtCaminho
            // 
            this.txtCaminho.Location = new System.Drawing.Point(16, 48);
            this.txtCaminho.Name = "txtCaminho";
            this.txtCaminho.ReadOnly = true;
            this.txtCaminho.Size = new System.Drawing.Size(232, 22);
            this.txtCaminho.TabIndex = 8;
            // 
            // btnGravar
            // 
            this.btnGravar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnGravar.Image = global::SID_Telecred.Properties.Resources.check;
            this.btnGravar.Location = new System.Drawing.Point(346, 746);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(70, 67);
            this.btnGravar.TabIndex = 38;
            this.btnGravar.Text = "&Gravar";
            this.btnGravar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // lblPermissoes
            // 
            this.lblPermissoes.AutoSize = true;
            this.lblPermissoes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPermissoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblPermissoes.Location = new System.Drawing.Point(207, 9);
            this.lblPermissoes.Name = "lblPermissoes";
            this.lblPermissoes.Size = new System.Drawing.Size(82, 18);
            this.lblPermissoes.TabIndex = 39;
            this.lblPermissoes.Text = "Permissões";
            this.lblPermissoes.Click += new System.EventHandler(this.lblPermissoes_Click);
            // 
            // grpPermissoes
            // 
            this.grpPermissoes.Controls.Add(this.trwDisponiveis);
            this.grpPermissoes.Controls.Add(this.cboUsuario);
            this.grpPermissoes.Controls.Add(this.lblUsuario);
            this.grpPermissoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.grpPermissoes.Location = new System.Drawing.Point(12, 24);
            this.grpPermissoes.Name = "grpPermissoes";
            this.grpPermissoes.Size = new System.Drawing.Size(410, 795);
            this.grpPermissoes.TabIndex = 43;
            this.grpPermissoes.TabStop = false;
            this.grpPermissoes.Visible = false;
            // 
            // trwDisponiveis
            // 
            this.trwDisponiveis.CheckBoxes = true;
            this.trwDisponiveis.HideSelection = false;
            this.trwDisponiveis.Location = new System.Drawing.Point(6, 50);
            this.trwDisponiveis.Name = "trwDisponiveis";
            this.trwDisponiveis.ShowNodeToolTips = true;
            this.trwDisponiveis.ShowPlusMinus = false;
            this.trwDisponiveis.Size = new System.Drawing.Size(322, 739);
            this.trwDisponiveis.TabIndex = 49;
            this.trwDisponiveis.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.trwDisponiveis_BeforeCheck);
            this.trwDisponiveis.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trwDisponiveis_AfterCheck);
            this.trwDisponiveis.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.trwDisponiveis_BeforeSelect);
            this.trwDisponiveis.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trwDisponiveis_AfterSelect);
            // 
            // cboUsuario
            // 
            this.cboUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboUsuario.FormattingEnabled = true;
            this.cboUsuario.Location = new System.Drawing.Point(67, 18);
            this.cboUsuario.Name = "cboUsuario";
            this.cboUsuario.Size = new System.Drawing.Size(181, 24);
            this.cboUsuario.TabIndex = 48;
            this.cboUsuario.SelectedIndexChanged += new System.EventHandler(this.cboUsuario_SelectedIndexChanged);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblUsuario.Location = new System.Drawing.Point(6, 21);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(55, 16);
            this.lblUsuario.TabIndex = 46;
            this.lblUsuario.Text = "Usuário";
            // 
            // frmConfigurarAplicacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 831);
            this.Controls.Add(this.grpBancoDados);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.lblPermissoes);
            this.Controls.Add(this.lblAplicacao);
            this.Controls.Add(this.lblBancoDados);
            this.Controls.Add(this.grpPermissoes);
            this.Controls.Add(this.grpAplicacao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfigurarAplicacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurações";
            this.Load += new System.EventHandler(this.frmConfigurarAplicacao_Load);
            this.grpBancoDados.ResumeLayout(false);
            this.grpBancoDados.PerformLayout();
            this.grpUsuarioSenha.ResumeLayout(false);
            this.grpUsuarioSenha.PerformLayout();
            this.grpAplicacao.ResumeLayout(false);
            this.grpAplicacao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDocumentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInatividade)).EndInit();
            this.grpPermissoes.ResumeLayout(false);
            this.grpPermissoes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBancoDados;
        private System.Windows.Forms.TextBox txtInitialCatalog;
        private System.Windows.Forms.GroupBox grpUsuarioSenha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Label lblInitialCatalog;
        private System.Windows.Forms.Label lblDatasource;
        private System.Windows.Forms.TextBox txtDataSource;
        private System.Windows.Forms.Label lblBancoDados;
        private System.Windows.Forms.Label lblAplicacao;
        private System.Windows.Forms.GroupBox grpAplicacao;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.NumericUpDown nudInatividade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCaminho;
        private System.Windows.Forms.FolderBrowserDialog fbdImagens;
        private System.Windows.Forms.ToolTip tipConfiguracao;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Label lblPermissoes;
        private System.Windows.Forms.GroupBox grpPermissoes;
        private System.Windows.Forms.TreeView trwDisponiveis;
        private System.Windows.Forms.ComboBox cboUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.NumericUpDown nudDocumentos;
        private System.Windows.Forms.Label label5;


    }
}