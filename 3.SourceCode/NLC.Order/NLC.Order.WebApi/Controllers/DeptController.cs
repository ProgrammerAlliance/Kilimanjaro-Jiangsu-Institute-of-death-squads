using NLC.Order.BLL;
using NLC.Order.Common;
using NLC.Order.IBLL;
using System.Web.Http;

namespace NLC.Order.WebApi.Controllers
{
    public class DeptController : ApiController
    {
        /// <summary>
        /// DeptBLL对象
        /// </summary>
        private IDeptBLL DeptBLL = new DeptBLL();

        /// <summary>
        /// 获取所有部门信息
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAllDept()
        {
            return DeptBLL.GetAllDept();
        }
    }
}
