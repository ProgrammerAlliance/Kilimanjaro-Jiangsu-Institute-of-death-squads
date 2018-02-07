using System.Collections.Generic;

namespace NLC.Order.Common
{
    public class Page<T>
    {
        /// <summary>
        /// 记录每页展现多少条数据
        /// </summary>
        public int PageRecord { get; set; }

        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPage { get; set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalRecord { get; set; }

        /// <summary>
        /// 查询的对象集合
        /// </summary>
        public List<T> ObjectList { get; set; }
    }
}
