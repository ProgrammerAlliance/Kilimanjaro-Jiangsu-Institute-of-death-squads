using NLC.Order.BLL;
using NLC.Order.Common;
using NLC.Order.DALFactory;
using NLC.Order.IBLL;
using NLC.Order.IDAL;
using NLC.Order.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace NLC.Order.WebApi.Controllers
{
    public class MenuController : ApiController
    {
        private IMenuBLL menuBLL = new MenuBLL();
        private JsonResult jr = new JsonResult();

        [HttpGet]
        public JsonResult GetMenu()
        {
            return null;
        }

        [HttpGet]
        public JsonResult AddlDish(MenuInfo food)
        {
            return menu
        }


    }
}
