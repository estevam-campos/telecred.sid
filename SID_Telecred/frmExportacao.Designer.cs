namespace SID_Telecred
{
    partial class frmExportacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExportacao));
            this.cboServico = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pgbProgresso = new System.Windows.Forms.ProgressBar();
            this.tmrExportar = new System.Windows.Forms.Timer(this.components);
            this.groDisponiveis = new System.Windows.Forms.GroupBox();
            this.lstDisponiveis = new System.Windows.Forms.ListBox();
            this.grpSelecionados = new System.Windows.Forms.GroupBox();
            this.lstSelecionados = new System.Windows.Forms.ListBox();
            this.btnAddTodos = new System.Windows.Forms.Button();
            this.btnRemTodos = new System.Windows.Forms.Button();
            this.btnRemLote = new System.Windows.Forms.Button();
            this.btnAddLote = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.cboCaixas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTodos = new System.Windows.Forms.Button();
            this.chkFormalizacao = new System.Windows.Forms.CheckBox();
            this.grpRegistros = new System.Windows.Forms.GroupBox();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.chkExportados = new System.Windows.Forms.CheckBox();
            this.groDisponiveis.SuspendLayout();
            this.grpSelecionados.SuspendLayout();
            this.grpRegistros.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboServico
            // 
            this.cboServico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboServico.FormattingEnabled = true;
            this.cboServico.Location = new System.Drawing.Point(73, 12);
            this.cboServico.Name = "cboServico";
            this.cboServico.Size = new System.Drawing.Size(204, 24);
            this.cboServico.TabIndex = 0;
            this.cboServico.SelectedIndexChanged += new System.EventHandler(this.cboServico_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.Location = new System.Drawing.Point(11, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 33;
            this.label2.Text = "Serviço";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pgbProgresso
            // 
            this.pgbProgresso.Location = new System.Drawing.Point(14, 460);
            this.pgbProgresso.Name = "pgbProgresso";
            this.pgbProgresso.Size = new System.Drawing.Size(398, 12);
            this.pgbProgresso.TabIndex = 42;
            // 
            // tmrExportar
            // 
            this.tmrExportar.Interval = 1000;
            this.tmrExportar.Tick += new System.EventHandler(this.tmrExportar_Tick);
            // 
            // groDisponiveis
            // 
            this.groDisponiveis.Controls.Add(this.lstDisponiveis);
            this.groDisponiveis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.groDisponiveis.Location = new System.Drawing.Point(14, 90);
            this.groDisponiveis.Name = "groDisponiveis";
            this.groDisponiveis.Size = new System.Drawing.Size(172, 318);
            this.groDisponiveis.TabIndex = 2;
            this.groDisponiveis.TabStop = false;
            this.groDisponiveis.Text = "Lotes Disponíveis";
            // 
            // lstDisponiveis
            // 
            this.lstDisponiveis.FormattingEnabled = true;
            this.lstDisponiveis.ItemHeight = 16;
            this.lstDisponiveis.Location = new System.Drawing.Point(6, 22);
            this.lstDisponiveis.Name = "lstDisponiveis";
            this.lstDisponiveis.Size = new System.Drawing.Size(160, 292);
            this.lstDisponiveis.Sorted = true;
            this.lstDisponiveis.TabIndex = 0;
            this.lstDisponiveis.DoubleClick += new System.EventHandler(this.lstDisponiveis_DoubleClick);
            // 
            // grpSelecionados
            // 
            this.grpSelecionados.Controls.Add(this.lstSelecionados);
            this.grpSelecionados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.grpSelecionados.Location = new System.Drawing.Point(240, 90);
            this.grpSelecionados.Name = "grpSelecionados";
            this.grpSelecionados.Size = new System.Drawing.Size(191, 318);
            this.grpSelecionados.TabIndex = 7;
            this.grpSelecionados.TabStop = false;
            this.grpSelecionados.Text = "Lotes Selecionados";
            // 
            // lstSelecionados
            // 
            this.lstSelecionados.FormattingEnabled = true;
            this.lstSelecionados.ItemHeight = 16;
            this.lstSelecionados.Location = new System.Drawing.Point(6, 22);
            this.lstSelecionados.Name = "lstSelecionados";
            this.lstSelecionados.Size = new System.Drawing.Size(179, 292);
            this.lstSelecionados.Sorted = true;
            this.lstSelecionados.TabIndex = 0;
            this.lstSelecionados.DoubleClick += new System.EventHandler(this.lstSelecionados_DoubleClick);
            // 
            // btnAddTodos
            // 
            this.btnAddTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTodos.Image = global::SID_Telecred.Properties.Resources.AddAll;
            this.btnAddTodos.Location = new System.Drawing.Point(193, 317);
            this.btnAddTodos.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddTodos.Name = "btnAddTodos";
            this.btnAddTodos.Size = new System.Drawing.Size(40, 40);
            this.btnAddTodos.TabIndex = 5;
            this.btnAddTodos.UseVisualStyleBackColor = true;
            this.btnAddTodos.Click += new System.EventHandler(this.btnAddTodos_Click);
            // 
            // btnRemTodos
            // 
            this.btnRemTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemTodos.Image = global::SID_Telecred.Properties.Resources.RemAll;
            this.btnRemTodos.Location = new System.Drawing.Point(193, 365);
            this.btnRemTodos.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemTodos.Name = "btnRemTodos";
            this.btnRemTodos.Size = new System.Drawing.Size(40, 40);
            this.btnRemTodos.TabIndex = 6;
            this.btnRemTodos.UseVisualStyleBackColor = true;
            this.btnRemTodos.Click += new System.EventHandler(this.btnRemTodos_Click);
            // 
            // btnRemLote
            // 
            this.btnRemLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemLote.Image = global::SID_Telecred.Properties.Resources.Remove;
            this.btnRemLote.Location = new System.Drawing.Point(193, 160);
            this.btnRemLote.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemLote.Name = "btnRemLote";
            this.btnRemLote.Size = new System.Drawing.Size(40, 40);
            this.btnRemLote.TabIndex = 4;
            this.btnRemLote.UseVisualStyleBackColor = true;
            this.btnRemLote.Click += new System.EventHandler(this.btnRemLote_Click);
            // 
            // btnAddLote
            // 
            this.btnAddLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddLote.Image = global::SID_Telecred.Properties.Resources.Add_1;
            this.btnAddLote.Location = new System.Drawing.Point(193, 112);
            this.btnAddLote.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddLote.Name = "btnAddLote";
            this.btnAddLote.Size = new System.Drawing.Size(40, 40);
            this.btnAddLote.TabIndex = 3;
            this.btnAddLote.UseVisualStyleBackColor = true;
            this.btnAddLote.Click += new System.EventHandler(this.btnAddLote_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnFechar.Image = global::SID_Telecred.Properties.Resources.delete;
            this.btnFechar.Location = new System.Drawing.Point(12, 414);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(141, 40);
            this.btnFechar.TabIndex = 9;
            this.btnFechar.Text = "&Cancelar";
            this.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnExportar.Image = global::SID_Telecred.Properties.Resources.DocumentOut;
            this.btnExportar.Location = new System.Drawing.Point(290, 414);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(141, 40);
            this.btnExportar.TabIndex = 8;
            this.btnExportar.Text = "&Exportar Registros";
            this.btnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // cboCaixas
            // 
            this.cboCaixas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCaixas.FormattingEnabled = true;
            this.cboCaixas.Location = new System.Drawing.Point(73, 42);
            this.cboCaixas.Name = "cboCaixas";
            this.cboCaixas.Size = new System.Drawing.Size(204, 21);
            this.cboCaixas.TabIndex = 1;
            this.cboCaixas.SelectedIndexChanged += new System.EventHandler(this.cboCaixas_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 50;
            this.label1.Text = "Caixa";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnTodos
            // 
            this.btnTodos.Enabled = false;
            this.btnTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnTodos.Image = global::SID_Telecred.Properties.Resources.MetapackageOk;
            this.btnTodos.Location = new System.Drawing.Point(283, 12);
            this.btnTodos.Name = "btnTodos";
            this.btnTodos.Size = new System.Drawing.Size(142, 51);
            this.btnTodos.TabIndex = 62;
            this.btnTodos.Text = "Selecionar todos os lotes";
            this.btnTodos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTodos.UseVisualStyleBackColor = true;
            this.btnTodos.Click += new System.EventHandler(this.btnTodos_Click);
            // 
            // chkFormalizacao
            // 
            this.chkFormalizacao.AutoSize = true;
            this.chkFormalizacao.Checked = true;
            this.chkFormalizacao.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFormalizacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkFormalizacao.Location = new System.Drawing.Point(23, 69);
            this.chkFormalizacao.Name = "chkFormalizacao";
            this.chkFormalizacao.Size = new System.Drawing.Size(214, 20);
            this.chkFormalizacao.TabIndex = 63;
            this.chkFormalizacao.Text = "Gerar Arquivo de Formalização";
            this.chkFormalizacao.UseVisualStyleBackColor = true;
            // 
            // grpRegistros
            // 
            this.grpRegistros.Controls.Add(this.lblRegistros);
            this.grpRegistros.Location = new System.Drawing.Point(159, 414);
            this.grpRegistros.Name = "grpRegistros";
            this.grpRegistros.Size = new System.Drawing.Size(125, 40);
            this.grpRegistros.TabIndex = 64;
            this.grpRegistros.TabStop = false;
            this.grpRegistros.Text = "Lotes Exportados";
            // 
            // lblRegistros
            // 
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblRegistros.Location = new System.Drawing.Point(6, 16);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(119, 21);
            this.lblRegistros.TabIndex = 34;
            this.lblRegistros.Text = "0 de 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkExportados
            // 
            this.chkExportados.AutoSize = true;
            this.chkExportados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkExportados.Location = new System.Drawing.Point(240, 69);
            this.chkExportados.Name = "chkExportados";
            this.chkExportados.Size = new System.Drawing.Size(197, 20);
            this.chkExportados.TabIndex = 65;
            this.chkExportados.Text = "Somente Caixas Exportadas";
            this.chkExportados.UseVisualStyleBackColor = true;
            this.chkExportados.CheckedChanged += new System.EventHandler(this.chkExportados_CheckedChanged);
            // 
            // frmExportacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 458);
            this.Controls.Add(this.chkExportados);
            this.Controls.Add(this.grpRegistros);
            this.Controls.Add(this.chkFormalizacao);
            this.Controls.Add(this.btnTodos);
            this.Controls.Add(this.cboCaixas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddTodos);
            this.Controls.Add(this.btnRemTodos);
            this.Controls.Add(this.btnRemLote);
            this.Controls.Add(this.btnAddLote);
            this.Controls.Add(this.grpSelecionados);
            this.Controls.Add(this.groDisponiveis);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.pgbProgresso);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.cboServico);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExportacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exportação de Dados";
            this.Load += new System.EventHandler(this.frmExportacao_Load);
            this.groDisponiveis.ResumeLayout(false);
            this.grpSelecionados.ResumeLayout(false);
            this.grpRegistros.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboServico;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.ProgressBar pgbProgresso;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Timer tmrExportar;
        private System.Windows.Forms.GroupBox groDisponiveis;
        private System.Windows.Forms.ListBox lstDisponiveis;
        private System.Windows.Forms.GroupBox grpSelecionados;
        private System.Windows.Forms.ListBox lstSelecionados;
        private System.Windows.Forms.Button btnAddTodos;
        private System.Windows.Forms.Button btnRemTodos;
        private System.Windows.Forms.Button btnRemLote;
        private System.Windows.Forms.Button btnAddLote;
        private System.Windows.Forms.ComboBox cboCaixas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTodos;
        private System.Windows.Forms.CheckBox chkFormalizacao;
        private System.Windows.Forms.GroupBox grpRegistros;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.CheckBox chkExportados;
    }
}