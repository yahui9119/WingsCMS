using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;

namespace Wings.Domain.Repositories
{
    /// <summary>
    /// 标示站点用户关系的  聚合根的仓库接口
    /// </summary>
    public interface IWebUserRepository:IRepository<WebUser>
    {
        /// <summary>
        /// 获取用户所有可以管理的站点
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        List<Web> GetWebsForUser(User user);
        /// <summary>
        /// 获取所有管理此站点的用户
        /// </summary>
        /// <param name="web"></param>
        /// <returns></returns>
        List<User> GetUsersForWeb(Web web);

    }
}
