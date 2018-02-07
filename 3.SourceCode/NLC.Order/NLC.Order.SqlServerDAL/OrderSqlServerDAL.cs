using NLC.Order.IDAL;
using System;
using System.Collections.Generic;
using NLC.Order.Model;
using System.Data.SqlClient;
using NLC.Order.DBUtility;
using System.Data;
using NLC.Order.Common;
using System.Text;

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
            int result = 0;
            try
            {
                string sql = "delete from ordertable where DateDiff(dd,createtime,getdate())=0 and UserId=@UserId";
                SqlParameter[] parameters =
                {
                new SqlParameter("UserId",UserId)
            };
                result = DBHelper.NonQuery(sql, parameters);
            }
            catch (Exception)
            {
                LogHelper.WriteLogFile("执行取消订餐SQL语句失败");
            }
            return result > 0 ? true : false;
        }

        /// <summary>
        /// 获取今日订餐人员信息，分页显示
        /// </summary>
        /// <param name="rows">行数</param>
        /// <param name="page">页数</param>
        /// <param name="deptId">部门ID</param>
        /// <returns></returns>
        public List<OrderInfo> SelectOrderPeople(int rows, int page, int deptId)
        {
            DataSet ds = null;
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("SELECT ROW_NUMBER() OVER(ORDER BY o.OrderNo) AS ROWID, " +
                    "o.UserId,e.UserName ,d.Deptname,o.Remark " +
                    "FROM OrderTable as o, Emp as e, Deptment d " +
                    "where e.UserId = o.UserId and e.Deptno = d.Deptno " +
                    "and DateDiff(dd, CreateTime, getdate()) = 0 ");
                if (deptId != 0)
                {
                    stringBuilder.Append(" and d.DeptNo=@deptNo");
                }
                string sql = "SELECT * FROM (" + stringBuilder.ToString() + ")t1 " +
                    "WHERE ROWID between(@startRows) and(@endRows)";
                SqlParameter[] parameters =
                {
                    new SqlParameter("startRows",rows*(page-1)+1),
                    new SqlParameter("endRows",rows*page),
                    new SqlParameter("deptNo",deptId)
                };
                ds = DBHelper.Query(sql, parameters);
            }
            catch (Exception)
            {
                LogHelper.WriteLogFile("执行获取今日订餐人员信息SQL语句失败");
            }
            return DBHelper.GetListbyDataSet<OrderInfo>(ds);
        }

        /// <summary>
        /// 获取打扫人员姓名
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <returns></returns>
        public IList<UserInfo> GetName()
        {
            DataSet ds = null;
            List<UserInfo> list = null;
            try
            {
                string sql = "select e.UserName " +
               " from Emp e,OrderTable o " +
               " where e.UserId=o.UserId and o.Clean=1 " +
               " and  DateDiff(dd, CreateTime, getdate()) = 0";
                ds = DBHelper.Query(sql, null);
                list = DBHelper.GetListbyDataSet<UserInfo>(ds);
            }
            catch (Exception)
            {
                LogHelper.WriteLogFile("执行获取打扫人员姓名SQL语句失败");
            }
            return list;
        }

        /// <summary>
        /// 修改打扫人员状态
        /// </summary>
        /// <param name="UserId">用户工号</param>
        /// <returns></returns>
        public bool ModifyCleanState(int UserId)
        {
            int result = 0;
            try
            {
                string sql = "update OrderTable set Clean=1 where UserId=@UserId and DateDiff(dd, CreateTime, getdate()) = 0";
                SqlParameter[] parameters =
                {
                    new SqlParameter("UserId",UserId)
                };
                result = DBHelper.NonQuery(sql, parameters);
            }
            catch (Exception)
            {
                LogHelper.WriteLogFile("执行修改打扫人员状态SQL语句失败");
            }
            return result > 0 ? true : false;
        }

        /// <summary>
        /// 获取今日订餐人员数
        /// </summary>
        /// <returns></returns>
        public int CountOrderNumber(int deptId)
        {
            DataSet ds = null;
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("select * from ordertable o,emp e,deptment d " +
                    "where o.userid=e.userid and e.deptno=d.deptno and " +
                    "DateDiff(dd, CreateTime, getdate()) = 0 ");
                if (deptId != 0)
                {
                    stringBuilder.Append(" and d.DeptNo=@deptNo");
                }
                SqlParameter[] parameters =
                {
                    new SqlParameter("deptNo",deptId)
                };
                ds = DBHelper.Query(stringBuilder.ToString(), parameters);
            }
            catch (Exception)
            {
                LogHelper.WriteLogFile("执行获取今日订餐人员数SQL语句失败");
            }
            return ds.Tables[0].Rows.Count;
        }

        /// <summary>
        /// 今日是否订餐
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <returns></returns>
        public bool IsOrder(int UserId)
        {
            DataSet ds = null;
            try
            {
                string sql = @"SELECT  UserId
                           FROM  dbo.OrderTable
                           WHERE (DATEDIFF(dd, CreateTime, GETDATE()) = 0) 
                           AND (UserId = @UserId)";
                SqlParameter[] parameters =
                {
                    new SqlParameter("UserId",UserId)
                };
                ds = DBHelper.Query(sql, parameters);
            }
            catch (Exception)
            {
                LogHelper.WriteLogFile("执行今日是否订餐SQL语句失败");
            }
            return ds.Tables[0].Rows.Count <= 0 ? false : true;
        }

        /// <summary>
        /// 判断今日是否生成打扫人员
        /// </summary>
        /// <returns></returns>
        public bool IsProduce()
        {
            DataSet ds = null;
            try
            {
                string sql = @"SELECT OrderNo, UserId, CreateTime, Clean, Remark
                         FROM dbo.OrderTable
                         WHERE   
                        (DATEDIFF(dd, CreateTime, GETDATE()) = 0) AND (Clean = 1)";
                ds = DBHelper.Query(sql, null);
            }
            catch (Exception)
            {
                LogHelper.WriteLogFile("执行判断今日是否生成打扫人员SQL语句失败");
            }
            return ds.Tables[0].Rows.Count <= 0 ? false : true;
        }
    }
}