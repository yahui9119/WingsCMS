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
        /// 获取该站点用户的分组
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns></returns>
        List<Group> GetGroupByWebUser(User user);
        /// <summary>
        /// 是否包换该用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool IsExistsUser(User user);
    }
}
