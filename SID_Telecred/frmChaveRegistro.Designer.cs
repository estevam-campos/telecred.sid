namespace SID_Telecred
{
    partial class frmChaveRegistro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChaveRegistro));
            this.lblChave = new System.Windows.Forms.Label();
            this.txtChave = new System.Windows.Forms.TextBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblChave
            // 
            this.lblChave.AutoSize = true;
            this.lblChave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblChave.Location = new System.Drawing.Point(12, 18);
            this.lblChave.Name = "lblChave";
            this.lblChave.Size = new System.Drawing.Size(47, 16);
            this.lblChave.TabIndex = 1;
            this.lblChave.Text = "Chave";
            // 
            // txtChave
            // 
            this.txtChave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtChave.Location = new System.Drawing.Point(65, 15);
            this.txtChave.MaxLength = 250;
            this.txtChave.Name = "txtChave";
            this.txtChave.Size = new System.Drawing.Size(289, 22);
            this.txtChave.TabIndex = 2;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnRegistrar.Image = global::SID_Telecred.Properties.Resources.RegistryReplace;
            this.btnRegistrar.Location = new System.Drawing.Point(360, 4);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(141, 40);
            this.btnRegistrar.TabIndex = 0;
            this.btnRegistrar.Text = "Processar Chave";
            this.btnRegistrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // frmChaveRegistro
            // 
            this.AcceptButton = this.btnRegistrar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 54);
            this.Controls.Add(this.txtChave);
            this.Controls.Add(this.lblChave);
            this.Controls.Add(this.btnRegistrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChaveRegistro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chave de Registro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Label lblChave;
        private System.Windows.Forms.TextBox txtChave;
    }
}