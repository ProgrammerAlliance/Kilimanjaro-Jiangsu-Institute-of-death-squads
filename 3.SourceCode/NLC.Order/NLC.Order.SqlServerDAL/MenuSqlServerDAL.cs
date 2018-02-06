using System;
using System.Collections.Generic;
using NLC.Order.IDAL;
using NLC.Order.Model;
using System.Data.SqlClient;
using NLC.Order.DBUtility;
using NL.Order.Common;
using System.Data;

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
            int result = 0;
            try
            {
                string sql = "delete from Menu where MenuId=@MenuId";
                SqlParameter[] parameters =
                {
                new SqlParameter("MenuId",menuId)
            };
                result = DBHelper.NonQuery(sql, parameters);
            }
            catch (Exception)
            {
                LogHelper.WriteLogFile("执行删除菜单SQL语句失败");
            }
            return result > 0 ? true : false;
        }

        /// <summary>
        /// 插入菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public bool InsertMenu(MenuInfo menu)
        {
            int result = 0;
            try
            {
                string sql = @"insert into Menu
                           (FoodId,RestaurantId,FoodName,Price)
                           values(@FoodId,@RestaurantId,@FoodName,@Price)";
                SqlParameter[] parameters =
                {
                new SqlParameter("FoodId",menu.FoodId),
                new SqlParameter("RestaurantId",menu.RestaurantId),
                new SqlParameter("FoodName",menu.FoodName),
                new SqlParameter("Price",menu.Price)
            };
                result = DBHelper.NonQuery(sql, parameters);
            }
            catch (Exception)
            {
                LogHelper.WriteLogFile("执行删除用户SQL语句失败");
            }
            return result > 0 ? true : false;
        }

        /// <summary>
        /// 查找所有饭店
        /// </summary>
        /// <returns></returns>
        public List<RestaurInfo> SelectAllRestaurant()
        {
            DataSet ds = null;
            try
            {
                string sql = @"SELECT *
                           FROM [Order].[dbo].[Restaurant]";
                ds = DBHelper.Query(sql, null);
            }
            catch (Exception)
            {
                LogHelper.WriteLogFile("执行删除用户SQL语句失败");
            }
            return DBHelper.GetListbyDataSet<RestaurInfo>(ds);
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