using NLC.Order.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLC.Order.Model;
using System.Data;
using NLC.Order.DBUtility;

namespace NLC.Order.OracleDAL
{
    public class OrderOracleDAL : IOrderDAL
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
        /// 获取今日所有订餐详情表
        /// </summary>
        /// <returns></returns>
        public List<OrderInfo> SelectOrderPeople(int rows, int page, int deptId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 统计今日订餐人数
        /// </summary>
        /// <returns></returns>
        public int CountOrderNumber()
        {
            string sql = "select * from ordertable where DateDiff(dd, CreateTime, getdate()) = 0";
            DataSet ds = DBHelper.Query(sql, null);
            return ds.Tables[0].Rows.Count;
        }

        /// <summary>
        /// 获取打扫人员名字
        /// </summary>
        /// <returns></returns>
        public IList<UserInfo> GetName()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 今日是否订餐
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <returns></returns>
        public bool IsOrder(int UserId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 今日是否生成打扫人员
        /// </summary>
        /// <returns></returns>
        public bool IsProduce()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 修改数据库用户打扫状态
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <returns></returns>
        public bool ModifyCleanState(int UserId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 取消订餐
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <returns></returns>
        public bool SubOrder(int UserId)
        {
            throw new NotImplementedException();
        }
    }
}
