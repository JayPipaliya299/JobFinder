﻿using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SQLHelper
{
    public enum CurrentDatabase
    {
        ArjunWeb,
        TraceMe,
        TraceMeNew
    }

    public class SqlHelper
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public MEMBERS.SQLReturnMessageNValue ExecuteProceduerWithMessageNValueSpecial(string ProceduerName
            , object obj
            , int ReturnTypeOutVal = 3)
        {
            MEMBERS.SQLReturnMessageNValue res = new MEMBERS.SQLReturnMessageNValue();

            try
            {
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = ProceduerName,
                    Connection = con,
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter[] param = new SQLPatameterClass().ConvertClassToSQLParams(obj);
                cmd.Parameters.AddRange(param);
                cmd.Parameters.Add("OUTVAL", (ReturnTypeOutVal == 1 ? SqlDbType.UniqueIdentifier : SqlDbType.Int)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("OUTMESSAGE", SqlDbType.NVarChar, -1).Direction = ParameterDirection.Output;
                if (con.State != ConnectionState.Open) { con.Open(); }
                cmd.ExecuteNonQuery();
                con.Close();
                res.Outval = cmd.Parameters["OUTVAL"].Value;
                res.Outmsg = cmd.Parameters["OUTMESSAGE"].Value.ToString();
            }
            catch (Exception ee)
            {
                res.Outval = 0;
                res.Outmsg = "Error : " + ee.Message;
            }
            return res;
        }

        public MEMBERS.SQLReturnValue ExecuteProceduerWithValueSpecial(string ProceduerName
            , object obj
            , int ReturnTypeOutVal = 3)
        {
            SqlConnection con = new SqlConnection();

            MEMBERS.SQLReturnValue res = new MEMBERS.SQLReturnValue();

            try
            {
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = ProceduerName,
                    Connection = con,
                    CommandType = CommandType.StoredProcedure
                };
                if (obj != null)
                {
                    SqlParameter[] param = new SQLPatameterClass().ConvertClassToSQLParams(obj);
                    cmd.Parameters.AddRange(param);
                }
                cmd.Parameters.Add("OUTVAL", (ReturnTypeOutVal == 1 ? SqlDbType.UniqueIdentifier : ReturnTypeOutVal == 2 ? SqlDbType.Int : SqlDbType.NVarChar), -1).Direction = ParameterDirection.Output;
                if (con.State != ConnectionState.Open) { con.Open(); }
                cmd.ExecuteNonQuery();
                con.Close();
                res.Outval = cmd.Parameters["OUTVAL"].Value;
            }
            catch (Exception ee)
            {
                res.Outval = "Error : " + ee.Message;
            }
            return res;
        }

        public MEMBERS.SQLReturnMessageNValue ExecuteProceduerWithMessageNValue(string ProceduerName
            , object[,] ParamValue
            , int ReturnTypeOutVal = 3)
        {
            MEMBERS.SQLReturnMessageNValue res = new MEMBERS.SQLReturnMessageNValue();

            try
            {
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = ProceduerName,
                    Connection = con,
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter[] param = new SqlParameter[ParamValue.GetUpperBound(0) + 1];
                for (int i = 0; i < param.Length; i++)
                {
                    param[i] = new SqlParameter("@" + ParamValue[i, 0].ToString(), (ParamValue[i, 1] == null ? null : (ParamValue[i, 1].ToString() == "null" ? null : ParamValue[i, 1].ToString())));
                }
                cmd.Parameters.AddRange(param);
                cmd.Parameters.Add("OUTVAL", (ReturnTypeOutVal == 1 ? SqlDbType.UniqueIdentifier : SqlDbType.Int)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("OUTMESSAGE", SqlDbType.NVarChar, -1).Direction = ParameterDirection.Output;
                if (con.State != ConnectionState.Open) { con.Open(); }
                cmd.ExecuteNonQuery();
                con.Close();
                res.Outval = cmd.Parameters["OUTVAL"].Value;
                res.Outmsg = cmd.Parameters["OUTMESSAGE"].Value.ToString();
            }
            catch (Exception ee)
            {
                res.Outval = 0;
                res.Outmsg = "Error : " + ee.Message;
            }
            return res;
        }

        public MEMBERS.SQLReturnValue ExecuteProceduerWithValue(string ProceduerName
            , object[,] ParamValue
            , int ReturnTypeOutVal = 3)
        {
            MEMBERS.SQLReturnValue res = new MEMBERS.SQLReturnValue();

            try
            {
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = ProceduerName,
                    Connection = con,
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter[] param = new SqlParameter[ParamValue.GetUpperBound(0) + 1];
                for (int i = 0; i < param.Length; i++)
                {
                    param[i] = new SqlParameter("@" + ParamValue[i, 0].ToString(), (ParamValue[i, 1] == null ? null : (ParamValue[i, 1].ToString() == "null" ? null : ParamValue[i, 1].ToString())));
                }
                cmd.Parameters.AddRange(param);
                cmd.Parameters.Add("OUTVAL", (ReturnTypeOutVal == 1 ? SqlDbType.UniqueIdentifier : ReturnTypeOutVal == 2 ? SqlDbType.Int : SqlDbType.NVarChar), -1).Direction = ParameterDirection.Output;
                if (con.State != ConnectionState.Open) { con.Open(); }
                cmd.ExecuteNonQuery();
                con.Close();
                res.Outval = cmd.Parameters["OUTVAL"].Value;
            }
            catch (Exception ee)
            {
                res.Outval = "Error : " + ee.Message;
            }
            return res;
        }

        public object GetJsonResult(string ProceduerName
            , object[,] ParamValue
            )
        {
            object mRes = null;

            try
            {
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = ProceduerName,
                    Connection = con,
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter[] param = new SqlParameter[ParamValue.GetUpperBound(0) + 1];
                for (int i = 0; i < param.Length; i++)
                {
                    param[i] = new SqlParameter("@" + ParamValue[i, 0].ToString(), (ParamValue[i, 1] == null ? null : (ParamValue[i, 1].ToString() == "null" ? null : ParamValue[i, 1].ToString())));
                }
                cmd.Parameters.AddRange(param);
                if (con.State != ConnectionState.Open) { con.Open(); }

                SqlDataAdapter myDAP = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                myDAP.Fill(dt);

                mRes = JsonConvert.SerializeObject(dt);

                con.Close();
            }
            catch (Exception ee)
            {
                mRes = "Error : " + ee.Message;
            }

            return mRes;
        }

        public DataTable GetAll_DataTable(string ProceduerName
            , object[,] ParamValue
            )
        {

            DataTable dt = new DataTable();

            try
            {
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = ProceduerName,
                    Connection = con,
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter[] param = new SqlParameter[ParamValue.GetUpperBound(0) + 1];
                for (int i = 0; i < param.Length; i++)
                {
                    param[i] = new SqlParameter("@" + ParamValue[i, 0].ToString(), (ParamValue[i, 1] == null ? null : (ParamValue[i, 1].ToString() == "null" ? null : ParamValue[i, 1].ToString())));
                }
                cmd.Parameters.AddRange(param);
                if (con.State != ConnectionState.Open) { con.Open(); }

                SqlDataAdapter myDAP = new SqlDataAdapter(cmd);
                myDAP.Fill(dt);

                con.Close();
            }
            catch (Exception ee)
            {
                string Error = ee.Message;
            }

            return dt;
        }

        public DataSet GetAll_DataSet(string ProceduerName
            , object[,] ParamValue
            )
        {
            DataSet ds = new DataSet();

            try
            {
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = ProceduerName,
                    Connection = con,
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter[] param = new SqlParameter[ParamValue.GetUpperBound(0) + 1];
                for (int i = 0; i < param.Length; i++)
                {
                    param[i] = new SqlParameter("@" + ParamValue[i, 0].ToString(), (ParamValue[i, 1] == null ? null : (ParamValue[i, 1].ToString() == "null" ? null : ParamValue[i, 1].ToString())));
                }
                cmd.Parameters.AddRange(param);
                if (con.State != ConnectionState.Open) { con.Open(); }

                SqlDataAdapter myDAP = new SqlDataAdapter(cmd);
                myDAP.Fill(ds);

                con.Close();
            }
            catch (Exception ee)
            {
                string Error = ee.Message;
            }

            return ds;
        }

        public MEMBERS.PagingResponse Paging_GetAll_DataTable(string ProceduerName
            , object[,] ParamValue
            )
        {
            MEMBERS.PagingResponse obj = new MEMBERS.PagingResponse();

            try
            {
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = ProceduerName,
                    Connection = con,
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter[] param = new SqlParameter[ParamValue.GetUpperBound(0) + 1];
                for (int i = 0; i < param.Length; i++)
                {
                    param[i] = new SqlParameter("@" + ParamValue[i, 0].ToString(), (ParamValue[i, 1] == null ? null : (ParamValue[i, 1].ToString() == "null" ? null : ParamValue[i, 1].ToString())));
                }
                cmd.Parameters.AddRange(param);
                cmd.Parameters.Add("FirstRecord", SqlDbType.Int, 0).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("LastRecord", SqlDbType.Int, 0).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("TotalRecord", SqlDbType.Int, 0).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("TotalPage", SqlDbType.Int, 0).Direction = ParameterDirection.Output;
                if (con.State != ConnectionState.Open) { con.Open(); }

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);

                obj.Data = JsonConvert.SerializeObject(dt);
                obj.FirstRecord = cmd.Parameters["FirstRecord"].Value;
                obj.LastRecord = cmd.Parameters["LastRecord"].Value;
                obj.TotalRecords = cmd.Parameters["TotalRecord"].Value;
                obj.TotalPage = cmd.Parameters["TotalPage"].Value;

                con.Close();
            }
            catch (Exception ee)
            {
                string Message = ee.Message;
            }

            return obj;
        }

        public String GetJsonObject(string ProceduerName
            , object[,] ParamValue
            )
        {

            try
            {
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = ProceduerName,
                    Connection = con,
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter[] param = new SqlParameter[ParamValue.GetUpperBound(0) + 1];
                for (int i = 0; i < param.Length; i++)
                {
                    param[i] = new SqlParameter("@" + ParamValue[i, 0].ToString(), (ParamValue[i, 1] == null ? null : (ParamValue[i, 1].ToString() == "null" ? null : ParamValue[i, 1].ToString())));
                }
                cmd.Parameters.AddRange(param);
                if (con.State != ConnectionState.Open) { con.Open(); }

                SqlDataReader reader = cmd.ExecuteReader();

                StringBuilder sb = new StringBuilder();

                while (reader.Read())
                    sb.Append(reader.GetSqlString(0).Value);

                con.Close();

                return sb.ToString();
            }
            catch (Exception ee)
            {
                return ee.Message;
            }
        }

        public MEMBERS.SQLReturnMessageNValueNDataTable ExecuteProcedureWithReturnValueAndDataTable(string ProceduerName
            , object[,] ParamValue
            )
        {

            MEMBERS.SQLReturnMessageNValueNDataTable obj = new MEMBERS.SQLReturnMessageNValueNDataTable();

            try
            {
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = ProceduerName,
                    Connection = con,
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter[] param = new SqlParameter[ParamValue.GetUpperBound(0) + 1];

                for (int i = 0; i < param.Length; i++)
                {
                    param[i] = new SqlParameter("@" + ParamValue[i, 0].ToString(), (ParamValue[i, 1] == null ? null : (ParamValue[i, 1].ToString() == "null" ? null : ParamValue[i, 1].ToString())));
                }

                cmd.Parameters.AddRange(param);
                cmd.Parameters.Add("OUTVAL", SqlDbType.Int, 0).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("OUTMESSAGE", SqlDbType.NVarChar, -1).Direction = ParameterDirection.Output;
                if (con.State != ConnectionState.Open) { con.Open(); }

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);

                obj.Outval = cmd.Parameters["OUTVAL"].Value;
                obj.Outmsg = cmd.Parameters["OUTMESSAGE"].Value.ToString();
                obj.dt = dt;

                con.Close();
            }
            catch (Exception ee)
            {
                string Message = ee.Message;
            }

            return obj;
        }

        public MEMBERS.SQLReturnValue ExecuteProcedureWithDatatable(string ProcedureName, DataTable tableValue
            , string TableParamName, object obj, int ReturnTypeOutVal = 3)
        {

            MEMBERS.SQLReturnValue res = new MEMBERS.SQLReturnValue();

            try
            {
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = ProcedureName,
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 0
                };

                if (obj != null)
                {
                    SqlParameter[] param = new SQLPatameterClass().ConvertClassToSQLParams(obj);
                    cmd.Parameters.AddRange(param);
                }

                if (tableValue != null)
                {
                    SqlParameter tableParam = new SqlParameter("@" + TableParamName, tableValue)
                    {
                        SqlDbType = SqlDbType.Structured
                    };
                    cmd.Parameters.Add(tableParam);
                }

                cmd.Parameters.Add("OUTVAL", (ReturnTypeOutVal == 1 ? SqlDbType.UniqueIdentifier : SqlDbType.Int)).Direction = ParameterDirection.Output;

                if (con.State != ConnectionState.Open) { con.Open(); }

                cmd.ExecuteNonQuery();

                con.Close();

                res.Outval = cmd.Parameters["OUTVAL"].Value;
            }
            catch (Exception ee)
            {
                res.Outval = ee.Message;
            }
            finally
            {
                con.Close();
            }
            return res;
        }
    }
}
