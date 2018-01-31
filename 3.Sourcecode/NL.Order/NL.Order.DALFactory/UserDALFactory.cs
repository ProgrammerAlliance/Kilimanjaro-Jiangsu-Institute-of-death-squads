using NL.Order.IDAL;
using NL.Order.SqlServerDAL;
using System.Configuration;
using NL.Order.OracleDAL;

namespace NL.Order.DALFactory
{
    public class UserDALFactory
    {
        //获取配置文件中DateBaseType对应的值
        private static string dateBaseType = ConfigurationManager.AppSettings["DateBaseType"].ToString();

        /// <summary>
        /// 根据配置文件中的值创建DAL
        /// </summary>
        /// <returns></returns>
        public static IUserDAL CreateUserDAL()
        {
            IUserDAL userDAL = null;
            switch (dateBaseType)
            {
                case "SqlServer":
                    userDAL = new UserSqlServerDAL(); break;
                case "Oracle":
                    userDAL = new UserOracleDAL(); break;
            }
            return userDAL;
        }
    }
}
