using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Transactions;
using System.Reflection;

namespace SID_Telecred
{
    public partial class frmServicos : Form
    {
        public frmServicos()
        {
            InitializeComponent();
        }

        bool blnLoad;
        Lote oLote = new Lote();
        private void frmServicos_Load(object sender, EventArgs e)
        {
            blnLoad = false;
            PreencherServico();
            HabilidarAlteracao(false);
            PreencherStatus();
            blnLoad = true;
        }

        private void PreencherServico()
        {
            cboServico.DataSource = Funcoes.CarregarServico();
            cboServico.DisplayMember = "SER_DESCRICAO";
            cboServico.ValueMember = "SER_CODIGO";
            cboServico.SelectedIndex = -1;
        }

        private void cboServico_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (blnLoad)
            {
                PreencherLotes();
            }
        }

        private void PreencherLotes()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oLote.intCodigoCaixa = Convert.ToInt32(cboServico.SelectedValue);
                cboLote.DataSource = oLote.ConsultarLote(true);
                cboLote.DisplayMember = "Lote";
                cboLote.ValueMember = "LOT_CODIGO";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreencherStatus()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                cboStatus.DataSource = Funcoes.CarregarStatus();
                cboStatus.DisplayMember = "STA_DESCRICAO";
                cboStatus.ValueMember = "STA_CODIGO";
                cboStatus.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAbrirLote_Click(object sender, EventArgs e)
        {
            if (cboLote.SelectedIndex != -1)
            {
                frmDigitacao ofrmDigitacao = new frmDigitacao();
                ofrmDigitacao.Tag = cboServico.SelectedValue;
                ofrmDigitacao.txtServico.Text = cboServico.Text;
                ofrmDigitacao.txtLote.Tag = cboLote.SelectedValue;
                ofrmDigitacao.txtLote.Text = cboLote.Text;
                ofrmDigitacao.ShowDialog();
                cboLote.SelectedIndex = -1;
                cboServico.SelectedIndex = -1;
            }
        }

        private void HabilidarAlteracao(bool blnHabilitar)
        {
            cboStatus.Enabled = blnHabilitar;
            btnAlterarStatus.Enabled = blnHabilitar;
        }

        private void chkAlterarStatus_CheckedChanged(object sender, EventArgs e)
        {
            HabilidarAlteracao(chkAlterarStatus.Checked);
        }

        private void btnAlterarStatus_Click(object sender, EventArgs e)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                if (cboStatus.SelectedIndex != -1)
                {
                    oLote.intCodigo = Convert.ToInt32(cboLote.SelectedValue);
                    oLote.AlterarStatus();
                    MessageBox.Show("Status alterado com sucesso.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chkAlterarStatus.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
