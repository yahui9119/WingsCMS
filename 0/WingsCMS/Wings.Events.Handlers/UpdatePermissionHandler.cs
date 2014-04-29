using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Events;
using Wings.Framework.Events;

namespace Wings.Events.Handlers
{
    [HandlesAsynchronously]
    public class UpdatePermissionHandler : IEventHandler<UserUpdatePermissionEvent>
    {
        public void Handle(UserUpdatePermissionEvent evnt)
        {
            Console.WriteLine("");
        }
    }
}
