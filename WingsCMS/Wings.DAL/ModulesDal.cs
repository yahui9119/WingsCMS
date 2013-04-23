using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wings.DLL;
using Wings.Models;

namespace Wings.DAL
{
    public class ModulesDal
    {
        BaseRepository<Module> Modules = new BaseRepository<Module>();

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="Module"></param>
        /// <returns></returns>
        public Module Add(Module Module)
        {
            return Modules.AddEntities(Module);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="Module"></param>
        /// <returns></returns>
        public bool Update(Module Module)
        {
            return Modules.UpdateEntities(Module);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Module"></param>
        /// <returns></returns>
        public bool Delete(Module Module)
        {
            return Modules.DeleteEntities(Module);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="wherelambda"></param>
        /// <returns></returns>
        public List<Module> Load(Func<Module, bool> wherelambda)
        {
            return Modules.LoadEntities(wherelambda).ToList();
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
        public List<Module> LoadPager<S>(int pageSize, int pageIndex, out int total,
            Func<Module, bool> whereLambda, bool isAsc, Func<Module, S> orderByLambda)
        {
            return Modules.LoadPagerEntities<S>(pageSize, pageIndex, out total, whereLambda, isAsc, orderByLambda).ToList();
        }
    }
}
