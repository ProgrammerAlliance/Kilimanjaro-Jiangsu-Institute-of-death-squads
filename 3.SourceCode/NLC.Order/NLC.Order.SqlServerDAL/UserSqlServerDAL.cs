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
        /// 删除用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool DeleteUser(string userId)
        {
            string sql = "delete from Emp where UserId=@UserId";
            SqlParameter[] parameters =
            {
                new SqlParameter("UserId",userId)
            };
            int result = DBHelper.NonQuery(sql, parameters);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 插入用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool InsertUser(UserInfo user)
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
            int result = DBHelper.NonQuery(sql, parameters);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 查找所有用户
        /// </summary>
        /// <returns></returns>
        public IList<UserInfo> SelectAllUser()
        {
            string sql = "select e.UserId,e.UserName,e.Gender,d.Deptname,t.Typename " +
                " from Emp e,Deptment d,UserType t " +
                " where e.UserType=t.Type and e.Deptno=d.Deptno";
            DataSet ds = DBHelper.Query(sql, null);
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

            var data = DBHelper.Query(sql, parameters);
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
            string sql = "update Emp set UserPwd=@UserPwd where UserId=@UserId";
            SqlParameter[] parameters =
            {
                new SqlParameter("UserPwd",psassword),
                new SqlParameter("UserId",userId)
            };
            int result = DBHelper.NonQuery(sql, parameters);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}