using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SID_Telecred
{
    public partial class frmChaveRegistro : Form
    {
        public frmChaveRegistro()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            this.Tag = txtChave.Text;
            this.Close();
        }
    }
}
