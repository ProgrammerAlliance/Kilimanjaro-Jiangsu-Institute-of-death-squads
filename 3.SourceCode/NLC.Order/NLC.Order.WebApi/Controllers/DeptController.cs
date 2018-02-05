using Newtonsoft.Json;
using NLC.Order.BLL;
using NLC.Order.Common;
using NLC.Order.IBLL;
using NLC.Order.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NLC.Order.WebApi.Controllers
{
    public class DeptController : ApiController
    {
        /// <summary>
        /// DeptBLL对象
        /// </summary>
        private IDeptBLL deptBLL = new DeptBLL();

        /// <summary>
        /// 获取所有部门信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetAllDept()
        {
            return deptBLL.GetAllDept();
        }
    }
}
