using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wings.CMS.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(string username, string password)
        {
            if (username==password)
            {
                return View("domain");
            }
            else
            {
                return View("index");
            }
        }

        public ActionResult domain()
        {
            return View();
        }
    }
}
