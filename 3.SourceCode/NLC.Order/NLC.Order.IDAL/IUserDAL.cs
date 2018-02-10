using NLC.Order.Model;
using System.Collections.Generic;

namespace NLC.Order.IDAL
{
    public interface IUserDAL
    {
        /// <summary>
        /// 查找所有用户，分页显示
        /// </summary>
        /// <param name="rows">行数</param>
        /// <param name="page">页数</param>
        /// <returns></returns>
        List<UserInfo> SelectAllUser(int rows, int page);

        /// <summary>
        /// 根据用户名和密码查找用户
        /// </summary>
        /// <param name="UserId">员工ID</param>
        /// <param name="pwd">密码</param>
        /// <param name="type">用户类型</param>
        /// <returns></returns>
        IList<UserInfo> SelectByIdAndPwd(int UserId, string pwd, int type);

        /// <summary>
        /// 插入用户
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <returns></returns>
        bool InsertUser(UserInfo user);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userId">员工编号</param>
        /// <returns></returns>
        bool DeleteUser(int userId);

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="userId">员工编号</param>
        /// <param name="psassword">密码</param>
        /// <returns></returns>
        bool UpdateUser(int userId, string psassword);

        /// <summary>
        /// 统计员工数
        /// </summary>
        /// <returns></returns>
        int CountEmp();

        /// <summary>
        /// 根据用户编号查找用户
        /// </summary>
        /// <param name="userId">员工编号</param>
        /// <returns></returns>
        bool SelectByUserId(int userId);
    }
}
