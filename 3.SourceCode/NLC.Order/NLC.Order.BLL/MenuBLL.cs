using NL.Order.Common;
using NLC.Order.Common;
using NLC.Order.DALFactory;
using NLC.Order.IBLL;
using NLC.Order.IDAL;
using NLC.Order.Model;
using System;

namespace NLC.Order.BLL
{
    public class MenuBLL : IMenuBLL
    {
        private IMenuDAL MenuDAL = Factory.CreateMenuDAL();
        private JsonResult jr = new JsonResult();

        /// <summary>
        /// 增加菜单
        /// </summary>
        /// <param name="menu">菜单</param>
        /// <returns></returns>
        public JsonResult AddDish(MenuInfo menu)
        {
            try
            {
                jr.Result=MenuDAL.InsertMenu(menu);
                jr.Status = 200;
            }
            catch (Exception)
            {

                jr.Result = "增加菜单失败";
                jr.Status = 500;
                LogHelper.WriteLogFile("增加菜单失败！");
            }
            return jr;
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public JsonResult DelDish(int menuId)
        {
            try
            {
                jr.Result= MenuDAL.DelMenu(menuId);
                jr.Status = 200;
            }
            catch (Exception)
            {
                jr.Result = "删除菜单失败";
                jr.Status = 500;
                LogHelper.WriteLogFile("删除菜单失败！");
            }
            return jr;
        }

        /// <summary>
        /// 根据饭店获取所有菜单
        /// </summary>
        /// <param name="id">饭店的ID</param>
        /// <returns></returns>
        public JsonResult GetMenu(int id)
        {
            try
            {
               jr.Result= MenuDAL.SelectMenuByRestaurant(id);
               jr.Status = 200;
            }
            catch (Exception)
            {
                jr.Result = "获取所有菜单失败";
                jr.Status = 500;
                LogHelper.WriteLogFile("获取所有菜单失败！");
            }
            return jr;
        }

        /// <summary>
        /// 获取所有饭店
        /// </summary>
        /// <returns></returns>
        public JsonResult GetRestaurant()
        {
            try
            {
                jr.Result = MenuDAL.SelectAllRestaurant();
                jr.Status = 200;
            }
            catch (Exception)
            {
                jr.Result = "获取所有饭店失败";
                jr.Status = 500;
                LogHelper.WriteLogFile("获取所有饭店失败！");
            }
            return jr;
        }
    }
}
