using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Domain.Repositories.EntityFramework.ModelConfig
{
    internal class ActionConfig : BaseConfig<Wings.Domain.Model.Action>
    {
        public ActionConfig()
            : base()
        {
            Property(w => w.Controller).IsRequired().HasMaxLength(50);
            Property(w => w.ActionName).IsRequired().HasMaxLength(50);
            Property(w => w.Description).IsRequired().HasMaxLength(50);
            Property(w => w.IsButton).IsRequired();
            Property(w => w.IsActivate).IsRequired();
            Property(w => w.Controller).IsRequired().HasMaxLength(50);
        }
    }
}
