using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Transactions;
using System.Reflection;

namespace SID_Telecred
{
    public partial class frmDigitacao : Form
    {
        public frmDigitacao()
        {
            InitializeComponent();
        }
        #region Objetos e variáveis
        Servico oServico = new Servico();
        Lote oLote = new Lote();
        DataTable dtChave = new DataTable();
        int intContadorImagens = 0;
        int intMaxTabIndex = 0;
        string[] strFixo;
        bool blnLoad;
        bool blnFechar = false;
        bool blnUltimo = false;
        int intZoom = 100;
        int intContFilho = 0;
        #endregion

        #region Eventos
        private void frmDigitacao_Load(object sender, EventArgs e)
        {
            blnLoad = false;
            PreencherServico();
            this.Size = new Size(438, 177);
            blnLoad = true;
        }
        public void MaskedEventoLeave(object sender, EventArgs e)
        {
            if (!blnFechar)
            {
                MaskedTextBox txt = sender as MaskedTextBox;

                if (!ValidarFormato(txt, ((string[])(txt.Tag))[5], Convert.ToBoolean(((string[])(txt.Tag))[4])))
                {
                    MessageBox.Show(((string[])(txt.Tag))[3] + " inválido.",
                        "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt.Text = string.Empty;
                    txt.Focus();
                    return;
                }
                else if (Convert.ToBoolean(((string[])(txt.Tag))[6]))
                {
                    foreach (Campo campo in oServico.Campos)
                    {
                        if (campo.blnChave)
                        {
                            campo.strConteudo = txt.Text;
                            dtChave = oServico.ConsultarChave();
                            break;
                        }
                    }
                    ExibirConteudo();
                }
                else if (Convert.ToBoolean(((string[])(txt.Tag))[4]) && txt.Text == string.Empty)
                {
                    MessageBox.Show("Preenchimento do campo " + ((string[])(txt.Tag))[3] + " é obrigatório.",
                        "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt.Focus();
                    return;
                }
                if (blnUltimo)
                {
                    btnGravar.PerformClick();
                }
            }
        }
        public void TextEventoLeave(object sender, EventArgs e)
        {
            if (!blnFechar)
            {
                TextBox txt = sender as TextBox;

                if (Convert.ToBoolean(((string[])(txt.Tag))[4]) && txt.Text == string.Empty)
                {
                    MessageBox.Show("Preenchimento do campo " + ((string[])(txt.Tag))[3] + " é obrigatório.",
                        "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt.Focus();
                    return;
                }
                else if (Convert.ToBoolean(((string[])(txt.Tag))[6]))
                {
                    foreach (Campo campo in oServico.Campos)
                    {
                        if (campo.blnChave)
                        {
                            campo.strConteudo = txt.Text;
                            dtChave = oServico.ConsultarChave();
                            break;
                        }
                    }
                    ExibirConteudo();
                }
            }
        }
        public void ComboEventoLeave(object sender, EventArgs e)
        {
            ComboBox cbo = sender as ComboBox;

            if (Convert.ToBoolean(((string[])(cbo.Tag))[4]) && cbo.SelectedIndex == -1)
            {
                MessageBox.Show("Preenchimento do campo " + ((string[])(cbo.Tag))[3] + " é obrigatório.",
                    "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbo.Focus();
                return;
            }
        }
        public void TextEventoKeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (e.KeyCode == Keys.Enter)
            {
                if (txt.TabIndex == intMaxTabIndex)
                {
                    btnGravar.PerformClick();
                }
                else
                {
                    SendKeys.Send("{TAB}");
                }
            }
        }
        public void MaskedEventoKeyDown(object sender, KeyEventArgs e)
        {
            MaskedTextBox txt = sender as MaskedTextBox;
            if (e.KeyCode == Keys.Enter)
            {
                if (txt.TabIndex == intMaxTabIndex)
                {
                    blnUltimo = true;
                }
                else
                {
                    blnUltimo = false;
                }
                SendKeys.Send("{TAB}");
            }
        }
        public void ComboEventoKeyDown(object sender, KeyEventArgs e)
        {
            ComboBox cbo = sender as ComboBox;
            if (e.KeyCode == Keys.Enter)
            {
                if (cbo.TabIndex == intMaxTabIndex)
                {
                    btnGravar.PerformClick();
                }
                else
                {
                    SendKeys.Send("{TAB}");
                }
            }
        }
        public void NumericUpDownEventoKeyDown(object sender, KeyEventArgs e)
        {
            NumericUpDown nud = sender as NumericUpDown;
            if (e.KeyCode == Keys.Enter)
            {
                if (nud.TabIndex == intMaxTabIndex)
                {
                    btnGravar.PerformClick();
                }
                else
                {
                    SendKeys.Send("{TAB}");
                }
            }
        }
        public void DateTimePickerEventoKeyDown(object sender, KeyEventArgs e)
        {
            DateTimePicker dtp = sender as DateTimePicker;
            if (e.KeyCode == Keys.Enter)
            {
                if (dtp.TabIndex == intMaxTabIndex)
                {
                    btnGravar.PerformClick();
                }
                else
                {
                    SendKeys.Send("{TAB}");
                }
            }
        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oServico.Campos.Clear();
                oServico.strNomeArquivo = grpImagem.Text;
                oServico.intCodigoLote = oLote.intCodigo;

                foreach (Control c in this.Controls)
                {
                    Campo oCampo = new Campo();
                    if (c.Name != "txtServico" && c.Name != "txtLote")
                    {
                        if (c is TextBox)
                        {
                            TextBox txt = c as TextBox;
                            oCampo.intCodigo = Convert.ToInt32(((string[])(txt.Tag))[0]);
                            oCampo.strConteudo = txt.Text;
                            oCampo.intOrdem = Convert.ToInt32(((string[])(txt.Tag))[1]);
                        }
                        else if (c is MaskedTextBox)
                        {
                            MaskedTextBox txt = c as MaskedTextBox;
                            oCampo.intCodigo = Convert.ToInt32(((string[])(txt.Tag))[0]);
                            oCampo.strConteudo = "CPF+CNPJ".IndexOf(((string[])(txt.Tag))[5]) != -1 ? txt.Text.Replace(".", "").Replace("-", "").Replace("/", "") : txt.Text;
                            oCampo.strConteudo = txt.Text;
                            oCampo.intOrdem = Convert.ToInt32(((string[])(txt.Tag))[1]);
                        }
                        else if (c is DateTimePicker)
                        {
                            DateTimePicker dtp = c as DateTimePicker;
                            oCampo.intCodigo = Convert.ToInt32(((string[])(dtp.Tag))[0]);
                            oCampo.strConteudo = dtp.CustomFormat.IndexOf(':') == -1 ? dtp.Value.ToShortDateString() : dtp.Value.ToShortTimeString();
                            oCampo.intOrdem = Convert.ToInt32(((string[])(dtp.Tag))[1]);
                        }
                        else if (c is NumericUpDown)
                        {
                            NumericUpDown nud = c as NumericUpDown;
                            oCampo.intCodigo = Convert.ToInt32(((string[])(nud.Tag))[0]);
                            oCampo.strConteudo = nud.Value.ToString();
                            oCampo.intOrdem = Convert.ToInt32(((string[])(nud.Tag))[1]);
                        }
                        else if (c is ComboBox)
                        {
                            oCampo.intCodigo = Convert.ToInt32(((string[])(c.Tag))[0]);
                            oCampo.strConteudo = c.Text;
                            oCampo.intOrdem = Convert.ToInt32(((string[])(c.Tag))[1]);
                        }
                        else if (c is RadioButton)
                        {
                            RadioButton rdb = c as RadioButton;
                            if (rdb.Name.IndexOf("Sim") != -1)
                            {
                                oCampo.intCodigo = Convert.ToInt32(((string[])(rdb.Tag))[0]);
                                oCampo.strConteudo = rdb.Checked ? "Sim" : "Não";
                                oCampo.intOrdem = Convert.ToInt32(((string[])(rdb.Tag))[1]);
                            }
                        }
                        if (oCampo.intCodigo != 0)
                        {
                            oCampo.strConteudo = oCampo.strConteudo.ToUpper();
                            oServico.Campos.Add(oCampo);
                        }
                    }
                }

                Gravar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAbrirLote_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Tag = cboServico.SelectedValue;
            this.txtServico.Text = cboServico.Text;
            this.txtLote.Tag = cboLote.SelectedValue;
            this.txtLote.Text = cboLote.Text;
            stsStatus.Visible = true;
            lblLote.Visible = true;
            lblServico.Visible = true;
            txtLote.Visible = true;
            txtServico.Visible = true;
            btnGravar.Visible = true;
            btnLimpar.Visible = true;
            btnFechar.Visible = true;
            btnIlegivel.Visible = true;
            btnRefresh.Visible = true;
            btnFilho.Visible = true;
            grpServico.Visible = false;
            grpImagem.Visible = true;
            oServico.intCodigo = Convert.ToInt32(this.Tag);
            oLote.intCodigo = Convert.ToInt32(cboLote.SelectedValue);
            oLote.ConsultarLote(false);
            oLote.ConsultarImagens(false);
            if (oLote.Imagens.Count == 0)
            {
                MessageBox.Show("Lote sem imagens ou com todas as imagens digitadas", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CarregarImagem();
            Application.DoEvents();
            pgbProgresso.Maximum = oLote.Imagens.Count;
            pgbProgresso.Value = 0;
            lblContadorRegistros.Text = "Registros Incluídos: " + Funcoes.intTotalRegistros.ToString("0000");
            lblProgresso.Text = "Progresso do Lote: " + intContadorImagens.ToString("0000") + " de " + oLote.Imagens.Count + "(" + (((double)(intContadorImagens) / (double)(oLote.Imagens.Count)) * 100).ToString("000") + "%)";
            Application.DoEvents();
            CarregarCampos();
            Application.DoEvents();
            CriaEvento();
            Application.DoEvents();
            LimparCampos();
        }
        private void cboServico_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (blnLoad)
            {
                PreencherLotes();
            }
        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmDigitacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {

                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                if (!blnFechar && oLote.intCodigo != 0)
                {
                    if (Funcoes.blnDesconectado || Funcoes.blnSair)
                    {
                        blnFechar = true;
                        oLote.intStatusLote = (int)Funcoes.StatusLote.AguardandoDigitacao;
                        oLote.AlterarStatus();
                    }
                    else if (MessageBox.Show("Deseja realmente encerrar a digitação?",
                        "Sistema Integrado de Digitação Telecred", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        blnFechar = true;
                        oLote.intStatusLote = (int)Funcoes.StatusLote.AguardandoDigitacao;
                        oLote.AlterarStatus();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CarregarImagem();
        }
        private void btnIlegivel_Click(object sender, EventArgs e)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                if (MessageBox.Show("Deseja marcar a imagem como ilegível?",
                       "Sistema Integrado de Digitação Telecred", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                       MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    Imagem imagem = new Imagem();
                    imagem.strNomeArquivo = oLote.Imagens[intContadorImagens].strNomeArquivo;
                    imagem.intStatus = (int)Funcoes.StatusImagem.Ilegivel;
                    oLote.AlterarStatusImagem(imagem);
                    MoverImagem(Funcoes.StatusImagem.Ilegivel);
                    AtualizarContadores();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Métodos
        private void PreencherServico()
        {
            cboServico.DataSource = Funcoes.CarregarServico();
            cboServico.DisplayMember = "SER_DESCRICAO";
            cboServico.ValueMember = "SER_CODIGO";
            cboServico.SelectedIndex = -1;
        }
        private void CarregarCampos()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oLote.intCodigo = Convert.ToInt32(txtLote.Tag);
                oLote.intStatusLote = (int)Funcoes.StatusLote.EmDigitacao;
                oLote.AlterarStatus();
                oServico.intCodigo = Convert.ToInt32(this.Tag);
                oServico.Consultar();
                int intLeftLabel = lblServico.Left;
                int intLeftCampo = txtLote.Left;
                int intPosicaoLabel = 90;
                int intPosicaoCampo = 86;
                strFixo = new string[oServico.Campos.Count];
                for (int intContador = 0; intContador < strFixo.Length; intContador++)
                {
                    strFixo[intContador] = string.Empty;
                }

                foreach (Campo objCampo in oServico.Campos)
                {
                    Label lbl = new Label();
                    lbl.Location = new Point(intLeftLabel, intPosicaoLabel);
                    lbl.Text = objCampo.blnPreenchimento ? "*" : "";
                    lbl.Text += objCampo.strDescricao;
                    lbl.Name = "Label" + objCampo.intOrdem.ToString();
                    lbl.Font = new Font("Microsoft Sans Serif", 10);
                    lbl.Size = new Size(164, 20);
                    lbl.TextAlign = ContentAlignment.TopRight;
                    lbl.Anchor = (AnchorStyles.Right | AnchorStyles.Top);
                    this.Controls.Add(lbl);

                    if (objCampo.intCodigoTipoCampo == (int)Funcoes.TipoCampo.Alphanumerico)
                    {
                        if (objCampo.strMascaraAlpha != string.Empty)
                        {
                            MaskedTextBox txt = new MaskedTextBox();
                            txt.Name = "Campo" + objCampo.intOrdem.ToString();
                            txt.Location = new Point(intLeftCampo, intPosicaoCampo);
                            txt.Font = new Font("Microsoft Sans Serif", 10);
                            txt.Size = new Size(275, 26);
                            txt.TabIndex = objCampo.intOrdem - 1;
                            txt.Mask = objCampo.strMascaraAlpha.Replace(",", "|").Replace(".", ",").Replace("|", ".");
                            txt.Anchor = (AnchorStyles.Right | AnchorStyles.Top);
                            txt.Tag = (objCampo.intCodigo.ToString() + "|" + objCampo.intOrdem.ToString() + "|" + objCampo.intPosicaoLayout.ToString() + "|" + objCampo.strDescricao + "|" + objCampo.blnPreenchimento.ToString() + "|" + objCampo.strFormatoAlpha + "|" + objCampo.blnChave.ToString()).Split('|');
                            this.Controls.Add(txt);
                        }
                        else
                        {
                            TextBox txt = new TextBox();
                            txt.Name = "Campo" + objCampo.intOrdem.ToString();
                            txt.Location = new Point(intLeftCampo, intPosicaoCampo);
                            txt.Font = new Font("Microsoft Sans Serif", 10);
                            txt.Size = new Size(275, 26);
                            txt.TabIndex = objCampo.intOrdem - 1;
                            txt.MaxLength = objCampo.intTamanho;
                            txt.Anchor = (AnchorStyles.Right | AnchorStyles.Top);
                            txt.Tag = (objCampo.intCodigo.ToString() + "|" + objCampo.intOrdem.ToString() + "|" + objCampo.intPosicaoLayout.ToString() + "|" + objCampo.strDescricao + "|" + objCampo.blnPreenchimento.ToString() + "|" + objCampo.strFormatoAlpha + "|" + objCampo.blnChave.ToString()).Split('|');
                            this.Controls.Add(txt);
                        }
                    }
                    else if (objCampo.intCodigoTipoCampo == (int)Funcoes.TipoCampo.Numerico)
                    {
                        NumericUpDown nud = new NumericUpDown();
                        nud.Name = "Campo" + objCampo.intOrdem.ToString();
                        nud.Location = new Point(intLeftCampo, intPosicaoCampo);
                        nud.Font = new Font("Microsoft Sans Serif", 10);
                        nud.Size = new Size(275, 26);
                        nud.TabIndex = objCampo.intOrdem - 1;
                        nud.Minimum = (decimal)objCampo.dblMinimo;
                        nud.Maximum = (decimal)objCampo.dblMaximo;
                        nud.DecimalPlaces = objCampo.intCasasDecimais;
                        nud.ThousandsSeparator = objCampo.blnSeparadorMilhar;
                        nud.Anchor = (AnchorStyles.Right | AnchorStyles.Top);
                        nud.Tag = (objCampo.intCodigo.ToString() + "|" + objCampo.intOrdem.ToString() + "|" + objCampo.intPosicaoLayout.ToString() + "|" + objCampo.strDescricao + "|" + objCampo.blnPreenchimento.ToString()).Split('|');
                        this.Controls.Add(nud);
                    }
                    else if (objCampo.intCodigoTipoCampo == (int)Funcoes.TipoCampo.Data)
                    {
                        DateTimePicker dtp = new DateTimePicker();
                        dtp.Name = "Campo" + objCampo.intOrdem.ToString();
                        dtp.Location = new Point(intLeftCampo, intPosicaoCampo);
                        dtp.Font = new Font("Microsoft Sans Serif", 10);
                        dtp.Size = new Size(275, 26);
                        dtp.TabIndex = objCampo.intOrdem - 1;
                        dtp.MaxDate = objCampo.dttMaxima;
                        dtp.MinDate = objCampo.dttMinima;
                        dtp.Format = DateTimePickerFormat.Custom;
                        dtp.CustomFormat = objCampo.strFormatoData.ToLower().Replace("mm", "MM");
                        dtp.Anchor = (AnchorStyles.Right | AnchorStyles.Top);
                        dtp.Tag = (objCampo.intCodigo.ToString() + "|" + objCampo.intOrdem.ToString() + "|" + objCampo.intPosicaoLayout.ToString() + "|" + objCampo.strDescricao + "|" + objCampo.blnPreenchimento.ToString()).Split('|');
                        this.Controls.Add(dtp);
                    }
                    else if (objCampo.intCodigoTipoCampo == (int)Funcoes.TipoCampo.Hora)
                    {
                        DateTimePicker dtp = new DateTimePicker();
                        dtp.Name = "Campo" + objCampo.intOrdem.ToString();
                        dtp.Location = new Point(intLeftCampo, intPosicaoCampo);
                        dtp.Font = new Font("Microsoft Sans Serif", 10);
                        dtp.Size = new Size(275, 26);
                        dtp.TabIndex = objCampo.intOrdem - 1;
                        dtp.Format = DateTimePickerFormat.Custom;
                        dtp.ShowUpDown = true;
                        dtp.CustomFormat = objCampo.strFormatoHora == "12:00" ? "hh:mm" : "HH:mm";
                        dtp.Anchor = (AnchorStyles.Right | AnchorStyles.Top);
                        dtp.Tag = (objCampo.intCodigo.ToString() + "|" + objCampo.intOrdem.ToString() + "|" + objCampo.intPosicaoLayout.ToString() + "|" + objCampo.strDescricao + "|" + objCampo.blnPreenchimento.ToString()).Split('|');
                        this.Controls.Add(dtp);
                    }
                    else if (objCampo.intCodigoTipoCampo == (int)Funcoes.TipoCampo.Opcoes)
                    {
                        ComboBox cbo = new ComboBox();
                        cbo.Name = "Campo" + objCampo.intOrdem.ToString();
                        cbo.Location = new Point(intLeftCampo, intPosicaoCampo);
                        cbo.Font = new Font("Microsoft Sans Serif", 10);
                        cbo.Size = new Size(275, 26);
                        cbo.TabIndex = objCampo.intOrdem - 1;
                        cbo.DataSource = objCampo.strOpcoes;
                        cbo.DropDownStyle = ComboBoxStyle.DropDownList;
                        cbo.Anchor = (AnchorStyles.Right | AnchorStyles.Top);
                        cbo.Tag = (objCampo.intCodigo.ToString() + "|" + objCampo.intOrdem.ToString() + "|" + objCampo.intPosicaoLayout.ToString() + "|" + objCampo.strDescricao + "|" + objCampo.blnPreenchimento.ToString()).Split('|');
                        this.Controls.Add(cbo);
                    }
                    else if (objCampo.intCodigoTipoCampo == (int)Funcoes.TipoCampo.Logico)
                    {
                        RadioButton rdbSim = new RadioButton();
                        rdbSim.Name = "CampoSim" + objCampo.intOrdem.ToString();
                        rdbSim.Location = new Point(intLeftCampo, intPosicaoCampo);
                        rdbSim.Text = "Sim";
                        rdbSim.Font = new Font("Microsoft Sans Serif", 10);
                        rdbSim.Size = new Size(100, 26);
                        rdbSim.TabIndex = objCampo.intOrdem - 1;
                        rdbSim.Checked = true;
                        rdbSim.Anchor = (AnchorStyles.Right | AnchorStyles.Top);
                        rdbSim.Tag = (objCampo.intCodigo.ToString() + "|" + objCampo.intOrdem.ToString() + "|" + objCampo.intPosicaoLayout.ToString() + "|" + objCampo.strDescricao + "|" + objCampo.blnPreenchimento.ToString()).Split('|');
                        this.Controls.Add(rdbSim);

                        RadioButton rdbNao = new RadioButton();
                        rdbNao.Name = "CampoNao" + objCampo.intOrdem.ToString();
                        rdbNao.Location = new Point(1100, intPosicaoCampo);
                        rdbNao.Text = "Não";
                        rdbNao.Font = new Font("Microsoft Sans Serif", 10);
                        rdbNao.Size = new Size(100, 26);
                        rdbNao.TabIndex = objCampo.intOrdem - 1;
                        rdbNao.Anchor = (AnchorStyles.Right | AnchorStyles.Top);
                        rdbNao.Tag = (objCampo.intCodigo.ToString() + "|" + objCampo.intOrdem.ToString() + "|" + objCampo.intPosicaoLayout.ToString() + "|" + objCampo.strDescricao + "|" + objCampo.blnPreenchimento.ToString()).Split('|');
                        this.Controls.Add(rdbNao);
                    }
                    intPosicaoCampo += 30;
                    intPosicaoLabel += 30;
                    intMaxTabIndex = objCampo.intOrdem - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CriaEvento()
        {
            foreach (Control c in this.Controls)
            {
                if (c is MaskedTextBox)
                {
                    c.Leave += new EventHandler(this.MaskedEventoLeave);
                    c.KeyDown += new KeyEventHandler(this.MaskedEventoKeyDown);
                }
                else if (c is TextBox)
                {
                    c.Leave += new EventHandler(this.TextEventoLeave);
                    c.KeyDown += new KeyEventHandler(this.TextEventoKeyDown);
                }
                else if (c is ComboBox)
                {
                    c.Leave += new EventHandler(this.ComboEventoLeave);
                    c.KeyDown += new KeyEventHandler(this.ComboEventoKeyDown);
                }
                else if (c is NumericUpDown)
                {
                    c.KeyDown += new KeyEventHandler(this.NumericUpDownEventoKeyDown);
                }
                else if (c is DateTimePicker)
                {
                    c.KeyDown += new KeyEventHandler(this.DateTimePickerEventoKeyDown);
                }
            }
        }
        private void ExibirConteudo()
        {
            oServico.blnBanco = false;
            if (dtChave.Rows.Count > 0)
            {
                oServico.blnBanco = true;
                foreach (DataRow linha in dtChave.Rows)
                {
                    string strConteudo = linha[0].ToString();
                    int intPosicao = Convert.ToInt32(linha[1]);
                    foreach (Campo campo in oServico.Campos)
                    {
                        if (campo.intPosicaoLayout == intPosicao && !campo.blnChave)
                        {
                            foreach (Control c in this.Controls)
                            {
                                if (c.Name != "txtServico" && c.Name != "txtLote")
                                {
                                    if (c is MaskedTextBox)
                                    {
                                        MaskedTextBox txt1 = c as MaskedTextBox;
                                        if (Convert.ToInt32(((string[])(txt1.Tag))[2]) == intPosicao)
                                        {
                                            txt1.Text = strConteudo;
                                            break;
                                        }
                                    }
                                    else if (c is TextBox)
                                    {
                                        TextBox txt1 = c as TextBox;
                                        if (Convert.ToInt32(((string[])(txt1.Tag))[2]) == intPosicao)
                                        {
                                            txt1.Text = strConteudo;
                                            break;
                                        }
                                    }
                                    else if (c is ComboBox)
                                    {
                                        ComboBox cbo1 = c as ComboBox;
                                        if (Convert.ToInt32(((string[])(cbo1.Tag))[2]) == intPosicao)
                                        {
                                            cbo1.SelectedIndex = cbo1.FindString(strConteudo);
                                            break;
                                        }
                                    }
                                    else if (c is DateTimePicker)
                                    {
                                        DateTimePicker dtp1 = c as DateTimePicker;
                                        if (Convert.ToInt32(((string[])(dtp1.Tag))[2]) == intPosicao)
                                        {
                                            dtp1.Value = Convert.ToDateTime(strConteudo);
                                            break;
                                        }
                                    }
                                    else if (c is NumericUpDown)
                                    {
                                        NumericUpDown nud1 = c as NumericUpDown;
                                        if (Convert.ToInt32(((string[])(nud1.Tag))[2]) == intPosicao)
                                        {
                                            nud1.Value = Convert.ToDecimal(strConteudo);
                                            break;
                                        }
                                    }
                                }
                            }
                            break;
                        }
                    }
                }
            }
        }
        private bool ValidarFormato(MaskedTextBox msktxt, string strFormato, bool blnObrigatorio)
        {
            bool blnResultado = true;
            if (strFormato == "CPF")
            {
                blnResultado = Funcoes.ValidaCPF(msktxt.Text, blnObrigatorio);
            }
            else if (strFormato == "CNPJ")
            {
                blnResultado = Funcoes.ValidaCNPJ(msktxt.Text, blnObrigatorio);
            }
            else if (strFormato == "CPF+CNPJ")
            {
                if (msktxt.Text.Trim().Length < 12)
                {
                    msktxt.Text = msktxt.Text.PadLeft(11, '0');
                    blnResultado = Funcoes.ValidaCPF(msktxt.Text, blnObrigatorio);
                }
                else
                {
                    msktxt.Text = msktxt.Text.PadLeft(14, '0');
                    blnResultado = Funcoes.ValidaCNPJ(msktxt.Text, blnObrigatorio);
                }
            }            
            return blnResultado;
        }
        private void LimparCampos()
        {
            blnUltimo = false;
            foreach (Control c in this.Controls)
            {
                if (c.Name == "Campo1")
                {
                    c.Focus();
                }
                if (c is TextBox || c is MaskedTextBox)
                {
                    if (c.Name != "txtServico" && c.Name != "txtLote")
                    {
                        //c.Text = string.Empty;
                        c.Text = strFixo[c.TabIndex];
                    }
                }
                else if (c is DateTimePicker)
                {
                    DateTimePicker dtp = c as DateTimePicker;
                    if (dtp.CustomFormat.IndexOf(':') != -1)
                    {
                        dtp.Value = Convert.ToDateTime("01/01/1900 00:00:00.000");
                    }
                    else
                    {
                        dtp.Value = DateTime.Now;
                    }

                }
                else if (c is NumericUpDown)
                {
                    NumericUpDown nud = c as NumericUpDown;
                    nud.Value = nud.Minimum;
                }
                else if (c is ComboBox)
                {
                    ComboBox cbo = c as ComboBox;
                    cbo.SelectedIndex = -1;
                }
                else if (c is RadioButton && c.Name.IndexOf("Sim") != -1)
                {
                    RadioButton rdb = c as RadioButton;
                    rdb.Checked = true;
                }
            }
        }
        private void MoverImagem(Funcoes.StatusImagem destino)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                string strOrigem = Funcoes.strCaminhoImagens + @"Imagens\" + oLote.strCaixa + "_" + oLote.strLote + @"_\" + oLote.Imagens[intContadorImagens].strNomeArquivo + ".pdf";
                string strDestino = Funcoes.strCaminhoImagens + @"Digitadas\" + oLote.Imagens[intContadorImagens].strNomeArquivo + ".pdf";
                //string strOrigem = ConfigurationManager.AppSettings["CaminhoImagens"] + @"Imagens\" + oLote.Imagens[intContadorImagens].strNomeArquivo + ".pdf";
                //string strDestino = ConfigurationManager.AppSettings["CaminhoImagens"] + @"Digitadas\" + oLote.Imagens[intContadorImagens].strNomeArquivo + ".pdf";
                if (destino == Funcoes.StatusImagem.Ilegivel)
                {
                    strDestino = strDestino.Replace("Digitadas", "Ilegíveis");
                }
                File.Copy(strOrigem, strDestino, true);
                File.Delete(strOrigem);
                //intContadorImagens++;
                //ProximaImagem();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AtualizarContadores()
        {
            pgbProgresso.Value++;
            lblContadorRegistros.Text = "Registros Incluídos: " + Funcoes.intTotalRegistros.ToString("0000");
            lblProgresso.Text = "Progresso do Lote: " + intContadorImagens.ToString("0000") + " de " + oLote.Imagens.Count + "(" + (((double)(intContadorImagens) / (double)(oLote.Imagens.Count)) * 100).ToString("000") + "%)";
        }
        private void Gravar()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oServico.GravarRegistro();
                Imagem imagem = new Imagem();
                imagem.strNomeArquivo = oLote.Imagens[intContadorImagens].strNomeArquivo;
                imagem.intStatus = (int)Funcoes.StatusImagem.AguardandoFechamentoLote;
                oLote.AlterarStatusImagem(imagem);
                MoverImagem(Funcoes.StatusImagem.AguardandoFechamentoCaixa);
                intContadorImagens++;
                Funcoes.intTotalRegistros++;
                AtualizarContadores();
                MessageBox.Show("Registro incluído com sucesso", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                oServico.Consultar();
                LimparCampos();
                ProximaImagem();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ProximaImagem()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                if (intContadorImagens < oLote.Imagens.Count)
                {
                    CarregarImagem();
                }
                else
                {
                    //Mover Imagens Restantes
                    DirectoryInfo Dir = new DirectoryInfo(Funcoes.strCaminhoImagens + @"Imagens\" + oLote.strCaixa + "_" + oLote.strLote + "_");

                    // Busca automaticamente todos os arquivos em todos os subdiretórios

                    FileInfo[] Files = Dir.GetFiles("*", SearchOption.AllDirectories);

                    foreach (FileInfo arquivo in Files)
                    {
                        File.Copy(arquivo.FullName, Funcoes.strCaminhoImagens + @"Digitadas\" + arquivo.Name, true);
                        File.Delete(arquivo.FullName);
                    }

                    Directory.Delete(Funcoes.strCaminhoImagens + @"Imagens\" + oLote.strCaixa + "_" + oLote.strLote + "_");

                    MessageBox.Show("Lote encerrado.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    oLote.intStatusLote = (int)Funcoes.StatusLote.AguardandoUpload;
                    oLote.AlterarStatus();
                    blnFechar = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CarregarImagem()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                grpFilho.Visible = false;
                btnFilho.Enabled = oLote.Imagens[intContadorImagens].filhos.Count > 0;

                grpImagem.Text = oLote.Imagens[intContadorImagens].strNomeArquivo;
                string strNomeImagem = Funcoes.strCaminhoImagens + @"Imagens\" + oLote.strCaixa + "_" + oLote.strLote + @"_\" + oLote.Imagens[intContadorImagens].strNomeArquivo + ".pdf";
                if (File.Exists(strNomeImagem))
                {
                    Application.DoEvents();
                    pdfDocumento.LoadFile(strNomeImagem);
                    Application.DoEvents();
                    pdfDocumento.Refresh();
                    Application.DoEvents();
                    pdfDocumento.setZoom(intZoom);
                    pdfDocumento.setView("FitH");
                    //string str = pdfDocumento.ToString();
                    //pdfDocumento.ShowPropertyPages();
                    //Size tam = pdfDocumento.GetPreferredSize(pdfDocumento.Size);
                }
                else
                {
                    string strPasta = Funcoes.strCaminhoImagens + @"Imagens\" + oLote.strCaixa + "_" + oLote.strLote + @"_\";
                    if (!Directory.Exists(strPasta))
                    {
                        Directory.CreateDirectory(strPasta);
                    }
                    //MessageBox.Show("Imagem " + oLote.Imagens[intContadorImagens].strNomeArquivo + " não localizada.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Imagem imagem = new Imagem();
                    imagem.strNomeArquivo = oLote.Imagens[intContadorImagens].strNomeArquivo;
                    imagem.intCodigoLote = oLote.intCodigo;
                    //imagem.intStatus = (int)Funcoes.StatusImagem.ArquivoNaoEncontrado;
                    //oLote.AlterarStatusImagem(imagem);
                    imagem.ConsultarImagem(true);
                    //string strImagem = Funcoes.strCaminhoImagens + @"Imagens\" + imagem.strNomeArquivo + ".pdf";
                    File.WriteAllBytes(strNomeImagem, imagem.bytImagem);
                    imagem.intStatus = (int)Funcoes.StatusImagem.AguardandoDigitacao;
                    oLote.AlterarStatusImagem(imagem);
                    //intContadorImagens++;
                    //pgbProgresso.Value++;Z:\Digitadas\CXA_838850041_CP00291_A015654.pdf
                    CarregarImagem();
                }
                tmrFocus.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PreencherLotes()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oLote.intCodigoServico = Convert.ToInt32(cboServico.SelectedValue);
                cboLote.DataSource = oLote.ConsultarLote(true);
                cboLote.DisplayMember = "Lote";
                cboLote.ValueMember = "LOT_CODIGO";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tmrFocus_Tick(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c.Name == "Campo1")
                {
                    c.Focus();
                    tmrFocus.Enabled = false;
                    break;
                }
            }
        }
        private void frmDigitacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 107 && e.Control)
            {
                intZoom += 10;
                pdfDocumento.setZoom(intZoom);
            }
            else if (e.KeyValue == 109 && e.Control)
            {
                intZoom -= 10;
                pdfDocumento.setZoom(intZoom);
            }
            else if ((e.KeyValue == 67 || e.KeyValue == 99) && e.Control)
            {
                MaskedTextBox masktxt = Controls.OfType<MaskedTextBox>().FirstOrDefault(x => x.Focused);
                TextBox plaintxt = Controls.OfType<TextBox>().FirstOrDefault(x => x.Focused);
                if (masktxt != null)
                {
                    strFixo[masktxt.TabIndex] = masktxt.Text;
                }
                else if (txtLote != null)
                {
                    strFixo[plaintxt.TabIndex] = plaintxt.Text;
                }
            }
        }
        #endregion

        private void btnFilho_Click(object sender, EventArgs e)
        {
            grpFilho.Visible = true;
            grpFilho.Text = oLote.Imagens[intContadorImagens].filhos[intContFilho];
            string strNomeImagem = Funcoes.strCaminhoImagens + @"Imagens\" + oLote.strCaixa + "_" + oLote.strLote + @"_\" + oLote.Imagens[intContadorImagens].filhos[intContFilho] + ".pdf";
            if (File.Exists(strNomeImagem))
            {
                Application.DoEvents();
                pdfFilho.LoadFile(strNomeImagem);
                Application.DoEvents();
                pdfFilho.Refresh();
                Application.DoEvents();
                pdfFilho.setZoom(intZoom);
                //string str = pdfDocumento.ToString();
                //pdfDocumento.ShowPropertyPages();
                //Size tam = pdfDocumento.GetPreferredSize(pdfDocumento.Size);
            }
            else
            {
                string strPasta = Funcoes.strCaminhoImagens + @"Imagens\" + oLote.strCaixa + "_" + oLote.strLote + @"_\";
                if (!Directory.Exists(strPasta))
                {
                    Directory.CreateDirectory(strPasta);
                }
                //MessageBox.Show("Imagem " + oLote.Imagens[intContadorImagens].strNomeArquivo + " não localizada.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Imagem imagem = new Imagem();
                imagem.strNomeArquivo = oLote.Imagens[intContadorImagens].filhos[intContFilho];
                imagem.intCodigoLote = oLote.intCodigo;
                //imagem.intStatus = (int)Funcoes.StatusImagem.ArquivoNaoEncontrado;
                //oLote.AlterarStatusImagem(imagem);
                imagem.ConsultarImagem(true);
                //string strImagem = Funcoes.strCaminhoImagens + @"Imagens\" + imagem.strNomeArquivo + ".pdf";
                File.WriteAllBytes(strNomeImagem, imagem.bytImagem);
                //imagem.intStatus = (int)Funcoes.StatusImagem.AguardandoDigitacao;
                //oLote.AlterarStatusImagem(imagem);
                //intContadorImagens++;
                //pgbProgresso.Value++;Z:\Digitadas\CXA_838850041_CP00291_A015654.pdf
                btnFilho.PerformClick();
            }
            intContFilho++;
            if (intContFilho >= oLote.Imagens[intContadorImagens].filhos.Count)
            {
                intContFilho = 0;
            }
        }

        private void pdfFilho_OnError(object sender, EventArgs e)
        {

        }
    }
}
