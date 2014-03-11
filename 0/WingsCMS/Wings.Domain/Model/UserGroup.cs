using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Domain.Model
{
    /// <summary>
    /// 标示标示站点用户分组的领域实体
    /// </summary>
    public class UserGroup : AggregateRoot
    {
        /// <summary>
        /// 用户
        /// </summary>
        public virtual User user { get; set; }
        /// <summary>
        /// 用户的分组
        /// </summary>
        public virtual List<Group> groups { get; set; }
    }
}
