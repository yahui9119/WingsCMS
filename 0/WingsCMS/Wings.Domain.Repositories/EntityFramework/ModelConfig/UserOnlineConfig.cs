using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;

namespace Wings.Domain.Repositories.EntityFramework.ModelConfig
{
    internal class UserOnlineConfig:BaseConfig<UserOnline>
    {
        public UserOnlineConfig()
            : base()
        {
            Property(u => u.IsOnline).IsRequired();
            HasRequired(uo => uo.user).WithRequiredDependent().Map(u => u.MapKey("UserID"));
            HasRequired(w => w.web).WithRequiredDependent().Map(w => w.MapKey("WebID"));
        }
    }
}
