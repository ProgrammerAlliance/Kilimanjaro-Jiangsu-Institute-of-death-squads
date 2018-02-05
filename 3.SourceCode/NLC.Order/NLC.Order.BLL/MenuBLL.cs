
using System;
using NLC.Order.Common;
using NLC.Order.Model;
using NLC.Order.IBLL;
using NLC.Order.DALFactory;
using NLC.Order.IDAL;

namespace NLC.Order.BLL
{
    public class MbenuBLL : IMenuBLL
    {
        private IMenuDAL MenuDAL = Factory.CreateMenuDAL();
        private JsonResult jr = new JsonResult();
        public JsonResult AddDishes(MenuInfo menu)
        {
            try
            {

            }
            catch (Exception)
            {

                jr.Result = "系统繁忙";
                jr.Status = 404;
            }
            return jr;
        }

        public JsonResult DelDishes(int DishesId)
        {
            try
            {

            }
            catch (Exception)
            {
                jr.Result = "系统繁忙";
                jr.Status = 404;
            }
            return jr;
        }

        public JsonResult GetAllMenu()
        {
            try
            {

            }
            catch (Exception)
            {
                jr.Result = "系统繁忙";
                jr.Status = 404;
            }
            return jr;
        }

        public JsonResult ModifyDishes(MenuInfo menu)
        {
            try
            {

            }
            catch (Exception)
            {
                jr.Result = "系统繁忙";
                jr.Status = 404;
            }
            return jr;
        }
    }
}
