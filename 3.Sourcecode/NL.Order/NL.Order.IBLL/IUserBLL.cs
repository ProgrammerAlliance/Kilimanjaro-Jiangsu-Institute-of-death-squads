using NL.Order.Common;
using NL.Order.Model;

namespace NL.Order.IBLL
{
    public interface IUserBLL
    {
        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        JsonResult GetAllUser();

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        JsonResult Login(string name, string pwd);

        /// <summary>
        /// 增加用户
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns></returns>
        JsonResult AddUser(UserInfo user);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userId">员工编号</param>
        /// <returns></returns>
        JsonResult DelUser(string userId);

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userId">员工编号</param>
        /// <param name="psassword">密码</param>
        /// <returns></returns>
        JsonResult ModifyPassword(string userId, string psassword);
    }
}
