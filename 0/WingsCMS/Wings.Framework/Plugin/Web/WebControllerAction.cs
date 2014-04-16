using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Wings.Framework.Config;
using Wings.Framework.Plugin.Contracts;

namespace Wings.Framework.Plugin.Web
{
    /// <summary>
    /// 站点的控制器表述
    /// </summary>
    public class WebControllerAction
    {
        public static List<Permission> GetAllAction()
        {
            List<Permission> permissList = new List<Permission>();
            var assembly = WingsConfigurationReader.Instance.WebAssembly;
            if (assembly == null || string.IsNullOrWhiteSpace(assembly))
            {
                return permissList;
            }

            var assemblylist = assembly.Split(',').ToList();
            assemblylist.ForEach(s =>
                {
                    var types = Assembly.Load(s).GetTypes();

                    foreach (var type in types)
                    {
                        if (type.BaseType.Name == "WingsController")//如果是Controller
                        {

                            var actions = type.GetMethods().ToList();
                            if (actions != null)
                            {
                                actions.ForEach(m =>
                                    {
                                        if (m.ReturnType.Name == "ActionResult")//如果是action
                                        {
                                            var permission = new Permission();

                                            permission.Controller = type.Name.Replace("Controller", "");//去除Controller的后缀

                                            permission.Action = m.Name;
                                            object[] actionattrs = m.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), true);

                                            permission.Description = actionattrs.Length > 0 ? (actionattrs[0] as System.ComponentModel.DescriptionAttribute).Description : string.Empty;
                                            permission.IsPost = m.GetCustomAttributes(typeof(HttpPostAttribute), true).Length > 0;
                                           
                                            
                                            //permission.Url = new UrlHelper(requestcontext, RouteTable.Routes).Action(permission.Controller, permission.Action);
                                            permissList.Add(permission);
                                        }
                                    });
                            }
                        }
                    }
                });
            return permissList;
        }
    }
}
