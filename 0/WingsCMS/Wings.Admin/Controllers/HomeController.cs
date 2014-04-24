using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wings.Framework.Config;
using Wings.Framework.Plugin;
using Wings.Framework.Plugin.UI;
using Wings.DataObjects;
using Wings.Framework.Caching;
using Wings.Framework.Plugin.Web;
using System.ComponentModel;

namespace Wings.Admin.Controllers
{
    public class HomeController : WingsController
    {
        [DefaultPage]
        [LoginAllowView]
        [Description("[站点主页【首页】]")]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 主页面
        /// </summary>
        /// <returns></returns>
        [LoginAllowView]
        [Description("[站点主页【主页】]")]
        public ActionResult Main()
        {
            return View();
        }
        /// <summary>
        /// 载入菜单 （工具条）
        /// </summary>
        /// <returns></returns>
        [LoginAllowView]
        [Description("[站点主页【获取菜单列表】]")]
        public ActionResult LoadMenus()
        {
            PluginsManger.Service.Login("test", "test", Guid.Empty);
           
            //List<MenusDTO> menus = new List<MenusDTO>();
            //for (int i = 0; i < 3; i++)
            //{
            //    MenusDTO menu = new MenusDTO();
            //    menu.ID = Guid.NewGuid().ToString();
            //    menu.Name = "系统维护";
            //    menu.Url = "javascript:;";
            //    menu.ICO = "";
            //    menu.ChildMenus = new List<MenusDTO>();
            //    for (int j = 0; j < 2; j++)
            //    {
            //        MenusDTO menu2 = new MenusDTO();
            //        menu2.ID = Guid.NewGuid().ToString();
            //        menu2.Name = "系统维护";
            //        menu2.Url = "javascript:;";
            //        menu2.ICO = "";
            //        menu.ChildMenus.Add(menu2);

            //    }
            //    menus.Add(menu);
            //}

            return Json(WebSetting.GetAllAction(), JsonRequestBehavior.AllowGet);
        }
    }
}
