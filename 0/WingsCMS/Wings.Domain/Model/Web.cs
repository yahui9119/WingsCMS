using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Domain.Model
{
    /// <summary>
    /// 表示站点领域的值的对象
    /// </summary>
    public class Web : AggregateRoot
    {
        /// <summary>
        /// 站点名字
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 简介说明
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 域名
        /// </summary>
        public string Domain { get; set; }
    }
}
