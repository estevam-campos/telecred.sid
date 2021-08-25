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
    public partial class frmAlteracaoStatusPeg : Form
    {
        public frmAlteracaoStatusPeg()
        {
            InitializeComponent();
        }
        RegistroPeg oRegistro = new RegistroPeg();

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (txtPeg.Text == string.Empty)
                return;
            try
            {
                lblStatusPeg.Text = "";
                btnGravar.Enabled = false;
                btnPriorizar.Enabled = false;

                oRegistro = new RegistroPeg();
                oRegistro.intPeg = Convert.ToInt32(txtPeg.Text);
                oRegistro.ConsultaPeg();

                if (oRegistro.intCodigo == 0)
                {
                    MessageBox.Show("Número da PEG não localizado.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                btnGravar.Enabled = oRegistro.intStatus == 2;
                btnPriorizar.Enabled = oRegistro.intStatus == 1 && !oRegistro.blnPriorizar;
                lblStatusPeg.Text = Funcoes.ConsultarStatusPeg(oRegistro.intStatus).Rows[0]["TSP_DESCRICAO"].ToString();
                lblPriorizada.Visible = oRegistro.blnPriorizar;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPeg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (txtPeg.Text == string.Empty)
                return;
            try
            {
                oRegistro.AlterarStatusPeg();
                MessageBox.Show("Status da Peg Alterado com sucesso", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPeg.Clear();
                lblStatusPeg.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPriorizar_Click(object sender, EventArgs e)
        {
            if (txtPeg.Text == string.Empty)
                return;
            try
            {
                oRegistro.Priorizar();
                MessageBox.Show("Peg priorizado com sucesso", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPeg.Clear();
                lblStatusPeg.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
