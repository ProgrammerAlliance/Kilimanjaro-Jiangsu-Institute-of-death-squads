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
    public class DeptBLL : IDeptBLL
    {
        private IDeptDAL DeptDAL = Factory.CreateOrderDAL();
        private JsonResult jr = new JsonResult();
        
        public JsonResult GetAllDept()
        {
            
            return jr;
        }

    }
}
