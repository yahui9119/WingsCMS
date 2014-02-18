using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;

namespace Wings.Framework.Plugin
{
    interface IPlugin
    {
        /// <summary>
        /// 插件名
        /// </summary>
        string PluginName { get; set; }
        /// <summary>
        /// 插件描述
        /// </summary>
        string Describtion { get; set; }
        /// <summary>
        /// 插件路由
        /// </summary>
        List<Route> routes { get; set; }
    }
}
