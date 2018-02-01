using NLC.Order.Common;
using NLC.Order.DALFactory;
using NLC.Order.IBLL;
using NLC.Order.IDAL;
using NLC.Order.Model;
using System;

namespace NLC.Order.BLL
{
    public class UserBLL : IUserBLL
    {
        private IUserDAL userDAL = Factory.CreateUserDAL();
        private JsonResult jr = new JsonResult();

        /// <summary>
        /// 增加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public JsonResult AddUser(UserInfo user)
        {
            try
            {
                jr.Result = userDAL.InsertUser(user);
                jr.Status = 200;
            }
            catch(Exception e)
            {
                jr.Status = 500;
                jr.Result = e.Message;
            }
            return jr;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public JsonResult DelUser(string userId)
        {
            try
            {
                jr.Result = userDAL.DeleteUser(userId);
                jr.Status = 200;
            }
            catch (Exception e)
            {
                jr.Status = 500;
                jr.Result = e.Message;
            }
            return jr;
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAllUser()
        {
            try
            {
                jr.Result = userDAL.SelectAllUser();
                jr.Status = 200;
            }
            catch (Exception e)
            {
                jr.Status = 500;
                jr.Result = e.Message;
            }
            return jr;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public JsonResult Login(int UserId, string pwd,int type)
        {
            try
            {
              //  jr.Result = userDAL.SelectByNameAndPwd(name, pwd,type);
                jr.Status = 200;
            }
            catch (Exception e)
            {
                jr.Status = 500;
                jr.Result = e.Message;
            }
            return jr;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="psassword"></param>
        /// <returns></returns>
        public JsonResult ModifyPassword(string userId, string password)
        {
            try
            {
                jr.Result = userDAL.UpdateUser(userId, password);
                jr.Status = 200;
            }
            catch (Exception e)
            {
                jr.Status = 500;
                jr.Result = e.Message;
            }
            return jr;
        }
    }
}
