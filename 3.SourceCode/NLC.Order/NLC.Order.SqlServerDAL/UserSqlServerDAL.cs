using NLC.Order.Common;
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
            catch (Exception e)
            {
                LogHelper.WriteLogFile( e.Message);
            }
            return ds.Tables[0].Rows.Count;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool DeleteUser(int userId)
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
            catch (Exception e)
            {
                LogHelper.WriteLogFile( e.Message);
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
            catch (Exception e)
            {
                LogHelper.WriteLogFile(e.Message);
            }
            return result > 0;
        }

        /// <summary>
        /// 查找所有用户，分页显示
        /// </summary>
        /// <param name="rows">行</param>
        /// <param name="page">页</param>
        /// <returns></returns>
        public List<UserInfo> SelectAllUser(int rows, int page)
        {
            DataSet ds = null;
            try
            {
                int nums = rows * (page - 1);
                string sql = @"SELECT TOP (@rows) UserName,UserId,UserPwd,DeptName,Deptno
                            FROM(SELECT row_number() OVER(ORDER BY UserId) AS rownumber, e.UserName, e.UserId, e.UserPwd, d.DeptName,d.Deptno
                            FROM Emp e, Deptment d WHERE e.Deptno = d.DeptNo and e.UserType = 2) t1
                            WHERE rownumber > @nums";
                SqlParameter[] parameters =
                {
                    new SqlParameter("rows",rows),
                    new SqlParameter("nums",nums)
                };
                ds = DBHelper.Query(sql, parameters);
            }
            catch (Exception e)
            {
                LogHelper.WriteLogFile(e.Message);
            }
            return DBHelper.GetListbyDataSet<UserInfo>(ds);
        }

        /// <summary>
        /// 根据用户名和密码查找用户
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <param name="pwd">密码</param>
        /// <param name="type">用户类型</param>
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
            catch (Exception e)
            {
                LogHelper.WriteLogFile( e.Message);
            }
            return DBHelper.GetListbyDataSet<UserInfo>(data);
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="psassword">密码</param>
        /// <returns></returns>
        public bool UpdateUser(int userId, string psassword)
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
            catch (Exception e)
            {
                LogHelper.WriteLogFile( e.Message);
            }
            return result > 0 ? true : false;
        }

        /// <summary>
        /// 根据用户工号查找用户
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public bool SelectByUserId(int userId)
        {
            DataSet data = null;
            try
            {
                string sql = @"SELECT * FROM  dbo.Emp WHERE UserId=@UserId";
                SqlParameter[] parameters =
                {
                    new SqlParameter("UserId",userId)
                };
                data = DBHelper.Query(sql, parameters);
            }
            catch (Exception e)
            {
                LogHelper.WriteLogFile(e.Message);
            }
            return data.Tables[0].Rows.Count == 0 ? false : true;
        }
    }
}