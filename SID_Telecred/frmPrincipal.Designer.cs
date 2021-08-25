namespace SID_Telecred
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTempo = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.mnuPrincipal = new System.Windows.Forms.MenuStrip();
            this.mnuLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLog_In = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLog_Off = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDigitacao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCadastro = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCadastroCaixas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCriacaoLotes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDigitalizacao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuServicos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImportacao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAssociacao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFechamento = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuManutencaoLotes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExportar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExportarCD = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExpurgo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRelatorios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReembolso = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDigReembolso = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFecReembolso = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImportarSegurados = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAssociar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuImportacaoPeg = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEstatisticas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAlteracaoStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDistribuicaoPeg = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMigracaoPeg = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPermissoes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRespostasPEG = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConsultaPeg = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEnvioListagem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDavita = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImportarPlanilha = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNFe = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVerificarNFe = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaida = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAjuda = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSobre = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConfiguracoes = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.mnuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUsuario,
            this.lblTempo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 665);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(916, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Image = global::SID_Telecred.Properties.Resources.bullet_ball_glass_red;
            this.lblUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(852, 17);
            this.lblUsuario.Spring = true;
            this.lblUsuario.Text = "Usuário: ";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblTempo
            // 
            this.lblTempo.Name = "lblTempo";
            this.lblTempo.Size = new System.Drawing.Size(49, 17);
            this.lblTempo.Text = "00:00:00";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // mnuPrincipal
            // 
            this.mnuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLogin,
            this.mnuDigitacao,
            this.mnuCadastro,
            this.mnuFechamento,
            this.mnuRelatorios,
            this.mnuReembolso,
            this.mnuDavita,
            this.mnuNFe,
            this.mnuSaida,
            this.mnuAjuda});
            this.mnuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnuPrincipal.Name = "mnuPrincipal";
            this.mnuPrincipal.Size = new System.Drawing.Size(916, 24);
            this.mnuPrincipal.TabIndex = 2;
            this.mnuPrincipal.Text = "menuStrip1";
            // 
            // mnuLogin
            // 
            this.mnuLogin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLog_In,
            this.mnuLog_Off});
            this.mnuLogin.Image = global::SID_Telecred.Properties.Resources.businessman;
            this.mnuLogin.Name = "mnuLogin";
            this.mnuLogin.Size = new System.Drawing.Size(65, 20);
            this.mnuLogin.Tag = "1|0|1";
            this.mnuLogin.Text = "&Login";
            // 
            // mnuLog_In
            // 
            this.mnuLog_In.Image = global::SID_Telecred.Properties.Resources.bullet_ball_glass_green;
            this.mnuLog_In.Name = "mnuLog_In";
            this.mnuLog_In.Size = new System.Drawing.Size(109, 22);
            this.mnuLog_In.Tag = "1|1|1";
            this.mnuLog_In.Text = "Log&in";
            this.mnuLog_In.Click += new System.EventHandler(this.mnuLog_In_Click);
            // 
            // mnuLog_Off
            // 
            this.mnuLog_Off.Image = global::SID_Telecred.Properties.Resources.bullet_ball_glass_red;
            this.mnuLog_Off.Name = "mnuLog_Off";
            this.mnuLog_Off.Size = new System.Drawing.Size(109, 22);
            this.mnuLog_Off.Tag = "1|2|1";
            this.mnuLog_Off.Text = "Log&off";
            this.mnuLog_Off.Click += new System.EventHandler(this.mnuLog_Off_Click);
            // 
            // mnuDigitacao
            // 
            this.mnuDigitacao.Image = global::SID_Telecred.Properties.Resources.ktouch;
            this.mnuDigitacao.Name = "mnuDigitacao";
            this.mnuDigitacao.Size = new System.Drawing.Size(85, 20);
            this.mnuDigitacao.Tag = "2|0|0";
            this.mnuDigitacao.Text = "&Digitação";
            this.mnuDigitacao.Click += new System.EventHandler(this.mnuDigitacao_Click);
            // 
            // mnuCadastro
            // 
            this.mnuCadastro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCadastroCaixas,
            this.mnuCriacaoLotes,
            this.mnuDigitalizacao,
            this.mnuServicos,
            this.mnuUsuarios,
            this.mnuImportacao,
            this.mnuAssociacao});
            this.mnuCadastro.Image = global::SID_Telecred.Properties.Resources.notebook_edit;
            this.mnuCadastro.Name = "mnuCadastro";
            this.mnuCadastro.Size = new System.Drawing.Size(82, 20);
            this.mnuCadastro.Tag = "3|0|0";
            this.mnuCadastro.Text = "&Cadastro";
            // 
            // mnuCadastroCaixas
            // 
            this.mnuCadastroCaixas.Image = global::SID_Telecred.Properties.Resources.Metapackage;
            this.mnuCadastroCaixas.Name = "mnuCadastroCaixas";
            this.mnuCadastroCaixas.Size = new System.Drawing.Size(205, 22);
            this.mnuCadastroCaixas.Tag = "3|1|0";
            this.mnuCadastroCaixas.Text = "Cadastro Caixas";
            this.mnuCadastroCaixas.Click += new System.EventHandler(this.mnuCadastroCaixas_Click);
            // 
            // mnuCriacaoLotes
            // 
            this.mnuCriacaoLotes.Image = global::SID_Telecred.Properties.Resources.Folder;
            this.mnuCriacaoLotes.Name = "mnuCriacaoLotes";
            this.mnuCriacaoLotes.Size = new System.Drawing.Size(205, 22);
            this.mnuCriacaoLotes.Tag = "3|2|0";
            this.mnuCriacaoLotes.Text = "Criação  &Lotes e Imagens";
            this.mnuCriacaoLotes.Click += new System.EventHandler(this.mnuCriacaoLotes_Click);
            // 
            // mnuDigitalizacao
            // 
            this.mnuDigitalizacao.Image = global::SID_Telecred.Properties.Resources.printer3;
            this.mnuDigitalizacao.Name = "mnuDigitalizacao";
            this.mnuDigitalizacao.Size = new System.Drawing.Size(205, 22);
            this.mnuDigitalizacao.Tag = "3|3|0";
            this.mnuDigitalizacao.Text = "Importar &Digitalizadas";
            this.mnuDigitalizacao.Click += new System.EventHandler(this.mnuDigitalizacao_Click);
            // 
            // mnuServicos
            // 
            this.mnuServicos.Image = global::SID_Telecred.Properties.Resources.note_new;
            this.mnuServicos.Name = "mnuServicos";
            this.mnuServicos.Size = new System.Drawing.Size(205, 22);
            this.mnuServicos.Tag = "3|4|0";
            this.mnuServicos.Text = "&Serviços";
            this.mnuServicos.Click += new System.EventHandler(this.mnuServicos_Click);
            // 
            // mnuUsuarios
            // 
            this.mnuUsuarios.Image = global::SID_Telecred.Properties.Resources.businesspeople2;
            this.mnuUsuarios.Name = "mnuUsuarios";
            this.mnuUsuarios.Size = new System.Drawing.Size(205, 22);
            this.mnuUsuarios.Tag = "3|5|0";
            this.mnuUsuarios.Text = "&Usuários";
            this.mnuUsuarios.Click += new System.EventHandler(this.mnuUsuarios_Click);
            // 
            // mnuImportacao
            // 
            this.mnuImportacao.Image = global::SID_Telecred.Properties.Resources.data_new;
            this.mnuImportacao.Name = "mnuImportacao";
            this.mnuImportacao.Size = new System.Drawing.Size(205, 22);
            this.mnuImportacao.Tag = "3|6|0";
            this.mnuImportacao.Text = "&Importação de Bases";
            this.mnuImportacao.Click += new System.EventHandler(this.mnuImportacao_Click);
            // 
            // mnuAssociacao
            // 
            this.mnuAssociacao.Image = global::SID_Telecred.Properties.Resources.FormCheck;
            this.mnuAssociacao.Name = "mnuAssociacao";
            this.mnuAssociacao.Size = new System.Drawing.Size(205, 22);
            this.mnuAssociacao.Tag = "3|7|0";
            this.mnuAssociacao.Text = "&Associação de Campos";
            this.mnuAssociacao.Click += new System.EventHandler(this.mnuAssociacao_Click);
            // 
            // mnuFechamento
            // 
            this.mnuFechamento.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuManutencaoLotes,
            this.mnuExportar,
            this.mnuExportarCD,
            this.mnuExpurgo});
            this.mnuFechamento.Image = global::SID_Telecred.Properties.Resources.stop;
            this.mnuFechamento.Name = "mnuFechamento";
            this.mnuFechamento.Size = new System.Drawing.Size(101, 20);
            this.mnuFechamento.Tag = "4|0|0";
            this.mnuFechamento.Text = "&Fechamento";
            // 
            // mnuManutencaoLotes
            // 
            this.mnuManutencaoLotes.Image = global::SID_Telecred.Properties.Resources.LightBrowBoxOk;
            this.mnuManutencaoLotes.Name = "mnuManutencaoLotes";
            this.mnuManutencaoLotes.Size = new System.Drawing.Size(180, 22);
            this.mnuManutencaoLotes.Tag = "4|1|0";
            this.mnuManutencaoLotes.Text = "&Manutenção Lotes";
            this.mnuManutencaoLotes.Click += new System.EventHandler(this.mnuFechamentoLotes_Click);
            // 
            // mnuExportar
            // 
            this.mnuExportar.Image = global::SID_Telecred.Properties.Resources.DocumentOut;
            this.mnuExportar.Name = "mnuExportar";
            this.mnuExportar.Size = new System.Drawing.Size(180, 22);
            this.mnuExportar.Tag = "4|2|0";
            this.mnuExportar.Text = "&Exportar Digitados";
            this.mnuExportar.Click += new System.EventHandler(this.mnuExportar_Click);
            // 
            // mnuExportarCD
            // 
            this.mnuExportarCD.Image = global::SID_Telecred.Properties.Resources.cd_into;
            this.mnuExportarCD.Name = "mnuExportarCD";
            this.mnuExportarCD.Size = new System.Drawing.Size(180, 22);
            this.mnuExportarCD.Tag = "4|3|0";
            this.mnuExportarCD.Text = "E&xportar CD";
            this.mnuExportarCD.Click += new System.EventHandler(this.mnuExportarCD_Click);
            // 
            // mnuExpurgo
            // 
            this.mnuExpurgo.Image = global::SID_Telecred.Properties.Resources.garbage_make_empty;
            this.mnuExpurgo.Name = "mnuExpurgo";
            this.mnuExpurgo.Size = new System.Drawing.Size(180, 22);
            this.mnuExpurgo.Tag = "4|4|0";
            this.mnuExpurgo.Text = "Expurg&o";
            this.mnuExpurgo.Click += new System.EventHandler(this.mnuExpurgo_Click);
            // 
            // mnuRelatorios
            // 
            this.mnuRelatorios.Image = global::SID_Telecred.Properties.Resources.Graphics;
            this.mnuRelatorios.Name = "mnuRelatorios";
            this.mnuRelatorios.Size = new System.Drawing.Size(87, 20);
            this.mnuRelatorios.Tag = "5|0|0";
            this.mnuRelatorios.Text = "&Relatórios";
            this.mnuRelatorios.Click += new System.EventHandler(this.mnuRelatorios_Click);
            // 
            // mnuReembolso
            // 
            this.mnuReembolso.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDigReembolso,
            this.mnuFecReembolso,
            this.mnuImportarSegurados,
            this.mnuAssociar,
            this.toolStripSeparator1,
            this.mnuImportacaoPeg,
            this.mnuEstatisticas,
            this.mnuAlteracaoStatus,
            this.mnuDistribuicaoPeg,
            this.mnuMigracaoPeg,
            this.mnuPermissoes,
            this.mnuRespostasPEG,
            this.mnuConsultaPeg,
            this.mnuEnvioListagem});
            this.mnuReembolso.Image = global::SID_Telecred.Properties.Resources.money_check;
            this.mnuReembolso.Name = "mnuReembolso";
            this.mnuReembolso.Size = new System.Drawing.Size(94, 20);
            this.mnuReembolso.Tag = "8|0|0";
            this.mnuReembolso.Text = "Reembol&so";
            // 
            // mnuDigReembolso
            // 
            this.mnuDigReembolso.Image = global::SID_Telecred.Properties.Resources.ktouch;
            this.mnuDigReembolso.Name = "mnuDigReembolso";
            this.mnuDigReembolso.Size = new System.Drawing.Size(180, 22);
            this.mnuDigReembolso.Tag = "8|1|0";
            this.mnuDigReembolso.Text = "&Digitação";
            this.mnuDigReembolso.Visible = false;
            this.mnuDigReembolso.Click += new System.EventHandler(this.mnuDigReembolso_Click);
            // 
            // mnuFecReembolso
            // 
            this.mnuFecReembolso.Image = global::SID_Telecred.Properties.Resources.stop;
            this.mnuFecReembolso.Name = "mnuFecReembolso";
            this.mnuFecReembolso.Size = new System.Drawing.Size(180, 22);
            this.mnuFecReembolso.Tag = "8|2|0";
            this.mnuFecReembolso.Text = "&Fechamento";
            this.mnuFecReembolso.Visible = false;
            this.mnuFecReembolso.Click += new System.EventHandler(this.mnuFecReembolso_Click);
            // 
            // mnuImportarSegurados
            // 
            this.mnuImportarSegurados.Image = global::SID_Telecred.Properties.Resources.UserPreferences;
            this.mnuImportarSegurados.Name = "mnuImportarSegurados";
            this.mnuImportarSegurados.Size = new System.Drawing.Size(180, 22);
            this.mnuImportarSegurados.Tag = "8|3|0";
            this.mnuImportarSegurados.Text = "&Importar Segurados";
            this.mnuImportarSegurados.Visible = false;
            // 
            // mnuAssociar
            // 
            this.mnuAssociar.Image = global::SID_Telecred.Properties.Resources.checkbox;
            this.mnuAssociar.Name = "mnuAssociar";
            this.mnuAssociar.Size = new System.Drawing.Size(180, 22);
            this.mnuAssociar.Tag = "8|4|0";
            this.mnuAssociar.Text = "&Associar Serviço";
            this.mnuAssociar.Visible = false;
            this.mnuAssociar.Click += new System.EventHandler(this.mnuAssociar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // mnuImportacaoPeg
            // 
            this.mnuImportacaoPeg.Image = global::SID_Telecred.Properties.Resources.table_replace;
            this.mnuImportacaoPeg.Name = "mnuImportacaoPeg";
            this.mnuImportacaoPeg.Size = new System.Drawing.Size(180, 22);
            this.mnuImportacaoPeg.Tag = "8|5|0";
            this.mnuImportacaoPeg.Text = "Importação Planilha";
            this.mnuImportacaoPeg.Click += new System.EventHandler(this.mnuImportacaoPeg_Click);
            // 
            // mnuEstatisticas
            // 
            this.mnuEstatisticas.Image = global::SID_Telecred.Properties.Resources.chart_gantt;
            this.mnuEstatisticas.Name = "mnuEstatisticas";
            this.mnuEstatisticas.Size = new System.Drawing.Size(180, 22);
            this.mnuEstatisticas.Tag = "8|6|0";
            this.mnuEstatisticas.Text = "Estatísticas";
            this.mnuEstatisticas.Click += new System.EventHandler(this.mnuEstatisticas_Click);
            // 
            // mnuAlteracaoStatus
            // 
            this.mnuAlteracaoStatus.Image = global::SID_Telecred.Properties.Resources.table2_warning;
            this.mnuAlteracaoStatus.Name = "mnuAlteracaoStatus";
            this.mnuAlteracaoStatus.Size = new System.Drawing.Size(180, 22);
            this.mnuAlteracaoStatus.Tag = "8|7|0";
            this.mnuAlteracaoStatus.Text = "Alteração Status";
            this.mnuAlteracaoStatus.Click += new System.EventHandler(this.mnuAlteracaoStatus_Click);
            // 
            // mnuDistribuicaoPeg
            // 
            this.mnuDistribuicaoPeg.Image = global::SID_Telecred.Properties.Resources.preferences;
            this.mnuDistribuicaoPeg.Name = "mnuDistribuicaoPeg";
            this.mnuDistribuicaoPeg.Size = new System.Drawing.Size(180, 22);
            this.mnuDistribuicaoPeg.Tag = "8|8|0";
            this.mnuDistribuicaoPeg.Text = "Distribuição PEG";
            this.mnuDistribuicaoPeg.Click += new System.EventHandler(this.mnuDistribuicaoPeg_Click);
            // 
            // mnuMigracaoPeg
            // 
            this.mnuMigracaoPeg.Image = global::SID_Telecred.Properties.Resources.cd_into;
            this.mnuMigracaoPeg.Name = "mnuMigracaoPeg";
            this.mnuMigracaoPeg.Size = new System.Drawing.Size(180, 22);
            this.mnuMigracaoPeg.Tag = "8|9|0";
            this.mnuMigracaoPeg.Text = "Migração";
            this.mnuMigracaoPeg.Click += new System.EventHandler(this.mnuMigracaoPeg_Click);
            // 
            // mnuPermissoes
            // 
            this.mnuPermissoes.Image = global::SID_Telecred.Properties.Resources.businesspeople2;
            this.mnuPermissoes.Name = "mnuPermissoes";
            this.mnuPermissoes.Size = new System.Drawing.Size(180, 22);
            this.mnuPermissoes.Tag = "8|10|0";
            this.mnuPermissoes.Text = "Permissões";
            this.mnuPermissoes.Click += new System.EventHandler(this.mnuPermissoes_Click);
            // 
            // mnuRespostasPEG
            // 
            this.mnuRespostasPEG.Image = global::SID_Telecred.Properties.Resources.note_new;
            this.mnuRespostasPEG.Name = "mnuRespostasPEG";
            this.mnuRespostasPEG.Size = new System.Drawing.Size(180, 22);
            this.mnuRespostasPEG.Tag = "8|11|0";
            this.mnuRespostasPEG.Text = "Respostas PEG";
            this.mnuRespostasPEG.Click += new System.EventHandler(this.mnuRespostasPEG_Click);
            // 
            // mnuConsultaPeg
            // 
            this.mnuConsultaPeg.Image = global::SID_Telecred.Properties.Resources.selection_view;
            this.mnuConsultaPeg.Name = "mnuConsultaPeg";
            this.mnuConsultaPeg.Size = new System.Drawing.Size(180, 22);
            this.mnuConsultaPeg.Tag = "8|12|0";
            this.mnuConsultaPeg.Text = "Consulta PEGs";
            this.mnuConsultaPeg.Click += new System.EventHandler(this.mnuConsultaPeg_Click);
            // 
            // mnuEnvioListagem
            // 
            this.mnuEnvioListagem.Image = global::SID_Telecred.Properties.Resources.NewJob;
            this.mnuEnvioListagem.Name = "mnuEnvioListagem";
            this.mnuEnvioListagem.Size = new System.Drawing.Size(180, 22);
            this.mnuEnvioListagem.Tag = "8|13|0";
            this.mnuEnvioListagem.Text = "Envio Listagem";
            this.mnuEnvioListagem.Click += new System.EventHandler(this.mnuEnvioListagem_Click);
            // 
            // mnuDavita
            // 
            this.mnuDavita.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuImportarPlanilha});
            this.mnuDavita.Image = global::SID_Telecred.Properties.Resources.Davita;
            this.mnuDavita.Name = "mnuDavita";
            this.mnuDavita.Size = new System.Drawing.Size(68, 20);
            this.mnuDavita.Tag = "9|0|0";
            this.mnuDavita.Text = "Da&vita";
            this.mnuDavita.Visible = false;
            // 
            // mnuImportarPlanilha
            // 
            this.mnuImportarPlanilha.Image = global::SID_Telecred.Properties.Resources.Excel;
            this.mnuImportarPlanilha.Name = "mnuImportarPlanilha";
            this.mnuImportarPlanilha.Size = new System.Drawing.Size(165, 22);
            this.mnuImportarPlanilha.Tag = "9|1|0";
            this.mnuImportarPlanilha.Text = "&Importar Planilha";
            this.mnuImportarPlanilha.Click += new System.EventHandler(this.MnuImportarPlanilha_Click);
            // 
            // mnuNFe
            // 
            this.mnuNFe.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuVerificarNFe});
            this.mnuNFe.Image = global::SID_Telecred.Properties.Resources.icons8_nota_fiscal_electrónica_48;
            this.mnuNFe.Name = "mnuNFe";
            this.mnuNFe.Size = new System.Drawing.Size(56, 20);
            this.mnuNFe.Tag = "10|0|0";
            this.mnuNFe.Text = "NFe";
            this.mnuNFe.Visible = false;
            // 
            // mnuVerificarNFe
            // 
            this.mnuVerificarNFe.Image = global::SID_Telecred.Properties.Resources.checkbox;
            this.mnuVerificarNFe.Name = "mnuVerificarNFe";
            this.mnuVerificarNFe.Size = new System.Drawing.Size(180, 22);
            this.mnuVerificarNFe.Tag = "9|1|0";
            this.mnuVerificarNFe.Text = "Verificar NFe";
            this.mnuVerificarNFe.Click += new System.EventHandler(this.MnuVerificarNFe_Click);
            // 
            // mnuSaida
            // 
            this.mnuSaida.Image = global::SID_Telecred.Properties.Resources.door2_open;
            this.mnuSaida.Name = "mnuSaida";
            this.mnuSaida.Size = new System.Drawing.Size(63, 20);
            this.mnuSaida.Tag = "6|0|1";
            this.mnuSaida.Text = "&Saída";
            this.mnuSaida.Click += new System.EventHandler(this.mnuSaida_Click);
            // 
            // mnuAjuda
            // 
            this.mnuAjuda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSobre,
            this.mnuConfiguracoes});
            this.mnuAjuda.Image = global::SID_Telecred.Properties.Resources.help2;
            this.mnuAjuda.Name = "mnuAjuda";
            this.mnuAjuda.Size = new System.Drawing.Size(66, 20);
            this.mnuAjuda.Tag = "7|0|1";
            this.mnuAjuda.Text = "&Ajuda";
            // 
            // mnuSobre
            // 
            this.mnuSobre.Image = global::SID_Telecred.Properties.Resources.about;
            this.mnuSobre.Name = "mnuSobre";
            this.mnuSobre.Size = new System.Drawing.Size(151, 22);
            this.mnuSobre.Tag = "7|1|1";
            this.mnuSobre.Text = "&Sobre";
            this.mnuSobre.Click += new System.EventHandler(this.mnuSobre_Click);
            // 
            // mnuConfiguracoes
            // 
            this.mnuConfiguracoes.Image = global::SID_Telecred.Properties.Resources.Gear;
            this.mnuConfiguracoes.Name = "mnuConfiguracoes";
            this.mnuConfiguracoes.Size = new System.Drawing.Size(151, 22);
            this.mnuConfiguracoes.Tag = "7|2|0";
            this.mnuConfiguracoes.Text = "&Configurações";
            this.mnuConfiguracoes.Click += new System.EventHandler(this.mnuConfiguracoes_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 687);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mnuPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuPrincipal;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrincipal";
            this.Text = "Sistema Integrado de Digitação - Telecred";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.mnuPrincipal.ResumeLayout(false);
            this.mnuPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripStatusLabel lblUsuario;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel lblTempo;
        private System.Windows.Forms.MenuStrip mnuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem mnuLogin;
        private System.Windows.Forms.ToolStripMenuItem mnuLog_In;
        private System.Windows.Forms.ToolStripMenuItem mnuLog_Off;
        private System.Windows.Forms.ToolStripMenuItem mnuCadastro;
        private System.Windows.Forms.ToolStripMenuItem mnuServicos;
        private System.Windows.Forms.ToolStripMenuItem mnuUsuarios;
        private System.Windows.Forms.ToolStripMenuItem mnuRelatorios;
        private System.Windows.Forms.ToolStripMenuItem mnuSaida;
        private System.Windows.Forms.ToolStripMenuItem mnuAjuda;
        private System.Windows.Forms.ToolStripMenuItem mnuSobre;
        public System.Windows.Forms.ToolStripMenuItem mnuDigitacao;
        private System.Windows.Forms.ToolStripMenuItem mnuCriacaoLotes;
        private System.Windows.Forms.ToolStripMenuItem mnuDigitalizacao;
        private System.Windows.Forms.ToolStripMenuItem mnuImportacao;
        private System.Windows.Forms.ToolStripMenuItem mnuAssociacao;
        private System.Windows.Forms.ToolStripMenuItem mnuFechamento;
        public System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuConfiguracoes;
        private System.Windows.Forms.ToolStripMenuItem mnuExportar;
        private System.Windows.Forms.ToolStripMenuItem mnuManutencaoLotes;
        private System.Windows.Forms.ToolStripMenuItem mnuCadastroCaixas;
        private System.Windows.Forms.ToolStripMenuItem mnuExportarCD;
        private System.Windows.Forms.ToolStripMenuItem mnuExpurgo;
        private System.Windows.Forms.ToolStripMenuItem mnuReembolso;
        private System.Windows.Forms.ToolStripMenuItem mnuDigReembolso;
        private System.Windows.Forms.ToolStripMenuItem mnuFecReembolso;
        private System.Windows.Forms.ToolStripMenuItem mnuImportarSegurados;
        private System.Windows.Forms.ToolStripMenuItem mnuAssociar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuImportacaoPeg;
        private System.Windows.Forms.ToolStripMenuItem mnuEstatisticas;
        private System.Windows.Forms.ToolStripMenuItem mnuAlteracaoStatus;
        private System.Windows.Forms.ToolStripMenuItem mnuDistribuicaoPeg;
        private System.Windows.Forms.ToolStripMenuItem mnuMigracaoPeg;
        private System.Windows.Forms.ToolStripMenuItem mnuPermissoes;
        private System.Windows.Forms.ToolStripMenuItem mnuRespostasPEG;
        private System.Windows.Forms.ToolStripMenuItem mnuConsultaPeg;
        private System.Windows.Forms.ToolStripMenuItem mnuDavita;
        private System.Windows.Forms.ToolStripMenuItem mnuImportarPlanilha;
        private System.Windows.Forms.ToolStripMenuItem mnuNFe;
        private System.Windows.Forms.ToolStripMenuItem mnuVerificarNFe;
        private System.Windows.Forms.ToolStripMenuItem mnuEnvioListagem;
    }
}