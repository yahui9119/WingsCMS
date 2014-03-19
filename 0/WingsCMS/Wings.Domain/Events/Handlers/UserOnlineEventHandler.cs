using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Events.Bus;

namespace Wings.Domain.Events.Handlers
{
    public class UserOnlineEventHandler : IDomainEventHandler<UserOnlineEvent>
    {
        private readonly IEventBus bus;
        public void Handle(UserOnlineEvent evnt)
        {
            bus.Publish<UserOnlineEvent>(evnt);
        }
    }
}
