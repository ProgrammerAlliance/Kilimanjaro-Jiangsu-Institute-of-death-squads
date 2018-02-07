using NLC.Order.Common;
using NLC.Order.Model;

namespace NLC.Order.IBLL
{
    public interface IMenuBLL
    {
        /// <summary>
        /// 增加菜品
        /// </summary>
        /// <param name="menu">菜单</param>
        /// <returns></returns>
        JsonResult AddDish(MenuInfo menu);

        /// <summary>
        /// 删除菜品
        /// </summary>
        /// <param name="DishesId">菜品编号</param>
        /// <returns></returns>
        JsonResult DelDish(int DishesId);

        /// <summary>
        /// 获取所有菜品
        /// </summary>
        /// <returns></returns>
        JsonResult GetMenu(int Id);

        JsonResult GetRestaurant();
    }
}
