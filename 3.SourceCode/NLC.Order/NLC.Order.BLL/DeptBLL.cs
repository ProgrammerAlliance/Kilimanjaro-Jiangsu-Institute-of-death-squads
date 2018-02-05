using NLC.Order.IBLL;
using System;
using NLC.Order.Common;
using NLC.Order.Model;
using NLC.Order.IDAL;
using NLC.Order.DALFactory;
using System.Configuration;
using System.Linq;
using NL.Order.Common;
using System.Data.SqlClient;

namespace NLC.Order.BLL
{
    public class DeptBLL : IDeptBLL
    {
        private IDeptDAL DeptDAL = Factory.CreateDeptDAL();
        private JsonResult jr = new JsonResult();

        public JsonResult GetAllDept()
        {
            try
            {
                jr.Status = 200;
                jr.Result = DeptDAL.GetAllDept();
            }
            catch (SqlException)
            {
                jr.Status = 405;
                jr.Result = "数据库异常";
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
