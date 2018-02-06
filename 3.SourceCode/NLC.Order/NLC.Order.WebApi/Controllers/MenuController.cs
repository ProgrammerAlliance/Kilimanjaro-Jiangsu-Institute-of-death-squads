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
                jr.Status = 202;
                jr.Result = OrderDAL.GetName();
            }
            catch (Exception)
            {
                jr.Status = 500;
                jr.Result = "出错";
            }
            return jr;
        }
    }
}
