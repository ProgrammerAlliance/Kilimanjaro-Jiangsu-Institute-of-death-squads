using NLC.Order.Common;
using NLC.Order.DALFactory;
using NLC.Order.IBLL;
using NLC.Order.IDAL;
using System;
using System.Data.SqlClient;

namespace NLC.Order.BLL
{
    public class DeptBLL : IDeptBLL
    {
        private IDeptDAL DeptDAL = Factory.CreateDeptDAL();
        private JsonResult jr = new JsonResult();

        /// <summary>
        /// 获得所有部门
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAllDept()
        {
            try
            {
                jr.Status = 200;
                jr.Result = DeptDAL.GetAllDept();
            }
            catch (SqlException e)
            {
                jr.Status = 405;
                jr.Result = "数据库异常";
                LogHelper.WriteLogFile(e.Message);
            }
            catch (Exception e)
            {
                jr.Status = 500;
                jr.Result = "系统繁忙";
                LogHelper.WriteLogFile(e.Message);
            }
            return jr;
        }
    }
}
