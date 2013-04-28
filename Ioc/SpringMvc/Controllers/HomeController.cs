using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpringMvc.Controllers
{
    public class HomeController : Controller
    {
        public string Message { get; set; }

        public ActionResult Index()
        {
            ViewData["Message"] = this.Message;

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
