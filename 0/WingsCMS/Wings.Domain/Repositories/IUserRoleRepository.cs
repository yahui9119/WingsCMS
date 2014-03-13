using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;

namespace Wings.Domain.Repositories
{
    /// <summary>
    /// 用户角色管理
    /// </summary>
    public interface IUserRoleRepository:IRepository<UserRole>
    {
        /// <summary>
        /// 根据用户获取用户角色
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        List<Role> GetRolesByUser(User user);
        /// <summary>
        /// 根据角色获取所有角色下的有效用户
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        List<User> GetUsersByRole(Role Role);
    }
}
