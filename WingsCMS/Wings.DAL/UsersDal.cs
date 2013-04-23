using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wings.DLL;
using Wings.Models;

namespace Wings.DAL
{
    public class UsersDal
    {
        BaseRepository<User> Users = new BaseRepository<User>();

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User Add(User user)
        {
            return Users.AddEntities(user);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Update(User user)
        {
            return Users.UpdateEntities(user);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Delete(User user)
        {
            return Users.DeleteEntities(user);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="wherelambda"></param>
        /// <returns></returns>
        public List<User> Load(Func<User, bool> wherelambda)
        {
            return Users.LoadEntities(wherelambda).ToList();
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
        public List<User> LoadPager<S>(int pageSize, int pageIndex, out int total,
            Func<User, bool> whereLambda, bool isAsc, Func<User, S> orderByLambda)
        {
            return Users.LoadPagerEntities<S>(pageSize, pageIndex, out total, whereLambda, isAsc, orderByLambda).ToList();
        }
    }
}
