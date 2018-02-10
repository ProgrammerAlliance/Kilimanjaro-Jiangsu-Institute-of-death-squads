using Newtonsoft.Json;
using NLC.Order.BLL;
using NLC.Order.Common;
using NLC.Order.IBLL;
using NLC.Order.Model;
using System.Web.Http;

namespace NLC.Order.WebApi.Controllers
{
    public class OrderController : ApiController
    {
        /// <summary>
        /// OrderBLL对象
        /// </summary>
        private IOrderBLL orderBLL = new OrderBLL();

        /// <summary>
        /// 获取今日订餐人员信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetOrderPeople(int rows, int page, int deptId)
        {
            return orderBLL.GetOrderPeople(rows, page, deptId);
        }

        /// <summary>
        /// 统计今日订餐人数
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetOrderNumber()
        {
            return orderBLL.CountOrderNumber();
        }

        /// <summary>
        /// 今日是否产生打扫人员
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetWetherProduce()
        {
            return orderBLL.WetherProudce();
        }

        /// <summary>
        /// 用户今日是否订餐
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetUserIsOrder(int userId)
        {
            return orderBLL.UserIsOrder(userId);
        }

        /// <summary>
        /// 获取打扫人员名字
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetCleanName()
        {
            return orderBLL.GetCleanEmpName();
        }

        /// <summary>
        /// 是否可以显示生成打扫按钮
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetIsShowProduceSymbol()
        {
            return orderBLL.IsShowProduceSymbol();
        }

        /// <summary>
        /// 订餐
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult PostAddOrder([FromBody]OrderInfo order)
        {
            return orderBLL.OrderFood(order);
        }

        /// <summary>
        /// 取消订餐
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [HttpDelete]
        public JsonResult DeleteOrder(OrderInfo order)
        {
            return orderBLL.CancelOrder(order.UserId);
        }

        /// <summary>
        /// 产生打扫人员
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public JsonResult PutProduceSweep()
        {
            return orderBLL.ProudceSweep();
        }

        /// <summary>
        /// 修改订餐截止时间
        /// </summary>
        /// <param name="hour">时</param>
        /// <param name="minute">分</param>
        /// <returns></returns>
        [HttpPut]
        public JsonResult PutModifyTime(int hour, int minute)
        {
            return orderBLL.ModifyTime(hour, minute);
        }
    }
}
