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
            //Property(m => m.IsActive).IsRequired();
            HasMany(m => m.ChildModule).WithOptional(m => m.ParentModule).Map(m => m.MapKey("ParentID"));//自关联 
            HasOptional(m => m.Action).WithOptionalDependent().Map(m => m.MapKey("ActionID"));//一对一关联
        }

    }
}
