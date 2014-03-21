using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using Wings.Contracts;
using Wings.DataObjects;
using Wings.Framework;

namespace Wings.SOAService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“PluginService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 PluginService.svc 或 PluginService.svc.cs，然后开始调试。
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class PluginService : IPluginService
    {
        private readonly IPluginService pluginServiceImpl = ServiceLocator.Instance.GetService<IPluginService>();

        public DataObjects.WebDTO InstallPlugin(DataObjects.WebDTO webdto)
        {
            try
            {
                return pluginServiceImpl.InstallPlugin(webdto);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }

        public DataObjects.WebDTO UpdatePlugin(DataObjects.WebDTO webdto)
        {
            try
            {
                return pluginServiceImpl.UpdatePlugin(webdto);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }

        public void UnstallPlugin(DataObjects.WebDTO web)
        {
            try
            {
                pluginServiceImpl.UnstallPlugin(web);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }

        public void Dispose()
        {
            pluginServiceImpl.Dispose();
        }
    }
}
