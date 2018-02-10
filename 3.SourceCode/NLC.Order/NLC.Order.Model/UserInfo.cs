namespace NLC.Order.Model
{
    public class UserInfo
    {
        /// <summary>
        /// 员工编号
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPwd { get; set; }

        /// <summary>
        /// 部门号
        /// </summary>
        public int Deptno { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DeptName { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        public int UserType { get; set; }

        /// <summary>
        /// 用户类型名字
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// 用户今日是否订餐
        /// </summary>
        public bool IsOrder { get; set; }

        /// <summary>
        /// 重复密码
        /// </summary>
        public string RepeatPassword { get; set; }
    }
}
