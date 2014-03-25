﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Wings.Framework.Plugin.UI
{
    /// <summary>
    /// 错误信息拦截
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class ExceFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //base.OnActionExecuted(filterContext);
            //判断是否出现错误
            //进行友好格式输出
            var exception = filterContext.Exception;
            if (exception != null)
            {
                
                //JsonResult exResult = new JsonResult();
                //exResult.Data = exception.Message;
                filterContext.Controller.ViewData["ErrorMessage"]=exception.Message;
                filterContext.Result = new ViewResult() { 
                 ViewName="Error",
                 ViewData = filterContext.Controller.ViewData
                };
                filterContext.ExceptionHandled = true;
            }
        }
    }
}
