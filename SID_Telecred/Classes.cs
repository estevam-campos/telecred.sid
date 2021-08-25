using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using iTextSharp.text;
using System.Reflection;

namespace SID_Telecred
{
    public class Servico
    {

        public int intCodigo { get; set; }
        public string strNome { get; set; }
        public int intCodigoLayout { get; set; }
        public string strNomeArquivo { get; set; }
        public int intCodigoLote { get; set; }
        public bool blnBanco { get; set; }

        public List<Campo> Campos = new List<Campo>();

        public Servico()
        {
            strNome = string.Empty;
            strNomeArquivo = string.Empty;
            intCodigoLayout = 0;
            intCodigoLote = 0;
            blnBanco = false;
        }

        AcessoBD oAcessoBD = new AcessoBD();
        DataTable dtServico = new DataTable();
        List<SqlParameter> oParametros = new List<SqlParameter>();
        string strSql = string.Empty;

        public void Consultar()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                this.Campos.Clear();
                Campo oCampo = new Campo();
                oCampo.intCodigoServico = intCodigo;
                List<string> strCampo = oCampo.Consultar();
                Campos = this.RetornaListaCampos(strCampo);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Campo> RetornaListaCampos(List<string> strCampo)
        {
            int intOrdem = 0;
            List<Campo> Retorno = new List<Campo>();
            foreach (string campo in strCampo)
            {
                Campo objCampo = new Campo();
                intOrdem++;
                string[] strItens = campo.Split('|');
                objCampo.strDescricao = strItens[0];
                objCampo.blnChave = strItens[1] == "(Chave)";
                objCampo.intPosicaoLayout = Convert.ToInt32(strItens[2]);
                objCampo.intCodigoTipoCampo = Convert.ToInt32(strItens[3]);
                objCampo.intOrdem = intOrdem;
                objCampo.blnPreenchimento = strItens[5] == "Obrigatório" ? true : false;
                if (objCampo.intCodigoTipoCampo == (int)Funcoes.TipoCampo.Alphanumerico)
                {
                    objCampo.strFormatoAlpha = strItens[6];
                    objCampo.strMascaraAlpha = strItens[7];
                    objCampo.intTamanho = Convert.ToInt32(strItens[8]);
                }
                else if (objCampo.intCodigoTipoCampo == (int)Funcoes.TipoCampo.Numerico)
                {
                    objCampo.dblMinimo = Convert.ToDouble(strItens[6]);
                    objCampo.dblMaximo = Convert.ToDouble(strItens[7]);
                    objCampo.intCasasDecimais = Convert.ToInt32(strItens[8]);
                    objCampo.blnSeparadorMilhar = Convert.ToBoolean(strItens[9]);

                }
                else if (objCampo.intCodigoTipoCampo == (int)Funcoes.TipoCampo.Data)
                {
                    objCampo.dttMinima = Convert.ToDateTime(strItens[6]);
                    objCampo.dttMaxima = Convert.ToDateTime(strItens[7]);
                    objCampo.strFormatoData = strItens[6];
                }
                else if (objCampo.intCodigoTipoCampo == (int)Funcoes.TipoCampo.Hora)
                {
                    objCampo.strFormatoHora = strItens[6];
                }
                else if (objCampo.intCodigoTipoCampo == (int)Funcoes.TipoCampo.Opcoes)
                {
                    objCampo.strOpcoes.Clear();
                    for (int intContador = 6; intContador < strItens.Count() - 1; intContador++)
                    {
                        objCampo.strOpcoes.Add(strItens[intContador]);
                    }
                }
                objCampo.intCodigo = Convert.ToInt32(strItens[strItens.Length - 1]);
                Retorno.Add(objCampo);
            }
            return Retorno;
        }
        public void Gravar()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                if (this.intCodigo == 0)
                {
                    oAcessoBD.Conectar(true);
                    //Cadastrando o Serviço
                    strSql = "INSERT INTO TB_SERVICO_SER (SER_DESCRICAO) VALUES (@p_Descricao);SELECT @@IDENTITY";

                    oParametros.Clear();
                    oParametros.Add(new SqlParameter("@p_Descricao", this.strNome));

                    intCodigo = oAcessoBD.ExecutarSql(strSql, oParametros);

                }
                else
                {
                    oAcessoBD.Conectar(true);

                    RemoverAssociacoes();

                    strSql = "UPDATE TB_SERVICO_SER SET SER_DESCRICAO = @p_Descricao WHERE SER_CODIGO = @p_Codigo";
                    oParametros.Clear();
                    oParametros.Add(new SqlParameter("@p_Codigo", this.intCodigo));
                    oParametros.Add(new SqlParameter("@p_Descricao", this.strNome));

                    oAcessoBD.ExecutarSql(oParametros, strSql);

                }

                string[] strTables = new string[5];
                strTables[0] = "TB_ALPHANUMERICO_ALP";
                strTables[1] = "TB_NUMERICO_NUM";
                strTables[2] = "TB_DATA_DAT";
                strTables[3] = "TB_HORA_HOR";
                strTables[4] = "TB_COMBOBOX_CBO";

                foreach (string tabela in strTables)
                {
                    strSql = "DELETE FROM " + tabela + " WHERE CPO_CODIGO IN (SELECT CPO_CODIGO FROM TB_CAMPO_CPO (NOLOCK) WHERE SER_CODIGO = @p_CodigoServico)";
                    oParametros.Clear();
                    oParametros.Add(new SqlParameter("@p_CodigoServico", intCodigo));

                    oAcessoBD.ExecutarSql(oParametros, strSql);

                }

                strSql = "DELETE FROM TB_CAMPO_CPO WHERE SER_CODIGO = @p_CodigoServico";
                oParametros.Clear();
                oParametros.Add(new SqlParameter("@p_CodigoServico", intCodigo));

                oAcessoBD.ExecutarSql(oParametros, strSql);

                //Cadastrando os Campos
                foreach (Campo campo in this.Campos)
                {
                    strSql = "INSERT INTO TB_CAMPO_CPO (CPO_DESCRICAO, CPO_ORDEM, CPO_OBRIGATORIO, CPO_CHAVE, SER_CODIGO, TTC_CODIGO)";
                    strSql += "VALUES (@p_DescricaoCampo, @p_Ordem, @p_Preenchimento, @p_Chave, @p_CodigoServico, @p_CodigoTipoCampo);SELECT @@IDENTITY";

                    oParametros.Clear();
                    oParametros.Add(new SqlParameter("@p_DescricaoCampo", campo.strDescricao));
                    oParametros.Add(new SqlParameter("@p_Ordem", campo.intOrdem));
                    oParametros.Add(new SqlParameter("@p_Preenchimento", campo.blnPreenchimento));
                    oParametros.Add(new SqlParameter("@p_Chave", campo.blnChave));
                    oParametros.Add(new SqlParameter("@p_CodigoServico", this.intCodigo));
                    oParametros.Add(new SqlParameter("@p_CodigoTipoCampo", campo.intCodigoTipoCampo));

                    campo.intCodigo = oAcessoBD.ExecutarSql(strSql, oParametros);

                    if (campo.intCodigoTipoCampo == (int)Funcoes.TipoCampo.Alphanumerico)
                    {
                        strSql = "INSERT INTO TB_ALPHANUMERICO_ALP (ALP_FORMATO, ALP_MASCARA, ALP_TAMANHO, CPO_CODIGO)";
                        strSql += "VALUES (@p_Formato, @p_Mascara, @p_Tamanho, @p_CodigoCampo)";

                        oParametros.Clear();
                        oParametros.Add(new SqlParameter("@p_Formato", campo.strFormatoAlpha));
                        oParametros.Add(new SqlParameter("@p_Mascara", campo.strMascaraAlpha));
                        oParametros.Add(new SqlParameter("@p_Tamanho", campo.intTamanho));
                        oParametros.Add(new SqlParameter("@p_CodigoCampo", campo.intCodigo));

                        oAcessoBD.ExecutarSql(oParametros, strSql);
                    }
                    else if (campo.intCodigoTipoCampo == (int)Funcoes.TipoCampo.Numerico)
                    {
                        strSql = "INSERT INTO TB_NUMERICO_NUM (NUM_MINIMO, NUM_MAXIMO, NUM_MILHAR, NUM_DECIMAIS, CPO_CODIGO)";
                        strSql += "VALUES (@p_Minimo, @p_Maximo, @p_Milhar, @p_Decimais, @p_CodigoCampo)";

                        oParametros.Clear();
                        oParametros.Add(new SqlParameter("@p_Minimo", campo.dblMinimo));
                        oParametros.Add(new SqlParameter("@p_Maximo", campo.dblMaximo));
                        oParametros.Add(new SqlParameter("@p_Milhar", campo.blnSeparadorMilhar));
                        oParametros.Add(new SqlParameter("@p_Decimais", campo.intCasasDecimais));
                        oParametros.Add(new SqlParameter("@p_CodigoCampo", campo.intCodigo));

                        oAcessoBD.ExecutarSql(oParametros, strSql);
                    }
                    else if (campo.intCodigoTipoCampo == (int)Funcoes.TipoCampo.Data)
                    {
                        strSql = "INSERT INTO TB_DATA_DAT (DAT_MINIMA, DAT_MAXIMA, DAT_FORMATO, CPO_CODIGO)";
                        strSql += "VALUES (@p_Minima, @p_Maxima, @p_Formato, @p_CodigoCampo)";

                        oParametros.Clear();
                        oParametros.Add(new SqlParameter("@p_Minima", campo.dttMinima));
                        oParametros.Add(new SqlParameter("@p_Maxima", campo.dttMaxima));
                        oParametros.Add(new SqlParameter("@p_Formato", campo.strFormatoData));
                        oParametros.Add(new SqlParameter("@p_CodigoCampo", campo.intCodigo));

                        oAcessoBD.ExecutarSql(oParametros, strSql);
                    }
                    else if (campo.intCodigoTipoCampo == (int)Funcoes.TipoCampo.Hora)
                    {
                        strSql = "INSERT INTO TB_HORA_HOR (HOR_FORMATO, CPO_CODIGO)";
                        strSql += "VALUES (@p_Formato, @p_CodigoCampo)";

                        oParametros.Clear();
                        oParametros.Add(new SqlParameter("@p_Formato", campo.strFormatoHora));
                        oParametros.Add(new SqlParameter("@p_CodigoCampo", campo.intCodigo));

                        oAcessoBD.ExecutarSql(oParametros, strSql);
                    }
                    else if (campo.intCodigoTipoCampo == (int)Funcoes.TipoCampo.Opcoes)
                    {
                        foreach (string opcao in campo.strOpcoes)
                        {
                            strSql = "INSERT INTO TB_COMBOBOX_CBO (CBO_ITEM, CPO_CODIGO)";
                            strSql += "VALUES (@p_Item, @p_CodigoCampo)";

                            oParametros.Clear();
                            oParametros.Add(new SqlParameter("@p_Item", opcao));
                            oParametros.Add(new SqlParameter("@p_CodigoCampo", campo.intCodigo));

                            oAcessoBD.ExecutarSql(oParametros, strSql);
                        }
                    }

                }

                oAcessoBD.Desconectar(true);
            }
            catch (Exception ex)
            {
                oAcessoBD.RollBack();
                throw new Exception(ex.Message);
            }
        }
        public void GravarRegistro()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oAcessoBD.Conectar(true);

                strSql = "INSERT INTO TB_REGISTRO_REG (REG_NOME_ARQUIVO, REG_DATA, SER_CODIGO, USU_CODIGO, LOT_CODIGO) VALUES ";
                strSql += "(@p_NomeArquivo, @p_Data, @p_CodigoServico, @p_CodigoUsuario, @p_CodigoLote);SELECT @@IDENTITY";

                oParametros.Clear();
                oParametros.Add(new SqlParameter("@p_NomeArquivo", strNomeArquivo));
                oParametros.Add(new SqlParameter("@p_Data", DateTime.Now));
                oParametros.Add(new SqlParameter("@p_CodigoServico", intCodigo));
                oParametros.Add(new SqlParameter("@p_CodigoUsuario", Funcoes.intCodigoUsuario));
                oParametros.Add(new SqlParameter("@p_CodigoLote", intCodigoLote));

                int intRegistro = oAcessoBD.ExecutarSql(strSql, oParametros);

                foreach (Campo campo in Campos)
                {
                    strSql = "INSERT INTO TB_VALOR_VAL (VAL_CONTEUDO, CPO_ORDEM, REG_CODIGO) VALUES ";
                    strSql += "(@p_Conteudo, @p_Ordem, @p_CodigoRegistro)";

                    oParametros.Clear();
                    oParametros.Add(new SqlParameter("@p_Conteudo", campo.strConteudo));
                    oParametros.Add(new SqlParameter("@p_Ordem", campo.intOrdem));
                    oParametros.Add(new SqlParameter("@p_CodigoRegistro", intRegistro));

                    oAcessoBD.ExecutarSql(oParametros, strSql);
                }
                oAcessoBD.Desconectar(true);
                Funcoes.GravarDigitacao(intCodigo, blnBanco);
            }
            catch (Exception ex)
            {
                oAcessoBD.RollBack();
                throw new Exception(ex.Message);
            }
        }
        public void GravarAssociacoes()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oAcessoBD.Conectar(true);
                RemoverAssociacoes();
                foreach (Campo campo in Campos)
                {
                    if (campo.intPosicaoLayout != 0)
                    {
                        strSql = "INSERT INTO TB_ASSOCIACAO_LAYOUT_DADOS_ALD (CPO_ORDEM, LIM_POSICAO, IMP_CODIGO, SER_CODIGO) ";
                        strSql += "VALUES (@p_OrdemServico, @p_OrdemLayout, @p_CodigoLayout, @p_CodigoServico)";

                        oParametros.Clear();
                        oParametros.Add(new SqlParameter("@p_OrdemServico", campo.intOrdem));
                        oParametros.Add(new SqlParameter("@p_OrdemLayout", campo.intPosicaoLayout));
                        oParametros.Add(new SqlParameter("@p_CodigoLayout", intCodigoLayout));
                        oParametros.Add(new SqlParameter("@p_CodigoServico", intCodigo));

                        oAcessoBD.ExecutarSql(oParametros, strSql);
                    }
                }
                oAcessoBD.Desconectar(true);
            }
            catch (Exception ex)
            {
                oAcessoBD.RollBack();
                throw new Exception(ex.Message);
            }
        }
        public void RemoverAssociacoes()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                //oAcessoBD.Conectar(false);
                strSql = "DELETE FROM TB_ASSOCIACAO_LAYOUT_DADOS_ALD WHERE SER_CODIGO = @p_CodigoServico";
                oParametros.Clear();
                oParametros.Add(new SqlParameter("@p_CodigoServico", intCodigo));

                oAcessoBD.ExecutarSql(oParametros, strSql);
                //oAcessoBD.Desconectar(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarAssociacoes()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                strSql = "SELECT CPO.CPO_ORDEM, ALD.LIM_POSICAO, LIM_CAMPO, CPO_DESCRICAO, LIM_CHAVE ";
                strSql += "FROM TB_ASSOCIACAO_LAYOUT_DADOS_ALD ALD (NOLOCK) ";
                strSql += "INNER JOIN TB_IMPORTACAO_IMP IMP (NOLOCK) ON ALD.IMP_CODIGO = IMP.IMP_CODIGO ";
                strSql += "INNER JOIN TB_CAMPO_CPO CPO (NOLOCK) ON CPO.SER_CODIGO = ALD.SER_CODIGO AND CPO.CPO_ORDEM = ALD.CPO_ORDEM ";
                strSql += "INNER JOIN TB_LAYOUT_IMPORTACAO_LIM LIM (NOLOCK) ON LIM.LIM_POSICAO = ALD.LIM_POSICAO AND LIM.IMP_CODIGO = IMP.IMP_CODIGO AND LIM.LIM_IMPORTAR = 1 ";
                strSql += "WHERE CPO.SER_CODIGO = @p_CodigoServico AND IMP.IMP_CODIGO = @p_CodigoLayout";
                oParametros.Clear();
                oParametros.Add(new SqlParameter("@p_CodigoServico", intCodigo));
                oParametros.Add(new SqlParameter("@p_CodigoLayout", intCodigoLayout));

                dtServico = oAcessoBD.ConsultarSql(strSql, oParametros);
                Campos.Clear();
                foreach (DataRow linha in dtServico.Rows)
                {
                    Campo campo = new Campo();
                    campo.intOrdem = Convert.ToInt32(linha["CPO_ORDEM"]);
                    campo.intPosicaoLayout = Convert.ToInt32(linha["LIM_POSICAO"]);
                    campo.strDescricao = linha["CPO_DESCRICAO"].ToString();
                    campo.strConteudo = linha["LIM_CAMPO"].ToString();
                    if (Convert.ToBoolean(linha["LIM_CHAVE"]))
                    {
                        campo.strConteudo += "(chave)";
                    }
                    Campos.Add(campo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ConsultarChave()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                strSql = "SELECT DIM_VALOR, LIM_POSICAO ";
                strSql += "FROM TB_DADOS_IMPORTADOS_DIM DIM (NOLOCK) ";
                strSql += "WHERE TRI_CODIGO = (SELECT TOP 1 TRI.TRI_CODIGO FROM TB_DADOS_IMPORTADOS_DIM DIM (NOLOCK) ";
                strSql += "INNER JOIN TB_REGISTROS_IMPORTADOS_TRI TRI (NOLOCK) ON TRI.TRI_CODIGO = DIM.TRI_CODIGO ";
                strSql += "WHERE LIM_POSICAO = ";
                strSql += "(SELECT LIM.LIM_POSICAO FROM TB_ASSOCIACAO_LAYOUT_DADOS_ALD ALD (NOLOCK) ";
                strSql += "INNER JOIN TB_IMPORTACAO_IMP IMP (NOLOCK) ON IMP.IMP_CODIGO = ALD.IMP_CODIGO ";
                strSql += "INNER JOIN TB_LAYOUT_IMPORTACAO_LIM LIM (NOLOCK) ON IMP.IMP_CODIGO = ";
                strSql += "LIM.IMP_CODIGO AND LIM.LIM_POSICAO = ALD.LIM_POSICAO AND LIM_CHAVE = 1 ";
                strSql += "WHERE SER_CODIGO = @p_CodigoServico) ";
                strSql += "AND TRI.IMP_CODIGO = (SELECT LIM.IMP_CODIGO FROM TB_ASSOCIACAO_LAYOUT_DADOS_ALD ALD (NOLOCK) ";
                strSql += "INNER JOIN TB_LAYOUT_IMPORTACAO_LIM LIM (NOLOCK) ON LIM.IMP_CODIGO = ALD.IMP_CODIGO  ";
                strSql += "AND LIM.LIM_POSICAO = ALD.LIM_POSICAO AND LIM_CHAVE = 1 ";
                strSql += "WHERE ALD.SER_CODIGO = @p_CodigoServico) ";
                strSql += "AND DIM.DIM_VALOR = @p_Conteudo)";

                oParametros.Clear();
                foreach (Campo campo in Campos)
                {
                    if (campo.blnChave)
                    {
                        oParametros.Add(new SqlParameter("@p_CodigoServico", intCodigo));
                        oParametros.Add(new SqlParameter("@p_Conteudo", campo.strConteudo.Replace(".", "").Replace("-", "")));

                        dtServico = oAcessoBD.ConsultarSql(strSql, oParametros);
                        break;
                    }
                }
                return dtServico;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AssociarServico()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oAcessoBD.Conectar(false);
                oParametros.Clear();
                strSql = "DELETE FROM servicoReembolso";
                oAcessoBD.ExecutarSql(oParametros, strSql);
                oParametros.Clear();
                strSql = "INSERT INTO SERVICOREEMBOLSO (CODIGO) VALUES (@p_CodigoServico)";
                oParametros.Add(new SqlParameter("@p_CodigoServico", intCodigo));

                oAcessoBD.ExecutarSql(oParametros, strSql);
                oAcessoBD.Desconectar(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool ConsultarAssociacao()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                strSql = "SELECT codigo from servicoReembolso ";
                oParametros.Clear();


                dtServico = oAcessoBD.ConsultarSql(strSql, oParametros);
                if (dtServico.Rows.Count > 0)
                {
                    intCodigo = Convert.ToInt32(dtServico.Rows[0]["codigo"].ToString());
                }
                return dtServico.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
    public class Campo
    {
        public int intCodigo { get; set; }
        public string strDescricao { get; set; }
        public bool blnPreenchimento { get; set; }
        public bool blnChave { get; set; }
        public int intOrdem { get; set; }
        public int intPosicaoLayout { get; set; }
        public int intCodigoServico { get; set; }
        public int intCodigoTipoCampo { get; set; }
        public string strFormatoAlpha { get; set; }
        public string strMascaraAlpha { get; set; }
        public int intTamanho { get; set; }
        public double dblMinimo { get; set; }
        public double dblMaximo { get; set; }
        public int intCasasDecimais { get; set; }
        public bool blnSeparadorMilhar { get; set; }
        public DateTime dttMinima { get; set; }
        public DateTime dttMaxima { get; set; }
        public string strFormatoData { get; set; }
        public string strFormatoHora { get; set; }
        public string strConteudo { get; set; }
        public string strNomeArquivo { get; set; }

        public List<string> strOpcoes = new List<string>();
        public Campo()
        {
            intCodigo = 0;
            strDescricao = string.Empty;
            blnPreenchimento = true;
            blnChave = false;
            intOrdem = 0;
            intPosicaoLayout = 0;
            intCodigoServico = 0;
            intCodigoTipoCampo = 0;
            strFormatoAlpha = string.Empty;
            strMascaraAlpha = string.Empty;
            intTamanho = 0;
            dblMinimo = 0;
            dblMaximo = 0;
            dttMaxima = DateTime.Now;
            dttMinima = DateTime.Now;
            strFormatoData = string.Empty;
            strFormatoHora = string.Empty;
            strConteudo = string.Empty;
        }

        AcessoBD oAcessoBD = new AcessoBD();
        DataTable dtCampo = new DataTable();
        List<SqlParameter> oParametros = new List<SqlParameter>();

        string strSql = string.Empty;
        public List<string> Consultar()
        {
            //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
            List<string> strRetorno = new List<string>();
            try
            {
                strSql = "SELECT CPO_CODIGO, CPO_DESCRICAO, ";
                strSql += "CASE WHEN CPO_CHAVE = 1 THEN '(Chave)' else '' END AS CHAVE, ";
                strSql += "ISNULL(LIM.LIM_POSICAO, 0) LIM_POSICAO, ";
                strSql += "TTC.TTC_CODIGO, TTC_NOME, ";
                strSql += "CASE WHEN CPO_OBRIGATORIO = 1 THEN 'Obrigatório' ELSE 'Opcional' END AS PREENCHIMENTO ";
                strSql += "FROM TB_CAMPO_CPO CPO (NOLOCK) ";
                strSql += "INNER JOIN TB_TIPO_CAMPO_TTC TTC (NOLOCK) ON TTC.TTC_CODIGO = CPO.TTC_CODIGO ";
                strSql += "INNER JOIN TB_SERVICO_SER SER (NOLOCK) ON SER.SER_CODIGO = CPO.SER_CODIGO ";
                strSql += "LEFT JOIN TB_ASSOCIACAO_LAYOUT_DADOS_ALD ALD (NOLOCK) ON ALD.SER_CODIGO = CPO.SER_CODIGO AND ALD.CPO_ORDEM = CPO.CPO_ORDEM ";
                strSql += "LEFT JOIN TB_IMPORTACAO_IMP IMP (NOLOCK) ON IMP.IMP_CODIGO = ALD.IMP_CODIGO ";
                strSql += "LEFT JOIN TB_LAYOUT_IMPORTACAO_LIM LIM (NOLOCK) ON ALD.IMP_CODIGO = LIM.IMP_CODIGO AND ALD.LIM_POSICAO = LIM.LIM_POSICAO ";
                strSql += "WHERE CPO.SER_CODIGO = @p_CodigoServico AND TTC_ATIVO = 1 ORDER BY CPO.CPO_ORDEM";

                oParametros.Clear();
                oParametros.Add(new SqlParameter("@p_CodigoServico", intCodigoServico));

                dtCampo = oAcessoBD.ConsultarSql(strSql, oParametros);

                foreach (DataRow linha in dtCampo.Rows)
                {
                    DataTable dtConsulta = new DataTable();
                    intCodigo = Convert.ToInt32(linha[0]);
                    int intTotal = 0;
                    string strCampo = string.Empty;

                    strCampo += linha[1].ToString();
                    strCampo += "|" + linha[2].ToString();
                    strCampo += "|" + linha[3].ToString();
                    strCampo += "|" + linha[4].ToString();
                    strCampo += "|" + linha[5].ToString();
                    strCampo += "|" + linha[6].ToString();

                    oParametros.Clear();
                    oParametros.Add(new SqlParameter("@p_Codigo", intCodigo));

                    if ((int)linha[4] == (int)Funcoes.TipoCampo.Alphanumerico)
                    {
                        strSql = "SELECT ALP_FORMATO, ALP_MASCARA, ALP_TAMANHO FROM TB_ALPHANUMERICO_ALP (NOLOCK) WHERE CPO_CODIGO = @p_Codigo";
                        intTotal = 3;
                    }
                    else if ((int)linha[4] == (int)Funcoes.TipoCampo.Numerico)
                    {
                        strSql = "SELECT NUM_MINIMO, NUM_MAXIMO, NUM_DECIMAIS, NUM_MILHAR FROM TB_NUMERICO_NUM (NOLOCK) WHERE CPO_CODIGO = @p_Codigo";
                        intTotal = 4;
                    }
                    else if ((int)linha[4] == (int)Funcoes.TipoCampo.Data)
                    {
                        strSql = "SELECT DAT_MINIMA, DAT_MAXIMA, DAT_FORMATO FROM TB_DATA_DAT (NOLOCK) WHERE CPO_CODIGO = @p_Codigo";
                        intTotal = 3;
                    }
                    else if ((int)linha[4] == (int)Funcoes.TipoCampo.Hora)
                    {
                        strSql = "SELECT HOR_FORMATO FROM TB_HORA_HOR (NOLOCK) WHERE CPO_CODIGO = @p_Codigo";
                        intTotal = 1;
                    }
                    else if ((int)linha[4] == (int)Funcoes.TipoCampo.Opcoes)
                    {
                        strSql = "SELECT CBO_ITEM FROM TB_COMBOBOX_CBO (NOLOCK) WHERE CPO_CODIGO = @p_Codigo";

                        dtConsulta = oAcessoBD.ConsultarSql(strSql, oParametros);

                        foreach (DataRow campo in dtConsulta.Rows)
                        {
                            strCampo += "|" + campo[0].ToString();
                        }
                    }
                    if ((int)linha[4] != (int)Funcoes.TipoCampo.Opcoes)
                    {
                        dtConsulta = oAcessoBD.ConsultarSql(strSql, oParametros);
                        for (int intContador = 0; intContador < intTotal; intContador++)
                        {
                            strCampo += "|" + dtConsulta.Rows[0][intContador].ToString();
                        }
                    }
                    strCampo += "|" + intCodigo.ToString();
                    strRetorno.Add(strCampo);
                }

                return strRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
    public class Lote
    {
        public int intCodigo { get; set; }
        public string strLote { get; set; }
        public int intTotal { get; set; }
        public List<Imagem> Imagens = new List<Imagem>();
        public int intCodigoCaixa { get; set; }
        public string strCaixa { get; set; }
        public int intStatusLote { get; set; }
        public int intCodigoServico { get; set; }
        public Lote()
        {
            intCodigo = 0;
            strLote = string.Empty;
            intTotal = 0;
            intCodigoCaixa = 0;
            strCaixa = string.Empty;
            intStatusLote = 0;
            intCodigoServico = 0;
        }

        AcessoBD oAcessoBD = new AcessoBD();
        DataTable dtLote = new DataTable();
        List<SqlParameter> oParametros = new List<SqlParameter>();
        string strSql = string.Empty;
        public void RemoverLote()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oAcessoBD.Conectar(true);

                strSql = "DELETE FROM TB_IMAGEM_IMA WHERE LOT_CODIGO = @p_CodigoLote";
                oParametros.Clear();
                oParametros.Add(new SqlParameter("@p_CodigoLote", intCodigo));
                oAcessoBD.ExecutarSql(oParametros, strSql);

                strSql = "DELETE FROM TB_LOTE_LOT WHERE LOT_CODIGO = @p_Codigo";
                oParametros.Clear();
                oParametros.Add(new SqlParameter("@p_Codigo", intCodigo));
                oAcessoBD.ExecutarSql(oParametros, strSql);

                oAcessoBD.Desconectar(true);
            }
            catch (Exception ex)
            {
                oAcessoBD.RollBack();
                throw new Exception(ex.Message);
            }
        }
        public void GravarLote()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oAcessoBD.Conectar(true);

                oParametros.Clear();
                oParametros.Add(new SqlParameter("@p_Numero", strLote));
                oParametros.Add(new SqlParameter("@p_Total", intTotal));
                oParametros.Add(new SqlParameter("@p_Data", DateTime.Now));
                oParametros.Add(new SqlParameter("@p_CodigoCaixa", intCodigoCaixa));
                oParametros.Add(new SqlParameter("@p_StatusLote", intStatusLote));
                oParametros.Add(new SqlParameter("@p_CodigoUsuario", Funcoes.intCodigoUsuario));

                if (intCodigo == 0)
                {
                    strSql = "INSERT INTO TB_LOTE_LOT (LOT_NUMERO, LOT_TOTAL, LOT_DATA, CAI_CODIGO, SLO_CODIGO, USU_CODIGO) VALUES ";
                    strSql += "(@p_Numero, @p_Total, @p_Data, @p_CodigoCaixa, @p_StatusLote, @p_CodigoUsuario);SELECT @@IDENTITY";

                    intCodigo = oAcessoBD.ExecutarSql(strSql, oParametros);
                }
                else
                {
                    strSql = "UPDATE TB_LOTE_LOT SET ";
                    strSql += "LOT_NUMERO = @p_Numero, ";
                    strSql += "LOT_TOTAL = @p_Total,";
                    strSql += "LOT_DATA = @p_Data, ";
                    strSql += "CAI_CODIGO = @p_CodigoCaixa, ";
                    strSql += "SLO_CODIGO = @p_StatusLote, ";
                    strSql += "USU_CODIGO = @p_CodigoUsuario ";
                    strSql += "WHERE LOT_CODIGO = @p_Codigo";
                    oParametros.Add(new SqlParameter("@p_Codigo", intCodigo));

                    oAcessoBD.ExecutarSql(oParametros, strSql);
                }
                oAcessoBD.Desconectar(true);
            }
            catch (Exception ex)
            {
                oAcessoBD.RollBack();
                throw new Exception(ex.Message);
            }
        }
        public DataTable ConsultarLote(bool blnDigitacao)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                strSql = "SELECT LOT_CODIGO, LOT_NUMERO as Lote, LOT_TOTAL as Total, LOT_DATA as Data, ";
                strSql += "SLO_DESCRICAO as Status, SLO.SLO_CODIGO, CAI.CAI_CODIGO, CAI.CAI_NUMERO ";
                strSql += "FROM TB_LOTE_LOT LOT (NOLOCK) ";
                strSql += "INNER JOIN TB_STATUS_LOTE_SLO SLO (NOLOCK)  ON LOT.SLO_CODIGO = SLO.SLO_CODIGO ";
                strSql += "INNER JOIN TB_CAIXA_CAI CAI (NOLOCK) ON CAI.CAI_CODIGO = LOT.CAI_CODIGO ";

                oParametros.Clear();
                if (intCodigo != 0)
                {
                    strSql += "WHERE LOT.LOT_CODIGO = @p_Codigo ";
                    oParametros.Add(new SqlParameter("@p_Codigo", intCodigo));
                }
                else if (intCodigoCaixa != 0)
                {
                    strSql += "WHERE CAI.CAI_CODIGO = @p_CodigoCaixa ";
                    oParametros.Add(new SqlParameter("@p_CodigoCaixa", intCodigoCaixa));
                }
                else if (intCodigoServico != 0)
                {
                    strSql += "WHERE SER_CODIGO = @p_CodigoServico ";
                    oParametros.Add(new SqlParameter("@p_CodigoServico", intCodigoServico));
                }
                if (blnDigitacao)
                {
                    strSql += "AND EXISTS (SELECT 1 FROM TB_IMAGEM_IMA IMA (NOLOCK) WHERE IMA.LOT_CODIGO = LOT.LOT_CODIGO AND SIM_CODIGO = 2) ";
                    strSql += "AND SLO.SLO_CODIGO in (@p_StatusLote) ";
                    oParametros.Add(new SqlParameter("@p_StatusLote", (int)Funcoes.StatusLote.AguardandoDigitacao));
                }

                strSql += "ORDER BY LOT_NUMERO";

                dtLote = oAcessoBD.ConsultarSql(strSql, oParametros);

                if (intCodigo != 0 && dtLote.Rows.Count != 0)
                {
                    intStatusLote = Convert.ToInt32(dtLote.Rows[0]["SLO_CODIGO"]);
                    strLote = dtLote.Rows[0]["Lote"].ToString();
                    intTotal = Convert.ToInt32(dtLote.Rows[0]["Total"]);
                    intCodigoCaixa = Convert.ToInt32(dtLote.Rows[0]["CAI_CODIGO"]);
                    strCaixa = dtLote.Rows[0]["CAI_NUMERO"].ToString();
                }

                return dtLote;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ConsultarLote(int StatusLote = 0)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                strSql = "SELECT LOT_CODIGO, LOT_NUMERO, SLO_DESCRICAO ";
                strSql += "FROM TB_LOTE_LOT LOT (NOLOCK) ";
                strSql += "INNER JOIN TB_STATUS_LOTE_SLO SLO (NOLOCK) ON LOT.SLO_CODIGO = SLO.SLO_CODIGO ";
                strSql += "INNER JOIN TB_CAIXA_CAI CAI (NOLOCK) ON CAI.CAI_CODIGO = LOT.CAI_CODIGO ";
                strSql += "WHERE CAI.SER_CODIGO = @p_CodigoServico ";

                oParametros.Clear();
                if (StatusLote != 0)
                {
                    strSql += "AND SLO.SLO_CODIGO = @p_StatusLote ";
                    oParametros.Add(new SqlParameter("@p_StatusLote", StatusLote));
                }
                if (intCodigoCaixa != 0)
                {
                    strSql += "AND LOT.CAI_CODIGO = @p_CodigoCaixa ";
                    oParametros.Add(new SqlParameter("@p_CodigoCaixa", intCodigoCaixa));
                }
                strSql += "ORDER BY LOT_NUMERO";

                oParametros.Add(new SqlParameter("@p_CodigoServico", intCodigoServico));

                dtLote = oAcessoBD.ConsultarSql(strSql, oParametros);

                return dtLote;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarImagens(bool blnVinculadas)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oParametros.Clear();
                strSql = "SELECT IMA_NOME_ARQUIVO, IMA_PARENT, IMA_DOCUMENTO_PAI, IMA_IMPRESSO, IMA_PCMSO, ";
                strSql += "IMA_APTO, IMA_ALTURA, IMA_CARIMBO, IMA_CONTATO, IMA_ASSINATURA, IMA_DATAS, IMA_DIGITAL, 0 AS ORDEM ";
                strSql += "FROM TB_IMAGEM_IMA IMA (NOLOCK) ";
                strSql += "INNER JOIN TB_LOTE_LOT LOT (NOLOCK) ON LOT.LOT_CODIGO = IMA.LOT_CODIGO ";
                strSql += "INNER JOIN TB_CAIXA_CAI CAI (NOLOCK) ON CAI.CAI_CODIGO = LOT.CAI_CODIGO ";
                strSql += "WHERE LOT.LOT_CODIGO = @p_Codigo ";
                strSql += "AND IMA_NOME_ARQUIVO = CAI.CAI_NUMERO + '_' + LOT.LOT_NUMERO + '_' + LOT.LOT_NUMERO ";

                strSql += "UNION ";

                strSql += "SELECT IMA_NOME_ARQUIVO, IMA_PARENT, IMA_DOCUMENTO_PAI, IMA_IMPRESSO, IMA_PCMSO, ";
                strSql += "IMA_APTO, IMA_ALTURA, IMA_CARIMBO, IMA_CONTATO, IMA_ASSINATURA, IMA_DATAS, IMA_DIGITAL, 1 AS ORDEM ";
                strSql += "FROM TB_IMAGEM_IMA IMA (NOLOCK) ";
                strSql += "INNER JOIN TB_LOTE_LOT LOT (NOLOCK) ON LOT.LOT_CODIGO = IMA.LOT_CODIGO ";
                strSql += "INNER JOIN TB_CAIXA_CAI CAI (NOLOCK) ON CAI.CAI_CODIGO = LOT.CAI_CODIGO ";
                strSql += "WHERE LOT.LOT_CODIGO = @p_Codigo ";
                strSql += "AND IMA_NOME_ARQUIVO != CAI.CAI_NUMERO + '_' + LOT.LOT_NUMERO + '_' + LOT.LOT_NUMERO ";

                if (!blnVinculadas)
                {
                    strSql += "AND SIM_CODIGO = @p_StatusImagem ";
                    strSql += "AND IMA_PARENT = @p_DocumentoPai ";
                    oParametros.Add(new SqlParameter("@p_StatusImagem", (int)Funcoes.StatusImagem.AguardandoDigitacao));
                    oParametros.Add(new SqlParameter("@p_DocumentoPai", true));
                }
                strSql += "ORDER BY ORDEM, IMA_PARENT DESC, IMA_NOME_ARQUIVO";
                oAcessoBD.Conectar(true);
                oParametros.Add(new SqlParameter("@p_Codigo", intCodigo));
                dtLote = oAcessoBD.ConsultarSql(strSql, oParametros);
                Imagens.Clear();
                foreach (DataRow linha in dtLote.Rows)
                {
                    Imagem oImagem = new Imagem();
                    oImagem.intCodigoLote = intCodigo;
                    oImagem.strNomeArquivo = linha[0].ToString();
                    oImagem.blnParent = Convert.ToBoolean(linha[1]);
                    oImagem.strArquivoPai = linha[2].ToString();
                    oImagem.blnImpresso = Convert.ToBoolean(linha[3]);
                    oImagem.blnPCMSO = Convert.ToBoolean(linha[4]);
                    oImagem.blnApto = Convert.ToBoolean(linha[5]);
                    oImagem.blnAltura = Convert.ToBoolean(linha[6]);
                    oImagem.blnCarimbo = Convert.ToBoolean(linha[7]);
                    oImagem.blnContato = Convert.ToBoolean(linha[8]);
                    oImagem.blnAssinatura = Convert.ToBoolean(linha[9]);
                    oImagem.blnDatas = Convert.ToBoolean(linha[10]);
                    oImagem.blnDigital = Convert.ToBoolean(linha[11]);
                    if (oImagem.blnParent)
                    {
                        oImagem.ConsultarFilhos();
                    }
                    Imagens.Add(oImagem);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oAcessoBD.Desconectar(true);
            }
        }
        public void AlterarStatus()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oAcessoBD.Conectar(true);
                oParametros.Clear();
                strSql = "UPDATE TB_LOTE_LOT SET SLO_CODIGO = @p_Status ";
                if (intCodigo != 0)
                {
                    strSql += "WHERE LOT_CODIGO = @p_Codigo";
                    oParametros.Add(new SqlParameter("@p_Codigo", intCodigo));
                }
                else if (strLote != string.Empty)
                {
                    strSql += "WHERE CAI_CODIGO = @p_CodigoCaixa ";
                    strSql += "AND LOT_NUMERO = @p_Lote";
                    oParametros.Add(new SqlParameter("@p_CodigoCaixa", intCodigoCaixa));
                    oParametros.Add(new SqlParameter("@p_Lote", strLote));
                }
                oParametros.Add(new SqlParameter("@p_Status", intStatusLote));

                oAcessoBD.ExecutarSql(oParametros, strSql);

                if (intCodigo == 0)
                {
                    strSql = "SELECT LOT_CODIGO FROM TB_LOTE_LOT (NOLOCK) WHERE CAI_CODIGO = @p_CodigoCaixa AND LOT_NUMERO = @p_Lote";
                    oParametros.Clear();
                    oParametros.Add(new SqlParameter("@p_Lote", strLote));
                    oParametros.Add(new SqlParameter("@p_CodigoCaixa", intCodigoCaixa));
                    intCodigo = oAcessoBD.ExecutarSql(strSql, oParametros);
                }

                if (intStatusLote == (int)Funcoes.StatusLote.AguardandoUpload || intStatusLote == (int)Funcoes.StatusLote.Finalizado)
                {
                    strSql = "UPDATE TB_IMAGEM_IMA SET SIM_CODIGO = @p_StatusImagem WHERE LOT_CODIGO = @p_CodigoLote";
                    oParametros.Clear();
                    oParametros.Add(new SqlParameter("@p_CodigoLote", intCodigo));
                    oParametros.Add(new SqlParameter("@p_StatusImagem", intStatusLote == (int)Funcoes.StatusLote.AguardandoUpload ? (int)Funcoes.StatusImagem.AguardandoUpload : (int)Funcoes.StatusImagem.Finalizada));
                    oAcessoBD.ExecutarSql(strSql, oParametros);
                }


                strSql = "INSERT INTO TB_HIST_LOTE_THL (THL_DATA, LOT_CODIGO, SLO_CODIGO, USU_CODIGO) VALUES ";
                strSql += "(@p_Data, @p_CodigoLote, @p_CodigoStatus, @p_CodigoUsuario)";
                oParametros.Clear();
                oParametros.Add(new SqlParameter("@p_Data", DateTime.Now));
                oParametros.Add(new SqlParameter("@p_CodigoStatus", intStatusLote));
                oParametros.Add(new SqlParameter("@p_CodigoLote", intCodigo));
                oParametros.Add(new SqlParameter("@p_CodigoUsuario", Funcoes.intCodigoUsuario));

                oAcessoBD.ExecutarSql(strSql, oParametros);

                oAcessoBD.Desconectar(true);
            }
            catch (Exception ex)
            {
                oAcessoBD.RollBack();
                throw new Exception(ex.Message);
            }
        }
        public void AlterarStatusImagem()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oAcessoBD.Conectar(true);

                foreach (Imagem oImagem in Imagens)
                {
                    strSql = "UPDATE TB_IMAGEM_IMA SET SIM_CODIGO = @p_StatusImagem ";
                    strSql += "WHERE IMA_NOME_ARQUIVO = @p_Imagem ";
                    strSql += "AND LOT_CODIGO = @p_CodigoLote";
                    oParametros.Clear();
                    oParametros.Add(new SqlParameter("@p_StatusImagem", oImagem.intStatus));
                    oParametros.Add(new SqlParameter("@p_Imagem", oImagem.strNomeArquivo));
                    oParametros.Add(new SqlParameter("@p_CodigoLote", intCodigo));

                    oAcessoBD.ExecutarSql(oParametros, strSql);
                }

                oAcessoBD.Desconectar(true);
            }
            catch (Exception ex)
            {
                oAcessoBD.RollBack();
                throw new Exception(ex.Message);
            }
        }
        public void AlterarStatusImagem(Imagem oImagem)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oAcessoBD.Conectar(true);

                strSql = "UPDATE TB_IMAGEM_IMA SET SIM_CODIGO = @p_StatusImagem ";
                strSql += "WHERE IMA_NOME_ARQUIVO = @p_Imagem ";
                strSql += "AND LOT_CODIGO = @p_CodigoLote";
                oParametros.Clear();
                oParametros.Add(new SqlParameter("@p_StatusImagem", oImagem.intStatus));
                oParametros.Add(new SqlParameter("@p_Imagem", oImagem.strNomeArquivo));
                oParametros.Add(new SqlParameter("@p_CodigoLote", intCodigo));

                oAcessoBD.ExecutarSql(oParametros, strSql);

                strSql = "SELECT IMA_CODIGO FROM TB_IMAGEM_IMA (NOLOCK) WHERE IMA_NOME_ARQUIVO = @p_Imagem AND LOT_CODIGO = @p_CodigoLote";
                oParametros.Clear();
                oParametros.Add(new SqlParameter("@p_Imagem", oImagem.strNomeArquivo));
                oParametros.Add(new SqlParameter("@p_CodigoLote", intCodigo));

                int intCodigoImagem = oAcessoBD.ExecutarSql(strSql, oParametros);

                oParametros.Clear();
                strSql = "INSERT INTO TB_HIST_IMAGEM_HIM (HIM_DATA, IMA_CODIGO, SIM_CODIGO, USU_CODIGO)";
                strSql += "VALUES (@p_Data, @p_CodigoImagem, @p_StatusImagem, @p_CodigoUsuario)";

                oParametros.Add(new SqlParameter("@p_Data", DateTime.Now));
                oParametros.Add(new SqlParameter("@p_StatusImagem", oImagem.intStatus));
                oParametros.Add(new SqlParameter("@p_CodigoImagem", intCodigoImagem));
                oParametros.Add(new SqlParameter("@p_CodigoUsuario", Funcoes.intCodigoUsuario));

                oAcessoBD.ExecutarSql(oParametros, strSql);

                oAcessoBD.Desconectar(true);
            }
            catch (Exception ex)
            {
                oAcessoBD.RollBack();
                throw new Exception(ex.Message);
            }
        }
        public void GravarImagens()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oAcessoBD.Conectar(true);

                strSql = "DELETE FROM TB_IMAGEM_IMA WHERE LOT_CODIGO = @p_CodigoLote";
                oParametros.Clear();
                oParametros.Add(new SqlParameter("@p_CodigoLote", intCodigo));

                oAcessoBD.ExecutarSql(oParametros, strSql);

                foreach (Imagem imagem in Imagens)
                {
                    strSql = "INSERT INTO TB_IMAGEM_IMA (IMA_NOME_ARQUIVO, IMA_ARQUIVO, IMA_PARENT, IMA_DOCUMENTO_PAI, IMA_IMPRESSO, IMA_PCMSO, ";
                    strSql += "IMA_APTO, IMA_ALTURA, IMA_CARIMBO, IMA_CONTATO, IMA_ASSINATURA, IMA_DATAS, IMA_DIGITAL, LOT_CODIGO, SIM_CODIGO) VALUES ";
                    strSql += "(@p_NomeArquivo, @p_Arquivo, @p_DocumentoPai, @p_ArquivoPai, @p_Impresso, @p_PCMSO, ";
                    strSql += "@p_Apto, @p_Altura, @p_Carimbo, @p_Contato, @p_Assinatura, @p_Datas, @p_Digital, @p_CodigoLote, @p_StatusImagem)";

                    oParametros.Clear();
                    oParametros.Add(new SqlParameter("@p_NomeArquivo", imagem.strNomeArquivo));
                    if (imagem.bytImagem != null)
                    {
                        oParametros.Add(new SqlParameter("@p_Arquivo", imagem.bytImagem));
                    }
                    else
                    {
                        strSql = strSql.Replace("@p_Arquivo, ", "");
                        strSql = strSql.Replace("IMA_ARQUIVO, ", "");
                    }
                    oParametros.Add(new SqlParameter("@p_DocumentoPai", imagem.blnParent));
                    oParametros.Add(new SqlParameter("@p_ArquivoPai", imagem.strArquivoPai));
                    oParametros.Add(new SqlParameter("@p_Impresso", imagem.blnImpresso));
                    oParametros.Add(new SqlParameter("@p_PCMSO", imagem.blnPCMSO));
                    oParametros.Add(new SqlParameter("@p_Apto", imagem.blnApto));
                    oParametros.Add(new SqlParameter("@p_Altura", imagem.blnAltura));
                    oParametros.Add(new SqlParameter("@p_Carimbo", imagem.blnCarimbo));
                    oParametros.Add(new SqlParameter("@p_Contato", imagem.blnContato));
                    oParametros.Add(new SqlParameter("@p_Assinatura", imagem.blnAssinatura));
                    oParametros.Add(new SqlParameter("@p_Datas", imagem.blnDatas));
                    oParametros.Add(new SqlParameter("@p_Digital", imagem.blnDigital));
                    oParametros.Add(new SqlParameter("@p_CodigoLote", intCodigo));
                    oParametros.Add(new SqlParameter("@p_StatusImagem", imagem.intStatus));

                    oAcessoBD.ExecutarSql(oParametros, strSql);
                }
                oAcessoBD.Desconectar(true);
            }
            catch (Exception ex)
            {
                oAcessoBD.RollBack();
                throw new Exception(ex.Message);
            }
        }
        public int ContarImagensCaixa(bool blnLote)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oParametros.Clear();
                strSql = "SELECT COUNT(IMA_NOME_ARQUIVO) FROM TB_IMAGEM_IMA IMA (NOLOCK) ";
                strSql += "INNER JOIN TB_LOTE_LOT LOT (NOLOCK) ON IMA.LOT_CODIGO = LOT.LOT_CODIGO ";
                strSql += "WHERE LOT.CAI_CODIGO = @p_CodigoCaixa ";
                if (blnLote)
                {
                    strSql += "AND LOT.LOT_CODIGO != @p_Codigo";
                    oParametros.Add(new SqlParameter("@p_Codigo", intCodigo));
                }
                oParametros.Add(new SqlParameter("@p_CodigoCaixa", intCodigoCaixa));
                oAcessoBD.Conectar(false);
                int intRetorno = oAcessoBD.ExecutarSql(strSql, oParametros);
                oAcessoBD.Desconectar(false);
                return intRetorno;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ExcluirImagens()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oAcessoBD.Conectar(false);
                strSql = "DELETE FROM TB_IMAGEM_IMA WHERE LOT_CODIGO = @p_CodigoLote AND IMA_ARQUIVO IS NULL";
                oParametros.Clear();
                oParametros.Add(new SqlParameter("@p_CodigoLote", intCodigo));
                oAcessoBD.ExecutarSql(strSql, oParametros);
                oAcessoBD.Desconectar(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
    public class Imagem
    {
        public string strNomeArquivo { get; set; }
        public int intStatus { get; set; }
        public bool blnParent { get; set; }
        public string strArquivoPai { get; set; }
        public byte[] bytImagem { get; set; }
        public bool blnImpresso { get; set; }
        public bool blnPCMSO { get; set; }
        public bool blnApto { get; set; }
        public bool blnAltura { get; set; }
        public bool blnCarimbo { get; set; }
        public bool blnContato { get; set; }
        public bool blnAssinatura { get; set; }
        public bool blnDatas { get; set; }
        public bool blnDigital { get; set; }
        public int intCodigoLote { get; set; }
        public List<string> filhos = new List<string>();
        public Imagem()
        {
            strNomeArquivo = string.Empty;
            intStatus = 0;
            bytImagem = null;
            blnParent = true;
            strArquivoPai = string.Empty;
            intCodigoLote = 0;
            blnImpresso = false;
            blnPCMSO = false;
            blnApto = false;
            blnAltura = false;
            blnCarimbo = false;
            blnContato = false;
            blnAssinatura = false;
            blnDatas = false;
            blnDigital = false;
        }
        AcessoBD oAcessoBD = new AcessoBD();
        List<SqlParameter> oParametros = new List<SqlParameter>();
        DataTable dtImagem = new DataTable();
        string strSql = string.Empty;
        public void GravarImagem()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oAcessoBD.Conectar(false);
                oParametros.Clear();
                oParametros.Add(new SqlParameter("@p_NomeArquivo", strNomeArquivo));
                oParametros.Add(new SqlParameter("@p_Arquivo", bytImagem));
                //oParametros.Add(new SqlParameter("@p_Status", intStatus));
                //strSql = "UPDATE TB_IMAGEM_IMA SET IMA_ARQUIVO = @p_Arquivo, SIM_CODIGO = @p_Status WHERE IMA_NOME_ARQUIVO = @p_NomeArquivo";
                strSql = "UPDATE TB_IMAGEM_IMA SET IMA_ARQUIVO = @p_Arquivo WHERE IMA_NOME_ARQUIVO = @p_NomeArquivo";

                oAcessoBD.ExecutarSql(oParametros, strSql);
                oAcessoBD.Desconectar(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarImagem(bool blnDigitacao)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oAcessoBD.Conectar(false);
                oParametros.Clear();
                oParametros.Add(new SqlParameter("@p_NomeArquivo", strNomeArquivo));
                strSql = "SELECT IMA_CODIGO, LOT_CODIGO, SIM_CODIGO, IMA_ARQUIVO, IMA_PARENT, IMA_DOCUMENTO_PAI, ";
                strSql += "IMA_IMPRESSO, IMA_PCMSO, IMA_APTO, IMA_ALTURA, IMA_CARIMBO, IMA_CONTATO, IMA_ASSINATURA, IMA_DATAS, IMA_DIGITAL ";
                strSql += "FROM TB_IMAGEM_IMA (NOLOCK) WHERE IMA_NOME_ARQUIVO = @p_NomeArquivo ";
                if (blnDigitacao)
                {
                    strSql += "AND SIM_CODIGO = 2 ";
                }
                if (intCodigoLote != 0)
                {
                    strSql += "AND LOT_CODIGO = @p_CodigoLote";
                    oParametros.Add(new SqlParameter("@p_CodigoLote", intCodigoLote));
                }

                dtImagem = oAcessoBD.ConsultarSql(strSql, oParametros);

                if (dtImagem.Rows.Count > 0)
                {
                    intStatus = Convert.ToInt32(dtImagem.Rows[0]["SIM_CODIGO"]);
                    if (dtImagem.Rows[0]["IMA_ARQUIVO"].ToString() != string.Empty)
                    {
                        bytImagem = (Byte[])(dtImagem.Rows[0]["IMA_ARQUIVO"]);
                    }
                    strArquivoPai = dtImagem.Rows[0]["IMA_DOCUMENTO_PAI"].ToString();
                    blnParent = Convert.ToBoolean(dtImagem.Rows[0]["IMA_PARENT"]);
                    blnImpresso = Convert.ToBoolean(dtImagem.Rows[0]["IMA_PARENT"]);
                    blnPCMSO = Convert.ToBoolean(dtImagem.Rows[0]["IMA_PCMSO"]);
                    blnApto = Convert.ToBoolean(dtImagem.Rows[0]["IMA_APTO"]);
                    blnAltura = Convert.ToBoolean(dtImagem.Rows[0]["IMA_ALTURA"]);
                    blnCarimbo = Convert.ToBoolean(dtImagem.Rows[0]["IMA_CARIMBO"]);
                    blnContato = Convert.ToBoolean(dtImagem.Rows[0]["IMA_CONTATO"]);
                    blnAssinatura = Convert.ToBoolean(dtImagem.Rows[0]["IMA_ASSINATURA"]);
                    blnDatas = Convert.ToBoolean(dtImagem.Rows[0]["IMA_DATAS"]);
                    blnDigital = Convert.ToBoolean(dtImagem.Rows[0]["IMA_DIGITAL"]);
                    if (blnParent)
                    {
                        ConsultarFilhos();
                    }
                }

                oAcessoBD.Desconectar(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ExcluirImagens()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oAcessoBD.Conectar(false);
                strSql = "DELETE FROM TB_IMAGEM_IMA WHERE IMA_NOME_ARQUIVO = @p_NomeArquivo AND IMA_ARQUIVO IS NULL AND SIM_CODIGO = 1 AND LOT_CODIGO = @p_CodigoLote";
                oParametros.Clear();
                oParametros.Add(new SqlParameter("@p_CodigoLote", intCodigoLote));
                oParametros.Add(new SqlParameter("@p_NomeArquivo", strNomeArquivo));

                oAcessoBD.ExecutarSql(oParametros, strSql);
                oAcessoBD.Desconectar(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarFilhos()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oAcessoBD.Conectar(false);
                strSql = "SELECT IMA_NOME_ARQUIVO FROM TB_IMAGEM_IMA (NOLOCK) WHERE IMA_DOCUMENTO_PAI = @p_NomeArquivo AND LOT_CODIGO = @p_CodigoLote";
                oParametros.Clear();
                oParametros.Add(new SqlParameter("@p_CodigoLote", intCodigoLote));
                oParametros.Add(new SqlParameter("@p_NomeArquivo", strNomeArquivo));

                dtImagem = oAcessoBD.ConsultarSql(strSql, oParametros);
                filhos.Clear();
                foreach (DataRow linha in dtImagem.Rows)
                {
                    filhos.Add(linha[0].ToString());
                }

                oAcessoBD.Desconectar(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
    public class Caixa
    {
        public int intCodigo { get; set; }
        public string strCaixa { get; set; }
        public string strEmpresa { get; set; }
        public int intQtdeImagens { get; set; }
        public int intCodigoUsuario { get; set; }
        public int intStatusCaixa { get; set; }
        public int intCodigoServico { get; set; }
        public Caixa()
        {
            intCodigo = 0;
            strCaixa = string.Empty;
            strEmpresa = string.Empty;
            intQtdeImagens = 0;
            intCodigoUsuario = 0;
            intStatusCaixa = 0;
            intCodigoServico = 0;
        }

        AcessoBD oAcessoBD = new AcessoBD();
        DataTable dtCaixa = new DataTable();
        List<SqlParameter> oParametros = new List<SqlParameter>();
        string strSql = string.Empty;

        public DataTable ConsultarCaixa(bool blnCD = false)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oParametros.Clear();
                strSql = "SELECT CAI_CODIGO, CAI_NUMERO Caixa, CAI_EMPRESA Empresa, CAI.SCA_CODIGO ";
                strSql += "FROM TB_CAIXA_CAI CAI (NOLOCK) ";
                strSql += "INNER JOIN TB_STATUS_CAIXA_SCA SCA (NOLOCK) ON SCA.SCA_CODIGO = CAI.SCA_CODIGO ";
                strSql += "WHERE SER_CODIGO = @p_CodigoServico ";
                strSql += string.Format("AND CAI.SCA_CODIGO {0} @p_StatusCaixa ", blnCD ? "=" : "!=");

                if (intCodigo != 0)
                {
                    strSql += "AND CAI_CODIGO = @p_Codigo ";
                    oParametros.Add(new SqlParameter("@p_Codigo", intCodigo));
                }
                else if (strCaixa != string.Empty)
                {
                    strSql += "AND CAI_NUMERO = @p_Caixa ";
                    oParametros.Add(new SqlParameter("@p_Caixa", strCaixa));
                }
                oParametros.Add(new SqlParameter("@p_StatusCaixa", (int)Funcoes.StatusCaixa.Finalizada));
                oParametros.Add(new SqlParameter("@p_CodigoServico", intCodigoServico));
                dtCaixa = oAcessoBD.ConsultarSql(strSql, oParametros);

                if (intCodigo != 0 || (strCaixa != string.Empty && dtCaixa.Rows.Count > 0))
                {
                    intCodigo = Convert.ToInt32(dtCaixa.Rows[0]["CAI_CODIGO"]);
                    strEmpresa = dtCaixa.Rows[0]["Empresa"].ToString();
                    strCaixa = dtCaixa.Rows[0]["Caixa"].ToString();
                    intStatusCaixa = Convert.ToInt32(dtCaixa.Rows[0]["SCA_CODIGO"]);
                }

                return dtCaixa;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void GravarCaixa()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oAcessoBD.Conectar(false);

                oParametros.Clear();
                oParametros.Add(new SqlParameter("@p_Empresa", strEmpresa));
                oParametros.Add(new SqlParameter("@p_CodigoServico", intCodigoServico));
                oParametros.Add(new SqlParameter("@p_StatusCaixa", intStatusCaixa));
                oParametros.Add(new SqlParameter("@p_CodigoUsuario", Funcoes.intCodigoUsuario));

                if (intCodigo == 0)
                {
                    strSql = "INSERT INTO TB_CAIXA_CAI (CAI_NUMERO, CAI_EMPRESA, SCA_CODIGO, SER_CODIGO, USU_CODIGO) ";
                    strSql += "VALUES (@p_Numero, @p_Empresa, @p_StatusCaixa, @p_CodigoServico, @p_CodigoUsuario);SELECT @@IDENTITY";
                    oParametros.Add(new SqlParameter("@p_Numero", strCaixa));

                    intCodigo = oAcessoBD.ExecutarSql(strSql, oParametros);
                }
                else
                {
                    strSql = "UPDATE TB_CAIXA_CAI SET ";
                    strSql += "CAI_EMPRESA = @p_Empresa, ";
                    strSql += "CAI_QTDE = (SELECT COUNT(1) FROM TB_IMAGEM_IMA (NOLOCK) WHERE LOT_CODIGO IN (SELECT LOT_CODIGO FROM TB_LOTE_LOT (NOLOCK) WHERE CAI_CODIGO = @p_Codigo)), ";
                    strSql += "SCA_CODIGO = @p_StatusCaixa, ";
                    strSql += "SER_CODIGO = @p_CodigoServico, ";
                    strSql += "USU_CODIGO = @p_CodigoUsuario ";
                    strSql += "WHERE CAI_CODIGO = @p_Codigo";
                    oParametros.Add(new SqlParameter("@p_Codigo", intCodigo));

                    oAcessoBD.ExecutarSql(oParametros, strSql);
                }
                oAcessoBD.Desconectar(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool ConsultarCaixaFechada()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                bool blnResultado = false;
                strSql = "SELECT CAI.CAI_CODIGO, CAI_NUMERO, CAI_QTDE, SCA_CODIGO, SER_CODIGO, CAI.USU_CODIGO, CAI_EMPRESA FROM TB_CAIXA_CAI CAI (NOLOCK) ";
                strSql += "INNER JOIN TB_LOTE_LOT LOT (NOLOCK) ON CAI.CAI_CODIGO = LOT.CAI_CODIGO ";
                strSql += "WHERE CAI.CAI_CODIGO = @p_Codigo AND LOT.SLO_CODIGO IN (@p_Digitacao, @p_Digitalizacao) ";
                oParametros.Clear();
                oParametros.Add(new SqlParameter("@p_Codigo", intCodigo));
                oParametros.Add(new SqlParameter("@p_Digitacao", (int)Funcoes.StatusLote.EmDigitacao));
                oParametros.Add(new SqlParameter("@p_Digitalizacao", (int)Funcoes.StatusLote.EmDigitalizacao));

                dtCaixa = oAcessoBD.ConsultarSql(strSql, oParametros);

                if (dtCaixa.Rows.Count == 0)
                {
                    blnResultado = true;
                }

                return blnResultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void RemoverCaixa()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oAcessoBD.Conectar(true);
                strSql = "DELETE FROM TB_IMAGEM_IMA WHERE LOT_CODIGO IN ";
                strSql += "(SELECT LOT_CODIGO FROM TB_LOTE_LOT (NOLOCK) WHERE CAI_CODIGO = @p_Codigo)";
                oParametros.Clear();
                oParametros.Add(new SqlParameter("@p_Codigo", intCodigo));
                oAcessoBD.ExecutarSql(oParametros, strSql);

                strSql = "DELETE FROM TB_LOTE_LOT WHERE CAI_CODIGO = @p_Codigo";
                oParametros.Clear();
                oParametros.Add(new SqlParameter("@p_Codigo", intCodigo));
                oAcessoBD.ExecutarSql(oParametros, strSql);

                strSql = "DELETE FROM TB_CAIXA_CAI WHERE CAI_CODIGO = @p_Codigo";
                oParametros.Clear();
                oParametros.Add(new SqlParameter("@p_Codigo", intCodigo));
                oAcessoBD.ExecutarSql(oParametros, strSql);

                oAcessoBD.Desconectar(true);
            }
            catch (Exception ex)
            {
                oAcessoBD.RollBack();
                throw new Exception(ex.Message);
            }
        }
    }
    public class Layout
    {
        public int intCodigo { get; set; }
        public string strNome { get; set; }
        public bool blnDuplicado { get; set; }

        public List<CampoLayout> Campos = new List<CampoLayout>();

        public Layout()
        {
            intCodigo = 0;
            strNome = string.Empty;
            blnDuplicado = false;
        }

        AcessoBD oAcessoBD = new AcessoBD();
        DataTable dtLayout = new DataTable();
        List<SqlParameter> oParametros = new List<SqlParameter>();
        string strSql = string.Empty;
        public void Gravar()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                if (this.intCodigo == 0)
                {
                    oAcessoBD.Conectar(true);
                    //Cadastrando o Serviço
                    strSql = "INSERT INTO TB_IMPORTACAO_IMP (IMP_NOME_LAYOUT) VALUES (@p_NomeLayout);SELECT @@IDENTITY";

                    oParametros.Clear();
                    oParametros.Add(new SqlParameter("@p_NomeLayout", strNome));

                    intCodigo = oAcessoBD.ExecutarSql(strSql, oParametros);

                }
                else
                {
                    oAcessoBD.Conectar(true);
                    strSql = "UPDATE TB_IMPORTACAO_IMP SET IMP_NOME_LAYOUT = @p_NomeLayout WHERE IMP_CODIGO = @p_Codigo";
                    oParametros.Clear();
                    oParametros.Add(new SqlParameter("@p_Codigo", intCodigo));
                    oParametros.Add(new SqlParameter("@p_NomeLayout", strNome));

                    oAcessoBD.ExecutarSql(oParametros, strSql);

                    strSql = "DELETE FROM TB_LAYOUT_IMPORTACAO_LIM WHERE IMP_CODIGO = @p_CodigoImportacao";
                    oParametros.Clear();
                    oParametros.Add(new SqlParameter("@p_CodigoImportacao", intCodigo));

                    oAcessoBD.ExecutarSql(oParametros, strSql);
                }

                foreach (CampoLayout campo in Campos)
                {
                    strSql = "INSERT INTO TB_LAYOUT_IMPORTACAO_LIM (LIM_POSICAO, LIM_CAMPO, LIM_IMPORTAR, LIM_CHAVE, IMP_CODIGO) ";
                    strSql += "VALUES (@p_Posicao, @p_Campo, @p_Importar, @p_Chave, @p_CodigoLayout)";

                    oParametros.Clear();

                    oParametros.Add(new SqlParameter("@p_Posicao", campo.intPosicao));
                    oParametros.Add(new SqlParameter("@p_Campo", campo.strNome));
                    oParametros.Add(new SqlParameter("@p_Importar", campo.blnImportar));
                    oParametros.Add(new SqlParameter("@p_Chave", campo.blnChave));
                    oParametros.Add(new SqlParameter("@p_CodigoLayout", intCodigo));

                    oAcessoBD.ExecutarSql(oParametros, strSql);
                }
                oAcessoBD.Desconectar(true);
            }
            catch (Exception ex)
            {
                oAcessoBD.RollBack();
                throw new Exception(ex.Message);
            }
        }

        public void Consultar()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                strSql = "SELECT LIM_CODIGO, LIM_POSICAO, LIM_CAMPO, LIM_IMPORTAR, LIM_CHAVE FROM TB_LAYOUT_IMPORTACAO_LIM (NOLOCK) WHERE IMP_CODIGO = @p_CodigoLayout";
                oParametros.Clear();
                oParametros.Add(new SqlParameter("@p_CodigoLayout", intCodigo));
                dtLayout = oAcessoBD.ConsultarSql(strSql, oParametros);
                Campos.Clear();
                foreach (DataRow linha in dtLayout.Rows)
                {
                    CampoLayout oCampo = new CampoLayout();
                    oCampo.intCodigo = Convert.ToInt32(linha["LIM_CODIGO"]);
                    oCampo.intPosicao = Convert.ToInt32(linha["LIM_POSICAO"]);
                    oCampo.strNome = linha["LIM_CAMPO"].ToString();
                    oCampo.blnImportar = Convert.ToBoolean(linha["LIM_IMPORTAR"]);
                    oCampo.blnChave = Convert.ToBoolean(linha["LIM_CHAVE"]);
                    Campos.Add(oCampo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
    public class CampoLayout
    {
        public int intCodigo { get; set; }
        public int intPosicao { get; set; }
        public string strNome { get; set; }
        public bool blnImportar { get; set; }
        public bool blnChave { get; set; }
        public int intCodigoLayout { get; set; }
        public string strConteudo { get; set; }
        public int intCodigoRegistro { get; set; }

        public CampoLayout()
        {
            intCodigo = 0;
            intPosicao = 0;
            strNome = string.Empty;
            blnImportar = true;
            blnChave = false;
            intCodigoLayout = 0;
            strConteudo = string.Empty;
            intCodigoRegistro = 0;
        }
    }
    public class Registro
    {
        public int intCodigo { get; set; }
        public int intCodigoImportacao { get; set; }
        public bool blnDuplicado { get; set; }
        public string strChave { get; set; }
        public int intRegistros { get; set; }
        public int intDuplicados { get; set; }

        public List<CampoLayout> Campos = new List<CampoLayout>();

        public Registro()
        {
            intCodigo = 0;
            intCodigoImportacao = 0;
            blnDuplicado = false;
            strChave = string.Empty;
            intRegistros = 0;
            intDuplicados = 0;
        }

        AcessoBD oAcessoBD = new AcessoBD();
        List<SqlParameter> oParametros = new List<SqlParameter>();
        string strSql = string.Empty;
        public void Gravar()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                bool blnGravar = false;
                foreach (CampoLayout oCampo in Campos)
                {
                    if (oCampo.blnChave)
                    {
                        strSql = "SELECT DIM.DIM_CODIGO, TRI.TRI_CODIGO FROM TB_DADOS_IMPORTADOS_DIM DIM (NOLOCK) ";
                        strSql += "INNER JOIN TB_REGISTROS_IMPORTADOS_TRI TRI (NOLOCK) ON TRI.TRI_CODIGO = DIM.TRI_CODIGO ";
                        strSql += "INNER JOIN TB_IMPORTACAO_IMP IMP (NOLOCK) ON IMP.IMP_CODIGO = TRI.IMP_CODIGO ";
                        strSql += "WHERE LIM_POSICAO = @p_PosicaoCampo AND DIM_VALOR = @p_Conteudo and IMP.IMP_CODIGO = @p_CodigoLayout";
                        oParametros.Clear();
                        oParametros.Add(new SqlParameter("@p_PosicaoCampo", oCampo.intPosicao));
                        oParametros.Add(new SqlParameter("@p_Conteudo", oCampo.strConteudo));
                        oParametros.Add(new SqlParameter("@p_CodigoLayout", intCodigoImportacao));

                        Funcoes.Log(strSql);
                        Funcoes.Log("Conteudo:" + oCampo.strConteudo);
                        DataTable dt = new DataTable();
                        dt = oAcessoBD.ConsultarSql(strSql, oParametros);

                        if (dt.Rows.Count > 0)
                        {
                            if (blnDuplicado)
                            {
                                oParametros.Clear();
                                strSql = "DELETE FROM TB_DADOS_IMPORTADOS_DIM WHERE TRI_CODIGO = @p_CodigoRegistro";
                                oParametros.Add(new SqlParameter("@p_CodigoRegistro", Convert.ToInt32(dt.Rows[0]["TRI_CODIGO"])));
                                Funcoes.Log(strSql);
                                oAcessoBD.Conectar(false);
                                oAcessoBD.ExecutarSql(strSql, oParametros);
                                oAcessoBD.Desconectar(false);

                                string strDim = string.Empty;

                                foreach (DataRow linha in dt.Rows)
                                {
                                    strDim += "," + linha["DIM_CODIGO"];
                                }
                                strDim = strDim.Substring(1);
                                oParametros.Clear();
                                strSql = "DELETE FROM TB_REGISTROS_IMPORTADOS_TRI WHERE TRI_CODIGO in (@p_CodigoRegistro)";
                                oParametros.Add(new SqlParameter("@p_CodigoRegistro", strDim));
                                Funcoes.Log(strSql);
                                oAcessoBD.Conectar(false);
                                oAcessoBD.ExecutarSql(strSql, oParametros);
                                oAcessoBD.Desconectar(false);

                                blnGravar = true;
                                intDuplicados++;
                            }
                            else
                            {
                                blnGravar = false;
                            }
                        }
                        else
                        {
                            blnGravar = true;
                        }
                        break;
                    }
                }
                if (blnGravar)
                {
                    //oAcessoBD.Conectar(true);
                    oAcessoBD.Conectar(true);
                    intRegistros++;
                    strSql = "INSERT INTO TB_REGISTROS_IMPORTADOS_TRI (IMP_CODIGO, TRI_CHAVE) ";
                    strSql += "VALUES (@p_CodigoImportacao, @p_Chave);SELECT @@IDENTITY";
                    oParametros.Clear();
                    oParametros.Add(new SqlParameter("@p_CodigoImportacao", intCodigoImportacao));
                    oParametros.Add(new SqlParameter("@p_Chave", strChave));
                    Funcoes.Log(strSql);
                    Funcoes.Log("intCodigoImportacao:" + intCodigoImportacao);
                    intCodigo = oAcessoBD.ExecutarSql(strSql, oParametros);

                    foreach (CampoLayout campo in Campos)
                    {
                        if (campo.blnImportar)
                        {
                            strSql = "INSERT INTO TB_DADOS_IMPORTADOS_DIM (DIM_VALOR, DIM_CHAVE, LIM_POSICAO, TRI_CODIGO) ";
                            strSql += "VALUES (@p_Conteudo, @p_Chave, @p_CodigoCampo, @p_CodigoImportacao)";
                            oParametros.Clear();
                            oParametros.Add(new SqlParameter("@p_Conteudo", campo.strConteudo));
                            oParametros.Add(new SqlParameter("@p_Chave", strChave));
                            oParametros.Add(new SqlParameter("@p_CodigoCampo", campo.intPosicao));
                            oParametros.Add(new SqlParameter("@p_CodigoImportacao", intCodigo));
                            Funcoes.Log(strSql);
                            Funcoes.Log("Conteúdo:" + campo.strConteudo);
                            Funcoes.Log("Codigo Campo" + campo.intPosicao);
                            oAcessoBD.ExecutarSql(oParametros, strSql);
                        }
                    }
                    oAcessoBD.Desconectar(true);
                }
            }
            catch (Exception ex)
            {
                Funcoes.Log(ex.Message);
                oAcessoBD.RollBack();
                throw new Exception(ex.Message);
            }
        }

        public void Desfazer()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oAcessoBD.Conectar(true);

                strSql = "DELETE FROM TB_DADOS_IMPORTADOS_DIM WHERE DIM_CHAVE = @p_Chave";
                oParametros.Clear();
                oParametros.Add(new SqlParameter("@p_Chave", strChave));

                oAcessoBD.ExecutarSql(oParametros, strSql);

                strSql = "DELETE FROM TB_REGISTROS_IMPORTADOS_TRI WHERE TRI_CHAVE = @p_Chave";
                oParametros.Clear();
                oParametros.Add(new SqlParameter("@p_Chave", strChave));

                oAcessoBD.ExecutarSql(oParametros, strSql);

                oAcessoBD.Desconectar(true);
            }
            catch (Exception ex)
            {
                oAcessoBD.RollBack();
                throw new Exception(ex.Message);
            }
        }
    }
    public class Permissoes
    {
        public string strMenu { get; set; }
        public bool blnStatus { get; set; }
        public int intCodigoUsuario { get; set; }

        public Permissoes()
        {
            strMenu = string.Empty;
            blnStatus = true;
            intCodigoUsuario = 0;
        }
    }

    public class Evento
    {
        public int intCodigo { get; set; }
        public string strCodigoAMB { get; set; }
        public string strDescricao { get; set; }
        public Evento()
        {
            intCodigo = 0;
            strCodigoAMB = string.Empty;
            strDescricao = string.Empty;
        }

        AcessoBD oAcessoBD = new AcessoBD();
        List<SqlParameter> oParametros = new List<SqlParameter>();
        DataTable dtEvento = new DataTable();
        string strSql = string.Empty;

        public DataTable Consultar()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                strSql = "Select id, codigo, descricao from procedimentos (nolock)\n";
                oParametros.Clear();

                if (this.intCodigo != 0)
                {
                    strSql += "where id = @p_Codigo";
                    oParametros.Add(new SqlParameter("@p_Codigo", this.intCodigo));
                }
                else if (this.strCodigoAMB != string.Empty)
                {
                    strSql += "where codigo = @p_CodigoAMB";
                    oParametros.Add(new SqlParameter("@p_CodigoAMB", this.strCodigoAMB));
                }
                else if (this.strDescricao != string.Empty)
                {
                    strSql += "where descricao like @p_Descricao";
                    oParametros.Add(new SqlParameter("@p_Descricao", "%" + this.strDescricao + "%"));
                }

                strSql += "\n order by descricao";
                dtEvento = oAcessoBD.ConsultarSql(strSql, oParametros);

                if (this.intCodigo != 0)
                {
                    this.intCodigo = Convert.ToInt32(dtEvento.Rows[0]["id"]);
                    this.strCodigoAMB = dtEvento.Rows[0]["codigo"].ToString();
                    this.strDescricao = dtEvento.Rows[0]["descricao"].ToString();
                }
                return dtEvento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Gravar()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oAcessoBD.Conectar(false);
                oParametros.Clear();
                if (this.intCodigo == 0)
                {
                    strSql = "insert into procedimentos (";
                    strSql += "codigo, descricao ";
                    strSql += ") values (";
                    strSql += "@p_CodigoAMB, @p_Descricao)";
                }
                else
                {
                    strSql = "update procedimentos set\n";
                    strSql += "codigo = @p_CodigoAMB,\n";
                    strSql += "descricao = @p_Descricao\n";
                    strSql += "where id = @p_Codigo";
                    oParametros.Add(new SqlParameter("@p_Codigo", this.intCodigo));
                }

                oParametros.Add(new SqlParameter("@p_CodigoAMB", this.strCodigoAMB));
                oParametros.Add(new SqlParameter("@p_Descricao", this.strDescricao));

                oAcessoBD.ExecutarSql(strSql, oParametros);
                oAcessoBD.Desconectar(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }

    public class Usuario
    {
        public int intCodigo { get; set; }
        public string strLogin { get; set; }
        public string strNome { get; set; }
        public string strSenha { get; set; }
        public string strObservacao { get; set; }
        public bool blnAtivo { get; set; }
        public List<Permissoes> Permissao = new List<Permissoes>();

        public Usuario()
        {
            this.intCodigo = 0;
            this.strLogin = string.Empty;
            this.strNome = string.Empty;
            this.strSenha = string.Empty;
            this.strObservacao = string.Empty;
            this.blnAtivo = true;
            Permissao.Clear();
        }
        AcessoBD oAcessoBD = new AcessoBD();
        List<SqlParameter> oParametros = new List<SqlParameter>();
        DataTable dtUsuario = new DataTable();
        string strSql = string.Empty;
        public bool AutenticarUsuario()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                strSql = "Select usu_codigo, usu_nome, usu_ativo from tb_usuario_usu (NOLOCK) ";
                strSql += "where usu_usuario = @p_Usuario ";
                strSql += "and usu_senha = @p_Senha";

                oParametros.Clear();

                oParametros.Add(new SqlParameter("@p_Usuario", strLogin));
                oParametros.Add(new SqlParameter("@p_Senha", strSenha));

                dtUsuario = oAcessoBD.ConsultarSql(strSql, oParametros);

                if (dtUsuario.Rows.Count > 0)
                {
                    this.intCodigo = Convert.ToInt32(dtUsuario.Rows[0][0]);
                    this.strNome = dtUsuario.Rows[0][1].ToString();
                    this.blnAtivo = Convert.ToBoolean(dtUsuario.Rows[0][2]);
                    Funcoes.intCodigoUsuario = this.intCodigo;
                    Funcoes.strNomeUsuario = this.strNome;
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ConsultarUsuario()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                strSql = "Select usu_codigo, usu_nome as Nome, usu_usuario as Usuário, usu_senha, usu_observacao, usu_ativo\n";
                strSql += "from tb_usuario_usu (NOLOCK)\n";
                oParametros.Clear();

                if (this.intCodigo != 0)
                {
                    strSql += "where usu_codigo = @p_Codigo";
                    oParametros.Add(new SqlParameter("@p_Codigo", this.intCodigo));
                }
                else if (this.strLogin != string.Empty)
                {
                    strSql += "where usu_usuario = @p_Login";
                    oParametros.Add(new SqlParameter("@p_Login", this.strLogin));
                }
                else if (this.strNome != string.Empty)
                {
                    strSql += "where usu_nome like @p_Nome";
                    oParametros.Add(new SqlParameter("@p_Nome", "%" + this.strNome + "%"));
                }

                strSql += "\norder by usu_nome";
                dtUsuario = oAcessoBD.ConsultarSql(strSql, oParametros);

                if (this.intCodigo != 0)
                {
                    this.intCodigo = Convert.ToInt32(dtUsuario.Rows[0]["usu_codigo"]);
                    this.strNome = dtUsuario.Rows[0]["Nome"].ToString();
                    this.strLogin = dtUsuario.Rows[0]["Usuário"].ToString();
                    this.strSenha = Funcoes.Decrypt(dtUsuario.Rows[0]["usu_senha"].ToString(), true);
                    this.strObservacao = dtUsuario.Rows[0]["usu_observacao"].ToString();
                    this.blnAtivo = Convert.ToBoolean(dtUsuario.Rows[0]["usu_ativo"]);
                }
                return dtUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarPermissoes()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                strSql = "SELECT PER_MENU, PER_STATUS FROM TB_PERMISSOES_PER (NOLOCK) WHERE USU_CODIGO = @p_Codigo";

                oParametros.Clear();

                oParametros.Add(new SqlParameter("@p_Codigo", this.intCodigo));
                dtUsuario = oAcessoBD.ConsultarSql(strSql, oParametros);
                Permissao.Clear();
                foreach (DataRow linha in dtUsuario.Rows)
                {
                    Permissoes oPermissoes = new Permissoes();
                    oPermissoes.intCodigoUsuario = intCodigo;
                    oPermissoes.strMenu = linha[0].ToString();
                    oPermissoes.blnStatus = Convert.ToBoolean(linha[1]);
                    Permissao.Add(oPermissoes);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void GravarUsuario()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oAcessoBD.Conectar(false);
                oParametros.Clear();
                if (this.intCodigo == 0)
                {
                    strSql = "insert into tb_usuario_usu (";
                    strSql += "usu_nome, usu_usuario, ";
                    strSql += "usu_senha, usu_Observacao, usu_ativo";
                    strSql += ") values (";
                    strSql += "@p_Nome, @p_Login, ";
                    strSql += "@p_Senha, @p_Obs, @p_Ativo)";
                }
                else
                {
                    strSql = "update tb_usuario_usu set\n";
                    strSql += "usu_nome = @p_Nome,\n";
                    strSql += "usu_usuario = @p_Login,\n";
                    strSql += "usu_senha = @p_Senha,\n";
                    strSql += "usu_observacao = @p_Obs,\n";
                    strSql += "usu_ativo = @p_Ativo\n";
                    strSql += "where usu_codigo = @p_Codigo";
                    oParametros.Add(new SqlParameter("@p_Codigo", this.intCodigo));
                }

                oParametros.Add(new SqlParameter("@p_Nome", this.strNome));
                oParametros.Add(new SqlParameter("@p_Login", this.strLogin));
                oParametros.Add(new SqlParameter("@p_Senha", Funcoes.Encrypt(this.strSenha, true)));
                oParametros.Add(new SqlParameter("@p_Obs", this.strObservacao));
                oParametros.Add(new SqlParameter("@p_Ativo", this.blnAtivo));

                oAcessoBD.ExecutarSql(strSql, oParametros);
                oAcessoBD.Desconectar(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void GravarPermissoes()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oAcessoBD.Conectar(true);
                oParametros.Clear();
                strSql = "DELETE FROM TB_PERMISSOES_PER WHERE USU_CODIGO = @p_Codigo";
                oParametros.Add(new SqlParameter("@p_Codigo", intCodigo));

                oAcessoBD.ExecutarSql(oParametros, strSql);

                foreach (Permissoes permissao in Permissao)
                {
                    strSql = "INSERT INTO TB_PERMISSOES_PER (PER_MENU, PER_STATUS, USU_CODIGO)";
                    strSql += "VALUES (@p_Menu, @p_Status, @p_Codigo)";
                    oParametros.Clear();
                    oParametros.Add(new SqlParameter("@p_Menu", permissao.strMenu));
                    oParametros.Add(new SqlParameter("@p_Status", permissao.blnStatus));
                    oParametros.Add(new SqlParameter("@p_Codigo", intCodigo));

                    oAcessoBD.ExecutarSql(oParametros, strSql);
                }
                oAcessoBD.Desconectar(true);
            }
            catch (Exception ex)
            {
                oAcessoBD.RollBack();
                throw new Exception(ex.Message);
            }
        }
        public void GravarPermissoesPEG(List<string> permissoesPeg)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oAcessoBD.Conectar(true);
                oParametros.Clear();
                strSql = "DELETE FROM TB_PERMISSAO_USUARIO_PEG_TPU WHERE USU_CODIGO = @p_Codigo";
                oParametros.Add(new SqlParameter("@p_Codigo", intCodigo));

                oAcessoBD.ExecutarSql(oParametros, strSql);

                foreach (string permissao in permissoesPeg)
                {
                    strSql = "INSERT INTO TB_PERMISSAO_USUARIO_PEG_TPU (USU_CODIGO, TIP_CODIGO, TPP_CONVENIO)";
                    strSql += "VALUES (@p_Codigo, @p_Permissao, @p_Convenio)";
                    oParametros.Clear();
                    oParametros.Add(new SqlParameter("@p_Codigo", intCodigo));
                    oParametros.Add(new SqlParameter("@p_Permissao", Convert.ToInt32(permissao.Substring(0, 1))));
                    oParametros.Add(new SqlParameter("@p_Convenio", permissao.Substring(permissao.IndexOf('(')+1).Replace(")","")));

                    oAcessoBD.ExecutarSql(oParametros, strSql);
                }
                oAcessoBD.Desconectar(true);
            }
            catch (Exception ex)
            {
                oAcessoBD.RollBack();
                throw new Exception(ex.Message);
            }
        }
        public DataTable ConsultarPermissoesPEG(int intTipo = 0)
        {

            try
            {
                oParametros.Clear();
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                strSql = "SELECT convert(varchar,TIP.TIP_CODIGO)+' - '+TIP_DESCRICAO+' ('+TPP_CONVENIO+')' FROM TB_PERMISSAO_USUARIO_PEG_TPU TPU (NOLOCK) ";
                strSql += "INNER JOIN TB_TIPO_PEG_TIP TIP (NOLOCK) ON TPU.TIP_CODIGO = TIP.TIP_CODIGO WHERE USU_CODIGO = @p_Codigo ";
                if (intTipo != 0)
                {
                    strSql += "AND TIP.TIP_CODIGO = @p_tipo";
                    oParametros.Add(new SqlParameter("@p_tipo", intTipo));
                }

                oParametros.Add(new SqlParameter("@p_Codigo", this.intCodigo));
                dtUsuario = oAcessoBD.ConsultarSql(strSql, oParametros);
                return dtUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
    public class Exportacao
    {
        public string strChave { get; set; }
        public DateTime dttDataExportacao { get; set; }
        public int intCodigoServico { get; set; }
        public List<string> Lotes = new List<string>();
        public Exportacao()
        {
            strChave = string.Empty;
            dttDataExportacao = DateTime.Now;
            intCodigoServico = 0;
        }

        AcessoBD oAcessoBD = new AcessoBD();
        List<SqlParameter> oParametros = new List<SqlParameter>();
        DataTable dtDados = new DataTable();
        string strSql = string.Empty;

        StreamWriter strArquivo;
        StreamWriter strArqFormalizacao;
        StreamWriter strArquivoCEDOC;

        string strDestino;

        public int SelecionarRegistros()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                string strLotes = string.Empty;
                oAcessoBD.Conectar(false);
                oParametros.Clear();
                strLotes = string.Empty;
                foreach (string lote in Lotes)
                {
                    strSql = "SELECT LOT_CODIGO FROM TB_LOTE_LOT (NOLOCK) WHERE LOT_NUMERO = @p_Lote and CAI_CODIGO = @p_CodigoCaixa";
                    oParametros.Clear();
                    oParametros.Add(new SqlParameter("@p_Lote", lote.Substring(lote.IndexOf('-') + 1)));
                    oParametros.Add(new SqlParameter("@p_CodigoCaixa", lote.Substring(0, lote.IndexOf('-'))));
                    strLotes += ", '" + oAcessoBD.ExecutarSql(strSql, oParametros).ToString() + "'";
                }

                oParametros.Clear();
                strSql = "UPDATE TB_REGISTRO_REG SET REG_CHAVE = @p_Chave, REG_DATA_EXPORTACAO = @p_DataExportacao ";
                //strSql = "SELECT * FROM TB_REGISTRO_REG ";
                strSql += "WHERE SER_CODIGO = @p_Servico ";//AND REG_CHAVE IS NULL ";
                strSql += "AND LOT_CODIGO in (@p_Lotes)";
                oParametros.Add(new SqlParameter("@p_Chave", strChave));
                oParametros.Add(new SqlParameter("@p_DataExportacao", dttDataExportacao));
                oParametros.Add(new SqlParameter("@p_Servico", intCodigoServico));

                strLotes = strLotes.Substring(1).Trim();
                strSql = strSql.Replace("@p_Lotes", strLotes);
                //dtDados = oAcessoBD.ConsultarSql(strSql, oParametros);

                int intRetorno = oAcessoBD.ExecutarSql(oParametros, strSql);

                return intRetorno;
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

        public void ExportarRegistros(bool blnFormalizacao, string strServico)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                string strFile = "Upload_" + Funcoes.Decrypt(strChave, true).Replace("/", "").Replace(":", "").Replace(" ", "_");
                string strFileFormalizacao = "CQ_BIO_" + Funcoes.Decrypt(strChave, true).Replace("/", "").Replace(":", "").Replace(" ", "_");

                string strPasta = ConfigurationManager.AppSettings["CaminhoImagens"] + @"\Exportação\" + strServico + @"\" + strFile + @"\";

                if (!Directory.Exists(strPasta))
                {
                    Directory.CreateDirectory(strPasta);
                }
                string strPathFile = strPasta + strFile + ".txt";
                string strPathFileFormalizacao = strPasta + strFileFormalizacao + ".txt";

                //using (StreamWriter sw = new StreamWriter(File.Open(strPathFile, FileMode.Create), Encoding.WhateverYouWant))

                //using (FileStream fs = new FileStream(strPathFile, FileMode.Create, FileAccess.Write)) ;
                //using (FileStream fs = new FileStream(strPathFileCQ, FileMode.Create, FileAccess.Write)) ;


                strArquivo = new StreamWriter(strPathFile, false, Encoding.UTF8);
                if (blnFormalizacao)
                {
                    strArqFormalizacao = new StreamWriter(strPathFileFormalizacao, false, Encoding.UTF8);
                }

                oAcessoBD.Conectar(false);
                oParametros.Clear();
                /*
                strSql = "SELECT REG_CODIGO, REG_NOME_ARQUIVO, LOT_CODIGO from TB_REGISTRO_REG ";
                strSql += "WHERE REG_CHAVE = @p_Chave ";
                strSql += "UNION ";
                strSql += "SELECT REG_CODIGO, IMA_NOME_ARQUIVO REG_NOME_ARQUIVO, IMA.LOT_CODIGO FROM TB_IMAGEM_IMA IMA ";
                strSql += "INNER JOIN TB_REGISTRO_REG REG ON REG.REG_NOME_ARQUIVO = IMA.IMA_DOCUMENTO_PAI ";
                strSql += "WHERE REG_CHAVE = @p_Chave ";
                strSql += "ORDER BY REG_CODIGO, REG_NOME_ARQUIVO ";
                */

                strSql = "SELECT REG_CODIGO, REG_NOME_ARQUIVO, REG.LOT_CODIGO, ";
                strSql += "IMA_IMPRESSO, IMA_PCMSO, IMA_APTO, IMA_ALTURA,  ";
                strSql += "IMA_CARIMBO, IMA_CONTATO, IMA_ASSINATURA, IMA_DATAS, IMA_DIGITAL, IMA_PARENT ";
                strSql += "from TB_REGISTRO_REG REG (NOLOCK) ";
                strSql += "INNER JOIN TB_IMAGEM_IMA IMA (NOLOCK) ON IMA.IMA_NOME_ARQUIVO = REG.REG_NOME_ARQUIVO ";
                strSql += "WHERE REG_CHAVE = @p_Chave ";
                strSql += "UNION ";
                strSql += "SELECT REG_CODIGO, IMA_NOME_ARQUIVO REG_NOME_ARQUIVO, IMA.LOT_CODIGO, ";
                strSql += "IMA_IMPRESSO, IMA_PCMSO, IMA_APTO, IMA_ALTURA, ";
                strSql += "IMA_CARIMBO, IMA_CONTATO, IMA_ASSINATURA, IMA_DATAS, IMA_DIGITAL, IMA_PARENT ";
                strSql += "FROM TB_IMAGEM_IMA IMA (NOLOCK) ";
                strSql += "INNER JOIN TB_REGISTRO_REG REG (NOLOCK) ON REG.REG_NOME_ARQUIVO = IMA.IMA_DOCUMENTO_PAI ";
                strSql += "WHERE REG_CHAVE = @p_Chave ";
                strSql += "ORDER BY REG.LOT_CODIGO, REG_CODIGO, REG_NOME_ARQUIVO ";

                oParametros.Add(new SqlParameter("@p_Chave", strChave));

                using (SqlDataReader oReader = oAcessoBD.ExecutarReader(strSql, oParametros))
                {
                    Funcoes.intContReg = 0;
                    int intLote = 0;
                    //using (strArquivo)
                    //{
                    while (oReader.Read())
                    {
                        if (intLote != Convert.ToInt32(oReader[2]))
                        {
                            Application.DoEvents();
                            Funcoes.intContReg++;
                            Application.DoEvents();
                            intLote = Convert.ToInt32(oReader[2]);
                        }
                        int intRegistro = Convert.ToInt32(oReader[0]);
                        string strNomeArquivo = oReader[1].ToString() + ".pdf";
                        strSql = "SELECT VAL_CONTEUDO FROM TB_VALOR_VAL (NOLOCK) WHERE REG_CODIGO = @p_Registro ORDER BY CPO_ORDEM";
                        DataTable dtLinha = new DataTable();
                        oParametros.Clear();
                        oParametros.Add(new SqlParameter("@p_Registro", intRegistro));
                        dtLinha = oAcessoBD.ConsultarSql(strSql, oParametros);
                        string strLinhaFormalizacao = string.Empty;
                        if (blnFormalizacao && Convert.ToBoolean(oReader[12]))
                        {
                            strLinhaFormalizacao += "\"" + strNomeArquivo + "\",";
                            for (int intCont = 3; intCont < oReader.FieldCount - 1; intCont++)
                            {
                                strLinhaFormalizacao += Convert.ToBoolean(oReader[intCont].ToString()) ? "\"1\"," : "\"0\",";
                            }
                        }

                        string strLinha = string.Empty;
                        strLinha += "\"" + strNomeArquivo + "\",";
                        foreach (DataRow linha in dtLinha.Rows)
                        {
                            strLinha += "\"" + linha[0].ToString() + "\",";
                            if (blnFormalizacao && Convert.ToBoolean(oReader[12]))
                            {
                                strLinhaFormalizacao += "\"" + linha[0].ToString() + "\",";
                            }
                        }
                        strLinha += "\"" + strNomeArquivo + "\",";
                        strLinha += "\"\"";
                        strArquivo.WriteLine(strLinha);
                        strLinha = string.Empty;
                        if (blnFormalizacao && Convert.ToBoolean(oReader[12]))
                        {
                            strLinhaFormalizacao = strLinhaFormalizacao.Substring(0, strLinhaFormalizacao.Length - 1);
                            strArqFormalizacao.WriteLine(strLinhaFormalizacao);
                            strLinhaFormalizacao = string.Empty;
                        }
                        string strOrigem = Funcoes.strCaminhoImagens + @"Digitadas\" + strNomeArquivo;
                        string strDestino = strPasta + @"\" + strNomeArquivo;

                        if (File.Exists(strOrigem))
                        {
                            File.Copy(strOrigem, strDestino, true);
                            File.Delete(strOrigem);
                        }
                        else
                        {
                            Imagem imagem = new Imagem();
                            imagem.strNomeArquivo = strNomeArquivo.Replace(".pdf", "");
                            imagem.intCodigoLote = Convert.ToInt32(oReader[2]);
                            imagem.ConsultarImagem(false);
                            if (imagem.bytImagem != null)
                            {
                                bool blnExecuta = true;
                                File.WriteAllBytes(strDestino, imagem.bytImagem);
                                do
                                {
                                    try
                                    {
                                        using (FileStream fs = File.OpenWrite(strDestino))
                                        {
                                            fs.Close();
                                            fs.Dispose();
                                            blnExecuta = false;
                                        }
                                    }
                                    catch
                                    {
                                        // colocar o arquivo na fila, para ser processado depois                                   
                                    }
                                } while (blnExecuta);
                            }
                        }
                    }
                    //}
                }
                foreach (string lote in Lotes)
                {
                    Lote oLote = new Lote();
                    oLote.intCodigoCaixa = Convert.ToInt32(lote.Substring(0, lote.IndexOf('-')));
                    oLote.strLote = lote.Substring(lote.IndexOf('-') + 1);
                    oLote.intStatusLote = (int)Funcoes.StatusLote.Finalizado;
                    oLote.AlterarStatus();
                }
            }
            catch (Exception ex)
            {
                Desfazer(Lotes);
                throw new Exception(ex.Message);
            }
            finally
            {
                oAcessoBD.Desconectar(false);
                strArquivo.Close();
                strArquivo.Dispose();
                if (blnFormalizacao)
                {
                    strArqFormalizacao.Close();
                    strArqFormalizacao.Dispose();
                }
            }
        }
        public void Desfazer(List<string> strLotes)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oAcessoBD.Conectar(false);

                strSql = "UPDATE TB_REGISTRO_REG SET REG_CHAVE = null, REG_DATA_EXPORTACAO = null ";
                strSql += "WHERE REG_CHAVE = @p_Chave";

                oParametros.Clear();
                oParametros.Add(new SqlParameter("@p_Chave", strChave));
                oAcessoBD.ExecutarSql(oParametros, strSql);

                foreach (string lote in strLotes)
                {
                    oParametros.Clear();
                    strSql = "UPDATE TB_LOTE_LOT SET SLO_CODIGO = @p_Status WHERE CAI_CODIGO = @p_CodigoCaixa AND LOT_NUMERO = @p_Lote";
                    oParametros.Add(new SqlParameter("@p_Lote", lote.Substring(lote.IndexOf('-') + 1)));
                    oParametros.Add(new SqlParameter("@p_CodigoCaixa", lote.Substring(0, lote.IndexOf('-'))));
                    oParametros.Add(new SqlParameter("@p_Status", (int)Funcoes.StatusLote.AguardandoUpload));
                    oAcessoBD.ExecutarSql(oParametros, strSql);
                }

                oAcessoBD.Desconectar(false);
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }
        public void ExportarCD(string strNumeroCaixa)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                Regex regNr = new Regex(@"[^\d]");
                Regex regStr = new Regex("[^a-zA-Z ]"); //[^a-zA-Z0-9 -]"

                string strPasta = ConfigurationManager.AppSettings["CaminhoImagens"] + @"\Exportação\CD\" + strNumeroCaixa + @"\";

                if (!Directory.Exists(strPasta))
                {
                    Directory.CreateDirectory(strPasta);
                }
                string strPathFile = strPasta.Substring(0, strPasta.LastIndexOf(@"\")) + ".txt";

                strArquivo = new StreamWriter(strPathFile, false, Encoding.UTF8);

                DataTable dtImgPai = new DataTable();

                oParametros.Clear();
                strSql = "select REG_CODIGO, IMA_NOME_ARQUIVO, LOT_NUMERO, IMA_ARQUIVO, LOT.LOT_CODIGO from TB_REGISTRO_REG REG (NOLOCK) ";
                strSql += "INNER JOIN TB_LOTE_LOT LOT (NOLOCK) ON LOT.LOT_CODIGO = REG.LOT_CODIGO ";
                strSql += "INNER JOIN TB_CAIXA_CAI CAI (NOLOCK) ON CAI.CAI_CODIGO = LOT.CAI_CODIGO ";
                strSql += "INNER JOIN TB_IMAGEM_IMA IMA (NOLOCK) ON IMA.IMA_NOME_ARQUIVO = REG.REG_NOME_ARQUIVO ";
                strSql += "WHERE CAI_NUMERO = @p_Caixa ";
                strSql += "AND CAI.SER_CODIGO = 1 ";

                oParametros.Add(new SqlParameter("@p_Caixa", strNumeroCaixa));

                dtImgPai = oAcessoBD.ConsultarSql(strSql, oParametros);

                dtDados.Columns.Add("REG_CODIGO", typeof(Int32));
                dtDados.Columns.Add("IMA_NOME_ARQUIVO", typeof(String));
                dtDados.Columns.Add("LOT_NUMERO", typeof(String));
                dtDados.Columns.Add("IMA_ARQUIVO", typeof(Byte[]));
                dtDados.Columns.Add("LOT_CODIGO", typeof(Int32));

                foreach (DataRow linha in dtImgPai.Rows)
                {

                    dtDados.Rows.Add(linha[0], linha[1], linha[2], linha[3], linha[4]);
                }

                DataTable dtImgFilho = new DataTable();

                oParametros.Clear();
                strSql = "select REG_CODIGO, IMA_NOME_ARQUIVO, LOT_NUMERO, IMA_ARQUIVO, LOT.LOT_CODIGO from TB_REGISTRO_REG REG (NOLOCK) ";
                strSql += "INNER JOIN TB_LOTE_LOT LOT (NOLOCK) ON LOT.LOT_CODIGO = REG.LOT_CODIGO ";
                strSql += "INNER JOIN TB_CAIXA_CAI CAI (NOLOCK) ON CAI.CAI_CODIGO = LOT.CAI_CODIGO ";
                strSql += "INNER JOIN TB_IMAGEM_IMA IMA (NOLOCK) ON IMA.IMA_DOCUMENTO_PAI = REG.REG_NOME_ARQUIVO ";
                strSql += "WHERE CAI_NUMERO = @p_Caixa ";
                strSql += "AND CAI.SER_CODIGO = 1 ";

                oParametros.Add(new SqlParameter("@p_Caixa", strNumeroCaixa));

                dtImgFilho = oAcessoBD.ConsultarSql(strSql, oParametros);

                foreach (DataRow linha in dtImgFilho.Rows)
                {
                    dtDados.Rows.Add(linha[0], linha[1], linha[2], linha[3], linha[4]);
                }

                foreach (DataRow linha in dtDados.Rows)
                {
                    int intRegistro = Convert.ToInt32(linha[0]);
                    string strNomeArquivo = strNumeroCaixa + ".pdf";
                    strSql = "SELECT VAL_CONTEUDO FROM TB_VALOR_VAL (NOLOCK) WHERE REG_CODIGO = @p_Registro ORDER BY CPO_ORDEM";
                    DataTable dtLinha = new DataTable();
                    oParametros.Clear();
                    oParametros.Add(new SqlParameter("@p_Registro", intRegistro));
                    dtLinha = oAcessoBD.ConsultarSql(strSql, oParametros);
                    if (dtLinha.Rows.Count == 7)
                    {
                        string caixa = regNr.Replace(strNumeroCaixa, "");
                        string cnpj = regNr.Replace(dtLinha.Rows[5][0].ToString(), "");
                        string empresa = regStr.Replace(dtLinha.Rows[6][0].ToString(), "");
                        string cpf = regNr.Replace(dtLinha.Rows[2][0].ToString(), "");
                        string funcionario = regStr.Replace(dtLinha.Rows[4][0].ToString(), "");
                        string lote = regNr.Replace(linha[2].ToString(), "");
                        string etiqueta = regNr.Replace(linha[1].ToString().Substring(linha[1].ToString().Length - 6), "");
                        string tipoExame = linha[1].ToString().Substring(linha[1].ToString().Length - 7, 1);

                        string strLinhaArquivo = string.Format("{0}|{1}|{2}|{3}|{4}|{5}_{6}|{7}",
                            caixa, //CAIXA
                            cnpj == string.Empty ? new string('0', 14) : cnpj, //CNPJ
                            empresa == string.Empty ? "ILEGÍVEL" : empresa, //EMPRESA
                            cpf == string.Empty ? new string('0', 11) : cpf, // CPF
                            funcionario == string.Empty ? "ILEGÍVEL" : funcionario, //FUNCIONÁRIO
                            lote, //LOTE
                            etiqueta, //ETIQUETA
                            tipoExame);//TIPO EXAME

                        string nomeArquivo = string.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}",
                            cnpj == string.Empty ? new string('0', 14) : cnpj, //CNPJ
                            empresa == string.Empty ? "ILEGÍVEL" : empresa, //EMPRESA
                            cpf == string.Empty ? new string('0', 11) : cpf, // CPF
                            funcionario == string.Empty ? "ILEGÍVEL" : funcionario, //FUNCIONÁRIO
                            lote, //LOTE
                            etiqueta, //ETIQUETA
                            tipoExame);

                        strArquivo.WriteLine(strLinhaArquivo); //Escrevendo a linha no arquivo

                        Imagem imagem = new Imagem();
                        imagem.strNomeArquivo = linha[1].ToString().Replace(".pdf", "");
                        imagem.intCodigoLote = Convert.ToInt32(linha[4]);
                        imagem.ConsultarImagem(false);
                        if (imagem.bytImagem != null)
                        {
                            strDestino = strPasta + @"\temp_" + DateTime.Now.ToString("ddMMyyyyhhmmssfff") + ".pdf";
                            File.WriteAllBytes(strDestino, imagem.bytImagem);

                            //Escrevendo no arquivo PDF
                            string oldFile = strDestino;
                            string newFile = strPasta + @"\" + nomeArquivo + ".pdf";
                            PdfReader reader = new PdfReader(oldFile);
                            FileStream outputStream = new FileStream(newFile, FileMode.Create);
                            PdfStamper Stamper = new PdfStamper(reader, outputStream);

                            float height = reader.GetPageSizeWithRotation(1).Height;// *postScriptPoints;

                            BaseFont bf = BaseFont.CreateFont("Helvetica", BaseFont.WINANSI, BaseFont.EMBEDDED);
                            PdfContentByte cb = Stamper.GetOverContent(1);
                            cb.BeginText();
                            cb.SetFontAndSize(bf, 16);
                            cb.SetTextMatrix(30, height - 25);//(Horizontal, Vertical)
                            cb.ShowText(string.Format("Caixa {0} - TELECRED {1}", regNr.Replace(strNumeroCaixa, ""), DateTime.Now.ToShortDateString()));
                            cb.EndText();
                            Stamper.FormFlattening = true;

                            Stamper.Close();
                            Stamper.Dispose();
                            reader.Close();
                            reader.Dispose();
                            outputStream.Close();
                            outputStream.Dispose();
                            File.Delete(strDestino);
                        }
                    }

                }
                oAcessoBD.Conectar(false);
                strSql = "INSERT INTO TB_EXPORTACAO_CD_TEC (TEC_DATA, TEC_CAIXA) VALUES (@p_Data, @p_Caixa)";
                oParametros.Clear();
                oParametros.Add(new SqlParameter("@p_Data", DateTime.Now));
                oParametros.Add(new SqlParameter("@p_Caixa", strNumeroCaixa));

                oAcessoBD.ExecutarSql(strSql, oParametros);
                dtDados = new DataTable();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oAcessoBD.Desconectar(false);
                strArquivo.Close();
                strArquivo.Dispose();

            }
        }
        public void Expurgar(Caixa oCaixa)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oParametros.Clear();
                oAcessoBD.Conectar(false);
                strSql = "SELECT CAI_CODIGO FROM TB_CAIXA_CAI (NOLOCK) WHERE CAI_NUMERO = @p_Caixa AND SER_CODIGO = @p_Servico";
                oParametros.Add(new SqlParameter("@p_Caixa", oCaixa.strCaixa));
                oParametros.Add(new SqlParameter("@p_Servico", oCaixa.intCodigoServico));
                oCaixa.intCodigo = oAcessoBD.ExecutarSql(strSql, oParametros);

                oParametros.Clear();
                strSql = "SELECT LOT_CODIGO FROM TB_LOTE_LOT (NOLOCK) WHERE CAI_CODIGO = @p_CodigoCaixa";
                oParametros.Add(new SqlParameter("@p_CodigoCaixa", oCaixa.intCodigo));

                dtDados = oAcessoBD.ConsultarSql(strSql, oParametros);

                oAcessoBD.Desconectar(false);

                oAcessoBD.Conectar(true);
                foreach (DataRow linha in dtDados.Rows)
                {
                    //Apagando valores
                    oParametros.Clear();
                    strSql = "DELETE FROM TB_VALOR_VAL WHERE REG_CODIGO IN (";
                    strSql += "SELECT REG_CODIGO FROM TB_REGISTRO_REG (NOLOCK) WHERE LOT_CODIGO = @p_CodigoLote)";
                    oParametros.Add(new SqlParameter("@p_CodigoLote", Convert.ToInt32(linha[0])));
                    oAcessoBD.ExecutarSql(strSql, oParametros);

                    //Apagando registros
                    oParametros.Clear();
                    strSql = "DELETE FROM TB_REGISTRO_REG WHERE LOT_CODIGO = @p_CodigoLote";
                    oParametros.Add(new SqlParameter("@p_CodigoLote", Convert.ToInt32(linha[0])));
                    oAcessoBD.ExecutarSql(strSql, oParametros);

                    //Apagando imagens
                    oParametros.Clear();
                    strSql = "DELETE FROM TB_IMAGEM_IMA WHERE LOT_CODIGO = @p_CodigoLote";
                    oParametros.Add(new SqlParameter("@p_CodigoLote", Convert.ToInt32(linha[0])));
                    oAcessoBD.ExecutarSql(strSql, oParametros);

                }
                //Apagando Lotes
                oParametros.Clear();
                strSql = "DELETE FROM TB_LOTE_LOT WHERE CAI_CODIGO = @p_CodigoCaixa";
                oParametros.Add(new SqlParameter("@p_CodigoCaixa", oCaixa.intCodigo));
                oAcessoBD.ExecutarSql(strSql, oParametros);


                //Apagando Caixa
                oParametros.Clear();
                strSql = "DELETE FROM TB_CAIXA_CAI WHERE CAI_CODIGO = @p_CodigoCaixa";
                oParametros.Add(new SqlParameter("@p_CodigoCaixa", oCaixa.intCodigo));
                oAcessoBD.ExecutarSql(strSql, oParametros);

                oAcessoBD.Desconectar(true);
            }
            catch (Exception ex)
            {
                oAcessoBD.RollBack();
                throw new Exception(ex.Message);
            }
        }
        public void FechamentoReembolso(string strNumeroCaixa, int intCodigoServico)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                Regex regNr = new Regex(@"[^\d]");
                Regex regStr = new Regex("[^a-zA-Z ]"); //[^a-zA-Z0-9 -]"

                string strPasta = ConfigurationManager.AppSettings["CaminhoImagens"] + @"\Exportação\CD\" + strNumeroCaixa + @"\";

                if (!Directory.Exists(strPasta))
                {
                    Directory.CreateDirectory(strPasta);
                }
                string strPathFile = strPasta.Substring(0, strPasta.LastIndexOf(@"\")) + ".txt";

                strArquivo = new StreamWriter(strPathFile, false, Encoding.UTF8);

                DataTable dtPegs = new DataTable();

                oParametros.Clear();
                strSql = "select id, tipo, numero, segurado, quantidade, valor, banco, agencia, contacorrente, cpf ";
                strSql += ", (select count(1) from guia g (nolock) where g.peg_id = p.id) guias ";
                strSql += "from peg p (nolock) ";
                strSql += "inner join TB_LOTE_LOT lot on p.lote = lot.LOT_CODIGO ";
                strSql += "inner join TB_CAIXA_CAI CAI on lot.CAI_CODIGO = CAI.CAI_CODIGO ";
                strSql += "where chave is null and data_exportacao is null and CAI.CAI_NUMERO = @p_caixa ";
                strSql += "and CAI.SER_CODIGO = @p_servico ";

                oParametros.Add(new SqlParameter("@p_Caixa", strNumeroCaixa));
                oParametros.Add(new SqlParameter("@p_Servico", intCodigoServico));

                dtPegs = oAcessoBD.ConsultarSql(strSql, oParametros);

                string strLinhaPeg = string.Empty;


                foreach (DataRow linha in dtPegs.Rows)
                {
                    string strTipoRegistro = "01";
                    string strCodigoTitular = linha["segurado"].ToString();
                    string strRegimeAtendimento = "0" + linha["tipo"].ToString();
                    double dblValorTotal = Convert.ToDouble(linha["valor"]);
                    int intQtdeGuias = Convert.ToInt32(linha["guias"]);
                    string strEstado = "  ";
                    string strMunicipío = new string(' ', 40);
                    string strQtdeDocumentos = "00";
                    string strTipoPagamento = "01";
                    string strBanco = "0" + linha["banco"].ToString();
                    string strAgencia = linha["agencia"].ToString().PadLeft(4, '0');
                    string strContaCorrente = linha["contacorrente"].ToString();
                    strContaCorrente = strContaCorrente.Substring(0, strContaCorrente.Length - 1).PadLeft(12, '0');
                    string strDigito = linha["contacorrente"].ToString();
                    strDigito = strDigito.Substring(strDigito.Length - 1).PadRight(2, ' ');
                    string strCPF = linha["cpf"].ToString().Trim().PadLeft(14, '0');
                    string strGeracaoPagamento = "00";
                    string strTipoTelefone = "0";
                    string strDDD = "000";
                    string strPrefixo = "00000";
                    string strTelefone = "0000";

                    strLinhaPeg = string.Format("{0}{1}{2}{3}{4}{5}"
                        , strTipoRegistro
                        , strCodigoTitular
                        , strRegimeAtendimento
                        , intQtdeGuias.ToString().PadLeft(6, '0')
                        , (dblValorTotal * 100).ToString().PadLeft(12, '0')
                        , strEstado
                        , strMunicipío
                        , strQtdeDocumentos
                        , strTipoPagamento
                        , strBanco
                        , strAgencia
                        , strContaCorrente
                        , strDigito
                        , strCPF
                        , strGeracaoPagamento
                        , strTipoTelefone
                        , strDDD
                        , strPrefixo
                        , strTelefone
                        );
                    strArquivo.WriteLine(strLinhaPeg);
                }

                DataTable dtGuias = new DataTable();

                //oParametros.Clear();
                //strSql = "select REG_CODIGO, IMA_NOME_ARQUIVO, LOT_NUMERO, IMA_ARQUIVO, LOT.LOT_CODIGO from TB_REGISTRO_REG REG (NOLOCK) ";
                //strSql += "INNER JOIN TB_LOTE_LOT LOT (NOLOCK) ON LOT.LOT_CODIGO = REG.LOT_CODIGO ";
                //strSql += "INNER JOIN TB_CAIXA_CAI CAI (NOLOCK) ON CAI.CAI_CODIGO = LOT.CAI_CODIGO ";
                //strSql += "INNER JOIN TB_IMAGEM_IMA IMA (NOLOCK) ON IMA.IMA_DOCUMENTO_PAI = REG.REG_NOME_ARQUIVO ";
                //strSql += "WHERE CAI_NUMERO = @p_Caixa ";
                //strSql += "AND CAI.SER_CODIGO = 1 ";

                //oParametros.Add(new SqlParameter("@p_Caixa", strNumeroCaixa));

                //dtImgFilho = oAcessoBD.ConsultarSql(strSql, oParametros);

                //foreach (DataRow linha in dtImgFilho.Rows)
                //{
                //    dtDados.Rows.Add(linha[0], linha[1], linha[2], linha[3], linha[4]);
                //}

                //foreach (DataRow linha in dtDados.Rows)
                //{
                //    int intRegistro = Convert.ToInt32(linha[0]);
                //    string strNomeArquivo = strNumeroCaixa + ".pdf";
                //    strSql = "SELECT VAL_CONTEUDO FROM TB_VALOR_VAL (NOLOCK) WHERE REG_CODIGO = @p_Registro ORDER BY CPO_ORDEM";
                //    DataTable dtLinha = new DataTable();
                //    oParametros.Clear();
                //    oParametros.Add(new SqlParameter("@p_Registro", intRegistro));
                //    dtLinha = oAcessoBD.ConsultarSql(strSql, oParametros);
                //    if (dtLinha.Rows.Count == 7)
                //    {
                //        string caixa = regNr.Replace(strNumeroCaixa, "");
                //        string cnpj = regNr.Replace(dtLinha.Rows[5][0].ToString(), "");
                //        string empresa = regStr.Replace(dtLinha.Rows[6][0].ToString(), "");
                //        string cpf = regNr.Replace(dtLinha.Rows[2][0].ToString(), "");
                //        string funcionario = regStr.Replace(dtLinha.Rows[4][0].ToString(), "");
                //        string lote = regNr.Replace(linha[2].ToString(), "");
                //        string etiqueta = regNr.Replace(linha[1].ToString().Substring(linha[1].ToString().Length - 6), "");
                //        string tipoExame = linha[1].ToString().Substring(linha[1].ToString().Length - 7, 1);

                //        string strLinhaArquivo = string.Format("{0}|{1}|{2}|{3}|{4}|{5}_{6}|{7}",
                //            caixa, //CAIXA
                //            cnpj == string.Empty ? new string('0', 14) : cnpj, //CNPJ
                //            empresa == string.Empty ? "ILEGÍVEL" : empresa, //EMPRESA
                //            cpf == string.Empty ? new string('0', 11) : cpf, // CPF
                //            funcionario == string.Empty ? "ILEGÍVEL" : funcionario, //FUNCIONÁRIO
                //            lote, //LOTE
                //            etiqueta, //ETIQUETA
                //            tipoExame);//TIPO EXAME

                //        string nomeArquivo = string.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}",
                //            cnpj == string.Empty ? new string('0', 14) : cnpj, //CNPJ
                //            empresa == string.Empty ? "ILEGÍVEL" : empresa, //EMPRESA
                //            cpf == string.Empty ? new string('0', 11) : cpf, // CPF
                //            funcionario == string.Empty ? "ILEGÍVEL" : funcionario, //FUNCIONÁRIO
                //            lote, //LOTE
                //            etiqueta, //ETIQUETA
                //            tipoExame);

                //        strArquivo.WriteLine(strLinhaArquivo); //Escrevendo a linha no arquivo

                //        Imagem imagem = new Imagem();
                //        imagem.strNomeArquivo = linha[1].ToString().Replace(".pdf", "");
                //        imagem.intCodigoLote = Convert.ToInt32(linha[4]);
                //        imagem.ConsultarImagem(false);
                //        if (imagem.bytImagem != null)
                //        {
                //            strDestino = strPasta + @"\temp_" + DateTime.Now.ToString("ddMMyyyyhhmmssfff") + ".pdf";
                //            File.WriteAllBytes(strDestino, imagem.bytImagem);

                //            //Escrevendo no arquivo PDF
                //            string oldFile = strDestino;
                //            string newFile = strPasta + @"\" + nomeArquivo + ".pdf";
                //            PdfReader reader = new PdfReader(oldFile);
                //            FileStream outputStream = new FileStream(newFile, FileMode.Create);
                //            PdfStamper Stamper = new PdfStamper(reader, outputStream);

                //            float height = reader.GetPageSizeWithRotation(1).Height;// *postScriptPoints;

                //            BaseFont bf = BaseFont.CreateFont("Helvetica", BaseFont.WINANSI, BaseFont.EMBEDDED);
                //            PdfContentByte cb = Stamper.GetOverContent(1);
                //            cb.BeginText();
                //            cb.SetFontAndSize(bf, 16);
                //            cb.SetTextMatrix(30, height - 25);//(Horizontal, Vertical)
                //            cb.ShowText(string.Format("Caixa {0} - TELECRED {1}", regNr.Replace(strNumeroCaixa, ""), DateTime.Now.ToShortDateString()));
                //            cb.EndText();
                //            Stamper.FormFlattening = true;

                //            Stamper.Close();
                //            Stamper.Dispose();
                //            reader.Close();
                //            reader.Dispose();
                //            outputStream.Close();
                //            outputStream.Dispose();
                //            File.Delete(strDestino);
                //        }
                //    }

                //}
                //oAcessoBD.Conectar(false);
                //strSql = "INSERT INTO TB_EXPORTACAO_CD_TEC (TEC_DATA, TEC_CAIXA) VALUES (@p_Data, @p_Caixa)";
                //oParametros.Clear();
                //oParametros.Add(new SqlParameter("@p_Data", DateTime.Now));
                //oParametros.Add(new SqlParameter("@p_Caixa", strNumeroCaixa));

                //oAcessoBD.ExecutarSql(strSql, oParametros);
                //dtDados = new DataTable();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oAcessoBD.Desconectar(false);
                strArquivo.Close();
                strArquivo.Dispose();

            }
        }
    }

    public class Procedimento
    {
        public string Segurado { get; set; }
        public string Codigo { get; set; }
        public DateTime DataAtendimento { get; set; }
        public string Solicitante { get; set; }
        public decimal Valor { get; set; }
    }

    public class Guia
    {
        public decimal Valor { get; set; }
        public List<Procedimento> Procedimentos = new List<Procedimento>();
    }

    public class PEG
    {
        public int TipoDocumento { get; set; }
        public long Numero { get; set; }
        public string Segurado { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public string Banco { get; set; }
        public string Agencia { get; set; }
        public string ContaCorrente { get; set; }
        public string CPF { get; set; }
        public int Digitador { get; set; }
        public int Lote { get; set; }
        public int Servico { get; set; }
        public List<Guia> Guias = new List<Guia>();

        AcessoBD oAcessoBD = new AcessoBD();
        string strSql = string.Empty;
        List<SqlParameter> oParametros = new List<SqlParameter>();

        public void Gravar()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oAcessoBD.Conectar(true);

                strSql = "INSERT INTO peg (tipo, numero, segurado, quantidade, valor, banco, agencia, contacorrente, cpf, digitador, lote) VALUES ";
                strSql += "(@p_Tipo, @p_Numero, @p_Segurado, @p_Quantidade, @p_Valor, @p_Banco, @p_Agencia, @p_ContaCorrente, @p_CPF, @p_CodigoUsuario, @p_CodigoLote);select SCOPE_IDENTITY()";

                oParametros.Clear();
                oParametros.Add(new SqlParameter("@p_Tipo", TipoDocumento));
                oParametros.Add(new SqlParameter("@p_Numero", Numero));
                oParametros.Add(new SqlParameter("@p_Segurado", Segurado));
                oParametros.Add(new SqlParameter("@p_Quantidade", Quantidade));
                oParametros.Add(new SqlParameter("@p_Valor", Valor));
                oParametros.Add(new SqlParameter("@p_Banco", Banco));
                oParametros.Add(new SqlParameter("@p_Agencia", Agencia));
                oParametros.Add(new SqlParameter("@p_ContaCorrente", ContaCorrente));
                oParametros.Add(new SqlParameter("@p_CPF", CPF));
                oParametros.Add(new SqlParameter("@p_CodigoUsuario", Funcoes.intCodigoUsuario));
                oParametros.Add(new SqlParameter("@p_CodigoLote", Lote));

                int intPeg = oAcessoBD.ExecutarSql(strSql, oParametros);

                foreach (Guia guia in Guias)
                {
                    strSql = "INSERT INTO guia (valor, peg_id) VALUES (@p_Valor, @p_PegId);select SCOPE_IDENTITY()";

                    oParametros.Clear();
                    oParametros.Add(new SqlParameter("@p_Valor", guia.Valor));
                    oParametros.Add(new SqlParameter("@p_PegId", intPeg));

                    int intGuia = oAcessoBD.ExecutarSql(strSql, oParametros);

                    foreach (Procedimento procedimento in guia.Procedimentos)
                    {
                        strSql = "INSERT INTO evento (segurado, evento, dataatendimento, solicitante, valor, guia_id) values ";
                        strSql += "(@p_segurado, @p_evento, @p_dataatendimento, @p_solicitante, @p_valor, @p_guia_id)";

                        oParametros.Clear();
                        oParametros.Add(new SqlParameter("@p_segurado", procedimento.Segurado));
                        oParametros.Add(new SqlParameter("@p_evento", procedimento.Codigo));
                        oParametros.Add(new SqlParameter("@p_dataatendimento", procedimento.DataAtendimento));
                        oParametros.Add(new SqlParameter("@p_solicitante", procedimento.Solicitante));
                        oParametros.Add(new SqlParameter("@p_valor", procedimento.Valor));
                        oParametros.Add(new SqlParameter("@p_guia_id", intGuia));

                        oAcessoBD.ExecutarSql(oParametros, strSql);

                        Funcoes.GravarDigitacao(Servico, false);
                    }
                }
                oAcessoBD.Desconectar(true);

            }
            catch (Exception ex)
            {
                oAcessoBD.RollBack();
                throw new Exception(ex.Message);
            }
        }
    }

    public class RegistroPeg
    {
        public int intCodigo { get; set; }
        public int intPeg { get; set; }
        public DateTime dttDataRecebimento { get; set; }
        public DateTime dttDataPagamentoIdeal { get; set; }
        public string strRegimeAtendimento { get; set; }
        public string strModulo { get; set; }
        public string strClassificacao { get; set; }
        public decimal decValor { get; set; }
        public DateTime dttDataEnvio { get; set; }
        public string strEmpresa { get; set; }
        public string strConvenio { get; set; }
        public int intCodigoArquivo { get; set; }
        public bool blnDiamante { get; set; }
        public bool blnListagem { get; set; }
        public int intTipoPeg { get; set; }
        public int intStatus { get; set; }
        public int intCodigoUsuario { get; set; }
        public int intCodigoUsuarioTratativa { get; set; }
        public string strResposta { get; set; }
        public string strRespostaTratativa { get; set; }
        public int intResposta { get; set; }
        public int intEventos { get; set; }
        public bool blnPriorizar { get; set; }
        public string strDataDistribuicao { get; set; }
        public string strDataFinalizacao { get; set; }


        public RegistroPeg()
        {
            decValor = 0;
            intCodigoArquivo = 0;
            intEventos = 0;
            intResposta = 0;
            strConvenio = string.Empty;
            blnDiamante = false;
            blnListagem = false;
            blnPriorizar = false;
        }

        AcessoBD oAcessoBD = new AcessoBD();
        string strSql = string.Empty;
        List<SqlParameter> oParametros = new List<SqlParameter>();
        DataTable dtPeg = new DataTable();

        public DataTable ConsultaDuplicidade(string arquivo, int peg)
        {
            try
            {
                strSql = "SELECT TPP_PEG_PEGRP FROM TB_PEG_PORTAL_TPP TPP (NOLOCK) ";
                strSql += "INNER JOIN TB_DETALHE_IMPORTACAO_TDI TDI(NOLOCK) ON TPP.TDI_CODIGO = TDI.TDI_CODIGO ";
                strSql += "WHERE TPP.TPP_PEG_PEGRP = @p_Peg AND TPP.TSP_CODIGO NOT IN (5, 6) ";
                strSql += "AND TDI.TDI_ARQUIVO != @p_Arquivo";

                oParametros.Clear();
                oParametros.Add(new SqlParameter("@p_Peg", peg));
                oParametros.Add(new SqlParameter("@p_Arquivo", arquivo));

                dtPeg = oAcessoBD.ConsultarSql(strSql, oParametros);

                return dtPeg;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ConsultaPeg()
        {
            try
            {
                strSql = "SELECT TPP_CODIGO, TPP.TPP_PEG_PEGRP, TPP_DATARECEBIMENTO_PEGRP, TPP_DATA_PAGAMENTO_IDEAL, TPP_REGIMEATENDIMENTO_PEGR, TPP_MODULO_PEGR, TPP_CONVENIO, \n";
                strSql += "TPP_CLASSIFICACAO, TPP_VALOR, TPP_DATA_ENVIO, TPP_EMPRESA, TPP.TPP_RESPOSTA, ISNULL(TPP_EVENTOS,0) TPP_EVENTOS, TPP_DIAMANTE, TPP_PRIORIZAR, TPP_DATA_DIGITACAO, \n";
                strSql += "TIP_CODIGO, ISNULL(TPP.USU_CODIGO,0) USU_CODIGO, TSP_CODIGO, TPP.TDI_CODIGO, ISNULL(TPT.USU_CODIGO,0) TR_USUARIO, ISNULL(TPT.TPP_RESPOSTA,'') TR_RESPOSTA, \n";
                strSql += "isnull(convert(varchar, PTA_DATA_DISTRIUICAO, 103)+' '+convert(varchar, PTA_DATA_DISTRIUICAO, 108),'') PTA_DATA_DISTRIUICAO, \n";
                strSql += "isnull(convert(varchar, PTA_DATA_FINALIZACAO, 103)+' '+convert(varchar, PTA_DATA_FINALIZACAO, 108),'') PTA_DATA_FINALIZACAO \n";
                strSql += "FROM TB_PEG_PORTAL_TPP TPP (NOLOCK) \n";
                strSql += "INNER JOIN TB_DETALHE_IMPORTACAO_TDI TDI (NOLOCK) ON TPP.TDI_CODIGO = TDI.TDI_CODIGO \n";
                strSql += "LEFT JOIN TB_PEG_TRATATIVA_TPT TPT (NOLOCK) ON TPP.TPP_PEG_PEGRP = TPT.TPP_PEG_PEGRP \n";
                strSql += "LEFT JOIN TB_PEG_TEMPO_ATUACAO_PTA PTA (NOLOCK) ON TPP.TPP_PEG_PEGRP = PTA.TPP_PEG_PEGRP \n";
                strSql += "WHERE TPP.TPP_PEG_PEGRP = @p_Peg  \n";
                strSql += "AND TDI.TDI_SUCESSO = 1 ";
                //strSql += "AND ISNULL(TPP.USU_CODIGO,0) = 0 ";
                //strSql += "and exists (select 1 from TB_PEG_EM_DIGITACAO WHERE TPP_PEG_PEGRP = TPP.TPP_PEG_PEGRP) ";
                oParametros.Clear();
                oParametros.Add(new SqlParameter("@p_Peg", intPeg));
                dtPeg = oAcessoBD.ConsultarSql(strSql, oParametros);

                intCodigo = 0;

                if (dtPeg.Rows.Count > 0)
                {
                    intCodigo = Convert.ToInt32(dtPeg.Rows[0]["TPP_CODIGO"]);
                    dttDataRecebimento = Convert.ToDateTime(dtPeg.Rows[0]["TPP_DATARECEBIMENTO_PEGRP"]);
                    dttDataPagamentoIdeal = Convert.ToDateTime(dtPeg.Rows[0]["TPP_DATA_PAGAMENTO_IDEAL"]);
                    strRegimeAtendimento = dtPeg.Rows[0]["TPP_REGIMEATENDIMENTO_PEGR"].ToString();
                    strResposta = dtPeg.Rows[0]["TPP_RESPOSTA"].ToString();
                    strModulo = dtPeg.Rows[0]["TPP_MODULO_PEGR"].ToString();
                    strClassificacao = dtPeg.Rows[0]["TPP_CLASSIFICACAO"].ToString();
                    blnPriorizar = Convert.ToBoolean(dtPeg.Rows[0]["TPP_PRIORIZAR"]);
                    blnDiamante = Convert.ToBoolean(dtPeg.Rows[0]["TPP_DIAMANTE"]);
                    decValor = Convert.ToDecimal(dtPeg.Rows[0]["TPP_VALOR"]);
                    intEventos = Convert.ToInt32(dtPeg.Rows[0]["TPP_EVENTOS"]);
                    dttDataEnvio = Convert.ToDateTime(dtPeg.Rows[0]["TPP_DATA_ENVIO"]);
                    strEmpresa = dtPeg.Rows[0]["TPP_EMPRESA"].ToString();
                    strConvenio = dtPeg.Rows[0]["TPP_CONVENIO"].ToString();
                    intTipoPeg = Convert.ToInt32(dtPeg.Rows[0]["TIP_CODIGO"]);
                    intCodigoUsuario = Convert.ToInt32(dtPeg.Rows[0]["USU_CODIGO"]);
                    intCodigoUsuarioTratativa = Convert.ToInt32(dtPeg.Rows[0]["TR_USUARIO"]);
                    strRespostaTratativa = dtPeg.Rows[0]["TR_RESPOSTA"].ToString();
                    intStatus = Convert.ToInt32(dtPeg.Rows[0]["TSP_CODIGO"]);
                    intCodigoArquivo = Convert.ToInt32(dtPeg.Rows[0]["TDI_CODIGO"]);
                    strDataDistribuicao = dtPeg.Rows[0]["PTA_DATA_DISTRIUICAO"].ToString();
                    strDataFinalizacao = dtPeg.Rows[0]["PTA_DATA_FINALIZACAO"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void BuscarPeg()
        {
            try
            {
                oAcessoBD.Conectar(false);
                strSql = "sp_retorna_peg";
                oParametros.Clear();
                oParametros.Add(new SqlParameter("@usuario", Funcoes.intCodigoUsuario));
                intPeg = Convert.ToInt32(oAcessoBD.ExecutarSql(strSql, oParametros, CommandType.StoredProcedure));
                ConsultaPeg();
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

        public void AlterarStatusPeg(bool listagem = false)
        {
            try
            {
                oAcessoBD.Conectar(true);
                if (intStatus == 8)
                {
                    oParametros.Clear();
                    strSql = "UPDATE TB_PEG_PORTAL_TPP SET TSP_CODIGO = 7 ";
                    strSql += "WHERE TPP_CODIGO = @p_Codigo";
                    oParametros.Add(new SqlParameter("@p_Codigo", intCodigo));

                    oAcessoBD.ExecutarSql(strSql, oParametros);
                }
                else
                {
                    oParametros.Clear();
                    strSql = "UPDATE TB_PEG_PORTAL_TPP SET TSP_CODIGO = 1, USU_CODIGO = NULL, TPP_RESPOSTA = NULL, TPP_EVENTOS = NULL, TPP_DATA_DIGITACAO = NULL ";
                    if (listagem)
                    {
                        strSql += ", TPP_LISTAGEM = 1 ";
                    }
                    strSql += "WHERE TPP_CODIGO = @p_Codigo";
                    oParametros.Add(new SqlParameter("@p_Codigo", intCodigo));

                    oAcessoBD.ExecutarSql(strSql, oParametros);
                }
                strSql = "DELETE FROM TB_PEG_EM_DIGITACAO WHERE TPP_PEG_PEGRP = @p_Peg";
                oParametros.Clear();
                oParametros.Add(new SqlParameter("@p_Peg", intPeg));

                oAcessoBD.ExecutarSql(strSql, oParametros);
                if (listagem)
                {
                    strSql = "INSERT INTO TB_PEG_ENVIO_LISTAGEM_PEL (PEL_DATA, TPP_PEG_PEGRP, USU_CODIGO, TPP_CODIGO) VALUES ";
                    strSql += "(@p_Data, @p_Peg, @p_Usuario, @p_CodigoPeg)";
                    oParametros.Clear();
                    oParametros.Add(new SqlParameter("@p_Data", DateTime.Now));
                    oParametros.Add(new SqlParameter("@p_Peg", intPeg));
                    oParametros.Add(new SqlParameter("@p_Usuario", Funcoes.intCodigoUsuario));
                    oParametros.Add(new SqlParameter("@p_CodigoPeg", intCodigo));

                    oAcessoBD.ExecutarSql(strSql, oParametros);
                }
            }
            catch (Exception ex)
            {
                oAcessoBD.RollBack();
                throw new Exception(ex.Message);
            }
            finally
            {
                oAcessoBD.Desconectar(true);
            }
        }

        public void Priorizar()
        {
            try
            {
                oAcessoBD.Conectar(false);
                oParametros.Clear();
                strSql = "UPDATE TB_PEG_PORTAL_TPP SET TPP_PRIORIZAR = 1 ";
                strSql += "WHERE TPP_CODIGO = @p_Codigo";
                oParametros.Add(new SqlParameter("@p_Codigo", intCodigo));

                oAcessoBD.ExecutarSql(strSql, oParametros);
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

        public void Gravar()
        {
            try
            {
                bool blnTratativa = false;
                RespostaPeg resposta = new RespostaPeg();

                if (intStatus != 8)
                {
                    oAcessoBD.Conectar(false);
                    strSql = "SELECT ISNULL(TIP_TRATATIVA,0) TIP_TRATATIVA FROM TB_TIPO_PEG_TIP (NOLOCK) WHERE TIP_CODIGO = @tipo_peg";
                    oParametros.Clear();
                    oParametros.Add(new SqlParameter("@tipo_peg", intTipoPeg));

                    blnTratativa = Convert.ToBoolean(oAcessoBD.ExecutarSql(strSql, oParametros));
                    oAcessoBD.Desconectar(false);

                    resposta.intCodigo = intResposta;
                    resposta.Consultar();
                }

                oAcessoBD.Conectar(true);

                if (intStatus == 8)
                {
                    oParametros.Clear();
                    strSql = "UPDATE TB_PEG_PORTAL_TPP SET TSP_CODIGO = @p_status WHERE TPP_CODIGO = @p_Codigo";
                    oParametros.Add(new SqlParameter("@p_Codigo", intCodigo));
                    oParametros.Add(new SqlParameter("@p_status", 9));

                    oAcessoBD.ExecutarSql(strSql, oParametros);

                    oParametros.Clear();
                    strSql = "UPDATE TB_PEG_TRATATIVA_TPT SET TPP_RESPOSTA = @p_resposta, USU_CODIGO = @p_usuario ";
                    strSql += "WHERE TPP_PEG_PEGRP = @p_peg";
                    oParametros.Add(new SqlParameter("@p_usuario", Funcoes.intCodigoUsuario));
                    oParametros.Add(new SqlParameter("@p_resposta", strResposta));
                    oParametros.Add(new SqlParameter("@p_peg", intPeg));

                    oAcessoBD.ExecutarSql(strSql, oParametros);
                }
                else
                {
                    oParametros.Clear();
                    strSql = "UPDATE TB_PEG_PORTAL_TPP SET USU_CODIGO = @p_usuario, TPP_RESPOSTA = @p_resposta, TPP_EVENTOS = @p_eventos, TPP_DATA_DIGITACAO = @p_data, TSP_CODIGO = @p_status ";
                    strSql += "WHERE TPP_CODIGO = @p_Codigo";
                    oParametros.Add(new SqlParameter("@p_Codigo", intCodigo));
                    oParametros.Add(new SqlParameter("@p_usuario", Funcoes.intCodigoUsuario));
                    oParametros.Add(new SqlParameter("@p_resposta", strResposta));
                    oParametros.Add(new SqlParameter("@p_eventos", intEventos));
                    oParametros.Add(new SqlParameter("@p_data", DateTime.Now));

                    if (intStatus == 2 && blnTratativa && resposta.blnEncaminhaTratativa)
                    {
                        intStatus = 7;
                    }
                    else
                    {
                        intStatus = 3;
                    }

                    oParametros.Add(new SqlParameter("@p_status", intStatus));

                    oAcessoBD.ExecutarSql(strSql, oParametros);

                    strSql = "SELECT TPP_DATA_DISTRIBUICAO FROM TB_PEG_EM_DIGITACAO (NOLOCK) WHERE TPP_PEG_PEGRP = @p_Peg";
                    oParametros.Clear();
                    oParametros.Add(new SqlParameter("@p_Peg", intPeg));

                    DateTime dtDistribuicao = Convert.ToDateTime(oAcessoBD.ExecutarSql(strSql, oParametros, CommandType.Text));

                    strSql = "INSERT INTO TB_PEG_TEMPO_ATUACAO_PTA VALUES (@p_peg, @p_Distribuicao, @p_Finalizacao, @p_usuario)";
                    oParametros.Clear();
                    oParametros.Add(new SqlParameter("@p_Peg", intPeg));
                    oParametros.Add(new SqlParameter("@p_Distribuicao", dtDistribuicao));
                    oParametros.Add(new SqlParameter("@p_Finalizacao", DateTime.Now));
                    oParametros.Add(new SqlParameter("@p_usuario", Funcoes.intCodigoUsuario));
                    oAcessoBD.ExecutarSql(strSql, oParametros);
                }
                strSql = "DELETE FROM TB_PEG_EM_DIGITACAO WHERE TPP_PEG_PEGRP = @p_Peg";
                oParametros.Clear();
                oParametros.Add(new SqlParameter("@p_Peg", intPeg));

                oAcessoBD.ExecutarSql(strSql, oParametros);

                if (blnTratativa && resposta.blnEncaminhaTratativa)
                {
                    strSql = "INSERT INTO TB_PEG_TRATATIVA_TPT (TPP_PEG_PEGRP) VALUES (@p_peg)";
                    oParametros.Clear();
                    oParametros.Add(new SqlParameter("@p_Peg", intPeg));
                    oAcessoBD.ExecutarSql(strSql, oParametros);
                }

                int intServico = 1;

                if (intTipoPeg == 1)
                {
                    intServico = 28;
                }
                else if (intTipoPeg == 2)
                {
                    intServico = 29;
                }
                else if (intTipoPeg == 3)
                {
                    intServico = 30;
                }
                else if (intTipoPeg == 4)
                {
                    intServico = 31;
                }

                Funcoes.GravarDigitacao(intServico, false);
            }
            catch (Exception ex)
            {
                oAcessoBD.RollBack();
                throw new Exception(ex.Message);
            }
            finally
            {
                oAcessoBD.Desconectar(true);
            }
        }

        public void AlterarRegime()
        {
            try
            {
                oAcessoBD.Conectar(false);

                oParametros.Clear();
                strSql = "UPDATE TB_PEG_PORTAL_TPP SET TIP_CODIGO = @p_Tipo, TPP_DIAMANTE = @p_diamante, TPP_REGIMEATENDIMENTO_PEGR = @p_regime, TPP_CLASSIFICACAO = @p_classificacao ";
                strSql += "WHERE TPP_CODIGO = @p_Codigo";
                oParametros.Add(new SqlParameter("@p_Codigo", intCodigo));
                oParametros.Add(new SqlParameter("@p_tipo", intTipoPeg));
                oParametros.Add(new SqlParameter("@p_diamante", blnDiamante));
                oParametros.Add(new SqlParameter("@p_regime", strRegimeAtendimento));
                oParametros.Add(new SqlParameter("@p_classificacao", strClassificacao));

                oAcessoBD.ExecutarSql(strSql, oParametros);
            }
            catch (Exception ex)
            {
                oAcessoBD.RollBack();
                throw new Exception(ex.Message);
            }
            finally
            {
                oAcessoBD.Desconectar(false);
            }
        }
    }
    public class ArquivoPeg
    {
        public List<RegistroPeg> registros = new List<RegistroPeg>();
        public List<RegistroPeg> tratativas = new List<RegistroPeg>();
        public string strArquivo { get; set; }
        public string strTratativa { get; set; }
        public int intConsulta { get; set; }
        public int intSADT { get; set; }
        public int intHospital { get; set; }
        public int intDiamante { get; set; }
        public DateTime dttInicioImportacao { get; set; }
        public DateTime dttFimImportacao { get; set; }
        public DateTime dttInicioMigracao { get; set; }
        public DateTime dttFimMigracao { get; set; }
        public DateTime dttDataMigracao { get; set; }

        public ArquivoPeg()
        {
            intConsulta = 0;
            intSADT = 0;
            intHospital = 0;
            intDiamante = 0;
            strArquivo = string.Empty;
            strTratativa = string.Empty;
        }

        AcessoBD oAcessoBD = new AcessoBD();
        string strSql = string.Empty;
        List<SqlParameter> oParametros = new List<SqlParameter>();
        DataTable dt = new DataTable();

        private void GravarStatus(int intCodigoArquivo, string strMensagem, bool blnSucesso, int duplicidade)
        {
            try
            {
                dttFimImportacao = DateTime.Now;

                oParametros.Clear();
                strSql = "UPDATE TB_DETALHE_IMPORTACAO_TDI SET TDI_DUPLICIDADE = @p_Duplicidade, TDI_STATUS = @p_Status, TDI_SUCESSO = @p_sucesso, TDI_DATA_FIM_IMPORTACAO = @p_Data_Fim_Importacao WHERE TDI_CODIGO = @p_Codigo";
                oParametros.Add(new SqlParameter("@p_Duplicidade", duplicidade));
                oParametros.Add(new SqlParameter("@p_Status", strMensagem));
                oParametros.Add(new SqlParameter("@p_Codigo", intCodigoArquivo));
                oParametros.Add(new SqlParameter("@p_Sucesso", blnSucesso));
                oParametros.Add(new SqlParameter("@p_data_Fim_Importacao", dttFimImportacao));

                oAcessoBD.ExecutarSql(strSql, oParametros);
            }
            catch (Exception ex)
            {
                oAcessoBD.RollBack();
                throw new Exception(ex.Message);
            }
        }

        public DataTable SelecionarPegs()
        {
            try
            {
                oParametros.Clear();
                strSql = "select TPP_PEG_PEGRP from TB_PEG_PORTAL_TPP where TPP_DATA_PAGAMENTO_IDEAL = @p_Data_Pagamento_Ideal AND TSP_CODIGO IN (3,9)";

                oParametros.Add(new SqlParameter("@p_Data_Pagamento_Ideal", dttDataMigracao));

                dt = oAcessoBD.ConsultarSql(strSql, oParametros);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Migrar()
        {
            int intCodigoArquivo = 0;
            try
            {

                oAcessoBD.Conectar(true);

                strSql = "INSERT INTO TB_MIGRACAO_PEG_PORTAL_MPP (MPP_TOTAL_REGISTROS, MPP_CONSULTA, MPP_SADT, MPP_HOSPITAL, MPP_DIAMANTE, MPP_DATA_INICIO_MIGRACAO, MPP_ARQUIVO, USU_CODIGO) values ";
                strSql += "(@p_Registros, @p_Consulta, @p_SADT, @p_Hospital, @p_Diamante, @p_Data_Inicio, @p_Arquivo, @p_CodigoUsuario);SELECT @@IDENTITY;";
                oParametros.Clear();
                oParametros.Add(new SqlParameter("@p_Registros", registros.Count));
                oParametros.Add(new SqlParameter("@p_Consulta", intConsulta));
                oParametros.Add(new SqlParameter("@p_SADT", intSADT));
                oParametros.Add(new SqlParameter("@p_Hospital", intHospital));
                oParametros.Add(new SqlParameter("@p_Diamante", intDiamante));
                oParametros.Add(new SqlParameter("@p_Data_Inicio", dttInicioMigracao));
                oParametros.Add(new SqlParameter("@p_Arquivo", System.IO.Path.GetFileNameWithoutExtension(strArquivo)));
                oParametros.Add(new SqlParameter("@p_CodigoUsuario", Funcoes.intCodigoUsuario));

                intCodigoArquivo = oAcessoBD.ExecutarSql(strSql, oParametros);

                using (StreamWriter sw = new StreamWriter(strArquivo, false, Encoding.Default))
                {
                    string strLinha = "PEG_PEGRP;RESPOSTA;DIGITADOR;EVENTOS;DATARECEBIMENTO_PEGRP;Data Pagamento Ideal;REGIMEATENDIMENTO_PEGR;MODULO_PEGR;Classificação;VALOR;data de envio;EMPRESA;Distribuído em;Finalizado em";
                    sw.WriteLine(strLinha);
                    foreach (RegistroPeg registro in registros)
                    {
                        Usuario usuario = new Usuario();
                        registro.ConsultaPeg();
                        usuario.intCodigo = registro.intCodigoUsuario;
                        usuario.ConsultarUsuario();

                        strLinha = string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12};{13}",
                            registro.intPeg.ToString(),
                            registro.strResposta,
                            usuario.strNome,
                            registro.intEventos.ToString(),
                            registro.dttDataRecebimento.ToShortDateString(),
                            registro.dttDataPagamentoIdeal.ToShortDateString(),
                            registro.strRegimeAtendimento,
                            registro.strModulo,
                            registro.strClassificacao,
                            registro.decValor.ToString("#,###.00"),
                            registro.dttDataEnvio.ToShortDateString(),
                            registro.strEmpresa,
                            registro.strDataDistribuicao,
                            registro.strDataFinalizacao
                            );

                        strSql = "UPDATE TB_PEG_PORTAL_TPP SET TSP_CODIGO = @p_status, MPP_CODIGO = @p_CodigoArquivo, TPP_DATA_MIGRACAO = @p_Data_Migracao  WHERE TPP_CODIGO = @p_Codigo";

                        oParametros.Clear();
                        oParametros.Add(new SqlParameter("@p_Codigo", registro.intCodigo));
                        oParametros.Add(new SqlParameter("@p_CodigoArquivo", intCodigoArquivo));
                        oParametros.Add(new SqlParameter("@p_Status", 4));
                        oParametros.Add(new SqlParameter("@p_Data_Migracao", DateTime.Now));

                        oAcessoBD.ExecutarSql(strSql, oParametros);

                        sw.WriteLine(strLinha);
                    }
                }

                using (StreamWriter sw = new StreamWriter(strTratativa, false, Encoding.Default))
                {
                    string strLinha = "PEG_PEGRP;RESPOSTA;DIGITADOR;RESPOSTA_TRATATIVA;DIGITADOR_TRATATIVA";
                    sw.WriteLine(strLinha);
                    foreach (RegistroPeg registro in tratativas)
                    {
                        Usuario usuario = new Usuario();
                        registro.ConsultaPeg();
                        usuario.intCodigo = registro.intCodigoUsuario;
                        usuario.ConsultarUsuario();

                        string digitador = usuario.strNome;

                        usuario = new Usuario();
                        usuario.intCodigo = registro.intCodigoUsuarioTratativa;
                        usuario.ConsultarUsuario();

                        string digitadorTratativa = usuario.strNome;

                        strLinha = string.Format("{0};{1};{2};{3};{4}",
                            registro.intPeg.ToString(),
                            registro.strResposta,
                            digitador,
                            registro.strRespostaTratativa,
                            digitadorTratativa
                            );

                        strSql = "UPDATE TB_PEG_PORTAL_TPP SET TSP_CODIGO = @p_status, MPP_CODIGO = @p_CodigoArquivo, TPP_DATA_MIGRACAO = @p_Data_Migracao  WHERE TPP_CODIGO = @p_Codigo";

                        oParametros.Clear();
                        oParametros.Add(new SqlParameter("@p_Codigo", registro.intCodigo));
                        oParametros.Add(new SqlParameter("@p_CodigoArquivo", intCodigoArquivo));
                        oParametros.Add(new SqlParameter("@p_Status", 10));
                        oParametros.Add(new SqlParameter("@p_Data_Migracao", DateTime.Now));

                        oAcessoBD.ExecutarSql(strSql, oParametros);

                        sw.WriteLine(strLinha);
                    }
                }
                //File.WriteAllText(strArquivo, strLinha, Encoding.UTF8);

                //foreach (RegistroPeg registro in registros)
                //{
                //    strSql = "UPDATE TB_PEG_PORTAL_TPP SET TSP_CODIGO = @p_status, MPP_CODIGO = @p_CodigoArquivo WHERE TPP_CODIGO = @p_Codigo";

                //    oParametros.Clear();
                //    oParametros.Add(new SqlParameter("@p_Codigo", registro.intCodigo));
                //    oParametros.Add(new SqlParameter("@p_CodigoArquivo", intCodigoArquivo));
                //    oParametros.Add(new SqlParameter("@p_Status", 4));

                //    oAcessoBD.ExecutarSql(strSql, oParametros);
                //}

                dttFimMigracao = DateTime.Now;
                strSql = "UPDATE TB_MIGRACAO_PEG_PORTAL_MPP SET MPP_DATA_FIM_MIGRACAO = @p_Data_Termino WHERE MPP_CODIGO = @p_CodigoArquivo ";
                oParametros.Clear();
                oParametros.Add(new SqlParameter("@p_Data_Termino", dttFimMigracao));
                oParametros.Add(new SqlParameter("@p_CodigoArquivo", intCodigoArquivo));
                oAcessoBD.ExecutarSql(strSql, oParametros);

            }
            catch (Exception ex)
            {
                oAcessoBD.RollBack();
                throw new Exception(ex.Message);
            }
            finally
            {
                oAcessoBD.Desconectar(true);
            }
        }

        public string Gravar(string caminho)
        {
            string arquivo = string.Empty;
            int intCodigoArquivo = 0;
            int intDuplicidade = 0;
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oAcessoBD.Conectar(true);

                strSql = "INSERT INTO TB_DETALHE_IMPORTACAO_TDI (TDI_CONSULTA, TDI_SADT, TDI_HOSPITAL, TDI_DIAMANTE, TDI_TOTAL_REGISTROS, TDI_ARQUIVO, TDI_DATA_INICIO_IMPORTACAO) VALUES";
                strSql += "(@p_consulta, @p_sadt, @p_hospital, @p_diamante, @p_total, @p_arquivo, @p_data_Inicio_Importacao);select @@identity;";

                oParametros.Clear();
                oParametros.Add(new SqlParameter("@p_consulta", intConsulta));
                oParametros.Add(new SqlParameter("@p_sadt", intSADT));
                oParametros.Add(new SqlParameter("@p_hospital", intHospital));
                oParametros.Add(new SqlParameter("@p_diamante", intDiamante));
                oParametros.Add(new SqlParameter("@p_total", registros.Count));
                oParametros.Add(new SqlParameter("@p_arquivo", strArquivo));
                oParametros.Add(new SqlParameter("@p_data_Inicio_Importacao", dttInicioImportacao));

                intCodigoArquivo = oAcessoBD.ExecutarSql(strSql, oParametros);

                var query = registros.GroupBy(x => x.intPeg).Where(g => g.Count() > 1).Select(y => y.Key).ToList();


                foreach (RegistroPeg registro in registros)
                {
                    if (query.IndexOf(registro.intPeg) != -1)
                    {
                        registro.intStatus = 6;
                    }
                    else
                    {
                        registro.intStatus = registro.ConsultaDuplicidade(strArquivo, registro.intPeg).Rows.Count != 0 ? 5 : 1;
                    }
                    if (registro.intStatus == 5 || registro.intStatus == 6)
                    {
                        intDuplicidade++;
                    }

                    strSql = "INSERT INTO TB_PEG_PORTAL_TPP (TPP_PEG_PEGRP, TPP_DATARECEBIMENTO_PEGRP, TPP_DATA_PAGAMENTO_IDEAL, TPP_REGIMEATENDIMENTO_PEGR, TPP_MODULO_PEGR, ";
                    strSql += "TPP_CLASSIFICACAO, TPP_VALOR, TPP_DATA_ENVIO, TPP_EMPRESA, TPP_CONVENIO, TPP_DIAMANTE, TPP_LISTAGEM, TPP_PRIORIZAR, TIP_CODIGO, TSP_CODIGO, TDI_CODIGO) VALUES ";
                    strSql += "(@p_Peg, @p_DataRecebimento, @p_DataPagamentoIdeal, @p_RegimaAtendimento, @p_Modulo, ";
                    strSql += "@p_Classificacao, @p_Valor, @p_DataEnvio, @p_Empresa, @p_Convenio, @p_Diamante, @p_Listagem, @p_Priorizar, @p_TipoPeg, @p_Status, @p_CodigoArquivo)";

                    oParametros.Clear();
                    oParametros.Add(new SqlParameter("@p_Peg", registro.intPeg));
                    oParametros.Add(new SqlParameter("@p_DataRecebimento", registro.dttDataRecebimento));
                    oParametros.Add(new SqlParameter("@p_DataPagamentoIdeal", registro.dttDataPagamentoIdeal));
                    oParametros.Add(new SqlParameter("@p_RegimaAtendimento", registro.strRegimeAtendimento));
                    oParametros.Add(new SqlParameter("@p_Modulo", registro.strModulo));
                    oParametros.Add(new SqlParameter("@p_Classificacao", registro.strClassificacao));
                    oParametros.Add(new SqlParameter("@p_Valor", registro.decValor));
                    oParametros.Add(new SqlParameter("@p_DataEnvio", registro.dttDataEnvio));
                    oParametros.Add(new SqlParameter("@p_Empresa", registro.strEmpresa));
                    oParametros.Add(new SqlParameter("@p_Convenio", registro.strConvenio));
                    oParametros.Add(new SqlParameter("@p_Diamante", registro.blnDiamante));
                    oParametros.Add(new SqlParameter("@p_Listagem", registro.blnListagem));
                    oParametros.Add(new SqlParameter("@p_TipoPeg", registro.intTipoPeg));
                    oParametros.Add(new SqlParameter("@p_Priorizar", registro.blnPriorizar));
                    oParametros.Add(new SqlParameter("@p_Status", registro.intStatus));
                    oParametros.Add(new SqlParameter("@p_CodigoArquivo", intCodigoArquivo));

                    oAcessoBD.ExecutarSql(strSql, oParametros);
                }

                GravarStatus(intCodigoArquivo, "Arquivo importado com sucesso", true, intDuplicidade);

                if (query.Count > 0)
                {
                    arquivo = System.IO.Path.GetFileNameWithoutExtension(caminho) + "_Duplicidades.txt";
                    arquivo = System.IO.Path.GetDirectoryName(caminho) + @"\" + arquivo;
                    TextWriter tw = new StreamWriter(arquivo);

                    foreach (int s in query)
                    {
                        tw.WriteLine(s.ToString());
                    }
                    tw.Close();
                }
                return arquivo;
            }
            catch (Exception ex)
            {
                GravarStatus(intCodigoArquivo, string.Format("Arquivo não importado. Erro:{0}", ex.Message), false, 0);

                //oAcessoBD.RollBack();
                throw new Exception(ex.Message);
            }
            finally
            {
                oAcessoBD.Desconectar(true);
            }
        }
        public DataTable Consultar()
        {
            try
            {
                oParametros.Clear();
                strSql = "select TDI_CODIGO, TDI_TOTAL_REGISTROS[Registros Importados], TDI_CONSULTA[Consultório / Clinica], TDI_SADT[Atendimento Externo]";
                strSql += ", TDI_HOSPITAL[Hospital / Maternidade], TDI_DIAMANTE[Diamante], TDI_DUPLICIDADE[Duplicidade], CONVERT(VARCHAR(10),TDI_DATA_INICIO_IMPORTACAO,103) +' '+ convert(varchar(8),tdi_data_inicio_importacao,114) [Data Importação]";
                strSql += ", TDI_ARQUIVO[Nome Arquivo], TDI_STATUS[Status], case when TDI_SUCESSO = 1 then 'Sim' else 'Não' end [Importado com Sucesso]";
                strSql += " from TB_DETALHE_IMPORTACAO_TDI ";

                if (strArquivo != string.Empty)
                {
                    strSql += "WHERE TDI_ARQUIVO = @p_Arquivo and TDI_SUCESSO = 1";
                    oParametros.Add(new SqlParameter("@p_Arquivo", strArquivo));
                }

                dt = oAcessoBD.ConsultarSql(strSql, oParametros);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

    public class RespostaPeg
    {
        public int intCodigo { get; set; }
        public string strDescricao { get; set; }
        public bool blnCampoExtra { get; set; }
        public bool blnAtivo { get; set; }
        public bool blnEncaminhaTratativa { get; set; }
        public bool blnSomenteTratativa { get; set; }

        public RespostaPeg()
        {
            intCodigo = 0;
            strDescricao = string.Empty;
            blnCampoExtra = false;
            blnAtivo = true;
            blnEncaminhaTratativa = false;
            blnSomenteTratativa = false;
        }

        AcessoBD oAcessoBD = new AcessoBD();
        string strSql = string.Empty;
        List<SqlParameter> oParametros = new List<SqlParameter>();
        DataTable dt = new DataTable();

        public void Gravar()
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                oAcessoBD.Conectar(false);
                oParametros.Clear();

                if (intCodigo == 0)
                {
                    strSql = "INSERT INTO TB_RESPOSTA_PEG_TRP (TRP_DESCRICAO, TRP_CAMPO_EXTRA, TRP_ATIVO, TRP_TRATATIVA, TRP_SOMENTE_TRATATIVA) VALUES (@p_descricao, @p_campo_extra, @p_ativo, @p_tratativa, @p_somente_tratativa)";
                }
                else
                {
                    strSql = "UPDATE TB_RESPOSTA_PEG_TRP SET ";
                    strSql += "TRP_DESCRICAO = @p_descricao, ";
                    strSql += "TRP_CAMPO_EXTRA = @p_campo_extra, ";
                    strSql += "TRP_ATIVO = @p_ativo, ";
                    strSql += "TRP_TRATATIVA = @p_tratativa, ";
                    strSql += "TRP_SOMENTE_TRATATIVA = @p_somente_tratativa ";
                    strSql += "WHERE TRP_CODIGO = @p_Codigo";
                    oParametros.Add(new SqlParameter("@p_Codigo", intCodigo));

                }
                oParametros.Add(new SqlParameter("@p_descricao", strDescricao));
                oParametros.Add(new SqlParameter("@p_campo_extra", blnCampoExtra));
                oParametros.Add(new SqlParameter("@p_ativo", blnAtivo));
                oParametros.Add(new SqlParameter("@p_tratativa", blnEncaminhaTratativa));
                oParametros.Add(new SqlParameter("@p_somente_tratativa", blnSomenteTratativa));

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
        public void Excluir()
        {
            try
            {
                oAcessoBD.Conectar(false);
                oParametros.Clear();
                strSql = "DELETE FROM TB_RESPOSTA_PEG_TRP WHERE TRP_CODIGO = @p_Codigo";
                oParametros.Add(new SqlParameter("@p_Codigo", this.intCodigo));
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
        public DataTable Consultar(bool blnSomenteAtivos = false, bool blnSomenteTratativa = false)
        {
            try
            {
                //Funcoes.Log(string.Format("[{0}] {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                strSql = "SELECT TRP_CODIGO, TRP_DESCRICAO, CASE WHEN TRP_CAMPO_EXTRA = 1 THEN 'Sim' else 'Não' END TRP_CAMPO_EXTRA, ";
                strSql += "TRP_ATIVO, CASE WHEN TRP_TRATATIVA = 1 THEN 'Sim' else 'Não' END TRP_TRATATIVA, ";
                strSql += "CASE WHEN TRP_SOMENTE_TRATATIVA = 1 THEN 'Sim' else 'Não' END TRP_SOMENTE_TRATATIVA FROM TB_RESPOSTA_PEG_TRP (NOLOCK) ";
                oParametros.Clear();

                if (this.intCodigo != 0)
                {
                    strSql += "WHERE TRP_CODIGO  = @p_Codigo ";
                    oParametros.Add(new SqlParameter("@p_Codigo", this.intCodigo));
                }
                else if (strDescricao != string.Empty)
                {
                    strSql += "WHERE TRP_DESCRICAO LIKE @p_Descricao ";
                    oParametros.Add(new SqlParameter("@p_Descricao", "%" + this.strDescricao + "%"));
                }
                if (intCodigo == 0 && strDescricao == string.Empty)
                {
                    if (blnSomenteAtivos)
                    {
                        if (strSql.IndexOf("WHERE") == -1)
                        {
                            strSql += "WHERE ";
                        }
                        else
                        {
                            strSql += " AND ";
                        }
                        strSql += "TRP_ATIVO = 1 ";
                        strSql += string.Format("AND TRP_SOMENTE_TRATATIVA = {0}", blnSomenteTratativa ? 1 : 0);
                    }
                }

                strSql += " ORDER BY TRP_DESCRICAO";
                dt = oAcessoBD.ConsultarSql(strSql, oParametros);

                if (this.intCodigo != 0)
                {
                    this.intCodigo = Convert.ToInt32(dt.Rows[0]["TRP_CODIGO"]);
                    this.strDescricao = dt.Rows[0]["TRP_DESCRICAO"].ToString();
                    this.blnCampoExtra = dt.Rows[0]["TRP_CAMPO_EXTRA"].ToString() == "Sim" ? true : false;
                    this.blnAtivo = Convert.ToBoolean(dt.Rows[0]["TRP_ATIVO"]);
                    this.blnEncaminhaTratativa = dt.Rows[0]["TRP_TRATATIVA"].ToString() == "Sim" ? true : false;
                    this.blnSomenteTratativa = dt.Rows[0]["TRP_SOMENTE_TRATATIVA"].ToString() == "Sim" ? true : false;
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

    public class ArquivoDavita
    {
        public int Codigo { get; set; }
        public string NomeArquivo { get; set; }
        public DateTime DataProcessamento { get; set; }
        public string Status { get; set; }
        public string CaminhoSaida { get; set; }
        public List<PegDavita> pegs = new List<PegDavita>();

        AcessoBD oAcessoBD = new AcessoBD();
        DataTable dtServico = new DataTable();
        List<SqlParameter> oParametros = new List<SqlParameter>();
        string strSql = string.Empty;

        public ArquivoDavita()
        {
            Codigo = 0;
            NomeArquivo = string.Empty;
            DataProcessamento = DateTime.Now;
            Status = string.Empty;
            CaminhoSaida = string.Empty;
        }

        public void Processar()
        {
            try
            {
                oAcessoBD.Conectar(true);
                strSql = "INSERT INTO TB_IMPORTACAO_PLANILHA_DAVITA_IPD (IPD_NOME_ARQUIVO, IPD_DATA_PROCESSAMENTO, IPD_STATUS) VALUES ";
                strSql += "(@p_nome_arquivo, @p_data_processamento, @p_status);SELECT @@IDENTITY;";
                oParametros.Clear();
                oParametros.Add(new SqlParameter("@p_nome_arquivo", NomeArquivo));
                oParametros.Add(new SqlParameter("@p_data_processamento", DataProcessamento));
                oParametros.Add(new SqlParameter("@p_status", Status));

                Codigo = oAcessoBD.ExecutarSql(strSql, oParametros);

                foreach (PegDavita peg in pegs)
                {
                    string strArquivo = string.Format(@"{0}\04_{1}.txt", CaminhoSaida, peg.NumeroPeg);
                    string linha = string.Empty;

                    using (StreamWriter sw = new StreamWriter(strArquivo, false, Encoding.Default))
                    {
                        oParametros.Clear();
                        peg.CodigoArquivo = Codigo;

                        strSql = "INSERT INTO TB_PLANILHA_PEG_DAVITA_PPD (PPD_NR_PEG, PPD_LOTE, IPD_CODIGO) VALUES ";
                        strSql += "(@p_numero_peg, @p_lote, @p_codigo_arquivo);SELECT @@IDENTITY;";

                        oParametros.Add(new SqlParameter("@p_numero_peg", peg.NumeroPeg));
                        oParametros.Add(new SqlParameter("@p_lote", peg.Lote));
                        oParametros.Add(new SqlParameter("@p_codigo_arquivo", peg.CodigoArquivo));

                        peg.Codigo = oAcessoBD.ExecutarSql(strSql, oParametros);
                        //0100000000289151  00000000000101068109472241
                        //0100000000289151  00000000000101068109473241
                        string strLinha = string.Format("01{0}  {1}{2}",
                            peg.Lote.ToString().PadLeft(14, '0'),
                            peg.ValorTotal.ToString().Replace(",", "").PadLeft(18, '0'),
                            peg.NumeroPeg.ToString().PadLeft(8, '0'));

                        sw.WriteLine(strLinha);

                        foreach (RegistroDavita registro in peg.registros)
                        {
                            registro.CodigoPeg = peg.Codigo;
                            oParametros.Clear();
                            strSql = "INSERT INTO TB_REGISTROS_PEG_DAVITA_RPD (RPD_ATENDIMENTO, RPD_PACIENTE, RPD_DATA_HORA, RPD_MAT_MED, RPD_CARTEIRINHA, RPD_VALOR, RPD_QTDE, RPD_SENHA, RPD_CRM, RPD_MEDICO, RPD_CBOS, PPD_CODIGO) VALUES ";
                            strSql += "(@p_atendimento, @p_paciente, @p_data_hora, @p_mat_med, @p_carteirinha, @p_valor, @p_qtde, @p_senha, @p_crm, @p_medico, @p_cbos, @p_codigo_peg)";

                            oParametros.Add(new SqlParameter("@p_atendimento", registro.Atendimento));
                            oParametros.Add(new SqlParameter("@p_paciente", registro.Paciente));
                            oParametros.Add(new SqlParameter("@p_data_hora", registro.DataHora));
                            oParametros.Add(new SqlParameter("@p_mat_med", registro.MatMed));
                            oParametros.Add(new SqlParameter("@p_carteirinha", registro.Carteirinha));
                            oParametros.Add(new SqlParameter("@p_valor", registro.Valor));
                            oParametros.Add(new SqlParameter("@p_qtde", registro.Quantidade));
                            oParametros.Add(new SqlParameter("@p_senha", registro.Senha));
                            oParametros.Add(new SqlParameter("@p_crm", registro.CRM));
                            oParametros.Add(new SqlParameter("@p_medico", registro.Medico));
                            oParametros.Add(new SqlParameter("@p_cbos", registro.CBOS));
                            oParametros.Add(new SqlParameter("@p_codigo_peg", registro.CodigoPeg));

                            oAcessoBD.ExecutarSql(strSql, oParametros);

                            //022000000000441303540002000000000000000000000000000000001234567812112019441303540002340012112019                                                     00000000000                      00000 0000 00 0000000000289151                                                                             000000000000000  2231.150000000000000000                                                                             000000000000000  2231.15                                                                                                    000000011117000000000000000000000000000000000000000000000000000000000000000000000000
                            //022000000000441303540002000000000000000000000000000000000004413014112019441303540002340014112019                                                     00000000000                      00000 0000 00 0000000000289151                                                                             000000000000000  2231.150000000000000000                                                                             000000000000000  2231.15                                                                                                    000000011117000000000000000000000000000000000000000000000000000000000000000000000000
                            strLinha = string.Format("022000000000{0}0000000000000000000000000{1}{2}{3}00{4}                                                     00000000000                      00000 0000 00 {5}                                                                             000000000000000{6}0000000000000000                                                                             000000000000000{6}                                                                                                    {7}000000000000000000000000000000000000000000000000000000000000000000000000",
                                registro.Carteirinha.Substring(0, 12),
                                registro.Senha.ToString().PadLeft(15, '0'),
                                registro.DataHora.ToString("ddMMyyyy"),
                                registro.Carteirinha.Substring(0, 14),
                                registro.DataHora.ToString("ddMMyyyy"),
                                peg.Lote.ToString().PadLeft(16, '0'),
                                registro.CBOS.PadLeft(9, ' '),
                                registro.Valor.ToString().Replace(",", "").PadLeft(12, '0')
                                );
                            sw.WriteLine(strLinha);
                            //030000000012112019        00N00010278    00000100U 00000001111700000000000000                                                                             000000000000000  
                            //030000000014112019        00N00010278    00000100U 00000001111700000000000000                                                                             000000000000000  
                            strLinha = string.Format("0300000000{0}        00N{1}    {2}U {3}00000000000000                                                                             000000000000000  ",
                                registro.DataHora.ToString("ddMMyyyy"),
                                registro.MatMed.ToString().PadLeft(8, '0'),
                                (registro.Quantidade * 100).ToString().PadLeft(8, '0'),
                                registro.Valor.ToString().Replace(",", "").PadLeft(12, '0')
                                );
                            sw.WriteLine(strLinha);
                        }
                    }
                }

                oAcessoBD.Desconectar(true);
            }
            catch (Exception ex)
            {
                oAcessoBD.RollBack();
                throw new Exception(ex.Message);
            }
        }
    }
    public class PegDavita
    {
        public int Codigo { get; set; }
        public int NumeroPeg { get; set; }
        public int Lote { get; set; }
        public int CodigoArquivo { get; set; }
        public decimal ValorTotal { get; set; }
        public List<RegistroDavita> registros = new List<RegistroDavita>();
        public PegDavita()
        {
            Codigo = 0;
            NumeroPeg = 0;
            Lote = 0;
            CodigoArquivo = 0;
            ValorTotal = 0;
        }
    }
    public class RegistroDavita
    {
        public int Codigo { get; set; }
        public int Atendimento { get; set; }
        public string Paciente { get; set; }
        public DateTime DataHora { get; set; }
        public int MatMed { get; set; }
        public string Carteirinha { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public int Senha { get; set; }
        public string CRM { get; set; }
        public string Medico { get; set; }
        public string CBOS { get; set; }
        public int CodigoPeg { get; set; }

        public RegistroDavita()
        {
            Codigo = 0;
            Atendimento = 0;
            Paciente = string.Empty;
            DataHora = DateTime.Now;
            MatMed = 0;
            Carteirinha = string.Empty;
            Valor = 0;
            Quantidade = 0;
            Senha = 0;
            CRM = string.Empty;
            Medico = string.Empty;
            CBOS = string.Empty;
            CodigoPeg = 0;
        }
    }

    public class Nfe
    {
        public int Codigo { get; set; }
        public int Peg { get; set; }
        public int Numero { get; set; }
        public DateTime DataEmissao { get; set; }
        public string CPF_CNPJ { get; set; }
        public string CodigoVerificacao { get; set; }
        public bool Cancelada { get; set; }
        public bool Existente { get; set; }
        public string URL { get; set; }
        public string Erro { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataVerificacao { get; set; }

        public Nfe()
        {
            Codigo = 0;
            Peg = 0;
            Numero = 0;
            DataEmissao = DateTime.Now;
            CPF_CNPJ = string.Empty;
            CodigoVerificacao = string.Empty;
            Cancelada = false;
            URL = string.Empty;
            Erro = string.Empty;
            DataInclusao = DateTime.Now;
            DataVerificacao = DateTime.Now;
            Existente = false;
        }

        string strSql = string.Empty;
        List<SqlParameter> oParametros = new List<SqlParameter>();
        DataTable dt = new DataTable();
        AcessoBD oAcessoBD = new AcessoBD();

        public DataTable Consultar()
        {
            try
            {
                oParametros.Clear();
                strSql = "SELECT TOP 1 NFE_CODIGO, NFE_PEG, NFE_NUMERO, NFE_DATA_EMISSAO, NFE_CODIGO_VERIFICACAO, NFE_CPF_CNPJ, NFE_URL, NFE_ERRO, NFE_CANCELADA, NFE_EXISTENTE, NFE_DATA_INCLUSAO, NFE_DATA_VERIFICACAO ";
                strSql += "FROM TB_NFE WHERE NFE_NUMERO = @p_Numero and NFE_CPF_CNPJ = @p_CPF_CNPJ AND NFE_PEG = @p_peg";

                oParametros.Add(new SqlParameter("@p_Numero", Numero));
                oParametros.Add(new SqlParameter("@p_peg", Peg));
                oParametros.Add(new SqlParameter("@p_CPF_CNPJ", CPF_CNPJ));
                //oAcessoBD.Conectar(false);
                dt = oAcessoBD.ConsultarSql(strSql, oParametros);

                if (dt.Rows.Count == 1)
                {
                    Codigo = Convert.ToInt32(dt.Rows[0]["NFE_CODIGO"]);
                    Peg = Convert.ToInt32(dt.Rows[0]["NFE_PEG"]);
                    Numero = Convert.ToInt32(dt.Rows[0]["NFE_NUMERO"]);
                    DataEmissao = Convert.ToDateTime(dt.Rows[0]["NFE_DATA_EMISSAO"]);
                    CodigoVerificacao = dt.Rows[0]["NFE_CODIGO_VERIFICACAO"].ToString();
                    CPF_CNPJ = dt.Rows[0]["NFE_CPF_CNPJ"].ToString();
                    URL = dt.Rows[0]["NFE_URL"].ToString();
                    Cancelada = Convert.ToBoolean(dt.Rows[0]["NFE_CANCELADA"]);
                    Existente = Convert.ToBoolean(dt.Rows[0]["NFE_EXISTENTE"]);
                    Erro = dt.Rows[0]["NFE_ERRO"].ToString();
                    DataInclusao = Convert.ToDateTime(dt.Rows[0]["NFE_DATA_INCLUSAO"]);
                    DataVerificacao = Convert.ToDateTime(dt.Rows[0]["NFE_DATA_VERIFICACAO"]);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Gravar()
        {
            try
            {
                oParametros.Clear();
                strSql = "INSERT INTO TB_NFE (NFE_PEG, NFE_NUMERO, NFE_DATA_EMISSAO, NFE_CODIGO_VERIFICACAO, NFE_CPF_CNPJ, NFE_URL, NFE_ERRO, NFE_CANCELADA, NFE_EXISTENTE, NFE_DATA_INCLUSAO, NFE_DATA_VERIFICACAO) values ";
                strSql += "(@p_Peg, @p_Numero, @p_DataEmissao, @p_CodigoVerificacao, @p_CPF_CNPJ, @p_URL, @p_Erro, @p_Cancelada, @p_Existente, @p_DataInclusao, @p_DataVerificacao)";

                oParametros.Add(new SqlParameter("@p_Peg", Peg));
                oParametros.Add(new SqlParameter("@p_Numero", Numero));
                oParametros.Add(new SqlParameter("@p_DataEmissao", DataEmissao));
                oParametros.Add(new SqlParameter("@p_CodigoVerificacao", CodigoVerificacao));
                oParametros.Add(new SqlParameter("@p_CPF_CNPJ", CPF_CNPJ));
                oParametros.Add(new SqlParameter("@p_Cancelada", Cancelada));
                oParametros.Add(new SqlParameter("@p_URL", URL));
                oParametros.Add(new SqlParameter("@p_Erro", Erro));
                oParametros.Add(new SqlParameter("@p_Existente", Existente));
                oParametros.Add(new SqlParameter("@p_DataInclusao", DataInclusao));
                oParametros.Add(new SqlParameter("@p_DataVerificacao", DataVerificacao));
                oAcessoBD.Conectar(false);
                oAcessoBD.ExecutarSql(strSql, oParametros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}


