using NLC.Order.IBLL;
using System;
using NLC.Order.Common;
using NLC.Order.Model;
using NLC.Order.IDAL;
using NLC.Order.DALFactory;

namespace NLC.Order.BLL
{
    public class OrderBLL : IOrderBLL
    {
        private IOrderDAL OrderDAL = Factory.CreateOrderDAL();
        private JsonResult jr = new JsonResult();

        /// <summary>
        /// 取消订餐
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public JsonResult CancelOrder(int  UserId)
        {
            try
            {
                jr.Result = OrderDAL.SubOrder(UserId);
                jr.Status = 200;
            }
            catch (Exception)
            {
                jr.Status = 500;
                jr.Result = "系统繁忙";
            }
            return jr;
        }

        /// <summary>
        /// 统计订餐人数
        /// </summary>
        /// <returns></returns>
        public JsonResult CountOrderNumber()
        {
            try
            {
               
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }

        /// <summary>
        /// 获得订餐人员信息
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public JsonResult GetOrderPeople(OrderInfo order)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 订餐
        /// </summary>
        /// <returns></returns>
        public JsonResult OrderFood()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 生成打扫
        /// </summary>
        /// <returns></returns>
        public JsonResult ProudceSweep()
        {
            throw new NotImplementedException();
        }
    }
}
