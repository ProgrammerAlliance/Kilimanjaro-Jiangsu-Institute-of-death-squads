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
        public JsonResult GetLogin(int UserId,string UserPwd,int UserType)
        {
            return userBLL.Login(UserId,UserPwd,UserType);
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAllUser(int rows, int page)
        {
            return userBLL.GetAllUser(rows, page);
        }

        /// <summary>
        /// 增加用户
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <returns></returns>
        public JsonResult PostAddUser(UserInfo user)
        {
            return userBLL.AddUser(user);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userId">员工编号</param>
        /// <returns></returns>
        public JsonResult DeleteUser(UserInfo user)
        {
            return userBLL.DelUser(user.UserId);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userId">员工编号</param>
        /// <param name="newPassword">新密码</param>
        /// <returns></returns>
        public JsonResult PutModifyPassword(UserInfo user)
        {
            return userBLL.ModifyPassword(user.UserId, user.UserPwd);
        }
    }
}
