using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SID_Telecred
{
    public partial class frmReembolso : Form
    {
        public frmReembolso()
        {
            InitializeComponent();
        }


        #region Variáveis
        PEG peg = new PEG();


        string numeroGuia = string.Empty;
        string numeroEvento = string.Empty;
        DataTable dtEventos = new DataTable();
        int intZoom = 100;

        Servico oServico = new Servico();
        Lote oLote = new Lote();
        int intContadorImagens = 0;


        bool blnLoad;
        bool blnFechar = false;

        #endregion

        #region Eventos

        #region KeyPress
        private void txtBanco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtValorReembolso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSegurado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtDigitador_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtValorGuia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAgencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtContaCorrente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSeguradoEvento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtEvento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSolicitante_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtValorEvento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPEG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region KeyDown
        private void txtBanco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lblBanco.Text = Funcoes.RetornaNomeBanco(txtBanco.Text);                
                if (lblBanco.Text == string.Empty)
                {
                    MessageBox.Show("Banco não localizado.", "Reembolso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SendKeys.Send("{TAB}");
                }
            }
            else if (e.KeyCode == Keys.F10)
            {
                frmPesquisa form = new frmPesquisa();
                form.txtTabela.Text = "bancos";
                form.txtCampos.Text = "numero, banco";
                form.txtCampoBusca.Text = "numero";
                form.txtCampoRetorno.Text = "numero";
                form.txtAssunto.Text = "Bancos";
                form.txtPesquisa.Text = txtBanco.Text;
                form.ShowDialog();
                if (Funcoes.strRetornoPesquisa != string.Empty)
                {
                    txtBanco.Text = Funcoes.strRetornoPesquisa;
                    SendKeys.Send("{TAB}");
                    Funcoes.strRetornoPesquisa = string.Empty;
                }
            }
        }

        private void txtSegurado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lblNomeSegurado.Text = Funcoes.RetornaNomeAssociado(txtSegurado.Text);
                if (lblNomeSegurado.Text == string.Empty)
                {
                    MessageBox.Show("Segurado não localizado.", "Reembolso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SendKeys.Send("{TAB}");
                }
            }
            else if (e.KeyCode == Keys.F10)
            {
                frmPesquisa form = new frmPesquisa();
                form.txtTabela.Text = "carteiras";
                form.txtCampos.Text = "numero, nome";
                form.txtCampoBusca.Text = "titular";
                form.txtPesquisa.Text = txtSegurado.Text;
                form.txtCampoRetorno.Text = "numero,nome";
                form.txtAssunto.Text = "Segurados";
                form.ShowDialog();
                if (Funcoes.strRetornoPesquisa != string.Empty)
                {
                    var retorno = Funcoes.strRetornoPesquisa.Split(',');
                    Funcoes.strRetornoPesquisa = string.Empty;
                    txtSegurado.Text = retorno[0];
                    lblNomeSegurado.Text = retorno[1];
                }
            }
        }

        private void txtValorGuia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAddGuia.PerformClick();
            }
        }

        private void grdGuias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                btnRemGuias.PerformClick();
            }
        }

        private void txtValorEvento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAddEvento.PerformClick();
            }
        }

        private void frmReembolso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 107 && e.Control)
            {
                intZoom += 10;
                pdfImagem.setZoom(intZoom);
            }
            else if (e.KeyValue == 109 && e.Control)
            {
                intZoom -= 10;
                pdfImagem.setZoom(intZoom);
            }
        }

        private void txtEvento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lblNomeEvento.Text = Funcoes.RetornaProcedimento(txtEvento.Text);
                if (lblNomeEvento.Text == string.Empty)
                {
                    if (MessageBox.Show("Código do evento não localizado.\nDeseja cadastrar este evento?", "Reembolso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        frmEvento ofrmEvento = new frmEvento();
                        ofrmEvento.txtCodigo.Text = txtEvento.Text;
                        ofrmEvento.ShowDialog();
                        SendKeys.Send("{ENTER}");
                    }
                }
                else
                {
                    SendKeys.Send("{TAB}");
                }
            }
            else if (e.KeyCode == Keys.F10)
            {
                frmPesquisa form = new frmPesquisa();
                form.txtTabela.Text = "procedimentos";
                form.txtCampos.Text = "codigo, descricao";
                form.txtCampoBusca.Text = "descricao";
                form.txtPesquisa.Text = txtEvento.Text;
                form.txtCampoRetorno.Text = "codigo, descricao";
                form.txtAssunto.Text = "Eventos";
                form.ShowDialog();
                if (Funcoes.strRetornoPesquisa != string.Empty)
                {
                    var retorno = Funcoes.strRetornoPesquisa.Split(',');
                    Funcoes.strRetornoPesquisa = string.Empty;
                    txtEvento.Text = retorno[0];
                    lblNomeEvento.Text = retorno[1];
                }
            }
        }

        private void txtSeguradoEvento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lblSeguradoEvento.Text = Funcoes.RetornaNomeAssociado(txtSeguradoEvento.Text);
                if (lblSeguradoEvento.Text == string.Empty)
                {
                    MessageBox.Show("Segurado não localizado.", "Reembolso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SendKeys.Send("{TAB}");
                }
            }
            else if (e.KeyCode == Keys.F10)
            {
                frmPesquisa form = new frmPesquisa();
                form.txtTabela.Text = "carteiras";
                form.txtCampos.Text = "numero, nome";
                form.txtCampoBusca.Text = "titular";
                form.txtCampoRetorno.Text = "numero,nome";
                form.txtAssunto.Text = "Segurados";
                form.txtPesquisa.Text = txtSeguradoEvento.Text;
                form.ShowDialog();
                if (Funcoes.strRetornoPesquisa != string.Empty)
                {
                    var retorno = Funcoes.strRetornoPesquisa.Split(',');
                    Funcoes.strRetornoPesquisa = string.Empty;
                    txtSeguradoEvento.Text = retorno[0];
                    lblSeguradoEvento.Text = retorno[1];
                }
            }
        }
        #endregion

        #region Leave
        private void txtValorReembolso_Leave(object sender, EventArgs e)
        {
            Double value;
            if (Double.TryParse(txtValorReembolso.Text, out value))
            {
                value = value / 100;
                txtValorReembolso.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", value);
            }
            else
            {
                txtValorReembolso.Text = "R$ 0,00";
            }
            AtualizarTotalGuias();
            AtualizarTotalEventos();
        }

        private void txtSegurado_Leave(object sender, EventArgs e)
        {
            txtSeguradoEvento.Text = txtSegurado.Text;
            lblSeguradoEvento.Text = lblNomeSegurado.Text;
        }

        private void txtCPF_Leave(object sender, EventArgs e)
        {
            if (!Funcoes.ValidaCPF(txtCPF.Text, false))
            {
                MessageBox.Show("CPF inválido.", "Reembolso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCPF.Focus();
            }
        }

        private void txtSolicitante_Leave(object sender, EventArgs e)
        {
            if (txtSolicitante.Text.Length <= 11)
            {
                if (!Funcoes.ValidaCPF(txtSolicitante.Text, false))
                {
                    MessageBox.Show("Solicitante inválido.", "Reembolso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSolicitante.Focus();
                }
            }
            else
            {
                if (!Funcoes.ValidaCNPJ(txtSolicitante.Text, false))
                {
                    MessageBox.Show("Solicitante inválido.", "Reembolso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSolicitante.Focus();
                }
            }
        }
        #endregion

        #region Click
        private void btnAddGuia_Click(object sender, EventArgs e)
        {
            if (txtValorGuia.Text != string.Empty)
            {
                double valor = double.Parse(Regex.Replace(txtValorGuia.Text, @"[^\d]", "")) / 100;
                int totalGuias = grdGuias.Rows.Count + 1;
                string[] guia = new string[2];
                guia[0] = totalGuias.ToString();
                guia[1] = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", valor);

                if (numeroGuia == string.Empty)
                {
                    grdGuias.Rows.Add(guia);
                }
                else
                {
                    foreach (DataGridViewRow linha in grdGuias.Rows)
                    {
                        if (linha.Cells[0].Value.ToString() == numeroGuia)
                        {
                            linha.Cells[1].Value = guia[1];
                        }
                    }
                }
                AtualizarTotalGuias();
                numeroGuia = string.Empty;
                txtValorGuia.Clear();
                txtValorGuia.Focus();
            }
        }

        private void btnRemGuias_Click(object sender, EventArgs e)
        {
            if (grdGuias.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Deseja realmente remover a guia selecionada? \nTodos os eventos lançados serão apagados!!!", "Reembolso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    int ordemGuia = int.Parse(grdGuias.SelectedRows[0].Cells[0].Value.ToString());
                    int ordemGuiaEvento = 0;
                    int contador = 0;

                    grdGuias.Rows.Remove(grdGuias.SelectedRows[0]);
                    Application.DoEvents();

                    while (grdEventos.Rows.Count > 0 && contador < grdEventos.Rows.Count)
                    {
                        ordemGuiaEvento = int.Parse(grdEventos.Rows[contador].Cells[0].Value.ToString());
                        Application.DoEvents();
                        if (ordemGuiaEvento == ordemGuia)
                        {
                            grdEventos.Rows.RemoveAt(contador);
                            Application.DoEvents();
                            contador = 0;
                        }
                        else if (ordemGuiaEvento > ordemGuia)
                        {
                            while (true)
                            {

                                grdEventos.Rows[contador].Cells[0].Value = ordemGuiaEvento - 1;
                                Application.DoEvents();

                                //contador++;
                                if (contador >= grdEventos.Rows.Count)
                                {
                                    break;
                                }
                            }
                        }
                        contador++;
                    }


                    txtValorGuia.Clear();
                    AtualizarTotalGuias();
                    AtualizarTotalEventos();
                }
            }
        }

        private void btnAddEvento_Click(object sender, EventArgs e)
        {
            string strMensagemErro = string.Empty;
            if (grdGuias.Rows.Count==0)
            {
                strMensagemErro += "- Informe o valor da guia antes de lançar os eventos.\n";
            }
            if (lblSeguradoEvento.Text == string.Empty)
            {
                strMensagemErro += "- Segurado não informado.\n";
            }
            if (lblNomeEvento.Text == string.Empty)
            {
                strMensagemErro += "- Procedimento não informado.\n";
            }
            if (dtpEvento.Value.ToShortDateString()=="01/01/1900")
            {
                strMensagemErro += "- Data de Atendimento não informada.\n";
            }
            if (txtSolicitante.Text == string.Empty)
            {
                strMensagemErro += "- Solicitante não informado.\n";
            }
            if (!double.TryParse(txtValorEvento.Text, out double result))
            {
                strMensagemErro += "- Valor não informado.";
            }
            if (strMensagemErro!=string.Empty)
            {
                MessageBox.Show(strMensagemErro, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);     
                return;
            }

            string[] evento = new string[7];
            double valor = double.Parse(txtValorEvento.Text) / 100;
            int totalEventos = grdEventos.Rows.Count + 1;

            evento[0] = grdGuias.SelectedRows[0].Cells[0].Value.ToString();
            evento[1] = totalEventos.ToString();
            evento[2] = dtpEvento.Value.ToShortDateString();
            evento[3] = txtSeguradoEvento.Text;
            evento[4] = txtSolicitante.Text;
            evento[5] = txtEvento.Text;
            evento[6] = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", valor);

            lblNumeroGuia.Text = evento[0];

            if (numeroEvento == string.Empty)
            {
                grdEventos.Rows.Add(evento);
            }
            else
            {
                foreach (DataGridViewRow linha in grdEventos.Rows)
                {
                    if (numeroEvento == linha.Cells[1].Value.ToString())
                    {
                        linha.Cells[2].Value = evento[2];
                        linha.Cells[3].Value = evento[3];
                        linha.Cells[4].Value = evento[4];
                        linha.Cells[5].Value = evento[5];
                        linha.Cells[6].Value = evento[6];
                    }
                }
                numeroEvento = string.Empty;
            }
            //AtualizaGrid(grdEventos, lblSaldoGuia, grdGuias.SelectedRows[0].Cells[0].Value.ToString(), grdGuias.SelectedRows[0].Cells["valor"].Value.ToString());
            AtualizarTotalEventos();

            txtEvento.Clear();
            txtValorEvento.Clear();
            txtSolicitante.Clear();
            lblNomeEvento.Text = string.Empty;
            txtSeguradoEvento.Focus();
        }

        private void grdGuias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            txtValorGuia.Text = Regex.Replace(grdGuias.SelectedRows[0].Cells[1].Value.ToString(), @"[^\d]", "");
            numeroGuia = grdGuias.SelectedRows[0].Cells[0].Value.ToString();
            txtValorGuia.Focus();
        }

        private void grdEventos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            numeroEvento = grdEventos.SelectedRows[0].Cells["Nr"].Value.ToString();            
            dtpEvento.Value = DateTime.Parse(grdEventos.SelectedRows[0].Cells["Data"].Value.ToString());
            txtSeguradoEvento.Text = grdEventos.SelectedRows[0].Cells["Segurado"].Value.ToString();
            lblNomeSegurado.Text = Funcoes.RetornaNomeAssociado(txtSeguradoEvento.Text);
            txtSolicitante.Text = grdEventos.SelectedRows[0].Cells["Solicitante"].Value.ToString();
            txtEvento.Text = grdEventos.SelectedRows[0].Cells["Evento"].Value.ToString();
            txtValorEvento.Text = Regex.Replace(grdEventos.SelectedRows[0].Cells["valor"].Value.ToString(), @"[^\d]", "");
            lblNomeEvento.Text = Funcoes.RetornaProcedimento(txtEvento.Text);
        }

        private void btnRemEvento_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente remover o evento selecionado?", "Reembolso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (grdEventos.SelectedRows.Count > 0)
                {
                    grdEventos.Rows.Remove(grdEventos.SelectedRows[0]);
                    //AtualizaGrid(grdEventos, lblSaldoGuia, grdGuias.SelectedRows[0].Cells[0].Value.ToString(), grdGuias.SelectedRows[0].Cells["valor"].Value.ToString());
                    AtualizarTotalEventos();
                    txtEvento.Clear();
                    txtValorEvento.Clear();
                    txtSolicitante.Clear();
                }
            }
        }

        private void grdGuias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FiltrarGuias();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente limpar os campos do formulário? \nTodos os dados serão apagados!!!", "Reembolso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                LimparCampos();
            }
        }
        #endregion

        #region Enter
        private void txtValorReembolso_Enter(object sender, EventArgs e)
        {
            if (txtValorReembolso.Text == "R$ 0,00")
            {
                txtValorReembolso.Text = "0";
            }
            else
            {
                txtValorReembolso.Text = Regex.Replace(txtValorReembolso.Text, @"[^\d]", "");
            }
        }

        private void txtSegurado_Enter(object sender, EventArgs e)
        {
            lblNomeSegurado.Text = string.Empty;
        }
        #endregion

        #region Load
        private void frmReembolso_Load(object sender, EventArgs e)
        {           
            string[] linha = new string[2];
            grdGuias.Columns.Add("Nr", "N°");
            grdGuias.Columns.Add("Valor", "Valor");
            grdGuias.Columns[0].Width = 50;
            grdGuias.Columns[1].Width = 125;

            grdEventos.Columns.Add("Guia", "Guia");
            grdEventos.Columns.Add("Nr", "N°");
            grdEventos.Columns.Add("Data", "Data");
            grdEventos.Columns.Add("Segurado", "Segurado");
            grdEventos.Columns.Add("Solicitante", "Solicitante");
            grdEventos.Columns.Add("Evento", "Evento");
            grdEventos.Columns.Add("Valor", "Valor");
            grdEventos.Columns[0].Visible = false;

            this.Height = 123;
            this.Width = 297;

            Funcoes.CarregarAppConfig();

            PreencherLotes();
        }
        #endregion

        #endregion

        #region Métodos
        private void PreencherLotes()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oLote.intCodigoServico = Convert.ToInt32(this.Tag);
                cboLote.DataSource = oLote.ConsultarLote(true);
                cboLote.DisplayMember = "Lote";
                cboLote.ValueMember = "LOT_CODIGO";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarTotalGuias()
        {
            int intLinha = 1;
            string antigo = string.Empty;
            double total = 0;
            double totalPeg = 0;
            foreach (DataGridViewRow linha in grdGuias.Rows)
            {
                antigo = linha.Cells["Nr"].Value.ToString();
                linha.Cells["Nr"].Value = intLinha;
                total += double.Parse(Regex.Replace(linha.Cells["valor"].Value.ToString(), @"[^\d]", "")) / 100;
                intLinha++;
            }
            lblTotalPEG.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", total);
            totalPeg = double.Parse(Regex.Replace(txtValorReembolso.Text, @"[^\d]", "")) / 100;
            if (totalPeg > total)
            {
                lblTotalPEG.ForeColor = Color.Red;
            }
            else if (totalPeg < total)
            {
                lblTotalPEG.ForeColor = Color.Blue;
            }
            else
            {
                lblTotalPEG.ForeColor = Color.Green;
            }
        }

        private void FiltrarGuias()
        {
            lblNumeroGuia.Text = grdGuias.SelectedRows[0].Cells[0].Value.ToString();
            foreach (DataGridViewRow linha in grdEventos.Rows)
            {
                if (linha.Cells[0].Value.ToString() == grdGuias.SelectedRows[0].Cells[0].Value.ToString())
                {
                    linha.Visible = true;
                }
                else
                {
                    linha.Visible = false;
                }
            }
        }

        private void AtualizarTotalEventos()
        {
            //double total = 0;
            double saldoPEG = 0;
            double saldoGuia = 0;
            double totalPEG = double.Parse(Regex.Replace(txtValorReembolso.Text, @"[^\d]", "")) / 100;
            double totalGuias = grdGuias.SelectedRows.Count == 0 ? 0 : double.Parse(Regex.Replace(grdGuias.SelectedRows[0].Cells["valor"].Value.ToString(), @"[^\d]", "")) / 100;
            double eventosGuia = 0;
            double eventosPEG = 0;
            int contadorlinha = 0;
            //int contadorGuia = 0;
            string guiaAnterior = string.Empty;

            //Verificar atualização dos números das guias nos eventos quando uma guia for excluída. 
            //Não está funcionando
            foreach (DataGridViewRow linha in grdEventos.Rows)
            {
                eventosPEG += double.Parse(Regex.Replace(linha.Cells["valor"].Value.ToString(), @"[^\d]", "")) / 100;
                contadorlinha++;
                //if (guiaAnterior != linha.Cells[0].Value.ToString())
                //{
                //    contadorGuia++;
                //    linha.Cells[0].Value = contadorGuia;
                //    guiaAnterior = contadorGuia.ToString();
                //}
                linha.Cells[1].Value = contadorlinha;
                if (linha.Cells[0].Value.ToString() == grdGuias.SelectedRows[0].Cells[0].Value.ToString())
                {
                    eventosGuia += double.Parse(Regex.Replace(linha.Cells["valor"].Value.ToString(), @"[^\d]", "")) / 100;
                }
            }
            saldoPEG = totalPEG - eventosPEG;
            saldoGuia = totalGuias - eventosGuia;

            lblSaldoPEG.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", saldoPEG);
            lblSaldoGuia.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", saldoGuia);

            if (saldoPEG != 0)
            {
                lblSaldoPEG.ForeColor = Color.Red;
            }
            else
            {
                lblSaldoPEG.ForeColor = Color.Green;
            }

            if (saldoGuia != 0)
            {
                lblSaldoGuia.ForeColor = Color.Red;
            }
            else
            {
                lblSaldoGuia.ForeColor = Color.Green;
            }
        }

        private void LimparCampos()
        {

            txtPEG.Clear();
            txtSegurado.Clear();
            lblNomeSegurado.Text = string.Empty;
            nudQtde.Value = 1;
            txtValorReembolso.Clear();
            txtBanco.Clear();
            lblBanco.Text = string.Empty;
            txtAgencia.Clear();
            txtContaCorrente.Clear();
            txtCPF.Clear();
            txtSeguradoEvento.Clear();
            lblSeguradoEvento.Text = string.Empty;
            txtEvento.Clear();
            dtpEvento.Value = Convert.ToDateTime("1/1/1900");
            txtSolicitante.Clear();
            txtValorEvento.Clear();
            txtValorGuia.Clear();
            grdGuias.Rows.Clear();
            grdEventos.Rows.Clear();
            rdbConsulta.Checked = false;
            rdbSADT.Checked = false;
            rdbHM.Checked = false;

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
                //string strNomeImagem = @"C:\Users\Michael\Documents\Telecred\Reembolso\601319_06_8944734.pdf";
                //Application.DoEvents();
                //pdfImagem.LoadFile(strNomeImagem);
                //Application.DoEvents();
                //pdfImagem.Refresh();
                //Application.DoEvents();
                //pdfImagem.setZoom(intZoom);
                //pdfImagem.setView("FitH");
                grpImagem.Text = oLote.Imagens[intContadorImagens].strNomeArquivo;
                string strNomeImagem = Funcoes.strCaminhoImagens + @"Imagens\" + oLote.strCaixa + "_" + oLote.strLote + @"_\" + oLote.Imagens[intContadorImagens].strNomeArquivo + ".pdf";
                if (File.Exists(strNomeImagem))
                {
                    Application.DoEvents();
                    pdfImagem.LoadFile(strNomeImagem);
                    Application.DoEvents();
                    pdfImagem.Refresh();
                    Application.DoEvents();
                    pdfImagem.setZoom(intZoom);
                    pdfImagem.setView("FitH");
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreencherClasse()
        {
            if (rdbConsulta.Checked)
            {
                peg.TipoDocumento = 4;
            }
            else if (rdbSADT.Checked)
            {
                peg.TipoDocumento = 2;
            }
            else if (rdbHM.Checked)
            {
                peg.TipoDocumento = 1;
            }
            peg.Servico = Convert.ToInt32(this.Tag);
            peg.Numero = Convert.ToInt64(txtPEG.Text);
            peg.Segurado = txtSegurado.Text;
            peg.Quantidade = Convert.ToInt32(nudQtde.Value);
            peg.Valor = decimal.Parse(Regex.Replace(txtValorReembolso.Text, @"[^\d]", "")) / 100;
            peg.Banco = txtBanco.Text;
            peg.Agencia = txtAgencia.Text;
            peg.ContaCorrente = txtContaCorrente.Text;
            peg.CPF = txtCPF.Text;
            peg.Guias.Clear();

            foreach (DataGridViewRow linha_guia in grdGuias.Rows)
            {
                Guia guia = new Guia();
                guia.Valor = decimal.Parse(Regex.Replace(linha_guia.Cells[1].Value.ToString(), @"[^\d]", "")) / 100;                 
                string nr_guia = linha_guia.Cells[0].Value.ToString();

                foreach (DataGridViewRow linha_evento in grdEventos.Rows)
                {
                    if (linha_evento.Cells[0].Value.ToString() == nr_guia)
                    {
                        Procedimento procedimento = new Procedimento();
                        procedimento.DataAtendimento = Convert.ToDateTime(linha_evento.Cells[2].Value.ToString());
                        procedimento.Segurado = linha_evento.Cells[3].Value.ToString();
                        procedimento.Solicitante = linha_evento.Cells[4].Value.ToString();
                        procedimento.Codigo = linha_evento.Cells[5].Value.ToString();
                        procedimento.Valor = decimal.Parse(Regex.Replace(linha_evento.Cells[6].Value.ToString(), @"[^\d]", "")) / 100; 

                        guia.Procedimentos.Add(procedimento);
                    }
                }

                peg.Guias.Add(guia);
            }
        }

        private string ValidarPreenchimento()
        {
            string strMsgErro = string.Empty;

            if (txtPEG.Text == string.Empty)
            {
                strMsgErro += "- Número da PEG não informado.\n";
            }
            if (txtSegurado.Text == string.Empty)
            {
                strMsgErro += "- Segurado não informado.\n";
            }
            if (txtValorReembolso.Text == "R$ 0,00")
            {
                strMsgErro += "- Valor da PEG não informado.\n";
            }
            if (lblBanco.Text == string.Empty)
            {
                strMsgErro += "- Banco não informado.\n";
            }
            if (txtAgencia.Text == string.Empty)
            {
                strMsgErro += "- Agência não informada.\n";
            }
            if (txtContaCorrente.Text == string.Empty)
            {
                strMsgErro += "- Conta Corrente não informada.\n";
            }
            if (txtCPF.Text == string.Empty)
            {
                strMsgErro += "- Número do CPF não informado.\n";
            }
            if (!rdbConsulta.Checked && !rdbHM.Checked && !rdbSADT.Checked)
            {
                strMsgErro += "- Tipo da PEG não informado.\n";
            }
            if (grdGuias.Rows.Count == 0)
            {
                strMsgErro += "- Nenhuma guia informada.\n";
            }
            else
            {
                decimal total_guias = 0;
                decimal total_peg = 0;
                foreach (DataGridViewRow linha in grdGuias.Rows)
                {
                    total_guias += decimal.Parse(Regex.Replace(linha.Cells["valor"].Value.ToString(), @"[^\d]", "")) / 100;
                }
                total_peg = decimal.Parse(Regex.Replace(txtValorReembolso.Text, @"[^\d]", "")) / 100;

                if (total_peg != total_guias)
                {
                    strMsgErro += "- Existem valores divergentes nos lançamentos das guias.\n";
                }
            }
            if (grdEventos.Rows.Count == 0)
            {
                strMsgErro += "- Nenhum procedimento informado.\n";
            }
            else
            {
                decimal total_eventos = 0;
                decimal total_peg = 0;
                foreach (DataGridViewRow linha in grdEventos.Rows)
                {
                    total_eventos += decimal.Parse(Regex.Replace(linha.Cells["valor"].Value.ToString(), @"[^\d]", "")) / 100;
                }
                total_peg = decimal.Parse(Regex.Replace(txtValorReembolso.Text, @"[^\d]", "")) / 100;

                if (total_peg != total_eventos)
                {
                    strMsgErro += "- Existem valores divergentes nos lançamentos dos procedimentos.\n";
                }
            }
            return strMsgErro;
        }
        #endregion

        private void frmReembolso_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                if (oLote.intCodigo != 0)
                {
                    if (Funcoes.blnDesconectado|| Funcoes.blnSair)
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

        private void btnAbrirLote_Click(object sender, EventArgs e)
        {
            oServico.intCodigo = Convert.ToInt32(this.Tag);
            oLote.intCodigo = Convert.ToInt32(cboLote.SelectedValue);
            oLote.ConsultarLote(false);
            oLote.ConsultarImagens(false);
            if (oLote.Imagens.Count == 0)
            {
                MessageBox.Show("Lote sem imagens ou com todas as imagens digitadas", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Height = 721;
            this.Width = 1270;
            stsStatus.Visible = true;
            grpLote.Visible = false;
            oLote.intStatusLote = (int)Funcoes.StatusLote.EmDigitacao;
            oLote.AlterarStatus();

            CarregarImagem();
            Application.DoEvents();
            pgbProgresso.Maximum = oLote.Imagens.Count;
            pgbProgresso.Value = 0;
            lblContadorRegistros.Text = "Registros Incluídos: " + Funcoes.intTotalRegistros.ToString("0000");
            lblProgresso.Text = "Progresso do Lote: " + intContadorImagens.ToString("0000") + " de " + oLote.Imagens.Count + "(" + (((double)(intContadorImagens) / (double)(oLote.Imagens.Count)) * 100).ToString("000") + "%)";
            Application.DoEvents();
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
        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {   
                string strMensagemErro = ValidarPreenchimento();

                if (strMensagemErro!=string.Empty)
                {
                    MessageBox.Show(strMensagemErro, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                PreencherClasse();                
                peg.Gravar();
                Imagem imagem = new Imagem();
                imagem.strNomeArquivo = oLote.Imagens[intContadorImagens].strNomeArquivo;
                imagem.intStatus = (int)Funcoes.StatusImagem.AguardandoFechamentoLote;
                oLote.AlterarStatusImagem(imagem);
                MoverImagem(Funcoes.StatusImagem.AguardandoFechamentoCaixa);

                MessageBox.Show("PEG gravada com sucesso", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
                intContadorImagens++;
                Funcoes.intTotalRegistros++;
                AtualizarContadores();
                ProximaImagem();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AtualizarContadores()
        {
            pgbProgresso.Value = intContadorImagens;
            lblContadorRegistros.Text = "Registros Incluídos: " + Funcoes.intTotalRegistros.ToString();
            lblProgresso.Text = "Progresso do Lote: " + intContadorImagens.ToString() + " de " + oLote.Imagens.Count + "(" + (((double)(intContadorImagens) / (double)(oLote.Imagens.Count)) * 100).ToString("000") + "%)";
        }

        private void nudQtde_KeyDown(object sender, KeyEventArgs e)
        {
            
            Tab(e.KeyCode);
        }

        private void Tab(Keys tecla)
        {
            if (tecla == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtValorReembolso_KeyDown(object sender, KeyEventArgs e)
        {
            Tab(e.KeyCode);
        }

        private void txtAgencia_KeyDown(object sender, KeyEventArgs e)
        {
            Tab(e.KeyCode);
        }

        private void txtContaCorrente_KeyDown(object sender, KeyEventArgs e)
        {
            Tab(e.KeyCode);
        }

        private void txtCPF_KeyDown(object sender, KeyEventArgs e)
        {
            Tab(e.KeyCode);
        }

        private void dtpEvento_KeyDown(object sender, KeyEventArgs e)
        {
            Tab(e.KeyCode);
        }

        private void txtSolicitante_KeyDown(object sender, KeyEventArgs e)
        {
            Tab(e.KeyCode);
        }

        private void txtPEG_KeyDown(object sender, KeyEventArgs e)
        {
            Tab(e.KeyCode);
        }
    }
}
