using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Domain.Model
{
    /// <summary>
    /// 猫
    /// </summary>
    public class Cat : AggregateRoot
    {
        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; }
    }
}
