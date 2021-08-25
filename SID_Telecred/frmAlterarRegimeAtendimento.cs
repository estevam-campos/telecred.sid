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
    public partial class frmAlterarRegimeAtendimento : Form
    {
        public frmAlterarRegimeAtendimento()
        {
            InitializeComponent();
        }

        RegistroPeg registroPeg;

        private void frmAlterarRegimeAtendimento_Load(object sender, EventArgs e)
        {
            ConsultarPeg();
            CarregarTipoPegs();
        }

        private void ConsultarPeg()
        {
            try
            {
                registroPeg = new RegistroPeg();
                registroPeg.intPeg = (int)this.Tag;
                registroPeg.ConsultaPeg();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro--> " + ex.Message,
                    "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CarregarTipoPegs()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = Funcoes.CarregarTipoPegs(true);
                cboTipoPeg.DataSource = dt;
                cboTipoPeg.DisplayMember = "TIP_DESCRICAO";
                cboTipoPeg.ValueMember = "TIP_DESCRICAO";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro--> " + ex.Message,
                    "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(string.Format("Confirma alteração do Regime de Atendimento para {0}?", cboTipoPeg.Text),
                    "Alteração Regime de Atendimento", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    registroPeg.intTipoPeg = Convert.ToInt32(cboTipoPeg.Text.Substring(0, 1));
                    registroPeg.blnDiamante = false;
                    registroPeg.strRegimeAtendimento = cboTipoPeg.Text.Substring(4);
                    registroPeg.strClassificacao = registroPeg.strRegimeAtendimento;

                    if (registroPeg.strModulo.ToLower().IndexOf("diamante") != -1 && registroPeg.intTipoPeg == 1)
                    {
                        registroPeg.blnDiamante = true;
                        registroPeg.intTipoPeg = 4;
                    }

                    registroPeg.AlterarRegime();
                    MessageBox.Show("Regime de Atendimento da Peg alterado com sucesso", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro--> " + ex.Message,
                    "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
