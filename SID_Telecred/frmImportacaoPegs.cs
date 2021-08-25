using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.CSharp.RuntimeBinder;
using System.IO;

namespace SID_Telecred
{
    public partial class frmImportacaoPegs : Form
    {
        public frmImportacaoPegs()
        {
            InitializeComponent();
        }

        string strArquivo = string.Empty;

        private void frmImportacaoPegs_Load(object sender, EventArgs e)
        {
            CarregarImportados();
        }
        private void CarregarImportados()
        {
            try
            {
                DataTable dtImportacao = new ArquivoPeg().Consultar(); 
                grdImportacao.DataSource = dtImportacao;
                grdImportacao.Columns[0].Visible = false;

                grdImportacao.Columns[1].Width = 80;
                grdImportacao.Columns[2].Width = 80;
                grdImportacao.Columns[3].Width = 80;
                grdImportacao.Columns[4].Width = 80;
                grdImportacao.Columns[5].Width = 80;
                grdImportacao.Columns[6].Width = 80;
                grdImportacao.Columns[7].Width = 120;
                grdImportacao.Columns[8].Width = 350;
                grdImportacao.Columns[9].Width = 300;
                grdImportacao.Columns[10].Width = 100;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult result = ofdArquivo.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                MessageBox.Show("Importação cancelada pelo usuário", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }           
            strArquivo = ofdArquivo.FileName;
            txtArquivo.Text = Path.GetFileName(ofdArquivo.FileName);
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {            
            if (txtArquivo.Text == string.Empty)
            {
                MessageBox.Show("Selecione o arquivo a ser importado.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ArquivoPeg arquivo = new ArquivoPeg();
            arquivo.strArquivo = txtArquivo.Text;

            if (arquivo.Consultar().Rows.Count != 0)
            {
                MessageBox.Show("Arquivo já importando anteriormente", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (MessageBox.Show(string.Format("Deseja iniciar a importação do arquivo {0}?", txtArquivo.Text), "Sistema Integrado de Digitação Telecred",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            
            try
            {                
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                Excel.Range range;

                this.Cursor = Cursors.WaitCursor;
                lblAndamento.Text = "Abrindo arquivo...";

                arquivo = new ArquivoPeg();
                arquivo.strArquivo = txtArquivo.Text;
                arquivo.dttInicioImportacao = DateTime.Now;

                RegistroPeg registro = new RegistroPeg();

                double rCnt;
                double cCnt;
                double rw = 0;
                double cl = 0;
                double percentual = 0;

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(strArquivo, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.Item[1];//  xlWorkBook.Worksheets.get_Item(1);
                lblAndamento.Text = "Contabilizando registros...";
                Application.DoEvents();
                range = xlWorkSheet.UsedRange;
                rw = range.Rows.Count;
                cl = range.Columns.Count;

                pgbImportacao.Maximum = (int)rw;

                for (rCnt = 1; rCnt <= rw; rCnt++)
                {
                    pgbImportacao.Value++;
                    percentual = rCnt / rw;
                    percentual = percentual * 100;
                    lblAndamento.Text = string.Format("Lendo registros {0}% de {1}", percentual.ToString("##0.00"), rw);
                    Application.DoEvents();
                    registro = new RegistroPeg();
                    for (cCnt = 1; cCnt <= cl; cCnt++)
                    {
                        if (rCnt > 1)
                        {
                            if (cCnt == 1)
                                registro.intPeg = Convert.ToInt32((range.Cells[rCnt, cCnt] as Excel.Range).Value2);
                            else if (cCnt == 2)
                                registro.dttDataRecebimento = DateTime.FromOADate((double)(range.Cells[rCnt, cCnt] as Excel.Range).Value2);
                            else if (cCnt == 3)
                                registro.dttDataPagamentoIdeal = DateTime.FromOADate((double)(range.Cells[rCnt, cCnt] as Excel.Range).Value2);
                            else if (cCnt == 4)
                                registro.strRegimeAtendimento = Convert.ToString((range.Cells[rCnt, cCnt] as Excel.Range).Value2);
                            else if (cCnt == 5)
                                registro.strModulo = Convert.ToString((range.Cells[rCnt, cCnt] as Excel.Range).Value2);
                            else if (cCnt == 6)
                                registro.strClassificacao = Convert.ToString((range.Cells[rCnt, cCnt] as Excel.Range).Value2);
                            else if (cCnt == 7)
                                registro.decValor = Convert.ToDecimal((range.Cells[rCnt, cCnt] as Excel.Range).Value2);
                            else if (cCnt == 8)
                                registro.dttDataEnvio = DateTime.FromOADate((double)(range.Cells[rCnt, cCnt] as Excel.Range).Value2);
                            else if (cCnt == 9)
                                registro.strEmpresa = Convert.ToString((range.Cells[rCnt, cCnt] as Excel.Range).Value2);
                            else if (cCnt == 10)
                                registro.strConvenio = Funcoes.RemoveAcentos(Convert.ToString((range.Cells[rCnt, cCnt] as Excel.Range).Value2));
                        }

                    }
                    if (rCnt > 1)
                    {
                        if (registro.strModulo.ToLower().IndexOf("diamante") != -1 && registro.strRegimeAtendimento.ToLower().IndexOf("consultório / clinica") != -1)
                        {
                            arquivo.intDiamante++;
                            registro.blnDiamante = true;
                            registro.intTipoPeg = 4;
                        }
                        else if (registro.strRegimeAtendimento.ToLower().IndexOf("consultório / clinica") != -1)
                        {
                            arquivo.intConsulta++;
                            registro.intTipoPeg = 1;
                        }
                        else if (registro.strRegimeAtendimento.ToLower().IndexOf("atendimento externo") != -1)
                        {
                            arquivo.intSADT++;
                            registro.intTipoPeg = 2;
                        }
                        else if (registro.strRegimeAtendimento.ToLower().IndexOf("hospital / maternidade") != -1)
                        {
                            arquivo.intHospital++;
                            registro.intTipoPeg = 3;
                        }

                        arquivo.registros.Add(registro);
                    }

                }

                xlWorkBook.Close(true, null, null);
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlApp);

                lblAndamento.Text = "Gravando registros...";
                Application.DoEvents();

                string arquivoDuplicidade = arquivo.Gravar(strArquivo);

                this.Cursor = Cursors.Default;

                if (arquivoDuplicidade != string.Empty)
                {
                    MessageBox.Show(string.Format("Existem duplicidades dentro do arquivo. \nVerificar o arquivo de log {0}", arquivoDuplicidade), 
                        "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                MessageBox.Show("Importação efetuada com sucesso", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblAndamento.Text = string.Empty;
                pgbImportacao.Value = 0;
                CarregarImportados();
                //this.Close();
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimparCampos_Click(object sender, EventArgs e)
        {
            CarregarImportados();
            txtArquivo.Clear();
            ofdArquivo.FileName = string.Empty;            
        }
    }
}
