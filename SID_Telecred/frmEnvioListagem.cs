using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SID_Telecred
{
    public partial class frmEnvioListagem : Form
    {
        public frmEnvioListagem()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarPegs();
        }

        private void CarregarPegs()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                grdPegs.DataSource = Funcoes.CarregarPegsEnvioListagem(dtpInicio.Value, dtpFim.Value.AddDays(1));
                lblQtde.Text = grdPegs.Rows.Count.ToString();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro--> " + ex.Message,
                    "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void frmEnvioListagem_Load(object sender, EventArgs e)
        {
            CarregarPegs();
        }

        //private void dtpInicio_ValueChanged(object sender, EventArgs e)
        //{
        //    CarregarPegs();
        //}

        //private void dtpFim_ValueChanged(object sender, EventArgs e)
        //{
        //    CarregarPegs();
        //}
    }
}
