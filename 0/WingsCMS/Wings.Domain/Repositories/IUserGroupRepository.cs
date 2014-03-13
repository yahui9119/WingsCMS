using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;

namespace Wings.Domain.Repositories
{
    /// <summary>
    /// 站点用户分组的仓库接口
    /// </summary>
    public interface IUserGroupRepository : IRepository<UserGroup>
    {
        /// <summary>
        /// 获取用户的分组
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns></returns>
        List<Group> GetGroupByUser(User user);
        /// <summary>
        /// 根据分组获取用户
        /// </summary>
        /// <param name="group">分组</param>
        /// <returns></returns>
        List<User> GetUserByGroup(Group group);

    }
}
