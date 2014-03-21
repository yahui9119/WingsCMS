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
        /// <summary>
        /// 新安装一个站点 一般在调试该站点的时候使用
        /// </summary>
        /// <param name="web"></param>
        public WebDTO InstallPlugin(WebDTO webdto)
        {
            Web web = Mapper.Map<WebDTO, Web>(webdto);
            webRepository.Add(web);
            Context.Commit();
            return Mapper.Map<Web, WebDTO>(web);
        }

        public WebDTO UpdatePlugin(DataObjects.WebDTO webdto)
        {
            Web web = Mapper.Map<WebDTO, Web>(webdto);
            webRepository.Update(web);
            Context.Commit();
            return Mapper.Map<Web, WebDTO>(web);
        }

        public void UnstallPlugin(DataObjects.WebDTO webdto)
        {
            Web web = webRepository.GetByKey(Guid.Parse(webdto.ID));
            web.Status = Wings.Domain.Model.Status.Deleted;
            webRepository.Update(web);
            Context.Commit();
        }
    }
}
