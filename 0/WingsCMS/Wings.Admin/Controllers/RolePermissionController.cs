using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wings.Framework.Plugin;

namespace Wings.Admin.Controllers
{
    /// <summary>
    /// 角色权限管理
    /// </summary>
    public class RolePermissionController : WingsController
    {
        //
        // GET: /RolePermission/
        [Description("角色权限管理【主页】")]
        public ActionResult Index()
        {
            return View();
        }

    }
}
