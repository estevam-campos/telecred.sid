using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SID_Telecred
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }
        DateTime dttLogin;
        //internal static Timer _timerContadorInatividade = new Timer();
        //internal static Timer _timerSessaoUsuario = new Timer();
        //internal static DateTime _tempoSessaoUsuario;
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            
            Funcoes.strMenuItens.Clear();
            foreach (ToolStripMenuItem item in mnuPrincipal.Items)
            {
                item.Enabled = false;
                Funcoes.strMenuItens.Add(item.Tag.ToString() + "|" + item.ToString().Replace("&", "") + "|" + item.Name.ToString());
                if (item.HasDropDownItems)
                {
                    foreach (object dropItem in item.DropDownItems)
                    {
                        if (dropItem is ToolStripDropDownItem)
                        {
                            ToolStripDropDownItem drop = dropItem as ToolStripDropDownItem;
                            drop.Enabled = false;
                            Funcoes.strMenuItens.Add(drop.Tag.ToString() + "|" + drop.ToString().Replace("&", "") + "|" + drop.Name.ToString());
                        }
                    }
                }

            }
            HabilitaMenus(true);

            //mnuDavita.Visible = false;
            //mnuNFe.Visible = false;

        }
        //private void IniciarContadorInatividade()
        //{
        //    _timerContadorInatividade.Interval = 10000; //300000; //10 segundos
        //    _timerContadorInatividade.Tick += TimerContadorInatividade_Tick;

        //    _tempoSessaoUsuario = new DateTime(0).AddMinutes(TimeSpan.FromMilliseconds(_timerContadorInatividade.Interval).TotalMinutes);

        //    _timerSessaoUsuario.Interval = 1000;
        //    _timerSessaoUsuario.Tick += TimerSessaoUsuario_Tick;
        //    _timerSessaoUsuario.Start();
        //}
        //private void TimerContadorInatividade_Tick(object sender, EventArgs e)
        //{
        //    Funcoes.RegistrarLogin((int)Funcoes.StatusLogin.Inatividade);
        //    lblUsuario.Image = Properties.Resources.bullet_ball_glass_red;
        //    lblUsuario.Text = "Usuario: ";
        //    Funcoes.intCodigoUsuario = 0;
        //    Funcoes.strNomeUsuario = string.Empty;
        //    timer1.Enabled = false;
        //    HabilitaMenus(true);
        //    _timerSessaoUsuario.Stop();
        //    MessageBox.Show("Usuário desconectado por inatividade", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}

        //private void TimerSessaoUsuario_Tick(object sender, EventArgs e)
        //{
        //    if (_tempoSessaoUsuario.Ticks > 0)
        //    {
        //        _tempoSessaoUsuario = _tempoSessaoUsuario.AddSeconds(-1);
        //        lblUsuario.Text = _tempoSessaoUsuario.ToString("HH:mm:ss");
        //    }
        //}
        private void HabilitaMenus(bool blnHabilita)
        {
            mnuLogin.Enabled = true;
            mnuAjuda.Enabled = true;
            mnuSaida.Enabled = true;
            mnuSobre.Enabled = true;
            mnuLog_In.Enabled = blnHabilita;
            mnuLog_Off.Enabled = !blnHabilita;
            mnuDigitacao.Enabled = !blnHabilita;
            mnuCadastro.Enabled = !blnHabilita;
            mnuRelatorios.Enabled = !blnHabilita;
            mnuFechamento.Enabled = !blnHabilita;
            mnuConfiguracoes.Enabled =!blnHabilita;
            mnuReembolso.Enabled = !blnHabilita;
        }
        private void mnuLotes_Click(object sender, EventArgs e)
        {
            frmLotes ofrmLotes = new frmLotes();
            AbrirForm(ofrmLotes);
        }
        private void AbrirForm(Form pForm)
        {
            bool blnExiste = false;

            foreach (Form filho in this.MdiChildren)
            {
                if (pForm.Name == filho.Name)
                {
                    blnExiste = true;
                    break;
                }
            }

            if (!blnExiste)
            {
                pForm.MdiParent = this;
                pForm.Show();
            }
        }
        private void mnuDigitacao_Click(object sender, EventArgs e)
        {
            frmDigitacao ofrmDigitacao = new frmDigitacao();
            AbrirForm(ofrmDigitacao);
        }
        private void mnuCriacaoLotes_Click(object sender, EventArgs e)
        {
            frmCriacaoLotes ofrmCriacaoLotes = new frmCriacaoLotes();
            AbrirForm(ofrmCriacaoLotes);
        }
        private void mnuServicos_Click(object sender, EventArgs e)
        {
            frmConfigurarServico ofrmConfiguracao = new frmConfigurarServico();
            AbrirForm(ofrmConfiguracao);
        }
        private void mnuUsuarios_Click(object sender, EventArgs e)
        {
            frmUsuario ofrmUsuario = new frmUsuario();
            AbrirForm(ofrmUsuario);
        }
        private void mnuLog_In_Click(object sender, EventArgs e)
        {
            try
            {
                frmLogin ofrmLogin = new frmLogin();
                ofrmLogin.ShowDialog();
                if (ofrmLogin.DialogResult == DialogResult.OK)
                {
                    dttLogin = DateTime.Now;
                    lblUsuario.Text += Funcoes.strNomeUsuario;
                    lblUsuario.Image = Properties.Resources.bullet_ball_glass_green;
                    timer1.Enabled = true;
                    //HabilitaMenus(false);
                    Funcoes.RegistrarLogin((int)Funcoes.StatusLogin.Login);
                    Usuario oUsuario = new Usuario();
                    oUsuario.intCodigo = Funcoes.intCodigoUsuario;
                    oUsuario.ConsultarPermissoes();

                    foreach (ToolStripMenuItem item in mnuPrincipal.Items)
                    {
                        foreach (Permissoes perm in oUsuario.Permissao)
                        {
                            if (perm.strMenu == item.Name)
                            {
                                item.Enabled = perm.blnStatus;
                            }
                            if (item.HasDropDownItems)
                            {
                                foreach (object dropItem in item.DropDownItems)
                                {
                                    if (dropItem is ToolStripDropDownItem)
                                    {
                                        ToolStripDropDownItem drop = dropItem as ToolStripDropDownItem;
                                        if (perm.strMenu == drop.Name)
                                        {
                                            drop.Enabled = perm.blnStatus;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    mnuLog_In.Enabled = false;
                    Funcoes.blnDesconectado = false;

                    //mnuDavita.Visible = false;
                    //mnuNFe.Visible = false;

                    //IniciarContadorInatividade();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            try
            {
                TimeSpan ts = DateTime.Now.Subtract(dttLogin);
                lblTempo.Text = "Tempo: " + ts.Hours.ToString("00") + ":" + ts.Minutes.ToString("00") + ":" + ts.Seconds.ToString("00");
                //Funcoes.intInatividade++;

                //if (Funcoes.intInatividade == Funcoes.intTotalInatividade)
                //{
                //    Funcoes.RegistrarLogin((int)Funcoes.StatusLogin.Inatividade);
                //    lblUsuario.Image = Properties.Resources.bullet_ball_glass_red;
                //    lblUsuario.Text = "Usuario: ";
                //    Funcoes.intCodigoUsuario = 0;
                //    Funcoes.strNomeUsuario = string.Empty;
                //    timer1.Enabled = false;
                //    HabilitaMenus(true);
                //    MessageBox.Show("Usuário desconectado por inatividade. Todos os formulários serão fechados.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    Funcoes.blnDesconectado = true;
                //    foreach (Form janela in this.MdiChildren)
                //    {
                //        janela.Close();
                //    }
                //}
                if (Funcoes.VerificaManutencao())
                {
                    frmManutencao form = new frmManutencao();
                    form.ShowDialog();
                    Funcoes.blnSair = true;
                    foreach (Form janela in this.MdiChildren)
                    {
                        janela.Close();
                    }
                    Funcoes.RegistrarLogin((int)Funcoes.StatusLogin.Logoff);
                    Funcoes.RegistrarSaida();                   
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void mnuLog_Off_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form janela in this.MdiChildren)
                {
                    MessageBox.Show("Feche todos os formulários para poder efetuar o LogOff", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("Confirma LogOff?", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    
                    Funcoes.RegistrarLogin((int)Funcoes.StatusLogin.Logoff);
                    lblUsuario.Image = Properties.Resources.bullet_ball_glass_red;
                    lblUsuario.Text = "Usuario: ";
                    Funcoes.intCodigoUsuario = 0;
                    Funcoes.strNomeUsuario = string.Empty;
                    HabilitaMenus(true);
                    timer1.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void mnuSaida_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Funcoes.blnSair)
            {
                if (MessageBox.Show("Deseja encerrar a aplicação?", "Sistema Integrado de Digitação Telecred",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    if (Funcoes.intCodigoUsuario != 0)
                    {
                        Funcoes.RegistrarLogin((int)Funcoes.StatusLogin.Logoff);
                    }
                    Funcoes.RegistrarSaida();
                }
            }
        }
        private void mnuImportacao_Click(object sender, EventArgs e)
        {
            frmImportacaoBases ofrmImportacaoBases = new frmImportacaoBases();
            AbrirForm(ofrmImportacaoBases);
        }
        private void mnuAssociacao_Click(object sender, EventArgs e)
        {
            frmAssociacaoCampos ofrmAssociacaoCampos = new frmAssociacaoCampos();
            AbrirForm(ofrmAssociacaoCampos);
        }
        private void mnuDigitalizacao_Click(object sender, EventArgs e)
        {
            frmImportarDigitalizados ofrmImportarDigitalizados = new frmImportarDigitalizados();
            AbrirForm(ofrmImportarDigitalizados);
        }
        private void mnuConfiguracoes_Click(object sender, EventArgs e)
        {
            frmConfigurarAplicacao ofrmConfigurarConexao = new frmConfigurarAplicacao();
            AbrirForm(ofrmConfigurarConexao);
        }

        private void mnuExportar_Click(object sender, EventArgs e)
        {
            frmExportacao ofrmExportacao = new frmExportacao();
            AbrirForm(ofrmExportacao);
        }

        private void mnuFechamentoLotes_Click(object sender, EventArgs e)
        {
            frmManutencaoLotes ofrmManutencaoLotes = new frmManutencaoLotes();
            AbrirForm(ofrmManutencaoLotes);
        }

        private void mnuRelatorios_Click(object sender, EventArgs e)
        {
            frmRelatorios ofrmRelatorios = new frmRelatorios();
            AbrirForm(ofrmRelatorios);
        }

        private void mnuSobre_Click(object sender, EventArgs e)
        {
            frmSobre ofrmSobre = new frmSobre();
            AbrirForm(ofrmSobre);
        }

        private void mnuCadastroCaixas_Click(object sender, EventArgs e)
        {
            frmCaixa ofrmCaixa = new frmCaixa();
            AbrirForm(ofrmCaixa);
        }

        private void mnuExportarCD_Click(object sender, EventArgs e)
        {
            frmExportacaoCD ofrmExportarCD = new frmExportacaoCD();
            AbrirForm(ofrmExportarCD);
        }

        private void mnuExpurgo_Click(object sender, EventArgs e)
        {
            frmExpurgo ofrmExpurgo = new frmExpurgo();
            AbrirForm(ofrmExpurgo);
        }

        private void mnuDigReembolso_Click(object sender, EventArgs e)
        {
            Servico oServico = new Servico();
            if (!oServico.ConsultarAssociacao())
            {
                MessageBox.Show("Nenhum serviço associado ao Reembolso.", "Reembolso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmReembolso ofrmReembolso = new frmReembolso();
            ofrmReembolso.Tag = oServico.intCodigo;
            AbrirForm(ofrmReembolso);
        }

        private void mnuAssociar_Click(object sender, EventArgs e)
        {
            frmAssociarServicoReembolso ofrmAssociarServicoReembolso = new frmAssociarServicoReembolso();
            AbrirForm(ofrmAssociarServicoReembolso);
        }

        private void mnuFecReembolso_Click(object sender, EventArgs e)
        {

        }

        private void mnuImportacaoPeg_Click(object sender, EventArgs e)
        {
            frmImportacaoPegs ofrmImportacaoPegs = new frmImportacaoPegs();
            AbrirForm(ofrmImportacaoPegs);
        }

        private void mnuPermissoes_Click(object sender, EventArgs e)
        {
            frmPermissaoPeg ofrmPermissaoPeg = new frmPermissaoPeg();
            AbrirForm(ofrmPermissaoPeg);
        }

        private void mnuEstatisticas_Click(object sender, EventArgs e)
        {
            frmEstatisticasPegPortal ofrmEstatisticasPegPortal = new frmEstatisticasPegPortal();
            AbrirForm(ofrmEstatisticasPegPortal);
        }

        private void mnuAlteracaoStatus_Click(object sender, EventArgs e)
        {
            frmAlteracaoStatusPeg ofrmAlteracaoStatusPeg = new frmAlteracaoStatusPeg();
            AbrirForm(ofrmAlteracaoStatusPeg);
        }

        private void mnuRespostasPEG_Click(object sender, EventArgs e)
        {
            frmRespostaPeg ofrmRespostaPeg = new frmRespostaPeg();
            AbrirForm(ofrmRespostaPeg);
        }

        private void mnuDistribuicaoPeg_Click(object sender, EventArgs e)
        {
            frmDistribuirPeg ofrmDistribuirPeg = new frmDistribuirPeg();
            AbrirForm(ofrmDistribuirPeg);
        }

        private void mnuMigracaoPeg_Click(object sender, EventArgs e)
        {
            frmMigracaoPegPortal ofrmMigracaoPegPortal = new frmMigracaoPegPortal();
            AbrirForm(ofrmMigracaoPegPortal);
        }

        private void mnuConsultaPeg_Click(object sender, EventArgs e)
        {
            frmConsultarPeg ofrmConsultarPeg = new frmConsultarPeg();
            AbrirForm(ofrmConsultarPeg);
        }

        private void MnuImportarPlanilha_Click(object sender, EventArgs e)
        {
            frmDavitaImportacao ofrmDavitaImportacao = new frmDavitaImportacao();
            AbrirForm(ofrmDavitaImportacao);
        }

        private void MnuVerificarNFe_Click(object sender, EventArgs e)
        {
            frmVerificacaoNFe ofrmVerificacaoNFe = new frmVerificacaoNFe();
            AbrirForm(ofrmVerificacaoNFe);
        }

        private void mnuEnvioListagem_Click(object sender, EventArgs e)
        {
            frmEnvioListagem ofrmEnvioListagem = new frmEnvioListagem();
            AbrirForm(ofrmEnvioListagem);
        }
    }
}
