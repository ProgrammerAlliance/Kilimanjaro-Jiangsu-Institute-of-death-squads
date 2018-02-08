using Newtonsoft.Json;
using NLC.Order.BLL;
using NLC.Order.Common;
using NLC.Order.IBLL;
using NLC.Order.Model;
using System.Web.Http;

namespace NLC.Order.WebApi.Controllers
{
    public class UserController : ApiController
    {
        /// <summary>
        /// UserBLL对象
        /// </summary>
        private IUserBLL userBLL = new UserBLL();

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult Login(int UserId, string pwd, int type)
        {
            return userBLL.Login(UserId, pwd, type);
        }

        /// <summary>
        /// 增加用户
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult AddUser(string user)
        {
            UserInfo u = JsonConvert.DeserializeObject<UserInfo>(user);
            return userBLL.AddUser(u);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userId">员工编号</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult DelUser(string userId)
        {
            return userBLL.DelUser(userId);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userId">员工编号</param>
        /// <param name="newPassword">新密码</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult ModifyPassword(string userId, string newPassword)
        {
            return userBLL.ModifyPassword(userId, newPassword);
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetAllUser(int rows, int page)
        {
            return userBLL.GetAllUser(rows, page);
        }
    }
}
