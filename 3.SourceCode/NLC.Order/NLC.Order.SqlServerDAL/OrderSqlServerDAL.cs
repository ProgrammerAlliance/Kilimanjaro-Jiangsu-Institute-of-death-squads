using NLC.Order.IDAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NLC.Order.Model;

namespace NLC.Order.SqlServerDAL
{
    public class OrderSqlServerDAL : IOrderDAL
    {
        /// <summary>
        /// 增加订餐
        /// </summary>
        /// <param name="order">订餐信息</param>
        /// <returns></returns>
        public bool AddOrder(OrderInfo order)
        {

            throw new NotImplementedException();
        }

        /// <summary>
        /// 取消订餐
        /// </summary>
        /// <param name="UserId">用户工号</param>
        /// <returns></returns>
        public bool SubOrder(int UserId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 产生打扫人员
        /// </summary>
        /// <returns></returns>
        public List<OrderInfo> Cleaner()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取打扫人员姓名
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public string GetName(int UserId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 修改打扫人员状态
        /// </summary>
        /// <param name="UserId">用户工号</param>
        /// <returns></returns>
        public bool ModifyCleanState(int UserId)
        {
            throw new NotImplementedException();
        }

    }
}