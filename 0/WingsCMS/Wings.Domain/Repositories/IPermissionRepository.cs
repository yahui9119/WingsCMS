using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;

namespace Wings.Domain.Repositories
{
    /// <summary>
    /// 标示权限的仓库接口
    /// </summary>
    public interface IPermissionRepository:IRepository<Permission>
    {
        /// <summary>
        /// 根据站点用户获取权限
        /// </summary>
        /// <param name="webuser"></param>
        /// <returns></returns>
        List<Permission> GetPermissionByWebUser(User user);
    }
}
