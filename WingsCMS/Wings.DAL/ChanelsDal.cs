using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wings.DLL;
using Wings.Models;

namespace Wings.DAL
{
    public class ChanelsDal
    {
        BaseRepository<Chanel> Chanels = new BaseRepository<Chanel>();

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="Chanel"></param>
        /// <returns></returns>
        public Chanel Add(Chanel Chanel)
        {
            return Chanels.AddEntities(Chanel);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="Chanel"></param>
        /// <returns></returns>
        public bool Update(Chanel Chanel)
        {
            return Chanels.UpdateEntities(Chanel);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Chanel"></param>
        /// <returns></returns>
        public bool Delete(Chanel Chanel)
        {
            return Chanels.DeleteEntities(Chanel);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="wherelambda"></param>
        /// <returns></returns>
        public List<Chanel> Load(Func<Chanel, bool> wherelambda)
        {
            return Chanels.LoadEntities(wherelambda).ToList();
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
        public List<Chanel> LoadPager<S>(int pageSize, int pageIndex, out int total,
            Func<Chanel, bool> whereLambda, bool isAsc, Func<Chanel, S> orderByLambda)
        {
            return Chanels.LoadPagerEntities<S>(pageSize, pageIndex, out total, whereLambda, isAsc, orderByLambda).ToList();
        }
    }
}
