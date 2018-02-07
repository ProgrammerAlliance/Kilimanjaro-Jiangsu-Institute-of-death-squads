using System;
using System.Collections.Generic;
using NLC.Order.IDAL;
using NLC.Order.Model;
using NLC.Order.DBUtility;
using System.Data;
using NLC.Order.Common;

namespace NLC.Order.SqlServerDAL
{
    public class DeptSqlServerDAL : IDeptDAL
    {
        /// <summary>
        /// 获取所有的部门
        /// </summary>
        /// <returns></returns>
        public List<DeptInfo> GetAllDept()
        {
            List<DeptInfo> list = null;
            try
            {
                string sql = @"SELECT  DeptNo, DeptName
                           FROM dbo.Deptment";
                DataSet ds = DBHelper.Query(sql, null);
                list = DBHelper.GetListbyDataSet<DeptInfo>(ds);
            }

            catch (Exception)
            {
                LogHelper.WriteLogFile("执行获取所有的部门SQL语句失败");
            }
            return list;
        }
    }
}