using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Transactions;
using System.Reflection;
//using Microsoft.Office.Interop.Excel;

namespace SID_Telecred
{
    public partial class frmImportacaoBases : Form
    {
        public frmImportacaoBases()
        {
            InitializeComponent();
        }

        #region Objetos e variáveis

        bool blnNovo = false;
        bool blnLoad = false;
        bool blnCancelar = false;
        string strNome;
        string strExtensao;
        Layout oLayout = new Layout();
        Registro oRegistro = new Registro();
        //private Microsoft.Office.Interop.Excel.Application ExcelObj = new Microsoft.Office.Interop.Excel.Application();

        #endregion

        #region Eventos
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //ofdArquivo.Filter = "Arquivos Excel|*.xls*|Arquivos CSV|*.csv|Arquivos txt|*.txt";
            ofdArquivo.Filter = "Arquivos CSV|*.csv";
            if (ofdArquivo.ShowDialog() == DialogResult.OK)
            {
                txtDocumento.Text = ofdArquivo.FileName;
                toolTip1.SetToolTip(txtDocumento, txtDocumento.Text);
                strNome = ofdArquivo.SafeFileName;
                strExtensao = strNome.Substring(strNome.LastIndexOf('.') + 1).ToLower();
            }
        }
        private void btnAddCampo_Click(object sender, EventArgs e)
        {
            if (lstCampos.SelectedIndex != -1)
            {
                bool blnCampoExiste = false;
                foreach (string campo in lstImportar.Items)
                {
                    if (campo.IndexOf("(chave)") == -1)
                    {
                        if (campo == lstCampos.Items[lstCampos.SelectedIndex].ToString())
                        {
                            blnCampoExiste = true;
                            break;
                        }
                    }
                    else
                    {
                        if (campo.IndexOf(lstCampos.Items[lstCampos.SelectedIndex].ToString()) != -1)
                        {
                            blnCampoExiste = true;
                            break;
                        }
                    }
                }
                if (!blnCampoExiste)
                {
                    lstImportar.Items.Add(lstCampos.Text);
                }
            }
        }
        private void btnRemCampo_Click(object sender, EventArgs e)
        {
            if (lstImportar.SelectedIndex != -1)
            {
                if (lstImportar.Items[lstImportar.SelectedIndex].ToString().IndexOf("(chave)") != -1)
                {
                    if (MessageBox.Show("Deseja realmente remover o campo " + lstImportar.Items[lstImportar.SelectedIndex].ToString() + "?",
                        "Sistema Integrado de Digitação Telecred",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        lstImportar.Items.RemoveAt(lstImportar.SelectedIndex);
                    }
                }
                else
                {
                    lstImportar.Items.RemoveAt(lstImportar.SelectedIndex);
                }
            }
        }
        private void btnAddTodos_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Adicionar todos os campos para serem importados?", "Sistema Integrado de Digitação Telecred",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) ==
                DialogResult.Yes)
            {
                lstImportar.Items.Clear();
                foreach (string campo in lstCampos.Items)
                {
                    lstImportar.Items.Add(campo);
                }
            }
        }
        private void btnRemTodos_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Remover todos os campos a serem importados?", "Sistema Integrado de Digitação Telecred",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) ==
                DialogResult.Yes)
            {
                lstImportar.Items.Clear();
            }
        }
        private void frmImportacaoBases_Load(object sender, EventArgs e)
        {
            blnLoad = false;
            blnNovo = true;
            CarregarLayouts();
            blnLoad = true;
        }
        private void btnCarregar_Click(object sender, EventArgs e)
        {
            if (txtDocumento.Text != string.Empty)
            {
                CarregarCampos();
            }
        }
        private void btnLimparCampos_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }
        private void btnGravarLayout_Click(object sender, EventArgs e)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                string strMensagemErro = ValidarPreenchimento();
                if (strMensagemErro != string.Empty)
                {
                    MessageBox.Show(strMensagemErro, "Sistema Integrado de Digitação Telecred",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLayout.Focus();
                }
                else
                {
                    PreencherClasse();
                    oLayout.Gravar();
                    MessageBox.Show("Layout gravado com sucesso.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregarLayouts();
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboLayout_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                if (blnLoad)
                {
                    oLayout.intCodigo = Convert.ToInt32(cboLayout.SelectedValue);
                    txtLayout.Text = cboLayout.Text;
                    oLayout.strNome = txtLayout.Text;
                    oLayout.Consultar();
                    PreencherForm();
                    blnNovo = false;
                    btnImportar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnNovoBanco_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }
        private void btnImportar_Click(object sender, EventArgs e)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                if (btnImportar.Text != "Cancelar")
                {

                    if (txtDocumento.Text != string.Empty && MessageBox.Show("Iniciar importação do arquivo " + ofdArquivo.SafeFileName + ", referenciando o layout " + txtLayout.Text + "?",
                        "Sistema Integrado de Digitação Telecred", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        pnlImportacao.Visible = true;
                        pnlImportacao.BringToFront();
                        btnImportar.Text = "Cancelar";
                        blnCancelar = false;
                        btnImportar.Image = Properties.Resources.delete;
                        btnFechar.Enabled = false;
                        HabilitarBotoes(false);

                        oRegistro.intCodigoImportacao = Convert.ToInt32(cboLayout.SelectedValue);
                        oRegistro.strChave = Funcoes.Encrypt(DateTime.Now.ToString(), true);
                        oRegistro.blnDuplicado = chkDuplicado.Checked;

                        if (strExtensao.IndexOf("xls") != -1)
                        {
                            #region Comentário XLS
                            //Cursor.Current = Cursors.WaitCursor;
                            //Workbook theWorkbook = ExcelObj.Workbooks.Open(ofdArquivo.FileName, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true);
                            //Sheets sheets = theWorkbook.Worksheets;
                            //Worksheet worksheet = (Worksheet)sheets.get_Item(1);
                            //string strRange = string.Empty;
                            //int intLinha = 2;
                            //int intCampos = 0;
                            //int[] intCelulas = new int[3];
                            //intCelulas[0] = 97;
                            //intCelulas[1] = 96;
                            //intCelulas[2] = 96;
                            //do
                            //{
                            //    lblRegistros.Text = "Registros Importados: " + intLinha.ToString("00000");
                            //    System.Windows.Forms.Application.DoEvents();
                            //    string strCelula = (char)intCelulas[0] + intLinha.ToString(); ;
                            //    if (intCelulas[1] > 96)
                            //    {
                            //        strCelula = (char)intCelulas[1] + strCelula;
                            //    }
                            //    else if (intCelulas[2] > 96)
                            //    {
                            //        strCelula = (char)intCelulas[2] + (char)intCelulas[1] + strCelula;
                            //    }
                            //    Range range = worksheet.get_Range(strCelula);
                            //    strCelula = Convert.ToString(range.Cells.Value);
                            //    if (strCelula == null)
                            //    {
                            //        if (intCelulas[0] == 97)
                            //        {
                            //            break;
                            //        }
                            //        oRegistro.Campos = oLayout.Campos;
                            //        //oRegistro.Gravar();
                            //        intLinha++;
                            //        intCampos = 0;
                            //        intCelulas[0] = 96;
                            //    }
                            //    else
                            //    {
                            //        intCampos++;
                            //        foreach (CampoLayout campo in oLayout.Campos)
                            //        {
                            //            if (campo.intPosicao == intCampos)
                            //            {
                            //                campo.strConteudo = strCelula;
                            //                break;
                            //            }
                            //        }
                            //    }
                            //    intCelulas[0]++;
                            //    if (intCelulas[0] == 123)
                            //    {
                            //        intCelulas[0] = 97;
                            //        intCelulas[1]++;
                            //        if (intCelulas[1] == 123)
                            //        {
                            //            intCelulas[1] = 97;
                            //            intCelulas[2]++;
                            //        }
                            //    }
                            //}
                            //while (true);

                            ////inserir campos

                            //Cursor.Current = Cursors.Default;
                            #endregion
                        }
                        else if (strExtensao.IndexOf("csv") != -1)
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            string linha;
                            StreamReader file = new StreamReader(txtDocumento.Text, UTF8Encoding.UTF7);
                            int intContador = 0;
                            while ((linha = file.ReadLine()) != null)
                            {
                                lblRegistros.Text = "Registros Importados: " + intContador.ToString("000000");
                                System.Windows.Forms.Application.DoEvents();
                                if (intContador > 0)
                                {
                                    string[] strCampos = linha.Split(';');
                                    lstCampos.Items.Clear();
                                    int intCampos = 0;
                                    foreach (string campo in strCampos)
                                    {
                                        intCampos++;
                                        foreach (CampoLayout oCampo in oLayout.Campos)
                                        {
                                            if (oCampo.intPosicao == intCampos)
                                            {
                                                oCampo.strConteudo = campo.Trim();
                                                break;
                                            }
                                        }
                                    }
                                    oRegistro.Campos = oLayout.Campos;
                                    oRegistro.Gravar();
                                }
                                intContador++;
                                //Zerando o contador de inatividade para não fechar o formulário
                                Funcoes.intInatividade = 0;
                                if (blnCancelar)
                                {
                                    break;
                                }
                            }
                            file.Close();
                            Cursor.Current = Cursors.Default;
                            btnImportar.Text = "Importar Dados";
                            btnImportar.Image = Properties.Resources.TableReplace;
                            if (!blnCancelar)
                            {
                                MessageBox.Show("Registros importados com sucesso",
                                    "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                        if (blnCancelar)
                        {
                            Desfazer();
                            btnFechar.Enabled = true;
                        }
                        LimparCampos();
                    }
                }
                else
                {
                    if (MessageBox.Show("Deseja Cancelar a importação do arquivo " + ofdArquivo.SafeFileName + ", referenciando o layout " + txtLayout.Text + "?",
                    "Sistema Integrado de Digitação Telecred", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        blnCancelar = true;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Desfazer();
            }
        }
        private void lstCampos_DoubleClick(object sender, EventArgs e)
        {
            btnAddCampo.PerformClick();
        }
        private void lstImportar_DoubleClick(object sender, EventArgs e)
        {
            btnRemCampo.PerformClick();
        }
        private void btnChave_Click(object sender, EventArgs e)
        {
            if (lstImportar.SelectedIndex != -1)
            {
                string strCampo = lstImportar.Items[lstImportar.SelectedIndex].ToString();
                lstImportar.Items.RemoveAt(lstImportar.SelectedIndex);
                foreach (string campo in lstImportar.Items)
                {
                    if (campo.IndexOf("(chave)") != -1)
                    {
                        lstImportar.Items.RemoveAt(lstImportar.Items.IndexOf(campo));
                        lstImportar.Items.Add(campo.Substring(0, campo.IndexOf("(chave)")));
                        break;
                    }
                }
                lstImportar.Items.Add(strCampo + "(chave)");
            }
        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Métodos
        private void CarregarCampos()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                if (strExtensao.IndexOf("xls") != -1)
                {
                    //Cursor.Current = Cursors.WaitCursor;
                    //Workbook theWorkbook = ExcelObj.Workbooks.Open(ofdArquivo.FileName, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true);
                    //Sheets sheets = theWorkbook.Worksheets;
                    //Worksheet worksheet = (Worksheet)sheets.get_Item(1);
                    //string strRange = string.Empty;
                    //int intCampos = 0;
                    //int[] intCelulas = new int[3];
                    //intCelulas[0] = 97;
                    //intCelulas[1] = 96;
                    //intCelulas[2] = 96;
                    //do
                    //{
                    //    string strCelula = (char)intCelulas[0] + "1";
                    //    if (intCelulas[1] > 96)
                    //    {
                    //        strCelula = (char)intCelulas[1] + strCelula;
                    //    }
                    //    else if (intCelulas[2] > 96)
                    //    {
                    //        strCelula = (char)intCelulas[2] + (char)intCelulas[1] + strCelula;
                    //    }
                    //    Range range = worksheet.get_Range(strCelula);
                    //    strCelula = Convert.ToString(range.Cells.Value);
                    //    if (strCelula == null)
                    //    {
                    //        break;
                    //    }
                    //    else
                    //    {
                    //        intCampos++;
                    //        lstCampos.Items.Add(intCampos.ToString("000") + "-" + strCelula);
                    //    }
                    //    intCelulas[0]++;
                    //    if (intCelulas[0] == 123)
                    //    {
                    //        intCelulas[0] = 97;
                    //        intCelulas[1]++;
                    //        if (intCelulas[1] == 123)
                    //        {
                    //            intCelulas[1] = 97;
                    //            intCelulas[2]++;
                    //        }
                    //    }
                    //}
                    //while (true);
                    //Cursor.Current = Cursors.Default;

                }
                else if (strExtensao.IndexOf("csv") != -1)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string linha;
                    StreamReader file = new StreamReader(txtDocumento.Text, UTF8Encoding.UTF7);
                    while ((linha = file.ReadLine()) != null)
                    {
                        file.Close();
                        break;
                    }
                    string[] strCampos = linha.Split(';');
                    lstCampos.Items.Clear();
                    int intCampos = 0;
                    foreach (string campo in strCampos)
                    {
                        intCampos++;
                        lstCampos.Items.Add(intCampos.ToString("000") + "-" + campo);
                    }
                    Cursor.Current = Cursors.Default;
                }
                else if (strExtensao.IndexOf("txt") != -1)
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimparCampos()
        {
            txtDocumento.Text = string.Empty;
            txtLayout.Text = string.Empty;
            cboLayout.SelectedIndex = -1;
            lstCampos.Items.Clear();
            lstImportar.Items.Clear();
            oLayout.intCodigo = 0;
            oLayout.strNome = string.Empty;
            oLayout.Campos.Clear();
            blnNovo = true;
            btnCarregar.Enabled = true;
            btnImportar.Enabled = false;
            pnlImportacao.Visible = false;
            txtLayout.Focus();
        }
        private void PreencherClasse()
        {
            oLayout.strNome = txtLayout.Text;
            oLayout.blnDuplicado = chkDuplicado.Checked;
            oLayout.Campos.Clear();
            foreach (string campo in lstCampos.Items)
            {
                CampoLayout oCampo = new CampoLayout();
                oCampo.intPosicao = Convert.ToInt32(campo.Substring(0, 3));
                oCampo.strNome = campo.Substring(4);
                oCampo.blnChave = lstImportar.Items.IndexOf(campo + "(chave)") != -1;
                oCampo.blnImportar = oCampo.blnChave ? true : lstImportar.Items.IndexOf(campo) != -1;
                oLayout.Campos.Add(oCampo);
            }
        }
        private string ValidarPreenchimento()
        {
            string strMsg = string.Empty;
            if (txtLayout.Text == string.Empty)
            {
                strMsg = "Nome do Layout em branco.\n";
            }
            if (lstCampos.Items.Count == 0)
            {
                strMsg += "Nenhum campo carregado.\n";
            }
            if (lstImportar.Items.Count == 0)
            {
                strMsg += "Nenhum campo para importar.\n";
            }
            bool blnChave = false;
            foreach (string campo in lstImportar.Items)
            {
                if (campo.IndexOf("(chave)") != -1)
                {
                    blnChave = true;
                    break;
                }
            }
            if (!blnChave)
            {
                strMsg += "Nenhum campo definido como chave.";
            }
            return strMsg;
        }
        private void CarregarLayouts()
        {
            try
            {
                cboLayout.DataSource = Funcoes.CarregarLayouts();
                cboLayout.DisplayMember = "IMP_NOME_LAYOUT";
                cboLayout.ValueMember = "IMP_CODIGO";
                cboLayout.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PreencherForm()
        {
            lstCampos.Items.Clear();
            lstImportar.Items.Clear();
            btnCarregar.Enabled = false;
            foreach (CampoLayout campo in oLayout.Campos)
            {
                string strCampo = campo.intPosicao.ToString("000") + "-" + campo.strNome;
                lstCampos.Items.Add(strCampo);
                strCampo += campo.blnChave ? "(chave)" : "";
                if (campo.blnImportar)
                {
                    lstImportar.Items.Add(strCampo);
                }
            }
        }
        private void HabilitarBotoes(bool blnHabilitar)
        {
            cboLayout.Enabled = blnHabilitar;
            txtLayout.Enabled = blnHabilitar;
            chkDuplicado.Enabled = blnHabilitar;
            btnAdd.Enabled = blnHabilitar;
            btnAddCampo.Enabled = blnHabilitar;
            btnAddTodos.Enabled = blnHabilitar;
            btnCarregar.Enabled = blnHabilitar;
            btnChave.Enabled = blnHabilitar;
            btnGravarLayout.Enabled = blnHabilitar;
            btnLimparCampos.Enabled = blnHabilitar;
            btnNovoBanco.Enabled = blnHabilitar;
            btnRemCampo.Enabled = blnHabilitar;
            btnRemTodos.Enabled = blnHabilitar;
        }
        private void Desfazer()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                if (MessageBox.Show("Deseja desfazer a importação até o momento?", "Sistema Integrado de Digitação Telecred",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    oRegistro.Desfazer();
                    HabilitarBotoes(true);
                    pnlImportacao.Visible = false;
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Registros excluídos com sucesso.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


    }
}
