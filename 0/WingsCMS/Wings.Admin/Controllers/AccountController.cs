using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [Description("[站点登录显示页面]")]
        [Anonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [Anonymous]
        [Description("[站点登录接受提交页面]")]
        public ActionResult Login(string username, string password, bool remember = false)
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
            if (islogin)
            {
                FormsAuthentication.SetAuthCookie(username, remember);
                //FormsAuthentication.CookieDomain 跨域的时候要配置 
                //FormsAuthentication.RedirectFromLoginPage();  登录记录登录状态之后自动转跳
                return RedirectToAction("index", "home");
            }
            else
            {
                ModelState.AddModelError("error", "用户名或密码错误");

            }
            return View();
        }
        [HttpPost]
        [Description("[站点登出]")]
        [LoginAllowView]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return View();
        }

    }
}
