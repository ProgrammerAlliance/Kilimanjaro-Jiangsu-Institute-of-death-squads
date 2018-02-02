using NLC.Order.IBLL;
using System;
using NLC.Order.Common;
using NLC.Order.Model;
using NLC.Order.IDAL;
using NLC.Order.DALFactory;
using System.Linq;

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
        public JsonResult CancelOrder(int UserId)
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
                jr.Result = OrderDAL.CountOrderNumber();
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
        /// 获得订餐人员信息
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public JsonResult GetOrderPeople()
        {
            try
            {
                jr.Result = OrderDAL.Cleaner();
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
        /// 订餐
        /// </summary>
        /// <returns></returns>
        public JsonResult OrderFood(OrderInfo order)
        {
            try
            {
                jr.Result = OrderDAL.AddOrder(order);
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
        /// 生成打扫
        /// </summary>
        /// <returns></returns>
        public JsonResult ProudceSweep()
        {
            
            var list = OrderDAL.Cleaner();
            if (list.Count > 0)
            {
                int[] getId = { };
                for (int i = 0; i < 2; i++)
                {

                    int number = new Random().Next(list.Count);
                    var id = list[number];
                    if (!getId.Contains(Convert.ToInt32(id)))
                    {
                        getId[i] = Convert.ToInt32(id);
                    }
                    else
                    {
                        continue;
                    }

                    jr.Result = OrderDAL.GetName(getId[i]);
                }
                jr.Status = 200;
            }
            else
            {
                jr.Status = 404;
                jr.Result = "无人订餐";

            }
            
            return jr;
        }

    }
}
