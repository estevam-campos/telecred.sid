using System;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data;

namespace SID_Telecred
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                bool blnStart = false;
                bool blnErro = false;
                bool blnFirst = false;
                Funcoes.CarregarAppConfig();
                //Funcoes.strStringConnexao = "Data Source=";
                //Funcoes.strStringConnexao += ConfigurationManager.AppSettings["Servidor"] + ";Initial Catalog=" + ConfigurationManager.AppSettings["Banco"] + ";";
                //Funcoes.strStringConnexao += "Uid=" + Funcoes.Decrypt(ConfigurationManager.AppSettings["Usuario"], true) + ";Pwd=";
                //Funcoes.strStringConnexao += Funcoes.Decrypt(ConfigurationManager.AppSettings["Senha"], true) + ";";
                //Funcoes.strCaminhoImagens = ConfigurationManager.AppSettings["CaminhoImagens"];
                //Funcoes.intTotalInatividade = Convert.ToInt32(ConfigurationManager.AppSettings["Inatividade"])*60;
                //Funcoes.intDocumentosCaixa = Convert.ToInt32(ConfigurationManager.AppSettings["DocumentosCaixa"]);
                string strMensagem = string.Empty;
                do
                {
                    string strChave = Funcoes.CarregarChave(string.Empty);

                    if (strChave == string.Empty || blnStart)
                    {
                        blnFirst = true;
                        if (blnErro)
                        {
                            strMensagem = "Chave de registro inválida.";
                        }
                        else
                        {
                            strMensagem = "Não foi localizada a chave de registro para a aplicação.";
                            if (blnStart)
                            {
                                strMensagem = "Período de testes encerrado.";
                            }
                        }
                        strMensagem += "\nDeseja incluir uma chave de registro válida?";
                        if (MessageBox.Show(strMensagem, "Sistema Integrado de Digitação Telecred",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            frmChaveRegistro ofrmChaveRegistro = new frmChaveRegistro();
                            ofrmChaveRegistro.ShowDialog();
                            strChave = ofrmChaveRegistro.Tag.ToString();
                            if (Funcoes.CarregarChave(strChave) != string.Empty)
                            {
                                blnErro = true;
                            }
                        }
                        else
                        {
                            blnStart = false;
                            break;
                        }
                    }
                    try
                    {
                        if (!blnErro)
                        {
                            Funcoes.strCliente = string.Empty;
                            string[] strRegistro = Funcoes.Decrypt(strChave, true).Split('|');
                            Funcoes.dttDataInstalacao = DateTime.Now;
                            Funcoes.dttData = DateTime.Now;
                            Funcoes.strCliente = strRegistro[0];
                            Funcoes.intDias = Convert.ToInt32(strRegistro[1]);
                            Funcoes.blnRegistrado = Convert.ToBoolean(strRegistro[2]);
                            Funcoes.intTotalDias = 1;
                            //if (blnFirst)
                            //{
                            //    Funcoes.GravarChave(strChave);
                            //}
                            //Funcoes.CarregarRegistro();

                            //if (DateTime.Now.ToShortDateString() != Funcoes.dttData.ToShortDateString())
                            //{
                            //    Funcoes.intTotalDias = DateTime.Now > Funcoes.dttData ? Funcoes.intTotalDias + Convert.ToInt32(Convert.ToDateTime(DateTime.Now.ToShortDateString()).Subtract(Funcoes.dttData).TotalDays) : Funcoes.intTotalDias++;
                            //    Funcoes.dttData = DateTime.Now;
                            //}
                            blnStart = true;
                            break;
                            //Funcoes.GravarRegistro();
                            //if (Funcoes.intTotalDias <= Funcoes.intDias || Funcoes.blnRegistrado)
                            //{
                            //    blnStart = true;
                            //    break;
                            //}
                        }
                    }
                    catch
                    {
                        strChave = string.Empty;
                        blnErro = true;
                    }

                }
                while (true);

                if (blnStart)
                {
                    if (Funcoes.VerificaManutencao())
                    {
                        Application.Run(new frmManutencao());
                    }
                    else
                    {
                        Funcoes.RegistrarEntrada();
                        Application.AddMessageFilter(new MessageFilter());
                        Application.Run(new frmPrincipal());
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
