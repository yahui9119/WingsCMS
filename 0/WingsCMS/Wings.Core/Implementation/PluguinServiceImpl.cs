﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Contracts;
using Wings.DataObjects;
using Wings.Domain.Model;
using Wings.Domain.Repositories;
using Wings.Domain.Specifications;
using Wings.Events.Bus;
using Wings.Framework.Plugin.Contracts;

namespace Wings.Core.Implementation
{
    public class PluginServiceImpl : CoreService, IPluginService
    {
        //private readonly IUserRepository userRepository;
        private readonly IActionRepository actionRepository;

        //private readonly IRoleRepository roleRepository;
        //private readonly IGroupRepository groupRespository;
        //private readonly IModuleRepository moduleRepository;
        private readonly IWebRepository webRepository;
        private readonly IEventBus bus;
        public PluginServiceImpl(IRepositoryContext context,
            IActionRepository actionRepository,
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
            this.actionRepository = actionRepository;
            this.bus = bus;
        }




        Guid IPluginService.Login(string account, string password, Guid webid)
        {
            return Guid.Empty;
        }

        public List<Permission> GetPermissionByUserID(Guid accountid, Guid webid, bool IsAdmin = false)
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
            var actions = actionRepository.GetAll(Specification<Wings.Domain.Model.Action>.Eval(a => a.web.ID.Equals(webid)));
            permission.ForEach(p =>
            {
                var action =actions!=null?actions.Where(a => a.ActionName == p.Action && a.Controller == p.Controller && a.IsButton == p.IsPost).FirstOrDefault():null;
                if (action == null)
                {
                    action=Mapper.Map<Permission, Wings.Domain.Model.Action>(p);
                    action.CreateDate = DateTime.Now;
                    action.EditDate = DateTime.Now;
                    action.Status = Wings.Domain.Model.Status.Active;
                    action.web = webRepository.Get(Specification<Web>.Eval(w => w.ID.Equals(webid)));
                    actionRepository.Add(action);
                }
                else
                {
                    action.EditDate = DateTime.Now;
                    action.Status = Wings.Domain.Model.Status.Active;
                    action.Description = p.Description;
                    actionRepository.Update(action);
                }
            });

            Context.Commit();
        }
    }
}
