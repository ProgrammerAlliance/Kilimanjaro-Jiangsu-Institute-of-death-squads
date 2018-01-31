using NL.Order.IDAL;
using NL.Order.Model;
using System;
using System.Collections.Generic;

namespace NL.Order.SqlServerDAL
{
    public class UserSqlServerDAL : IUserDAL
    {
        public bool DeleteUser(string userId)
        {
            throw new NotImplementedException();
        }

        public bool InsertUser(UserInfo user)
        {
            throw new NotImplementedException();
        }

        public IList<UserInfo> SelectAllUser()
        {
            throw new NotImplementedException();
        }

        public UserInfo SelectByNameAndPwd(string name, string pwd)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(string userId, string psassword)
        {
            throw new NotImplementedException();
        }
    }
}