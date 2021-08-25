namespace SID_Telecred
{
    partial class frmServicos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServicos));
            this.cboServico = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLote = new System.Windows.Forms.Label();
            this.cboLote = new System.Windows.Forms.ComboBox();
            this.btnAbrirLote = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAlterarStatus = new System.Windows.Forms.CheckBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnAlterarStatus = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboServico
            // 
            this.cboServico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboServico.FormattingEnabled = true;
            this.cboServico.Location = new System.Drawing.Point(76, 12);
            this.cboServico.Name = "cboServico";
            this.cboServico.Size = new System.Drawing.Size(239, 24);
            this.cboServico.TabIndex = 27;
            this.cboServico.SelectedIndexChanged += new System.EventHandler(this.cboServico_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.Location = new System.Drawing.Point(9, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 26;
            this.label2.Text = "Serviço";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLote
            // 
            this.lblLote.AutoSize = true;
            this.lblLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblLote.Location = new System.Drawing.Point(31, 50);
            this.lblLote.Name = "lblLote";
            this.lblLote.Size = new System.Drawing.Size(34, 16);
            this.lblLote.TabIndex = 25;
            this.lblLote.Text = "Lote";
            this.lblLote.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboLote
            // 
            this.cboLote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboLote.FormattingEnabled = true;
            this.cboLote.Location = new System.Drawing.Point(76, 47);
            this.cboLote.Name = "cboLote";
            this.cboLote.Size = new System.Drawing.Size(239, 24);
            this.cboLote.TabIndex = 28;
            // 
            // btnAbrirLote
            // 
            this.btnAbrirLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnAbrirLote.Image = global::SID_Telecred.Properties.Resources.DocumentEdit;
            this.btnAbrirLote.Location = new System.Drawing.Point(321, 12);
            this.btnAbrirLote.Name = "btnAbrirLote";
            this.btnAbrirLote.Size = new System.Drawing.Size(114, 58);
            this.btnAbrirLote.TabIndex = 29;
            this.btnAbrirLote.Text = "Abrir Lote";
            this.btnAbrirLote.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAbrirLote.UseVisualStyleBackColor = true;
            this.btnAbrirLote.Click += new System.EventHandler(this.btnAbrirLote_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAlterarStatus);
            this.groupBox1.Controls.Add(this.cboStatus);
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Controls.Add(this.btnAlterarStatus);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(12, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(423, 94);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            // 
            // chkAlterarStatus
            // 
            this.chkAlterarStatus.AutoSize = true;
            this.chkAlterarStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkAlterarStatus.Location = new System.Drawing.Point(16, 19);
            this.chkAlterarStatus.Name = "chkAlterarStatus";
            this.chkAlterarStatus.Size = new System.Drawing.Size(106, 20);
            this.chkAlterarStatus.TabIndex = 36;
            this.chkAlterarStatus.Text = "Alterar Status";
            this.chkAlterarStatus.UseVisualStyleBackColor = true;
            this.chkAlterarStatus.CheckedChanged += new System.EventHandler(this.chkAlterarStatus_CheckedChanged);
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(111, 50);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(172, 24);
            this.cboStatus.TabIndex = 35;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblStatus.Location = new System.Drawing.Point(13, 53);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(81, 16);
            this.lblStatus.TabIndex = 34;
            this.lblStatus.Text = "Novo Status";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAlterarStatus
            // 
            this.btnAlterarStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnAlterarStatus.Image = global::SID_Telecred.Properties.Resources.DocumentRefresh;
            this.btnAlterarStatus.Location = new System.Drawing.Point(289, 19);
            this.btnAlterarStatus.Name = "btnAlterarStatus";
            this.btnAlterarStatus.Size = new System.Drawing.Size(114, 58);
            this.btnAlterarStatus.TabIndex = 33;
            this.btnAlterarStatus.Text = "Alterar Status";
            this.btnAlterarStatus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAlterarStatus.UseVisualStyleBackColor = true;
            this.btnAlterarStatus.Click += new System.EventHandler(this.btnAlterarStatus_Click);
            // 
            // frmServicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 183);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAbrirLote);
            this.Controls.Add(this.cboLote);
            this.Controls.Add(this.cboServico);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblLote);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmServicos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleção de Serviços";
            this.Load += new System.EventHandler(this.frmServicos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboServico;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLote;
        private System.Windows.Forms.ComboBox cboLote;
        private System.Windows.Forms.Button btnAbrirLote;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkAlterarStatus;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnAlterarStatus;
    }
}