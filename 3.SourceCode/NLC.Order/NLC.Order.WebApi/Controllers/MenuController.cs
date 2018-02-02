using NLC.Order.BLL;
using NLC.Order.Common;
using NLC.Order.DALFactory;
using NLC.Order.IBLL;
using NLC.Order.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NLC.Order.WebApi.Controllers
{
    public class MenuController : ApiController
    {
        private IOrderDAL OrderDAL = Factory.CreateOrderDAL();
        private JsonResult jr = new JsonResult();

        [HttpGet]
        public JsonResult Test()
        {
            try
            {
                string name = OrderDAL.GetName(1001);
                jr.Status = 202;
                jr.Result = name == null ? "又是空的字符串" : name;
            }
            catch (Exception e)
            {
                jr.Status = 500;
                jr.Result = "出错";
            }
            return jr;
        }
    }
}
