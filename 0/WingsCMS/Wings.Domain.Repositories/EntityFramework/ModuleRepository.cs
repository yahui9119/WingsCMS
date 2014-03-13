using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;

namespace Wings.Domain.Repositories.EntityFramework
{
    public class ModuleRepository : EntityFrameworkRepository<Model.Module>, IModuleRepository
    {
        public ModuleRepository(IRepositoryContext Context)
            : base(Context)
        {

        }
        /// <summary>
        /// 获取此站点用户可用的所有模块
        /// 只涉及单个领域
        /// 此数据是此操作未经过权限过滤
        /// </summary>
        /// <param name="webuser"></param>
        /// <returns></returns>
        public List<Module> GetModuleByWebUser(WebUser webuser)
        {
            var context = EFContext.Context as WingsDbContext;
            var query = from webmodule in context.WebModules
                        from userweb in context.WebUsers
                        where userweb.user.ID.Equals(webuser.ID) && userweb.webs.Contains(webmodule.web)
                        select webmodule;
            if (query == null)
            { return null; }
             List<Module> modules=new List<Module> ();
             query.ToList().ForEach(q =>
             {
                 if (webuser.webs.Contains(q.web))
                 {
                     q.Modules.ForEach(m =>
                     {
                         modules.Add(m);
                     });

                 }
             });
             return modules;
        }
    }
}
