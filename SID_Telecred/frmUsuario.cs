using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace SID_Telecred
{
    public partial class frmUsuario : Form
    {
        public frmUsuario()
        {
            InitializeComponent();
        }

        Usuario oUsuario = new Usuario();
        DataTable dtUsuario = new DataTable();

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimparCampos()
        {
            //Componentes da tela
            txtPesquisar.Text = string.Empty;
            txtUsuario.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtSenha.Text = string.Empty;
            txtConfirmacao.Text = string.Empty;
            rdbAtivo.Checked = true;
            //Atributos da classe
            oUsuario.intCodigo = 0;
            oUsuario.strNome = string.Empty;
            oUsuario.strLogin = string.Empty;
            oUsuario.strSenha = string.Empty;
            oUsuario.blnAtivo = true;

            btnOk.Enabled = true;

            txtPesquisar.Focus();
        }

        private void PreencherClasse()
        {
            oUsuario.strNome = txtNome.Text;
            oUsuario.strLogin = txtUsuario.Text;
            oUsuario.strSenha = txtSenha.Text;
            oUsuario.blnAtivo = rdbAtivo.Checked;
        }

        private void PreencherFormulario()
        {
            txtNome.Text = oUsuario.strNome;
            txtUsuario.Text = oUsuario.strLogin;
            txtSenha.Text = oUsuario.strSenha;
            txtConfirmacao.Text = oUsuario.strSenha;
            rdbAtivo.Checked = oUsuario.blnAtivo;
            rdbInativo.Checked = !oUsuario.blnAtivo;
        }

        private void CarregarGridUsuarios()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                dtUsuario = oUsuario.ConsultarUsuario();
                grdUsuarios.DataSource = dtUsuario;
                grdUsuarios.Columns[0].Visible = false;
                grdUsuarios.Columns[1].Width = 250;
                grdUsuarios.Columns[2].Width = 150;
                grdUsuarios.Columns[3].Visible = false;
                grdUsuarios.Columns[4].Visible = false;
                grdUsuarios.Columns[5].Visible = false;
                grdUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                grdUsuarios.ReadOnly = true;
                grdUsuarios.MultiSelect = false;
                grdUsuarios.AllowUserToAddRows = false;
                grdUsuarios.RowHeadersVisible = false;
                grdUsuarios.AllowUserToResizeColumns = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            CarregarGridUsuarios();
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            oUsuario.strNome = txtPesquisar.Text;
            oUsuario.strLogin = string.Empty;
            oUsuario.intCodigo = 0;
            CarregarGridUsuarios();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void grdUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oUsuario.intCodigo = Convert.ToInt32(grdUsuarios.SelectedCells[0].Value);
                oUsuario.ConsultarUsuario();
                PreencherFormulario();
                if (oUsuario.intCodigo == Funcoes.intCodigoUsuario)
                {
                    btnOk.Enabled = false;
                }
                else
                {
                    btnOk.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ValidarPreenchimento()
        {
            string strMsg = string.Empty;
            if (txtUsuario.Text == string.Empty)
            {
                strMsg = "Campo Usuário em branco.\n";
            }
            else
            {
                if (oUsuario.intCodigo == 0 ||
                    oUsuario.strLogin != txtUsuario.Text)
                {
                    try
                    {
                        //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                        int intCodAux = oUsuario.intCodigo;
                        oUsuario.intCodigo = 0;
                        oUsuario.strLogin = txtUsuario.Text;
                        dtUsuario = oUsuario.ConsultarUsuario();
                        if (dtUsuario.Rows.Count > 0)
                        {
                            strMsg = "Usuário já existe no banco de dados.\n";
                        }
                        oUsuario.intCodigo = intCodAux;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
            if (txtNome.Text == string.Empty)
            {
                strMsg += "Campo Nome em branco.\n";
            }
            if (txtSenha.Text == string.Empty)
            {
                strMsg += "Campo Senha em branco.\n";
            }
            else if (txtSenha.Text != txtConfirmacao.Text)
            {
                strMsg += "Confirmação de Senha não confere.";
            }
            return strMsg;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                string strMensagem = ValidarPreenchimento();
                if (strMensagem != string.Empty)
                {
                    MessageBox.Show(strMensagem, "Sistema Integrado de Digitação Telecred",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    PreencherClasse();
                    oUsuario.GravarUsuario();
                    MessageBox.Show("Usuário gravado com sucesso.",
                        "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    LimparCampos();
                    CarregarGridUsuarios();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message,
                    "Sistema Integrado de Digitação Telecred",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void txtPesquisar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                grdUsuarios_CellClick(grdUsuarios, new DataGridViewCellEventArgs(1, 1));
            }
        }  
    }
}
