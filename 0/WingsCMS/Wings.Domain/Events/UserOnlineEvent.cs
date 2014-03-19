using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wings.Domain.Events
{
    /// <summary>
    /// 用户上线事件
    /// </summary>
    public class UserOnlineEvent:DomainEvent
    {
        public UserOnlineEvent() { }
        public UserOnlineEvent(IEntity entity) : base(entity) { }
    }
}
