using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Wings.Contracts;
using Wings.DataObjects;
using Wings.Framework.Communication;
using Wings.Framework.Plugin;
using Wings.Framework.Plugin.UI;

namespace Wings.Admin.Controllers
{
    public class AccountController : WingsController
    {
        //
        // GET: /Account/

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [Anonymous]
        public ActionResult Login(string username, string password,bool remember=false)
        {
            //var username =;
            //var password = "";
            bool islogin = false;
            using (ServiceProxy<IUserService> proxy = new ServiceProxy<IUserService>())
            {
                islogin = proxy.Channel.CheckPassword(username, password);
                Pagination p = new Pagination();
                p.page = 1;
                p.rows = 10;
                
                var test = proxy.Channel.GetAllUsers();
            }
            if(islogin)
            {
                 FormsAuthentication.SetAuthCookie(username, remember);
                 return RedirectToAction("index", "home");
            }
            else
            {
                ModelState.AddModelError("error", "用户名或密码错误");
                
            }
            return View();
        }
        [HttpPost]
        [LoginAllowView]
        public ActionResult LogOut()
        {
            return View();
        }

    }
}
