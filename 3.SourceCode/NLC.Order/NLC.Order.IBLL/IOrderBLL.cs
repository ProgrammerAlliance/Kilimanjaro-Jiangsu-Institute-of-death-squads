using NLC.Order.Common;
using NLC.Order.Model;

namespace NLC.Order.IBLL
{
    public interface IOrderBLL
    {
        /// <summary>
        /// 订餐
        /// </summary>
        /// <param name="order">用户信息</param>
        /// <returns></returns>
        JsonResult OrderFood(OrderInfo order);

        /// <summary>
        /// 取消订餐
        /// </summary>
        /// <param name="UserId">员工编号</param>
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
        /// <param name="rows">行数</param>
        /// <param name="page">页数</param>
        /// <param name="deptId">部门号</param>
        /// <returns></returns>
        JsonResult GetOrderPeople(int rows, int page, int deptId);

        /// <summary>
        /// 统计今日订餐人数
        /// </summary>
        /// <returns></returns>
        JsonResult CountOrderNumber();

        /// <summary>
        /// 获取打扫人员的名字
        /// </summary>
        /// <returns></returns>
        JsonResult GetCleanEmpName();

        /// <summary>
        /// 今日是否产生打扫人员
        /// </summary>
        /// <returns></returns>
        JsonResult WetherProudce();

        /// <summary>
        /// 员工今日是否订餐
        /// </summary>
        /// <param name="UserId">员工编号</param>
        /// <returns></returns>
        JsonResult UserIsOrder(int UserId);

        /// <summary>
        /// 修改截止订餐时间
        /// </summary>
        /// <param name="hour">时</param>
        /// <param name="minutes">分</param>
        /// <returns></returns>
        JsonResult ModifyTime(int hour, int minutes);
    }
}
