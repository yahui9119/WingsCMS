using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Domain.Model
{
    /// <summary>
    /// 标示分组的领域的实体
    /// </summary>
    public class Group : AggregateRoot
    {
        /// <summary>
        /// 分组名字
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 简介说明
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 父分组的标示
        /// </summary>
        public Guid PID { get; set; }
    }
}
