using NLC.Order.IDAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NLC.Order.Model;
using System.Data.SqlClient;
using NLC.Order.DBUtility;
using System.Data;

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
            string sql = @"insert into OrderTable
                           (UserId, Clean, Remark)
                           values
                           (@UserId, @Clean, @Remark)";
            SqlParameter[] parameters =
           {
                new SqlParameter("UserId",order.UserId),
                new SqlParameter("Clean",order.Clean),
                new SqlParameter("Remark",order.Remark)
            };
            return DBHelper.NonQuery(sql, parameters) > 0 ? true : false;
        }

        /// <summary>
        /// 取消订餐
        /// </summary>
        /// <param name="UserId">用户工号</param>
        /// <returns></returns>
        public bool SubOrder(int UserId)
        {
            string sql = "delete from ordertable where DateDiff(dd,createtime,getdate())=0 and UserId=@UserId";
            SqlParameter[] parameters =
            {
                new SqlParameter("UserId",UserId)
            };
            int result = DBHelper.NonQuery(sql, parameters);
            return result > 0 ? true : false;
        }

        /// <summary>
        /// 产生打扫人员
        /// </summary>
        /// <returns></returns>
        public List<OrderInfo> Cleaner()
        {
            string sql = "select o.UserId,e.UserName,d.Deptname,o.Remark " +
                "from OrderTable o,Emp e, Deptment d " +
                "where o.userid = e.userid and e.deptno = d.deptno and DateDiff(dd, createtime, getdate())= 0";
            DataSet ds = DBHelper.Query(sql, null);
            return DBHelper.GetListbyDataSet<OrderInfo>(ds);
        }

        /// <summary>
        /// 获取打扫人员姓名
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public IList<UserInfo> GetName()
        {
            string sql = "select e.UserName " +
                " from Emp e,OrderTable o " +
                " where e.UserId=o.UserId and o.Clean=1 " +
                " and  DateDiff(dd, CreateTime, getdate()) = 0";
            DataSet ds = DBHelper.Query(sql, null);
            List<UserInfo> list = DBHelper.GetListbyDataSet<UserInfo>(ds);
            return list;
        }

        /// <summary>
        /// 修改打扫人员状态
        /// </summary>
        /// <param name="UserId">用户工号</param>
        /// <returns></returns>
        public bool ModifyCleanState(int UserId)
        {
            string sql = "update OrderTable set Clean=1 where UserId=@UserId and DateDiff(dd, CreateTime, getdate()) = 0";
            SqlParameter[] parameters =
            {
                new SqlParameter("UserId",UserId)
            };
            int result = DBHelper.NonQuery(sql, parameters);
            return result > 0 ? true : false;
        }

        /// <summary>
        /// 获取今日订餐人员数
        /// </summary>
        /// <returns></returns>
        public int CountOrderNumber()
        {
            string sql = "select * from ordertable where DateDiff(dd, CreateTime, getdate()) = 0";
            DataSet ds = DBHelper.Query(sql, null);
            return ds.Tables[0].Rows.Count;
        }

        /// <summary>
        /// 今日是否订餐
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public bool IsOrder(int UserId)
        {
            string sql = @"SELECT  UserId
                           FROM  dbo.OrderTable
                           WHERE (DATEDIFF(dd, CreateTime, GETDATE()) = 0) 
                           AND (UserId = @UserId)";
            SqlParameter[] parameters =
            {
                new SqlParameter("UserId",UserId)
            };
            DataSet ds = DBHelper.Query(sql, parameters);
            return ds.Tables[0].Rows.Count <= 0 ? false : true;
        }

        public bool IsProduce()
        {
            string sql = @"SELECT OrderNo, UserId, CreateTime, Clean, Remark
                         FROM dbo.OrderTable
                         WHERE   
                        (DATEDIFF(dd, CreateTime, GETDATE()) = 0) AND (Clean = 1)";
            DataSet ds = DBHelper.Query(sql, null);
            return ds.Tables[0].Rows.Count <= 0 ? false : true;
        }
    }
}