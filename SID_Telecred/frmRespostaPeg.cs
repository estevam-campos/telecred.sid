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
    public partial class frmRespostaPeg : Form
    {
        public frmRespostaPeg()
        {
            InitializeComponent();
        }

        RespostaPeg resposta = new RespostaPeg();
        DataTable dt = new DataTable();

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            resposta = new RespostaPeg();
            resposta.strDescricao = txtPesquisar.Text;
            CarregarGrid();
        }

        private void grdRespostas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            resposta = new RespostaPeg();
            resposta.intCodigo = Convert.ToInt32(grdRespostas.SelectedRows[0].Cells[0].Value);
            resposta.Consultar();
            PreencherForm();
        }

        private void btnLimparCampos_Click(object sender, EventArgs e)
        {
            resposta = new RespostaPeg();
            txtPesquisar.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            rdbAtivo.Checked = true;
            rdbNao.Checked = true;
            rdbTratativaNao.Checked = true;
            rdbSoTratativaNao.Checked = true;
            CarregarGrid();
        }

        private void PreencherClasse()
        {
            resposta.strDescricao = txtDescricao.Text;
            resposta.blnAtivo = rdbAtivo.Checked;
            resposta.blnCampoExtra = rdbSim.Checked;
            resposta.blnEncaminhaTratativa = rdbTratativaSim.Checked;
            resposta.blnSomenteTratativa = rdbSoTratativaSim.Checked;
        }

        private void PreencherForm()
        {
            txtDescricao.Text = resposta.strDescricao;
            rdbAtivo.Checked = resposta.blnAtivo;
            rdbInativo.Checked = !resposta.blnAtivo;
            rdbSim.Checked = resposta.blnCampoExtra;
            rdbNao.Checked = !resposta.blnCampoExtra;
            rdbTratativaSim.Checked = resposta.blnEncaminhaTratativa;
            rdbTratativaNao.Checked = !resposta.blnEncaminhaTratativa;
            rdbSoTratativaSim.Checked = resposta.blnSomenteTratativa;
            rdbSoTratativaNao.Checked = !resposta.blnSomenteTratativa;
        }

        private void CarregarGrid()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                dt = resposta.Consultar();
                grdRespostas.DataSource = dt;
                grdRespostas.Columns[0].Visible = false;
                grdRespostas.Columns[3].Visible = false;
                grdRespostas.Columns[1].Width = 350;
                grdRespostas.Columns[2].Width = 100;
                grdRespostas.Columns[4].Width = 100;
                grdRespostas.Columns[5].Width = 100;
                grdRespostas.Columns[1].HeaderText = "Resposta";
                grdRespostas.Columns[2].HeaderText = "Campo Extra";
                grdRespostas.Columns[4].HeaderText = "Direciona Tratativa";
                grdRespostas.Columns[5].HeaderText = "Somente Tratativa";

                grdRespostas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                grdRespostas.ReadOnly = true;
                grdRespostas.MultiSelect = false;
                grdRespostas.AllowUserToAddRows = false;
                grdRespostas.RowHeadersVisible = false;
                grdRespostas.AllowUserToResizeColumns = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmRespostaPeg_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text == string.Empty)
            {
                MessageBox.Show("Preencha a resposta", "Sistema Integrado de Digitação Telecred",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                PreencherClasse();
                resposta.Gravar();
                MessageBox.Show("Resposta gravada com sucesso", "Sistema Integrado de Digitação Telecred",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnLimparCampos.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdRespostas_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void grdRespostas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Deseja excluir a resposta selecionada?", "Sistema Integrado de Digitação Telecred",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    PreencherClasse();
                    resposta.Excluir();
                    MessageBox.Show("Resposta excluída com sucesso", "Sistema Integrado de Digitação Telecred",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnLimparCampos.PerformClick();
                }
            }
        }
    }
}
