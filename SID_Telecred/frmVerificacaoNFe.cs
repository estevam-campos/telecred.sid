using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SID_Telecred
{
    public partial class frmVerificacaoNFe : Form
    {
        public frmVerificacaoNFe()
        {
            InitializeComponent();
        }
        string strArquivo = string.Empty;
        List<string> nfes;
        int Contador = 0;
        bool blnLoad = false;
        Nfe nfe;
        int Tentativas = 0;
        DateTime HoraInicio;


        private void BtnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnImportar_Click(object sender, EventArgs e)
        {
            if (txtArquivo.Text == string.Empty)
                return;

            if (MessageBox.Show("Iniciar verificação?", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
            {
                MessageBox.Show("Verificação cancelada pelo usuário", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                HoraInicio = DateTime.Now;
                Contador = 0;
                nfes = System.IO.File.ReadAllLines(ofdArquivo.FileName).ToList();
                pgbImportacao.Maximum = nfes.Count;
                lblQtde.Text = "";// string.Format("0 / {0}", nfes.Count);
                webNotaFiscal.Navigate(Funcoes.strNFeUrl);
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAbrirArquivo_Click(object sender, EventArgs e)
        {
            DialogResult result = ofdArquivo.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                MessageBox.Show("Verificação cancelada pelo usuário", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            strArquivo = ofdArquivo.FileName;
            txtArquivo.Text = Path.GetFileName(ofdArquivo.FileName);
        }
        private void LimparCampos()
        {
            txtArquivo.Text = string.Empty;
            lblAndamento.Text = string.Empty;
            pgbImportacao.Value = 0;
            lblQtde.Text = "";// "0 / 0";
            pctNfe.Image = Properties.Resources.document_delete;//NFSe_layout_novo;
            grpNfe.Text = string.Empty;
        }
        private void WebNotaFiscal_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                if (!blnLoad)
                {
                    do
                    {
                        if (Contador >= nfes.Count)
                        {
                            MessageBox.Show("Verificação finalizada com sucesso", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparCampos();
                            return;
                        }
                        nfe = new Nfe();
                        Application.DoEvents();
                        this.Text = string.Format("Verificação NFe - {0}", Contador + 1);
                        pgbImportacao.Value = Contador + 1;
                        lblQtde.Text = ((double)pgbImportacao.Value / (double)nfes.Count).ToString("##0.00%"); // string.Format("{0} / {1}", pgbImportacao.Value, nfes.Count);
                        Application.DoEvents();

                        HtmlElement cpfcnpj = webNotaFiscal.Document.All["ctl00_body_tbCPFCNPJ"];
                        HtmlElement numeronota = webNotaFiscal.Document.All["ctl00_body_tbNota"];
                        HtmlElement codigoverificacao = webNotaFiscal.Document.All["ctl00_body_tbVerificacao"];

                        string NFe = nfes[Contador];

                        string[] campos = NFe.Split(';');

                        nfe.Peg = Convert.ToInt32(campos[0]);
                        nfe.Numero = Convert.ToInt32(campos[1]);
                        nfe.DataEmissao = Convert.ToDateTime(campos[2]);
                        nfe.CodigoVerificacao = campos[3];
                        nfe.CPF_CNPJ = campos[4];
                        nfe.DataInclusao = DateTime.Now;
                        nfe.DataVerificacao = DateTime.Now;

                        nfe.Consultar();
                        if (nfe.Codigo != 0)
                        {
                            Contador++;
                            Application.DoEvents();
                            blnLoad = false;
                            //webNotaFiscal.Navigate(Funcoes.strNFeUrl);
                        }
                        else
                        {
                            TimeSpan ts = DateTime.Now.Subtract(HoraInicio);
                            double tempo = (ts.TotalSeconds / pgbImportacao.Value);
                            TimeSpan estimado = TimeSpan.FromSeconds(tempo * (pgbImportacao.Maximum - pgbImportacao.Value));

                            lblAndamento.Text = string.Format("NFEs Verificadas: {0} | Duração: {1}:{2}:{3} | Tempo Estimado: {4}d {5}:{6}:{7}",
                                pgbImportacao.Value, ts.Hours.ToString("00"), ts.Minutes.ToString("00"), ts.Seconds.ToString("00"),
                                estimado.Days, estimado.Hours.ToString("00"), estimado.Minutes.ToString("00"), estimado.Seconds.ToString("00"));
                            grpNfe.Text = string.Format("CNPJ: {0} | Número NFe: {1} | Código de Verificação: {2}", nfe.CPF_CNPJ, nfe.Numero, nfe.CodigoVerificacao);
                            Application.DoEvents();

                            cpfcnpj.InnerText = nfe.CPF_CNPJ;
                            numeronota.InnerText = nfe.Numero.ToString();
                            codigoverificacao.InnerText = nfe.CodigoVerificacao;
                            blnLoad = true;
                            HtmlElement form = webNotaFiscal.Document.GetElementById("aspnetForm");
                            if (form != null)
                            {
                                form.InvokeMember("submit");
                                break;
                            }
                        }
                    } while (Contador < nfes.Count());
                }
                else
                {
                    if ((webNotaFiscal.Document.Body.InnerText.IndexOf("Número da NFS-e e Código de Verificação não conferem") == -1) &&
                        (webNotaFiscal.Document.Body.InnerText.IndexOf("Contribuinte não encontrado") == -1) &&
                        (webNotaFiscal.Document.Body.InnerText.IndexOf("CPF/CNPJ Inválido") == -1))
                    {
                        HtmlDocument htmlDocument = this.webNotaFiscal.Document;
                        HtmlElement htmlElement = htmlDocument.Images["ctl00_cphBase_img"];
                        string imgUrl = htmlElement.GetAttribute("src");

                        if (imgUrl.IndexOf("cancelada") != -1)
                        {
                            nfe.Cancelada = true;
                        }
                        nfe.Existente = true;
                        nfe.URL = imgUrl;
                        //if (chkVisualizar.Checked)
                        pctNfe.ImageLocation = imgUrl;
                        try
                        {
                            nfe.Gravar();
                        }
                        catch
                        {

                        }
                        Contador++;
                        Application.DoEvents();
                        blnLoad = false;
                        webNotaFiscal.Navigate(Funcoes.strNFeUrl);
                    }
                    else
                    {
                        if (webNotaFiscal.Document.Body.InnerHtml.IndexOf("display: inline;\">CPF/CNPJ Inválido") != -1)
                            nfe.Erro = "CPF/CNPJ Inválido";
                        else if (webNotaFiscal.Document.Body.InnerHtml.IndexOf("display: inline;\">Número da NFS-e não preenchido") != -1)
                            nfe.Erro = "Número da NFS-e não preenchido";
                        else if (webNotaFiscal.Document.Body.InnerHtml.IndexOf("display:inline;\">Digite apenas números") != -1)
                            nfe.Erro = "Número da NFS-e Inválido";
                        else if (webNotaFiscal.Document.Body.InnerHtml.IndexOf("display: inline;\">Código de Verificação não preenchido") != -1)
                            nfe.Erro = "Código de Verificação não preenchido";
                        else if (webNotaFiscal.Document.Body.InnerText.IndexOf("Contribuinte não encontrado") != -1)
                            nfe.Erro = "Contribuinte não encontrado";
                        else if (webNotaFiscal.Document.Body.InnerText.IndexOf("Número da NFS-e e Código de Verificação não conferem") != -1)
                            nfe.Erro = "Número da NFS-e e Código de Verificação não conferem";
                        else
                            nfe.Erro = webNotaFiscal.Document.Body.InnerHtml;

                        //MessageBox.Show("NF Não verificada");
                        pctNfe.Image = Properties.Resources.document_delete;
                        nfe.Existente = false;
                        nfe.Gravar();
                        blnLoad = false;
                        webNotaFiscal.Navigate(Funcoes.strNFeUrl);
                    }
                }
            }
            catch (Exception ex)
            {
                //if (Tentativas > 5)
                //{
                //MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nfe.Erro = ex.Message;
                try
                {
                    nfe.Gravar();
                }
                catch
                {

                }
                Contador++;
                Application.DoEvents();
                blnLoad = false;
                Tentativas = 0;
                webNotaFiscal.Navigate(Funcoes.strNFeUrl);
                //}
                //else
                //{
                //    blnLoad = false;
                //    Tentativas++;
                //    webNotaFiscal.Navigate(Funcoes.strNFeUrl);
                //}
            }
        }

        private void BtnLimparCampos_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }
    }
}
