using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SID_Telecred
{
    public partial class frmDistribuirPeg : Form
    {
        public frmDistribuirPeg()
        {
            InitializeComponent();
        }

        RegistroPeg registro = new RegistroPeg();
        RespostaPeg resposta = new RespostaPeg();
        bool blnLoad = false;

        private void CarregarRespostas(bool blnTratativa = false)
        {
            try
            {
                cboRespostas.DataSource = resposta.Consultar(true, blnTratativa);
                cboRespostas.DisplayMember = "TRP_DESCRICAO";
                cboRespostas.ValueMember = "TRP_CODIGO";

                cboRespostas.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                registro.BuscarPeg();

                if (registro.intPeg == 0)
                {
                    MessageBox.Show("Nenhum PEG retornada. Verifique suas as permissões com o Administrador do SID", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                txtNumeroPeg.Text = registro.intPeg.ToString();
                registro.ConsultaPeg();
                txtRegimeAtendimento.Text = registro.strRegimeAtendimento;
                txtConvenio.Text = registro.strConvenio;

                Clipboard.SetText(txtNumeroPeg.Text);
                if (txtNumeroPeg.Text == Clipboard.GetText())
                {
                    lblCopia.Visible = true;
                }

                blnLoad = false;
                if (registro.intStatus == 2)
                {
                    CarregarRespostas(false);
                }
                else
                {
                    this.Height = 406;
                    txtRespostaAnterior.Text = registro.strResposta;
                    txtEventos.Text = registro.intEventos.ToString();
                    txtEventos.ReadOnly = true;
                    txtRespostaAnterior.Visible = true;
                    lblRespostaAnterior.Visible = true;
                    btnAlterarRegime.Enabled = false;
                    CarregarRespostas(true);
                }
                blnLoad = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboRespostas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (blnLoad)
            {
                resposta.intCodigo = Convert.ToInt32(cboRespostas.SelectedValue);
                resposta.Consultar();

                txtComplemento.Enabled = resposta.blnCampoExtra;

            }
        }

        private void frmDistribuirPeg_Load(object sender, EventArgs e)
        {
            //CarregarRespostas();  
            lblCopia.Visible = false;
            this.Height = 376;
            //blnLoad = true;
        }

        private void btnDescartar_Click(object sender, EventArgs e)
        {
            if (registro.intPeg == 0)
                return;

            if (MessageBox.Show("Deseja realmente descartar a PEG " + txtNumeroPeg.Text + "?", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AtualizaPeg();
            }
        }

        private void AtualizaPeg(bool p_listagem = false)
        {
            try
            {
                registro.AlterarStatusPeg(p_listagem);
                if (!Funcoes.blnSair)
                    MessageBox.Show("Status da Peg Alterado com sucesso", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            txtNumeroPeg.Text = string.Empty;
            txtRegimeAtendimento.Text = string.Empty;
            txtComplemento.Text = string.Empty;
            txtEventos.Text = string.Empty;
            cboRespostas.SelectedIndex = -1;
            this.Height = 376;
            txtRespostaAnterior.Visible = false;
            lblRespostaAnterior.Visible = false;
            txtEventos.ReadOnly = false;
            btnAlterarRegime.Enabled = true;
            registro = new RegistroPeg();
            resposta = new RespostaPeg();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (registro.intCodigo == 0)
                return;

            try
            {
                string strMensagemErro = string.Empty;
                if (cboRespostas.SelectedIndex == -1)
                {
                    strMensagemErro = "Selecione a resposta a ser gravada.\n";
                }
                else if (txtComplemento.Enabled && txtComplemento.Text == string.Empty)
                {
                    strMensagemErro = "Preencha o complemento da resposta selecionada.\n";
                }
                if (txtEventos.Text == string.Empty)
                {
                    strMensagemErro += "Preencha a quantidade de eventos da PEG.";
                }

                if (strMensagemErro != string.Empty)
                {
                    MessageBox.Show(strMensagemErro, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("Confirma gravação da PEG " + txtNumeroPeg.Text + "?", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                registro.intEventos = Convert.ToInt32(txtEventos.Text);
                registro.strResposta = cboRespostas.Text + " " + txtComplemento.Text;
                registro.intResposta = resposta.intCodigo;
                registro.Gravar();

                if (registro.intTipoPeg == 1)
                {
                    Funcoes.intConsulta++;
                    if (registro.blnListagem)
                        Funcoes.intConsultaListagem++;
                }
                else if (registro.intTipoPeg == 2)
                {
                    Funcoes.intSADT++;
                    if (registro.blnListagem)
                        Funcoes.intSADTListagem++;
                }
                else if (registro.intTipoPeg == 3)
                {
                    Funcoes.intHospital++;
                    if (registro.blnListagem)
                        Funcoes.intHospitalListagem++;
                }
                else if (registro.intTipoPeg == 4)
                {
                    Funcoes.intDiamante++;
                    if (registro.blnListagem)
                        Funcoes.intDiamanteListagem++;
                }

                lblConsulta.Text = string.Format("Consultório / Clínica: {0}/{1}", Funcoes.intConsulta, Funcoes.intConsultaListagem);
                lblSADT.Text = string.Format("Atendimento Externo: {0}/{1}", Funcoes.intSADT, Funcoes.intSADTListagem);
                lblHospital.Text = string.Format("Hospital / Maternidade: {0}/{1}", Funcoes.intHospital, Funcoes.intHospitalListagem);
                lblDiamante.Text = string.Format("Diamante: {0}/{1}", Funcoes.intDiamante, Funcoes.intDiamanteListagem);

                MessageBox.Show("Dados da Peg gravados com sucesso", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnListagem_Click(object sender, EventArgs e)
        {
            if (registro.blnListagem || txtNumeroPeg.Text == string.Empty)
                return;
            try
            {
                //if (registro.intTipoPeg == 1 || registro.intTipoPeg == 4)
                //{
                //    MessageBox.Show("Não é permitido marcar como listagem as PEGs com regime de atendimento Consultório / Clinica!!!", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                if (MessageBox.Show("Deseja realmente marcar a PEG " + txtNumeroPeg.Text + " como listagem?", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    AtualizaPeg(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtEventos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDistribuirPeg_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (txtNumeroPeg.Text != string.Empty)
            {
                if (Funcoes.blnSair)
                {
                    AtualizaPeg();
                }
                else if (MessageBox.Show("A PEG será descartada caso o formulário seja fechado. Deseja realmente discartar a PEG " + txtNumeroPeg.Text + "?", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    AtualizaPeg();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnAlterarRegime_Click(object sender, EventArgs e)
        {
            try
            {
                if (registro.intCodigo != 0)
                {
                    frmAlterarRegimeAtendimento ofrmAlterarRegimeAtendimento = new frmAlterarRegimeAtendimento();
                    ofrmAlterarRegimeAtendimento.Tag = registro.intPeg;
                    ofrmAlterarRegimeAtendimento.ShowDialog();
                    if (ofrmAlterarRegimeAtendimento.DialogResult == DialogResult.OK)
                    {
                        registro.ConsultaPeg();
                        txtRegimeAtendimento.Text = registro.strRegimeAtendimento;

                        Usuario usuario = new Usuario();
                        usuario.intCodigo = Funcoes.intCodigoUsuario;
                        if (usuario.ConsultarPermissoesPEG(registro.intTipoPeg).Rows.Count == 0)
                        {
                            MessageBox.Show("Esta PEG será descartada pois você não possui permissão para este novo Regime de atendimento.\nVerifique suas as permissões com o Administrador do SID", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            registro.AlterarStatusPeg();
                            MessageBox.Show("Status da Peg Alterado com sucesso", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparCampos();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
