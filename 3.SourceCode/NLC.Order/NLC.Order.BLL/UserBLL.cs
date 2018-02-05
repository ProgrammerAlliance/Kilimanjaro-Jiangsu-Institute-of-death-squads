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
        private IUserDAL UserDAL = Factory.CreateUserDAL();
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
                jr.Result = UserDAL.InsertUser(user);
                jr.Status = 200;
            }
            catch (Exception e)
            {
                jr.Status = 500;
                jr.Result = "系统繁忙";
                //LogHelper.WriteLogFile(e.Message);
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
                jr.Result = UserDAL.DeleteUser(userId);
                jr.Status = 200;
            }
            catch (Exception e)
            {
                jr.Status = 500;
                jr.Result = "系统繁忙";
                //LogHelper.WriteLogFile(e.Message);
            }
            return jr;
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAllUser(int rows,int page)
        {
            try
            {
                jr.Result = UserDAL.SelectAllUser(rows, page);
                jr.Status = 200;
            }
            catch (Exception e)
            {
                jr.Status = 500;
                jr.Result = "获取用户出错";
            }
            return jr;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public JsonResult Login(int UserId, string pwd, int type)
        {
            try
            {
                var Result = UserDAL.SelectByIdAndPwd(UserId, pwd, type);
                if (Result == null||Result.Count==0)//没有用户
                {
                    jr.Status = 404;
                    jr.Result = "用户名或密码错误";
                }
                else
                {
                    jr.Status = 200;
                    jr.Result = Result[0];
                }
            }
            catch(Exception e)
            {
                jr.Status = 500;
                jr.Result = "登录出错";
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
                jr.Result = UserDAL.UpdateUser(userId, password);
                jr.Status = 200;
            }
            catch (Exception e)
            {
                jr.Status = 500;
                jr.Result = "修改密码出错";
               // LogHelper.WriteLogFile(e.Message);
            }
            return jr;
        }
    }
}
