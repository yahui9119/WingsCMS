using Omu.Encrypto;
using Wings.Core.Model;
using Wings.Core.Security;
using Wings.Core.Service;
using Wings.Infra;
using Wings.Service;
using Wings.UI.Dto;
using Wings.UI.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wings.UI
{
    public class WindsorConfigurator
    {
        public static void Configure()
        {
            WindsorRegistrar.Register(typeof(IFormsAuthentication), typeof(FormAuthService));
            WindsorRegistrar.Register(typeof(IHasher), typeof(Hasher));
            WindsorRegistrar.Register(typeof(IMapper<Dinner, DinnerInput>), typeof(DinnerMapper));
            WindsorRegistrar.Register(typeof(IUserService), typeof(UserService));
            WindsorRegistrar.Register(typeof(IMealService), typeof(MealService));

            WindsorRegistrar.RegisterAllFromAssemblies("Wings.Data");
            WindsorRegistrar.RegisterAllFromAssemblies("Wings.Service");
            WindsorRegistrar.RegisterAllFromAssemblies("Wings.Infra");
            WindsorRegistrar.RegisterAllFromAssemblies("Wings.UI");
        }
    }
}