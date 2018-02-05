using NLC.Order.Model;
using System.Collections.Generic;

namespace NLC.Order.IDAL
{
    public interface IDeptDAL
    {
        /// <summary>
        /// 查找所有部门
        /// </summary>
        /// <returns></returns>
        List<DeptInfo> SelectAllUser();

    }
}
