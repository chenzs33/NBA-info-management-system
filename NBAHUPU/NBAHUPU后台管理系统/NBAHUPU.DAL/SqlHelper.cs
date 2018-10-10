//===============================================================================
// This file is based on the Microsoft Data Access Application Block for .NET
// For more information please go to 
// http://msdn.microsoft.com/library/en-us/dnbda/html/daab-rm.asp
//===============================================================================

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace NBAHUPU.DAL
{

    /// <summary>
    /// 执行Sql 命令的通用方法
    /// </summary>
    public abstract class SqlHelper
    {

        //Database connection strings
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["NBAHUPU"].ConnectionString;

        #region ExecuteNonQuery

        /// <summary>
        /// 执行sql命令
        /// </summary>        
        /// <param name="commandType">命令类型</param>
        /// <param name="commandText">sql语句/参数化sql语句/存储过程名</param>
        /// <param name="commandParameters">参数</param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteNonQuery(string commandText, CommandType commandType, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                PrepareCommand(cmd, commandType,conn, commandText, commandParameters);
                int val = cmd.ExecuteNonQuery();

                return val;
            }
        }
        
        #endregion

        #region ExecuteReader

        /// <summary>
        ///  执行sql命令
        /// </summary>        
        /// <param name="commandType">命令类型</param>
        /// <param name="commandText">sql语句/参数化sql语句/存储过程名</param>
        /// <param name="commandParameters">参数</param>
        /// <returns>SqlDataReader 对象</returns>
        public static SqlDataReader ExecuteReader(string commandText, CommandType commandType, params SqlParameter[] commandParameters)
        {

            SqlConnection conn = new SqlConnection(ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, commandType, conn, commandText, commandParameters);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        #endregion

        #region ExecuteDataset

        /// <summary>
        /// 执行Sql 命令
        /// </summary>        
        /// <param name="commandType">命令类型</param>
        /// <param name="commandText">sql语句/参数化sql语句/存储过程名</param>
        /// <param name="commandParameters">参数</param>
        /// <returns>DataSet 对象</returns>
        public static DataSet ExecuteDataset(string commandText, CommandType commandType, params SqlParameter[] commandParameters)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {

                SqlCommand cmd = new SqlCommand();

                PrepareCommand(cmd, commandType, conn, commandText, commandParameters);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    return ds;
                }
            }
        }

        #endregion

        #region ExecuteScalar

        /// <summary>
        /// 执行Sql 命令
        /// </summary>       
        /// <param name="commandType">命令类型</param>
        /// <param name="commandText">sql语句/参数化sql语句/存储过程名</param>
        /// <param name="commandParameters">参数</param>
        /// <returns>执行结果对象</returns>
        public static object ExecuteScalar(string commandText, CommandType commandType, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                PrepareCommand(cmd, commandType, conn, commandText, commandParameters);
                object val = cmd.ExecuteScalar();

                return val;
            }
        }      
        
        #endregion

        #region Private Method

        /// <summary>
        /// 设置一个等待执行的SqlCommand对象
        /// </summary>
        /// <param name="cmd">SqlCommand 对象，不允许空对象</param>
        /// <param name="conn">SqlConnection 对象，不允许空对象</param>
        /// <param name="commandText">Sql 语句</param>
        /// <param name="cmdParms">SqlParameters  对象,允许为空对象</param>
        private static void PrepareCommand(SqlCommand cmd, CommandType commandType, SqlConnection conn, string commandText, SqlParameter[] cmdParms)
        {
            //打开连接
            if (conn.State != ConnectionState.Open)
                conn.Open();

            //设置SqlCommand对象
            cmd.Connection = conn;
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }
        
        #endregion


    }
}