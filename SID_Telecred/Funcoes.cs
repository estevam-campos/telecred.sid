using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;
using System.Net;
using System.Net.Sockets;

namespace SID_Telecred
{
    public static class Funcoes
    {
        public static int intCodigoUsuario;
        public static string strNomeUsuario;
        public static string strStringConnexao;
        public static string strCaminhoImagens;
        public static int intInatividade;
        public static int intTotalInatividade;
        public static int intDocumentosCaixa;
        public static int intTotalRegistros = 0;
        public static int intDias = 0;
        public static int intValidade = 0;
        public static bool blnRegistrado = false;
        public static string strSecurityKey = string.Empty;
        public static DateTime dttDataInstalacao;
        public static int intTotalDias;
        public static DateTime dttData;
        public static string strCliente = string.Empty;
        public static List<string> strMenuItens = new List<string>();
        public static int intContReg;
        public static int intTotReg;
        public static bool blnDesconectado = false;
        public static int intQtdeRegistros = 0;
        public static int intQtdeLotes = 0;
        public static int intConsulta = 0;
        public static int intSADT = 0;
        public static int intHospital = 0;
        public static int intDiamante = 0;
        public static int intConsultaListagem = 0;
        public static int intSADTListagem = 0;
        public static int intHospitalListagem = 0;
        public static int intDiamanteListagem = 0;
        public static string strRetornoPesquisa = string.Empty;
        public static string strNFeUrl = string.Empty;
        public static long lngCodigoEntrada = 0;
        public static DateTime dttManutencao;
        public static bool blnSair = false;

        public enum TipoCampo { Alphanumerico = 1, Numerico = 2, Logico = 3, Data = 4, Hora = 5, Opcoes = 6 };
        public enum Formato { Cpf = 0, Cnpj = 1, Cep = 2, Telefone = 3, DDD_Telefone = 4, Específico = 5, Livre = 6, CpfCnpj = 7 };
        public enum StatusCaixa { Aberta = 1, AguardandoDigitalizacao = 2, EmDigitalizacao = 3, AguardandoDigitacao = 4, EmDigitacao = 5, AguardandoUpload = 6, Finalizada = 7 }
        public enum StatusLote { Aberto = 1, AguardandoDigitalizacao = 2, EmDigitalizacao = 3, AguardandoDigitacao = 4, EmDigitacao = 5, AguardandoFechamentoCaixa = 6, AguardandoUpload = 7, Finalizado = 8, Nenhum = 9 }
        public enum StatusImagem { AguardandoDigitalizacao = 1, AguardandoDigitacao = 2, AguardandoFechamentoLote = 3, AguardandoFechamentoCaixa = 4, AguardandoUpload = 5, Finalizada = 6, Ilegivel = 7, ArquivoNaoEncontrado = 8, Nenhum = 9 }
        public enum StatusLogin { Login = 1, Logoff = 2, Inatividade = 3 };
        public enum OpcaoConfiguracao { BancoDados = 1, Aplicacao = 2, Permissoes = 3 };
        public static string Encrypt(string toEncrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            AppSettingsReader settingsReader = new AppSettingsReader();
            // Get the key from config file
            string key = strCliente == string.Empty ? "Code Technology Soluções em Tecnologia Ltda" : strCliente;
            //System.Windows.Forms.MessageBox.Show(key);
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        /// <summary>
        /// DeCrypt a string using dual encryption method. Return a DeCrypted clear string
        /// </summary>
        /// <param name="cipherString">encrypted string</param>
        /// <param name="useHashing">Did you use hashing to encrypt this data? pass true is yes</param>
        /// <returns></returns>
        public static string Decrypt(string cipherString, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            AppSettingsReader settingsReader = new AppSettingsReader();
            //Get your key from config file to open the lock!
            //string key = (string)settingsReader.GetValue("SecurityKey", typeof(String));
            string key = strCliente == string.Empty ? "Code Technology Soluções em Tecnologia Ltda" : strCliente;

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        public static DataTable CarregarTipoCampo()
        {
            AcessoBD oAcessoBD = new AcessoBD();
            try
            {
                string strSql = "SELECT TTC_CODIGO, TTC_DESCRICAO, TTC_NOME FROM TB_TIPO_CAMPO_TTC (NOLOCK) WHERE TTC_ATIVO = 1";
                //oAcessoBD.Conectar(false);
                DataTable dtTipoCampo = oAcessoBD.ConsultarSql(strSql, new List<SqlParameter>());
                //oAcessoBD.Desconectar(false);
                return dtTipoCampo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                //oAcessoBD.Desconectar(false);
            }
        }
        public static DataTable CarregarUsuario(bool blnTodos = false)
        {
            AcessoBD oAcessoBD = new AcessoBD();
            try
            {
                string strSql = string.Empty;
                if (blnTodos)
                {
                    strSql = "SELECT 0 USU_CODIGO, 'TODOS' USU_NOME UNION ";
                }
                strSql += "SELECT USU_CODIGO, USU_NOME FROM TB_USUARIO_USU (NOLOCK)";
                //oAcessoBD.Conectar(false);
                DataTable dtUsuario = oAcessoBD.ConsultarSql(strSql, new List<SqlParameter>());
                //oAcessoBD.Desconectar(false);
                return dtUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                //oAcessoBD.Desconectar(false);
            }
        }
        public static DataTable CarregarServico(bool blnTodos = false)
        {
            AcessoBD oAcessoBD = new AcessoBD();
            try
            {
                //AcessoBD oAcessoBD = new AcessoBD();
                string strSql = string.Empty;
                if (blnTodos)
                {
                    strSql = "SELECT 0 SER_CODIGO, 'TODOS' SER_DESCRICAO UNION ";
                }
                strSql += "SELECT SER_CODIGO, SER_DESCRICAO FROM TB_SERVICO_SER (NOLOCK)";
                oAcessoBD.Conectar(false);
                DataTable dtServico = oAcessoBD.ConsultarSql(strSql, new List<SqlParameter>());
                //oAcessoBD.Desconectar(false);
                return dtServico;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oAcessoBD.Desconectar(false);
            }

        }
        public static DataTable CarregarStatus()
        {
            AcessoBD oAcessoBD = new AcessoBD();
            try
            {
                //AcessoBD oAcessoBD = new AcessoBD();
                string strSql = "SELECT STA_CODIGO, STA_DESCRICAO FROM TB_STATUS_STA (NOLOCK)";

                DataTable dtStatus = oAcessoBD.ConsultarSql(strSql, new List<SqlParameter>());
                //oAcessoBD.Desconectar(false);
                return dtStatus;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
        public static DataTable CarregarStatusLote()
        {
            AcessoBD oAcessoBD = new AcessoBD();
            try
            {
                //AcessoBD oAcessoBD = new AcessoBD();
                string strSql = "SELECT SLO_CODIGO, SLO_DESCRICAO FROM TB_STATUS_LOTE_SLO (NOLOCK)";

                DataTable dtStatus = oAcessoBD.ConsultarSql(strSql, new List<SqlParameter>());
                //oAcessoBD.Desconectar(false);
                return dtStatus;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable CarregarLayouts()
        {
            AcessoBD oAcessoBD = new AcessoBD();
            try
            {
                //AcessoBD oAcessoBD = new AcessoBD();
                string strSql = "SELECT IMP_CODIGO, IMP_NOME_LAYOUT FROM TB_IMPORTACAO_IMP (NOLOCK) ORDER BY IMP_NOME_LAYOUT";

                DataTable dtLayouts = oAcessoBD.ConsultarSql(strSql, new List<SqlParameter>());
                //oAcessoBD.Desconectar(false);
                return dtLayouts;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable ConsultarStatusPeg(int intCodigoStatus = 0)
        {
            AcessoBD oAcessoBD = new AcessoBD();
            List<SqlParameter> oParametros = new List<SqlParameter>();
            try
            {
                //AcessoBD oAcessoBD = new AcessoBD();
                oParametros.Clear();
                string strSql = "SELECT TSP_CODIGO, TSP_DESCRICAO FROM TB_STATUS_PEG_TSP ";
                if (intCodigoStatus != 0)
                {
                    strSql += "WHERE TSP_CODIGO = @p_Codigo";
                    oParametros.Add(new SqlParameter("@p_Codigo", intCodigoStatus));
                }

                DataTable dt = oAcessoBD.ConsultarSql(strSql, oParametros);
                //oAcessoBD.Desconectar(false);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable CarregarTipoPegs(bool blnSomenteRegime = false)
        {
            AcessoBD oAcessoBD = new AcessoBD();
            try
            {
                //AcessoBD oAcessoBD = new AcessoBD();
                string strSql = "SELECT Convert(varchar,TIP_CODIGO) + ' - '+ TIP_DESCRICAO TIP_DESCRICAO FROM TB_TIPO_PEG_TIP (NOLOCK) ";
                if (blnSomenteRegime)
                {
                    strSql += "WHERE TIP_CODIGO NOT IN (4,5,6) ";
                }
                strSql += "ORDER BY TIP_CODIGO";
                //oAcessoBD.Conectar(false);
                DataTable dtPegs = oAcessoBD.ConsultarSql(strSql, new List<SqlParameter>());
                //oAcessoBD.Desconectar(false);
                return dtPegs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                //oAcessoBD.Desconectar(false);
            }
        }
        public static bool EnviaTratativa(int intTipoPeg)
        {
            AcessoBD oAcessoBD = new AcessoBD();
            try
            {
                string strSql = "SELECT ISNULL(TIP_TRATATIVA,0) TIP_TRATATIVA FROM TB_TIPO_PEG_TIP (NOLOCK) WHERE TIP_CODIGO = @tipo_peg";
                List<SqlParameter> oParametros = new List<SqlParameter>();
                oParametros.Add(new SqlParameter("@tipo_peg", intTipoPeg));
                oAcessoBD.Conectar(false);
                return Convert.ToBoolean(oAcessoBD.ExecutarSql(strSql, oParametros));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oAcessoBD.Desconectar(false);
            }
        }
        public static DataTable CarregarPegsMigracao(DateTime dttDe, DateTime dttAte)
        {
            AcessoBD oAcessoBD = new AcessoBD();
            try
            {
                //List<SqlParameter> oParametros = new List<SqlParameter>();
                //oParametros.Add(new SqlParameter("@p_Data_Inicio", Convert.ToDateTime(dttDe.ToShortDateString())));
                //oParametros.Add(new SqlParameter("@p_Data_Fim", Convert.ToDateTime(dttAte.ToShortDateString())));

                //string strSql = "select DISTINCT CONVERT(VARCHAR(10),TPP_DATA_PAGAMENTO_IDEAL,103) [Data Pagamento Ideal], ";
                //strSql += "(select COUNT(1) FROM  TB_PEG_PORTAL_TPP TPP1 (nolock)  where TPP1.TPP_DIAMANTE = 1 AND TPP1.TSP_CODIGO IN (3) AND TPP1.TPP_DATA_PAGAMENTO_IDEAL = TPP.TPP_DATA_PAGAMENTO_IDEAL)  [Diamante], ";
                //strSql += "(select COUNT(1) FROM  TB_PEG_PORTAL_TPP TPP1 (nolock)  where TPP1.TIP_CODIGO = 1 AND TPP1.TPP_DIAMANTE = 0 AND TPP1.TSP_CODIGO IN (3) AND TPP1.TPP_DATA_PAGAMENTO_IDEAL = TPP.TPP_DATA_PAGAMENTO_IDEAL)  [Consultório / Clinica], ";
                //strSql += "(select COUNT(1) FROM  TB_PEG_PORTAL_TPP TPP1 (nolock)  where TPP1.TIP_CODIGO = 2 AND TPP1.TPP_DIAMANTE = 0 AND TPP1.TSP_CODIGO IN (3) AND TPP1.TPP_DATA_PAGAMENTO_IDEAL = TPP.TPP_DATA_PAGAMENTO_IDEAL)  [Atendimento Externo], ";
                //strSql += "(select COUNT(1) FROM  TB_PEG_PORTAL_TPP TPP1 (nolock)  where TPP1.TIP_CODIGO = 3 AND TPP1.TPP_DIAMANTE = 0 AND TPP1.TSP_CODIGO IN (3) AND TPP1.TPP_DATA_PAGAMENTO_IDEAL = TPP.TPP_DATA_PAGAMENTO_IDEAL)  [Hospital / Maternidade], ";
                //strSql += "(select COUNT(1) FROM  TB_PEG_PORTAL_TPP TPP1 (nolock)  where TPP1.TSP_CODIGO IN (9) AND TPP1.TPP_DATA_PAGAMENTO_IDEAL = TPP.TPP_DATA_PAGAMENTO_IDEAL)  [Tratativa] ";
                //strSql += "from TB_PEG_PORTAL_TPP TPP (NOLOCK)  ";
                //strSql += "WHERE TPP.TPP_DATA_PAGAMENTO_IDEAL BETWEEN @p_Data_Inicio AND @p_Data_Fim  ";
                //strSql += "ORDER BY 1";

                //DataTable dt = oAcessoBD.ConsultarSql(strSql, oParametros);
                string strSql = "sp_retorna_pegs_migracao";

                List<SqlParameter> oParametros = new List<SqlParameter>();
                oParametros.Add(new SqlParameter("@p_Data_Inicio", Convert.ToDateTime(dttDe.ToShortDateString())));
                oParametros.Add(new SqlParameter("@p_Data_Fim", Convert.ToDateTime(dttAte.ToShortDateString())));
                DataTable dt = oAcessoBD.ConsultarSql(strSql, oParametros, CommandType.StoredProcedure);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public static DataTable CarregarPegsEnvioListagem(DateTime dttDe, DateTime dttAte)
        {
            AcessoBD oAcessoBD = new AcessoBD();
            try
            {
                List<SqlParameter> oParametros = new List<SqlParameter>();
                oParametros.Add(new SqlParameter("@p_Data_Inicio", Convert.ToDateTime(dttDe.ToShortDateString())));
                oParametros.Add(new SqlParameter("@p_Data_Fim", Convert.ToDateTime(dttAte.ToShortDateString())));

                string strSql = "select CONVERT(VARCHAR(10),PEL_DATA,103) [Data Envio], PEL.TPP_PEG_PEGRP [N° PEG], USU_NOME [Digitador] ";
                strSql += "from TB_PEG_ENVIO_LISTAGEM_PEL PEL (NOLOCK) ";
                strSql += "INNER JOIN TB_USUARIO_USU USU(NOLOCK) ON PEL.USU_CODIGO = USU.USU_CODIGO ";

                strSql += "WHERE PEL.PEL_DATA BETWEEN @p_Data_Inicio AND @p_Data_Fim  ";
                strSql += "ORDER BY 1, 2 ";

                DataTable dt = oAcessoBD.ConsultarSql(strSql, oParametros);
                //string strSql = "sp_retorna_pegs_migracao";                

                //List<SqlParameter> oParametros = new List<SqlParameter>();
                //oParametros.Add(new SqlParameter("@p_Data_Inicio", Convert.ToDateTime(dttDe.ToShortDateString())));
                //oParametros.Add(new SqlParameter("@p_Data_Fim", Convert.ToDateTime(dttAte.ToShortDateString())));
                //DataTable dt =  oAcessoBD.ConsultarSql(strSql, oParametros, CommandType.StoredProcedure);                
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static DataTable CarregarEstatisticasPegPortal(int intOpcao, DateTime dttDe, DateTime dttAte)
        {
            AcessoBD oAcessoBD = new AcessoBD();
            try
            {
                List<SqlParameter> oParametros = new List<SqlParameter>();
                oParametros.Add(new SqlParameter("@p_Data_Inicio", Convert.ToDateTime(dttDe.ToShortDateString())));
                oParametros.Add(new SqlParameter("@p_Data_Fim", Convert.ToDateTime(dttAte.ToShortDateString())));
                oParametros.Add(new SqlParameter("@p_tipo_pesquisa", intOpcao));
                string strSql = "sp_retorna_estatisticas_pegs";
                //string strSql = "select CONVERT(VARCHAR(10),TPP_DATA_PAGAMENTO_IDEAL,103) [Data Pagamento Ideal], TIP_DESCRICAO [Regime Atendimento], \n";
                //strSql += "SUM(CASE WHEN ISNULL(TPP.USU_CODIGO,0)=0 AND TSP_CODIGO IN (1,2) THEN 1 ELSE 0 END) [Em Aberto],\n";
                //strSql += "SUM(CASE WHEN ISNULL(TPP.USU_CODIGO,0)=0 AND TPP_LISTAGEM = 1 AND TSP_CODIGO IN (1,2) THEN 1 ELSE 0 END) [Listagem em Aberto],\n";
                //strSql += "SUM(CASE WHEN ISNULL(TPP.USU_CODIGO, 0) != 0 AND ISNULL(TPT.TPP_PEG_PEGRP,0)!=0 AND ISNULL(TPT.USU_CODIGO,0)=0 and TSP_CODIGO IN (7,8) THEN 1 ELSE 0 END)[Tratativa Abertos], \n";
                //strSql += "SUM(CASE WHEN ISNULL(TPP.USU_CODIGO, 0) != 0 AND TSP_CODIGO = 3 THEN 1 ELSE 0 END)[Digitados], \n";
                //strSql += "SUM(CASE WHEN ISNULL(TPP.USU_CODIGO, 0) != 0 AND TPP_LISTAGEM = 1 AND TSP_CODIGO = 3 THEN 1 ELSE 0 END)[Listagem Digitados],\n";
                //strSql += "SUM(CASE WHEN ISNULL(TPP.USU_CODIGO, 0) != 0 AND ISNULL(TPT.TPP_PEG_PEGRP,0)!=0 AND ISNULL(TPT.USU_CODIGO,0) != 0 AND TSP_CODIGO = 9 THEN 1 ELSE 0 END)[Tratativa Digitados], \n";
                //strSql += "SUM(CASE WHEN TSP_CODIGO = 4 THEN 1 ELSE 0 END) [Migrados], \n";
                //strSql += "SUM(CASE WHEN TSP_CODIGO = 4 AND TPP_LISTAGEM = 1 THEN 1 ELSE 0 END) [Listagem Migrados], \n";
                //strSql += "SUM(CASE WHEN TSP_CODIGO IN (10) THEN 1 ELSE 0 END) [Tratativa Migrados] \n";
                //strSql += "from TB_PEG_PORTAL_TPP TPP (NOLOCK)\n ";
                //strSql += "INNER JOIN TB_TIPO_PEG_TIP TIP(NOLOCK) ON TPP.TIP_CODIGO = TIP.TIP_CODIGO \n";
                //strSql += "LEFT JOIN TB_PEG_TRATATIVA_TPT TPT(NOLOCK) ON TPP.TPP_PEG_PEGRP = TPT.TPP_PEG_PEGRP \n";
                //strSql += "WHERE TPP.TPP_DATA_PAGAMENTO_IDEAL BETWEEN @p_Data_Inicio AND @p_Data_Fim \n";
                //strSql += "AND TSP_CODIGO NOT IN (5, 6) \n";
                //strSql += "GROUP BY CONVERT(VARCHAR(10), TPP_DATA_PAGAMENTO_IDEAL, 103), TIP_DESCRICAO, TPP_DATA_PAGAMENTO_IDEAL \n";
                //if (intOpcao == 1)
                //{
                //    strSql += "HAVING SUM(CASE WHEN ISNULL(TPP.USU_CODIGO, 0) = 0 THEN 1 ELSE 0 END) > 0 \n";
                //}
                //else if (intOpcao == 2)
                //{
                //    strSql += "HAVING SUM(CASE WHEN ISNULL(TPP.USU_CODIGO, 0) = 0 THEN 1 ELSE 0 END) = 0 \n";
                //}
                //strSql += "ORDER BY TPP_DATA_PAGAMENTO_IDEAL, TIP_DESCRICAO";

                DataTable dt = oAcessoBD.ConsultarSql(strSql, oParametros, CommandType.StoredProcedure);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable ConsultarPegs(DateTime dttData, int intStatus = 0)
        {
            AcessoBD oAcessoBD = new AcessoBD();
            try
            {
                List<SqlParameter> oParametros = new List<SqlParameter>();
                oParametros.Add(new SqlParameter("@p_Data", Convert.ToDateTime(dttData.ToShortDateString())));

                string strSql = "Select \n";
                strSql += "TPP.TPP_PEG_PEGRP[Peg],  \n";
                strSql += "TSP_DESCRICAO[Situação],  \n";
                strSql += "TPP_REGIMEATENDIMENTO_PEGR[Regime Atendimento],  \n";
                strSql += "case when TPP_DIAMANTE = 1 then 'Sim'else 'Não' end[Diamante], \n";
                strSql += "case when TPP_LISTAGEM = 1 then 'Sim'else 'Não' end[Listagem], \n";
                strSql += "case when TPP_PRIORIZAR = 1 THEN 'Sim' else 'Não' end[Priorizada], \n";
                strSql += "ISNULL(TPP.TPP_RESPOSTA, '')[Resposta], \n";
                strSql += "ISNULL(CASE WHEN TPP.TSP_CODIGO = 8 THEN US.USU_NOME ELSE USU_.USU_NOME END,'') [Digitador Tratativa], \n";
                strSql += "ISNULL(CONVERT(VARCHAR, TPP_EVENTOS), '')[Eventos], \n";
                strSql += "ISNULL(CONVERT(VARCHAR(10), TPP_DATA_DIGITACAO, 103), '')[Digitado em], \n";
                strSql += "ISNULL(CASE WHEN TPP.TSP_CODIGO = 2 THEN US.USU_NOME ELSE USU.USU_NOME END, '')[Digitador], \n";
                strSql += "TDI_ARQUIVO[Arquivo Importação], \n";
                strSql += "ISNULL(CONVERT(VARCHAR(10), TPP_DATA_MIGRACAO, 103), '')[Migrado em], \n";
                strSql += "ISNULL(MPP_ARQUIVO, '')[Arquivo Migração], \n";
                strSql += "ISNULL(CONVERT(VARCHAR(10), PTA_DATA_DISTRIUICAO, 103), '')+' '+ISNULL(CONVERT(VARCHAR(10), PTA_DATA_DISTRIUICAO, 108), '')[Distribuido em], \n";
                strSql += "ISNULL(CONVERT(VARCHAR(10), PTA_DATA_FINALIZACAO, 103), '')+' '+ISNULL(CONVERT(VARCHAR(10), PTA_DATA_FINALIZACAO, 108), '')[Finalizado em] \n"; 
                strSql += "from TB_PEG_PORTAL_TPP TPP (nolock) \n";
                strSql += "inner join TB_DETALHE_IMPORTACAO_TDI TDI(NOLOCK) ON TPP.TDI_CODIGO = TDI.TDI_CODIGO \n";
                strSql += "inner join TB_STATUS_PEG_TSP TSP(NOLOCK) ON TPP.TSP_CODIGO = TSP.TSP_CODIGO \n";
                strSql += "left join TB_USUARIO_USU USU(NOLOCK) ON TPP.USU_CODIGO = USU.USU_CODIGO \n";
                strSql += "left join TB_MIGRACAO_PEG_PORTAL_MPP MPP(NOLOCK) ON TPP.MPP_CODIGO = MPP.MPP_CODIGO \n";
                strSql += "left join TB_PEG_EM_DIGITACAO DIG (NOLOCK) ON TPP.TPP_PEG_PEGRP = DIG.TPP_PEG_PEGRP \n";
                strSql += "left join TB_USUARIO_USU US(NOLOCK) ON DIG.USU_CODIGO = US.USU_CODIGO \n";
                strSql += "left join TB_PEG_TRATATIVA_TPT TPT (NOLOCK) ON TPP.TPP_PEG_PEGRP = TPT.TPP_PEG_PEGRP \n";
                strSql += "left join TB_USUARIO_USU USU_(NOLOCK) ON TPT.USU_CODIGO = USU_.USU_CODIGO \n";
                strSql += "left join TB_PEG_TEMPO_ATUACAO_PTA PTA (NOLOCK) ON PTA.TPP_PEG_PEGRP = TPP.TPP_PEG_PEGRP \n";
                strSql += "where TPP_DATA_PAGAMENTO_IDEAL = @p_Data ";


                if (intStatus == 1)
                {
                    strSql += "AND TPP.TSP_CODIGO IN (1,7)";
                    //oParametros.Add(new SqlParameter("@p_CodigoStatus", intStatus));
                }
                else if (intStatus == 2)
                {
                    strSql += "AND TPP.TSP_CODIGO IN (2,8)";
                    //oParametros.Add(new SqlParameter("@p_CodigoStatus", intStatus));
                }
                else if (intStatus == 3)
                {
                    strSql += "AND TPP.TSP_CODIGO IN (3,9)";
                    //oParametros.Add(new SqlParameter("@p_CodigoStatus", intStatus));
                }
                else if (intStatus == 4)
                {
                    strSql += "AND TPP.TSP_CODIGO IN (4,10)";
                    //oParametros.Add(new SqlParameter("@p_CodigoStatus", intStatus));
                }


                DataTable dt = oAcessoBD.ConsultarSql(strSql, oParametros);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable GerarRelatorio(bool blnServico, int intServico, int intUsuario, DateTime dttDe, DateTime dttAte)
        {
            AcessoBD oAcessoBD = new AcessoBD();
            try
            {
                //AcessoBD oAcessoBD = new AcessoBD();
                List<SqlParameter> oParametros = new List<SqlParameter>();
                oParametros.Clear();

                string strSql = "SELECT ";
                string strGoupBy = "GROUP BY ";
                if (blnServico)
                {
                    strSql += "SER.SER_DESCRICAO SERVIÇO, USU.USU_NOME USUÁRIO, ";
                    strGoupBy += "SER.SER_DESCRICAO, USU.USU_NOME ";
                }
                else
                {
                    strSql += "USU.USU_NOME USUÁRIO, SER.SER_DESCRICAO SERVIÇO, ";
                    strGoupBy += "USU.USU_NOME, SER.SER_DESCRICAO ";
                }
                strGoupBy += ", CASE WHEN DIG_BANCO = 0 THEN 'Não' else 'Sim' end";
                strSql += "CASE WHEN DIG_BANCO = 0 THEN 'Não' else 'Sim' end \"REGISTRO LOCALIZADO\",";
                strSql += "COUNT(USU.USU_NOME) QTDE from TB_DIGITACAO_DIG DIG  (NOLOCK)";
                strSql += "inner join TB_SERVICO_SER SER (NOLOCK) ON DIG.SER_CODIGO = SER.SER_CODIGO ";
                strSql += "inner join TB_USUARIO_USU USU (NOLOCK) ON DIG.USU_CODIGO = USU.USU_CODIGO ";
                strSql += "WHERE DIG.DIG_DATA BETWEEN @p_De AND @p_Ate ";

                if (intServico != 0)
                {
                    strSql += "AND SER.SER_CODIGO = @p_CodigoServico ";
                    oParametros.Add(new SqlParameter("@p_CodigoServico", intServico));
                }
                if (intUsuario != 0)
                {
                    strSql += "AND USU.USU_CODIGO = @p_CodigoUsuario ";
                    oParametros.Add(new SqlParameter("@p_CodigoUsuario", intUsuario));
                }

                strSql += strGoupBy;

                oParametros.Add(new SqlParameter("@p_De", Convert.ToDateTime(dttDe.ToShortDateString())));
                oParametros.Add(new SqlParameter("@p_Ate", Convert.ToDateTime(dttAte.ToShortDateString())));

                DataTable dtRelatorio = oAcessoBD.ConsultarSql(strSql, oParametros);
                //oAcessoBD.Desconectar(false);
                return dtRelatorio;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable CarregarCaixas(int intCodigoServico, Funcoes.StatusLote pStatusLote)
        {
            AcessoBD oAcessoBD = new AcessoBD();
            try
            {
                //AcessoBD oAcessoBD = new AcessoBD();
                List<SqlParameter> oParametros = new List<SqlParameter>();
                string strSql = "SELECT DISTINCT CAI.CAI_CODIGO, CAI_NUMERO FROM TB_CAIXA_CAI CAI (NOLOCK) ";
                strSql += "INNER JOIN TB_LOTE_LOT LOT (NOLOCK) ON CAI.CAI_CODIGO = LOT.CAI_CODIGO ";
                strSql += "WHERE CAI.SCA_CODIGO != @p_StatusCaixa ";
                //strSql += "INNER JOIN TB_IMAGEM_IMA IMA ON LOT.LOT_CODIGO = IMA.LOT_CODIGO ";
                //if (pStatusImagem != Funcoes.StatusImagem.Nenhum)
                //    strSql += "WHERE SIM_CODIGO = @p_StatusImagem AND SER_CODIGO = @p_CodigoServico ";
                //    oParametros.Add(new SqlParameter("@p_StatusImagem", Convert.ToInt32(pStatusImagem)));
                if (pStatusLote != Funcoes.StatusLote.Nenhum)
                {
                    strSql += "AND LOT.SLO_CODIGO = @p_StatusLote ";
                    oParametros.Add(new SqlParameter("@p_StatusLote", Convert.ToInt32(pStatusLote)));
                    if (pStatusLote == StatusLote.Finalizado)
                    {
                        strSql += "AND NOT EXISTS (SELECT 1 FROM TB_EXPORTACAO_CD_TEC TEC (NOLOCK) WHERE CAI_NUMERO = TEC_CAIXA) ";
                    }
                }
                strSql += "AND SER_CODIGO = @p_CodigoServico ";
                strSql += "ORDER BY CAI_NUMERO";
                oParametros.Add(new SqlParameter("@p_StatusCaixa", (int)Funcoes.StatusCaixa.Finalizada));
                oParametros.Add(new SqlParameter("@p_CodigoServico", intCodigoServico));
                //oAcessoBD.Conectar(false);
                DataTable dtCaixa = oAcessoBD.ConsultarSql(strSql, oParametros);
                //oAcessoBD.Desconectar(false);
                return dtCaixa;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                //oAcessoBD.Desconectar(false);
            }

        }
        public static void GravarDigitacao(int intServico, bool blnBanco)
        {
            AcessoBD oAcessoBD = new AcessoBD();
            try
            {
                //AcessoBD oAcessoBD = new AcessoBD();
                List<SqlParameter> oParametros = new List<SqlParameter>();
                string strSql = "INSERT INTO TB_DIGITACAO_DIG ";
                strSql += "(DIG_DATA, SER_CODIGO, USU_CODIGO, DIG_BANCO)";
                strSql += "VALUES";
                strSql += "(@p_Data, @p_Servico, @p_Usuario, @p_Banco)";
                oAcessoBD.Conectar(false);
                oParametros.Clear();
                oParametros.Add(new SqlParameter("@p_Data", DateTime.Now));
                oParametros.Add(new SqlParameter("@p_Servico", intServico));
                oParametros.Add(new SqlParameter("@p_Usuario", Funcoes.intCodigoUsuario));
                oParametros.Add(new SqlParameter("@p_Banco", blnBanco));
                oAcessoBD.ExecutarSql(oParametros, strSql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oAcessoBD.Desconectar(false);
            }

        }
        public static void RegistrarLogin(int intTipo)
        {
            AcessoBD oAcessoBD = new AcessoBD();
            try
            {
                string strStatus = "Inatividade";
                if (intTipo == 1)
                {
                    strStatus = "Login";
                }
                else if (intTipo == 2)
                {
                    strStatus = "Logoff";
                }
                //AcessoBD oAcessoBD = new AcessoBD();
                string strSql = "INSERT INTO TB_LOGIN_LOG (LOG_DATA, LOG_STATUS, LOG_TOTAL, USU_CODIGO) ";
                strSql += "VALUES (@p_Data, @p_Status, @p_Total, @p_Usuario)";
                List<SqlParameter> oParametros = new List<SqlParameter>();
                oParametros.Add(new SqlParameter("@p_Data", DateTime.Now));
                oParametros.Add(new SqlParameter("@p_Status", strStatus));
                oParametros.Add(new SqlParameter("@p_Total", "00:00:00.000"));
                oParametros.Add(new SqlParameter("@p_Usuario", Funcoes.intCodigoUsuario));
                oAcessoBD.Conectar(false);
                oAcessoBD.ExecutarSql(oParametros, strSql);
                //oAcessoBD.Desconectar(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oAcessoBD.Desconectar(false);
            }

        }
        public static bool ValidaCPF(string strCPF, bool blnObrgatorio)
        {
            string strValor = strCPF.Replace(".", "");
            strValor = strValor.Replace("-", "");
            if (strValor.Trim() == string.Empty && !blnObrgatorio)
            {
                return true;
            }
            else if (strValor.Length != 11)
            {
                return false;
            }
            bool blnIgual = true;
            for (int i = 1; i < 11 && blnIgual; i++)
            {
                if (strValor[i] != strValor[0])
                {
                    blnIgual = false;
                }
            }
            if (blnIgual || strValor == "12345678909")
            {
                return false;
            }
            int[] intNumeros = new int[11];
            for (int i = 0; i < 11; i++)
            {
                intNumeros[i] = int.Parse(strValor[i].ToString());
            }
            int intSoma = 0;
            for (int i = 0; i < 9; i++)
            {
                intSoma += (10 - i) * intNumeros[i];
            }
            int intResultado = intSoma % 11;
            if (intResultado == 1 || intResultado == 0)
            {
                if (intNumeros[9] != 0)
                {
                    return false;
                }
            }
            else if (intNumeros[9] != 11 - intResultado)
            {
                return false;
            }
            intSoma = 0;
            for (int i = 0; i < 10; i++)
            {
                intSoma += (11 - i) * intNumeros[i];
            }
            intResultado = intSoma % 11;
            if (intResultado == 1 || intResultado == 0)
            {
                if (intNumeros[10] != 0)
                {
                    return false;
                }
            }
            else if (intNumeros[10] != 11 - intResultado)
            {
                return false;
            }
            return true;
        }
        public static bool ValidaCNPJ(string strCNPJ, bool blnObrgatorio)
        {
            string CNPJ = strCNPJ.Replace(".", "");
            CNPJ = CNPJ.Replace("/", "");
            CNPJ = CNPJ.Replace("-", "");
            int[] digitos, soma, resultado;
            int nrDig;
            string ftmt;
            bool[] CNPJOk;
            ftmt = "6543298765432";
            digitos = new int[14];
            soma = new int[2];
            soma[0] = 0;
            soma[1] = 0;
            resultado = new int[2];
            resultado[0] = 0;
            resultado[1] = 0;
            CNPJOk = new bool[2];
            CNPJOk[0] = false;
            CNPJOk[1] = false;
            try
            {
                if (CNPJ.Trim() == string.Empty && !blnObrgatorio)
                {
                    return true;
                }
                for (nrDig = 0; nrDig < 14; nrDig++)
                {
                    digitos[nrDig] = int.Parse(CNPJ.Substring(nrDig, 1));
                    if (nrDig <= 11)
                    {
                        soma[0] += (digitos[nrDig] * int.Parse(ftmt.Substring(nrDig + 1, 1)));
                    }
                    if (nrDig <= 12) soma[1] += (digitos[nrDig] * int.Parse(ftmt.Substring(nrDig, 1)));
                }
                for (nrDig = 0; nrDig < 2; nrDig++)
                {
                    resultado[nrDig] = (soma[nrDig] % 11);
                    if ((resultado[nrDig] == 0) || (resultado[nrDig] == 1))
                    {
                        CNPJOk[nrDig] = (digitos[12 + nrDig] == 0);
                    }
                    else
                    {
                        CNPJOk[nrDig] = (digitos[12 + nrDig] == (11 - resultado[nrDig]));
                    }
                }
                return (CNPJOk[0] && CNPJOk[1]);
            }
            catch
            {
                return false;
            }
        }
        public static bool VerificarImagem(string strImagem)
        {
            AcessoBD oAcessoBD = new AcessoBD();
            try
            {
                bool blnResultado = false;
                //AcessoBD oAcessoBD = new AcessoBD();
                string strSql = "SELECT IMA_CODIGO FROM TB_IMAGEM_IMA (NOLOCK) WHERE IMA_NOME_ARQUIVO = @p_NomeArquivo AND SIM_CODIGO = 2;";
                List<SqlParameter> oParametros = new List<SqlParameter>();
                oParametros.Add(new SqlParameter("@p_NomeArquivo", strImagem));
                //oAcessoBD.Conectar(false);
                DataTable dtImagem = oAcessoBD.ConsultarSql(strSql, oParametros);
                if (dtImagem.Rows.Count > 0)
                {
                    blnResultado = true;
                }
                //oAcessoBD.Desconectar(false);
                return blnResultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                //oAcessoBD.Desconectar(false);
            }

        }
        public static void UpdateAppSettings(string chave, string valor)
        {

            // Open App.Config of executable

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);


            // Add an Application Setting.

            config.AppSettings.Settings.Remove(chave);

            config.AppSettings.Settings.Add(chave, valor);


            // Save the configuration file.

            config.Save(ConfigurationSaveMode.Modified);


            // Force a reload of a changed section.

            ConfigurationManager.RefreshSection("appSettings");

        }
        public static string CarregarChave(string strChave)
        {
            AcessoBD oAcessoBD = new AcessoBD();
            try
            {
                //AcessoBD oAcessoBD = new AcessoBD();
                List<SqlParameter> oParametros = new List<SqlParameter>();
                string strSql = "SELECT TCR_CHAVE FROM TB_CHAVE_REGISTRO_TCR (NOLOCK) ";
                if (strChave == string.Empty)
                {
                    strSql += "WHERE TCR_DATA = (SELECT MAX(TCR_DATA) FROM TB_CHAVE_REGISTRO_TCR (NOLOCK))";
                }
                else
                {
                    strSql += "WHERE TCR_CHAVE = @p_Chave";
                    oParametros.Add(new SqlParameter("@p_Chave", strChave));
                }
                //oAcessoBD.Conectar(false);
                DataTable dtChave = new DataTable();
                dtChave = oAcessoBD.ConsultarSql(strSql, oParametros);
                //oAcessoBD.Desconectar(false);
                return dtChave.Rows.Count != 0 ? dtChave.Rows[0]["TCR_CHAVE"].ToString() : string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                //oAcessoBD.Desconectar(false);
            }
        }
        public static void GravarChave(string strChave)
        {
            AcessoBD oAcessoBD = new AcessoBD();
            try
            {
                //AcessoBD oAcessoBD = new AcessoBD();
                List<SqlParameter> oParametros = new List<SqlParameter>();
                string strSql = string.Empty;
                oAcessoBD.Conectar(false);
                strSql = "INSERT INTO TB_CHAVE_REGISTRO_TCR (TCR_DATA, TCR_CHAVE) ";
                strSql += "VALUES";
                strSql += "(@p_Data, @p_Chave)";

                oParametros.Add(new SqlParameter("@p_Data", DateTime.Now));
                oParametros.Add(new SqlParameter("@p_Chave", strChave));

                oAcessoBD.ExecutarSql(oParametros, strSql);

                //oAcessoBD.Desconectar(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oAcessoBD.Desconectar(false);
            }
        }
        public static void GravarRegistro()
        {
            AcessoBD oAcessoBD = new AcessoBD();
            try
            {
                //AcessoBD oAcessoBD = new AcessoBD();
                List<SqlParameter> oParametros = new List<SqlParameter>();
                string strSql = string.Empty;
                oAcessoBD.Conectar(false);
                strSql = "DELETE FROM TB_SECURITY_KEY_SEC;INSERT INTO TB_SECURITY_KEY_SEC (SEC_CLIENTE, SEC_REGISTRO) ";
                strSql += "VALUES";
                strSql += "(@p_Cliente, @p_Registro)";

                oParametros.Add(new SqlParameter("@p_Cliente", strCliente));
                oParametros.Add(new SqlParameter("@p_Registro",
                    Encrypt(
                    dttDataInstalacao.ToShortDateString() + "|" +
                    intDias.ToString("00") + "|" +
                    intTotalDias.ToString("000") + "|" +
                    dttData.ToShortDateString()
                    , true)));

                oAcessoBD.ExecutarSql(oParametros, strSql);

                //oAcessoBD.Desconectar(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oAcessoBD.Desconectar(false);
            }
        }
        public static void CarregarRegistro()
        {
            AcessoBD oAcessoBD = new AcessoBD();
            try
            {
                //AcessoBD oAcessoBD = new AcessoBD();
                string strSql = "SELECT SEC_CLIENTE, SEC_REGISTRO FROM TB_SECURITY_KEY_SEC (NOLOCK)";
                //oAcessoBD.Conectar(false);
                DataTable dtRegistro = new DataTable();
                dtRegistro = oAcessoBD.ConsultarSql(strSql, new List<SqlParameter>());
                //oAcessoBD.Desconectar(false);
                if (dtRegistro.Rows.Count != 0)
                {
                    strCliente = dtRegistro.Rows[0]["SEC_CLIENTE"].ToString();
                    string strRegistro = dtRegistro.Rows[0]["SEC_REGISTRO"].ToString();
                    string[] strChave = Funcoes.Decrypt(strRegistro, true).Split('|');
                    dttDataInstalacao = Convert.ToDateTime(strChave[0]);
                    intDias = Convert.ToInt32(strChave[1]);
                    intTotalDias = Convert.ToInt32(strChave[2]);
                    dttData = Convert.ToDateTime(strChave[3]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                //oAcessoBD.Desconectar(false);
            }
        }
        public static void CarregarAppConfig()
        {
            Funcoes.strStringConnexao = "Data Source=";
            Funcoes.strStringConnexao += ConfigurationManager.AppSettings["Servidor"] + ";Initial Catalog=" + ConfigurationManager.AppSettings["Banco"] + ";";
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["Integrated Security"]))
            {
                Funcoes.strStringConnexao += "Integrated Security = true;";
            }
            else
            {
                Funcoes.strStringConnexao += "Uid=" + Funcoes.Decrypt(ConfigurationManager.AppSettings["Usuario"], true) + ";Pwd=";
                //Funcoes.strStringConnexao += Funcoes.Decrypt(ConfigurationManager.AppSettings["Senha"], true) + ";Pooling=true;Min Pool Size=5;Max Pool Size=250; Connect Timeout=3";
                Funcoes.strStringConnexao += Funcoes.Decrypt(ConfigurationManager.AppSettings["Senha"], true) + ";Connect Timeout=90";
            }
            Funcoes.strCaminhoImagens = ConfigurationManager.AppSettings["CaminhoImagens"];
            Funcoes.intTotalInatividade = Convert.ToInt32(ConfigurationManager.AppSettings["Inatividade"]) * 60;
            Funcoes.intDocumentosCaixa = Convert.ToInt32(ConfigurationManager.AppSettings["DocumentosCaixa"]);
            Funcoes.strNFeUrl = ConfigurationManager.AppSettings["NFeUrl"];
        }
        public static void Log(string logMessage)
        {
            using (StreamWriter w = File.AppendText(Funcoes.strCaminhoImagens + @"\log.txt"))
            {
                w.Write("\r\nLog Entry : ");
                w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                w.WriteLine("  :");
                w.WriteLine("  :{0}", logMessage);
                w.WriteLine("-------------------------------");
            }
        }

        //public static void Log(string strMetodo, string exception = "", string query = "")
        //{
        //    try
        //    {
        //        string strCaminho = Funcoes.strCaminhoImagens + @"\Log";
        //        string strArquivo = string.Format(@"{0}\Log_{1}.txt", strCaminho, DateTime.Now.ToString("yyyyMMdd"));
        //        if (!Directory.Exists(strCaminho))
        //        {
        //            Directory.CreateDirectory(strCaminho);
        //        }
        //        StreamWriter file = new StreamWriter(strArquivo, true);
        //        file.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}",
        //            DateTime.Now.ToString(),
        //            strMetodo,
        //            exception == string.Empty ? "" : "Exception:",
        //            exception == string.Empty ? "" : exception,
        //            query == string.Empty ? "" : "Query:",
        //            query == string.Empty ? "" : query,
        //            intCodigoUsuario != 0 ? intCodigoUsuario.ToString() : ""));
        //        file.Close();
        //        file.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        public static string RetornaProcedimento(string codigo)
        {
            string retorno = string.Empty;
            try
            {
                AcessoBD acesso = new AcessoBD();
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Clear();
                parametros.Add(new SqlParameter("@codigo", codigo));
                acesso.Conectar(false);
                retorno = acesso.ExecutarSql("sp_retorna_nome_procedimento", parametros, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return retorno;
        }

        public static string RetornaNomeAssociado(string numero)
        {
            string retorno = string.Empty;
            try
            {
                AcessoBD acesso = new AcessoBD();
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Clear();
                parametros.Add(new SqlParameter("@numero", numero));
                acesso.Conectar(false);
                retorno = acesso.ExecutarSql("sp_retorna_nome_associado", parametros, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return retorno;
        }

        public static string RetornaNomeBanco(string numero)
        {
            string retorno = string.Empty;
            try
            {
                AcessoBD acesso = new AcessoBD();
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Clear();
                parametros.Add(new SqlParameter("@numero", numero));
                acesso.Conectar(false);
                retorno = acesso.ExecutarSql("sp_retorna_nome_banco", parametros, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return retorno;
        }

        public static string RemoveAcentos(this string text)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "IP não identificado";
        }
        public static void RegistrarEntrada()
        {
            AcessoBD oAcessoBD = new AcessoBD();
            try
            {
                //AcessoBD oAcessoBD = new AcessoBD();
                string strSql = "INSERT INTO TB_ACESSO_SID_TAS (TAS_IP, TAS_ENTRADA) ";
                strSql += "VALUES (@p_Ip, @p_Data); SELECT @@IDENTITY;";
                List<SqlParameter> oParametros = new List<SqlParameter>();
                oParametros.Add(new SqlParameter("@p_Ip", Funcoes.GetLocalIPAddress()));
                oParametros.Add(new SqlParameter("@p_Data", DateTime.Now));                
                oAcessoBD.Conectar(false);
                Funcoes.lngCodigoEntrada =  oAcessoBD.ExecutarSql(oParametros, strSql);
                //oAcessoBD.Desconectar(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oAcessoBD.Desconectar(false);
            }

        }
        public static void RegistrarSaida()
        {
            AcessoBD oAcessoBD = new AcessoBD();
            try
            {
                //AcessoBD oAcessoBD = new AcessoBD();
                string strSql = "UPDATE TB_ACESSO_SID_TAS SET TAS_SAIDA = @p_Data WHERE TAS_CODIGO = @p_Codigo";
                List<SqlParameter> oParametros = new List<SqlParameter>();
                oParametros.Add(new SqlParameter("@p_Codigo", Funcoes.lngCodigoEntrada));
                oParametros.Add(new SqlParameter("@p_Data", DateTime.Now));
                oAcessoBD.Conectar(false);
                oAcessoBD.ExecutarSql(oParametros, strSql);
                //oAcessoBD.Desconectar(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oAcessoBD.Desconectar(false);
            }

        }
        public static bool VerificaManutencao()
        {
            AcessoBD oAcessoBD = new AcessoBD();
            try
            {
                bool retorno = false;
                //AcessoBD oAcessoBD = new AcessoBD();
                string strSql = "SELECT ATU_CODIGO, ATU_TERMINO FROM TB_ATUALIZACAO_ATU ATU (NOLOCK) WHERE GETDATE() BETWEEN ATU_INICIO AND ATU_TERMINO";
                //oAcessoBD.Conectar(false);
                DataTable dtRegistro = new DataTable();
                dtRegistro = oAcessoBD.ConsultarSql(strSql, new List<SqlParameter>());
                //oAcessoBD.Desconectar(false);
                if (dtRegistro.Rows.Count != 0)
                {
                    Funcoes.dttManutencao = Convert.ToDateTime(dtRegistro.Rows[0]["ATU_TERMINO"]);
                    retorno = true;
                }
                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                //oAcessoBD.Desconectar(false);
            }
        }
    }
}
