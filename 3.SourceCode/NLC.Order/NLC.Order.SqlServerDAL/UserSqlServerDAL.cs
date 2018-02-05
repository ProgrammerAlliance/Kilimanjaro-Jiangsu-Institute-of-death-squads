using NL.Order.Common;
using NLC.Order.DBUtility;
using NLC.Order.IDAL;
using NLC.Order.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace NLC.Order.SqlServerDAL
{
    public class UserSqlServerDAL : IUserDAL
    {
        /// <summary>
        /// 统计员工数量
        /// </summary>
        /// <returns></returns>
        public int CountEmp()
        {
            DataSet ds = null;
            try
            {
                string sql = @"SELECT UserId, UserName, UserType, UserPwd, Deptno, Gender
                           FROM dbo.Emp AS ordertable
                           WHERE(UserType = 2)";
                 ds = DBHelper.Query(sql, null);
            }
            catch (Exception)
            {

                LogHelper.WriteLogFile("执行统计员工数量SQL语句失败");
            }
            
            return ds.Tables[0].Rows.Count;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool DeleteUser(string userId)
        {
            int result = 0;
            try
            {
                string sql = "delete from Emp where UserId=@UserId";
                SqlParameter[] parameters =
                {
                new SqlParameter("UserId",userId)
            };
                result = DBHelper.NonQuery(sql, parameters);
            }
            catch (Exception)
            {
                LogHelper.WriteLogFile("执行删除用户SQL语句失败");
              
            }
            
            return result > 0 ? true : false;
        }

        /// <summary>
        /// 插入用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool InsertUser(UserInfo user)
        {
            int result = 0;
            try
            {
                string sql = @"insert into Emp
                           (UserId,UserName,UserType,UserPwd,Deptno,Gender)
                           values(@UserId,@UserName,@UserType,@UserPwd,@Deptno,@Gender)";
                SqlParameter[] parameters =
                {
                new SqlParameter("UserId",user.UserId),
                new SqlParameter("UserName",user.UserName),
                new SqlParameter("UserType",user.UserType),
                new SqlParameter("UserPwd",user.UserPwd),
                new SqlParameter("Deptno",user.Deptno),
                new SqlParameter("Gender",user.Gender)
            };
                result = DBHelper.NonQuery(sql, parameters);
            }
            catch (Exception)
            {
                LogHelper.WriteLogFile("执行删除用户SQL语句失败");
            }
            
            return result > 0 ? true : false;
        }

        /// <summary>
        /// 查找所有用户
        /// </summary>
        /// <returns></returns>
        public List<UserInfo> SelectAllUser(int rows, int page)
        {
            DataSet ds = null;
            try
            {
                int nums = rows * (page - 1);
                string sql = @"SELECT TOP (@rows) [UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]
                            FROM  (SELECT  row_number() OVER (ORDER BY UserId) AS rownumber, 
                                   [UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]
                            FROM  [Order].[dbo].[Emp]WHERE   UserType = 2) A
                            WHERE rownumber > @nums";
                SqlParameter[] parameters =
                {
                new SqlParameter("rows",rows),
                new SqlParameter("nums",nums)
            };
                ds = DBHelper.Query(sql, parameters);
            }
            catch (Exception)
            {
                LogHelper.WriteLogFile("执行删除用户SQL语句失败");
            }          
            return DBHelper.GetListbyDataSet<UserInfo>(ds);
        }

        /// <summary>
        /// 根据用户名和密码查找用户
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public IList<UserInfo> SelectByIdAndPwd(int UserId, string pwd, int type)
        {
            DataSet data = null;
            try
            {
                string sql = @"SELECT  e.UserId, e.UserName, d.Deptname
                           FROM  dbo.Emp AS e INNER JOIN
                           dbo.Deptment AS d ON e.Deptno = d.Deptno
                           WHERE   
                            (e.UserId = @UserId) AND (e.UserPwd = @UserPwd) AND (e.UserType = @UserType)";
                SqlParameter[] parameters =
                {
                new SqlParameter("UserType",type),
                new SqlParameter("UserId",UserId),
                new SqlParameter("UserPwd",pwd)
            };

                data = DBHelper.Query(sql, parameters);
            }
            catch (Exception)
            {
                LogHelper.WriteLogFile("执行根据用户名和密码查找用户SQL语句失败");
            }
            
            return DBHelper.GetListbyDataSet<UserInfo>(data);
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="psassword"></param>
        /// <returns></returns>
        public bool UpdateUser(string userId, string psassword)
        {
            int result = 0;
            try
            {
                string sql = "update Emp set UserPwd=@UserPwd where UserId=@UserId";
                SqlParameter[] parameters =
                {
                new SqlParameter("UserPwd",psassword),
                new SqlParameter("UserId",userId)
            };
                result = DBHelper.NonQuery(sql, parameters);
            }
            catch (Exception)
            {
                LogHelper.WriteLogFile("执行更新用户SQL语句失败");
            }           
            return result > 0 ? true : false;
        }
    }
}