using NL.Order.Common;
using NL.Order.Model;

namespace NL.Order.IBLL
{
    public interface IUserBLL
    {
        JsonResult GetAllUser();
        JsonResult Login(string name, string pwd);
        JsonResult AddUser(UserInfo user);
        JsonResult DelUser(string userId);
        JsonResult MotifyPassword(string userId, string psassword);
    }
}
