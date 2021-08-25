using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace SID_Telecred
{
    public partial class frmExpurgo : Form
    {
        public frmExpurgo()
        {
            InitializeComponent();
        }
        bool blnLoad = false;
        bool blnProcessando = false;
        private void frmExpurgo_Load(object sender, EventArgs e)
        {
            blnLoad = false;
            PreencherServico();
            blnLoad = true;
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

        private void cboServico_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (blnLoad)
            {
                CarregarCaixas();
            }
        }
        private void CarregarCaixas()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                blnLoad = false;
                lstDisponiveis.Items.Clear();
                lstSelecionados.Items.Clear();
                foreach (DataRow linha in Funcoes.CarregarCaixas(Convert.ToInt32(cboServico.SelectedValue), Funcoes.StatusLote.Finalizado).Rows) 
                {
                    lstDisponiveis.Items.Add(linha[1].ToString());
                }
                lstDisponiveis.SelectedIndex = -1;

                blnLoad = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddTodos_Click(object sender, EventArgs e)
        {
            for (int intContador = 0; intContador < lstDisponiveis.Items.Count; intContador++)
            {
                if (lstSelecionados.Items.IndexOf(lstDisponiveis.Items[intContador].ToString()) == -1)
                {
                    lstSelecionados.Items.Add(lstDisponiveis.Items[intContador].ToString());
                }
            }
            lstDisponiveis.Items.Clear();
            grpSelecionados.Text = "Selecionados - " + lstSelecionados.Items.Count;
        }

        private void btnRemTodos_Click(object sender, EventArgs e)
        {
            for (int intContador = 0; intContador < lstSelecionados.Items.Count; intContador++)
            {
                lstDisponiveis.Items.Add(lstSelecionados.Items[intContador].ToString());
            }
            lstSelecionados.Items.Clear();
        }

        private void btnAddCaixa_Click(object sender, EventArgs e)
        {
            if (lstDisponiveis.SelectedIndex != -1)
            {

                if (lstSelecionados.Items.IndexOf(lstDisponiveis.Text) == -1)
                {
                    lstSelecionados.Items.Add(lstDisponiveis.Text);
                    lstDisponiveis.Items.RemoveAt(lstDisponiveis.SelectedIndex);
                }
            }
        }

        private void btnRemCaixa_Click(object sender, EventArgs e)
        {
            if (lstSelecionados.SelectedIndex != -1)
            {
                lstDisponiveis.Items.Add(lstSelecionados.Text);
                lstSelecionados.Items.RemoveAt(lstSelecionados.SelectedIndex);
            }
        }

        private void lstDisponiveis_DoubleClick(object sender, EventArgs e)
        {
            btnAddCaixa.PerformClick();
        }

        private void lstSelecionados_DoubleClick(object sender, EventArgs e)
        {
            btnRemCaixa.PerformClick();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            if (!blnProcessando)
            {
                this.Close();
            }
            else
            {
                blnProcessando = false;
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                if (MessageBox.Show("Inicia Expurgo das caixas selecionadas?", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    blnProcessando = true;
                    btnExportar.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;
                    Exportacao export = new Exportacao();
                    int intCont = 0;

                    foreach (string strCaixa in lstSelecionados.Items)
                    {
                        intCont++;
                        lblRegistros.Text = string.Format("{0} de {1}", intCont, lstSelecionados.Items.Count);
                        Application.DoEvents();
                        Caixa caixa = new Caixa();
                        caixa.strCaixa = strCaixa;
                        caixa.intCodigoServico = Convert.ToInt32(cboServico.SelectedValue);
                        export.Expurgar(caixa);
                        Application.DoEvents();
                        if (blnProcessando == false)
                        {
                            break;
                        }
                    }
                    btnExportar.Enabled = true;
                    this.Cursor = Cursors.Default;
                    if (blnProcessando)
                    {
                        MessageBox.Show("Caixas Expurgadas com sucesso", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    CarregarCaixas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
