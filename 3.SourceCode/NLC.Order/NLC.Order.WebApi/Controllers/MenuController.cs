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

        /// <summary>
        /// 获取菜单
        /// </summary>
        /// <param name="id">饭店ID</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetMenu(int id)
        {
            return menuBLL.GetMenu(id);
        }

        /// <summary>
        /// 添加菜
        /// </summary>
        /// <param name="dish">菜对象</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult AddlDish(MenuInfo dish)
        {
            return menuBLL.AddDish(dish);
        }

        /// <summary>
        /// 删除菜
        /// </summary>
        /// <param name="id">菜ID</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult DelDish(int id)
        {
            return menuBLL.DelDish(id);
        }

        [HttpGet]
        public JsonResult GetAllRest()
        {
            return menuBLL;
        }


    }
}
