namespace SID_Telecred
{
    partial class frmExpurgo
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
            this.grpRegistros = new System.Windows.Forms.GroupBox();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.lstSelecionados = new System.Windows.Forms.ListBox();
            this.btnAddTodos = new System.Windows.Forms.Button();
            this.btnRemTodos = new System.Windows.Forms.Button();
            this.lstDisponiveis = new System.Windows.Forms.ListBox();
            this.btnAddCaixa = new System.Windows.Forms.Button();
            this.groDisponiveis = new System.Windows.Forms.GroupBox();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnRemCaixa = new System.Windows.Forms.Button();
            this.grpSelecionados = new System.Windows.Forms.GroupBox();
            this.cboServico = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpRegistros.SuspendLayout();
            this.groDisponiveis.SuspendLayout();
            this.grpSelecionados.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpRegistros
            // 
            this.grpRegistros.Controls.Add(this.lblRegistros);
            this.grpRegistros.Location = new System.Drawing.Point(159, 366);
            this.grpRegistros.Name = "grpRegistros";
            this.grpRegistros.Size = new System.Drawing.Size(125, 40);
            this.grpRegistros.TabIndex = 81;
            this.grpRegistros.TabStop = false;
            this.grpRegistros.Text = "Caixas Expurgadas";
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
            this.btnAddTodos.Location = new System.Drawing.Point(193, 269);
            this.btnAddTodos.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddTodos.Name = "btnAddTodos";
            this.btnAddTodos.Size = new System.Drawing.Size(40, 40);
            this.btnAddTodos.TabIndex = 71;
            this.btnAddTodos.UseVisualStyleBackColor = true;
            this.btnAddTodos.Click += new System.EventHandler(this.btnAddTodos_Click);
            // 
            // btnRemTodos
            // 
            this.btnRemTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemTodos.Image = global::SID_Telecred.Properties.Resources.RemAll;
            this.btnRemTodos.Location = new System.Drawing.Point(193, 317);
            this.btnRemTodos.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemTodos.Name = "btnRemTodos";
            this.btnRemTodos.Size = new System.Drawing.Size(40, 40);
            this.btnRemTodos.TabIndex = 72;
            this.btnRemTodos.UseVisualStyleBackColor = true;
            this.btnRemTodos.Click += new System.EventHandler(this.btnRemTodos_Click);
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
            // btnAddCaixa
            // 
            this.btnAddCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCaixa.Image = global::SID_Telecred.Properties.Resources.Add_1;
            this.btnAddCaixa.Location = new System.Drawing.Point(193, 64);
            this.btnAddCaixa.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddCaixa.Name = "btnAddCaixa";
            this.btnAddCaixa.Size = new System.Drawing.Size(40, 40);
            this.btnAddCaixa.TabIndex = 69;
            this.btnAddCaixa.UseVisualStyleBackColor = true;
            this.btnAddCaixa.Click += new System.EventHandler(this.btnAddCaixa_Click);
            // 
            // groDisponiveis
            // 
            this.groDisponiveis.Controls.Add(this.lstDisponiveis);
            this.groDisponiveis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.groDisponiveis.Location = new System.Drawing.Point(14, 42);
            this.groDisponiveis.Name = "groDisponiveis";
            this.groDisponiveis.Size = new System.Drawing.Size(172, 318);
            this.groDisponiveis.TabIndex = 68;
            this.groDisponiveis.TabStop = false;
            this.groDisponiveis.Text = "Caixas Disponíveis";
            // 
            // btnFechar
            // 
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnFechar.Image = global::SID_Telecred.Properties.Resources.delete;
            this.btnFechar.Location = new System.Drawing.Point(12, 366);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(141, 40);
            this.btnFechar.TabIndex = 75;
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
            this.btnExportar.Location = new System.Drawing.Point(290, 366);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(141, 40);
            this.btnExportar.TabIndex = 74;
            this.btnExportar.Text = "&Iniciar Expurgo";
            this.btnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnRemCaixa
            // 
            this.btnRemCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemCaixa.Image = global::SID_Telecred.Properties.Resources.Remove;
            this.btnRemCaixa.Location = new System.Drawing.Point(193, 112);
            this.btnRemCaixa.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemCaixa.Name = "btnRemCaixa";
            this.btnRemCaixa.Size = new System.Drawing.Size(40, 40);
            this.btnRemCaixa.TabIndex = 70;
            this.btnRemCaixa.UseVisualStyleBackColor = true;
            this.btnRemCaixa.Click += new System.EventHandler(this.btnRemCaixa_Click);
            // 
            // grpSelecionados
            // 
            this.grpSelecionados.Controls.Add(this.lstSelecionados);
            this.grpSelecionados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.grpSelecionados.Location = new System.Drawing.Point(240, 42);
            this.grpSelecionados.Name = "grpSelecionados";
            this.grpSelecionados.Size = new System.Drawing.Size(191, 318);
            this.grpSelecionados.TabIndex = 73;
            this.grpSelecionados.TabStop = false;
            this.grpSelecionados.Text = "Caixas Selecionadas";
            // 
            // cboServico
            // 
            this.cboServico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboServico.FormattingEnabled = true;
            this.cboServico.Location = new System.Drawing.Point(74, 6);
            this.cboServico.Name = "cboServico";
            this.cboServico.Size = new System.Drawing.Size(357, 24);
            this.cboServico.TabIndex = 66;
            this.cboServico.SelectedIndexChanged += new System.EventHandler(this.cboServico_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 76;
            this.label2.Text = "Serviço";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmExpurgo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 413);
            this.Controls.Add(this.grpRegistros);
            this.Controls.Add(this.btnAddTodos);
            this.Controls.Add(this.btnRemTodos);
            this.Controls.Add(this.btnAddCaixa);
            this.Controls.Add(this.groDisponiveis);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnRemCaixa);
            this.Controls.Add(this.grpSelecionados);
            this.Controls.Add(this.cboServico);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExpurgo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expurgo";
            this.Load += new System.EventHandler(this.frmExpurgo_Load);
            this.grpRegistros.ResumeLayout(false);
            this.groDisponiveis.ResumeLayout(false);
            this.grpSelecionados.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpRegistros;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.ListBox lstSelecionados;
        private System.Windows.Forms.Button btnAddTodos;
        private System.Windows.Forms.Button btnRemTodos;
        private System.Windows.Forms.ListBox lstDisponiveis;
        private System.Windows.Forms.Button btnAddCaixa;
        private System.Windows.Forms.GroupBox groDisponiveis;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnRemCaixa;
        private System.Windows.Forms.GroupBox grpSelecionados;
        private System.Windows.Forms.ComboBox cboServico;
        private System.Windows.Forms.Label label2;
    }
}