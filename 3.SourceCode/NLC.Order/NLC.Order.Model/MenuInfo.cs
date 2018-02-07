namespace NLC.Order.Model
{
    public class MenuInfo
    {
        /// <summary>
        /// 饭店编号
        /// </summary>
        public int RestaurantId { get; set; }

        /// <summary>
        /// 菜编号
        /// </summary>
        public int FoodId { get; set; }

        /// <summary>
        /// 菜名
        /// </summary>
        public string FoodName { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public int Price { get; set; }
    }
}
