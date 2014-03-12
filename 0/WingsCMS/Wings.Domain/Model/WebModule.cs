using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Domain.Model
{
    /// <summary>
    /// 标示站点模块领域的实体
    /// </summary>
    public class WebModule:AggregateRoot
    {
        /// <summary>
        /// 站点
        /// </summary>
        public Web web { get; set; }
        /// <summary>
        /// 该站点包含的模块
        /// </summary>
        public List<Module> Modules { get; set; }
    }
}
