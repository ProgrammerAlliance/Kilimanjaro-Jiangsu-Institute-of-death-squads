using System;
using System.Collections.Generic;
using NLC.Order.IDAL;
using NLC.Order.Model;

namespace NLC.Order.SqlServerDAL
{
    public class MenuSqlServerDAL : IMenuDAL
    {
        public bool DelMenu(int menuId)
        {
            throw new NotImplementedException();
        }

        public bool InsertMenu(MenuInfo menu)
        {
            throw new NotImplementedException();
        }

        public List<MenuInfo> SelectMenuByRestaurant(int restaurantId)
        {
            throw new NotImplementedException();
        }
    }
}