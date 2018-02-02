using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLC.Order.Model;

namespace NLC.Order.IDAL
{
    public interface IOrderDAL
    {
        /// <summary>
        /// 增加订餐
        /// </summary>
        /// <param name="order">订餐对象</param>
        /// <returns></returns>
        bool AddOrder(OrderInfo order);

        /// <summary>
        /// 取消订餐
        /// </summary>
        /// <param name="UserId">用户工号</param>
        /// <returns></returns>
        bool SubOrder(int UserId);

        /// <summary>
        /// 获取所有今日订餐人员
        /// </summary>
        /// <returns></returns>
        List<OrderInfo> Cleaner();

        /// <summary>
        /// 修改打扫人员状态
        /// </summary>
        /// <param name="UserId">工号</param>
        /// <returns></returns>
        bool ModifyCleanState(int UserId);

        /// <summary>
        /// 获取打扫人员名字
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        string GetName(int UserId);

        /// <summary>
        /// 获取今日订餐人员数
        /// </summary>
        /// <returns></returns>
        int CountOrderNumber();

    }
}
