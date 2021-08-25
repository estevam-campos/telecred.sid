namespace SID_Telecred
{
    partial class frmAlteracaoStatusPeg
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPeg = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStatusPeg = new System.Windows.Forms.Label();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnPriorizar = new System.Windows.Forms.Button();
            this.lblPriorizada = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 83;
            this.label1.Text = "Número PEG";
            // 
            // txtPeg
            // 
            this.txtPeg.Location = new System.Drawing.Point(87, 30);
            this.txtPeg.Name = "txtPeg";
            this.txtPeg.Size = new System.Drawing.Size(203, 20);
            this.txtPeg.TabIndex = 84;
            this.txtPeg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPeg_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 86;
            this.label2.Text = "Status Atual";
            // 
            // lblStatusPeg
            // 
            this.lblStatusPeg.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusPeg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblStatusPeg.Location = new System.Drawing.Point(84, 62);
            this.lblStatusPeg.Name = "lblStatusPeg";
            this.lblStatusPeg.Size = new System.Drawing.Size(324, 66);
            this.lblStatusPeg.TabIndex = 87;
            this.lblStatusPeg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnPesquisar.Image = global::SID_Telecred.Properties.Resources.selection_view;
            this.btnPesquisar.Location = new System.Drawing.Point(296, 19);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(117, 40);
            this.btnPesquisar.TabIndex = 85;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnGravar
            // 
            this.btnGravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnGravar.Image = global::SID_Telecred.Properties.Resources.FloppyDisks;
            this.btnGravar.Location = new System.Drawing.Point(12, 134);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(117, 40);
            this.btnGravar.TabIndex = 82;
            this.btnGravar.Text = "&Gravar";
            this.btnGravar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnFechar.Image = global::SID_Telecred.Properties.Resources.delete;
            this.btnFechar.Location = new System.Drawing.Point(293, 134);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(117, 40);
            this.btnFechar.TabIndex = 21;
            this.btnFechar.Text = "&Cancelar";
            this.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnPriorizar
            // 
            this.btnPriorizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnPriorizar.Image = global::SID_Telecred.Properties.Resources.UpArrow1;
            this.btnPriorizar.Location = new System.Drawing.Point(156, 134);
            this.btnPriorizar.Name = "btnPriorizar";
            this.btnPriorizar.Size = new System.Drawing.Size(117, 40);
            this.btnPriorizar.TabIndex = 88;
            this.btnPriorizar.Text = "&Priorizar";
            this.btnPriorizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPriorizar.UseVisualStyleBackColor = true;
            this.btnPriorizar.Click += new System.EventHandler(this.btnPriorizar_Click);
            // 
            // lblPriorizada
            // 
            this.lblPriorizada.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriorizada.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblPriorizada.Location = new System.Drawing.Point(91, 58);
            this.lblPriorizada.Name = "lblPriorizada";
            this.lblPriorizada.Size = new System.Drawing.Size(322, 23);
            this.lblPriorizada.TabIndex = 89;
            this.lblPriorizada.Text = "PEG PRIORIZADA";
            this.lblPriorizada.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPriorizada.Visible = false;
            // 
            // frmAlteracaoStatusPeg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 182);
            this.Controls.Add(this.lblPriorizada);
            this.Controls.Add(this.btnPriorizar);
            this.Controls.Add(this.lblStatusPeg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.txtPeg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.btnFechar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAlteracaoStatusPeg";
            this.Text = "Alteração Status Peg";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPeg;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStatusPeg;
        private System.Windows.Forms.Button btnPriorizar;
        private System.Windows.Forms.Label lblPriorizada;
    }
}