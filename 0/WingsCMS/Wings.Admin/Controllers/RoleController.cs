using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wings.Framework.Plugin;

namespace Wings.Admin.Controllers
{
    /// <summary>
    /// 角色管理
    /// </summary>
    public class RoleController : WingsController
    {
        //
        // GET: /Role/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }

    }
}
