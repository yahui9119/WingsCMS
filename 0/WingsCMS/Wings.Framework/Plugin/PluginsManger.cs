using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wings.Framework.Plugin
{
    public class PluginsManger : IPluginsManger
    {
        /// <summary>
        /// 安装插件
        /// </summary>
        /// <param name="plugin">插件</param>
        /// <returns></returns>
        public bool InstallPlugin(IPlugin plugin)
        {
            try
            {

            }
            catch (Exception)
            {
                
                throw;
            }
            return false;
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

            }
            catch (Exception)
            {
                
                throw;
            }
            return false;
        }
    }
}
