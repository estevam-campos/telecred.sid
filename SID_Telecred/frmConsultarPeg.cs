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
    public partial class frmConsultarPeg : Form
    {
        public frmConsultarPeg()
        {
            InitializeComponent();
        }

        RegistroPeg RegistroPeg = new RegistroPeg();

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CarregarPegs()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                int intTipoPesquisa = 0;
                if (rdbDisponivel.Checked)
                    intTipoPesquisa = 1;
                else if (rdbEmDigitacao.Checked)
                    intTipoPesquisa = 2;
                else if (rdbDigitado.Checked)
                    intTipoPesquisa = 3;
                else if (rdbMigrado.Checked)
                    intTipoPesquisa = 4;

                grdPegs.DataSource = Funcoes.ConsultarPegs(dtpDataPagamentoIdeal.Value, intTipoPesquisa);

                lblQtde.Text = grdPegs.Rows.Count.ToString();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Erro--> " + ex.Message,
                    "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarPegs();
        }

        private void frmConsultarPeg_Load(object sender, EventArgs e)
        {
            CarregarPegs();
        }

        private void rdbDisponivel_CheckedChanged(object sender, EventArgs e)
        {
            CarregarPegs();
        }

        private void rdbEmDigitacao_CheckedChanged(object sender, EventArgs e)
        {
            CarregarPegs();
        }

        private void rdbDigitado_CheckedChanged(object sender, EventArgs e)
        {
            CarregarPegs();
        }

        private void rdbMigrado_CheckedChanged(object sender, EventArgs e)
        {
            CarregarPegs();
        }

        private void rdbTodos_CheckedChanged(object sender, EventArgs e)
        {
            CarregarPegs();
        }

        private void dtpDataPagamentoIdeal_ValueChanged(object sender, EventArgs e)
        {
            CarregarPegs();
        }
    }
}
