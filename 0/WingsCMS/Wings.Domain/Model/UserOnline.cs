using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Domain.Model
{
    /// <summary>
    /// 标示用户在线领域的实体
    /// </summary>
    public class UserOnline:AggregateRoot
    {
        /// <summary>
        /// 在线的用户
        /// </summary>
        public User user { get; set; }
        /// <summary>
        /// 已经在线的时间
        /// </summary>
        public DateTime OnlineTime { get; set; }
        /// <summary>
        /// 当前是否在线
        /// </summary>
        public bool IsOnline { get; set; }
    }
}
