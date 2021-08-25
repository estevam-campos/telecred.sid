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
    public partial class frmManutencaoLotes : Form
    {
        public frmManutencaoLotes()
        {
            InitializeComponent();
        }
        bool blnLoad = false;
        Lote oLote = new Lote();
        int intQtdeLotes = 0;
        private void frmManutencaoLotes_Load(object sender, EventArgs e)
        {
            blnLoad = false;
            PreencherServico();
            PreencherStatusLote();
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
        private void PreencherStatusLote()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                cboStatus.DataSource = Funcoes.CarregarStatusLote();
                cboStatus.DisplayMember = "SLO_DESCRICAO";
                cboStatus.ValueMember = "SLO_CODIGO";
                cboStatus.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro--> " + ex.Message,
                    "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void PreencherLotes()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                trwLotes.Nodes.Clear();
                intQtdeLotes = 0;
                oLote.intCodigoCaixa = Convert.ToInt32(cboCaixas.SelectedValue);
                oLote.intCodigoServico = Convert.ToInt32(cboServico.SelectedValue);
                foreach (DataRow linha in oLote.ConsultarLote().Rows)
                {
                    //trwDisponiveis.Nodes.Add("Permissões");
                    trwLotes.Nodes.Add(linha[1].ToString() + "  (" + linha[2].ToString() + ")");
                    intQtdeLotes++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro--> " + ex.Message,
                    "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void cboServico_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (blnLoad)
            {
                CarregarCaixas();
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelTodos_Click(object sender, EventArgs e)
        {
            for (int intContador = 0; intContador < intQtdeLotes; intContador++)
            {
                if (!trwLotes.Nodes[intContador].Checked)
                {
                    trwLotes.Nodes[intContador].Checked = true;
                }
            }
        }

        private void btnDesmTodos_Click(object sender, EventArgs e)
        {
            for (int intContador = 0; intContador < intQtdeLotes; intContador++)
            {
                if (trwLotes.Nodes[intContador].Checked)
                {
                    trwLotes.Nodes[intContador].Checked = false;
                }
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                int intMarcados = 0;
                if (cboStatus.SelectedIndex != -1)
                {
                    for (int intContador = 0; intContador < intQtdeLotes; intContador++)
                    {
                        if (trwLotes.Nodes[intContador].Checked)
                        {
                            intMarcados++;
                            oLote.intCodigo = 0;
                            oLote.intCodigoCaixa = Convert.ToInt32(cboCaixas.SelectedValue);
                            oLote.strLote = trwLotes.Nodes[intContador].Text.Substring(0, trwLotes.Nodes[intContador].Text.IndexOf('(') - 1).Trim();
                            oLote.intStatusLote = Convert.ToInt32(cboStatus.SelectedValue);
                            oLote.AlterarStatus();
                        }
                    }

                    if (intMarcados != 0)
                    {
                        MessageBox.Show("Status dos lotes alterados com sucesso", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PreencherLotes();
                        cboStatus.SelectedIndex = -1;
                        intMarcados = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CarregarCaixas()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                blnLoad = false;
                cboCaixas.DataSource = Funcoes.CarregarCaixas(Convert.ToInt32(cboServico.SelectedValue), Funcoes.StatusLote.Nenhum);
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

        private void cboCaixas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (blnLoad)
            {
                PreencherLotes();
            }
        }
    }
}
