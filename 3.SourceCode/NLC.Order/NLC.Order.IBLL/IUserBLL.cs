using NLC.Order.Common;
using NLC.Order.Model;

namespace NLC.Order.IBLL
{
    public interface IUserBLL
    {
        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        JsonResult GetAllUser(int rows, int page);

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        JsonResult Login(int UserId, string pwd, int type);

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
        JsonResult DelUser(int userId);

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userId">员工编号</param>
        /// <param name="psassword">密码</param>
        /// <returns></returns>
        JsonResult ModifyPassword(int userId, string password, string repeatPassword);
    }
}
