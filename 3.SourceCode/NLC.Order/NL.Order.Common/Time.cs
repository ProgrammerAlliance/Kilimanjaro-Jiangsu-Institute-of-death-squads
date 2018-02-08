using System;
using System.Configuration;

namespace NLC.Order.Common
{
    public class Time
    {
        /// <summary>
        /// 是否已到截止时间
        /// </summary>
        /// <returns></returns>
        public bool IsTimeUp()
        {
            System.DateTime currentTime = System.DateTime.Now;

            int hour = Convert.ToInt32(ConfigurationManager.AppSettings["Hour"]);
            int minute = Convert.ToInt32(ConfigurationManager.AppSettings["Minute"]);

            if (currentTime.Hour < hour || (currentTime.Hour <= hour && currentTime.Minute <= minute))
            {
                return true;
            }
            return false;
        }
    }
}
