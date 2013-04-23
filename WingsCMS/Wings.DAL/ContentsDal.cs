using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wings.DLL;
using Wings.Models;

namespace Wings.DAL
{
    public class ContentsDal
    {
        BaseRepository<Content> Contents = new BaseRepository<Content>();

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="Content"></param>
        /// <returns></returns>
        public Content Add(Content Content)
        {
            return Contents.AddEntities(Content);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="Content"></param>
        /// <returns></returns>
        public bool Update(Content Content)
        {
            return Contents.UpdateEntities(Content);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Content"></param>
        /// <returns></returns>
        public bool Delete(Content Content)
        {
            return Contents.DeleteEntities(Content);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="wherelambda"></param>
        /// <returns></returns>
        public List<Content> Load(Func<Content, bool> wherelambda)
        {
            return Contents.LoadEntities(wherelambda).ToList();
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
            return Contents.LoadPagerEntities<S>(pageSize, pageIndex, out total, whereLambda, isAsc, orderByLambda).ToList();
        }
    }
}
