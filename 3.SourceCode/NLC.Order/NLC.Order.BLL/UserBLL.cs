using NLC.Order.Common;
using NLC.Order.DALFactory;
using NLC.Order.IBLL;
using NLC.Order.IDAL;
using NLC.Order.Model;
using System;
using System.Data.SqlClient;

namespace NLC.Order.BLL
{
    public class UserBLL : IUserBLL
    {
        private IUserDAL userDAL = Factory.CreateUserDAL();
        private IOrderDAL orderDAL = Factory.CreateOrderDAL();
        private JsonResult jr = new JsonResult();

        /// <summary>
        /// 增加用户
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns></returns>
        public JsonResult AddUser(UserInfo user)
        {
            if (user.UserId == 0)
            {
                jr.Result = "用户工号为空";
                jr.Status = 202;
                return jr;
            }
            if (user.UserPwd == null)
            {
                jr.Result = "密码为空";
                jr.Status = 203;
                return jr;
            }
            try
            {
                if (userDAL.SelectByUserId(user.UserId))
                {
                    jr.Result = "该工号已存在";
                    jr.Status = 201;
                    return jr;
                }
                jr.Result = userDAL.InsertUser(user);
                jr.Status = 200;
            }
            catch (SqlException e)
            {
                jr.Status = 405;
                jr.Result = "数据库错误";
                LogHelper.WriteLogFile("数据库错误" + e.Message);
            }
            catch (Exception e)
            {
                jr.Status = 500;
                jr.Result = "系统繁忙";
                LogHelper.WriteLogFile("增加用户失败" + e.Message);
            }
            return jr;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userId">员工编号</param>
        /// <returns></returns>
        public JsonResult DelUser(int userId)
        {
            try
            {
                jr.Result = userDAL.DeleteUser(userId);
                jr.Status = 200;
            }
            catch (SqlException e)
            {
                jr.Status = 405;
                jr.Result = "数据库错误";
                LogHelper.WriteLogFile("数据库错误" + e.Message);
            }
            catch (Exception e)
            {
                jr.Status = 500;
                jr.Result = "系统繁忙";
                LogHelper.WriteLogFile("删除用户失败" + e.Message);
            }
            return jr;
        }

        /// <summary>
        /// /获取所有用户
        /// </summary>
        /// <param name="rows">行数</param>
        /// <param name="page">页数</param>
        /// <returns></returns>
        public JsonResult GetAllUser(int rows, int page)
        {
            Page<UserInfo> pageObject = new Page<UserInfo>();
            pageObject.CurrentPage = page;
            pageObject.PageRecord = rows;
            try
            {
                pageObject.TotalRecord = userDAL.CountEmp();
                pageObject.TotalPage = pageObject.TotalRecord % rows == 0 ? pageObject.TotalRecord / rows : pageObject.TotalRecord / rows + 1;
                pageObject.ObjectList = userDAL.SelectAllUser(rows, page);
                jr.Result = pageObject;
                jr.Status = 200;
            }
            catch (SqlException e)
            {
                jr.Status = 405;
                jr.Result = "数据库错误";
                LogHelper.WriteLogFile("数据库错误");
            }
            catch (Exception e)
            {
                jr.Status = 500;
                jr.Result = "系统繁忙";
                LogHelper.WriteLogFile("获取所有用户失败");
            }
            return jr;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="UserId">员工编号</param>
        /// <param name="pwd">密码</param>
        /// <param name="type">用户类型</param>
        /// <returns></returns>
        public JsonResult Login(int UserId, string pwd, int type)
        {
            if (UserId == 0)
            {
                jr.Result = "用户工号为空";
                jr.Status = 202;
                return jr;
            }
            if (pwd == null)
            {
                jr.Result = "密码为空";
                jr.Status = 203;
                return jr;
            }
            try
            {
                var Result = userDAL.SelectByIdAndPwd(UserId, pwd, type);
                if (Result == null || Result.Count == 0)//没有用户
                {
                    jr.Status = 404;
                    jr.Result = "用户名或密码错误";
                }
                else
                {
                    Result[0].IsOrder = orderDAL.IsOrder(UserId);
                    jr.Status = 200;
                    jr.Result = Result[0];
                }
            }
            catch (SqlException)
            {
                jr.Status = 405;
                jr.Result = "数据库错误";
                LogHelper.WriteLogFile("数据库错误");
            }
            catch (Exception)
            {
                jr.Status = 500;
                jr.Result = "登录出错";
                LogHelper.WriteLogFile("登录出错");
            }
            return jr;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userId">员工编号</param>
        /// <param name="psassword">密码</param>
        /// <returns></returns>
        public JsonResult ModifyPassword(int userId, string password, string repeatPassword)
        {
            if (!password.Equals(repeatPassword))
            {
                jr.Result = "两次密码不一致";
                jr.Status = 201;
                return jr;
            }
            try
            {
                jr.Result = userDAL.UpdateUser(userId, password);
                jr.Status = 200;
            }
            catch (SqlException)
            {
                jr.Status = 405;
                jr.Result = "数据库错误";
                LogHelper.WriteLogFile("数据库错误");
            }
            catch (Exception)
            {
                jr.Status = 500;
                jr.Result = "修改密码出错";
                LogHelper.WriteLogFile("修改密码失败");
            }
            return jr;
        }
    }
}
