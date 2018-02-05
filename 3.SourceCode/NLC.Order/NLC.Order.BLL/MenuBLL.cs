
using System;
using NLC.Order.Common;
using NLC.Order.Model;
using NLC.Order.IBLL;
using NLC.Order.DALFactory;

namespace NLC.Order.BLL
{
    public class MbenuBLL : IMenuBLL
    {
        private IMenuDAL MenuDAL = Factory.CreateMenuDAL();
        private JsonResult jr = new JsonResult();
        public JsonResult AddDishes(MenuInfo menu)
        {
            throw new NotImplementedException();
        }

        public JsonResult DelDishes(int DishesId)
        {
            throw new NotImplementedException();
        }

        public JsonResult GetAllMenu()
        {
            throw new NotImplementedException();
        }

        public JsonResult ModifyDishes(MenuInfo menu)
        {
            throw new NotImplementedException();
        }
    }
}
