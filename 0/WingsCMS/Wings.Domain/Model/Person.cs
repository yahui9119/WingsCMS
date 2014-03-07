using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Domain.Model
{
    /// <summary>
    /// 人
    /// </summary>
    public class Person:AggregateRoot
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        public Guid CatId { get; set; }
    }
}
