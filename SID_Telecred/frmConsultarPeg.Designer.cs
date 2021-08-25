namespace SID_Telecred
{
    partial class frmConsultarPeg
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtpDataPagamentoIdeal = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbMigrado = new System.Windows.Forms.RadioButton();
            this.rdbDigitado = new System.Windows.Forms.RadioButton();
            this.rdbTodos = new System.Windows.Forms.RadioButton();
            this.rdbEmDigitacao = new System.Windows.Forms.RadioButton();
            this.rdbDisponivel = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdPegs = new System.Windows.Forms.DataGridView();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblQtde = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPegs)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpDataPagamentoIdeal
            // 
            this.dtpDataPagamentoIdeal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataPagamentoIdeal.Location = new System.Drawing.Point(129, 18);
            this.dtpDataPagamentoIdeal.Name = "dtpDataPagamentoIdeal";
            this.dtpDataPagamentoIdeal.Size = new System.Drawing.Size(85, 20);
            this.dtpDataPagamentoIdeal.TabIndex = 33;
            this.dtpDataPagamentoIdeal.ValueChanged += new System.EventHandler(this.dtpDataPagamentoIdeal_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Data Pagamento Ideal";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbMigrado);
            this.groupBox2.Controls.Add(this.rdbDigitado);
            this.groupBox2.Controls.Add(this.rdbTodos);
            this.groupBox2.Controls.Add(this.rdbEmDigitacao);
            this.groupBox2.Controls.Add(this.rdbDisponivel);
            this.groupBox2.Location = new System.Drawing.Point(220, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(438, 41);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Opções de Filtro - Status Peg";
            // 
            // rdbMigrado
            // 
            this.rdbMigrado.AutoSize = true;
            this.rdbMigrado.Location = new System.Drawing.Point(291, 16);
            this.rdbMigrado.Name = "rdbMigrado";
            this.rdbMigrado.Size = new System.Drawing.Size(63, 17);
            this.rdbMigrado.TabIndex = 4;
            this.rdbMigrado.Text = "Migrado";
            this.rdbMigrado.UseVisualStyleBackColor = true;
            this.rdbMigrado.CheckedChanged += new System.EventHandler(this.rdbMigrado_CheckedChanged);
            // 
            // rdbDigitado
            // 
            this.rdbDigitado.AutoSize = true;
            this.rdbDigitado.Location = new System.Drawing.Point(211, 16);
            this.rdbDigitado.Name = "rdbDigitado";
            this.rdbDigitado.Size = new System.Drawing.Size(64, 17);
            this.rdbDigitado.TabIndex = 3;
            this.rdbDigitado.Text = "Digitado";
            this.rdbDigitado.UseVisualStyleBackColor = true;
            this.rdbDigitado.CheckedChanged += new System.EventHandler(this.rdbDigitado_CheckedChanged);
            // 
            // rdbTodos
            // 
            this.rdbTodos.AutoSize = true;
            this.rdbTodos.Location = new System.Drawing.Point(370, 16);
            this.rdbTodos.Name = "rdbTodos";
            this.rdbTodos.Size = new System.Drawing.Size(55, 17);
            this.rdbTodos.TabIndex = 2;
            this.rdbTodos.Text = "Todos";
            this.rdbTodos.UseVisualStyleBackColor = true;
            this.rdbTodos.CheckedChanged += new System.EventHandler(this.rdbTodos_CheckedChanged);
            // 
            // rdbEmDigitacao
            // 
            this.rdbEmDigitacao.AutoSize = true;
            this.rdbEmDigitacao.Location = new System.Drawing.Point(107, 16);
            this.rdbEmDigitacao.Name = "rdbEmDigitacao";
            this.rdbEmDigitacao.Size = new System.Drawing.Size(88, 17);
            this.rdbEmDigitacao.TabIndex = 1;
            this.rdbEmDigitacao.Text = "Em Digitação";
            this.rdbEmDigitacao.UseVisualStyleBackColor = true;
            this.rdbEmDigitacao.CheckedChanged += new System.EventHandler(this.rdbEmDigitacao_CheckedChanged);
            // 
            // rdbDisponivel
            // 
            this.rdbDisponivel.AutoSize = true;
            this.rdbDisponivel.Checked = true;
            this.rdbDisponivel.Location = new System.Drawing.Point(15, 16);
            this.rdbDisponivel.Name = "rdbDisponivel";
            this.rdbDisponivel.Size = new System.Drawing.Size(76, 17);
            this.rdbDisponivel.TabIndex = 0;
            this.rdbDisponivel.TabStop = true;
            this.rdbDisponivel.Text = "Disponível";
            this.rdbDisponivel.UseVisualStyleBackColor = true;
            this.rdbDisponivel.CheckedChanged += new System.EventHandler(this.rdbDisponivel_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdPegs);
            this.groupBox1.Location = new System.Drawing.Point(10, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1162, 332);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resultado da Busca";
            // 
            // grdPegs
            // 
            this.grdPegs.AllowUserToAddRows = false;
            this.grdPegs.AllowUserToDeleteRows = false;
            this.grdPegs.AllowUserToResizeColumns = false;
            this.grdPegs.AllowUserToResizeRows = false;
            this.grdPegs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdPegs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdPegs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPegs.Location = new System.Drawing.Point(4, 19);
            this.grdPegs.Name = "grdPegs";
            this.grdPegs.ReadOnly = true;
            this.grdPegs.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.grdPegs.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.grdPegs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPegs.Size = new System.Drawing.Size(1152, 306);
            this.grdPegs.TabIndex = 17;
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnAtualizar.Image = global::SID_Telecred.Properties.Resources.DocumentRefresh;
            this.btnAtualizar.Location = new System.Drawing.Point(10, 385);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(141, 40);
            this.btnAtualizar.TabIndex = 39;
            this.btnAtualizar.Text = "&Atualizar";
            this.btnAtualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnFechar.Image = global::SID_Telecred.Properties.Resources.delete;
            this.btnFechar.Location = new System.Drawing.Point(1025, 385);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(141, 40);
            this.btnFechar.TabIndex = 40;
            this.btnFechar.Text = "&Cancelar";
            this.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(969, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Pegs Localizadas:";
            // 
            // lblQtde
            // 
            this.lblQtde.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtde.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblQtde.Location = new System.Drawing.Point(1068, 6);
            this.lblQtde.Name = "lblQtde";
            this.lblQtde.Size = new System.Drawing.Size(102, 41);
            this.lblQtde.TabIndex = 42;
            this.lblQtde.Text = "0";
            this.lblQtde.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmConsultarPeg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 433);
            this.Controls.Add(this.lblQtde);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpDataPagamentoIdeal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConsultarPeg";
            this.Text = "Consulta de PEGs";
            this.Load += new System.EventHandler(this.frmConsultarPeg_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPegs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDataPagamentoIdeal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbMigrado;
        private System.Windows.Forms.RadioButton rdbDigitado;
        private System.Windows.Forms.RadioButton rdbTodos;
        private System.Windows.Forms.RadioButton rdbEmDigitacao;
        private System.Windows.Forms.RadioButton rdbDisponivel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grdPegs;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblQtde;
    }
}