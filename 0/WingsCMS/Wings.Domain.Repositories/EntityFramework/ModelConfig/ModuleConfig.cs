using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;

namespace Wings.Domain.Repositories.EntityFramework.ModelConfig
{
    internal class ModuleConfig : BaseConfig<Module>
    {
        public ModuleConfig()
            : base()
        {
            Property(m => m.Name).IsRequired().HasMaxLength(50);
            Property(m => m.Description).IsRequired().HasMaxLength(200);
            Property(m => m.ICON).IsRequired().HasMaxLength(100);
            Property(m => m.Url).IsRequired().HasMaxLength(100);
            Property(m => m.Index).IsRequired();
            Property(m => m.IsMenus).IsRequired();
            Property(m => m.IsActive).IsRequired();
        }

    }
}
