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
        JsonResult AddDishes(MenuInfo menu);

        JsonResult DelDishes(int DishesId);

        JsonResult ModifyDishes(MenuInfo menu);

        JsonResult GetAllMenu();
    }
}
