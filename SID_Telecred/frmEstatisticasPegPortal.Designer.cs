namespace SID_Telecred
{
    partial class frmEstatisticasPegPortal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEstatisticasPegPortal));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdEstatisticas = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbTodos = new System.Windows.Forms.RadioButton();
            this.rdbFechados = new System.Windows.Forms.RadioButton();
            this.rdbEmDigitacao = new System.Windows.Forms.RadioButton();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFim = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCopiar = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEstatisticas)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdEstatisticas);
            this.groupBox1.Location = new System.Drawing.Point(12, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1013, 332);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Andamento Digitação Pegs";
            // 
            // grdEstatisticas
            // 
            this.grdEstatisticas.AllowUserToAddRows = false;
            this.grdEstatisticas.AllowUserToDeleteRows = false;
            this.grdEstatisticas.AllowUserToResizeColumns = false;
            this.grdEstatisticas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdEstatisticas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdEstatisticas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdEstatisticas.Location = new System.Drawing.Point(6, 19);
            this.grdEstatisticas.Name = "grdEstatisticas";
            this.grdEstatisticas.ReadOnly = true;
            this.grdEstatisticas.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.grdEstatisticas.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.grdEstatisticas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdEstatisticas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdEstatisticas.Size = new System.Drawing.Size(1001, 306);
            this.grdEstatisticas.TabIndex = 17;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbTodos);
            this.groupBox2.Controls.Add(this.rdbFechados);
            this.groupBox2.Controls.Add(this.rdbEmDigitacao);
            this.groupBox2.Location = new System.Drawing.Point(294, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(438, 41);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Opções de Filtro";
            // 
            // rdbTodos
            // 
            this.rdbTodos.AutoSize = true;
            this.rdbTodos.Location = new System.Drawing.Point(372, 16);
            this.rdbTodos.Name = "rdbTodos";
            this.rdbTodos.Size = new System.Drawing.Size(55, 17);
            this.rdbTodos.TabIndex = 2;
            this.rdbTodos.Text = "Todos";
            this.rdbTodos.UseVisualStyleBackColor = true;
            this.rdbTodos.CheckedChanged += new System.EventHandler(this.rdbTodos_CheckedChanged);
            // 
            // rdbFechados
            // 
            this.rdbFechados.AutoSize = true;
            this.rdbFechados.Location = new System.Drawing.Point(187, 16);
            this.rdbFechados.Name = "rdbFechados";
            this.rdbFechados.Size = new System.Drawing.Size(148, 17);
            this.rdbFechados.TabIndex = 1;
            this.rdbFechados.Text = "Somente datas finalizadas";
            this.rdbFechados.UseVisualStyleBackColor = true;
            this.rdbFechados.CheckedChanged += new System.EventHandler(this.rdbFechados_CheckedChanged);
            // 
            // rdbEmDigitacao
            // 
            this.rdbEmDigitacao.AutoSize = true;
            this.rdbEmDigitacao.Checked = true;
            this.rdbEmDigitacao.Location = new System.Drawing.Point(9, 16);
            this.rdbEmDigitacao.Name = "rdbEmDigitacao";
            this.rdbEmDigitacao.Size = new System.Drawing.Size(159, 17);
            this.rdbEmDigitacao.TabIndex = 0;
            this.rdbEmDigitacao.TabStop = true;
            this.rdbEmDigitacao.Text = "Somente datas em digitação";
            this.rdbEmDigitacao.UseVisualStyleBackColor = true;
            this.rdbEmDigitacao.CheckedChanged += new System.EventHandler(this.rdbEmDigitacao_CheckedChanged);
            // 
            // dtpInicio
            // 
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(84, 24);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(85, 20);
            this.dtpInicio.TabIndex = 23;
            this.dtpInicio.ValueChanged += new System.EventHandler(this.dtpInicio_ValueChanged);
            // 
            // dtpFim
            // 
            this.dtpFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFim.Location = new System.Drawing.Point(203, 24);
            this.dtpFim.Name = "dtpFim";
            this.dtpFim.Size = new System.Drawing.Size(85, 20);
            this.dtpFim.TabIndex = 24;
            this.dtpFim.ValueChanged += new System.EventHandler(this.dtpFim_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "até";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Período de";
            // 
            // btnCopiar
            // 
            this.btnCopiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnCopiar.Image = global::SID_Telecred.Properties.Resources.Excel;
            this.btnCopiar.Location = new System.Drawing.Point(448, 391);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(141, 40);
            this.btnCopiar.TabIndex = 27;
            this.btnCopiar.Text = "Copiar &Dados";
            this.btnCopiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCopiar.UseVisualStyleBackColor = true;
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnAtualizar.Image = global::SID_Telecred.Properties.Resources.DocumentRefresh;
            this.btnAtualizar.Location = new System.Drawing.Point(11, 391);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(141, 40);
            this.btnAtualizar.TabIndex = 21;
            this.btnAtualizar.Text = "&Atualizar";
            this.btnAtualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnFechar.Image = global::SID_Telecred.Properties.Resources.delete;
            this.btnFechar.Location = new System.Drawing.Point(885, 391);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(141, 40);
            this.btnFechar.TabIndex = 20;
            this.btnFechar.Text = "&Cancelar";
            this.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // frmEstatisticasPegPortal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 439);
            this.Controls.Add(this.btnCopiar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFim);
            this.Controls.Add(this.dtpInicio);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEstatisticasPegPortal";
            this.Text = "Estatísticas Peg Portal";
            this.Load += new System.EventHandler(this.frmEstatisticasPegPortal_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEstatisticas)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grdEstatisticas;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbTodos;
        private System.Windows.Forms.RadioButton rdbFechados;
        private System.Windows.Forms.RadioButton rdbEmDigitacao;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DateTimePicker dtpFim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCopiar;
    }
}