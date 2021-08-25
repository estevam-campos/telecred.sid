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
    public partial class frmAssociarServicoReembolso : Form
    {
        public frmAssociarServicoReembolso()
        {
            InitializeComponent();
        }

        private void frmAssociarServicoReembolso_Load(object sender, EventArgs e)
        {
            PreencherServico();
        }
        private void PreencherServico()
        {
            cboServico.DataSource = Funcoes.CarregarServico();
            cboServico.DisplayMember = "SER_DESCRICAO";
            cboServico.ValueMember = "SER_CODIGO";
            cboServico.SelectedIndex = -1;
        }

        private void btnAssociar_Click(object sender, EventArgs e)
        {
            if (cboServico.SelectedIndex==-1)
            {
                MessageBox.Show("Selecione o serviço.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Servico oServico = new Servico();
            oServico.intCodigo = Convert.ToInt32(cboServico.SelectedValue);
            oServico.AssociarServico();
            MessageBox.Show("Serviço associado com sucesso.", "Sistema Integrado de Digitação Telecred", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cboServico.SelectedIndex = -1;
        }
    }
}
