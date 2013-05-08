﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace Omu.ProDinner.WebUI.Controllers
{
    //http://www.screwturn.eu/ResxSync.ashx
    public class MuiController : Controller
    {
        readonly IDictionary<string, string> langs = new Dictionary<string, string>
                                                    {
                                                        {"en","english"},
                                                        {"fr","francais"},
                                                        {"es","español"},
                                                        {"ro","română"},
                                                        {"de","deutsch"},
                                                        {"ru","русский"},
                                                        {"it","italiano"},
                                                        {"auto","default"},//browser default
                                                    };
        public ActionResult Index()
        {
            var c = Request.Cookies["lang"];

            var k = c == null ? "auto" : c.Value;
            ViewBag.lang = langs[k];
            return View();
        }

        public ActionResult Langs()
        {
            return View(langs);
        }

        [HttpPost]
        public ActionResult Change(string l)
        {
            var period = 1;
            if (l == "auto") period = -1;
            var aCookie = new HttpCookie("lang") { Value = l, Expires = DateTime.Now.AddYears(1) };

            Response.Cookies.Add(aCookie);

            return Content("");
        }
    }
}