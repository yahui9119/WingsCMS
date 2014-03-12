using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;

namespace Wings.Domain.Repositories.EntityFramework.ModelConfig
{
    internal class GroupConfig : BaseConfig<Group>
    {
        public GroupConfig()
            : base()
        {
            Property(g => g.Name).IsRequired().HasMaxLength(50);
            Property(g => g.Description).IsRequired().HasMaxLength(200);
        }
    }
}
