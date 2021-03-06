﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wings.DAL;
using Wings.Models;

namespace Wings.BLL
{
    public class UsersBll
    {
        UsersDal dal = new UsersDal();
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User Add(User user)
        {
            return dal.Add(user);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Update(User user)
        {
            return dal.Update(user);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Delete(User user)
        {
            return dal.Delete(user);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="wherelambda"></param>
        /// <returns></returns>
        public List<User> Load(Func<User, bool> wherelambda)
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
        public List<User> LoadPager<S>(int pageSize, int pageIndex, out int total,
            Func<User, bool> whereLambda, bool isAsc, Func<User, S> orderByLambda)
        {
            return dal.LoadPager<S>(pageSize, pageIndex, out total, whereLambda, isAsc, orderByLambda);
        }
    }
}
