using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Domain.Model
{
    /// <summary>
    /// 标示站点用户 角色领域的实体
    /// </summary>
    public class WebUserRole:AggregateRoot
    {
        /// <summary>
        /// 获取或设置站点用户
        /// </summary>
        public virtual WebUser webuser { get;set; }
        /// <summary>
        /// 角色
        /// </summary>
        public virtual Role role { get; set; }
        /// <summary>
        /// 站点用户标示
        /// </summary>
        public Guid WebUserID { get; set; }
        /// <summary>
        /// 角色id
        /// </summary>
        public Guid RoleID { get; set; }
    }
}
