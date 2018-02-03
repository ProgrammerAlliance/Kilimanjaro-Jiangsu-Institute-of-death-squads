using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLC.Order.Model
{
    class MenuInfo
    {
        /// <summary>
        /// 菜编号
        /// </summary>
        public int DishNumber { get; set; }

        /// <summary>
        /// 菜名
        /// </summary>
        public int DishName { get; set; }

        /// <summary>
        /// 菜图片路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public int Price { get; set; }
    }
}
