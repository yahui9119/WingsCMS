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

namespace Wings.Core.Implementation
{
    public class UserServiceImple :CoreService, IUserService
    {

        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IGroupRepository groupRespository;
        private readonly IModuleRepository moduleRepository;
        private readonly IWebRepository webRepository;
        public UserServiceImple(IRepositoryContext context,
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IGroupRepository groupRespository,
            IModuleRepository moduleReposiroty,
            IWebRepository webRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            this.groupRespository = groupRespository;
            this.moduleRepository = moduleReposiroty;
            this.webRepository = webRepository;
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
            return PerformUpdateObjects<UserDTOList, UserDTO, User>(user, userRepository, uto => uto.ID, (u, uto) => {
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
                if (uto.Version!=null)
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
           return Mapper.Map<User,UserDTO>( userRepository.GetByKey(UserID));
        }
        /// <summary>
        /// 根据分页获取用户信息
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public DataObjectListWithPagination<UserDTOList> GetUsersByPage(Pagination pagination)
        {
            throw new NotImplementedException();
        }

        public ModuleDTOList GetUserPermission(Guid UserID)
        {
            throw new NotImplementedException();
        }

        public UserDTO AssignUserPermission(Guid userid, IDList moduleids)
        {
            throw new NotImplementedException();
        }

        public RoleDTOList CreateRole(RoleDTOList role)
        {
            throw new NotImplementedException();
        }

        public RoleDTOList EditRole(RoleDTOList role)
        {
            throw new NotImplementedException();
        }

        public void DeleteRole(IDList roleid)
        {
            throw new NotImplementedException();
        }

        public UserDTOList GetUserListByRole(Guid roleid)
        {
            throw new NotImplementedException();
        }

        public RoleDTO AssignRolePermission(Guid roleid, IDList moduleids)
        {
            throw new NotImplementedException();
        }

        public DataObjectListWithPagination<RoleDTOList> GetRolesByPage(Pagination pagination)
        {
            throw new NotImplementedException();
        }

        public UserDTO AssignUserRole(Guid userid, IDList roleids)
        {
            throw new NotImplementedException();
        }

        public UserDTO AssignUserGroup(Guid userid, IDList groupids)
        {
            throw new NotImplementedException();
        }

        public GroupDTOList CreateGroup(GroupDTOList group)
        {
            throw new NotImplementedException();
        }

        public GroupDTOList EditGroup(GroupDTOList group)
        {
            throw new NotImplementedException();
        }

        public void DeleteGroup(IDList groupid)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
