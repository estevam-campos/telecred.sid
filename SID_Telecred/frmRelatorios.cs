using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace SID_Telecred
{
    public partial class frmRelatorios : Form
    {
        public frmRelatorios()
        {
            InitializeComponent();
        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmRelatorios_Load(object sender, EventArgs e)
        {
            PreencherServico();
            PreencherUsuario();
        }
        private void PreencherServico()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                cboServico.DataSource = Funcoes.CarregarServico(true);
                cboServico.DisplayMember = "SER_DESCRICAO";
                cboServico.ValueMember = "SER_CODIGO";
                cboServico.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PreencherUsuario()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                cboUsuario.DataSource = Funcoes.CarregarUsuario(true);
                cboUsuario.DisplayMember = "USU_NOME";
                cboUsuario.ValueMember = "USU_CODIGO";
                cboUsuario.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }
        private void LimparCampos()
        {
            cboUsuario.SelectedIndex = -1;
            cboServico.SelectedIndex = -1;
            rdbServico.Checked = true;
            dtpDe.Value = DateTime.Now;
            dtpAte.Value = DateTime.Now;
            grdRelatorios.DataSource = null;
        }
        private void btnGerar_Click(object sender, EventArgs e)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                if (cboServico.SelectedIndex != -1 && cboUsuario.SelectedIndex != -1)
                {
                    grdRelatorios.DataSource = null;
                    grdRelatorios.DataSource = Funcoes.GerarRelatorio
                        (rdbServico.Checked, Convert.ToInt32(cboServico.SelectedValue), Convert.ToInt32(cboUsuario.SelectedValue), dtpDe.Value, dtpAte.Value);
                    grdRelatorios.Columns[0].Width = rdbUsuario.Checked ? 300 : 200;
                    grdRelatorios.Columns[1].Width = rdbUsuario.Checked ? 200 : 300;
                    grdRelatorios.Columns[2].Width = 100;
                    grdRelatorios.Columns[3].Width = 55;
                }
                else
                {
                    MessageBox.Show("Selecione as opções de filtros.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                sfdRelatorio.FileName = "Relatorio_" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "_") + ".csv";
                sfdRelatorio.Filter = "Arquivos CSV|*.csv";
                if (sfdRelatorio.ShowDialog() == DialogResult.OK)
                {
                    string strFile = sfdRelatorio.FileName;
                    using (FileStream fs = new FileStream(strFile, FileMode.Create, FileAccess.Write)) ;
                    StreamWriter strArquivo = new StreamWriter(strFile);

                    foreach (DataGridViewRow linha in grdRelatorios.Rows)
                    {
                        string strLinha = string.Empty;
                        foreach (DataGridViewCell celula in linha.Cells)
                        {
                            strLinha += ";" + celula.Value.ToString();
                        }
                        strLinha = strLinha.Substring(1);
                        strArquivo.WriteLine(strLinha);
                    }
                    strArquivo.Close();
                    strArquivo.Dispose();
                    MessageBox.Show("Arquivo gerado com sucesso", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
