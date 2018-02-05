using System;
using System.Collections.Generic;
using NLC.Order.IDAL;
using NLC.Order.Model;
using NLC.Order.DBUtility;
using System.Data;

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
            string sql = @"SELECT  DeptNo, DeptName
                           FROM dbo.Deptment";
            DataSet ds = DBHelper.Query(sql, null);
            return DBHelper.GetListbyDataSet<DeptInfo>(ds);
        }
    }
}