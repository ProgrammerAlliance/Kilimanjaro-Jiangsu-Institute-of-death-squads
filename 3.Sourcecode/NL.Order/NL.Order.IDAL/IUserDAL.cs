using NL.Order.Model;
using System.Collections.Generic;

namespace NL.Order.IDAL
{
    public interface IUserDAL
    {
        IList<UserInfo> SelectAllUser();
        UserInfo SelectByNameAndPwd(string name, string pwd);
        bool InsertUser(UserInfo user);
        bool DeleteUser(string userId);
        bool UpdateUser(string userId, string psassword);
    }
}
