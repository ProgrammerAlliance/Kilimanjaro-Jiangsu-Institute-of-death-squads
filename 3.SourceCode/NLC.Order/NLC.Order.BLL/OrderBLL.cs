using NL.Order.Common;
using NLC.Order.Common;
using NLC.Order.DALFactory;
using NLC.Order.IBLL;
using NLC.Order.IDAL;
using NLC.Order.Model;
using System;
using System.Configuration;
using System.Linq;
using System.Xml;

namespace NLC.Order.BLL
{
    public class OrderBLL : IOrderBLL
    {
        private IOrderDAL OrderDAL = Factory.CreateOrderDAL();
        private JsonResult jr = new JsonResult();

        /// <summary>
        /// 获取时间对象
        /// </summary>
        System.DateTime currentTime = System.DateTime.Now;

        /// <summary>
        /// 取消订餐
        /// </summary>
        /// <param name="UserId">员工编号</param>
        /// <returns></returns>
        public JsonResult CancelOrder(int UserId)
        {
            if (currentTime.Hour >= Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Hour"]))
            {
                jr.Status = 404;
                jr.Result = "已超过取消订餐时间";
                return jr;
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
                LogHelper.WriteLogFile(" 取消订餐失败");
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
                jr.Result = OrderDAL.CountOrderNumber(0);
                jr.Status = 200;
            }
            catch (Exception)
            {
                jr.Status = 500;
                jr.Result = "系统繁忙";
                LogHelper.WriteLogFile("统计订餐人数失败");
            }
            return jr;
        }

        /// <summary>
        /// 获得订餐人员信息
        /// </summary>
        /// <param name="rows">行数</param>
        /// <param name="page">页数</param>
        /// <param name="deptId">部门号</param>
        /// <returns></returns>
        public JsonResult GetOrderPeople(int rows, int page, int deptId)
        {
            Page<OrderInfo> pageObject = new Page<OrderInfo>();
            pageObject.CurrentPage = page;
            pageObject.PageRecord = rows;
            try
            {
                pageObject.TotalRecord = OrderDAL.CountOrderNumber(deptId);
                pageObject.TotalPage = pageObject.TotalRecord % rows == 0 ? pageObject.TotalRecord / rows : pageObject.TotalRecord / rows + 1;
                pageObject.ObjectList = OrderDAL.SelectOrderPeople(rows, page, deptId);
                jr.Result = pageObject;
                jr.Status = 200;
            }
            catch (Exception)
            {
                jr.Status = 500;
                jr.Result = "系统繁忙";
                LogHelper.WriteLogFile("获得订餐人员信息失败");
            }
            return jr;
        }

        /// <summary>
        /// 订餐
        /// </summary>
        /// <param name="order">订餐信息</param>
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
                if (OrderDAL.IsOrder(order.UserId))
                {
                    jr.Status = 201;
                    jr.Result = "该用户今日已订餐";
                    return jr;
                }
                jr.Result = OrderDAL.AddOrder(order);
                jr.Status = 200;
            }
            catch (Exception)
            {
                jr.Status = 500;
                jr.Result = "系统繁忙";
                LogHelper.WriteLogFile("订餐失败");
            }
            return jr;
        }

        /// <summary>
        /// 改变订餐人员的打扫状态，生成随机打扫人员
        /// </summary>
        /// <returns></returns>
        public JsonResult ProudceSweep()
        {
            try
            {
                if (currentTime.Hour < Convert.ToInt32(ConfigurationManager.AppSettings["Hour"]))
                {
                    jr.Status = 404;
                    jr.Result = "未到订餐截止时间";
                    return jr;
                }
                if (OrderDAL.IsProduce())
                {
                    jr.Status = 201;
                    jr.Result = "今日已产生打扫人员";
                    return jr;
                }
                var list = OrderDAL.SelectOrderPeople(OrderDAL.CountOrderNumber(0), 1, 0);
                if (list.Count == 0)
                {
                    jr.Result = "无人订餐";
                    jr.Status = 303;
                    return jr;
                }
                if (list.Count > 1)
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
                }
                else
                {
                    OrderDAL.ModifyCleanState(list[0].UserId);
                }
                jr.Result = "OK";
                jr.Status = 200;
            }
            catch (Exception)
            {
                LogHelper.WriteLogFile("改变订餐人员的打扫状态失败");
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
                LogHelper.WriteLogFile("获取打扫人员的名单失败");
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
                LogHelper.WriteLogFile("今日是否产生打扫人员失败");
            }
            return jr;
        }

        /// <summary>
        /// 判断员工今日是否订餐
        /// </summary>
        /// <param name="UserId">员工编号</param>
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
                LogHelper.WriteLogFile("判断员工今日是否订餐失败");
            }
            return jr;
        }

        /// <summary>
        /// 修改订餐截止时间
        /// </summary>
        /// <param name="hour">时</param>
        /// <param name="minutes">分</param>
        /// <returns></returns>
        public JsonResult ModifyTime(int hour, int minutes)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                string strFileName = AppDomain.CurrentDomain.BaseDirectory.ToString() + "Web.config";
                doc.Load(strFileName);
                XmlNodeList nodes = doc.GetElementsByTagName("add");
                XmlAttribute _key_hour = nodes[0].Attributes["Hour"];
                XmlAttribute _key_min = nodes[1].Attributes["Minute"];
                _key_hour = nodes[0].Attributes["value"];
                _key_hour.Value = hour.ToString();
                _key_min = nodes[1].Attributes["value"];
                _key_min.Value = minutes.ToString();
                doc.Save(strFileName);

                jr.Result = "修改成功";
            }
            catch (Exception)
            {
                jr.Result = "修改失败";
                LogHelper.WriteLogFile("修改订餐截止时间失败");
            }
            return jr;
        }

        /// <summary>
        /// 是否已到截止时间
        /// </summary>
        /// <returns></returns>
        public JsonResult IsShowProduceSymbol()
        {

            if (currentTime.Hour >= Convert.ToInt32(ConfigurationManager.AppSettings["Hour"]))
            {
                jr.Status = 404;
                jr.Result = false;
                return jr;
            }
            try
            {
                jr.Result = true;
                jr.Status = 200;
            }
            catch (Exception)
            {
                jr.Status = 500;
                jr.Result = "系统繁忙";
                LogHelper.WriteLogFile("订餐失败");
            }
            return jr;
        }
    }
}
