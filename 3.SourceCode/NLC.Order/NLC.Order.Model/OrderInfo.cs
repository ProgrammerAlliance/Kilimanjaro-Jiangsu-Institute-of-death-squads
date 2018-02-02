using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLC.Order.Model
{
    public class OrderInfo
    {
        /// <summary>
        /// 订餐号
        /// </summary>
        public int OrderNo { get; set; }

        /// <summary>
        /// 员工编号
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 点餐时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 打扫人员
        /// </summary>
        public int Clean { get; set; }

        /// <summary>
        /// 点餐备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 部门名
        /// </summary>
        public string DeptName { get; set; }

    }
}
