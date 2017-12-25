using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DataProvider
    {
        /// <summary>
        /// Connection String
        /// </summary>
        private static string cs = ConfigurationManager.ConnectionStrings["QuanLyThanhVien"].ConnectionString;

        /// <summary>
        /// SQL connection
        /// </summary>
        private static SqlConnection cn;
        /// <summary>
        /// Connect and open connection to database
        /// </summary>
        /// <returns></returns>
        public static SqlConnection Connect()
        {
            cn = new SqlConnection(cs);
            cn.Open();
            return cn;
        }

        /// <summary>
        /// Disconnection to database
        /// </summary>
        public static void Disconnect(ref SqlConnection connect)
        {
            connect.Close();
        }

        public static DataSet LoadDataByProc(String strProc)
        {
            SqlCommand cmd = new SqlCommand(strProc);
            cmd.CommandType = CommandType.StoredProcedure;
            return ExecuteQuery(cmd);
        }

        public static DataSet LoadDataByText(String strQuery)
        {
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            return ExecuteQuery(cmd);
        }

        /// <summary>
        /// Get the dataset value from database
        /// </summary>
        /// <param name="cmd">sql command connect and run query</param>
        /// <returns></returns>
        public static DataSet ExecuteQuery(SqlCommand cmd)
        {
            //Connect to command sql
            cmd.Connection = Connect();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            //đóng kết nối
            Disconnect(ref cn);
            return ds;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd">Sql command run query</param>
        /// <returns></returns>
        public static bool ExecuteNonquery(SqlCommand cmd)
        {
            SqlTransaction tran = null;
            try
            {
                cmd.Connection = Connect();
                tran = cmd.Connection.BeginTransaction();
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
                Disconnect(ref cn);
                return true;
            }
            catch (Exception ex)
            {
                if (tran != null)
                    tran.Rollback();
                return false;
                //throw ex;
            }
        }


    }
}
