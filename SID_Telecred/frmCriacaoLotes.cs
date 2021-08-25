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
    public partial class frmCriacaoLotes : Form
    {
        public frmCriacaoLotes()
        {
            InitializeComponent();
        }

        bool blnLoad;
        bool blnAberta = false;
        bool blnRemover = false;
        Caixa oCaixa = new Caixa();
        Lote oLote = new Lote();
        DataSet dsDocumentos = new DataSet();
        DataSet dsFormalizacao = new DataSet();
        int intTotalCaixa = 0;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string strDocumento = (cboCaixa.Text + "_" + cboLote.Text + "_" + txtDocumento.Text).ToUpper();
            if (txtDocumento.Text != string.Empty && lstDocumentos.Items.IndexOf(strDocumento) == -1)
            {
                lstDocumentos.Items.Add(strDocumento);
                Imagem img = new Imagem();
                img.strArquivoPai = strDocumento;
                AdicionarPai(img);
                txtDocumento.Text = string.Empty;
                //txtDocumento.Focus();
                TotalImagens();
                lstDocumentos.SelectedIndex = lstDocumentos.Items.IndexOf(strDocumento);
                if (!chkDocumentoPai.Checked)
                {
                    txtFilho.Focus();
                }
            }
        }
        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnAdd.PerformClick();
            }
        }
        private void lstDocumentos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                btnRemover.PerformClick();
            }
        }
        private void TotalImagens()
        {
            grpDocumentos.Text = "Documentos Lidos - " + lstDocumentos.Items.Count.ToString();
            txtTotalCaixa.Text = (intTotalCaixa + lstDocumentos.Items.Count).ToString();
        }
        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (lstDocumentos.SelectedIndex != -1)
            {
                blnRemover = true;
                dsDocumentos.Tables.Remove(lstDocumentos.Text);
                dsFormalizacao.Tables.Remove(lstDocumentos.Text);
                lstDocumentos.Items.RemoveAt(lstDocumentos.SelectedIndex);
                TotalImagens();
                if (lstDocumentos.Items.Count > 0)
                {
                    lstDocumentos.SelectedIndex = 0;
                }
                else
                {
                    MarcarTodos(false);
                }
            }
        }
        private void PreencherClasse()
        {
            oLote.intTotal = lstDocumentos.Items.Count;
            oLote.Imagens.Clear();

            foreach (DataTable dt in dsDocumentos.Tables)
            {
                Imagem oImagem = new Imagem();
                oImagem.strNomeArquivo = dt.TableName;
                oImagem.intStatus = (int)Funcoes.StatusImagem.AguardandoDigitalizacao;
                oImagem.blnParent = true;
                oImagem.blnImpresso = Convert.ToBoolean(dsFormalizacao.Tables[oImagem.strNomeArquivo].Rows[0]["IMPRESSO"]);
                oImagem.blnPCMSO = Convert.ToBoolean(dsFormalizacao.Tables[oImagem.strNomeArquivo].Rows[0]["PCMSO"]);
                oImagem.blnApto = Convert.ToBoolean(dsFormalizacao.Tables[oImagem.strNomeArquivo].Rows[0]["APTO"]);
                oImagem.blnAltura = Convert.ToBoolean(dsFormalizacao.Tables[oImagem.strNomeArquivo].Rows[0]["ALTURA"]);
                oImagem.blnCarimbo = Convert.ToBoolean(dsFormalizacao.Tables[oImagem.strNomeArquivo].Rows[0]["CARIMBO"]);
                oImagem.blnContato = Convert.ToBoolean(dsFormalizacao.Tables[oImagem.strNomeArquivo].Rows[0]["CONTATO"]);
                oImagem.blnAssinatura = Convert.ToBoolean(dsFormalizacao.Tables[oImagem.strNomeArquivo].Rows[0]["ASSINATURA"]);
                oImagem.blnDatas = Convert.ToBoolean(dsFormalizacao.Tables[oImagem.strNomeArquivo].Rows[0]["DATAS"]);
                oImagem.blnDigital = Convert.ToBoolean(dsFormalizacao.Tables[oImagem.strNomeArquivo].Rows[0]["DIGITAL"]);
                oLote.Imagens.Add(oImagem);
                foreach (DataRow filho in dt.Rows)
                {
                    Imagem oFilho = new Imagem();
                    oFilho.strArquivoPai = dt.TableName;
                    oFilho.intStatus = (int)Funcoes.StatusImagem.AguardandoDigitalizacao;
                    oFilho.blnParent = false;
                    oFilho.strNomeArquivo = filho["DOCUMENTO_FILHO"].ToString();
                    oLote.Imagens.Add(oFilho);
                }
            }

            //foreach (string imagem in lstDocumentos.Items)
            //{
            //    Imagem oImagem = new Imagem();
            //    oImagem.strNomeArquivo = imagem;
            //    oImagem.intStatus = (int)Funcoes.StatusImagem.AguardandoDigitalizacao;
            //    oImagem.blnParent = true;
            //    oLote.Imagens.Add(oImagem);
            //}
        }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                if (cboCaixa.Text != string.Empty)
                {
                    PreencherClasse();
                    oCaixa.GravarCaixa();
                    MessageBox.Show("Caixa incluída com sucesso", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            cboCaixa.Text = string.Empty;
            cboCaixa.SelectedIndex = -1;
            txtDocumento.Text = string.Empty;
            lstDocumentos.Items.Clear();
            oCaixa.intCodigo = 0;
            oCaixa.strCaixa = string.Empty;
            oCaixa.intQtdeImagens = 0;
            oCaixa.intCodigoUsuario = 0;
            cboServico.Focus();
        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnGravarCaixa_Click(object sender, EventArgs e)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                if (MessageBox.Show("Confirma fechamento da caixa " + cboCaixa.Text + "?", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    oCaixa.intStatusCaixa = (int)Funcoes.StatusCaixa.AguardandoDigitalizacao;
                    oCaixa.GravarCaixa();
                    oCaixa.intCodigo = 0;
                    oCaixa.strCaixa = string.Empty;
                    MessageBox.Show("Caixa fechada com sucesso.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    blnAberta = false;
                    cboServico.Enabled = true;
                    cboCaixa.Enabled = true;
                    btnAbrirCaixa.Enabled = true;
                    //btnRemoverCaixa.Enabled = true;
                    btnGravarCaixa.Enabled = false;
                    cboLote.Enabled = false;
                    btnAbrirLote.Enabled = false;
                    btnRemoverLote.Enabled = false;
                    txtPrefixo.Enabled = false;
                    nudInicio.Enabled = false;
                    nudFim.Enabled = false;
                    cboLote.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAbrirCaixa_Click(object sender, EventArgs e)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                if (cboCaixa.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o número da caixa.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                blnAberta = true;
                oCaixa.strCaixa = cboCaixa.Text.ToUpper();
                oCaixa.intCodigo = Convert.ToInt32(cboCaixa.SelectedValue);
                oCaixa.intStatusCaixa = (int)Funcoes.StatusCaixa.Aberta;

                oLote.intCodigo = 0;
                oLote.intCodigoCaixa = oCaixa.intCodigo;
                if (oLote.ContarImagensCaixa(false) >= Funcoes.intDocumentosCaixa)
                {
                    if (MessageBox.Show("Limite de documentos excedido. Deseja continuar inserindo lotes nesta caixa?", "Sistema Integrado de Digitação Telecred",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        return;
                    }
                }

                if (cboCaixa.FindStringExact(cboCaixa.Text) == -1)
                {
                    MessageBox.Show("Caixa não encontrada. Verifique número da caixa digitado.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cboCaixa.Focus();
                    blnAberta = false;
                    return;
                    //oCaixa.GravarCaixa();
                    //PreencherCaixa();
                }
                else
                {
                    oCaixa.GravarCaixa();
                }
                cboCaixa.SelectedIndex = cboCaixa.FindStringExact(oCaixa.strCaixa);
                oCaixa.intCodigo = Convert.ToInt32(cboCaixa.SelectedValue);
                oLote.intCodigoCaixa = oCaixa.intCodigo;
                oLote.intCodigo = 0;
                PreencherLote();
                cboServico.Enabled = false;
                cboCaixa.Enabled = false;
                btnAbrirCaixa.Enabled = false;
                btnGravarCaixa.Enabled = true;
                btnRemoverCaixa.Enabled = false;
                btnAbrirLote.Enabled = true;
                btnRemoverLote.Enabled = true;
                cboLote.Enabled = true;
                btnFecharLote.Enabled = false;
                txtPrefixo.Enabled = false;
                nudInicio.Enabled = false;
                nudFim.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PreencherLote()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                cboLote.DataSource = oLote.ConsultarLote(false);
                cboLote.DisplayMember = "Lote";
                cboLote.ValueMember = "LOT_CODIGO";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmAberturaCaixa_Load(object sender, EventArgs e)
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
        private void PreencherCaixa()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oCaixa.intCodigo = 0;
                oCaixa.intCodigoServico = Convert.ToInt32(cboServico.SelectedValue);
                cboCaixa.DataSource = oCaixa.ConsultarCaixa();
                cboCaixa.DisplayMember = "Caixa";
                cboCaixa.ValueMember = "CAI_CODIGO";
                btnAbrirCaixa.Enabled = true;
                //btnRemoverCaixa.Enabled = true;
                cboCaixa.Enabled = true;
                cboCaixa.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboServico_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboCaixa.Text = string.Empty;
            cboLote.Text = string.Empty;

            if (blnLoad)
            {
                blnLoad = false;
                PreencherCaixa();
                blnLoad = true;
            }
        }
        private void cboCaixa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAbrirCaixa.PerformClick();
            }
        }
        private void btnAbrirLote_Click(object sender, EventArgs e)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                if (cboLote.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o número do lote.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                dsDocumentos.Tables.Clear();
                dsFormalizacao.Tables.Clear();
                oLote.intCodigo = 0;
                oLote.strLote = cboLote.Text.ToUpper();
                oLote.intStatusLote = (int)Funcoes.StatusLote.Aberto;
                if (cboLote.FindStringExact(cboLote.Text) != -1)
                {
                    oLote.intCodigo = Convert.ToInt32(cboLote.SelectedValue);
                    oLote.ConsultarLote(false);
                    if (oLote.intStatusLote == (int)Funcoes.StatusLote.EmDigitacao || oLote.intStatusLote == (int)Funcoes.StatusLote.EmDigitalizacao)
                    {
                        MessageBox.Show("Lote em Digitação/Digitalização, não é possível abrir o lote.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cboLote.Focus();
                        return;
                    }
                    oLote.GravarLote();
                }
                else
                {
                    oLote.GravarLote();
                    oLote.intCodigo = 0;
                    PreencherLote();
                }
                cboLote.SelectedIndex = cboLote.FindStringExact(oLote.strLote);
                oLote.intCodigo = Convert.ToInt32(cboLote.SelectedValue);
                cboLote.Enabled = false;
                btnGravarCaixa.Enabled = false;
                btnAbrirLote.Enabled = false;
                btnRemoverLote.Enabled = false;
                btnFecharLote.Enabled = true;
                txtDocumento.Enabled = true;
                btnAdd.Enabled = true;
                btnRemover.Enabled = true;
                grpAutomatico.Enabled = true;
                grpFormalizacao.Enabled = true;
                grpFilho.Enabled = true;
                grpDocumentos.Enabled = true;
                txtPrefixo.Enabled = true;
                nudInicio.Enabled = true;
                nudFim.Enabled = true;
                btnProcessar.Enabled = true;
                txtDocumentosCaixa.Text = Funcoes.intDocumentosCaixa.ToString();

                if (blnLoad && cboLote.SelectedIndex != -1)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    oLote.ConsultarImagens(true);
                    lstDocumentos.Items.Clear();
                    foreach (Imagem oImagem in oLote.Imagens)
                    {
                        if (oImagem.blnParent)
                        {
                            lstDocumentos.Items.Add(oImagem.strNomeArquivo);
                            oImagem.strArquivoPai = oImagem.strNomeArquivo;
                            AdicionarPai(oImagem);
                        }
                        else
                        {
                            AdicionarFilho(oImagem.strArquivoPai, oImagem.strNomeArquivo);
                        }
                    }
                    intTotalCaixa = oLote.ContarImagensCaixa(true);
                    TotalImagens();
                    oLote.intCodigoCaixa = Convert.ToInt32(cboCaixa.SelectedValue);
                    //txtTotalCaixa.Text = (intTotalCaixa + lstDocumentos.Items.Count).ToString();
                    if (lstDocumentos.Items.Count > 0)
                    {
                        lstDocumentos.SelectedIndex = 0;
                    }
                    Cursor.Current = Cursors.Default;
                    txtDocumento.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboLote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAbrirLote.PerformClick();
            }
        }
        private void btnFecharLote_Click(object sender, EventArgs e)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                if (MessageBox.Show("Confirma fechamento do Lote " + cboLote.Text + "?", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    PreencherClasse();
                    oLote.GravarImagens();
                    oLote.intStatusLote = (int)Funcoes.StatusLote.AguardandoDigitalizacao;
                    oLote.GravarLote();
                    oLote.intCodigo = 0;
                    oLote.strLote = string.Empty;
                    oLote.Imagens.Clear();

                    MessageBox.Show("Lote fechado com sucesso.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPrefixo.Text = string.Empty;
                    txtDocumentosCaixa.Text = string.Empty;
                    txtTotalCaixa.Text = string.Empty;
                    lstFilhos.DataSource = null;
                    nudInicio.Value = 0;
                    nudFim.Value = 0;
                    grpAutomatico.Enabled = false;
                    grpFormalizacao.Enabled = false;
                    grpFilho.Enabled = false;
                    grpDocumentos.Enabled = false;
                    //txtPrefixo.Enabled = false;
                    //nudInicio.Enabled = false;
                    //nudFim.Enabled = false;
                    //btnProcessar.Enabled = false;
                    btnAbrirLote.Enabled = false;
                    btnRemoverLote.Enabled = false;
                    btnFecharLote.Enabled = false;
                    btnAdd.Enabled = false;
                    btnRemover.Enabled = false;
                    txtDocumento.Enabled = false;
                    btnAbrirLote.Enabled = true;
                    btnRemoverLote.Enabled = true;
                    cboLote.Enabled = true;
                    btnGravarCaixa.Enabled = true;
                    lstDocumentos.Items.Clear();
                    PreencherLote();
                    TotalImagens();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRemoverLote_Click(object sender, EventArgs e)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                if (cboLote.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o número do lote.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show("Todas os documentos do lote " + cboLote.Text + " serão excluídos.\nDeseja continuar?", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    oLote.intCodigo = Convert.ToInt32(cboLote.SelectedValue);
                    oLote.ConsultarLote(false);
                    if (oLote.intStatusLote == (int)Funcoes.StatusLote.EmDigitacao || oLote.intStatusLote == (int)Funcoes.StatusLote.EmDigitalizacao)
                    {
                        MessageBox.Show("Lote em Digitação/Digitalização, não é possível excluir o lote.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cboLote.Focus();
                    }
                    else
                    {
                        oLote.RemoverLote();
                        MessageBox.Show("Lote removido com sucesso.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        oLote.intCodigo = 0;
                        oLote.strLote = string.Empty;
                        PreencherLote();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRemoverCaixa_Click(object sender, EventArgs e)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                //if (cboCaixa.Text == string.Empty)
                //{
                //    MessageBox.Show("Preencha o número da caixa.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                //if (MessageBox.Show("Todas os lotes e documentos da caixa " + cboCaixa.Text + " serão excluídos.\nDeseja continuar?", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                //{
                //    oCaixa.intCodigo = Convert.ToInt32(cboCaixa.SelectedValue);
                //    if (!oCaixa.ConsultarCaixaFechada())
                //    {
                //        MessageBox.Show("Caixa com lotes em Digitação/Digitalização, não é possível excluir a caixa.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        cboLote.Focus();
                //    }
                //    else
                //    {
                //        oCaixa.RemoverCaixa();
                //        MessageBox.Show("Caixa removida com sucesso.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        oCaixa.intCodigo = 0;
                //        oCaixa.strCaixa = string.Empty;
                //        PreencherCaixa();
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtDocumento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd.PerformClick();
            }
        }
        private void frmAberturaCaixa_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (blnAberta)
            {
                MessageBox.Show("Existe uma caixa aberta. Feche-a antes de fechar o formulário.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }
        private void btnProcessar_Click(object sender, EventArgs e)
        {
            for (decimal decContador = nudInicio.Value; decContador <= nudFim.Value; decContador++)
            {
                Application.DoEvents();
                txtDocumento.Text = (txtPrefixo.Text + decContador.ToString()).ToUpper();
                btnAdd.PerformClick();
                Application.DoEvents();
            }
        }

        private void btnAddFilho_Click(object sender, EventArgs e)
        {
            if (txtFilho.Text.ToUpper().IndexOf('A') != -1)
            {
                MessageBox.Show("Não é permitido documento ASO ser adicionado como FILHO.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFilho.Focus();
                return;
            }
            string strDocumento = (cboCaixa.Text + "_" + cboLote.Text + "_" + txtFilho.Text).ToUpper();

            if (lstDocumentos.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um documento PAI.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFilho.Focus();
                return;
            }

            if (txtFilho.Text == string.Empty)
            {
                MessageBox.Show("Preencha o documento FILHO.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFilho.Focus();
                return;
            }
            else
            {
                bool blnExiste = false;
                foreach (DataRow linha in dsDocumentos.Tables[lstDocumentos.Text].Rows)
                {
                    if (linha[0].ToString() == strDocumento)
                    {
                        blnExiste = true;
                        break;
                    }
                }
                if (!blnExiste)
                {
                    AdicionarFilho(lstDocumentos.Text, strDocumento);
                }
                else
                {
                    txtFilho.Text = string.Empty;
                }
            }
        }

        private void btnRemFilho_Click(object sender, EventArgs e)
        {
            if (lstFilhos.SelectedIndex != -1)
            {
                dsDocumentos.Tables[lstDocumentos.Text].Rows.RemoveAt(lstFilhos.SelectedIndex);
                AtualizarFilho(lstDocumentos.Text);
            }
        }
        private void AdicionarPai(Imagem imagem)
        {
            DataTable dt = new DataTable(imagem.strArquivoPai);
            DataTable dt1 = new DataTable(imagem.strArquivoPai);
            dt.Columns.Add(new DataColumn("DOCUMENTO_FILHO"));
            dsDocumentos.Tables.Add(dt);
            dt1.Columns.Add(new DataColumn("IMPRESSO"));
            dt1.Columns.Add(new DataColumn("PCMSO"));
            dt1.Columns.Add(new DataColumn("APTO"));
            dt1.Columns.Add(new DataColumn("ALTURA"));
            dt1.Columns.Add(new DataColumn("CARIMBO"));
            dt1.Columns.Add(new DataColumn("CONTATO"));
            dt1.Columns.Add(new DataColumn("ASSINATURA"));
            dt1.Columns.Add(new DataColumn("DATAS"));
            dt1.Columns.Add(new DataColumn("DIGITAL"));
            dsFormalizacao.Tables.Add(dt1);
            DataRow linha = dt1.NewRow();
            linha["IMPRESSO"] = imagem.blnImpresso.ToString();
            linha["PCMSO"] = imagem.blnPCMSO.ToString();
            linha["APTO"] = imagem.blnApto.ToString();
            linha["ALTURA"] = imagem.blnAltura.ToString();
            linha["CARIMBO"] = imagem.blnCarimbo.ToString();
            linha["CONTATO"] = imagem.blnContato.ToString();
            linha["ASSINATURA"] = imagem.blnAssinatura.ToString();
            linha["DATAS"] = imagem.blnDatas.ToString();
            linha["DIGITAL"] = imagem.blnDigital.ToString();
            dsFormalizacao.Tables[imagem.strArquivoPai].Rows.Add(linha);
        }

        private void AdicionarFilho(string strDocPai, string strDocFilho)
        {
            DataRow linha = dsDocumentos.Tables[strDocPai].NewRow();
            linha["DOCUMENTO_FILHO"] = strDocFilho;
            dsDocumentos.Tables[strDocPai].Rows.Add(linha);
            txtFilho.Text = string.Empty;
            AtualizarFilho(strDocPai);
        }

        private void lstDocumentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!blnRemover)
            {
                AtualizarFilho(lstDocumentos.Text);
                AtualizarCheckBox();
            }
            else
            {
                blnRemover = false;
            }
        }
        private void AtualizarFilho(string strPai)
        {
            lstFilhos.DataSource = null;
            lstFilhos.DataSource = dsDocumentos.Tables[strPai];
            lstFilhos.DisplayMember = "DOCUMENTO_FILHO";
            lstFilhos.ValueMember = "DOCUMENTO_FILHO";
        }
        private void AtualizarCheckBox()
        {
            chkImpresso.Checked = Convert.ToBoolean(dsFormalizacao.Tables[lstDocumentos.Text].Rows[0]["IMPRESSO"]);
            chkPCMSO.Checked = Convert.ToBoolean(dsFormalizacao.Tables[lstDocumentos.Text].Rows[0]["PCMSO"]);
            chkApto.Checked = Convert.ToBoolean(dsFormalizacao.Tables[lstDocumentos.Text].Rows[0]["APTO"]);
            chkAltura.Checked = Convert.ToBoolean(dsFormalizacao.Tables[lstDocumentos.Text].Rows[0]["ALTURA"]);
            chkCarimbo.Checked = Convert.ToBoolean(dsFormalizacao.Tables[lstDocumentos.Text].Rows[0]["CARIMBO"]);
            chkTelefone.Checked = Convert.ToBoolean(dsFormalizacao.Tables[lstDocumentos.Text].Rows[0]["CONTATO"]);
            chkAssinatura.Checked = Convert.ToBoolean(dsFormalizacao.Tables[lstDocumentos.Text].Rows[0]["ASSINATURA"]);
            chkData.Checked = Convert.ToBoolean(dsFormalizacao.Tables[lstDocumentos.Text].Rows[0]["DATAS"]);
            chkDigital.Checked = Convert.ToBoolean(dsFormalizacao.Tables[lstDocumentos.Text].Rows[0]["DIGITAL"]);
        }

        private void txtFilho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAddFilho.PerformClick();
            }
        }

        private void lstFilhos_KeyDown(object sender, KeyEventArgs e)
        {
            if (lstFilhos.SelectedIndex != -1 && e.KeyCode == Keys.Delete)
            {
                btnRemFilho.PerformClick();
            }
        }

        private void chkImpresso_CheckedChanged(object sender, EventArgs e)
        {
            if (lstDocumentos.Items.Count > 0)
            {
                dsFormalizacao.Tables[lstDocumentos.Text].Rows[0]["IMPRESSO"] = chkImpresso.Checked.ToString();
                VerificarMarcados();
            }
        }

        private void chkPCMSO_CheckedChanged(object sender, EventArgs e)
        {
            if (lstDocumentos.Items.Count > 0)
            {
                dsFormalizacao.Tables[lstDocumentos.Text].Rows[0]["PCMSO"] = chkPCMSO.Checked.ToString();
                VerificarMarcados();
            }
        }

        private void chkApto_CheckedChanged(object sender, EventArgs e)
        {
            if (lstDocumentos.Items.Count > 0)
            {
                dsFormalizacao.Tables[lstDocumentos.Text].Rows[0]["APTO"] = chkApto.Checked.ToString();
                VerificarMarcados();
            }
        }

        private void chkAltura_CheckedChanged(object sender, EventArgs e)
        {
            if (lstDocumentos.Items.Count > 0)
            {
                dsFormalizacao.Tables[lstDocumentos.Text].Rows[0]["ALTURA"] = chkAltura.Checked.ToString();
                VerificarMarcados();
            }
        }

        private void chkCarimbo_CheckedChanged(object sender, EventArgs e)
        {
            if (lstDocumentos.Items.Count > 0)
            {
                dsFormalizacao.Tables[lstDocumentos.Text].Rows[0]["CARIMBO"] = chkCarimbo.Checked.ToString();
                VerificarMarcados();
            }
        }

        private void chkTelefone_CheckedChanged(object sender, EventArgs e)
        {
            if (lstDocumentos.Items.Count > 0)
            {
                dsFormalizacao.Tables[lstDocumentos.Text].Rows[0]["CONTATO"] = chkTelefone.Checked.ToString();
                VerificarMarcados();
            }
        }

        private void chkAssinatura_CheckedChanged(object sender, EventArgs e)
        {
            if (lstDocumentos.Items.Count > 0)
            {
                dsFormalizacao.Tables[lstDocumentos.Text].Rows[0]["ASSINATURA"] = chkAssinatura.Checked.ToString();
                VerificarMarcados();
            }
        }

        private void chkData_CheckedChanged(object sender, EventArgs e)
        {
            if (lstDocumentos.Items.Count > 0)
            {
                dsFormalizacao.Tables[lstDocumentos.Text].Rows[0]["DATAS"] = chkData.Checked.ToString();
                VerificarMarcados();
            }
        }

        private void chkDigital_CheckedChanged(object sender, EventArgs e)
        {
            if (lstDocumentos.Items.Count > 0)
            {
                dsFormalizacao.Tables[lstDocumentos.Text].Rows[0]["DIGITAL"] = chkDigital.Checked.ToString();
                VerificarMarcados();
            }
        }
        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void MarcarTodos(bool blnMarcar)
        {
            foreach (Control checkbox in grpFormalizacao.Controls)
            {
                if (checkbox.Name != "chkTodos")
                {
                    CheckBox chk = checkbox as CheckBox;
                    chk.Checked = blnMarcar;
                }
            }
        }

        private void chkTodos_Click(object sender, EventArgs e)
        {
            MarcarTodos(chkTodos.Checked);
        }
        private void VerificarMarcados()
        {
            bool blnRetorno = true;
            foreach (Control checkbox in grpFormalizacao.Controls)
            {
                if (checkbox.Name != "chkTodos")
                {
                    CheckBox chk = checkbox as CheckBox;
                    if (!chk.Checked)
                    {
                        blnRetorno = false;
                    }
                }
            }
            chkTodos.Checked = blnRetorno;
        }

        private void cboCaixa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (blnLoad)
            {
                oCaixa.intCodigo = Convert.ToInt32(cboCaixa.SelectedValue);
                oCaixa.ConsultarCaixa();
                txtEmpresa.Text = oCaixa.strEmpresa;
            }
        }


    }
}
