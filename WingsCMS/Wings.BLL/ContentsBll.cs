using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wings.DAL;
using Wings.Models;

namespace Wings.BLL
{
    public class ContentsBll
    {
        ContentsDal dal = new ContentsDal();
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="Content"></param>
        /// <returns></returns>
        public Content Add(Content Content)
        {
            return dal.Add(Content);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="Content"></param>
        /// <returns></returns>
        public bool Update(Content Content)
        {
            return dal.Update(Content);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Content"></param>
        /// <returns></returns>
        public bool Delete(Content Content)
        {
            return dal.Delete(Content);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="wherelambda"></param>
        /// <returns></returns>
        public List<Content> Load(Func<Content, bool> wherelambda)
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
        public List<Content> LoadPager<S>(int pageSize, int pageIndex, out int total,
            Func<Content, bool> whereLambda, bool isAsc, Func<Content, S> orderByLambda)
        {
            return dal.LoadPager<S>(pageSize, pageIndex, out total, whereLambda, isAsc, orderByLambda);
        }
    }
}
