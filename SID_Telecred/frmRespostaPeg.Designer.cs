namespace SID_Telecred
{
    partial class frmRespostaPeg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRespostaPeg));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbInativo = new System.Windows.Forms.RadioButton();
            this.rdbAtivo = new System.Windows.Forms.RadioButton();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.grdRespostas = new System.Windows.Forms.DataGridView();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.grpUsuario = new System.Windows.Forms.GroupBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.grpCadastro = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbNao = new System.Windows.Forms.RadioButton();
            this.rdbSim = new System.Windows.Forms.RadioButton();
            this.btnLimparCampos = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdbTratativaNao = new System.Windows.Forms.RadioButton();
            this.rdbTratativaSim = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdbSoTratativaNao = new System.Windows.Forms.RadioButton();
            this.rdbSoTratativaSim = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRespostas)).BeginInit();
            this.grpUsuario.SuspendLayout();
            this.grpCadastro.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbInativo);
            this.groupBox1.Controls.Add(this.rdbAtivo);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(8, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(140, 53);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // rdbInativo
            // 
            this.rdbInativo.AutoSize = true;
            this.rdbInativo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.rdbInativo.Location = new System.Drawing.Point(68, 19);
            this.rdbInativo.Name = "rdbInativo";
            this.rdbInativo.Size = new System.Drawing.Size(65, 20);
            this.rdbInativo.TabIndex = 11;
            this.rdbInativo.Text = "Inativo";
            this.rdbInativo.UseVisualStyleBackColor = true;
            // 
            // rdbAtivo
            // 
            this.rdbAtivo.AutoSize = true;
            this.rdbAtivo.Checked = true;
            this.rdbAtivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.rdbAtivo.Location = new System.Drawing.Point(6, 19);
            this.rdbAtivo.Name = "rdbAtivo";
            this.rdbAtivo.Size = new System.Drawing.Size(56, 20);
            this.rdbAtivo.TabIndex = 10;
            this.rdbAtivo.TabStop = true;
            this.rdbAtivo.Text = "Ativo";
            this.rdbAtivo.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(12, 443);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(146, 40);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblPesquisar.Location = new System.Drawing.Point(17, 30);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(95, 16);
            this.lblPesquisar.TabIndex = 0;
            this.lblPesquisar.Text = "Pesquisar por:";
            // 
            // grdRespostas
            // 
            this.grdRespostas.AllowUserToAddRows = false;
            this.grdRespostas.AllowUserToDeleteRows = false;
            this.grdRespostas.AllowUserToResizeColumns = false;
            this.grdRespostas.AllowUserToResizeRows = false;
            this.grdRespostas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRespostas.Location = new System.Drawing.Point(6, 59);
            this.grdRespostas.MultiSelect = false;
            this.grdRespostas.Name = "grdRespostas";
            this.grdRespostas.ReadOnly = true;
            this.grdRespostas.RowHeadersVisible = false;
            this.grdRespostas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdRespostas.Size = new System.Drawing.Size(621, 228);
            this.grdRespostas.TabIndex = 2;
            this.grdRespostas.TabStop = false;
            this.grdRespostas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdRespostas_CellClick);
            this.grdRespostas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdRespostas_KeyDown);
            this.grdRespostas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdRespostas_KeyPress);
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtPesquisar.Location = new System.Drawing.Point(133, 27);
            this.txtPesquisar.MaxLength = 50;
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(343, 22);
            this.txtPesquisar.TabIndex = 1;
            this.txtPesquisar.TextChanged += new System.EventHandler(this.txtPesquisar_TextChanged);
            // 
            // grpUsuario
            // 
            this.grpUsuario.Controls.Add(this.grdRespostas);
            this.grpUsuario.Controls.Add(this.txtPesquisar);
            this.grpUsuario.Controls.Add(this.lblPesquisar);
            this.grpUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.grpUsuario.Location = new System.Drawing.Point(12, 12);
            this.grpUsuario.Name = "grpUsuario";
            this.grpUsuario.Size = new System.Drawing.Size(633, 293);
            this.grpUsuario.TabIndex = 14;
            this.grpUsuario.TabStop = false;
            this.grpUsuario.Text = "Respostas Cadastradas";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtDescricao.Location = new System.Drawing.Point(83, 27);
            this.txtDescricao.MaxLength = 255;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(544, 22);
            this.txtDescricao.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.Location = new System.Drawing.Point(498, 443);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(146, 40);
            this.btnOk.TabIndex = 16;
            this.btnOk.Text = "Ok";
            this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblUsuario.Location = new System.Drawing.Point(7, 30);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(70, 16);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Descrição";
            // 
            // grpCadastro
            // 
            this.grpCadastro.Controls.Add(this.groupBox4);
            this.grpCadastro.Controls.Add(this.groupBox3);
            this.grpCadastro.Controls.Add(this.groupBox2);
            this.grpCadastro.Controls.Add(this.groupBox1);
            this.grpCadastro.Controls.Add(this.txtDescricao);
            this.grpCadastro.Controls.Add(this.lblUsuario);
            this.grpCadastro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.grpCadastro.Location = new System.Drawing.Point(12, 311);
            this.grpCadastro.Name = "grpCadastro";
            this.grpCadastro.Size = new System.Drawing.Size(633, 126);
            this.grpCadastro.TabIndex = 15;
            this.grpCadastro.TabStop = false;
            this.grpCadastro.Text = "Dados da Resposta";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbNao);
            this.groupBox2.Controls.Add(this.rdbSim);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.groupBox2.Location = new System.Drawing.Point(162, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(144, 53);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Campo Extra";
            // 
            // rdbNao
            // 
            this.rdbNao.AutoSize = true;
            this.rdbNao.Checked = true;
            this.rdbNao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.rdbNao.Location = new System.Drawing.Point(76, 21);
            this.rdbNao.Name = "rdbNao";
            this.rdbNao.Size = new System.Drawing.Size(52, 20);
            this.rdbNao.TabIndex = 11;
            this.rdbNao.TabStop = true;
            this.rdbNao.Text = "Não";
            this.rdbNao.UseVisualStyleBackColor = true;
            // 
            // rdbSim
            // 
            this.rdbSim.AutoSize = true;
            this.rdbSim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.rdbSim.Location = new System.Drawing.Point(21, 19);
            this.rdbSim.Name = "rdbSim";
            this.rdbSim.Size = new System.Drawing.Size(49, 20);
            this.rdbSim.TabIndex = 10;
            this.rdbSim.Text = "Sim";
            this.rdbSim.UseVisualStyleBackColor = true;
            // 
            // btnLimparCampos
            // 
            this.btnLimparCampos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimparCampos.Image = global::SID_Telecred.Properties.Resources.Eraser;
            this.btnLimparCampos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimparCampos.Location = new System.Drawing.Point(255, 444);
            this.btnLimparCampos.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimparCampos.Name = "btnLimparCampos";
            this.btnLimparCampos.Size = new System.Drawing.Size(146, 40);
            this.btnLimparCampos.TabIndex = 18;
            this.btnLimparCampos.Text = "&Limpar Campos";
            this.btnLimparCampos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimparCampos.UseVisualStyleBackColor = true;
            this.btnLimparCampos.Click += new System.EventHandler(this.btnLimparCampos_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdbTratativaNao);
            this.groupBox3.Controls.Add(this.rdbTratativaSim);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.groupBox3.Location = new System.Drawing.Point(320, 66);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(145, 53);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Encaminha Tratativa";
            // 
            // rdbTratativaNao
            // 
            this.rdbTratativaNao.AutoSize = true;
            this.rdbTratativaNao.Checked = true;
            this.rdbTratativaNao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.rdbTratativaNao.Location = new System.Drawing.Point(76, 21);
            this.rdbTratativaNao.Name = "rdbTratativaNao";
            this.rdbTratativaNao.Size = new System.Drawing.Size(52, 20);
            this.rdbTratativaNao.TabIndex = 11;
            this.rdbTratativaNao.TabStop = true;
            this.rdbTratativaNao.Text = "Não";
            this.rdbTratativaNao.UseVisualStyleBackColor = true;
            // 
            // rdbTratativaSim
            // 
            this.rdbTratativaSim.AutoSize = true;
            this.rdbTratativaSim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.rdbTratativaSim.Location = new System.Drawing.Point(21, 19);
            this.rdbTratativaSim.Name = "rdbTratativaSim";
            this.rdbTratativaSim.Size = new System.Drawing.Size(49, 20);
            this.rdbTratativaSim.TabIndex = 10;
            this.rdbTratativaSim.Text = "Sim";
            this.rdbTratativaSim.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rdbSoTratativaNao);
            this.groupBox4.Controls.Add(this.rdbSoTratativaSim);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.groupBox4.Location = new System.Drawing.Point(479, 67);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(144, 53);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Somente Tratativa";
            // 
            // rdbSoTratativaNao
            // 
            this.rdbSoTratativaNao.AutoSize = true;
            this.rdbSoTratativaNao.Checked = true;
            this.rdbSoTratativaNao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.rdbSoTratativaNao.Location = new System.Drawing.Point(76, 21);
            this.rdbSoTratativaNao.Name = "rdbSoTratativaNao";
            this.rdbSoTratativaNao.Size = new System.Drawing.Size(52, 20);
            this.rdbSoTratativaNao.TabIndex = 11;
            this.rdbSoTratativaNao.TabStop = true;
            this.rdbSoTratativaNao.Text = "Não";
            this.rdbSoTratativaNao.UseVisualStyleBackColor = true;
            // 
            // rdbSoTratativaSim
            // 
            this.rdbSoTratativaSim.AutoSize = true;
            this.rdbSoTratativaSim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.rdbSoTratativaSim.Location = new System.Drawing.Point(21, 19);
            this.rdbSoTratativaSim.Name = "rdbSoTratativaSim";
            this.rdbSoTratativaSim.Size = new System.Drawing.Size(49, 20);
            this.rdbSoTratativaSim.TabIndex = 10;
            this.rdbSoTratativaSim.Text = "Sim";
            this.rdbSoTratativaSim.UseVisualStyleBackColor = true;
            // 
            // frmRespostaPeg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 494);
            this.Controls.Add(this.btnLimparCampos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grpUsuario);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.grpCadastro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRespostaPeg";
            this.Text = "Cadastro de Respostas";
            this.Load += new System.EventHandler(this.frmRespostaPeg_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRespostas)).EndInit();
            this.grpUsuario.ResumeLayout(false);
            this.grpUsuario.PerformLayout();
            this.grpCadastro.ResumeLayout(false);
            this.grpCadastro.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbInativo;
        private System.Windows.Forms.RadioButton rdbAtivo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.DataGridView grdRespostas;
        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.GroupBox grpUsuario;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.GroupBox grpCadastro;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbNao;
        private System.Windows.Forms.RadioButton rdbSim;
        private System.Windows.Forms.Button btnLimparCampos;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdbTratativaNao;
        private System.Windows.Forms.RadioButton rdbTratativaSim;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rdbSoTratativaNao;
        private System.Windows.Forms.RadioButton rdbSoTratativaSim;
    }
}