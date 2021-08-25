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
    public partial class frmManutencao : Form
    {
        public frmManutencao()
        {
            InitializeComponent();
        }
        DateTime dtt;
        int segundos = 10;
        private void frmManutencao_Load(object sender, EventArgs e)
        {
            dtt = DateTime.Now.AddSeconds(10);
            string texto = "Acesso ao SID bloqueado por motivo de manutenção.\n";
            texto += "O acesso será liberado a partir de " + Funcoes.dttManutencao.ToShortDateString();
            texto += " as " + Funcoes.dttManutencao.ToShortTimeString();
            lblManutencao.Text = texto;
            lblTimer.Text = "Esta janela será fechada em 10 segundos";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            segundos--;
            lblTimer.Text = string.Format("Esta janela será fechada em {0} segundos", segundos);
            if (DateTime.Now > dtt)
                this.Close();
        }
    }
}
