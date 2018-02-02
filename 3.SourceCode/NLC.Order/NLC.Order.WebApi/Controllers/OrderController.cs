using NLC.Order.Common;
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

        [HttpGet]
        public JsonResult AddOrder()
        {
            return null;
        }

        /// <summary>
        /// 取消订餐
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult CancelOrder(int orderId)
        {
            return null;
        }

        /// <summary>
        /// 产生打扫人员
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult ProduceSweep()
        {
            return null;
        }

        /// <summary>
        /// 获取今日订餐人员信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetOrderPeople()
        {
            return null;
        }

        /// <summary>
        /// 统计今日订餐人数
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult CountOrderNumber()
        {
            return null;
        }
    }
}
