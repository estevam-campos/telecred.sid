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
    public partial class frmEstatisticasPegPortal : Form
    {
        public frmEstatisticasPegPortal()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEstatisticasPegPortal_Load(object sender, EventArgs e)
        {
            CarregarEstatisticas();
        }
        private void CarregarEstatisticas()
        {
            try
            {
                int intTipoPesquisa = 0;
                if (rdbEmDigitacao.Checked)
                    intTipoPesquisa = 1;
                else if (rdbFechados.Checked)
                    intTipoPesquisa = 2;

                grdEstatisticas.DataSource = Funcoes.CarregarEstatisticasPegPortal(intTipoPesquisa, dtpInicio.Value, dtpFim.Value);

                grdEstatisticas.Columns[0].Width = 90;
                grdEstatisticas.Columns[1].Width = 100;
                grdEstatisticas.Columns[2].Width = 170;
                grdEstatisticas.Columns[4].Width = 70;
                grdEstatisticas.Columns[3].Width = 70;
                grdEstatisticas.Columns[5].Width = 70;
                grdEstatisticas.Columns[6].Width = 70;
                grdEstatisticas.Columns[7].Width = 70;
                grdEstatisticas.Columns[8].Width = 70;
                grdEstatisticas.Columns[9].Width = 70;
                grdEstatisticas.Columns[10].Width = 70;
                grdEstatisticas.Columns[11].Width = 70;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro--> " + ex.Message,
                    "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarEstatisticas();
        }

        private void rdbEmDigitacao_CheckedChanged(object sender, EventArgs e)
        {
            //CarregarEstatisticas();
        }

        private void rdbFechados_CheckedChanged(object sender, EventArgs e)
        {
            //CarregarEstatisticas();
        }

        private void rdbTodos_CheckedChanged(object sender, EventArgs e)
        {
           // CarregarEstatisticas();
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            grdEstatisticas.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            grdEstatisticas.SelectAll();            
            DataObject dataObj = grdEstatisticas.GetClipboardContent();
            Clipboard.SetDataObject(dataObj, true);
            MessageBox.Show("Conteúdo copiado para a área de transferência.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dtpInicio_ValueChanged(object sender, EventArgs e)
        {
            //CarregarEstatisticas();
        }

        private void dtpFim_ValueChanged(object sender, EventArgs e)
        {
            //CarregarEstatisticas();
        }
    }
}
