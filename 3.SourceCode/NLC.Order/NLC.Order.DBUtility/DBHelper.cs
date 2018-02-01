using System;
using System.Data;
using System.Data.SqlClient;

namespace NLC.Order.DBUtility
{
    public class DBHelper
    {
        static string connString = "Data Source=DESKTOP-52NF0RS;Initial Catalog=Order;Persist Security Info=True;User ID=sa;Password=123";

       
        // 执行对数据表中数据的增加、删除、修改操作  
        public static int NonQuery(string sql,SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connString);
            int result = -1;
            try
            {
                conn.Open();  //打开数据库  
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (parameters != null && parameters.Length > 0)
                {
                    foreach(SqlParameter parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                }
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception msg)
            {
                throw new Exception(msg.ToString());
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();    //关闭数据库  
                }
            }
            return result;

        }
        // 执行对数据表中数据的查询操作  
        public static DataSet Query(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();      //打开数据库  
                SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
                adp.Fill(ds);
            }
            catch (Exception msg)
            {
                throw new Exception(msg.ToString());
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();      //关闭数据库  
            }
            return ds;
        }
    }
}
