using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wings.DLL;
using Wings.Models;

namespace Wings.DAL
{
    public class RolesDal
    {
        BaseRepository<Role> Roles = new BaseRepository<Role>();

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        public Role Add(Role Role)
        {
            return Roles.AddEntities(Role);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        public bool Update(Role Role)
        {
            return Roles.UpdateEntities(Role);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        public bool Delete(Role Role)
        {
            return Roles.DeleteEntities(Role);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="wherelambda"></param>
        /// <returns></returns>
        public List<Role> Load(Func<Role, bool> wherelambda)
        {
            return Roles.LoadEntities(wherelambda).ToList();
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="total"></param>
        /// <param name="whereLambda"></param>
        /// <param name="isAsc"></param>
        /// <param name="orderByLambda"></param>
        /// <returns></returns>
        public List<Role> LoadPager<S>(int pageSize, int pageIndex, out int total,
            Func<Role, bool> whereLambda, bool isAsc, Func<Role, S> orderByLambda)
        {
            return Roles.LoadPagerEntities<S>(pageSize, pageIndex, out total, whereLambda, isAsc, orderByLambda).ToList();
        }
    }
}
