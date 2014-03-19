using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Domain.Events
{
    /// <summary>
    /// 用户下线事件
    /// </summary>
    public class UserOfflineEvent:DomainEvent
    {
        public UserOfflineEvent() { }
        public UserOfflineEvent(IEntity entity) : base(entity) { }
    }
}
