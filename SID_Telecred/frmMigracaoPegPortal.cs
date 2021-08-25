using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SID_Telecred
{
    public partial class frmMigracaoPegPortal : Form
    {
        public frmMigracaoPegPortal()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CarregarPegs()
        {
            try
            {
                grdPegs.DataSource = Funcoes.CarregarPegsMigracao(dtpInicio.Value, dtpFim.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro--> " + ex.Message,
                    "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void frmMigracaoPegPortal_Load(object sender, EventArgs e)
        {
            CarregarPegs();
        }

        private void dtpInicio_ValueChanged(object sender, EventArgs e)
        {
            //CarregarPegs();
        }

        private void dtpFim_ValueChanged(object sender, EventArgs e)
        {
            //CarregarPegs();
        }

        private void btnMigrar_Click(object sender, EventArgs e)
        {
            if (grdPegs.SelectedRows.Count == 0)
            {
                return;
            }


            if (MessageBox.Show(string.Format("Confirma a migração do dia {0}?",
                grdPegs.SelectedRows[0].Cells[0].Value.ToString()),
                "Sistema Integrado de Digitação Telecred",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }
            try
            {
                ArquivoPeg arquivoPeg = new ArquivoPeg();
                arquivoPeg.dttDataMigracao = Convert.ToDateTime(grdPegs.SelectedRows[0].Cells[0].Value);
                arquivoPeg.strArquivo = string.Format("{0}_{1}.csv", arquivoPeg.dttDataMigracao.ToString("ddMMyyyy"), DateTime.Now.ToString("ddMMyyyyHHmm"));
                arquivoPeg.strTratativa = string.Format("Tratativa_{0}_{1}.csv", arquivoPeg.dttDataMigracao.ToString("ddMMyyyy"), DateTime.Now.ToString("ddMMyyyyHHmm"));
                arquivoPeg.dttInicioMigracao = DateTime.Now;

                sfdArquivo.FileName = arquivoPeg.strArquivo;
                if (sfdArquivo.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                txtArquivo.Text = sfdArquivo.FileName;
                arquivoPeg.strArquivo = sfdArquivo.FileName;
                arquivoPeg.strTratativa = arquivoPeg.strArquivo.Replace(Path.GetFileName(arquivoPeg.strArquivo), "Tratativa_" + Path.GetFileName(arquivoPeg.strArquivo));
                txtTratativa.Text = arquivoPeg.strTratativa;


                lblAndamento.Text = "Selecionando registros...";


                DataTable dt = new DataTable();
                dt = arquivoPeg.SelecionarPegs();

                pgbProgress.Maximum = dt.Rows.Count;
                pgbProgress.Value = 0;

                arquivoPeg.registros.Clear();

                foreach (DataRow linha in dt.Rows)
                {
                    pgbProgress.Value++;
                    lblAndamento.Text = string.Format("Processando registro {0} de {1}", pgbProgress.Value, pgbProgress.Maximum);
                    Application.DoEvents();


                    RegistroPeg registro = new RegistroPeg();
                    registro.intPeg = Convert.ToInt32(linha[0]);
                    registro.ConsultaPeg();

                    if (registro.intStatus == 3)
                    {
                        arquivoPeg.registros.Add(registro);
                    }
                    else
                    {
                        arquivoPeg.tratativas.Add(registro);
                    }

                    if (registro.intTipoPeg == 1)
                    {
                        arquivoPeg.intConsulta++;
                    }
                    else if (registro.intTipoPeg == 2)
                    {
                        arquivoPeg.intSADT++;
                    }
                    else if (registro.intTipoPeg == 3)
                    {
                        arquivoPeg.intHospital++;
                    }
                    else if (registro.intTipoPeg == 4)
                    {
                        arquivoPeg.intDiamante++;
                    }
                }

                lblAndamento.Text = string.Format("Gravando arquivos {0} / {1}", Path.GetFileName(arquivoPeg.strArquivo), Path.GetFileName(arquivoPeg.strTratativa));
                arquivoPeg.Migrar();

                MessageBox.Show("Migração efetuada com sucesso", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                pgbProgress.Value = 0;
                lblAndamento.Text = "";
                txtArquivo.Text = "";

                CarregarPegs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro--> " + ex.Message,
                    "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            CarregarPegs();
        }
    }
}
