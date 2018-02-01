using NL.Order.Common;
using System;
using System.Data;
using System.Data.SqlClient;

namespace NL.Order.DBUtility
{
    public class DBHelper
    {
        static string connString = "Data Source=DESKTOP-52NF0RS;Initial Catalog=Order;Persist Security Info=True;User ID=sa;Password=123";

       
        // 执行对数据表中数据的增加、删除、修改操作  
        public static int NonQuery(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            int result = -1;
            try
            {
                conn.Open();  //打开数据库  
                SqlCommand cmd = new SqlCommand(sql, conn);
                result = cmd.ExecuteNonQuery();
            }
            catch 
            {
                LogHelper.WriteLogFile("操作数据失败！");
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
            catch
            {
                LogHelper.WriteLogFile("操作数据失败！");
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
