using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Contracts;
using Wings.DataObjects;
using Wings.Domain.Model;
using Wings.Domain.Repositories;
using Wings.Events.Bus;
using Wings.Framework.Plugin.Contracts;

namespace Wings.Core.Implementation
{
    public class PluginServiceImpl : CoreService, IPluginService
    {
        //private readonly IUserRepository userRepository;
        //private readonly IActionRepository actionRepository;

        //private readonly IRoleRepository roleRepository;
        //private readonly IGroupRepository groupRespository;
        //private readonly IModuleRepository moduleRepository;
        private readonly IWebRepository webRepository;
        private readonly IEventBus bus;
        public PluginServiceImpl(IRepositoryContext context,
            //IActionRepository actionRepository,
            //IUserRepository userRepository,
            //IRoleRepository roleRepository,
            //IGroupRepository groupRespository,
            //IModuleRepository moduleReposiroty,
            IWebRepository webRepository,
            IEventBus bus)
            : base(context)
        {
            //this.userRepository = userRepository;
            //this.roleRepository = roleRepository;
            //this.groupRespository = groupRespository;
            //this.moduleRepository = moduleReposiroty;
            this.webRepository = webRepository;
            //this.actionRepository = actionRepository;
            this.bus = bus;
        }




        Guid IPluginService.Login(string account, string password, Guid webid)
        {
            return Guid.Empty;
        }

        public List<Permission> GetPermissionByUserID(Guid accountid, Guid webid)
        {
            return new List<Permission>();
        }

        public void LoginOut(Guid accountid, Guid webid)
        {
           
        }

        public void OnlineHeartbeat(Guid accountid, Guid webid)
        {
           
        }

        public void Init(Guid webid, List<Permission> permission)
        {
           
        }
    }
}
