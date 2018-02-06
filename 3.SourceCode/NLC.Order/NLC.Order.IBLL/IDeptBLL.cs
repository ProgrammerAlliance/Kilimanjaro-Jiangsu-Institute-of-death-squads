using NLC.Order.Common;
using NLC.Order.Model;

namespace NLC.Order.IBLL
{
    public interface IDeptBLL
    {
        /// <summary>
        /// 查询所有部门
        /// </summary>
        /// <returns></returns>
        JsonResult GetAllDept();
    }
}
