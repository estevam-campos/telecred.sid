namespace SID_Telecred
{
    partial class frmAlterarRegimeAtendimento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAlterarRegimeAtendimento));
            this.cboTipoPeg = new System.Windows.Forms.ComboBox();
            this.lblRegime = new System.Windows.Forms.Label();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboTipoPeg
            // 
            this.cboTipoPeg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPeg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboTipoPeg.FormattingEnabled = true;
            this.cboTipoPeg.Location = new System.Drawing.Point(12, 28);
            this.cboTipoPeg.Name = "cboTipoPeg";
            this.cboTipoPeg.Size = new System.Drawing.Size(288, 24);
            this.cboTipoPeg.TabIndex = 83;
            // 
            // lblRegime
            // 
            this.lblRegime.AutoSize = true;
            this.lblRegime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblRegime.Location = new System.Drawing.Point(12, 9);
            this.lblRegime.Name = "lblRegime";
            this.lblRegime.Size = new System.Drawing.Size(261, 16);
            this.lblRegime.TabIndex = 82;
            this.lblRegime.Text = "Selecione o novo Regime de Atendimento";
            // 
            // btnGravar
            // 
            this.btnGravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnGravar.Image = global::SID_Telecred.Properties.Resources.FloppyDisks;
            this.btnGravar.Location = new System.Drawing.Point(12, 58);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(141, 40);
            this.btnGravar.TabIndex = 85;
            this.btnGravar.Text = "&Gravar";
            this.btnGravar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnFechar.Image = global::SID_Telecred.Properties.Resources.delete;
            this.btnFechar.Location = new System.Drawing.Point(159, 58);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(141, 40);
            this.btnFechar.TabIndex = 84;
            this.btnFechar.Text = "&Cancelar";
            this.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // frmAlterarRegimeAtendimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 117);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.cboTipoPeg);
            this.Controls.Add(this.lblRegime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAlterarRegimeAtendimento";
            this.Tag = "0";
            this.Text = "Alteração do Regime de Atendimento - PEG";
            this.Load += new System.EventHandler(this.frmAlterarRegimeAtendimento_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.ComboBox cboTipoPeg;
        private System.Windows.Forms.Label lblRegime;
    }
}