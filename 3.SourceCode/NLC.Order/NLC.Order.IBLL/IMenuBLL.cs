using NLC.Order.Common;
using NLC.Order.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLC.Order.IBLL
{
   public interface IMenuBLL
    {
        /// <summary>
        /// 增加菜品
        /// </summary>
        /// <param name="menu">菜单</param>
        /// <returns></returns>
        JsonResult AddDishes(MenuInfo menu);

        /// <summary>
        /// 删除菜品
        /// </summary>
        /// <param name="DishesId">菜品编号</param>
        /// <returns></returns>
        JsonResult DelDishes(int DishesId);

        /// <summary>
        /// 更改菜单
        /// </summary>
        /// <param name="menu">菜单</param>
        /// <returns></returns>
        JsonResult ModifyDishes(MenuInfo menu);

        /// <summary>
        /// 获取所有菜品
        /// </summary>
        /// <returns></returns>
        JsonResult GetAllMenu();
    }
}
