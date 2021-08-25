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

namespace SID_Telecred
{
    public partial class frmImportarDigitalizados : Form
    {
        public frmImportarDigitalizados()
        {
            InitializeComponent();
        }
        bool blnLoad;
        Caixa oCaixa = new Caixa();
        Lote oLote = new Lote();
        Imagem oImagem = new Imagem();

        private void btnLiberarLote_Click(object sender, EventArgs e)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                if (MessageBox.Show("Confirma liberação do lote " + cboLote.Text + "?",
                        "Sistema Integrado de Digitação Telecred",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (lstCaixa.Items.Count > 0 || lstImagens.Items.Count > 0)
                    {
                        if (MessageBox.Show("Existem imagens não vinculadas, efetuar a liberação do lote " + cboLote.Text + " e excluir os índices não relacionados?",
                        "Sistema Integrado de Digitação Telecred",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        {
                            return;
                        }
                        else
                        {
                            foreach (string strNomeArquivo in lstCaixa.Items)
                            {
                                Imagem imagem = new Imagem();
                                imagem.strNomeArquivo = strNomeArquivo;
                                imagem.intCodigoLote = oLote.intCodigo;
                                imagem.ExcluirImagens();
                                foreach (Imagem img in oLote.Imagens)
                                {
                                    if (img.strNomeArquivo == strNomeArquivo)
                                    {
                                        oLote.Imagens.Remove(img);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    Cursor.Current = Cursors.WaitCursor;

                    foreach (Imagem imagem in oLote.Imagens)
                    {
                        imagem.intStatus = (int)Funcoes.StatusImagem.AguardandoDigitacao;
                        Funcoes.GravarDigitacao(oLote.intCodigoServico, false);
                    }
                    oLote.intStatusLote = (int)Funcoes.StatusLote.AguardandoDigitacao;
                    oLote.AlterarStatus();
                    oLote.GravarImagens();
                    //oLote.ExcluirImagens();
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Liberação do lote " + cboLote.Text + ", efetuada com sucesso", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimparCampos()
        {
            lblDocumentos.Text = "-";
            grpCaixa.Text = "Documentos";
            lstCaixa.Items.Clear();
            cboCaixas.SelectedIndex = -1;
            btnLiberarLote.Enabled = false;
            oCaixa.intCodigo = 0;
            oCaixa.intQtdeImagens = 0;
            pctDocumento.Visible = false;
            pctImagens.Visible = false;
            blnLoad = false;
            CarregarCaixas();
            blnLoad = true;
        }
        private void frmImportarDigitalizados_Load(object sender, EventArgs e)
        {
            blnLoad = false;
            PreencherServico();
            blnLoad = true;
        }
        private void PreencherServico()
        {
            cboServico.DataSource = Funcoes.CarregarServico();
            cboServico.DisplayMember = "SER_DESCRICAO";
            cboServico.ValueMember = "SER_CODIGO";
            cboServico.SelectedIndex = -1;
        }
        private void CarregarCaixas()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                blnLoad = false;
                cboCaixas.DataSource = null;
                cboCaixas.DataSource = Funcoes.CarregarCaixas(Convert.ToInt32(cboServico.SelectedValue), Funcoes.StatusLote.AguardandoDigitalizacao);
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
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                if (blnLoad)
                {
                    blnLoad = false;
                    oLote.intCodigo = 0;
                    oLote.intCodigoCaixa = Convert.ToInt32(cboCaixas.SelectedValue);
                    cboLote.DataSource = null;
                    cboLote.DataSource = oLote.ConsultarLote(false);
                    cboLote.DisplayMember = "Lote";
                    cboLote.ValueMember = "LOT_CODIGO";
                    cboLote.SelectedIndex = -1;
                    blnLoad = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void VincularImagens()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                if (lstCaixa.Items.Count == 0)
                {
                    return;
                }
                pgbProcesso.Visible = true;
                pgbProcesso.Maximum = lstCaixa.Items.Count;
                lblDocumentos.Text = "-";
                lblImagens.Text = "-";
                pgbProcesso.Value = 0;
                int intTotal = lstCaixa.Items.Count;
                int intContador = 0;
                do
                {
                    Application.DoEvents();
                    pgbProcesso.Value++;
                    Application.DoEvents();
                    string strImagem = Funcoes.strCaminhoImagens + @"Imagens\" + cboCaixas.Text + "_" + cboLote.Text + @"_\" + lstCaixa.Items[intContador].ToString() + ".pdf";
                    //MessageBox.Show(strImagem);
                    if (File.Exists(strImagem))
                    {
                        FileStream fsImagem = new FileStream(strImagem, FileMode.Open, FileAccess.Read);
                        byte[] picbyte = new byte[fsImagem.Length];
                        fsImagem.Read(picbyte, 0, System.Convert.ToInt32(fsImagem.Length));
                        fsImagem.Close();

                        oImagem.strNomeArquivo = lstCaixa.Items[intContador].ToString();
                        oImagem.bytImagem = picbyte;
                        oImagem.intStatus = (int)Funcoes.StatusImagem.AguardandoDigitacao;
                        oImagem.GravarImagem();

                        foreach (Imagem imagem in oLote.Imagens)
                        {
                            if (imagem.strNomeArquivo == oImagem.strNomeArquivo)
                            {
                                imagem.bytImagem = oImagem.bytImagem;
                                break;
                            }
                        }

                        lstCaixa.Items.RemoveAt(intContador);
                        foreach (string imagem in lstImagens.Items)
                        {
                            if (imagem == oImagem.strNomeArquivo)
                            {
                                lstImagens.Items.Remove(imagem);
                                break;
                            }
                        }


                        intTotal--;
                    }
                    else
                    {
                        intContador++;
                        lblDocumentos.Text = intContador.ToString();
                    }
                } while (intContador < intTotal);

                pgbProcesso.Visible = false;

                if (lstCaixa.Items.Count > 0)
                {
                    pctDocumento.Image = Properties.Resources.delete;
                    pctDocumento.Visible = true;
                    //btnLiberarLote.Enabled = false;
                }
                else
                {
                    pctDocumento.Image = Properties.Resources.check;
                    pctDocumento.Visible = true;
                    //btnLiberarLote.Enabled = true;
                }
                lblImagens.Text = lstImagens.Items.Count > 0 ? lstImagens.Items.Count.ToString() : "-";
                if (lstImagens.Items.Count > 0)
                {
                    pctImagens.Image = Properties.Resources.delete;
                    pctImagens.Visible = true;
                    //btnLiberarLote.Enabled = false;
                }
                else
                {
                    pctImagens.Image = Properties.Resources.check;
                    pctImagens.Visible = true;
                    //btnLiberarLote.Enabled = true;
                }
                btnLiberarLote.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //int intDocumentos = 0;
            //int intImagens = 0;

            //if (lstCaixa.Items.Count > 0 && lstArquivo.Items.Count > 0)
            //{
            //    do
            //    {
            //        string strItem = lstCaixa.Items[intDocumentos].ToString();
            //        int intPosicao = lstArquivo.Items.IndexOf(strItem);
            //        if (intPosicao == -1)
            //        {
            //            intDocumentos++;
            //        }
            //        else
            //        {
            //            lstCaixa.Items.RemoveAt(intDocumentos);
            //            lstArquivo.Items.RemoveAt(intPosicao);
            //        }
            //        if (lstCaixa.Items.Count == 0 || intDocumentos == lstCaixa.Items.Count)
            //        {
            //            break;
            //        }
            //    }
            //    while (true);

            //    foreach (string imagem in lstArquivo.Items)
            //    {
            //        if (lstCaixa.Items.IndexOf(imagem) == -1)
            //        {
            //            intImagens++;
            //        }
            //    }
            //    lblDocumentos.Text = intDocumentos.ToString("0000");
            //    lblImagens.Text = intImagens.ToString("0000");

            //    pctArquivo.Visible = true;
            //    pctDocumento.Visible = true;

            //    pctArquivo.Image = intImagens == 0 ? Properties.Resources.check : Properties.Resources.delete;
            //    pctDocumento.Image = intDocumentos == 0 ? Properties.Resources.check : Properties.Resources.delete;

            //    if (intDocumentos == 0)// && intImagens == 0)
            //    {
            //        btnLiberarLote.Enabled = true;
            //    }
            //    else
            //    {
            //        btnLiberarLote.Enabled = false;
            //    }
            //}
        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cboLote_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                if (blnLoad)
                {
                    string strPasta = Funcoes.strCaminhoImagens + @"Imagens\" + cboCaixas.Text + "_" + cboLote.Text + @"_\";
                    btnLiberarLote.Enabled = false;
                    pctDocumento.Visible = false;
                    oCaixa.intCodigo = Convert.ToInt32(cboCaixas.SelectedValue);
                    oCaixa.intCodigoServico = Convert.ToInt32(cboServico.SelectedValue);
                    oCaixa.ConsultarCaixa();
                    //if (oCaixa.intStatusCaixa == (int)Funcoes.StatusCaixa.Aberta ||
                    //    oCaixa.intStatusCaixa == (int)Funcoes.StatusCaixa.EmDigitacao ||
                    //    oCaixa.intStatusCaixa == (int)Funcoes.StatusCaixa.EmDigitalizacao)
                    //{
                    //    MessageBox.Show("Não é possível carregar o lote, caixa bloqueada por outro usuário", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return;
                    //}
                    oLote.intCodigo = Convert.ToInt32(cboLote.SelectedValue);
                    oLote.ConsultarLote(false);
                    if (oLote.intStatusLote == (int)Funcoes.StatusLote.EmDigitalizacao ||
                        oLote.intStatusLote == (int)Funcoes.StatusLote.EmDigitacao)
                    {
                        MessageBox.Show("Não é possível carregar o lote, stauts do lote em Digitalização/Digitação", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //oLote.intStatusLote = (int)Funcoes.StatusLote.EmDigitalizacao;
                    //oLote.GravarLote();
                    oLote.ConsultarImagens(true);
                    lstCaixa.Items.Clear();
                    foreach (Imagem imagem in oLote.Imagens)
                    {
                        lstCaixa.Items.Add(imagem.strNomeArquivo);
                    }
                    string[] strImagens = Directory.GetFiles(strPasta);
                    lstImagens.Items.Clear();
                    foreach (string imagem in strImagens)
                    {
                        if (imagem.IndexOf(".pdf") != -1)
                        {
                            lstImagens.Items.Add(imagem.Replace(strPasta, "").Replace(".pdf", ""));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnComparar_Click(object sender, EventArgs e)
        {
            VincularImagens();
        }

        private void btnLiberarCaixa_Click(object sender, EventArgs e)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oCaixa.intStatusCaixa = (int)Funcoes.StatusCaixa.AguardandoDigitacao;
                oCaixa.GravarCaixa();
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
                oLote.intCodigoServico = Convert.ToInt32(cboServico.SelectedValue);
            }
        }

        private void frmImportarDigitalizados_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (lblDocumentos.Text != "-")
            {
                try
                {
                    //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                    oLote.intStatusLote = (int)Funcoes.StatusLote.AguardandoDigitalizacao;
                    oLote.AlterarStatus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
