using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wings.Framework.Plugin;
using Wings.DataObjects;
using Wings.Framework.Communication;
using Wings.Contracts;

namespace Wings.Admin.Controllers
{
    /// <summary>
    /// 角色管理
    /// </summary>
    public class RoleController : WingsController
    {
        //
        // GET: /Role/
        public ActionResult Index(FormCollection collection)
        {
            RoleDTOList roles = new RoleDTOList();
            using (ServiceProxy<IUserService> proxy = new ServiceProxy<IUserService>())
            {
                //Pagination p = new Pagination();
                //p.PageNumber = 1;
                //p.PageSize = 10;
                //p.StartTime = null;
                //p.EndTime = null;
                //p.IsDesc = true;
                //this.TryUpdateModel<Pagination>(p);
                roles=proxy.Channel.GetAllRoles();
            }
            return View(roles);
        }
        public ActionResult Edit()
        {
            return View();
        }

    }
}
