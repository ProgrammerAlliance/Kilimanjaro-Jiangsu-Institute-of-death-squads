using System;
using System.Data;
using System.Data.SqlClient;

namespace NL.Order.DBUtility
{
    public  class DBHelper
    {
        static string connStr = "Data Source=DESKTOP-52NF0RS;Initial Catalog=Order;Integrated Security=True";
        static SqlConnection conn = new SqlConnection(connStr);

        public static SqlDataReader GetDataReader(string sql)//返回值是一个数组，可通过dr[0],dr[1]使用各字段的值
        {
            SqlConnection myConn = conn;
            SqlDataReader dr = null;

            try
            {
                if (myConn.State == ConnectionState.Closed)
                {
                    myConn.Open();
                }
                SqlCommand cmd = new SqlCommand(sql, myConn);

                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch
            {

                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }

            }
            return dr;
        }

        public static bool ExecuteNonQuery(string sql)  //对于 UPDATE、INSERT 和 DELETE 语句，返回值为该命令所影响的行数。对于所有其他类型的语句，返回值为 -1。如果发生回滚，返回值也为 -1
        {
            int n = 0;

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand(sql, conn);
                n = cmd.ExecuteNonQuery();

            }
            catch
            {

                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return n > 0;
        }

        public static Object ExecuteScalar(string sql)//使用ExecuteScalar()，增删改查如果成功，会返回一个对象，否则会返回一个null；
        {
            Object ob = null;

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand(sql, conn);
                ob = cmd.ExecuteScalar();
            }
            catch
            {
                return null;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return ob;
        }
    }
}

