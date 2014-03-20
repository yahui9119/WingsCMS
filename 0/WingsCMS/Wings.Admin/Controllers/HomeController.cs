using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wings.Framework.Config;
using Wings.Framework.Plugin;
using Wings.Framework.Plugin.UI;
using Wings.DataObjects;

namespace Wings.Admin.Controllers
{
    public class HomeController : WingsController
    {
        [DefaultPage]
        [LoginAllowView]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 载入菜单 （工具条）
        /// </summary>
        /// <returns></returns>
        [LoginAllowView]
        public ActionResult LoadMenus()
        {
            List<MenusDTO> menus = new List<MenusDTO>();
            for (int i = 0; i < 3; i++)
            {
                MenusDTO menu = new MenusDTO();
                menu.ID = Guid.NewGuid().ToString();
                menu.Name = "系统维护";
                menu.Url = "javascript:;";
                menu.ICO = "";
                menu.ChildMenus = new List<MenusDTO>();
                for (int j = 0; j < 2; j++)
                {
                    MenusDTO menu2 = new MenusDTO();
                    menu2.ID = Guid.NewGuid().ToString();
                    menu2.Name = "系统维护";
                    menu2.Url = "javascript:;";
                    menu2.ICO = "";
                    menu.ChildMenus.Add(menu2);

                }
                menus.Add(menu);
            }

            return Json(menus,JsonRequestBehavior.AllowGet);
        }
    }
}
