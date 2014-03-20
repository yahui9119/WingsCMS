using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Contracts;
using Wings.Domain.Repositories;
using Wings.DataObjects;
using Wings.Domain.Model;
using AutoMapper;
using Wings.Domain.Specifications;
using Wings.Framework;
using Wings.Framework.Transactions;
using Wings.Events.Bus;

namespace Wings.Core.Implementation
{
    public class UserServiceImple : CoreService, IUserService
    {

        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IGroupRepository groupRespository;
        private readonly IModuleRepository moduleRepository;
        private readonly IWebRepository webRepository;
        private readonly IEventBus bus;
        public UserServiceImple(IRepositoryContext context,
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IGroupRepository groupRespository,
            IModuleRepository moduleReposiroty,
            IWebRepository webRepository,
            IEventBus bus)
            : base(context)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            this.groupRespository = groupRespository;
            this.moduleRepository = moduleReposiroty;
            this.webRepository = webRepository;
            this.bus = bus;
        }


        public bool CheckPassword(string UserName, string Password)
        {
            return userRepository.CheckPassword(UserName, Password);
        }

        public bool IsExistsAccount(string Account)
        {
            return userRepository.IsExistsAccount(Account);
        }

        public UserDTOList CreateUser(UserDTOList user)
        {
            return PerformCreateObjects<UserDTOList, UserDTO, User>(user, userRepository);
        }
        /// <summary>
        /// 修改用户的个人信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserDTOList EidtUser(UserDTOList user)
        {
            return PerformUpdateObjects<UserDTOList, UserDTO, User>(user, userRepository, uto => uto.ID, (u, uto) =>
            {
                if (!string.IsNullOrEmpty(uto.Account))
                {
                    u.Account = uto.Account;
                }
                if (!string.IsNullOrEmpty(uto.Address))
                {
                    u.Address = uto.Address;
                }
                if (!string.IsNullOrEmpty(uto.ALiWangWang))
                {
                    u.ALiWangWang = uto.ALiWangWang;
                }
                if (uto.Birthday != null)
                {

                    u.Birthday = uto.Birthday;

                }
                u.EditDate = DateTime.Now;
                if (!string.IsNullOrEmpty(uto.Email))
                {
                    u.Email = uto.Email;
                }
                if (!uto.IsMan)
                {
                    u.IsMan = uto.IsMan;
                }
                if (!string.IsNullOrEmpty(uto.Password))
                {
                    u.Password = uto.Password;
                }
                if (!string.IsNullOrEmpty(uto.PhoneNum))
                {
                    u.PhoneNum = uto.PhoneNum;
                }
                if (!string.IsNullOrEmpty(uto.QQ))
                {
                    u.QQ = uto.QQ;
                }
                if (!string.IsNullOrEmpty(uto.RealName))
                {
                    u.RealName = uto.RealName;
                }
                if (uto.Version != null)
                {
                    u.Version = uto.Version;
                }
                if (!string.IsNullOrEmpty(uto.Zip))
                {
                    u.Zip = uto.Zip;
                }
            });
        }
        /// <summary>
        /// 批量删除用户
        /// </summary>
        /// <param name="UserIDs"></param>
        public void DeleteUser(UserDTOList Users)
        {
            PerformUpdateObjects<UserDTOList, UserDTO, User>(Users, userRepository, uto => uto.ID, (u, uto) =>
            {
                u.Status = Wings.Domain.Model.Status.Deleted;
            });
        }
        /// <summary>
        /// 通过id获取单个用户
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public UserDTO GetUserByID(Guid UserID)
        {
            return Mapper.Map<User, UserDTO>(userRepository.GetByKey(UserID));
        }
        /// <summary>
        /// 根据分页获取用户信息
        /// </summary>
        /// <param name="pagination">用户的创建时间筛选</param>
        /// <returns></returns>
        public DataObjectListWithPagination<UserDTOList> GetUsersByPage(Pagination pagination)
        {

            Specification<User> starttime = Specification<User>.Eval(u => pagination.StartTime != null ? u.CreateDate < pagination.StartTime : true);
            Specification<User> endtime = Specification<User>.Eval(u => pagination.EndTime != null ? u.CreateDate > pagination.EndTime : true);
            Specification<User> likeword = Specification<User>.Eval(u => (string.IsNullOrEmpty(pagination.LikeWord) ? u.RealName.Contains(pagination.LikeWord) : true));
            PagedResult<User> userpages = userRepository.GetAll(starttime.And(endtime).And(likeword), u => u.CreateDate, SortOrder.Descending, pagination.PageNumber, pagination.PageSize);
            DataObjectListWithPagination<UserDTOList> result = new DataObjectListWithPagination<UserDTOList>();
            if (userpages.Data != null)
            {
                userpages.Data.ForEach(u =>
                {
                    result.DataObjectList.Add(Mapper.Map<User, UserDTO>(u));
                });
            }
            else { result.DataObjectList = new UserDTOList(); }
            result.pagination.PageNumber = userpages.PageNumber;
            result.pagination.PageSize = userpages.PageSize;
            result.pagination.TotalPages = userpages.TotalPages;
            result.pagination.TotalRecords = userpages.TotalRecords;
            return result;
        }
        /// <summary>
        /// 获取用户选择已经拥有的权限
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public ModuleDTOList GetUserPermission(Guid UserID)
        {
            ModuleDTOList mdtolist = new ModuleDTOList();
            var user = userRepository.Find(Specification<User>.Eval(u => u.Status == Wings.Domain.Model.Status.Active).And(Specification<User>.Eval(u => u.ID.Equals(UserID))));
            if (user == null)
            {
                return null;
            }
            //添加用户组模块
            user.Groups.ForEach(g =>
            {
                if (g.Status.Equals(Wings.Domain.Model.Status.Active))
                {
                    g.Modules.ForEach(
                        m =>
                        {
                            mdtolist.Add(Mapper.Map<Module, ModuleDTO>(m));
                        });
                }
            });
            user.Roles.FindAll(t => t.Status == Wings.Domain.Model.Status.Active).ForEach(r =>
            {
                r.Modules.FindAll(m => m.Status == Wings.Domain.Model.Status.Active).ForEach(m =>
                {
                    mdtolist.Add(Mapper.Map<Module, ModuleDTO>(m));
                });
            });
            user.ModuleAllow.FindAll(m => m.Status == Wings.Domain.Model.Status.Active).ForEach(m =>
            {
                mdtolist.Add(Mapper.Map<Module, ModuleDTO>(m));
            });
            //去除重复项
            ModuleDTOList resultmdtolist = new ModuleDTOList();
            mdtolist.GroupBy(m => m.ID).ToList().ForEach(m =>
            {
                resultmdtolist.Add(mdtolist.Find(mt => mt.ID == m.Key));
            });
            //去除禁用的
            user.ModuleBan.FindAll(m => m.Status == Wings.Domain.Model.Status.Active).ForEach(m =>
            {
                if (resultmdtolist.Contains(Mapper.Map<Module, ModuleDTO>(m)))
                {
                    resultmdtolist.Remove(Mapper.Map<Module, ModuleDTO>(m));
                }
            });
            return resultmdtolist;
        }
        /// <summary>
        /// 授予用户权限
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="moduleids"></param>
        /// <param name="IsBan">是否禁用</param>
        /// <returns></returns>
        public UserDTO AssignUserPermission(Guid userid, IDList moduleids, bool IsBan)
        {
            List<Guid> mids = new List<Guid>();
            moduleids.ForEach(m =>
            {
                Guid id = new Guid();
                if (Guid.TryParse(m, out id))
                {
                    mids.Add(id);
                }

            });
            List<Module> modules = moduleRepository.FindAll(Specification<Module>.Eval(m => mids.Contains(m.ID))).ToList();
            var user = userRepository.Find(Specification<User>.Eval(u => u.ID.Equals(userid)));
            if (IsBan)//是否是禁用
            {
                user.ModuleBan = modules;
            }
            else
            {
                user.ModuleAllow = modules;
            }
            userRepository.Update(user);
            //调用用户权限跟新
            user.UpdateModule(IsBan);
            Context.Commit();//提交当前事务单元
            return Mapper.Map<User, UserDTO>(user);

        }

        public RoleDTOList CreateRole(RoleDTOList roles)
        {
            return PerformCreateObjects<RoleDTOList, RoleDTO, Role>(roles, roleRepository);
        }

        public RoleDTOList EditRole(RoleDTOList roles)
        {
            return PerformUpdateObjects<RoleDTOList, RoleDTO, Role>(roles, roleRepository, r => r.ID, (r, rdto) =>
            {
                r.Name = rdto.Name;
                r.Description = rdto.Description;
                r.EditDate = DateTime.Now;
            });
        }

        public void DeleteRole(RoleDTOList roles)
        {
            PerformUpdateObjects<RoleDTOList, RoleDTO, Role>(roles, roleRepository, r => r.ID, (r, rdto) =>
           {
               r.Status = Wings.Domain.Model.Status.Deleted;
           });
        }
        /// <summary>
        /// 获取此角色下的所有用户
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public UserDTOList GetUserListByRole(Guid roleid)
        {
            var role = roleRepository.Find(Specification<Role>.Eval(r => r.ID.Equals(roleid)));
            if (role == null)
            {
                return null;
            }
            List<User> users = role.Users;
            UserDTOList udtoList = new UserDTOList();
            users.ForEach(u =>
                {
                    if (u.Status == Wings.Domain.Model.Status.Active)//只获取有效数据
                    {
                        udtoList.Add(Mapper.Map<User, UserDTO>(u));
                    }
                });
            return udtoList;
        }
        /// <summary>
        /// 赋予角色权限
        /// </summary>
        /// <param name="roleid"></param>
        /// <param name="moduleids"></param>
        /// <returns></returns>
        public RoleDTO AssignRolePermission(Guid roleid, IDList moduleids)
        {
            List<Guid> mids = new List<Guid>();
            moduleids.ForEach(m =>
            {
                Guid id = new Guid();
                if (Guid.TryParse(m, out id))
                {
                    mids.Add(id);
                }

            });
            var role = roleRepository.Find(Specification<Role>.Eval(r => r.ID.Equals(roleid)));
            var modules = moduleRepository.GetAll(Specification<Module>.Eval(m => mids.Contains(m.ID))).ToList();
            role.Modules = modules;
            roleRepository.Update(role);
            Context.Commit();
            return Mapper.Map<Role, RoleDTO>(role);
        }

        public DataObjectListWithPagination<RoleDTOList> GetRolesByPage(Pagination pagination)
        {

            Specification<Role> starttime = Specification<Role>.Eval(u => pagination.StartTime != null ? u.CreateDate < pagination.StartTime : true);
            Specification<Role> endtime = Specification<Role>.Eval(u => pagination.EndTime != null ? u.CreateDate > pagination.EndTime : true);
            Specification<Role> likeword = Specification<Role>.Eval(u => (string.IsNullOrEmpty(pagination.LikeWord) ? u.Name.Contains(pagination.LikeWord) : true));

            PagedResult<Role> rolepages = roleRepository.GetAll(starttime.And(endtime).And(likeword), u => u.CreateDate, SortOrder.Descending, pagination.PageNumber, pagination.PageSize);
            DataObjectListWithPagination<RoleDTOList> result = new DataObjectListWithPagination<RoleDTOList>();
            if (rolepages.Data != null)
            {
                rolepages.Data.ForEach(u =>
                {
                    result.DataObjectList.Add(Mapper.Map<Role, RoleDTO>(u));
                });
            }
            else { result.DataObjectList = new RoleDTOList(); }
            result.pagination.PageNumber = rolepages.PageNumber;
            result.pagination.PageSize = rolepages.PageSize;
            result.pagination.TotalPages = rolepages.TotalPages;
            result.pagination.TotalRecords = rolepages.TotalRecords;
            return result;
        }

        public UserDTO AssignUserRole(Guid userid, IDList roleids)
        {
            List<Guid> rids = new List<Guid>();
            roleids.ForEach(m =>
            {
                Guid id = new Guid();
                if (Guid.TryParse(m, out id))
                {
                    rids.Add(id);
                }

            });
            var user = userRepository.Find(Specification<User>.Eval(u => u.ID.Equals(userid)));
            using (ITransactionCoordinator coordinator = TransactionCoordinatorFactory.Create(Context, bus))
            {

                if (user == null)
                {
                    throw new NullReferenceException("无法找指定的用户");
                }
                var roles = roleRepository.GetAll((Specification<Role>.Eval(r => rids.Contains(r.ID)))).ToList(); ;
                user.Roles = roles;
                userRepository.Update(user);
                user.UpdateRole();
                coordinator.Commit();
            }
            return Mapper.Map<User, UserDTO>(user);
        }

        /// <summary>
        /// 通过id获取单个角色
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public RoleDTO GetRoleByID(Guid roleid)
        {
            return Mapper.Map<Role, RoleDTO>(roleRepository.Get(Specification<Role>.Eval(r => r.ID.Equals(roleid))));
        }
        /// <summary>
        /// 获取所有的角色
        /// </summary>
        /// <returns></returns>
        public RoleDTOList GetAllRoles()
        {
            RoleDTOList roledtolist = new RoleDTOList();
            var roles = roleRepository.GetAll();
            roles.ToList().ForEach(r =>
            {
                roledtolist.Add(Mapper.Map<Role, RoleDTO>(r));
            });
            return roledtolist;
        }

        public UserDTO AssignUserGroup(Guid userid, IDList groupids)
        {

            List<Guid> gids = new List<Guid>();
            groupids.ForEach(m =>
            {
                Guid id = new Guid();
                if (Guid.TryParse(m, out id))
                {
                    gids.Add(id);
                }

            });
            var user = userRepository.Find(Specification<User>.Eval(u => u.ID.Equals(userid)));
            using (ITransactionCoordinator coordinator = TransactionCoordinatorFactory.Create(Context, bus))
            {

                if (user == null)
                {
                    throw new NullReferenceException("无法找指定的用户");
                }

                var groups = groupRespository.GetAll((Specification<Group>.Eval(g => gids.Contains(g.ID)))).ToList(); ;
                user.Groups = groups;
                userRepository.Update(user);
                user.UpdateGroup();
                coordinator.Commit();
            }
            return Mapper.Map<User, UserDTO>(user);
        }

        public GroupDTOList CreateGroup(GroupDTOList groups)
        {
            return PerformCreateObjects<GroupDTOList, GroupDTO, Group>(groups, groupRespository);
        }

        public GroupDTOList EditGroup(GroupDTOList groups)
        {
            return PerformUpdateObjects<GroupDTOList, GroupDTO, Group>(groups, groupRespository, g => g.ID, (g, gdto) =>
            {
                g.Name = gdto.Name;
                g.Description = gdto.Description;
                g.EditDate = DateTime.Now;
            });
        }

        public void DeleteGroup(GroupDTOList groups)
        {
            PerformUpdateObjects<GroupDTOList, GroupDTO, Group>(groups, groupRespository, g => g.ID, (g, gdto) =>
           {
               g.Status = Wings.Domain.Model.Status.Deleted;
           });
        }

        public void Dispose()
        {
            //销毁处理
        }
       
        /// <summary>
        /// 根据父id获取分组
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GroupDTOList GetGroupParentID(Guid id)
        {
            var groups = groupRespository.FindAll(Specification<Group>.Eval(g => g.ParentGroup.ID.Equals(id)));
            GroupDTOList gdtolist = new GroupDTOList();
            foreach (var item in groups)
            {
                gdtolist.Add(Mapper.Map<Group, GroupDTO>(item));
            }
            return gdtolist;
        }
        /// <summary>
        /// 根据分组id获取分组信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GroupDTO GetGroupByID(Guid id)
        {
            var group= groupRespository.Find(Specification<Group>.Eval(g => g.ID.Equals(id)));
            return Mapper.Map<Group, GroupDTO>(group);
        }
        /// <summary>
        /// 获取所有分组信息
        /// </summary>
        /// <returns></returns>
        public GroupDTOList GetAllGroups()
        {
            var groups = groupRespository.FindAll();
            GroupDTOList gdtolist = new GroupDTOList();
            foreach (var item in groups)
            {
                gdtolist.Add(Mapper.Map<Group, GroupDTO>(item));
            }
            return gdtolist;
        }
        /// <summary>
        /// 获取所有的有效站点模块
        /// </summary>
        /// <returns></returns>
        public WebDTOList GetAllWebModules()
        {
            var webs = webRepository.GetAll(Specification<Web>.Eval(w=>w.Status==Wings.Domain.Model.Status.Active));
            WebDTOList wdtolist=new WebDTOList ();
            foreach (var item in webs)
            {
                item.Modules.RemoveAll(m => m.Status != Wings.Domain.Model.Status.Active);
            }
            foreach (var item in webs)
	        {
                wdtolist.Add(Mapper.Map<Web, WebDTO>(item));
	        }
            return wdtolist;
        }


        public void DeleteUser(IDList UserIDs)
        {
            throw new NotImplementedException();
        }

        public void DeleteRole(IDList roleid)
        {
            throw new NotImplementedException();
        }
    }
}
