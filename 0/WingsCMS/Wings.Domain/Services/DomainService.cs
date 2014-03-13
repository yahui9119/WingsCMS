using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wings.Domain.Model;
using Wings.Domain.Repositories;
using Wings.Domain.Specifications;

namespace Wings.Domain.Services
{
    public class DomainService : IDomainService
    {
        private readonly IRepositoryContext repositoryContext;
        private readonly IUserGroupRepository usergroupRepository;
        private readonly IUserRoleRepository userroleRepository;
        private readonly IUserRepository userRepository;
        private readonly IWebRepository webRepository;
        private readonly IWebUserRepository webuserRepository;
        private readonly IGroupRepository groupRepository;
        private readonly IModuleRepository moduleRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IWebModuleRepositoty webmoduleRepository;
          
        public DomainService(IRepositoryContext repositoryContext,
          IUserGroupRepository iusergroupRepository,
        IUserRoleRepository iuserroleRepository,
            IRoleRepository roleRepository,
        IUserRepository iuserRepository,
        IWebRepository iwebRepository,
        IWebUserRepository iwebuserRepository,
        IGroupRepository igroupRepository,
        IModuleRepository imoduleRepository,
            IWebModuleRepositoty webmoduleRepository)
        {
            this.groupRepository = igroupRepository;
            this.moduleRepository = imoduleRepository;
            this.usergroupRepository = iusergroupRepository;
            this.userRepository = iuserRepository;
            this.userroleRepository = iuserroleRepository;
            this.webRepository = iwebRepository;
            this.webuserRepository = iwebuserRepository;
            this.repositoryContext = repositoryContext;
            this.roleRepository = roleRepository;
            this.webmoduleRepository = webmoduleRepository;
        }

        public Model.UserRole AssignUserRole(Model.User user, List<Role> roles)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            if (roles == null)
            {
                throw new ArgumentNullException("roles");
            }
            var userroles = userroleRepository.Find(Specification<UserRole>.Eval(ur => ur.user.ID.Equals(user.ID)));
            //数据修正
            roles = roleRepository.FindAll(Specification<Role>.Eval(r => roles.Contains(r))).ToList();
            user = userRepository.Find(Specification<User>.Eval(u => u.ID.Equals(user.ID)));
            UserRole entity = new UserRole();
            if (userroles != null)
            {
                userroleRepository.Remove(userroles);
                entity.user = user;
                entity.roles = roles;
                userroleRepository.Add(entity);
            }
            entity.user = user;
            entity.roles = roles;
            userroleRepository.Add(entity);
            repositoryContext.Commit();
            return entity;
        }

        public Model.WebUser AssignUserWeb(Model.User user, List<Model.Web> webs)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            if (webs == null)
            {
                throw new ArgumentNullException("webs");
            }
            var userwebs = webuserRepository.Find(Specification<WebUser>.Eval(ur => ur.user.ID.Equals(user.ID)));
            //数据修正
            webs = webRepository.FindAll(Specification<Web>.Eval(r => webs.Contains(r))).ToList();
            user = userRepository.Find(Specification<User>.Eval(u => u.ID.Equals(user.ID)));
            WebUser entity = new WebUser();
            if (userwebs != null)
            {
                webuserRepository.Remove(userwebs);
                entity.user = user;
                entity.webs = webs;
                webuserRepository.Add(entity);
                
            }

            entity.user = user;
            entity.webs = webs;
            webuserRepository.Add(entity);
            repositoryContext.Commit();
            return entity;
        }

        public Model.UserGroup AssignUserGroup(Model.User user, List<Model.Group> groups)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            if (groups == null)
            {
                throw new ArgumentNullException("groups");
            }
            var usergroups = usergroupRepository.Find(Specification<UserGroup>.Eval(ur => ur.user.ID.Equals(user.ID)));
            //数据修正
            groups = groupRepository.FindAll(Specification<Group>.Eval(r => groups.Contains(r))).ToList();
            user = userRepository.Find(Specification<User>.Eval(u => u.ID.Equals(user.ID)));
            UserGroup entity = new UserGroup();
            if (usergroups != null)
            {
                usergroupRepository.Remove(usergroups);
            }
            entity.user = user;
            entity.groups = groups;
            usergroupRepository.Add(entity);
            repositoryContext.Commit();
            return entity;
        }

        public Model.WebModule AssignWebModule(Model.Web web, List<Model.Module> modules)
        {
            if (web == null)
            {
                throw new ArgumentNullException("web");
            }
            if (modules == null)
            {
                throw new ArgumentNullException("modules");
            }
            
            var webmodules = webmoduleRepository .Find(Specification<WebModule>.Eval(ur => ur.web.ID.Equals(web.ID)));
            //数据修正
            modules = moduleRepository.FindAll(Specification<Module>.Eval(r => modules.Contains(r))).ToList();
            web = webRepository.Find(Specification<Web>.Eval(u => u.ID.Equals(web.ID)));
            WebModule entity = new WebModule();
            if (webmodules != null)
            {
                webmoduleRepository.Remove(webmodules);
            }
            entity.web = web;
            entity.Modules = modules;
            webmoduleRepository.Add(entity);
            repositoryContext.Commit();
            return entity;
        }


        public Permission GrantRolePermission(Role role, List<Module> modules)
        {
            throw new NotImplementedException();
        }

        public Permission GrantGroupPermission(Group group, List<Module> modules)
        {
            throw new NotImplementedException();
        }

        public Permission AssignUserAllowPermission(User user, List<Module> modules)
        {
            throw new NotImplementedException();
        }

        public Permission AssignUserBanPermission(User user, List<Module> modules)
        {
            throw new NotImplementedException();
        }
    }
}
