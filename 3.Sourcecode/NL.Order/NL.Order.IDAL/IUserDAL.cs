using NL.Order.Model;
using System.Collections.Generic;

namespace NL.Order.IDAL
{
    public interface IUserDAL
    {
        /// <summary>
        /// 查找所有用户
        /// </summary>
        /// <returns></returns>
        IList<UserInfo> SelectAllUser();

        /// <summary>
        /// 根据用户名和密码查找用户
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        UserInfo SelectByNameAndPwd(string name, string pwd);

        /// <summary>
        /// 插入用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool InsertUser(UserInfo user);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        bool DeleteUser(string userId);

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="psassword"></param>
        /// <returns></returns>
        bool UpdateUser(string userId, string psassword);
    }
}
