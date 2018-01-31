using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NLC.Order.Common
{
    public class JsonResult
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 结果
        /// </summary>
        public object Result { get; set; }
    }
}