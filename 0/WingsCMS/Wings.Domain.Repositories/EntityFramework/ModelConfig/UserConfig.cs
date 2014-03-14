﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Wings.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wings.Domain.Repositories.EntityFramework.ModelConfig
{
    internal class UserConfig : BaseConfig<User>
    {
        public UserConfig()
            : base()
        {
            Property(u => u.Account).IsRequired().HasMaxLength(50);
            Property(u => u.Email).IsRequired().HasMaxLength(50);
            Property(u => u.Password).IsRequired().HasMaxLength(50);
            Property(u => u.Email).IsRequired().HasMaxLength(50);
            Property(u => u.PhoneNum).IsRequired().HasMaxLength(11);
            Property(u => u.Zip).IsRequired().HasMaxLength(20);
            Property(u => u.QQ).HasMaxLength(50);
            Property(u => u.ALiWangWang).HasMaxLength(50);
            Property(u => u.Address).IsRequired().HasMaxLength(200);
            Property(u => u.LastloginTime).IsRequired();
        }
    }
}