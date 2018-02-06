using NLC.Order.IDAL;
using NLC.Order.Model;
using System;
using System.Collections.Generic;

namespace NLC.Order.OracleDAL
{
    public class UserOracleDAL : IUserDAL
    {
        public int CountEmp()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool DeleteUser(string userId)
        {
            return false;
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
        public List<UserInfo> SelectAllUser(int rows,int page)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据用户名和密码查找用户
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public IList<UserInfo> SelectByIdAndPwd(int UserId, string pwd,int type)
        {
            throw new NotImplementedException();
        }

        public bool SelectByUserId(int userId)
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
            throw new NotImplementedException();
        }

    }
}
