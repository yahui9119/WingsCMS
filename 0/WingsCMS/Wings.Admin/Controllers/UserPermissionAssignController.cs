using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wings.Framework.Plugin;

namespace Wings.Admin.Controllers
{
    public class UserPermissionAssignController : WingsController
    {
        //
        // GET: /UserPermissionAssign/
        [Description("[用户权限添加【主页】]")]
        public ActionResult Index()
        {
            return View();
        }

    }
}
