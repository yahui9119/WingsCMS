using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;

namespace Wings.Domain.Repositories.EntityFramework
{
    public class UserRoleRepository : EntityFrameworkRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(IRepositoryContext context) : base(context) { }
        /// <summary>
        /// 根据用户获取用户角色
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<Role> GetRolesByUser(User user)
        {
            var context= this.EFContext.Context as WingsDbContext;
            var query = from userrole in context.UserRoles
                        where user.ID.Equals(user.ID)
                        select userrole.roles;
            if (query == null)
            {
                return null;
            }
            return query.FirstOrDefault();
        }
        /// <summary>
        /// 根据角色获取所有角色下的有效用户
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        public List<User> GetUsersByRole(Role Role)
        {
            var context = this.EFContext.Context as WingsDbContext;
            var query = from userrole in context.UserRoles
                        where userrole.roles.Contains(Role)
                        select userrole.user;
            if (query == null)
            {
                return null;
            }
            return query.ToList();
        }
    }
}
