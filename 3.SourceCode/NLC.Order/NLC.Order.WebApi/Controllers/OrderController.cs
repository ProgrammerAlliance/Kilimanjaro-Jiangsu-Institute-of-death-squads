using Newtonsoft.Json;
using NLC.Order.BLL;
using NLC.Order.Common;
using NLC.Order.IBLL;
using NLC.Order.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        /// 订餐
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult AddOrder(string order)
        {
            OrderInfo orderInfo = JsonConvert.DeserializeObject<OrderInfo>(order);
            return orderBLL.OrderFood(orderInfo);
        }

        /// <summary>
        /// 取消订餐
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult CancelOrder(int userId)
        {
            return orderBLL.CancelOrder(userId);
        }

        /// <summary>
        /// 产生打扫人员
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult ProduceSweep()
        {
            //return orderBLL.ProudceSweep();
            return null;
        }

        /// <summary>
        /// 获取今日订餐人员信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetOrderPeople()
        {
            return orderBLL.GetOrderPeople();
        }

        /// <summary>
        /// 统计今日订餐人数
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult CountOrderNumber()
        {
            return orderBLL.CountOrderNumber();
        }
    }
}
