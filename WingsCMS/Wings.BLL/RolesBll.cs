using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wings.DAL;
using Wings.Models;

namespace Wings.BLL
{
    public class RolesBll
    {
        RolesDal dal = new RolesDal();
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        public Role Add(Role Role)
        {
            return dal.Add(Role);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        public bool Update(Role Role)
        {
            return dal.Update(Role);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        public bool Delete(Role Role)
        {
            return dal.Delete(Role);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="wherelambda"></param>
        /// <returns></returns>
        public List<Role> Load(Func<Role, bool> wherelambda)
        {
            return dal.Load(wherelambda);
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
            return dal.LoadPager<S>(pageSize, pageIndex, out total, whereLambda, isAsc, orderByLambda);
        }
    }
}
