﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;

namespace Wings.Domain.Repositories.EntityFramework.ModelConfig
{
    internal class WebConfig:BaseConfig<Web>
    {
        public WebConfig():base()
        {
            Property(w => w.Name).IsRequired().HasMaxLength(50);
            Property(w => w.Description).IsRequired().HasMaxLength(200);
            Property(w => w.Domain).IsRequired().HasMaxLength(50);
            HasMany(w => w.Modules).WithOptional().Map(w => w.MapKey("WebID"));
            HasMany(w => w.Users).WithMany(u => u.Webs).Map(uw =>
            {
                uw.MapLeftKey("UserID");
                uw.MapRightKey("WebID");
                uw.ToTable("UserWeb");
            });
        }
    }
}