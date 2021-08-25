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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        Usuario oUsuario = new Usuario();
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oUsuario.strLogin = txtUsuario.Text;
                oUsuario.strSenha = Funcoes.Encrypt(txtSenha.Text, true);
                if (oUsuario.AutenticarUsuario())
                {
                    if (!oUsuario.blnAtivo)
                    {
                        MessageBox.Show("O usuário " + oUsuario.strNome +
                        " encontra-se inativo, login cancelado.",
                            "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                        Funcoes.intCodigoUsuario = 0;
                        Funcoes.strNomeUsuario = string.Empty;
                    }
                    else
                    {
                        MessageBox.Show("Bem vindo " + oUsuario.strNome,
                            "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Login e/ou Senha incorretos",
                        "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
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
