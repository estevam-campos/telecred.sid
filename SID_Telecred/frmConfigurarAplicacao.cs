using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Transactions;
using System.Reflection;

namespace SID_Telecred
{
    public partial class frmConfigurarAplicacao : Form
    {
        public frmConfigurarAplicacao()
        {
            InitializeComponent();
        }

        Usuario oUsuario = new Usuario();
        bool blnPermissoes;
        bool blnLoad;
        private void lblBancoDados_Click(object sender, EventArgs e)
        {
            AlternarOpcao(Funcoes.OpcaoConfiguracao.BancoDados);
            this.Height = 325;
        }
        private void lblAplicacao_Click(object sender, EventArgs e)
        {
            AlternarOpcao(Funcoes.OpcaoConfiguracao.Aplicacao);
            this.Height = 325;
        }
        private void lblPermissoes_Click(object sender, EventArgs e)
        {
            AlternarOpcao(Funcoes.OpcaoConfiguracao.Permissoes);
            this.Height = 870;
        }
        private void AlternarOpcao(Funcoes.OpcaoConfiguracao opcao)
        {
            grpAplicacao.Visible = opcao == Funcoes.OpcaoConfiguracao.Aplicacao;
            grpBancoDados.Visible = opcao == Funcoes.OpcaoConfiguracao.BancoDados;
            grpPermissoes.Visible = opcao == Funcoes.OpcaoConfiguracao.Permissoes;

            if (opcao == Funcoes.OpcaoConfiguracao.Aplicacao)
            {
                lblAplicacao.ForeColor = Color.Red;
                lblBancoDados.ForeColor = Color.Black;
                lblPermissoes.ForeColor = Color.Black;
                lblAplicacao.BorderStyle = BorderStyle.Fixed3D;
                lblBancoDados.BorderStyle = BorderStyle.None;
                lblPermissoes.BorderStyle = BorderStyle.None;
                btnGravar.Enabled = true;
            }
            else if (opcao == Funcoes.OpcaoConfiguracao.BancoDados)
            {
                lblAplicacao.ForeColor = Color.Black;
                lblBancoDados.ForeColor = Color.Red;
                lblPermissoes.ForeColor = Color.Black;
                lblAplicacao.BorderStyle = BorderStyle.None;
                lblBancoDados.BorderStyle = BorderStyle.Fixed3D;
                lblPermissoes.BorderStyle = BorderStyle.None;
                btnGravar.Enabled = true;
            }
            else if (opcao == Funcoes.OpcaoConfiguracao.Permissoes)
            {
                lblAplicacao.ForeColor = Color.Black;
                lblBancoDados.ForeColor = Color.Black;
                lblPermissoes.ForeColor = Color.Red;
                lblAplicacao.BorderStyle = BorderStyle.None;
                lblBancoDados.BorderStyle = BorderStyle.None;
                lblPermissoes.BorderStyle = BorderStyle.Fixed3D;

                if (Funcoes.intCodigoUsuario == Convert.ToInt32(cboUsuario.SelectedValue))
                {
                    btnGravar.Enabled = false;
                }
                else
                {
                    btnGravar.Enabled = true;
                }
            }
        }
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            fbdImagens.SelectedPath = txtCaminho.Text;
            if (fbdImagens.ShowDialog() == DialogResult.OK)
            {
                txtCaminho.Text = fbdImagens.SelectedPath;
                tipConfiguracao.SetToolTip(txtCaminho, txtCaminho.Text);
            }
        }
        private void frmConfigurarAplicacao_Load(object sender, EventArgs e)
        {
            blnLoad = false;
            PreencherComboUsuario();
            ConfigurarMenus();
            CarregarConfiguracoes();
            lblPermissoes.Enabled = Funcoes.intCodigoUsuario != 0;
            this.Height = 325;
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
        private void ConfigurarMenus()
        {
            int intContadorNode = -1;
            trwDisponiveis.Nodes.Add("Permissões");
            foreach (string opcao in Funcoes.strMenuItens)
            {
                string[] strOpcao = opcao.Split('|');

                {
                    if (strOpcao[1] == "0")
                    {
                        intContadorNode++;
                        trwDisponiveis.Nodes[0].Nodes.Add(strOpcao[3]);
                        trwDisponiveis.Nodes[0].Nodes[trwDisponiveis.Nodes[0].Nodes.Count - 1].Tag = strOpcao[4];
                        if (strOpcao[2] != "0")
                        {
                            trwDisponiveis.Nodes[0].Nodes[trwDisponiveis.Nodes[0].Nodes.Count - 1].ForeColor = Color.Gray;
                            trwDisponiveis.Nodes[0].Nodes[trwDisponiveis.Nodes[0].Nodes.Count - 1].Checked = true;
                            Application.DoEvents();
                        }

                    }
                    else
                    {
                        trwDisponiveis.Nodes[0].Nodes[intContadorNode].Nodes.Add(strOpcao[3]);
                        trwDisponiveis.Nodes[0].Nodes[intContadorNode].Nodes[trwDisponiveis.Nodes[0].Nodes[intContadorNode].Nodes.Count - 1].Tag = strOpcao[4]; ;
                        if (strOpcao[2] != "0")
                        {
                            trwDisponiveis.Nodes[0].Nodes[intContadorNode].Nodes[trwDisponiveis.Nodes[0].Nodes[intContadorNode].Nodes.Count - 1].ForeColor = Color.Gray;
                            trwDisponiveis.Nodes[0].Nodes[intContadorNode].Nodes[trwDisponiveis.Nodes[0].Nodes[intContadorNode].Nodes.Count - 1].Checked = true;
                            Application.DoEvents();
                        }
                    }
                }
            }
            trwDisponiveis.ExpandAll();
        }
        private void CarregarConfiguracoes()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                string strCliente = Funcoes.strCliente;
                Funcoes.strCliente = string.Empty;
                txtDataSource.Text = ConfigurationManager.AppSettings["Servidor"];
                txtInitialCatalog.Text = ConfigurationManager.AppSettings["Banco"];
                txtUserId.Text = Funcoes.Decrypt(ConfigurationManager.AppSettings["Usuario"], true);
                txtPassword.Text = Funcoes.Decrypt(ConfigurationManager.AppSettings["Senha"], true);
                txtCaminho.Text = ConfigurationManager.AppSettings["CaminhoImagens"];
                nudInatividade.Value = Convert.ToDecimal(ConfigurationManager.AppSettings["Inatividade"]);
                nudDocumentos.Value = Convert.ToDecimal(ConfigurationManager.AppSettings["DocumentosCaixa"]);
                Funcoes.strCliente = strCliente;
                tipConfiguracao.SetToolTip(txtCaminho, txtCaminho.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro--> " + ex.Message,
                    "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                string strCliente = Funcoes.strCliente;
                Funcoes.strCliente = string.Empty;
                Funcoes.UpdateAppSettings("Servidor", txtDataSource.Text);
                Funcoes.UpdateAppSettings("Banco", txtInitialCatalog.Text);
                Funcoes.UpdateAppSettings("Usuario", Funcoes.Encrypt(txtUserId.Text, true));
                Funcoes.UpdateAppSettings("Senha", Funcoes.Encrypt(txtPassword.Text, true));
                Funcoes.UpdateAppSettings("CaminhoImagens", txtCaminho.Text);
                Funcoes.UpdateAppSettings("Inatividade", nudInatividade.Value.ToString());
                Funcoes.UpdateAppSettings("DocumentosCaixa", nudDocumentos.Value.ToString());
                Funcoes.strCliente = strCliente;

                if (cboUsuario.SelectedIndex != -1)
                {
                    oUsuario.Permissao.Clear();
                    int intMenus = trwDisponiveis.Nodes[0].GetNodeCount(false);
                    for (int intContador = 0; intContador < intMenus; intContador++)
                    {
                        Permissoes perm = new Permissoes();
                        perm.strMenu = trwDisponiveis.Nodes[0].Nodes[intContador].Tag.ToString();
                        perm.blnStatus = trwDisponiveis.Nodes[0].Nodes[intContador].Checked;
                        perm.intCodigoUsuario = oUsuario.intCodigo;
                        oUsuario.Permissao.Add(perm);
                        int intItens = trwDisponiveis.Nodes[0].Nodes[intContador].GetNodeCount(false);
                        for (int intContadorNode = 0; intContadorNode < intItens; intContadorNode++)
                        {
                            Permissoes perm1 = new Permissoes();
                            perm1.strMenu = trwDisponiveis.Nodes[0].Nodes[intContador].Nodes[intContadorNode].Tag.ToString();
                            perm1.blnStatus = trwDisponiveis.Nodes[0].Nodes[intContador].Nodes[intContadorNode].Checked;
                            perm1.intCodigoUsuario = oUsuario.intCodigo;
                            oUsuario.Permissao.Add(perm1);
                        }
                    }
                    if (oUsuario.Permissao.Count > 0)
                    {
                        oUsuario.GravarPermissoes();
                    }
                }

                MessageBox.Show("Configurações efetuadas com sucesso.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                //Funcoes.CarregarAppConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro--> " + ex.Message,
                    "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void cboUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (blnLoad)
            {
                blnPermissoes = false;
                oUsuario.intCodigo = Convert.ToInt32(cboUsuario.SelectedValue);
                oUsuario.ConsultarPermissoes();

                if (Funcoes.intCodigoUsuario == oUsuario.intCodigo)
                {
                    btnGravar.Enabled = true;
                }
                else
                {
                    btnGravar.Enabled = true;
                }

                trwDisponiveis.Nodes[0].Checked = false;

                int intMenus = trwDisponiveis.Nodes[0].GetNodeCount(false);
                for (int intContador = 0; intContador < intMenus; intContador++)
                {
                    string strMenu = trwDisponiveis.Nodes[0].Nodes[intContador].Tag.ToString();
                    trwDisponiveis.Nodes[0].Nodes[intContador].Checked = false;

                    foreach (Permissoes perm in oUsuario.Permissao)
                    {
                        if (perm.strMenu == strMenu)
                        {
                            trwDisponiveis.Nodes[0].Nodes[intContador].Checked = perm.blnStatus;
                            break;
                        }
                    }
                }

                intMenus = trwDisponiveis.Nodes[0].GetNodeCount(false);
                for (int intContador = 0; intContador < intMenus; intContador++)
                {
                    for (int intContadorNode = 0; intContadorNode < trwDisponiveis.Nodes[0].Nodes[intContador].GetNodeCount(false); intContadorNode++)
                    {
                        string strMenu = trwDisponiveis.Nodes[0].Nodes[intContador].Nodes[intContadorNode].Tag.ToString();

                        foreach (Permissoes perm in oUsuario.Permissao)
                        {
                            if (perm.strMenu == strMenu)
                            {
                                trwDisponiveis.Nodes[0].Nodes[intContador].Nodes[intContadorNode].Checked = perm.blnStatus;
                                break;
                            }
                        }
                    }
                }
                blnPermissoes = true;
            }
        }
        private void trwDisponiveis_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (blnLoad && blnPermissoes)
            {
                foreach (TreeNode opcao in e.Node.Nodes)
                {
                    opcao.Checked = e.Node.Checked;
                }
            }
        }
        private void trwDisponiveis_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.ForeColor == Color.Gray)
            {
                e.Cancel = true;
                Application.DoEvents();
            }
        }
        private void trwDisponiveis_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Checked && e.Node.ForeColor == Color.Gray)
            {
                e.Cancel = true;
                Application.DoEvents();
            }
        }
        private void trwDisponiveis_AfterSelect(object sender, TreeViewEventArgs e)
        {
            e.Node.Checked = !e.Node.Checked;
        }
    }
}
