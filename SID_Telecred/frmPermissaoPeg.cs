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
    public partial class frmPermissaoPeg : Form
    {
        public frmPermissaoPeg()
        {
            InitializeComponent();
        }

        Usuario oUsuario = new Usuario();
        bool blnLoad = false;

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPermissaoPeg_Load(object sender, EventArgs e)
        {
            PreencherComboUsuario();
            PreencherComboConvenio();
            CarregarTipoPegs();
            blnLoad = true;
        }
        private void PreencherComboUsuario()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                cboUsuario.DataSource = oUsuario.ConsultarUsuario();
                cboUsuario.DisplayMember = "Usuário";
                cboUsuario.ValueMember = "USU_CODIGO";
                cboUsuario.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro--> " + ex.Message,
                    "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void PreencherComboConvenio()
        {
            cboConvenio.Items.Add("ITAU");
            cboConvenio.Items.Add("PORTO SAUDE");
            cboUsuario.SelectedIndex = -1;
        }

        private void CarregarPermissoesUsuario()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = oUsuario.ConsultarPermissoesPEG();
                lstSelecionados.Items.Clear();
                lstDisponiveis.Items.Clear();
                CarregarTipoPegs();

                foreach (DataRow linha in dt.Rows)
                {
                    //int posicao = lstDisponiveis.FindStringExact(linha[0].ToString());
                    //if (posicao != -1)
                    //{
                    //    lstDisponiveis.Items.RemoveAt(posicao);
                    //}
                    if (linha[0].ToString() != string.Empty)
                        lstSelecionados.Items.Add(linha[0].ToString());
                }
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
                dt = Funcoes.CarregarTipoPegs();
                lstDisponiveis.Items.Clear();
                foreach (DataRow linha in dt.Rows)
                {
                    lstDisponiveis.Items.Add(linha[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro--> " + ex.Message,
                    "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnAddTodos_Click(object sender, EventArgs e)
        {
            for (int intContador = 0; intContador < lstDisponiveis.Items.Count; intContador++)
            {
                string strPermissao = lstDisponiveis.Items[intContador].ToString() + " (" + cboConvenio.Text + ")";
                if (lstSelecionados.Items.IndexOf(strPermissao) == -1)
                {
                    lstSelecionados.Items.Add(strPermissao);
                }
            }
            //lstDisponiveis.Items.Clear();
            grpSelecionados.Text = "Selecionados - " + lstSelecionados.Items.Count;
        }

        private void btnRemTodos_Click(object sender, EventArgs e)
        {
            //for (int intContador = 0; intContador < lstSelecionados.Items.Count; intContador++)
            //{
            //    lstDisponiveis.Items.Add(lstSelecionados.Items[intContador].ToString());
            //}
            lstSelecionados.Items.Clear();
        }

        private void btnAddPermissao_Click(object sender, EventArgs e)
        {
            if (lstDisponiveis.SelectedIndex != -1 && cboConvenio.SelectedIndex != -1)
            {
                string strPermissao = lstDisponiveis.Text + " (" + cboConvenio.Text + ")";
                if (lstSelecionados.Items.IndexOf(strPermissao) == -1)
                {
                    lstSelecionados.Items.Add(strPermissao);
                    //lstDisponiveis.Items.RemoveAt(lstDisponiveis.SelectedIndex);
                }
            }
        }

        private void btnRemPermissao_Click(object sender, EventArgs e)
        {
            if (lstSelecionados.SelectedIndex != -1)
            {
                //lstDisponiveis.Items.Add(lstSelecionados.Text);
                lstSelecionados.Items.RemoveAt(lstSelecionados.SelectedIndex);
            }
        }

        private void lstDisponiveis_DoubleClick(object sender, EventArgs e)
        {
            btnAddPermissao.PerformClick();
        }

        private void lstSelecionados_DoubleClick(object sender, EventArgs e)
        {
            btnRemPermissao.PerformClick();
        }

        private void cboUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (blnLoad)
            {
                oUsuario.intCodigo = Convert.ToInt32(cboUsuario.SelectedValue);
                CarregarPermissoesUsuario();
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboUsuario.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecione o usuário para gravar as permissões.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<string> permissoes = new List<string>();
                permissoes = lstSelecionados.Items.Cast<String>().ToList();
                oUsuario.GravarPermissoesPEG(permissoes);

                MessageBox.Show("Permissões gravadas com sucesso", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lstSelecionados.Items.Clear();
                lstDisponiveis.Items.Clear();
                cboUsuario.SelectedIndex = -1;
                CarregarTipoPegs();
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
