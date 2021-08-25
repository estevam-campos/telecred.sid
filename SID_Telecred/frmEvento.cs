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
    public partial class frmEvento : Form
    {
        public frmEvento()
        {
            InitializeComponent();
        }
        Evento oEvento = new Evento();
        DataTable dtEvento = new DataTable();

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtCodigo.Clear();
            txtDescricao.Clear();            
            txtCodigo.Focus();
        }        

        private void frmEvento_Load(object sender, EventArgs e)
        {
           
        }

        private void PreencherClasse()
        {
            oEvento.strCodigoAMB = txtCodigo.Text;
            oEvento.strDescricao = txtDescricao.Text;
        }      

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                PreencherClasse();
                oEvento.Gravar();
                MessageBox.Show("Eventos gravado com sucesso", "Sistema Integrado de Digitação Telecred",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
