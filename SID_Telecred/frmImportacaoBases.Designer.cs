namespace SID_Telecred
{
    partial class frmImportacaoBases
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportacaoBases));
            this.ofdArquivo = new System.Windows.Forms.OpenFileDialog();
            this.lblArquivo = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.grpCamposLocalizados = new System.Windows.Forms.GroupBox();
            this.lstCampos = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkDuplicado = new System.Windows.Forms.CheckBox();
            this.btnChave = new System.Windows.Forms.Button();
            this.lstImportar = new System.Windows.Forms.ListBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnAddTodos = new System.Windows.Forms.Button();
            this.btnRemTodos = new System.Windows.Forms.Button();
            this.btnRemCampo = new System.Windows.Forms.Button();
            this.btnAddCampo = new System.Windows.Forms.Button();
            this.lblBanco = new System.Windows.Forms.Label();
            this.cboLayout = new System.Windows.Forms.ComboBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtLayout = new System.Windows.Forms.TextBox();
            this.btnCarregar = new System.Windows.Forms.Button();
            this.btnNovoBanco = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnGravarLayout = new System.Windows.Forms.Button();
            this.btnImportar = new System.Windows.Forms.Button();
            this.btnLimparCampos = new System.Windows.Forms.Button();
            this.pnlImportacao = new System.Windows.Forms.Panel();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.lblImportacao = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.grpCamposLocalizados.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlImportacao.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblArquivo
            // 
            this.lblArquivo.AutoSize = true;
            this.lblArquivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArquivo.Location = new System.Drawing.Point(16, 23);
            this.lblArquivo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblArquivo.Name = "lblArquivo";
            this.lblArquivo.Size = new System.Drawing.Size(54, 16);
            this.lblArquivo.TabIndex = 14;
            this.lblArquivo.Text = "Arquivo";
            this.lblArquivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDocumento
            // 
            this.txtDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocumento.Location = new System.Drawing.Point(78, 20);
            this.txtDocumento.Margin = new System.Windows.Forms.Padding(4);
            this.txtDocumento.MaxLength = 200;
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.ReadOnly = true;
            this.txtDocumento.Size = new System.Drawing.Size(429, 22);
            this.txtDocumento.TabIndex = 15;
            // 
            // grpCamposLocalizados
            // 
            this.grpCamposLocalizados.Controls.Add(this.lstCampos);
            this.grpCamposLocalizados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCamposLocalizados.Location = new System.Drawing.Point(20, 157);
            this.grpCamposLocalizados.Margin = new System.Windows.Forms.Padding(4);
            this.grpCamposLocalizados.Name = "grpCamposLocalizados";
            this.grpCamposLocalizados.Padding = new System.Windows.Forms.Padding(4);
            this.grpCamposLocalizados.Size = new System.Drawing.Size(302, 324);
            this.grpCamposLocalizados.TabIndex = 17;
            this.grpCamposLocalizados.TabStop = false;
            this.grpCamposLocalizados.Text = "Campos Localizados";
            // 
            // lstCampos
            // 
            this.lstCampos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstCampos.FormattingEnabled = true;
            this.lstCampos.ItemHeight = 16;
            this.lstCampos.Location = new System.Drawing.Point(8, 23);
            this.lstCampos.Margin = new System.Windows.Forms.Padding(4);
            this.lstCampos.Name = "lstCampos";
            this.lstCampos.ScrollAlwaysVisible = true;
            this.lstCampos.Size = new System.Drawing.Size(286, 292);
            this.lstCampos.TabIndex = 18;
            this.lstCampos.DoubleClick += new System.EventHandler(this.lstCampos_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkDuplicado);
            this.groupBox1.Controls.Add(this.btnChave);
            this.groupBox1.Controls.Add(this.lstImportar);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(378, 157);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(302, 324);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Campos a Importar";
            // 
            // chkDuplicado
            // 
            this.chkDuplicado.Checked = true;
            this.chkDuplicado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDuplicado.Location = new System.Drawing.Point(151, 276);
            this.chkDuplicado.Name = "chkDuplicado";
            this.chkDuplicado.Size = new System.Drawing.Size(143, 40);
            this.chkDuplicado.TabIndex = 1;
            this.chkDuplicado.Text = "Atualizar Registros Existentes";
            this.chkDuplicado.UseVisualStyleBackColor = true;
            // 
            // btnChave
            // 
            this.btnChave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChave.Image = global::SID_Telecred.Properties.Resources.TableNew;
            this.btnChave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChave.Location = new System.Drawing.Point(8, 275);
            this.btnChave.Margin = new System.Windows.Forms.Padding(4);
            this.btnChave.Name = "btnChave";
            this.btnChave.Size = new System.Drawing.Size(136, 40);
            this.btnChave.TabIndex = 0;
            this.btnChave.Text = "&Definir Campo como Chave";
            this.btnChave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnChave.UseVisualStyleBackColor = true;
            this.btnChave.Click += new System.EventHandler(this.btnChave_Click);
            // 
            // lstImportar
            // 
            this.lstImportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstImportar.FormattingEnabled = true;
            this.lstImportar.ItemHeight = 16;
            this.lstImportar.Location = new System.Drawing.Point(8, 23);
            this.lstImportar.Margin = new System.Windows.Forms.Padding(4);
            this.lstImportar.Name = "lstImportar";
            this.lstImportar.ScrollAlwaysVisible = true;
            this.lstImportar.Size = new System.Drawing.Size(286, 244);
            this.lstImportar.TabIndex = 18;
            this.lstImportar.DoubleClick += new System.EventHandler(this.lstImportar_DoubleClick);
            // 
            // btnAddTodos
            // 
            this.btnAddTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTodos.Image = global::SID_Telecred.Properties.Resources.AddTable;
            this.btnAddTodos.Location = new System.Drawing.Point(330, 384);
            this.btnAddTodos.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddTodos.Name = "btnAddTodos";
            this.btnAddTodos.Size = new System.Drawing.Size(40, 40);
            this.btnAddTodos.TabIndex = 7;
            this.toolTip1.SetToolTip(this.btnAddTodos, "Adicionar Todos");
            this.btnAddTodos.UseVisualStyleBackColor = true;
            this.btnAddTodos.Click += new System.EventHandler(this.btnAddTodos_Click);
            // 
            // btnRemTodos
            // 
            this.btnRemTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemTodos.Image = global::SID_Telecred.Properties.Resources.RemTable;
            this.btnRemTodos.Location = new System.Drawing.Point(330, 432);
            this.btnRemTodos.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemTodos.Name = "btnRemTodos";
            this.btnRemTodos.Size = new System.Drawing.Size(40, 40);
            this.btnRemTodos.TabIndex = 8;
            this.toolTip1.SetToolTip(this.btnRemTodos, "Remover Todos");
            this.btnRemTodos.UseVisualStyleBackColor = true;
            this.btnRemTodos.Click += new System.EventHandler(this.btnRemTodos_Click);
            // 
            // btnRemCampo
            // 
            this.btnRemCampo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemCampo.Image = global::SID_Telecred.Properties.Resources.RemColumn;
            this.btnRemCampo.Location = new System.Drawing.Point(330, 228);
            this.btnRemCampo.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemCampo.Name = "btnRemCampo";
            this.btnRemCampo.Size = new System.Drawing.Size(40, 40);
            this.btnRemCampo.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btnRemCampo, "Remover Campo");
            this.btnRemCampo.UseVisualStyleBackColor = true;
            this.btnRemCampo.Click += new System.EventHandler(this.btnRemCampo_Click);
            // 
            // btnAddCampo
            // 
            this.btnAddCampo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCampo.Image = global::SID_Telecred.Properties.Resources.AddColumn;
            this.btnAddCampo.Location = new System.Drawing.Point(330, 180);
            this.btnAddCampo.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddCampo.Name = "btnAddCampo";
            this.btnAddCampo.Size = new System.Drawing.Size(40, 40);
            this.btnAddCampo.TabIndex = 5;
            this.toolTip1.SetToolTip(this.btnAddCampo, "Adicionar Campo");
            this.btnAddCampo.UseVisualStyleBackColor = true;
            this.btnAddCampo.Click += new System.EventHandler(this.btnAddCampo_Click);
            // 
            // lblBanco
            // 
            this.lblBanco.AutoSize = true;
            this.lblBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBanco.Location = new System.Drawing.Point(16, 71);
            this.lblBanco.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBanco.Name = "lblBanco";
            this.lblBanco.Size = new System.Drawing.Size(48, 16);
            this.lblBanco.TabIndex = 23;
            this.lblBanco.Text = "Layout";
            this.lblBanco.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboLayout
            // 
            this.cboLayout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLayout.FormattingEnabled = true;
            this.cboLayout.Location = new System.Drawing.Point(78, 68);
            this.cboLayout.Name = "cboLayout";
            this.cboLayout.Size = new System.Drawing.Size(429, 24);
            this.cboLayout.TabIndex = 0;
            this.cboLayout.SelectedIndexChanged += new System.EventHandler(this.cboLayout_SelectedIndexChanged);
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.Location = new System.Drawing.Point(16, 119);
            this.lblNome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(84, 16);
            this.lblNome.TabIndex = 26;
            this.lblNome.Text = "Novo Layout";
            this.lblNome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLayout
            // 
            this.txtLayout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLayout.Location = new System.Drawing.Point(108, 116);
            this.txtLayout.Margin = new System.Windows.Forms.Padding(4);
            this.txtLayout.MaxLength = 200;
            this.txtLayout.Name = "txtLayout";
            this.txtLayout.Size = new System.Drawing.Size(399, 22);
            this.txtLayout.TabIndex = 1;
            // 
            // btnCarregar
            // 
            this.btnCarregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarregar.Image = global::SID_Telecred.Properties.Resources.TableInfo;
            this.btnCarregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCarregar.Location = new System.Drawing.Point(515, 59);
            this.btnCarregar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCarregar.Name = "btnCarregar";
            this.btnCarregar.Size = new System.Drawing.Size(165, 40);
            this.btnCarregar.TabIndex = 3;
            this.btnCarregar.Text = "&Pesquisar Campos no Arquivo";
            this.btnCarregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCarregar.UseVisualStyleBackColor = true;
            this.btnCarregar.Click += new System.EventHandler(this.btnCarregar_Click);
            // 
            // btnNovoBanco
            // 
            this.btnNovoBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovoBanco.Image = global::SID_Telecred.Properties.Resources.TableNew;
            this.btnNovoBanco.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNovoBanco.Location = new System.Drawing.Point(515, 107);
            this.btnNovoBanco.Margin = new System.Windows.Forms.Padding(4);
            this.btnNovoBanco.Name = "btnNovoBanco";
            this.btnNovoBanco.Size = new System.Drawing.Size(165, 40);
            this.btnNovoBanco.TabIndex = 4;
            this.btnNovoBanco.Text = "&Novo Layout";
            this.btnNovoBanco.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNovoBanco.UseVisualStyleBackColor = true;
            this.btnNovoBanco.Click += new System.EventHandler(this.btnNovoBanco_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = global::SID_Telecred.Properties.Resources.Folder;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(515, 11);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(165, 40);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "&Abrir Arquivo";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnGravarLayout
            // 
            this.btnGravarLayout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGravarLayout.Image = global::SID_Telecred.Properties.Resources.TableOk;
            this.btnGravarLayout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGravarLayout.Location = new System.Drawing.Point(19, 489);
            this.btnGravarLayout.Margin = new System.Windows.Forms.Padding(4);
            this.btnGravarLayout.Name = "btnGravarLayout";
            this.btnGravarLayout.Size = new System.Drawing.Size(165, 40);
            this.btnGravarLayout.TabIndex = 9;
            this.btnGravarLayout.Text = "&Gravar Layout";
            this.btnGravarLayout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGravarLayout.UseVisualStyleBackColor = true;
            this.btnGravarLayout.Click += new System.EventHandler(this.btnGravarLayout_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.Enabled = false;
            this.btnImportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportar.Image = global::SID_Telecred.Properties.Resources.TableReplace;
            this.btnImportar.Location = new System.Drawing.Point(512, 489);
            this.btnImportar.Margin = new System.Windows.Forms.Padding(4);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(165, 40);
            this.btnImportar.TabIndex = 12;
            this.btnImportar.Text = "&Importar Dados";
            this.btnImportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // btnLimparCampos
            // 
            this.btnLimparCampos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimparCampos.Image = global::SID_Telecred.Properties.Resources.Eraser;
            this.btnLimparCampos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimparCampos.Location = new System.Drawing.Point(192, 489);
            this.btnLimparCampos.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimparCampos.Name = "btnLimparCampos";
            this.btnLimparCampos.Size = new System.Drawing.Size(165, 40);
            this.btnLimparCampos.TabIndex = 10;
            this.btnLimparCampos.Text = "&Limpar Campos";
            this.btnLimparCampos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimparCampos.UseVisualStyleBackColor = true;
            this.btnLimparCampos.Click += new System.EventHandler(this.btnLimparCampos_Click);
            // 
            // pnlImportacao
            // 
            this.pnlImportacao.Controls.Add(this.lblRegistros);
            this.pnlImportacao.Controls.Add(this.lblImportacao);
            this.pnlImportacao.Location = new System.Drawing.Point(19, 157);
            this.pnlImportacao.Name = "pnlImportacao";
            this.pnlImportacao.Size = new System.Drawing.Size(661, 100);
            this.pnlImportacao.TabIndex = 32;
            this.pnlImportacao.Visible = false;
            // 
            // lblRegistros
            // 
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.Red;
            this.lblRegistros.Location = new System.Drawing.Point(3, 58);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(658, 39);
            this.lblRegistros.TabIndex = 1;
            this.lblRegistros.Text = "Registros Lidos: 00000";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblImportacao
            // 
            this.lblImportacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImportacao.ForeColor = System.Drawing.Color.Red;
            this.lblImportacao.Location = new System.Drawing.Point(3, 8);
            this.lblImportacao.Name = "lblImportacao";
            this.lblImportacao.Size = new System.Drawing.Size(658, 50);
            this.lblImportacao.TabIndex = 0;
            this.lblImportacao.Text = "Importando Registros !!!! Aguarde...";
            this.lblImportacao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFechar
            // 
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnFechar.Image = global::SID_Telecred.Properties.Resources.door2_open;
            this.btnFechar.Location = new System.Drawing.Point(364, 489);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(141, 40);
            this.btnFechar.TabIndex = 11;
            this.btnFechar.Text = "&Sair";
            this.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // frmImportacaoBases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 539);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnLimparCampos);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.btnGravarLayout);
            this.Controls.Add(this.btnCarregar);
            this.Controls.Add(this.txtLayout);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.btnNovoBanco);
            this.Controls.Add(this.cboLayout);
            this.Controls.Add(this.lblBanco);
            this.Controls.Add(this.btnAddTodos);
            this.Controls.Add(this.btnRemTodos);
            this.Controls.Add(this.btnRemCampo);
            this.Controls.Add(this.btnAddCampo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpCamposLocalizados);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtDocumento);
            this.Controls.Add(this.lblArquivo);
            this.Controls.Add(this.pnlImportacao);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImportacaoBases";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importação de Bases de Dados";
            this.Load += new System.EventHandler(this.frmImportacaoBases_Load);
            this.grpCamposLocalizados.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.pnlImportacao.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdArquivo;
        private System.Windows.Forms.Label lblArquivo;
        public System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox grpCamposLocalizados;
        private System.Windows.Forms.ListBox lstCampos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstImportar;
        private System.Windows.Forms.Button btnRemTodos;
        private System.Windows.Forms.Button btnRemCampo;
        private System.Windows.Forms.Button btnAddCampo;
        private System.Windows.Forms.Button btnAddTodos;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblBanco;
        private System.Windows.Forms.ComboBox cboLayout;
        private System.Windows.Forms.Button btnNovoBanco;
        private System.Windows.Forms.Label lblNome;
        public System.Windows.Forms.TextBox txtLayout;
        private System.Windows.Forms.Button btnCarregar;
        private System.Windows.Forms.Button btnGravarLayout;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.Button btnLimparCampos;
        private System.Windows.Forms.Panel pnlImportacao;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Label lblImportacao;
        private System.Windows.Forms.CheckBox chkDuplicado;
        private System.Windows.Forms.Button btnChave;
        private System.Windows.Forms.Button btnFechar;
    }
}