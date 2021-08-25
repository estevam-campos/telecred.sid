using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;

namespace SID_Telecred
{
    public partial class frmSobre : Form
    {
        public frmSobre()
        {
            InitializeComponent();
        }

        private void frmSobre_Load(object sender, EventArgs e)
        {
            lblTexto.Text = "Sistema Integrado de Digitação Telecred\n";
            lblTexto.Text += "Versão " + Application.ProductVersion.ToString() + "\n";
            lblTexto.Text += "©Code Technology Soluções em Tecnologia Ltda\n";
            lblTexto.Text += "Software Registrado para:\n";
            lblTexto.Text += "Telecred Sistemas e Métodos Ltda";

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
