using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;

namespace Wings.Domain.Repositories
{
    /// <summary>
    /// 菜单仓库
    /// </summary>
    interface IMenusRepository:IRepository<Menus>
    {
        /// <summary>
        /// 根据用户获取该用户所拥有的菜单
        /// </summary>
        /// <param name="webuser"></param>
        /// <returns></returns>
        List<Menus> GetMenusByUser(WebUser webuser);
    }
}
