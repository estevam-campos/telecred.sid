namespace SID_Telecred
{
    partial class frmAssociarServicoReembolso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAssociarServicoReembolso));
            this.btnAssociar = new System.Windows.Forms.Button();
            this.cboServico = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAssociar
            // 
            this.btnAssociar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnAssociar.Image = global::SID_Telecred.Properties.Resources.DocumentEdit;
            this.btnAssociar.Location = new System.Drawing.Point(257, 9);
            this.btnAssociar.Name = "btnAssociar";
            this.btnAssociar.Size = new System.Drawing.Size(114, 58);
            this.btnAssociar.TabIndex = 32;
            this.btnAssociar.Text = "Associar";
            this.btnAssociar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAssociar.UseVisualStyleBackColor = true;
            this.btnAssociar.Click += new System.EventHandler(this.btnAssociar_Click);
            // 
            // cboServico
            // 
            this.cboServico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboServico.FormattingEnabled = true;
            this.cboServico.Location = new System.Drawing.Point(12, 43);
            this.cboServico.Name = "cboServico";
            this.cboServico.Size = new System.Drawing.Size(239, 24);
            this.cboServico.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 30;
            this.label2.Text = "Serviço";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmAssociarServicoReembolso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 77);
            this.Controls.Add(this.btnAssociar);
            this.Controls.Add(this.cboServico);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAssociarServicoReembolso";
            this.Text = "Grupo Telecred - Associar Serviço Reembolso";
            this.Load += new System.EventHandler(this.frmAssociarServicoReembolso_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAssociar;
        private System.Windows.Forms.ComboBox cboServico;
        private System.Windows.Forms.Label label2;
    }
}