using NLC.Order.IBLL;
using System;
using NLC.Order.Common;
using NLC.Order.Model;
using NLC.Order.IDAL;
using NLC.Order.DALFactory;
using System.Configuration;
using System.Linq;
using NL.Order.Common;

namespace NLC.Order.BLL
{
    public class OrderBLL : IOrderBLL
    {
        private IOrderDAL OrderDAL = Factory.CreateOrderDAL();m
        private JsonResult jr = new JsonResult();

        /// <summary>
        /// 获取时间对象
        /// </summary>
        System.DateTime currentTime = System.DateTime.Now;

        /// <summary>
        /// 取消订餐
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public JsonResult CancelOrder(int UserId)
        {
            if (currentTime.Hour >= Convert.ToInt32(ConfigurationManager.AppSettings["Hour"]))
            {
                jr.Status = 404;
                jr.Result = "已超过取消订餐时间";
            }
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
        public JsonResult GetOrderPeople(int rows, int page)
        {
            Page<OrderInfo> pageObject = new Page<OrderInfo>();
            pageObject.CurrentPage = page;
            pageObject.PageRecord = rows;
            try
            {
                pageObject.TotalRecord = OrderDAL.CountOrderNumber();
                pageObject.TotalPage = pageObject.TotalRecord % rows == 0 ? pageObject.TotalRecord / rows : pageObject.TotalRecord / rows + 1;
                pageObject.ObjectList = OrderDAL.SelectOrderPeople(rows, page);
                jr.Result = pageObject;
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
            if (currentTime.Hour >= Convert.ToInt32(ConfigurationManager.AppSettings["Hour"]))
            {
                jr.Status = 404;
                jr.Result = "已超过订餐时间";
                return jr;
            }
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
        /// 改变订餐人员的打扫状态
        /// </summary>
        /// <returns></returns>
        public JsonResult ProudceSweep()
        {
            if (currentTime.Hour < Convert.ToInt32(ConfigurationManager.AppSettings["Hour"]))
            {
                jr.Status = 404;
                jr.Result = "未到订餐截止时间";
            }
            var list = OrderDAL.SelectOrderPeople(OrderDAL.CountOrderNumber(),1);
            if (list.Count > 0)
            {
                int[] GetId = new int[2];
                for (int i = 0; i < 2; i++)
                {
                    int number = new Random().Next(0, list.Count);
                    var randowitem = list[number];
                    if (!GetId.Contains(number))
                    {
                        GetId[i] = number;
                    }
                    else
                    {
                        i--;
                        continue;
                    }
                    OrderDAL.ModifyCleanState(list[GetId[i]].UserId);
                }
                jr.Result = "OK";
                jr.Status = 200;
            }
            else
            {
                jr.Result = "无人订餐";
                jr.Status = 303;
            }
            return jr;
        }

        /// <summary>
        /// 获取打扫人员的名单
        /// </summary>
        /// <returns></returns>
        public JsonResult GetCleanEmpName()
        {
            try
            {
                jr.Result = OrderDAL.GetName();
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
        /// 今日是否产生打扫人员
        /// </summary>
        /// <returns></returns>
        public JsonResult WetherProudce()
        {
            try
            {
                jr.Result = OrderDAL.IsProduce();
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
        /// 判断员工今日是否订餐
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public JsonResult UserIsOrder(int UserId)
        {
            try
            {
                jr.Result = OrderDAL.IsOrder(UserId);
                jr.Status = 200;
            }
            catch (Exception)
            {
                jr.Status = 500;
                jr.Result = "系统繁忙";
            }
            return jr;
        }
    }
}
