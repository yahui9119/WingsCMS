using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;

namespace Wings.Domain.Repositories.EntityFramework.ModelConfig
{
    internal class PermissionConfig:BaseConfig<Permission>
    {
        public PermissionConfig()
            : base()
        {
            Property(p => p.Type).IsRequired();
            Property(p => p.OwnID).IsRequired();
            Property(p => p.IsAuthorization).IsRequired();
        }
    }
}
