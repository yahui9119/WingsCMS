using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wings.Common;
using Wings.Models;

namespace Wings.CMS.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        ResultDWZ rdwz = new ResultDWZ();
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
            rdwz.statusCode = "200";
            rdwz.message = "操作成功";
            rdwz.callbackType = "closeCurrent";
            return Json(rdwz);
        }
        public ActionResult domain()
        {
            return View();
        }
    }
}
