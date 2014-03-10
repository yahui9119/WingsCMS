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
    public class WebUserGroup : AggregateRoot
    {
        /// <summary>
        /// 站点用户
        /// </summary>
        public virtual WebUser webuser { get; set; }
        /// <summary>
        /// 用户的分组
        /// </summary>
        public virtual List<Group> groups { get; set; }
        /// <summary>
        /// 站点用户标示
        /// </summary>
        public Guid WebUserID { get; set; }
        /// <summary>
        /// 分组id
        /// </summary>
        public Guid GroupID { get; set; }
    }
}
