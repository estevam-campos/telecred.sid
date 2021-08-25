using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace SID_Telecred
{
    public partial class frmDavitaImportacao : Form
    {
        public frmDavitaImportacao()
        {
            InitializeComponent();
        }

        string strArquivo = string.Empty;
        int linhaGrid = 0;
        private void btnCarregarPlanilha_Click(object sender, EventArgs e)
        {

            DialogResult result = ofdArquivo.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                MessageBox.Show("Carregamento cancelado pelo usuário", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnCarregarPlanilha.Enabled = false;

            strArquivo = ofdArquivo.FileName;
            lblAndamento.Text = ofdArquivo.FileName;

            pgbImportacao.Visible = true;
            pgbPlanilhas.Visible = true;
            lblPlanilhas.Visible = true;
            lblRegistros.Visible = true;

            try
            {
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Range range;

                this.Cursor = Cursors.WaitCursor;
                //lblAndamento.Text = "Abrindo arquivo...";

                double rCnt;
                double cCnt;
                double rw = 0;
                double cl = 0;

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(strArquivo, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                //List<Excel.Worksheet> planilhas = new List<Excel.Worksheet>();
                pgbPlanilhas.Value = 0;
                pgbPlanilhas.Maximum = xlWorkBook.Worksheets.Count;

                foreach (Excel.Worksheet planilha in xlWorkBook.Worksheets)
                {
                    pgbPlanilhas.Value++;
                    lblPlanilhas.Text = string.Format("{0}/{1}", pgbPlanilhas.Value, pgbPlanilhas.Maximum);
                    Application.DoEvents();
                    // planilhas.Add(planilha);

                    TabPage tabPage = new TabPage();
                    tabPage.Name = planilha.Name;// "Planilha" + pgbPlanilhas.Value.ToString();
                    tabPage.Text = tabPage.Name;
                    DataGridView dataGrid = new DataGridView();

                    dataGrid.Name = "grd" + tabPage.Name;
                    dataGrid.Left = 8;
                    dataGrid.Top = 8;
                    dataGrid.Width = 850;
                    dataGrid.Height = 437;

                    Application.DoEvents();
                    range = planilha.UsedRange;
                    rw = range.Rows.Count;
                    cl = range.Columns.Count;

                    for (int cont = 0; cont < cl; cont++)
                    {
                        dataGrid.Columns.Add(string.Format("Coluna{0}", cont + 1), string.Format("Coluna{0}", cont + 1));
                        dataGrid.Columns[cont].SortMode = DataGridViewColumnSortMode.NotSortable;
                    }

                    dataGrid.AllowUserToAddRows = false;
                    dataGrid.AllowUserToDeleteRows = false;
                    dataGrid.AllowUserToOrderColumns = false;
                    dataGrid.AllowUserToResizeColumns = false;
                    dataGrid.AllowUserToResizeRows = false;
                    dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                    dataGrid.MultiSelect = false;
                    dataGrid.ReadOnly = true;
                    dataGrid.RowHeadersVisible = false;
                    dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    //dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    pgbImportacao.Maximum = (int)rw;
                    pgbImportacao.Value = 0;

                    for (rCnt = 1; rCnt <= rw; rCnt++)
                    {
                        pgbImportacao.Value++;
                        lblRegistros.Text = string.Format("{0}/{1}", pgbImportacao.Value, rw);
                        Application.DoEvents();
                        //percentual = rCnt / rw;
                        //percentual = percentual * 100;
                        //lblAndamento.Text = string.Format("Lendo registros {0}% de {1}", percentual.ToString("##0.00"), rw);
                        Application.DoEvents();
                        //registro = new RegistroPeg();
                        DataGridViewRow linha = new DataGridViewRow();
                        string slinha = string.Empty;// slinha = ";" + rCnt.ToString();
                        for (cCnt = 1; cCnt <= cl; cCnt++)
                        {

                            var valor = (range.Cells[rCnt, cCnt] as Excel.Range).Value2;

                            //double convertido = 0;

                            //if (Double.TryParse(valor, out convertido))
                            //{
                            if (valor == null)
                                slinha += ";";
                            else
                            {
                                if (valor.GetType() == typeof(string))
                                {
                                    slinha += ";" + valor;
                                }
                                else if (valor.GetType() == typeof(DateTime))
                                {
                                    slinha += ";" + valor.ToString("dd/MM/yyyy");
                                }
                                else if (valor.GetType() == typeof(int) || valor.GetType() == typeof(double))
                                {
                                    slinha += ";" + valor.ToString("N");
                                }
                            }

                            //}
                            //else
                            //{
                            //    slinha += ";" + valor;
                            //}                           

                        }
                        dataGrid.Rows.Add(slinha.Substring(1).Split(';'));
                    }

                    tabPage.Controls.Add(dataGrid);

                    PictureBox picture = new PictureBox();
                    picture.Name = "pctLote" + tabPage.Name;
                    picture.SizeMode = PictureBoxSizeMode.Zoom;
                    picture.Width = 25;
                    picture.Height = 25;
                    picture.Image = Properties.Resources.delete;
                    picture.Left = 860;
                    picture.Top = 10;
                    picture.BorderStyle = BorderStyle.FixedSingle;

                    Label lbl = new Label();
                    lbl.Text = "Definição do Número do Lote";
                    lbl.AutoSize = true;
                    lbl.Left = 890;
                    lbl.Top = 15;
                    lbl.Name = "lblLote" + tabPage.Name;

                    tabPage.Controls.Add(picture);
                    tabPage.Controls.Add(lbl);

                    picture = new PictureBox();
                    picture.Name = "pctCabecalho" + tabPage.Name;
                    picture.SizeMode = PictureBoxSizeMode.Zoom;
                    picture.Width = 25;
                    picture.Height = 25;
                    picture.Image = Properties.Resources.delete;
                    picture.Left = 860;
                    picture.Top = 40;
                    picture.BorderStyle = BorderStyle.FixedSingle;

                    lbl = new Label();
                    lbl.Text = "Definição do Cabeçalho";
                    lbl.AutoSize = true;
                    lbl.Left = 890;
                    lbl.Top = 45;
                    lbl.Name = "lblLote" + tabPage.Name;

                    tabPage.Controls.Add(picture);
                    tabPage.Controls.Add(lbl);

                    this.tabPlanilha.Controls.Add(tabPage);
                }


                xlWorkBook.Close(true, null, null);
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlApp);

                btnLote.Enabled = true;
                btnDefinirCabecalho.Enabled = true;
                btnRemoverAba.Enabled = true;
                btnProcessar.Enabled = true;
                btnCarregarPlanilha.Enabled = false;
                tabPlanilha.Visible = true;
                this.Width = 1146;
                this.Height = 621;
                Application.DoEvents();

                MessageBox.Show("Arquivo carregado com sucesso!!", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);




            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnCarregarPlanilha.Enabled = true;
            }
            finally
            {
                this.Cursor = Cursors.Default;
                pgbImportacao.Visible = false;
                pgbPlanilhas.Visible = false;
                lblPlanilhas.Visible = false;
                lblRegistros.Visible = false;
                lblAndamento.Text = string.Empty;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            //txtArquivo.Text = Path.GetFileName(ofdArquivo.FileName);
        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDefinirCabecalho_Click(object sender, EventArgs e)
        {
            if (tabPlanilha.SelectedTab.Tag == null)
            {
                MessageBox.Show("É necessário definir o lote dessa planilha antes de definir o cabeçalho.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Confirma a definição da linha selecionada como cabeçalho?", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                if (chkCabecalho.Checked)
                {
                    foreach (TabPage page in tabPlanilha.TabPages)
                    {
                        DefinirCabecalho(page);
                    }
                }
                else
                {
                    DefinirCabecalho(tabPlanilha.SelectedTab);
                }

                MessageBox.Show("Cabeçalhos definidos com sucesso!!", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.WaitCursor;
            }
        }

        private void DefinirCabecalho(TabPage tabPage)
        {
            try
            {
                DataGridView grid = tabPage.Controls.Find("grd" + tabPage.Name, true)[0] as DataGridView;

                if (grid.Columns[0].HeaderText.IndexOf("Coluna1") == -1)
                {
                    return;
                }

                grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (linhaGrid == 0)
                {
                    linhaGrid = grid.CurrentRow.Index;
                }

                grid.Rows[linhaGrid].Selected = true;
                Application.DoEvents();

                grid.Columns.Add("Ordem", "Ordem");
                int nr_linha = 0;
                int nr_coluna = grid.Columns.Count - 1;
                foreach (DataGridViewRow row in grid.Rows)
                {
                    nr_linha++;
                    row.Cells[nr_coluna].Value = nr_linha.ToString();
                    if (row.Selected)
                        break;
                }

                string linha = grid.SelectedRows[0].Cells[nr_coluna].Value.ToString();


                foreach (DataGridViewColumn coluna in grid.Columns)
                {
                    coluna.HeaderText = grid.SelectedRows[0].Cells[coluna.Index].Value.ToString();
                }


                do
                {
                    grid.Rows.RemoveAt(0);
                } while (grid.Rows[0].Cells[nr_coluna].Value != null);

                grid.Columns.RemoveAt(nr_coluna);

                ComboBox cbo = new ComboBox();
                cbo.DropDownStyle = ComboBoxStyle.DropDownList;
                cbo.Name = "cbo" + tabPage.Text;
                cbo.Left = 860;
                cbo.Top = 110;
                cbo.Width = 230;

                //tabPlanilha.SelectedTab.Controls.RemoveByKey(cbo.Name);

                Label lbl = new Label();
                lbl.Text = "Selecione a coluna de entrada para associação";
                lbl.AutoSize = true;
                lbl.Left = 860;
                lbl.Top = 95;
                lbl.Name = "lbl" + tabPage.Text;

                //tabPlanilha.SelectedTab.Controls.RemoveByKey(lbl.Name);
                cbo.Items.Add("");
                foreach (DataGridViewColumn coluna in grid.Columns)
                {
                    if (coluna.HeaderText != string.Empty)
                        cbo.Items.Add(coluna.HeaderText);
                }

                tabPage.Controls.Add(cbo);
                tabPage.Controls.Add(lbl);

                ComboBox cboSaida = new ComboBox();
                cboSaida.DropDownStyle = ComboBoxStyle.DropDownList;
                cboSaida.Name = "cbo" + tabPage.Text + "_saida";
                cboSaida.Left = 860;
                cboSaida.Top = 160;
                cboSaida.Width = 230;
                //cboSaida.Items.Add("Atendimento");
                //cboSaida.Items.Add("Atendimento paciente");
                cboSaida.Items.Add("Data");
                cboSaida.Items.Add("Código Procedimento");
                cboSaida.Items.Add("Carteirinha");
                cboSaida.Items.Add("Valor");
                cboSaida.Items.Add("Quantidade");
                cboSaida.Items.Add("Senha");
                //cboSaida.Items.Add("Atendimento medico crm");
                //cboSaida.Items.Add("Atendimento medico responsavel");
                cboSaida.Items.Add("CBOS");

                //tabPlanilha.SelectedTab.Controls.RemoveByKey(cbo.Name);

                tabPage.Controls.Add(cboSaida);

                lbl = new Label();
                lbl.Text = "Selecione a coluna de saída para associação";
                lbl.AutoSize = true;
                lbl.Left = 860;
                lbl.Top = 140;
                lbl.Name = "lbl" + tabPage.Text + "_saida";

                //tabPlanilha.SelectedTab.Controls.RemoveByKey(lbl.Name);

                tabPage.Controls.Add(lbl);

                lbl = new Label();
                lbl.Text = "Colunas associadas";
                lbl.AutoSize = true;
                lbl.Left = 860;
                lbl.Top = 210;
                lbl.Name = "lbl" + tabPage.Text + "_associada";

                //tabPlanilha.SelectedTab.Controls.RemoveByKey(lbl.Name);

                tabPage.Controls.Add(lbl);

                ListBox lst = new ListBox();
                lst.Top = 225;
                lst.Name = "lst" + tabPage.Text;
                lst.Left = 860;
                lst.Width = 230;
                lst.Height = 180;

                foreach (string opcao in cboSaida.Items)
                {
                    if (cbo.Items.IndexOf(opcao) != -1)
                    {
                        lst.Items.Add(opcao + "|" + opcao);
                    }
                }
                tabPage.Controls.Add(lst);
                btnAddItem.Visible = true;
                btnRemItem.Visible = true;
                btnReplicar.Visible = true;
                grid.SelectionMode = DataGridViewSelectionMode.CellSelect;

                PictureBox pct = tabPage.Controls.Find("pctCabecalho" + tabPage.Name, true)[0] as PictureBox;
                pct.Image = Properties.Resources.check;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                string nome_entrada = "cbo" + tabPlanilha.SelectedTab.Text;
                string nome_saida = "cbo" + tabPlanilha.SelectedTab.Text + "_saida";
                string nome_associacao = "lst" + tabPlanilha.SelectedTab.Text;

                ComboBox cboEntrada = (ComboBox)this.Controls.Find(nome_entrada, true)[0];
                ComboBox cboSaida = (ComboBox)this.Controls.Find(nome_saida, true)[0];
                ListBox lstAssociacao = (ListBox)this.Controls.Find(nome_associacao, true)[0];

                if ((cboEntrada.SelectedIndex == -1 || cboEntrada.Text == string.Empty) && cboSaida.SelectedIndex != -1)
                {
                    if (MessageBox.Show(string.Format("Campo {0} não associado. Deseja inserir um valor fixo para este campo?", cboSaida.Text),
                        "Sistema Integrado de Digitação Telecred", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    {
                        return;
                    }
                    string retorno = "";
                    if (Funcoes.InputBox("Associação com Valor Fixo", "Digite o valor a ser associado:", ref retorno) == DialogResult.OK)
                    {
                        lstAssociacao.Items.Add(string.Format("{0}_*FIXO*_|{1}", retorno, cboSaida.Text));
                        cboSaida.SelectedIndex = -1;
                    }
                    else
                    {
                        return;
                    }
                }

                if (cboEntrada.SelectedIndex == -1 || cboSaida.SelectedIndex == -1)
                    return;


                if (lstAssociacao.Items.IndexOf(cboEntrada.Text + "|" + cboSaida.Text) == -1)
                    lstAssociacao.Items.Add(cboEntrada.Text + "|" + cboSaida.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemItem_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = "lst" + tabPlanilha.SelectedTab.Text;
                ListBox lstAssociacao = (ListBox)this.Controls.Find(nome, true)[0];
                if (lstAssociacao.SelectedIndex == -1)
                    return;

                lstAssociacao.Items.RemoveAt(lstAssociacao.SelectedIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool VerificarLoteCabecalho(TabPage tabPage)
        {
            bool blnLote = tabPage.Tag != null;
            bool blnCabecalho = false;

            DataGridView grd = tabPage.Controls.Find("grd" + tabPage.Name, true)[0] as DataGridView;
            blnCabecalho = grd.Columns[0].HeaderText != "Coluna1";

            return blnLote && blnCabecalho;
        }

        private void tabPlanilha_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                bool blnVerificacao = VerificarLoteCabecalho(tabPlanilha.SelectedTab);

                if (blnVerificacao)
                {
                    btnAddItem.Visible = true;
                    btnRemItem.Visible = true;
                    btnReplicar.Visible = true;
                }
                else
                {
                    btnAddItem.Visible = false;
                    btnRemItem.Visible = false;
                    btnReplicar.Visible = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProcessar_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErro = false;
                string strMensagem = string.Empty;
                ListBox lst = new ListBox();
                ComboBox cbo = new ComboBox();
                foreach (TabPage tabPage in tabPlanilha.TabPages)
                {
                    if (tabPage.Tag == null)
                    {
                        strMensagem += string.Format("É necessário definir o Lote da planilha {0}!!!\n", tabPage.Name);
                        blnErro = true;
                        //break;
                    }
                    else
                    {
                        bool achei = false;
                        foreach (Control control in tabPage.Controls)
                        {
                            if (control.GetType() == typeof(ListBox))
                            {
                                achei = true;
                                lst = control as ListBox;
                                cbo = tabPage.Controls.Find("cbo" + tabPage.Name + "_saida", true)[0] as ComboBox;

                                if (lst.Items.Count == 0 || cbo.Items.Count != lst.Items.Count)
                                {
                                    strMensagem += string.Format("Existem campos não associados na planilha {0}!!!\n", tabPage.Name);
                                    blnErro = true;
                                    break;
                                }
                            }
                        }
                        if (!achei)
                        {
                            strMensagem += string.Format("É necessário definir o cabeçalho da planilha {0}!!!\n", tabPage.Name);
                            blnErro = true;
                            //break;
                        }
                    }
                }
                if (blnErro)
                {
                    MessageBox.Show(strMensagem, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show(string.Format("Confirma processamento do arquivo {0}?", ofdArquivo.FileName),
                                    "Sistema Integrado de Digitação Telecred", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                {
                    return;
                }

                fbdDavita.Description = "Selecione o local onde os arquivos serão criados";
                fbdDavita.ShowNewFolderButton = false;

                if (fbdDavita.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                this.Cursor = Cursors.WaitCursor;

                ArquivoDavita arquivo = new ArquivoDavita();
                arquivo.NomeArquivo = ofdArquivo.FileName;
                arquivo.DataProcessamento = DateTime.Now;
                arquivo.CaminhoSaida = fbdDavita.SelectedPath;
                arquivo.Status = "Importado";

                pgbPlanilhas.Visible = true;
                pgbPlanilhas.Value = 0;
                pgbPlanilhas.Maximum = tabPlanilha.TabPages.Count;

                pgbImportacao.Visible = true;
                lblPlanilhas.Visible = true;
                lblRegistros.Visible = true;
                Application.DoEvents();

                foreach (TabPage tabPage in tabPlanilha.TabPages)
                {
                    pgbPlanilhas.Value++;
                    lblPlanilhas.Text = string.Format("{0}/{1}", pgbPlanilhas.Value, tabPlanilha.TabPages.Count);
                    Application.DoEvents();
                    PegDavita peg = new PegDavita();
                    peg.Lote = Convert.ToInt32(tabPage.Tag.ToString());
                    peg.NumeroPeg = Convert.ToInt32(tabPage.Name.Substring(0,7));

                    DataGridView grid = tabPage.Controls.Find("grd" + tabPage.Name, true)[0] as DataGridView;

                    pgbImportacao.Value = 0;
                    pgbImportacao.Maximum = grid.Rows.Count;

                    foreach (DataGridViewRow linha in grid.Rows)
                    {
                        pgbImportacao.Value++;
                        lblRegistros.Text = string.Format("{0}/{1}", pgbImportacao.Value, grid.Rows.Count);

                        Application.DoEvents();
                        RegistroDavita registro = new RegistroDavita();
                        foreach (string item in lst.Items)
                        {
                            string[] campos = item.Split('|');

                            for (int contador = 0; contador < linha.Cells.Count; contador++)
                            {

                                if (grid.Columns[contador].HeaderText == campos[0] || campos[0].IndexOf("_*FIXO*_") != -1)
                                {
                                    int posicao = cbo.Items.IndexOf(campos[1]);
                                    //if (posicao == 0)
                                    //{
                                    //    if (campos[1].IndexOf("_*FIXO*_") != -1)
                                    //    {
                                    //        registro.Atendimento = Convert.ToInt32(campos[1].Substring(0, campos[1].IndexOf("_*FIXO*_")));
                                    //    }
                                    //    else
                                    //    {
                                    //        registro.Atendimento = Convert.ToInt32(Convert.ToDouble(linha.Cells[contador].Value));
                                    //    }
                                    //    break;
                                    //}
                                    //else if (posicao == 1)
                                    //{
                                    //    if (campos[1].IndexOf("_*FIXO*_") != -1)
                                    //    {
                                    //        registro.Paciente = campos[1].Substring(0, campos[1].IndexOf("_*FIXO*_"));
                                    //    }
                                    //    else
                                    //    {
                                    //        registro.Paciente = linha.Cells[contador].Value.ToString();
                                    //    }
                                    //    break;
                                    //}
                                    if (posicao == 0)
                                    {
                                        if (campos[0].IndexOf("_*FIXO*_") != -1)
                                        {
                                            registro.DataHora = Convert.ToDateTime(campos[0].Substring(0, campos[0].IndexOf("_*FIXO*_")));
                                        }
                                        else
                                        {
                                            //registro.DataHora = Convert.ToDateTime("1/1/1900").AddDays(Convert.ToDouble(linha.Cells[contador].Value)-2);
                                            registro.DataHora = DateTime.FromOADate(Convert.ToDouble(linha.Cells[contador].Value));
                                        }
                                        break;
                                    }
                                    else if (posicao == 1)
                                    {
                                        if (campos[1].IndexOf("_*FIXO*_") != -1)
                                        {
                                            registro.MatMed = Convert.ToInt32(campos[0].Substring(0, campos[0].IndexOf("_*FIXO*_")));
                                        }
                                        else
                                        {
                                            registro.MatMed = Convert.ToInt32(Convert.ToDouble(linha.Cells[contador].Value));
                                        }
                                        break;
                                    }
                                    else if (posicao == 2)
                                    {
                                        if (campos[0].IndexOf("_*FIXO*_") != -1)
                                        {
                                            registro.Carteirinha = campos[0].Substring(0, campos[0].IndexOf("_*FIXO*_"));
                                        }
                                        else
                                        {
                                            registro.Carteirinha = (linha.Cells[contador].Value.ToString()).Replace(",", "").Replace(".", "");
                                        }
                                        break;
                                    }
                                    else if (posicao == 3)
                                    {
                                        if (campos[0].IndexOf("_*FIXO*_") != -1)
                                        {
                                            registro.Valor = Convert.ToDecimal(campos[0].Substring(0, campos[0].IndexOf("_*FIXO*_")));
                                        }
                                        else
                                        {
                                            registro.Valor = Convert.ToDecimal(linha.Cells[contador].Value);
                                        }
                                        peg.ValorTotal += registro.Valor;
                                        break;
                                    }
                                    else if (posicao == 4)
                                    {
                                        if (campos[0].IndexOf("_*FIXO*_") != -1)
                                        {
                                            registro.Quantidade = Convert.ToInt32(campos[0].Substring(0, campos[0].IndexOf("_*FIXO*_")));
                                        }
                                        else
                                        {
                                            registro.Quantidade = Convert.ToInt32(Convert.ToDouble(linha.Cells[contador].Value));
                                        }
                                        break;
                                    }
                                    else if (posicao == 5)
                                    {
                                        if (campos[0].IndexOf("_*FIXO*_") != -1)
                                        {
                                            registro.Senha = Convert.ToInt32(campos[0].Substring(0, campos[0].IndexOf("_*FIXO*_")));
                                        }
                                        else
                                        {
                                            registro.Senha = Convert.ToInt32(Convert.ToDouble(linha.Cells[contador].Value));
                                        }
                                        break;
                                    }
                                    //else if (posicao == 8)
                                    //{
                                    //    if (campos[1].IndexOf("_*FIXO*_") != -1)
                                    //    {
                                    //        registro.CRM = campos[1].Substring(0, campos[1].IndexOf("_*FIXO*_"));
                                    //    }
                                    //    else
                                    //    {
                                    //        registro.CRM = Convert.ToDouble(linha.Cells[contador].Value.ToString()).ToString();
                                    //    }
                                    //    break;
                                    //}
                                    //else if (posicao == 9)
                                    //{
                                    //    if (campos[1].IndexOf("_*FIXO*_") != -1)
                                    //    {
                                    //        registro.Medico = campos[1].Substring(0, campos[1].IndexOf("_*FIXO*_"));
                                    //    }
                                    //    else
                                    //    {
                                    //        registro.Medico = linha.Cells[contador].Value.ToString();
                                    //    }
                                    //    break;
                                    //}
                                    else if (posicao == 6)
                                    {
                                        if (campos[0].IndexOf("_*FIXO*_") != -1)
                                        {
                                            registro.CBOS = campos[0].Substring(0, campos[0].IndexOf("_*FIXO*_"));
                                        }
                                        else
                                        {
                                            registro.CBOS = linha.Cells[contador].Value.ToString();
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                        peg.registros.Add(registro);
                    }


                    arquivo.pegs.Add(peg);
                }
                lblAndamento.Text = "Armazenando dados e gerando os arquivos...";
                arquivo.Processar();



                this.Cursor = Cursors.Default;




                MessageBox.Show("Arquivo processado com sucesso!!!", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                //btnCarregarPlanilha.Enabled = true;
                //btnDefinirCabecalho.Enabled = false;
                //btnLote.Enabled = false;
                //btnRemoverAba.Enabled = false;
                //btnProcessar.Enabled = false;
                //this.Controls.RemoveByKey("tabPlanilha");
                //this.Width = 1146;
                //this.Height = 133;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReplicar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabPlanilha.TabPages.Count == 1)
                {
                    return;
                }
                List<string> associacoes = new List<string>();
                List<string> original = new List<string>();
                ListBox lst = tabPlanilha.SelectedTab.Controls.Find("lst" + tabPlanilha.SelectedTab.Text, true)[0] as ListBox;
                if (lst.Items.Count == 0)
                {
                    return;
                }

                foreach (string item in lst.Items)
                    associacoes.Add(item);


                if (MessageBox.Show("Replicar a mesma associação para as outras planilhas?", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }
                string nomeAba = tabPlanilha.SelectedTab.Name;

                bool blnErro = false;

                foreach (TabPage tabPage in tabPlanilha.TabPages)
                {
                    if (tabPage.Name != nomeAba)
                    {
                        if (!VerificarLoteCabecalho(tabPage))
                        {
                            blnErro = true;
                            break;
                        }
                        ComboBox combo = tabPage.Controls.Find("cbo" + tabPage.Name, true)[0] as ComboBox;
                        lst = tabPage.Controls.Find("lst" + tabPage.Name, true)[0] as ListBox;

                        original.Clear();

                        foreach (string item in lst.Items)
                            original.Add(item);

                        lst.Items.Clear();
                        foreach (string item in associacoes)
                        {
                            lst.Items.Add(item);
                            string campo = item.Split('|')[0];
                            if (combo.Items.IndexOf(campo) == -1 && campo.IndexOf("_*FIXO*_") == -1)
                            {
                                blnErro = true;
                                lst.Items.Clear();
                                foreach (string opcao in original)
                                    lst.Items.Add(opcao);
                                break;
                            }
                        }
                        if (blnErro)
                            break;
                    }
                }
                if (blnErro)
                {
                    MessageBox.Show("Não foi possível replicar as associações para todas as planilhas.\nVerificar manualmente.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Associações replicadas com sucesso!!!", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLote_Click(object sender, EventArgs e)
        {
            int linha = 0;
            int coluna = 0;
            try
            {
                if (tabPlanilha.SelectedTab.Tag != null)
                {
                    if (MessageBox.Show(string.Format("Esta aba já possui Unidade {0} associada!! Deseja substituir esta unidade?", tabPlanilha.SelectedTab.Tag.ToString()), "Sistema Integrado de Digitação Telecred", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        return;
                }

                DataGridView grd = tabPlanilha.SelectedTab.Controls.Find("grd" + tabPlanilha.SelectedTab.Name, true)[0] as DataGridView;

                if (double.TryParse(grd.SelectedCells[0].Value.ToString(), out double aux))
                {
                    linha = grd.SelectedCells[0].RowIndex;
                    coluna = grd.SelectedCells[0].ColumnIndex;
                    if (chkLote.Checked)
                    {
                        foreach (TabPage tabPage in tabPlanilha.TabPages)
                        {
                            string nome = Convert.ToDouble(grd.Rows[linha].Cells[coluna].Value).ToString();
                            tabPage.Tag = nome;
                            PictureBox pct = tabPage.Controls.Find("pctLote" + tabPage.Name, true)[0] as PictureBox;
                            pct.Image = Properties.Resources.check;
                        }
                        MessageBox.Show("Unidades definidas com sucesso!!!", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string nome = Convert.ToDouble(grd.SelectedCells[0].Value).ToString();

                        if (MessageBox.Show(string.Format("Definir a unidade como {0}?", nome), "Sistema Integrado de Digitação Telecred", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        {
                            return;
                        }

                        tabPlanilha.SelectedTab.Tag = nome;
                        MessageBox.Show("Unidade definida com sucesso!!!", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        PictureBox pct = tabPlanilha.SelectedTab.Controls.Find("pctLote" + tabPlanilha.SelectedTab.Name, true)[0] as PictureBox;
                        pct.Image = Properties.Resources.check;
                    }


                    //grd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
                else
                {
                    MessageBox.Show(string.Format("O valor informado {0}, não é um número de unidade válido.", grd.SelectedCells[0].Value.ToString()), "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmDavitaImportacao_Load(object sender, EventArgs e)
        {
            this.Width = 1146;
            this.Height = 143;
        }

        private void btnRemoverAba_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabPlanilha.TabPages.Count == 1)
                {
                    MessageBox.Show("Não é possível remover outra aba.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show(string.Format("Confirma exclusão da Aba {0}?", tabPlanilha.SelectedTab.Name), "Sistema Integrado de Digitação Telecred", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }

                tabPlanilha.TabPages.Remove(tabPlanilha.SelectedTab);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
