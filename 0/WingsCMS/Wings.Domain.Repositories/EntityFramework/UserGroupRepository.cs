using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;
using Wings.Domain.Repositories.Specifications;

namespace Wings.Domain.Repositories.EntityFramework
{
    public class UserGroupRepository : EntityFrameworkRepository<UserGroup>, IUserGroupRepository
    {
        public UserGroupRepository(IRepositoryContext Context)
            : base(Context) { }
        /// <summary>
        /// 获取用户的分组
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns></returns>
        public List<Group> GetGroupByUser(User user)
        {
            var context = EFContext.Context as WingsDbContext;
            var query = from usergroup in context.UserGroups
                        where usergroup.user.ID.Equals(user.ID)
                        select usergroup.groups;
            return query.FirstOrDefault();
        }
        /// <summary>
        /// 根据分组获取用户
        /// </summary>
        /// <param name="group">分组</param>
        /// <returns></returns>
        public List<User> GetUserByGroup(Group group)
        {
            var context = EFContext.Context as WingsDbContext;
            var getgroup = 
                        from groups in context.Groups
                        where groups.ID.Equals(@group.ID)
                        select groups;
            var query = from usergroup in context.UserGroups
                        where usergroup.groups.Contains(getgroup.FirstOrDefault())
                        select usergroup.user;
                      
            return query.ToList();
        }
     
    }
}
