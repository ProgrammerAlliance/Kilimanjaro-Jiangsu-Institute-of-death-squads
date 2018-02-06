using NLC.Order.Common;
using NLC.Order.DALFactory;
using NLC.Order.IBLL;
using NLC.Order.IDAL;
using NLC.Order.Model;
using System;

namespace NLC.Order.BLL
{
    public class MbenuBLL : IMenuBLL
    {
        private IMenuDAL MenuDAL = Factory.CreateMenuDAL();
        private JsonResult jr = new JsonResult();

        /// <summary>
        /// 增加菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public JsonResult AddFood(MenuInfo menu)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="DishesId"></param>
        /// <returns></returns>
        public JsonResult DelFood(int DishesId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取所有菜单
        /// </summary>
        /// <returns></returns>
        public JsonResult GetMenu(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
