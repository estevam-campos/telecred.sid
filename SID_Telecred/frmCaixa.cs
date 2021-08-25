using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Transactions;
using System.Reflection;

namespace SID_Telecred
{
    public partial class frmCaixa : Form
    {
        public frmCaixa()
        {
            InitializeComponent();
        }
        Caixa oCaixa = new Caixa();
        bool blnLoad = false;
        private void frmCaixa_Load(object sender, EventArgs e)
        {
            blnLoad = false;
            PreencherServico();
            blnLoad = true;
        }
        private void PreencherServico()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                cboServico.DataSource = Funcoes.CarregarServico();
                cboServico.DisplayMember = "SER_DESCRICAO";
                cboServico.ValueMember = "SER_CODIGO";
                cboServico.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void PreencherGrid()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                grdCaixas.DataSource = oCaixa.ConsultarCaixa();
                grdCaixas.Columns[0].Visible = false;
                grdCaixas.Columns[2].Width = 250;
                grdCaixas.Columns[3].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboServico_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (blnLoad)
            {
                grdCaixas.DataSource = null;
                LimparCampos();
                oCaixa.intCodigoServico = Convert.ToInt32(cboServico.SelectedValue);
                oCaixa.intCodigoUsuario = Funcoes.intCodigoUsuario;
                PreencherGrid();
            }
        }

        private void grdCaixas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                if (grdCaixas.SelectedCells.Count > 0)
                {
                    oCaixa.intCodigo = Convert.ToInt32(grdCaixas.SelectedCells[0].Value);
                    oCaixa.ConsultarCaixa();
                    Lote oLote = new Lote();
                    oLote.intCodigoCaixa = oCaixa.intCodigo;
                    oCaixa.intQtdeImagens = oLote.ContarImagensCaixa(false);
                    PreencherForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtCaixa.Text = string.Empty;
            txtEmpresa.Text = string.Empty;
            oCaixa.intCodigo = 0;
            oCaixa.strCaixa = string.Empty;
            oCaixa.strEmpresa = string.Empty;
            txtCaixa.Focus();
        }
        private void PreencherClasse()
        {
            oCaixa.strEmpresa = txtEmpresa.Text;
            oCaixa.strCaixa = txtCaixa.Text;
            oCaixa.intStatusCaixa = 1;
        }
        private void PreencherForm()
        {
            txtCaixa.Text = oCaixa.strCaixa;
            txtEmpresa.Text = oCaixa.strEmpresa;
            txtQtde.Text = oCaixa.intQtdeImagens.ToString();
        }
        private string ValidarPreenchimento()
        {
            string strMsg = string.Empty;
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                if (txtCaixa.Text == string.Empty)
                {
                    strMsg = "Número da caixa em branco.\n";
                }
                if (txtEmpresa.Text == string.Empty)
                {
                    strMsg += "Empresa em branco.\n";
                }
                int intCodAux = oCaixa.intCodigo;
                oCaixa.intCodigo = 0;
                oCaixa.ConsultarCaixa();
                if (oCaixa.intCodigo != 0 && oCaixa.intCodigo != intCodAux)
                {
                    strMsg += "Caixa já existente para o serviço selecionado.";
                }
                oCaixa.intCodigo = intCodAux;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strMsg;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                PreencherClasse();
                string strMensagemErro = ValidarPreenchimento();
                if (strMensagemErro != string.Empty)
                {
                    MessageBox.Show(strMensagemErro, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCaixa.Focus();
                }
                else
                {
                    PreencherClasse();
                    oCaixa.GravarCaixa();
                    MessageBox.Show("Caixa gravada com sucesso.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                    PreencherGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoverCaixa_Click(object sender, EventArgs e)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                if (grdCaixas.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Selecione o número da caixa a ser excluída.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show("Todas os lotes e documentos da caixa " + grdCaixas.SelectedCells[1].Value.ToString() + " serão excluídos.\nDeseja continuar?", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    oCaixa.intCodigo = Convert.ToInt32(grdCaixas.SelectedCells[0].Value);
                    if (!oCaixa.ConsultarCaixaFechada())
                    {
                        MessageBox.Show("Caixa com lotes em Digitação/Digitalização, não é possível excluir a caixa.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCaixa.Focus();
                    }
                    else
                    {
                        oCaixa.RemoverCaixa();
                        MessageBox.Show("Caixa removida com sucesso.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        oCaixa.intCodigo = 0;
                        oCaixa.strCaixa = string.Empty;
                        txtCaixa.Text = string.Empty;
                        txtEmpresa.Text = string.Empty;
                        PreencherGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
