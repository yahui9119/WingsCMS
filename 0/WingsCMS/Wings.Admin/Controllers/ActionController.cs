using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wings.Admin.Controllers
{
    public class ActionController : Controller
    {
        //
        // GET: /Action/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Tree(string WebID)
        {

            return Json(null,JsonRequestBehavior.AllowGet);
        }
    }
}
