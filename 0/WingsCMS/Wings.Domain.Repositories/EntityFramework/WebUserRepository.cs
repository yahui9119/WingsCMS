using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;

namespace Wings.Domain.Repositories.EntityFramework
{
    public class WebUserRepository : EntityFrameworkRepository<WebUser>, IWebUserRepository
    {
        public WebUserRepository(IRepositoryContext context) : base(context) { }
        /// <summary>
        /// 获取用户所有可以管理的站点
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<Web> GetWebsForUser(User user)
        {
            var context = EFContext.Context as WingsDbContext;
            var query = from webusers in context.WebUsers
                        where webusers.user.ID.Equals(user.ID)
                        select webusers.webs;
            return query.FirstOrDefault();
                      
        }
        /// <summary>
        /// 获取所有管理此站点的用户
        /// </summary>
        /// <param name="web"></param>
        /// <returns></returns>
        public List<User> GetUsersForWeb(Web web)
        {
            var context = EFContext.Context as WingsDbContext;
            var query = from webusers in context.WebUsers
                        where webusers.webs.Contains(web)
                        select webusers.user;
            return query.ToList();
        }
    }
}
