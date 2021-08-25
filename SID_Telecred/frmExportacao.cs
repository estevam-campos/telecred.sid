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
    public partial class frmExportacao : Form
    {
        public frmExportacao()
        {
            InitializeComponent();
        }

        Exportacao oExportacao = new Exportacao();
        Lote oLote = new Lote();
        bool blnLoad = false;
        string strChave;
        private void HabilitarControles(bool blnHabilitar)
        {
            cboCaixas.Enabled = blnHabilitar;
            cboServico.Enabled = blnHabilitar;
            lstDisponiveis.Enabled = blnHabilitar;
            lstSelecionados.Enabled = blnHabilitar;
            btnAddLote.Enabled = blnHabilitar;
            btnAddTodos.Enabled = blnHabilitar;
            btnExportar.Enabled = blnHabilitar;
            btnFechar.Enabled = blnHabilitar;
            btnRemLote.Enabled = blnHabilitar;
            btnTodos.Enabled = blnHabilitar;
            btnRemTodos.Enabled = blnHabilitar;
            chkFormalizacao.Enabled = blnHabilitar;
            
           
        }
        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                if (MessageBox.Show("Inicia Exportação?", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    HabilitarControles(false);
                    //tmrExportar.Enabled = true;                    
                    oExportacao.intCodigoServico = Convert.ToInt32(cboServico.SelectedValue);
                    oExportacao.dttDataExportacao = DateTime.Now;
                    //tmrExportar.Enabled = true;
                    //pgbProgresso.Maximum = lstSelecionados.Items.Count;
                    //pgbProgresso.Value = 0;
                    //tmrExportar.Enabled = true;
                    strChave = Funcoes.Encrypt(DateTime.Now.ToString(), true);
                    oExportacao.Lotes.Clear();
                        
                    foreach (string lote in lstSelecionados.Items)
                    {
                        oExportacao.Lotes.Add(lote);
                        oExportacao.strChave = strChave;
                    }
                        Funcoes.intQtdeRegistros = oExportacao.SelecionarRegistros();

                        if (Funcoes.intQtdeRegistros == 0)
                        {
                            MessageBox.Show("Nenhum registro encontrado.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            HabilitarControles(true);
                            return;
                        }

                        //grpRegistros.Visible = false;
                        tmrExportar.Enabled = true;

                        Funcoes.intQtdeLotes = 0;
                        oExportacao.ExportarRegistros(chkFormalizacao.Checked, cboServico.Text);
                    tmrExportar.Enabled = false;
                    MessageBox.Show("Arquivos exportados com sucesso", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HabilitarControles(true);
                    cboCaixas.SelectedIndex = -1;
                    cboServico.SelectedIndex = -1;
                    lstDisponiveis.Items.Clear();
                    lstSelecionados.Items.Clear();
                    Cursor.Current = Cursors.Arrow;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmExportacao_Load(object sender, EventArgs e)
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
        private void PreencherDisponiveis()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                lstDisponiveis.Items.Clear();
                //lstSelecionados.Items.Clear();
                oLote.intCodigoServico = Convert.ToInt32(cboServico.SelectedValue);
                oLote.intCodigoCaixa = Convert.ToInt32(cboCaixas.SelectedValue);
                foreach (DataRow linha in oLote.ConsultarLote(chkExportados.Checked ? (int)Funcoes.StatusLote.Finalizado : (int)Funcoes.StatusLote.AguardandoUpload).Rows)
                {
                    lstDisponiveis.Items.Add(linha[1].ToString());
                }
                lstDisponiveis.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tmrExportar_Tick(object sender, EventArgs e)
        {
            //Application.DoEvents();
            //pgbProgresso.Value = Funcoes.intContReg;
            Application.DoEvents();
            lblRegistros.Text = Funcoes.intContReg.ToString();
            Application.DoEvents();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CarregarCaixas()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                blnLoad = false;
                cboCaixas.DataSource = Funcoes.CarregarCaixas(Convert.ToInt32(cboServico.SelectedValue), chkExportados.Checked ? Funcoes.StatusLote.Finalizado : Funcoes.StatusLote.AguardandoUpload);
                cboCaixas.DisplayMember = "CAI_NUMERO";
                cboCaixas.ValueMember = "CAI_CODIGO";
                cboCaixas.SelectedIndex = -1;
                blnLoad = true;
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
                btnTodos.Enabled = true;
            }
        }

        private void btnAddTodos_Click(object sender, EventArgs e)
        {
            for (int intContador = 0; intContador < lstDisponiveis.Items.Count; intContador++)
            {
                string strLote = cboCaixas.SelectedValue.ToString() + "-" + lstDisponiveis.Items[intContador];
                if (lstSelecionados.Items.IndexOf(strLote) == -1)
                {
                    lstSelecionados.Items.Add(strLote);
                }
            }
            lstDisponiveis.Items.Clear();
            grpSelecionados.Text = "Selecionados - " + lstSelecionados.Items.Count;
        }

        private void btnRemTodos_Click(object sender, EventArgs e)
        {
            for (int intContador = 0; intContador < lstSelecionados.Items.Count; intContador++)
            {
                if (Convert.ToInt32(cboCaixas.SelectedValue) == Convert.ToInt32(lstSelecionados.Items[intContador].ToString().Substring(0, lstSelecionados.Items[intContador].ToString().IndexOf('-'))) &&
                    lstDisponiveis.Items.IndexOf(lstSelecionados.Items[intContador].ToString().Substring(lstSelecionados.Items[intContador].ToString().IndexOf('-') + 1)) == -1)
                {
                    lstDisponiveis.Items.Add(lstSelecionados.Items[intContador].ToString().Substring(lstSelecionados.Items[intContador].ToString().IndexOf('-') + 1));
                }
            }
            lstSelecionados.Items.Clear();
        }

        private void btnAddLote_Click(object sender, EventArgs e)
        {
            if (lstDisponiveis.SelectedIndex != -1)
            {
                string strLote = cboCaixas.SelectedValue.ToString() + "-" + lstDisponiveis.Text;
                if (lstSelecionados.Items.IndexOf(strLote) == -1)
                {
                    lstSelecionados.Items.Add(cboCaixas.SelectedValue.ToString() + "-" + lstDisponiveis.Text);
                }
                lstDisponiveis.Items.RemoveAt(lstDisponiveis.SelectedIndex);
            }
        }

        private void btnRemLote_Click(object sender, EventArgs e)
        {
            if (lstSelecionados.SelectedIndex != -1)
            {
                if (Convert.ToInt32(lstSelecionados.Items[lstSelecionados.SelectedIndex].ToString().Substring(0, lstSelecionados.Items[lstSelecionados.SelectedIndex].ToString().IndexOf('-'))) == Convert.ToInt32(cboCaixas.SelectedValue) &&
                lstDisponiveis.Items.IndexOf(lstSelecionados.Text.Substring(lstSelecionados.Text.IndexOf('-') + 1)) == -1)
                {
                    lstDisponiveis.Items.Add(lstSelecionados.Text.Substring(lstSelecionados.Text.IndexOf('-') + 1));
                }
                lstSelecionados.Items.RemoveAt(lstSelecionados.SelectedIndex);
            }
        }

        private void lstDisponiveis_DoubleClick(object sender, EventArgs e)
        {
            btnAddLote.PerformClick();
        }

        private void lstSelecionados_DoubleClick(object sender, EventArgs e)
        {
            btnRemLote.PerformClick();
        }

        private void cboCaixas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (blnLoad)
            {
                PreencherDisponiveis();
            }
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja adicionar todos os lotes de todas as caixas do serviço selecionado?", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //HabilitarControles(false);    
                for (int intContador = 0; intContador < cboCaixas.Items.Count; intContador++)
                {
                    cboCaixas.SelectedIndex = intContador;
                    Application.DoEvents();
                    btnAddTodos.PerformClick();
                    Application.DoEvents();
                }
                //HabilitarControles(true);    
            }
        }

        private void chkExportados_CheckedChanged(object sender, EventArgs e)
        {
            if (blnLoad)
            {
                CarregarCaixas();
                btnTodos.Enabled = true;
            }
        }
    }
}
