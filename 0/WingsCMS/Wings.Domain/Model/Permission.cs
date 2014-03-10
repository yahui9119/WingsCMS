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
        /// 用户
        /// </summary>
        public virtual User user { get; set; }
        /// <summary>
        /// 站点用户分组
        /// </summary>
        public virtual List<WebUserGroup> webusergroups { get; set; }
        /// <summary>
        /// 站点用户角色
        /// </summary>
        public virtual List<WebUserRole> webuserroles { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 简介说明
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 模块ID
        /// </summary>
        public Guid ModuleID { get; set; }
        /// <summary>
        /// 站点用户分组标示
        /// </summary>
        public Guid WebUserGroupID { get; set; }
        /// <summary>
        /// 站点用户角色标示
        /// </summary>
        public Guid WebUserRoleID { get; set; }

    }
}
