//using MySql.Data.MySqlClient;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;

//namespace H.Saas.Tools
//{
//    public partial class SqlHelper
//    {
//        public string _connStr;
//        public SqlHelper(string connStr)
//        {
//            this._connStr = connStr;
//        }
//        public object ExecuteScalar(string sql)
//        {
//            using (SqlConnection conn = new SqlConnection(_connStr))
//            {
//                using (SqlCommand cmd = conn.CreateCommand())
//                {
//                    conn.Open();
//                    cmd.CommandText = sql;
//                    return cmd.ExecuteScalar();
//                }
//            }
//        }
//        /// <summary>
//        /// 执行多条SQL语句，实现数据库事务。
//        /// </summary>
//        /// <param name="SQLStringList">多条SQL语句</param>        
//        public int ExecuteSqlTran(List<String> SQLStringList)
//        {
//            using (SqlConnection conn = new SqlConnection(_connStr))
//            {
//                conn.Open();
//                SqlCommand cmd = new SqlCommand();
//                cmd.Connection = conn;
//                SqlTransaction tx = conn.BeginTransaction();
//                cmd.Transaction = tx;
//                try
//                {
//                    int count = 0;
//                    for (int n = 0; n < SQLStringList.Count; n++)
//                    {
//                        string strsql = SQLStringList[n];
//                        if (strsql.Trim().Length > 1)
//                        {
//                            cmd.CommandText = strsql;
//                            count += cmd.ExecuteNonQuery();
//                        }
//                    }
//                    tx.Commit();
//                    conn.Close();
//                    return count;
//                }
//                catch (Exception err)
//                {
//                    tx.Rollback();

//                    return 0;
//                }
//            }

//        }


//        /// <summary>
//        /// 执行SQL语句
//        /// </summary>
//        public int ExecuteSql(string sql)
//        {
//            using (SqlConnection conn = new SqlConnection(_connStr))
//            {
//                conn.Open();
//                SqlCommand cmd = new SqlCommand();
//                cmd.Connection = conn;
//                try
//                {
//                    cmd.CommandText = sql;
//                    return cmd.ExecuteNonQuery();
//                }
//                catch (Exception err)
//                {
//                    return 0;
//                }
//            }
//        }
//        public DataTable dataTable(string sql, List<SqlParameter> parameters)
//        {
//            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, _connStr))
//            {
//                DataTable dt = new DataTable();
//                if (parameters != null && parameters.Count > 0)
//                    parameters.ForEach(t=> adapter.SelectCommand.Parameters.Add(t)) ;
//                adapter.Fill(dt);
//                return dt;
//            }
//        }
//        public DataTable dataTable(string sql)
//        {
//            DataTable dt = new DataTable();
//            string CmdString = string.Empty;
//            using (SqlConnection conn = new SqlConnection(_connStr))
//            {
//                CmdString = sql;
//                SqlCommand cmd = new SqlCommand(CmdString, conn);
//                SqlDataAdapter sda = new SqlDataAdapter(cmd);
//                sda.Fill(dt);
//                conn.Close();
//            }
//            return dt;
//        }
//    }


//    public partial class MySqlHelper
//    {

//        public string _connStr;
//        public MySqlHelper(string connStr)
//        {
//            this._connStr = connStr;
//        }
//        /// <summary>
//        /// 执行sql,返回查询结果中的第一行第一列的值
//        /// </summary>
//        /// <param name="sql"></param>
//        /// <param name="parameters"></param>
//        /// <returns></returns>
//        public object ExecuteScalar(string strsql, params MySqlParameter[] parameters)
//        {
//            using (MySqlConnection conn = new MySqlConnection(_connStr))
//            {
//                using (MySqlCommand cmd = conn.CreateCommand())
//                {
//                    try
//                    {
//                        conn.Open();
//                        cmd.CommandText = strsql;
//                        cmd.Parameters.AddRange(parameters);
//                        return cmd.ExecuteScalar();
//                    }
//                    catch (Exception err)
//                    {
//                        Logs.WriteLog("sql异常：" + strsql + "\n" + err.Message);
//                        return 0;
//                    }
//                }
//            }
//        }
//        public int ExecuteSqlTran(List<String> SQLStringList)
//        {
//            using (MySqlConnection conn = new MySqlConnection(_connStr))
//            {
//                conn.Open();
//                MySqlCommand cmd = new MySqlCommand();
//                cmd.Connection = conn;
//                MySqlTransaction tx = conn.BeginTransaction();
//                cmd.Transaction = tx;
//                var strsql = "";
//                try
//                {
//                    int count = 0;
//                    for (int n = 0; n < SQLStringList.Count; n++)
//                    {
//                        strsql = SQLStringList[n];
//                        if (strsql.Trim().Length > 1)
//                        {
//                            cmd.CommandText = strsql;
//                            count += cmd.ExecuteNonQuery();
//                        }
//                    }
//                    tx.Commit();
//                    conn.Close();
//                    return count;
//                }
//                catch (Exception err)
//                {
//                    Logs.WriteLog("sql异常：" + strsql+"\n"+err.Message);
//                    tx.Rollback();
//                    return 0;
//                }
//            }

//        }
//        /// <summary>
//        /// 执行SQL语句
//        /// </summary>
//        public int ExecuteSql(string strsql)
//        {
//            using (MySqlConnection conn = new MySqlConnection(_connStr))
//            {
//                conn.Open();
//                MySqlCommand cmd = new MySqlCommand();
//                cmd.Connection = conn;
//                try
//                {
//                    cmd.CommandText = strsql;
//                    return cmd.ExecuteNonQuery();
//                }
//                catch (Exception err)
//                {
//                    Logs.WriteLog("sql异常：" + strsql + "\n" + err.Message);
//                    return 0;
//                }
//            }
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="sql"></param>
//        /// <returns></returns>
//        public DataTable dataTable(string strsql)
//        {

//            DataTable dt = new DataTable();
//            string CmdString = string.Empty;
//            using (MySqlConnection conn = new MySqlConnection(_connStr))
//            {
//                try
//                {
//                    CmdString = strsql;
//                    MySqlCommand cmd = new MySqlCommand(CmdString, conn);
//                    MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
//                    sda.Fill(dt);
//                }
//                catch (Exception err)
//                {
//                    Logs.WriteLog("sql异常：" + strsql + "\n" + err.Message);
//                    dt = new DataTable();
//                }
//                conn.Close();
//            }
//            return dt;
//        }
//    }

//}
