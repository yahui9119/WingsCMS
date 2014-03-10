using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Domain.Model
{
    /// <summary>
    /// 标示站点和用户对应关系的领域实体
    /// </summary>
    public class WebUser:AggregateRoot
    {
        /// <summary>
        /// 获取或设置拥有站点的用户实体
        /// </summary>
        public virtual User user { get; set; }
        /// <summary>
        /// 获取或设置该所有的站点
        /// </summary>
        public virtual List<Web> webs { get; set; }
        /// <summary>
        /// 站点标识
        /// </summary>
        public Guid WebID { get; set; }
        /// <summary>
        /// 用户标识
        /// </summary>
        public Guid UserID { get; set; }
    }
}
