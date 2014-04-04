using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Wings.Framework.Plugin.Contracts;
using Wings.Framework.Plugin.Services;
using Wings.Framework.Routes;

namespace Wings.Framework.Plugin
{
    public class PluginsManger : IPluginsManger
    {
        /// <summary>
        /// 站点扩展初始化
        /// </summary>
        public static void Init()
        {

        }
        private static IPluginService _service;
        public static IPluginService Service
        {
            get
            {
                if (_service == null)
                {
                    InstanceContext instanceContext = new InstanceContext(new PluginServiceCallBack());
                    DuplexChannelFactory<IPluginService> channelFactory = new DuplexChannelFactory<IPluginService>(instanceContext, "PluginService");
                    _service = channelFactory.CreateChannel();
                }
                try
                {
                    _service.OnlineHeartbeat(Guid.Empty,Guid.Empty);
                }
                catch (Exception ex)
                {
                    new Log.Log().Error(ex);
                    InstanceContext instanceContext = new InstanceContext(new PluginServiceCallBack());
                    DuplexChannelFactory<IPluginService> channelFactory = new DuplexChannelFactory<IPluginService>(instanceContext, "PluginService");
                    _service = channelFactory.CreateChannel();
                }
                return _service;


            }
        }
        /// <summary>
        /// 安装插件
        /// </summary>
        /// <param name="plugin">插件</param>
        /// <returns></returns>
        public bool InstallPlugin(IPlugin plugin)
        {
            try
            {
                RoutesRegister.RegisterRoute(plugin.routes);
                return true;
            }
            catch (Exception ex)
            {
                //记录日志ex
                return false;
            }

        }
        /// <summary>
        /// 卸载插件
        /// </summary>
        /// <param name="plugin">插件</param>
        /// <returns></returns>
        public bool UnInstallPlugin(IPlugin plugin)
        {
            try
            {
                RoutesRegister.DeleteRoute(plugin.routes);
                return true;
            }
            catch (Exception ex)
            {

                //记录日志ex
                return false;
            }
        }
    }
}
