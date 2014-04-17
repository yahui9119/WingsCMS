using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wings.Framework.Plugin;

namespace Wings.Admin.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class UserPermissionBanController : WingsController
    {
        //
        // GET: /UserPermissionBan/
        [Description("[用户权限禁用【主页】]")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
