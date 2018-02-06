using System;
using System.Collections.Generic;
using NLC.Order.IDAL;
using NLC.Order.Model;

namespace NLC.Order.SqlServerDAL
{
    public class MenuSqlServerDAL : IMenuDAL
    {
        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public bool DelMenu(int menuId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 插入菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public bool InsertMenu(MenuInfo menu)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 查找所有饭店
        /// </summary>
        /// <returns></returns>
        public List<RestaurInfo> SelectAllRestaurant()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据饭店查找所有菜单
        /// </summary>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        public List<MenuInfo> SelectMenuByRestaurant(int restaurantId)
        {
            throw new NotImplementedException();
        }
    }
}