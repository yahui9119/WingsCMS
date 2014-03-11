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
    public class UserRole:AggregateRoot
    {

        /// <summary>
        /// 获取或设置站点用户
        /// </summary>
        public virtual User user { get;set; }
        /// <summary>
        /// 角色
        /// </summary>
        public virtual List<Role> roles { get; set; }
    }
}
