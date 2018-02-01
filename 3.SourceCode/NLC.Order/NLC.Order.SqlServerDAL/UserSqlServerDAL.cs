using NLC.Order.IDAL;
using NLC.Order.Model;
using System;
using System.Collections.Generic;

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
            return true;
        }

        /// <summary>
        /// 插入用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool InsertUser(UserInfo user)
        {
            throw new NotImplementedException();
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

            return true;
        }
    }
}