using NLC.Order.IDAL;
using NLC.Order.OracleDAL;
using NLC.Order.SqlServerDAL;
using System.Configuration;

namespace NLC.Order.DALFactory
{
    public class Factory
    {
        //获取配置文件中DateBaseType对应的值
        private static string dateBaseType = ConfigurationManager.AppSettings["DateBaseType"].ToString();
        
        /// <summary>
        /// 根据配置文件中的值创建UserDAL
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

        /// <summary>
        /// 根据配置文件中的值创建OrderDAL
        /// </summary>
        /// <returns></returns>
        public static IUserDAL CreateOrderDAL()
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

        /// <summary>
        /// 根据配置文件中的值创建MenuDAL
        /// </summary>
        /// <returns></returns>
        public static IUserDAL CreateMenuDAL()
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
