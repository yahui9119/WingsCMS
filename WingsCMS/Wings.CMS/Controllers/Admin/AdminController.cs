using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wings.Model;

namespace Wings.CMS.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            ViewBag.login = false;
            return View();
        }
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public JsonResult login(string username, string password)
        {
            if (username==password)
            {
                return Json("domain");
            }
            else
            {
                return Json("index");
            }
        }
        public ActionResult Post()
        {
            return View();
        }
        
        [ValidateInput(false)]
        [HttpPost]
        public JsonResult Post(Content content)
        {
            return Json("true");
        }
        public ActionResult domain()
        {
            return View();
        }
    }
}
