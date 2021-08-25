using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace SID_Telecred
{
    public partial class frmLotes : Form
    {
        public frmLotes()
        {
            InitializeComponent();
        }

        bool blnLoad;
        Lote oLote = new Lote();
        private void frmLotes_Load(object sender, EventArgs e)
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

        private void cboServico_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (blnLoad)
            {
                PreencherLotes();
            }
        }

        private void PreencherLotes()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oLote.intCodigoCaixa = Convert.ToInt32(cboServico.SelectedValue);
                grdLotes.DataSource = oLote.ConsultarLote(false);
                grdLotes.Columns[0].Visible = false;
                grdLotes.Columns[1].Width = 100;
                grdLotes.Columns[2].Width = 50;
                grdLotes.Columns[3].Width = 150;
                grdLotes.Columns[4].Width = 250;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreencherImagens()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oLote.intCodigo = Convert.ToInt32(grdLotes.SelectedCells[0].Value);
                oLote.ConsultarImagens(false);
                foreach (Imagem imagem in oLote.Imagens)
                {
                    lstImagens.Items.Add(imagem.strNomeArquivo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            txtLote.Text = string.Empty;
            txtTotal.Text = string.Empty;
            lstImagens.Items.Clear();
            cboServico.SelectedIndex = -1;
        }

        private void grdLotes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdLotes.SelectedRows.Count > 0)
            {
                txtLote.Text = grdLotes.SelectedCells[1].Value.ToString();
                txtTotal.Text = grdLotes.SelectedCells[2].Value.ToString();
                PreencherImagens();
            }
        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            if (fbdImagens.ShowDialog() == DialogResult.OK)
            {
                string strCaminho = fbdImagens.SelectedPath;
                int intImagemNaoImportadas = 0;
                int intContador = 0;
                Cursor.Current = Cursors.WaitCursor;
                foreach (FileInfo arquivo in new DirectoryInfo(strCaminho).GetFiles("*.pdf"))
                {
                    intContador++;
                    txtTotal.Text = intContador.ToString();
                    Application.DoEvents();
                    string strNomeArquivo = arquivo.Name;
                    if (Funcoes.VerificarImagem(strNomeArquivo))
                    {
                        lstImagens.Items.Add(strNomeArquivo);
                    }
                    else
                    {
                        intImagemNaoImportadas++;
                    }
                }
                Cursor.Current = Cursors.Default;
                txtTotal.Text = lstImagens.Items.Count.ToString();
                MessageBox.Show("Imagens carregadas: " + txtTotal.Text + "\n" + "Imagens não carregadas: " + intImagemNaoImportadas.ToString(),
                    "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                if (lstImagens.Items.Count > 0)
                {
                    PreencherClasse();
                    oLote.GravarLote();
                    MessageBox.Show("Registro incluído com sucesso", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreencherClasse()
        {
            oLote.strLote = txtLote.Text;
            oLote.intTotal = Convert.ToInt32(txtTotal.Text);
            foreach (string imagem in lstImagens.Items)
            {
                Imagem oImagem = new Imagem();
                oImagem.strNomeArquivo = imagem;
                oLote.Imagens.Add(oImagem);
            }
        }

        private void txtLote_Leave(object sender, EventArgs e)
        {
            foreach (DataGridViewRow linha in grdLotes.Rows)
            {
                if (linha.Cells[0].ToString() == txtLote.Text)
                {
                    MessageBox.Show("Lote já existente", "Cadastro de Lotes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLote.Focus();
                    break;
                }
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }
    }
}

