using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Domain.Model
{
    /// <summary>
    /// 标示角色领域的实体
    /// </summary>
    public class Role:AggregateRoot
    {
        /// <summary>
        /// 角色名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 简介说明
        /// </summary>
        public string Description { get; set; }
    }
}
