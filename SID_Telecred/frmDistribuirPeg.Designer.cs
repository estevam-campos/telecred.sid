namespace SID_Telecred
{
    partial class frmDistribuirPeg
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
            this.cboRespostas = new System.Windows.Forms.ComboBox();
            this.lblResposta = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtComplemento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRegimeAtendimento = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRespostaAnterior = new System.Windows.Forms.TextBox();
            this.lblRespostaAnterior = new System.Windows.Forms.Label();
            this.txtNumeroPeg = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEventos = new System.Windows.Forms.TextBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnListagem = new System.Windows.Forms.Button();
            this.btnDescartar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblConsulta = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSADT = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblHospital = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDiamante = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnAlterarRegime = new System.Windows.Forms.Button();
            this.txtConvenio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCopia = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboRespostas
            // 
            this.cboRespostas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboRespostas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRespostas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboRespostas.FormattingEnabled = true;
            this.cboRespostas.Location = new System.Drawing.Point(97, 215);
            this.cboRespostas.Name = "cboRespostas";
            this.cboRespostas.Size = new System.Drawing.Size(659, 24);
            this.cboRespostas.TabIndex = 91;
            this.cboRespostas.SelectedIndexChanged += new System.EventHandler(this.cboRespostas_SelectedIndexChanged);
            // 
            // lblResposta
            // 
            this.lblResposta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblResposta.AutoSize = true;
            this.lblResposta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblResposta.Location = new System.Drawing.Point(24, 218);
            this.lblResposta.Name = "lblResposta";
            this.lblResposta.Size = new System.Drawing.Size(67, 16);
            this.lblResposta.TabIndex = 90;
            this.lblResposta.Text = "Resposta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.Location = new System.Drawing.Point(18, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 93;
            this.label1.Text = "N° PEG";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.Location = new System.Drawing.Point(24, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 16);
            this.label2.TabIndex = 94;
            this.label2.Text = "Complemento";
            // 
            // txtComplemento
            // 
            this.txtComplemento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtComplemento.Enabled = false;
            this.txtComplemento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtComplemento.Location = new System.Drawing.Point(122, 245);
            this.txtComplemento.MaxLength = 255;
            this.txtComplemento.Name = "txtComplemento";
            this.txtComplemento.Size = new System.Drawing.Size(463, 22);
            this.txtComplemento.TabIndex = 95;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label3.Location = new System.Drawing.Point(21, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 16);
            this.label3.TabIndex = 96;
            this.label3.Text = "Regime Atendimento";
            // 
            // txtRegimeAtendimento
            // 
            this.txtRegimeAtendimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegimeAtendimento.Location = new System.Drawing.Point(161, 97);
            this.txtRegimeAtendimento.MaxLength = 255;
            this.txtRegimeAtendimento.Name = "txtRegimeAtendimento";
            this.txtRegimeAtendimento.ReadOnly = true;
            this.txtRegimeAtendimento.Size = new System.Drawing.Size(595, 38);
            this.txtRegimeAtendimento.TabIndex = 97;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.txtConvenio);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtRespostaAnterior);
            this.groupBox1.Controls.Add(this.lblRespostaAnterior);
            this.groupBox1.Controls.Add(this.txtNumeroPeg);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtEventos);
            this.groupBox1.Controls.Add(this.cboRespostas);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnPesquisar);
            this.groupBox1.Controls.Add(this.txtRegimeAtendimento);
            this.groupBox1.Controls.Add(this.lblResposta);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtComplemento);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(767, 281);
            this.groupBox1.TabIndex = 98;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados da PEG";
            // 
            // txtRespostaAnterior
            // 
            this.txtRespostaAnterior.BackColor = System.Drawing.Color.Red;
            this.txtRespostaAnterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRespostaAnterior.ForeColor = System.Drawing.Color.White;
            this.txtRespostaAnterior.Location = new System.Drawing.Point(161, 183);
            this.txtRespostaAnterior.MaxLength = 255;
            this.txtRespostaAnterior.Name = "txtRespostaAnterior";
            this.txtRespostaAnterior.ReadOnly = true;
            this.txtRespostaAnterior.Size = new System.Drawing.Size(595, 29);
            this.txtRespostaAnterior.TabIndex = 102;
            this.txtRespostaAnterior.Visible = false;
            // 
            // lblRespostaAnterior
            // 
            this.lblRespostaAnterior.AutoSize = true;
            this.lblRespostaAnterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblRespostaAnterior.Location = new System.Drawing.Point(21, 191);
            this.lblRespostaAnterior.Name = "lblRespostaAnterior";
            this.lblRespostaAnterior.Size = new System.Drawing.Size(116, 16);
            this.lblRespostaAnterior.TabIndex = 101;
            this.lblRespostaAnterior.Text = "Resposta Anterior";
            this.lblRespostaAnterior.Visible = false;
            // 
            // txtNumeroPeg
            // 
            this.txtNumeroPeg.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroPeg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtNumeroPeg.Location = new System.Drawing.Point(77, 29);
            this.txtNumeroPeg.MaxLength = 255;
            this.txtNumeroPeg.Name = "txtNumeroPeg";
            this.txtNumeroPeg.ReadOnly = true;
            this.txtNumeroPeg.Size = new System.Drawing.Size(529, 62);
            this.txtNumeroPeg.TabIndex = 100;
            this.txtNumeroPeg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label4.Location = new System.Drawing.Point(591, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 16);
            this.label4.TabIndex = 98;
            this.label4.Text = "Qtde Eventos";
            // 
            // txtEventos
            // 
            this.txtEventos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtEventos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtEventos.Location = new System.Drawing.Point(689, 245);
            this.txtEventos.MaxLength = 255;
            this.txtEventos.Name = "txtEventos";
            this.txtEventos.Size = new System.Drawing.Size(67, 22);
            this.txtEventos.TabIndex = 99;
            this.txtEventos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEventos_KeyPress);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnPesquisar.Image = global::SID_Telecred.Properties.Resources.selection_view;
            this.btnPesquisar.Location = new System.Drawing.Point(618, 35);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(138, 40);
            this.btnPesquisar.TabIndex = 88;
            this.btnPesquisar.Text = "&Buscar PEG";
            this.btnPesquisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnListagem
            // 
            this.btnListagem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnListagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnListagem.Image = global::SID_Telecred.Properties.Resources.TableInfo;
            this.btnListagem.Location = new System.Drawing.Point(222, 299);
            this.btnListagem.Name = "btnListagem";
            this.btnListagem.Size = new System.Drawing.Size(138, 40);
            this.btnListagem.TabIndex = 99;
            this.btnListagem.Text = "&Marcar como Listagem";
            this.btnListagem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnListagem.UseVisualStyleBackColor = true;
            this.btnListagem.Click += new System.EventHandler(this.btnListagem_Click);
            // 
            // btnDescartar
            // 
            this.btnDescartar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDescartar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnDescartar.Image = global::SID_Telecred.Properties.Resources.stop;
            this.btnDescartar.Location = new System.Drawing.Point(175, 299);
            this.btnDescartar.Name = "btnDescartar";
            this.btnDescartar.Size = new System.Drawing.Size(138, 40);
            this.btnDescartar.TabIndex = 89;
            this.btnDescartar.Text = "&Descartar PEG";
            this.btnDescartar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDescartar.UseVisualStyleBackColor = true;
            this.btnDescartar.Visible = false;
            this.btnDescartar.Click += new System.EventHandler(this.btnDescartar_Click);
            // 
            // btnGravar
            // 
            this.btnGravar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnGravar.Image = global::SID_Telecred.Properties.Resources.FloppyDisks;
            this.btnGravar.Location = new System.Drawing.Point(12, 299);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(138, 40);
            this.btnGravar.TabIndex = 87;
            this.btnGravar.Text = "&Gravar";
            this.btnGravar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnFechar.Image = global::SID_Telecred.Properties.Resources.delete;
            this.btnFechar.Location = new System.Drawing.Point(642, 299);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(138, 40);
            this.btnFechar.TabIndex = 86;
            this.btnFechar.Text = "&Cancelar";
            this.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblConsulta,
            this.lblSADT,
            this.lblHospital,
            this.lblDiamante});
            this.statusStrip1.Location = new System.Drawing.Point(0, 345);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(792, 22);
            this.statusStrip1.TabIndex = 100;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblConsulta
            // 
            this.lblConsulta.Name = "lblConsulta";
            this.lblConsulta.Size = new System.Drawing.Size(194, 17);
            this.lblConsulta.Spring = true;
            this.lblConsulta.Text = "Consultório / Clínica: 0";
            // 
            // lblSADT
            // 
            this.lblSADT.Name = "lblSADT";
            this.lblSADT.Size = new System.Drawing.Size(194, 17);
            this.lblSADT.Spring = true;
            this.lblSADT.Text = "Atendimento Externo: 0";
            // 
            // lblHospital
            // 
            this.lblHospital.Name = "lblHospital";
            this.lblHospital.Size = new System.Drawing.Size(194, 17);
            this.lblHospital.Spring = true;
            this.lblHospital.Text = "Hospital / Maternidade: 0";
            // 
            // lblDiamante
            // 
            this.lblDiamante.Name = "lblDiamante";
            this.lblDiamante.Size = new System.Drawing.Size(194, 17);
            this.lblDiamante.Spring = true;
            this.lblDiamante.Text = "Diamante: 0";
            // 
            // btnAlterarRegime
            // 
            this.btnAlterarRegime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAlterarRegime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnAlterarRegime.Image = global::SID_Telecred.Properties.Resources.DocumentRefresh;
            this.btnAlterarRegime.Location = new System.Drawing.Point(432, 299);
            this.btnAlterarRegime.Name = "btnAlterarRegime";
            this.btnAlterarRegime.Size = new System.Drawing.Size(138, 40);
            this.btnAlterarRegime.TabIndex = 101;
            this.btnAlterarRegime.Text = "&Alterar Regime Atendimento";
            this.btnAlterarRegime.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAlterarRegime.UseVisualStyleBackColor = true;
            this.btnAlterarRegime.Click += new System.EventHandler(this.btnAlterarRegime_Click);
            // 
            // txtConvenio
            // 
            this.txtConvenio.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConvenio.Location = new System.Drawing.Point(161, 141);
            this.txtConvenio.MaxLength = 255;
            this.txtConvenio.Name = "txtConvenio";
            this.txtConvenio.ReadOnly = true;
            this.txtConvenio.Size = new System.Drawing.Size(595, 38);
            this.txtConvenio.TabIndex = 104;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label5.Location = new System.Drawing.Point(21, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 16);
            this.label5.TabIndex = 103;
            this.label5.Text = "Convênio";
            // 
            // lblCopia
            // 
            this.lblCopia.AutoSize = true;
            this.lblCopia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopia.ForeColor = System.Drawing.Color.Red;
            this.lblCopia.Location = new System.Drawing.Point(513, 1);
            this.lblCopia.Name = "lblCopia";
            this.lblCopia.Size = new System.Drawing.Size(264, 13);
            this.lblCopia.TabIndex = 102;
            this.lblCopia.Text = "Nº PEG copiado para a área de transferência";
            // 
            // frmDistribuirPeg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 367);
            this.Controls.Add(this.lblCopia);
            this.Controls.Add(this.btnAlterarRegime);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnListagem);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDescartar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.btnFechar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDistribuirPeg";
            this.Text = "Distribuição de PEGs";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDistribuirPeg_FormClosing);
            this.Load += new System.EventHandler(this.frmDistribuirPeg_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnDescartar;
        private System.Windows.Forms.ComboBox cboRespostas;
        private System.Windows.Forms.Label lblResposta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtComplemento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRegimeAtendimento;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEventos;
        private System.Windows.Forms.Button btnListagem;
        private System.Windows.Forms.TextBox txtNumeroPeg;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblConsulta;
        private System.Windows.Forms.ToolStripStatusLabel lblSADT;
        private System.Windows.Forms.ToolStripStatusLabel lblHospital;
        private System.Windows.Forms.ToolStripStatusLabel lblDiamante;
        private System.Windows.Forms.TextBox txtRespostaAnterior;
        private System.Windows.Forms.Label lblRespostaAnterior;
        private System.Windows.Forms.Button btnAlterarRegime;
        private System.Windows.Forms.TextBox txtConvenio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCopia;
    }
}