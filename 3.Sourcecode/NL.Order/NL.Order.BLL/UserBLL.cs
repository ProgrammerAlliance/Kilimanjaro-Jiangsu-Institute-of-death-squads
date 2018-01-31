using NL.Order.IBLL;
using System;
using NL.Order.Common;
using NL.Order.Model;

namespace NL.Order.BLL
{
    public class UserBLL : IUserBLL
    {
        public JsonResult AddUser(UserInfo user)
        {
            throw new NotImplementedException();
        }

        public JsonResult DelUser(string userId)
        {
            throw new NotImplementedException();
        }

        public JsonResult GetAllUser()
        {
            throw new NotImplementedException();
        }

        public JsonResult Login(string name, string pwd)
        {
            throw new NotImplementedException();
        }

        public JsonResult MotifyPassword(string userId, string psassword)
        {
            throw new NotImplementedException();
        }
    }
}
