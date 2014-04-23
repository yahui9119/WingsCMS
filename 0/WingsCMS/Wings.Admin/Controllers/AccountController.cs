using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;
using Wings.Admin.Models;
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
        [ValidateAntiForgeryToken]
        [Description("[站点登录接受提交页面]")]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            //if (ModelState.IsValid && WebSecurity.Login(model.Account, model.Password, persistCookie: model.RememberMe))
            //{
            //    return RedirectToLocal(returnUrl);
            //}
            var webid=Wings.Framework.Config.WingsConfigurationReader.Instance.WebID;
            var adminid=Wings.Framework.Config.WingsConfigurationReader.Instance.WebAdminID;
            if (ModelState.IsValid)
            {
                if (false)
                {
                    ModelState.AddModelError("", "验证码不正确。");
                }

                var accountid = PluginsManger.Service.Login(model.Account, model.Password,webid );
                if (accountid == null || accountid.Equals(Guid.Empty))
                {
                    ModelState.AddModelError("", "提供的账户或密码不正确。");
                }
                else
                {
                    var PermissionList= PluginsManger.Service.GetPermissionByUserID(accountid, webid, adminid == accountid);
                    FormsAuthentication.RedirectFromLoginPage(model.Account, model.RememberMe);
                }

            }
            // 如果我们进行到这一步时某个地方出错，则重新显示表单

            return View(model);
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
