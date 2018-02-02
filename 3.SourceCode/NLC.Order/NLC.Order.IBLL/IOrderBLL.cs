using NLC.Order.Common;
using NLC.Order.Model;

namespace NLC.Order.IBLL
{
    public interface IOrderBLL
    {
        /// <summary>
        /// 订餐
        /// </summary>
        /// <returns></returns>
        JsonResult OrderFood(OrderInfo order);

        /// <summary>
        /// 取消订餐
        /// </summary>
        /// <returns></returns>
        JsonResult CancelOrder(int UserId);

        /// <summary>
        /// 产生打扫人员
        /// </summary>
        /// <returns></returns>
        JsonResult ProudceSweep();

        /// <summary>
        /// 获取今日订餐人员信息
        /// </summary>
        /// <returns></returns>
        JsonResult GetOrderPeople();

        /// <summary>
        /// 统计今日订餐人数
        /// </summary>
        /// <returns></returns>
        JsonResult CountOrderNumber();

        /// <summary>
        /// 获取打扫人员的名字
        /// </summary>
        /// <returns></returns>
        JsonResult GetName();
    }
}
