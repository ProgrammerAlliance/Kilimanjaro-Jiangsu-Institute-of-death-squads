using NL.Order.IBLL;
using System;
using NL.Order.Common;
using NL.Order.Model;

namespace NL.Order.BLL
{
    public class UserBLL : IUserBLL
    {
        /// <summary>
        /// 增加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public JsonResult AddUser(UserInfo user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public JsonResult DelUser(string userId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAllUser()
        {

            return null;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public JsonResult Login(string name, string pwd)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="psassword"></param>
        /// <returns></returns>
        public JsonResult ModifyPassword(string userId, string psassword)
        {
            throw new NotImplementedException();
        }
    }
}
