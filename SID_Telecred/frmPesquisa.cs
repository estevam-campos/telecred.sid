using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SID_Telecred
{
    public partial class frmPesquisa : Form
    {
        public frmPesquisa()
        {
            InitializeComponent();
        }

        AcessoBD acesso = new AcessoBD();
        List<SqlParameter> parametros = new List<SqlParameter>();

        private void frmPesquisa_Load(object sender, EventArgs e)
        {
            this.Text += string.Format(" ({0})", txtAssunto.Text);
            CarregaCombo();
            CarregarGrid();
        }

        private void CarregaCombo()
        {
            try
            {
                DataTable dt = new DataTable();
                parametros.Clear();
                parametros.Add(new SqlParameter("@tabela", txtTabela.Text));
                dt = acesso.ConsultarSql("sp_retorna_colunas", parametros, CommandType.StoredProcedure);

                cboCampo.DataSource = dt;
                cboCampo.DisplayMember = "name";
                cboCampo.SelectedIndex = cboCampo.FindStringExact(txtCampoBusca.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: "+ex.Message, "Pesquisa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CarregarGrid()
        {
            try
            {
                if (txtPesquisa.Text != string.Empty)
                {
                    DataTable dtPesquisa = new DataTable();
                    parametros.Clear();
                    parametros.Add(new SqlParameter("@tabela", txtTabela.Text));
                    parametros.Add(new SqlParameter("@campos", txtCampos.Text));
                    parametros.Add(new SqlParameter("@campoBusca", cboCampo.Text));
                    parametros.Add(new SqlParameter("@busca", txtPesquisa.Text));
                    parametros.Add(new SqlParameter("@like", chkLike.Checked));

                    dtPesquisa = acesso.ConsultarSql("sp_pesquisa", parametros, CommandType.StoredProcedure);

                    if (dtPesquisa.Rows.Count > 0)
                    {
                        grdPesquisa.DataSource = dtPesquisa;
                        foreach (DataGridViewColumn coluna in grdPesquisa.Columns)
                        {
                            coluna.HeaderText = coluna.HeaderText.ToUpper();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nenhum registro localizado.", "Pesquisa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível efetuar a pesquisa.\nErro: "+ex.Message, "Pesquisa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            var retorno = txtCampoRetorno.Text.Split(',');
            Funcoes.strRetornoPesquisa = string.Empty;

            if (grdPesquisa.SelectedRows.Count > 0)
            {
                foreach (string campo in retorno)
                {
                    Funcoes.strRetornoPesquisa += "," + grdPesquisa.SelectedRows[0].Cells[campo.Trim()].Value.ToString();
                }

                Funcoes.strRetornoPesquisa = Funcoes.strRetornoPesquisa.Substring(1);

                this.Close();
            }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
           // CarregarGrid();
        }

        private void grdPesquisa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSelecionar.PerformClick();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Funcoes.strRetornoPesquisa = string.Empty;
            this.Close();
        }

        private void txtPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CarregarGrid();
                grdPesquisa.Focus();
            }
        }

        private void grdPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSelecionar.PerformClick();
            }
        }

        private void chkLike_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSelecionar.PerformClick();
            }
        }
    }
}
