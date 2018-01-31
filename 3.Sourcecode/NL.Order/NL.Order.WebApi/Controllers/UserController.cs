using NL.Order.Model;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;

namespace NL.Order.WebApi.Controllers
{
    public class UserController : ApiController
    {
        IList<UserInfo> users = new List<UserInfo>
        {
            new UserInfo(){UserId="NL001",UserName="zs",UserPwd="123",UserType="用户",Dept="技术部"},
            new UserInfo(){UserId="NL002",UserName="ls",UserPwd="456",UserType="用户",Dept="人事部"},
        };

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public IList<UserInfo> GetAllUser()
        {
            return users;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public string Login(string name, string pwd)
        {
            return "121111";
        }

        /// <summary>
        /// 增加用户
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <returns></returns>
        public JsonResult AddUser(UserInfo user)
        {
            return null;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userId">员工编号</param>
        /// <returns></returns>
        public JsonResult DelUser(string userId)
        {
            return null;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userId">员工编号</param>
        /// <param name="newPassword">新密码</param>
        /// <param name="repeatPassword">重复密码</param>
        /// <returns></returns>
        public JsonResult MotifyPassword(string userId, string newPassword, string repeatPassword)
        {
            return null;
        }
    }
}
