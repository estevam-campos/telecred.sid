using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace SID_Telecred
{
    class AcessoBD
    {
        SqlConnection oConn;
        SqlTransaction oTrans;
        StreamWriter strArquivo;

        public void Conectar(bool blnBeginTrans)
        {
            try
            {
                oConn = null;
                oConn = new SqlConnection(Funcoes.strStringConnexao);
                oConn.Open();
                if (blnBeginTrans)
                {
                    oTrans = oConn.BeginTransaction();
                }
                else
                {
                    oTrans = null;
                }
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }
        public void Desconectar(bool blnCommitTrans)
        {
            try
            {
                if (oConn.State == ConnectionState.Open)
                {
                    if (blnCommitTrans)
                    {
                        oTrans.Commit();
                    }
                    //oConn.Close();
                    //oConn.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
            finally
            {
                oConn.Close();
                oConn.Dispose();
                //if (oTrans != null)
                  //  oTrans.Dispose();
               // SqlConnection.ClearAllPools();
            }
        }
        public int ExecutarSql(List<SqlParameter> pParams, string pSQL)
        {
            SqlCommand oCmd = null;
            try
            {
                oCmd = new SqlCommand(pSQL, oConn);
                oCmd.CommandTimeout = 90;
                if (oTrans != null)
                {
                    oCmd.Transaction = oTrans;
                }
                foreach (SqlParameter param in pParams)
                {
                    oCmd.Parameters.Add(param);
                }
                return oCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
            finally
            {
                oCmd.Dispose();
                //LogSql(pSQL, pParams);
            }
        }
        public int ExecutarSql(string pSQL, List<SqlParameter> pParams)
        {
            SqlCommand oCmd = null;
            try
            {
                int intRetorno = 0;
                oCmd = new SqlCommand(pSQL, oConn);
                oCmd.CommandTimeout = 90;
                if (oTrans != null)
                {
                    oCmd.Transaction = oTrans;
                }
                foreach (SqlParameter param in pParams)
                {
                    oCmd.Parameters.Add(param);
                }
                intRetorno = Convert.ToInt32(oCmd.ExecuteScalar());
                return intRetorno;
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
            finally
            {
                oCmd.Dispose();
                //LogSql(pSQL, pParams);
            }
        }
        public string ExecutarSql(string pSQL, List<SqlParameter> pParams, CommandType commandType)
        {
            SqlCommand oCmd = null;
            try
            {
                string Retorno = string.Empty;
                oCmd = new SqlCommand(pSQL, oConn);
                oCmd.CommandTimeout = 90;
                oCmd.CommandType = commandType;
                if (oTrans != null)
                {
                    oCmd.Transaction = oTrans;
                }
                foreach (SqlParameter param in pParams)
                {
                    oCmd.Parameters.Add(param);
                }
                Retorno = Convert.ToString(oCmd.ExecuteScalar());
                return Retorno;
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
            finally
            {
                oCmd.Dispose();
                //LogSql(pSQL, pParams);
            }
        }
        public DataTable ConsultarSql(string pSQL, List<SqlParameter> pParams)
        {
            SqlCommand oCmd = null;
            try
            {
                this.Conectar(false);
                oCmd = new SqlCommand(pSQL, oConn);
                //oCmd.CommandTimeout = 90;
                foreach (SqlParameter param in pParams)
                {
                    oCmd.Parameters.Add(param);
                }
                SqlDataAdapter oAdp = new SqlDataAdapter(oCmd);
                DataSet ds = new DataSet();
                oAdp.Fill(ds);
                //this.Desconectar(false);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
            finally
            {
                oCmd.Dispose();
                this.Desconectar(false);
                //LogSql(pSQL, pParams);
            }
        }

        public DataTable ConsultarSql(string pSQL, List<SqlParameter> pParams, CommandType type)
        {
            SqlCommand oCmd = null;
            try
            {
                this.Conectar(false);

                oCmd = new SqlCommand(pSQL.ToUpper().Trim(), oConn);
                oCmd.CommandType = type;

                foreach (SqlParameter param in pParams)
                {
                    oCmd.Parameters.Add(param);
                }
                SqlDataAdapter oAdp = new SqlDataAdapter(oCmd);
                DataSet ds = new DataSet();
                oAdp.Fill(ds);
                //this.Desconectar(false);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
            finally
            {
                oCmd.Dispose();
                this.Desconectar(false);
            }
        }


        public void ExportarDados(DateTime dttInicio, DateTime dttTermino, int intServico, string strFile, string strChave)
        {
            try
            {
                using (FileStream fs = new FileStream(strFile, FileMode.Create, FileAccess.Write)) ;
                strArquivo = new StreamWriter(strFile);

                this.Conectar(true);

                string pSQL = "UPDATE TB_REGISTRO_REG SET REG_CHAVE = @p_Chave, REG_DATA_EXPORTACAO = @p_DataExportacao ";
                pSQL += "WHERE SER_CODIGO = @p_Servico AND REG_DATA BETWEEN @p_Inicio AND @p_Termino";

                SqlCommand oCmd = new SqlCommand(pSQL, oConn);
                oCmd.CommandTimeout = 90;
                oCmd.Transaction = oTrans;
                oCmd.Parameters.Add(new SqlParameter("@p_Chave", strChave));
                oCmd.Parameters.Add(new SqlParameter("@p_DataExportacao", DateTime.Now));

                oCmd.Parameters.Add(new SqlParameter("@p_Servico", intServico));
                oCmd.Parameters.Add(new SqlParameter("@p_Inicio", dttInicio));
                oCmd.Parameters.Add(new SqlParameter("@p_Termino", dttTermino));

                Funcoes.intTotalRegistros = oCmd.ExecuteNonQuery();
                oCmd.Dispose();
                oCmd = new SqlCommand(pSQL, oConn);
                oCmd.CommandTimeout = 90;
                oCmd.Transaction = oTrans;
                pSQL = "select REG_CODIGO from TB_REGISTRO_REG (NOLOCK) WHERE REG_CHAVE = @p_Chave";
                oCmd.Parameters.Add(new SqlParameter("@p_Chave", strChave));

                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    Funcoes.intTotReg = 0;
                    using (strArquivo)
                    {
                        while (oReader.Read())
                        {
                            Funcoes.intContReg++;
                            int intRegistro = Convert.ToInt32(oReader[0]);
                            pSQL = "SELECT VAL_CONTEUDO FROM TB_VALOR_VAL (NOLOCK) WHERE REG_CODIGO = @p_Registro ORDER BY CPO_ORDEM";
                            DataTable dtLinha = new DataTable();
                            List<SqlParameter> oParametros = new List<SqlParameter>();
                            oParametros.Add(new SqlParameter("@p_Registro", intRegistro));
                            dtLinha = ConsultarSql(pSQL, oParametros);
                            string strLinha = string.Empty;
                            foreach (DataRow linha in dtLinha.Rows)
                            {
                                strLinha += linha[0].ToString() + ";";
                            }
                            strArquivo.WriteLine(strLinha.Substring(0, strLinha.Length - 1));
                            strLinha = string.Empty;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RollBack();
                throw (new Exception(ex.Message));
            }
            finally
            {
                strArquivo.Close();
                this.Desconectar(true);
            }
        }
        public void CancelarExportacao(string strChave)
        {
            try
            {
                this.Conectar(true);

                string pSQL = "UPDATE TB_REGISTRO_REG SET REG_CHAVE = null, REG_DATA_EXPORTACAO = null ";
                pSQL += "WHERE SER_CHAVE = @p_Chave";

                SqlCommand oCmd = new SqlCommand(pSQL, oConn);
                oCmd.CommandTimeout = 90;
                oCmd.Transaction = oTrans;
                oCmd.Parameters.Add(new SqlParameter("@p_Chave", strChave));

                oCmd.ExecuteNonQuery();
                oCmd.Dispose();
                oCmd = new SqlCommand(pSQL, oConn);
                oCmd.CommandTimeout = 90;
                oCmd.Transaction = oTrans;

                this.Desconectar(true);
            }
            catch (Exception ex)
            {
                RollBack();
                throw (new Exception(ex.Message));
            }
        }

        public void RollBack()
        {
            oTrans.Rollback();
            oConn.Close();
            oConn.Dispose();
        }

        public SqlDataReader ExecutarReader(string pSQL, List<SqlParameter> pParams)
        {
            try
            {
                SqlDataReader oReader;
                //this.Conectar(false);
                SqlCommand oCmd = new SqlCommand(pSQL, oConn);
                oCmd.CommandTimeout = 90;
                foreach (SqlParameter param in pParams)
                {
                    oCmd.Parameters.Add(param);
                }
                oReader = oCmd.ExecuteReader();
                return oReader;
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }
        //public void LogSql(string pQuery, List<SqlParameter> pSqlParams)
        //{
        //    string pSQL = string.Empty;
        //    try
        //    {
        //        this.Conectar(false);
        //        SqlCommand oCmd = new SqlCommand();

        //        pSQL = "INSERT INTO TB_QUERIES_TQU (TQU_QUERY, TQU_PARAMETERS, TQU_DATA, USU_CODIGO) VALUES (@p_query, @p_parameters, @p_Data, @p_usuario)";

        //        if (Funcoes.intCodigoUsuario != 0)
        //        {
        //            oCmd.Parameters.Add(new SqlParameter("@p_usuario", Funcoes.intCodigoUsuario));
        //        }
        //        else
        //        {
        //            pSQL = pSQL.Replace(", USU_CODIGO", "");
        //            pSQL = pSQL.Replace(", @p_usuario", "");
        //        }

        //        oCmd.CommandText = pSQL;
        //        oCmd.Connection = oConn;

        //        string strParameters = string.Empty;

        //        foreach (SqlParameter p in pSqlParams)
        //        {
        //            strParameters += "|" + p.ParameterName + " = " + p.Value.ToString();
        //        }

        //        oCmd.Parameters.Add(new SqlParameter("@p_query", pQuery.ToUpper().Trim()));
        //        oCmd.Parameters.Add(new SqlParameter("@p_parameters", strParameters != string.Empty ? strParameters.Substring(1) : strParameters));
        //        oCmd.Parameters.Add(new SqlParameter("@p_Data", DateTime.Now));

        //        oCmd.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (new Exception(ex.Message));
        //    }
        //    finally
        //    {
        //        this.Desconectar(false);
        //    }
        //}
    }
}
