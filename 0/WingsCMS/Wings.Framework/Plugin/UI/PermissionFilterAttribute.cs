using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.WebPages;
using Wings.Framework.Caching;
using Wings.Framework.Plugin.Contracts;

namespace Wings.Framework.Plugin.UI
{
    /// <summary>
    /// 权限拦截
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class PermissionFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 判断当前用户是否有次访问点的权限
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //权限拦截是否忽略
            bool IsIgnored = false;
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            //是否登录和允许匿名访问 即无权限控制
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                if (filterContext.ActionDescriptor.IsDefined(typeof(AnonymousAttribute), false))
                {
                    IsIgnored = true;

                }
                else
                {
                    FormsAuthentication.RedirectToLoginPage();
                }
            }
            else
                //用户已经登录
                if (!IsIgnored)
                {
                    if (filterContext.ActionDescriptor.IsDefined(typeof(LoginAllowViewAttribute), false))
                    {
                        IsIgnored = true;
                    }
                    else
                    {
                        //读取缓存 是否包含此控制器和访问
                        var permissionsobj = CacheManager.Instance.Get("Permission", filterContext.HttpContext.User.Identity.Name);
                        if (permissionsobj != null)
                        {
                            List<Permission> permissions = (List<Permission>)permissionsobj;
                            var path = filterContext.HttpContext.Request.Path.ToLower();
                            string controller = filterContext.RouteData.Values["controller"].ToString();
                            string action = filterContext.RouteData.Values["action"].ToString();
                            var ispost = filterContext.HttpContext.Request.HttpMethod.ToLower() == "post";
                            if (permissions != null && permissions.Count > 0)
                            {

                                int index = permissions.FindIndex(p =>
                                 p.Action.ToLower() == action && p.Controller.ToLower() == controller && p.IsPost == ispost);
                                IsIgnored = index >= 0;
                            }
                        }
                    }
                }

            //
            if (!IsIgnored)
            {
                filterContext.Result = new JsonResult() { Data = new { success = false, message = "抱歉 您不具有此页面的访问权限！" } };
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
