namespace SID_Telecred
{
    partial class frmManutencaoLotes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManutencaoLotes));
            this.grpLotes = new System.Windows.Forms.GroupBox();
            this.trwLotes = new System.Windows.Forms.TreeView();
            this.grpStatusLote = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.cboServico = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnSelTodos = new System.Windows.Forms.Button();
            this.btnDesmTodos = new System.Windows.Forms.Button();
            this.cboCaixas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpLotes.SuspendLayout();
            this.grpStatusLote.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpLotes
            // 
            this.grpLotes.Controls.Add(this.trwLotes);
            this.grpLotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.grpLotes.Location = new System.Drawing.Point(6, 72);
            this.grpLotes.Name = "grpLotes";
            this.grpLotes.Size = new System.Drawing.Size(349, 440);
            this.grpLotes.TabIndex = 1;
            this.grpLotes.TabStop = false;
            this.grpLotes.Text = "Lotes";
            // 
            // trwLotes
            // 
            this.trwLotes.CheckBoxes = true;
            this.trwLotes.HideSelection = false;
            this.trwLotes.Location = new System.Drawing.Point(6, 17);
            this.trwLotes.Name = "trwLotes";
            this.trwLotes.ShowNodeToolTips = true;
            this.trwLotes.ShowPlusMinus = false;
            this.trwLotes.Size = new System.Drawing.Size(338, 412);
            this.trwLotes.TabIndex = 0;
            // 
            // grpStatusLote
            // 
            this.grpStatusLote.Controls.Add(this.lblStatus);
            this.grpStatusLote.Controls.Add(this.cboStatus);
            this.grpStatusLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.grpStatusLote.Location = new System.Drawing.Point(361, 12);
            this.grpStatusLote.Name = "grpStatusLote";
            this.grpStatusLote.Size = new System.Drawing.Size(288, 75);
            this.grpStatusLote.TabIndex = 2;
            this.grpStatusLote.TabStop = false;
            this.grpStatusLote.Text = "Status Lote";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblStatus.Location = new System.Drawing.Point(12, 22);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(81, 16);
            this.lblStatus.TabIndex = 57;
            this.lblStatus.Text = "Novo Status";
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(15, 42);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(267, 24);
            this.cboStatus.TabIndex = 0;
            // 
            // cboServico
            // 
            this.cboServico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboServico.FormattingEnabled = true;
            this.cboServico.Location = new System.Drawing.Point(72, 16);
            this.cboServico.Name = "cboServico";
            this.cboServico.Size = new System.Drawing.Size(283, 24);
            this.cboServico.TabIndex = 0;
            this.cboServico.SelectedIndexChanged += new System.EventHandler(this.cboServico_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.Location = new System.Drawing.Point(12, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 53;
            this.label2.Text = "Serviço";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnFechar
            // 
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnFechar.Image = global::SID_Telecred.Properties.Resources.delete;
            this.btnFechar.Location = new System.Drawing.Point(361, 472);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(141, 40);
            this.btnFechar.TabIndex = 6;
            this.btnFechar.Text = "&Cancelar";
            this.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnGravar
            // 
            this.btnGravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnGravar.Image = global::SID_Telecred.Properties.Resources.FloppyDisks;
            this.btnGravar.Location = new System.Drawing.Point(508, 472);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(141, 40);
            this.btnGravar.TabIndex = 5;
            this.btnGravar.Text = "&Gravar Lote";
            this.btnGravar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnSelTodos
            // 
            this.btnSelTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnSelTodos.Image = global::SID_Telecred.Properties.Resources.LightBrowBoxOk;
            this.btnSelTodos.Location = new System.Drawing.Point(361, 93);
            this.btnSelTodos.Name = "btnSelTodos";
            this.btnSelTodos.Size = new System.Drawing.Size(141, 40);
            this.btnSelTodos.TabIndex = 3;
            this.btnSelTodos.Text = "&Selecionar Todos";
            this.btnSelTodos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelTodos.UseVisualStyleBackColor = true;
            this.btnSelTodos.Click += new System.EventHandler(this.btnSelTodos_Click);
            // 
            // btnDesmTodos
            // 
            this.btnDesmTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnDesmTodos.Image = global::SID_Telecred.Properties.Resources.LightBrowBoxRem;
            this.btnDesmTodos.Location = new System.Drawing.Point(508, 93);
            this.btnDesmTodos.Name = "btnDesmTodos";
            this.btnDesmTodos.Size = new System.Drawing.Size(141, 40);
            this.btnDesmTodos.TabIndex = 4;
            this.btnDesmTodos.Text = "&Desmarcar Todos";
            this.btnDesmTodos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDesmTodos.UseVisualStyleBackColor = true;
            this.btnDesmTodos.Click += new System.EventHandler(this.btnDesmTodos_Click);
            // 
            // cboCaixas
            // 
            this.cboCaixas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCaixas.FormattingEnabled = true;
            this.cboCaixas.Location = new System.Drawing.Point(72, 46);
            this.cboCaixas.Name = "cboCaixas";
            this.cboCaixas.Size = new System.Drawing.Size(283, 21);
            this.cboCaixas.TabIndex = 54;
            this.cboCaixas.SelectedIndexChanged += new System.EventHandler(this.cboCaixas_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 55;
            this.label1.Text = "Caixa";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmManutencaoLotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 524);
            this.Controls.Add(this.cboCaixas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDesmTodos);
            this.Controls.Add(this.btnSelTodos);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.cboServico);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grpStatusLote);
            this.Controls.Add(this.grpLotes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManutencaoLotes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manutenção de Lotes";
            this.Load += new System.EventHandler(this.frmManutencaoLotes_Load);
            this.grpLotes.ResumeLayout(false);
            this.grpStatusLote.ResumeLayout(false);
            this.grpStatusLote.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpLotes;
        private System.Windows.Forms.TreeView trwLotes;
        private System.Windows.Forms.GroupBox grpStatusLote;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.ComboBox cboServico;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnSelTodos;
        private System.Windows.Forms.Button btnDesmTodos;
        private System.Windows.Forms.ComboBox cboCaixas;
        private System.Windows.Forms.Label label1;

    }
}