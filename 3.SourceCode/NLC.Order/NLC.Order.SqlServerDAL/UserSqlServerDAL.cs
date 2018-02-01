using NLC.Order.DBUtility;
using NLC.Order.IDAL;
using NLC.Order.Model;
using System;
using System.Collections.Generic;
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
            string sql = "delete from Emp where Empno=@empno";
            SqlParameter[] parameters =
            {
                new SqlParameter("Empno",userId)
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
            string sql = "insert into Emp(Empno,Name,Type,Password,Dephno,Gender) values(@Empno,@Name,@Type,@Password,@Dephno,@Gender)";
            SqlParameter[] parameters =
            {
                new SqlParameter("Empno",user.UserId),
                new SqlParameter("Name",user.UserName),
                new SqlParameter("Type",user.UserType),
                new SqlParameter("Password",user.UserPwd),
                new SqlParameter("Deptno",user.Deptno),
                new SqlParameter("Gender",user.Gender)
            };
            int result=DBHelper.NonQuery(sql, parameters);
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据用户名和密码查找用户
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public UserInfo SelectByNameAndPwd(string name, string pwd)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="psassword"></param>
        /// <returns></returns>
        public bool UpdateUser(string userId, string psassword)
        {
            string sql = "update Emp set Password=@Password where Empno=@empno";
            SqlParameter[] parameters =
            {
                new SqlParameter("Password",psassword),
                new SqlParameter("Empno",userId)
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