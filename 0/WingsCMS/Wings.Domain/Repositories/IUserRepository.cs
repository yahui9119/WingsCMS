using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;
using Wings.Framework;

namespace Wings.Domain.Repositories
{
    public interface IUserRepository:IRepository<User>
    {
        /// <summary>
        /// 用户名是否已经存在
        /// </summary>
        /// <param name="UserNamed">用户名</param>
        /// <returns></returns>
        bool UserNameExists(string UserNamed);
        /// <summary>
        /// 邮箱是否已经存在
        /// </summary>
        /// <param name="Email">邮箱</param>
        /// <returns></returns>
        bool EmailExists(string Email);
        /// <summary>
        /// 验证密码是否正确
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="Password">密码</param>
        /// <returns></returns>
        bool CheckPassword(string UserName, string Password);
        /// <summary>
        /// 通过邮件获取用户
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        User GetUserByEmail(string Email);
    }
}
