using System;
using System.Collections.Generic;
using NLC.Order.IDAL;
using NLC.Order.Model;
using System.Data.SqlClient;
using NLC.Order.DBUtility;
using NLC.Order.Common;
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
                string sql = "delete from Menu where FoodId=@FoodId";
                SqlParameter[] parameters =
                {
                    new SqlParameter("FoodId",menuId)
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
                           (RestaurantId,FoodName,Price)
                           values(@RestaurantId,@FoodName,@Price)";
                SqlParameter[] parameters =
                {
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
            DataSet data = null;
            try
            {
                string sql = "select m.FoodId,m.FoodName,m.Price " +
                    "from Menu m,Restaurant r " +
                    "where m.RestaurantId = r.RestaurantId and r.RestaurantId=@RestaurantId";
                SqlParameter[] parameters =
                {
                    new SqlParameter("RestaurantId",restaurantId)
                };
                data = DBHelper.Query(sql, parameters);
            }
            catch (Exception)
            {
                LogHelper.WriteLogFile("执行根据饭店查找所有菜单SQL语句失败");
            }
            return DBHelper.GetListbyDataSet<MenuInfo>(data);
        }

        /// <summary>
        /// 根据菜品名称和饭店查找菜品
        /// </summary>
        /// <param name="foodName"></param>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        public bool SelectMenuByNameAndRestaurant(string foodName, int restaurantId)
        {
            DataSet data = null;
            try
            {
                string sql = "select FoodId,FoodName,Price " +
                    "from Menu " +
                    "where FoodName = @FoodName and RestaurantId=@RestaurantId";
                SqlParameter[] parameters =
                {
                    new SqlParameter("FoodName",foodName),
                    new SqlParameter("RestaurantId",restaurantId)
                };
                data = DBHelper.Query(sql, parameters);
            }
            catch (Exception)
            {
                LogHelper.WriteLogFile("执行根据菜品名称和饭店查找菜品SQL语句失败");
            }
            return data.Tables[0].Rows.Count == 0 ? false : true;
        }
    }
}