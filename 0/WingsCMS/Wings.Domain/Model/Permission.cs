using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Domain.Model
{
    /// <summary>
    /// 标示权限的领域的实体
    /// </summary>
    public class Permission : AggregateRoot
    {
        /// <summary>
        /// 此权限类型
        /// </summary>
        public PermissionType Type { get; set; }
        /// <summary>
        /// 所有者的Id
        /// </summary>
        public Guid Own { get; set; }
        /// <summary>
        /// 模块
        /// </summary>
        public List<Module> Modules { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 简介说明
        /// </summary>
        public string Description { get; set; }
        ///// <summary>
        ///// 模块ID
        ///// </summary>
        //public Guid ModuleID { get; set; }
        ///// <summary>
        ///// 站点用户分组标示
        ///// </summary>
        //public Guid WebUserGroupID { get; set; }
        ///// <summary>
        ///// 站点用户角色标示
        ///// </summary>
        //public Guid WebUserRoleID { get; set; }
        /// <summary>
        /// 是否授权 为False 对单个用户启用控制
        /// </summary>
        public bool IsAuthorization { get; set; }
    }
    /// <summary>
    /// 权限类型
    /// </summary>
    public enum PermissionType : int
    {
        /// <summary>
        /// 无效数据类型
        /// </summary>
        None=0,
        /// <summary>
        /// 角色权限
        /// </summary>
        Role = 1,
        /// <summary>
        /// 用户组权限
        /// </summary>
        GroupUser = 2,
        /// <summary>
        /// 用户权限
        /// </summary>
        User = 3
    }
    ///// <summary>
    ///// 请求类型
    ///// </summary>
    //public enum OptionType : int
    //{
    //    GET=1,
    //    POST=2,
    //    PUT=3,
    //    DELETE=4
    //}
}
