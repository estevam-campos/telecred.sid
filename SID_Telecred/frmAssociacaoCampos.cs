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
    public partial class frmAssociacaoCampos : Form
    {
        public frmAssociacaoCampos()
        {
            InitializeComponent();
        }

        bool blnLoad = false;
        Layout oLayout = new Layout();
        Servico oServico = new Servico();
        private void CarregarLayouts()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                cboLayout.DataSource = Funcoes.CarregarLayouts();
                cboLayout.DisplayMember = "IMP_NOME_LAYOUT";
                cboLayout.ValueMember = "IMP_CODIGO";
                cboLayout.SelectedIndex = -1;
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
        private void frmAssociacaoCampos_Load(object sender, EventArgs e)
        {
            blnLoad = false;
            CarregarLayouts();
            PreencherServico();
            blnLoad = true;
        }

        private void cboServico_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                if (blnLoad)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    lstServico.Items.Clear();
                    oServico.intCodigo = Convert.ToInt32(cboServico.SelectedValue);
                    oServico.Consultar();
                    foreach (Campo campo in oServico.Campos)
                    {
                        lstServico.Items.Add(campo.intOrdem.ToString("000") + "-" + campo.strDescricao);
                    }

                    if (cboLayout.SelectedIndex != -1)
                    {
                        PreencherAssociacoes();
                    }

                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboLayout_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                if (blnLoad)
                {

                    Cursor.Current = Cursors.WaitCursor;
                    oLayout.intCodigo = Convert.ToInt32(cboLayout.SelectedValue);
                    oLayout.Consultar();
                    lstLayout.Items.Clear();
                    foreach (CampoLayout oCampo in oLayout.Campos)
                    {
                        string strCampo = oCampo.intPosicao.ToString("000") + "-" + oCampo.strNome;
                        strCampo += oCampo.blnChave ? "(chave)" : "";
                        if (oCampo.blnImportar)
                        {
                            lstLayout.Items.Add(strCampo);
                        }
                    }

                    if (cboServico.SelectedIndex != -1)
                    {
                        PreencherAssociacoes();
                    }
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lstLayout.SelectedIndex != -1 && lstServico.SelectedIndex != -1)
            {
                string strCampo = lstServico.Items[lstServico.SelectedIndex] + " --> " + lstLayout.Items[lstLayout.SelectedIndex];
                if (lstCamposAssociados.Items.IndexOf(strCampo) == -1)
                {
                    lstCamposAssociados.Items.Add(strCampo);
                }
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (lstCamposAssociados.SelectedIndex != -1)
            {
                lstCamposAssociados.Items.RemoveAt(lstCamposAssociados.SelectedIndex);
            }
        }

        private void PreencherClasse()
        {
            oServico.intCodigoLayout = Convert.ToInt32(cboLayout.SelectedValue);
            foreach (string campos in lstCamposAssociados.Items)
            {
                int intOrdem = Convert.ToInt32(campos.Substring(0, 3));
                int intPosicao = Convert.ToInt32(campos.Substring(campos.IndexOf("-->") + 4, 3));
                foreach (Campo campo in oServico.Campos)
                {
                    if (campo.intOrdem == intOrdem)
                    {
                        campo.intPosicaoLayout = intPosicao;
                        break;
                    }
                }
            }
        }

        private void btnAssociar_Click(object sender, EventArgs e)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                if (lstCamposAssociados.Items.Count > 0)
                {
                    if (MessageBox.Show("Confirma Associação dos campos?", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        PreencherClasse();
                        oServico.GravarAssociacoes();
                        MessageBox.Show("Campos associados com sucesso.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCampos();
                    }
                }
                else
                {
                    if (MessageBox.Show("Deseja excluir a associação entre " + cboServico.Text + " e " + cboLayout.Text + "?", "Sistema Integrado de Digitação Telecred",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        oServico.Campos.Clear();
                        PreencherClasse();
                        oServico.GravarAssociacoes();
                        MessageBox.Show("Associados excluías com sucesso.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PreencherAssociacoes()
        {
            try
            {
                Servico servico = new Servico();
                servico.intCodigo = oServico.intCodigo;
                servico.intCodigoLayout = oLayout.intCodigo;
                //oServico.Campos.Clear();
                servico.ConsultarAssociacoes();
                lstCamposAssociados.Items.Clear();
                foreach (Campo campo in servico.Campos)
                {
                    lstCamposAssociados.Items.Add(campo.intOrdem.ToString().PadLeft(3, '0') + "-" + campo.strDescricao + " --> " + campo.intPosicaoLayout.ToString().PadLeft(3, '0') + "-" + campo.strConteudo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            lstLayout.Items.Clear();
            lstServico.Items.Clear();
            lstCamposAssociados.Items.Clear();
            cboLayout.SelectedIndex = -1;
            cboServico.SelectedIndex = -1;
        }

        private void btnLimparCampos_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
