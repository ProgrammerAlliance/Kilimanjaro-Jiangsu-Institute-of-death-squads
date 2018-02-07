using NLC.Order.Model;
using System.Collections.Generic;

namespace NLC.Order.IDAL
{
    public interface IMenuDAL
    {
        /// <summary>
        /// 增加菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        bool InsertMenu(MenuInfo menu);

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        bool DelMenu(int menuId);

        /// <summary>
        /// 根据饭店查找菜单
        /// </summary>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        List<MenuInfo> SelectMenuByRestaurant(int restaurantId);

        /// <summary>
        /// 获取所有饭店
        /// </summary>
        /// <returns></returns>
        List<RestaurInfo> SelectAllRestaurant();

        /// <summary>
        /// 根据菜品名称和饭店查找菜品
        /// </summary>
        /// <param name="foodName"></param>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        bool SelectMenuByNameAndRestaurant(string foodName,int restaurantId);
    }
}
