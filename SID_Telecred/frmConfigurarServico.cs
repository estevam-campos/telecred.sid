using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Transactions;
namespace SID_Telecred
{
    public partial class frmConfigurarServico : Form
    {
        public frmConfigurarServico()
        {
            InitializeComponent();
        }

        #region Objetos e Variáveis
        bool blnLoad;
        Servico oServico = new Servico();
        Campo oCampo = new Campo();
        #endregion

        #region Eventos
        private void frmConfiguracao_Load(object sender, EventArgs e)
        {
            blnLoad = false;
            PreencherFormato();
            EsconderGroupBox();
            PosicionarCombos();
            PreencherServico();
            PreencherTipoCampo();
            blnLoad = true;
        }
        private void cboTipoCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (blnLoad && cboTipoCampo.SelectedIndex != -1)
            {
                EsconderGroupBox();
                chkChave.Enabled = false;
                if ((int)cboTipoCampo.SelectedValue == (int)Funcoes.TipoCampo.Alphanumerico)
                {
                    grpAlphanumerico.Visible = true;
                    chkChave.Enabled = true;
                }
                else if ((int)cboTipoCampo.SelectedValue == (int)Funcoes.TipoCampo.Numerico)
                {
                    grpNumericUpDown.Visible = true;
                }
                else if ((int)cboTipoCampo.SelectedValue == (int)Funcoes.TipoCampo.Data)
                {
                    grpDateTimePicker.Visible = true;
                }
                else if ((int)cboTipoCampo.SelectedValue == (int)Funcoes.TipoCampo.Hora)
                {
                    grpHora.Visible = true;
                }
                else if ((int)cboTipoCampo.SelectedValue == (int)Funcoes.TipoCampo.Opcoes)
                {
                    grpComboBox.Visible = true;
                }
            }
        }
        private void cboFormato_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (blnLoad)
            {
                txtFormato.ReadOnly = true;
                nudTamanho.Enabled = false;
                if (cboFormato.SelectedIndex == (int)Funcoes.Formato.Cpf)
                {
                    txtFormato.Text = "000.000.000-00";
                }
                else if (cboFormato.SelectedIndex == (int)Funcoes.Formato.Cnpj)
                {
                    txtFormato.Text = "00.000.000/0000-00";
                }
                else if (cboFormato.SelectedIndex == (int)Funcoes.Formato.Cep)
                {
                    txtFormato.Text = "00000-000";
                }
                else if (cboFormato.SelectedIndex == (int)Funcoes.Formato.Telefone)
                {
                    txtFormato.Text = "00000-0000";
                }
                else if (cboFormato.SelectedIndex == (int)Funcoes.Formato.DDD_Telefone)
                {
                    txtFormato.Text = "(00)00000-0000";
                }
                else if (cboFormato.SelectedIndex == (int)Funcoes.Formato.Específico)
                {
                    txtFormato.ReadOnly = false;
                    txtFormato.Text = string.Empty;
                }
                else if (cboFormato.SelectedIndex == (int)Funcoes.Formato.Livre)
                {
                    nudTamanho.Enabled = true;
                    txtFormato.Text = string.Empty;
                    nudTamanho.Value = 50;
                }
                else if (cboFormato.SelectedIndex == (int)Funcoes.Formato.CpfCnpj)
                {
                    txtFormato.Text = "00000000000000";
                }
                if (cboFormato.SelectedIndex <= (int)Funcoes.Formato.Específico)
                {
                    nudTamanho.Value = txtFormato.Text.Length;
                }
            }
        }
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (txtItem.Text.Trim() != string.Empty)
            {
                lstOpcoes.Items.Add(txtItem.Text.Trim());
                txtItem.Text = string.Empty;
                txtItem.Focus();
            }
        }
        private void btnRemItem_Click(object sender, EventArgs e)
        {
            if (lstOpcoes.SelectedIndex != -1)
            {
                lstOpcoes.Items.RemoveAt(lstOpcoes.SelectedIndex);
            }
        }
        private void txtFormato_TextChanged(object sender, EventArgs e)
        {
            if (txtFormato.Text != string.Empty)
            {
                nudTamanho.Value = txtFormato.Text.Length;
            }
            else
            {
                nudTamanho.Value = 0;
            }
        }
        private void btnAddCampo_Click(object sender, EventArgs e)
        {
            string strMensagemErro = ValidarPreenchimento(true);
            if (strMensagemErro == string.Empty)
            {
                if ((int)cboTipoCampo.SelectedValue == (int)Funcoes.TipoCampo.Alphanumerico)
                {
                    lstCampos.Items.Add(AdicionarAlphaNumerico());
                }
                else if ((int)cboTipoCampo.SelectedValue == (int)Funcoes.TipoCampo.Numerico)
                {
                    lstCampos.Items.Add(AdicionarNumerico());
                }
                else if ((int)cboTipoCampo.SelectedValue == (int)Funcoes.TipoCampo.Data)
                {
                    lstCampos.Items.Add(AdicionarData());
                }
                else if ((int)cboTipoCampo.SelectedValue == (int)Funcoes.TipoCampo.Hora)
                {
                    lstCampos.Items.Add(AdicionarHora());
                }
                else if ((int)cboTipoCampo.SelectedValue == (int)Funcoes.TipoCampo.Logico)
                {
                    lstCampos.Items.Add(AdicionarLogico());
                }
                else if ((int)cboTipoCampo.SelectedValue == (int)Funcoes.TipoCampo.Opcoes)
                {
                    lstCampos.Items.Add(AdicionarOpcoes());
                    lstOpcoes.Items.Clear();
                }
                cboTipoCampo.SelectedIndex = -1;
                cboFormato.SelectedIndex = 0;
                chkChave.Checked = false;
                EsconderGroupBox();
                txtCampo.Text = string.Empty;
                txtCampo.Focus();
            }
            else
            {
                MessageBox.Show(strMensagemErro, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtServico.Focus();
            }
        }
        private void btnRemCampo_Click(object sender, EventArgs e)
        {
            if (lstCampos.SelectedIndex != -1)
            {
                lstCampos.Items.RemoveAt(lstCampos.SelectedIndex);
            }
        }
        private void btnRemTodos_Click(object sender, EventArgs e)
        {
            if (lstCampos.Items.Count > 0)
            {
                if (MessageBox.Show("Remover todos os campos?", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    lstCampos.Items.Clear();
                }
            }
        }
        private void btnCima_Click(object sender, EventArgs e)
        {
            if (lstCampos.SelectedIndex > 0)
            {
                int intPosicao = lstCampos.SelectedIndex - 1;
                Mover(true);
                lstCampos.SelectedIndex = intPosicao;
            }
        }
        private void btnBaixo_Click(object sender, EventArgs e)
        {
            if (lstCampos.SelectedIndex < lstCampos.Items.Count - 1)
            {
                int intPosicao = lstCampos.SelectedIndex + 1;
                Mover(false);
                lstCampos.SelectedIndex = intPosicao; ;
            }
        }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                string strErro = ValidarPreenchimento(false);
                if (strErro == string.Empty)
                {
                    string strMsg = oServico.intCodigo == 0 ? "Confirma Gravação do Servico " + txtServico.Text + "?" : "A alteração do serviço " + txtServico.Text + " removerá todas as associações do mesmo. Continua?";
                    if (MessageBox.Show(strMsg, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        PreencherClasse();
                        oServico.Gravar();
                        MessageBox.Show("Serviço gravado com sucesso", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PreencherServico();
                        LimparCampos();
                    }
                }
                else
                {
                    MessageBox.Show(strErro, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtServico.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboServico_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                if (blnLoad && cboServico.SelectedIndex != -1)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    lstCampos.Items.Clear();
                    txtServico.Text = cboServico.Text;
                    oServico.intCodigo = Convert.ToInt32(cboServico.SelectedValue);
                    oCampo.intCodigoServico = oServico.intCodigo;
                    foreach (string campo in oCampo.Consultar())
                    {
                        lstCampos.Items.Add(campo);
                    }
                    Cursor.Current = Cursors.Default;
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
        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        #endregion

        #region Métodos
        private void PosicionarCombos()
        {
            cboFormatoData.SelectedIndex = 0;
            cboFormatoHora.SelectedIndex = 0;
            cboFormato.SelectedIndex = 0;
        }
        private void EsconderGroupBox()
        {
            grpAlphanumerico.Visible = false;
            grpDateTimePicker.Visible = false;
            grpHora.Visible = false;
            grpNumericUpDown.Visible = false;
            grpComboBox.Visible = false;
        }
        private void PreencherFormato()
        {
            cboFormato.Items.Add("CPF");
            cboFormato.Items.Add("CNPJ");
            cboFormato.Items.Add("CEP");
            cboFormato.Items.Add("TELEFONE");
            cboFormato.Items.Add("DDD+TELEFONE");
            cboFormato.Items.Add("Específico");
            cboFormato.Items.Add("Livre");
            cboFormato.Items.Add("CPF+CNPJ");
        }
        private void PreencherTipoCampo()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                cboTipoCampo.DataSource = Funcoes.CarregarTipoCampo();
                cboTipoCampo.DisplayMember = "TTC_NOME";
                cboTipoCampo.ValueMember = "TTC_CODIGO";
                cboTipoCampo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        private string AdicionarEstrutura()
        {
            string strCampo = txtCampo.Text + "|";
            strCampo += chkChave.Checked ? "(Chave)|0|" : "|0|";
            strCampo += cboTipoCampo.SelectedValue + "|" + cboTipoCampo.Text + "|";
            strCampo += rdbObrigatorio.Checked ? "Obrigatório" : "Opcional";
            return strCampo;
        }
        private string AdicionarAlphaNumerico()
        {
            string strCampo = AdicionarEstrutura() + "|";
            strCampo += cboFormato.Text + "|";
            strCampo += txtFormato.Text + "|";
            strCampo += nudTamanho.Value.ToString() + "|0";

            return strCampo;
        }
        private string AdicionarNumerico()
        {
            string strCampo = AdicionarEstrutura() + "|";
            strCampo += nudMinimo.Value.ToString() + "|";
            strCampo += nudMaximo.Value.ToString() + "|";
            strCampo += nudDecimais.Value.ToString() + "|";
            strCampo += chkMilhar.Checked + "|0";
            return strCampo;
        }
        private string AdicionarData()
        {
            string strCampo = AdicionarEstrutura() + "|";
            strCampo += dtpMinima.Value.ToShortDateString() + "|";
            strCampo += dtpMaxima.Value.ToShortDateString() + "|";
            strCampo += cboFormatoData.Text + "|0";
            return strCampo;
        }
        private string AdicionarHora()
        {
            string strCampo = AdicionarEstrutura() + "|";
            strCampo += cboFormatoHora.Text;
            return strCampo;
        }
        private string AdicionarLogico()
        {
            string strCampo = AdicionarEstrutura();
            return strCampo;
        }
        private string AdicionarOpcoes()
        {
            string strCampo = AdicionarEstrutura() + "|";
            foreach (string strOpcao in lstOpcoes.Items)
            {
                strCampo += strOpcao + "|";
            }
            strCampo += "0";// strCampo.Substring(0, strCampo.Length - 1);
            return strCampo;
        }
        private void Mover(bool blnUp)
        {
            int intPosicao = lstCampos.SelectedIndex;
            string[] strItems = new string[lstCampos.Items.Count];
            string strAux;
            for (int intContador = 0; intContador < lstCampos.Items.Count; intContador++)
            {
                lstCampos.SelectedIndex = intContador;
                strItems[intContador] = lstCampos.Text;
            }

            if (blnUp)
            {
                strAux = strItems[intPosicao - 1];
                strItems[intPosicao - 1] = strItems[intPosicao];
                strItems[intPosicao] = strAux;
            }
            else
            {
                strAux = strItems[intPosicao + 1];
                strItems[intPosicao + 1] = strItems[intPosicao];
                strItems[intPosicao] = strAux;
            }
            lstCampos.Items.Clear();
            foreach (string item in strItems)
            {
                lstCampos.Items.Add(item);
            }
        }
        private void PreencherClasse()
        {
            List<string> strListBox = new List<string>();
            foreach (string campo in lstCampos.Items)
            {
                strListBox.Add(campo);
            }
            oServico.Campos.Clear();
            oServico.Campos = oServico.RetornaListaCampos(strListBox);
            oServico.strNome = txtServico.Text;
        }
        private string ValidarPreenchimento(bool blnValidarCampos)
        {
            string strMsg = string.Empty;

            if (blnValidarCampos)
            {
                if (txtCampo.Text == string.Empty)
                {
                    strMsg = "Nome do campo em branco.\n";
                }
                if (cboTipoCampo.SelectedIndex == -1)
                {
                    strMsg += "Tipo do campo não selecionado.\n";
                }
                if (cboFormato.SelectedIndex == (int)Funcoes.Formato.Específico && txtFormato.Text == string.Empty)
                {
                    strMsg += "Máscara do campo em branco.\n";
                }
                if (cboFormato.SelectedIndex == (int)Funcoes.Formato.Livre && nudTamanho.Value == 0)
                {
                    strMsg += "Tamanho do campo inválido.";
                }
            }
            else
            {
                if (txtServico.Text == string.Empty)
                {
                    strMsg = "Nome do serviço em branco.\n";
                }
                if (lstCampos.Items.Count == 0)
                {
                    strMsg += "Nenhum campo adicionado ao serviço.";
                }
            }
            return strMsg;
        }
        private void LimparCampos()
        {
            cboServico.SelectedIndex = -1;
            txtServico.Text = string.Empty;
            cboTipoCampo.SelectedIndex = -1;
            rdbObrigatorio.Checked = true;
            lstCampos.Items.Clear();
            oServico.strNome = string.Empty;
            oServico.Campos.Clear();
            oCampo.intCodigo = 0;
            oCampo.strDescricao = string.Empty;
            oCampo.blnPreenchimento = true;
            oCampo.intOrdem = 0;
            oCampo.intCodigoServico = 0;
            oCampo.intCodigoTipoCampo = 0;
            oCampo.strFormatoAlpha = string.Empty;
            oCampo.strMascaraAlpha = string.Empty;
            oCampo.intTamanho = 0;
            oCampo.dblMinimo = 0;
            oCampo.dblMaximo = 0;
            oCampo.dttMaxima = DateTime.Now;
            oCampo.dttMinima = DateTime.Now;
            oCampo.strFormatoData = string.Empty;
            oCampo.strFormatoHora = string.Empty;
        }
        #endregion

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
