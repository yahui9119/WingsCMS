using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Framework.Events.Bus;

namespace Wings.Domain.Events.Handlers
{
    class UserUpdateModuleEventHandler : IDomainEventHandler<UserUpdateModuleEvent>
    {
        private readonly IEventBus bus;
        public void Handle(UserUpdateModuleEvent evnt)
        {
            
            bus.Publish<UserUpdateModuleEvent>(evnt);
        }
    }
}
