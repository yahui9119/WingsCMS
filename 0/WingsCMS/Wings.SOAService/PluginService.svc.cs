﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using Wings.Contracts;
using Wings.DataObjects;
using Wings.Framework;
using Wings.Framework.Plugin.Contracts;
using Wings.Framework.Plugin.Utils;

namespace Wings.SOAService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“PluginService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 PluginService.svc 或 PluginService.svc.cs，然后开始调试。
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class PluginService : IPluginService
    {
        private IPluginService pluginServiceImpl = ServiceLocator.Instance.GetService<IPluginService>();
        public void Init(Guid webid, List<Permission> permission)
        {
            IPluginServiceCallBack callback = OperationContext.Current.GetCallbackChannel<IPluginServiceCallBack>();
            ChannelManager.Instance.Add(webid, callback);//添加通信管道
            try
            {
                pluginServiceImpl.Init(webid, permission);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }

        public void Login(string account, string password, Guid webid)
        {
            IPluginServiceCallBack callback = OperationContext.Current.GetCallbackChannel<IPluginServiceCallBack>();
            ChannelManager.Instance.Add(webid, callback);//添加通信管道
            List<ConfiguredString> list = new List<ConfiguredString>();
            list.Add(new ConfiguredString() { key = "sdfsdf", value = "gasfasdfsdf" });
            list.Add(new ConfiguredString() { key = "sdf2f", value = "gasfsdf" });
            callback.SaveConfig(list);
            callback.SaveConfig(list);
        }


        UserInfo IPluginService.Login(string account, string password, Guid webid)
        {
            try
            {
                pluginServiceImpl = ServiceLocator.Instance.GetService<IPluginService>();
                return pluginServiceImpl.Login(account,password, webid);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }

        public List<Permission> GetPermissionByUserID(Guid accountid, Guid webid, bool IsAdmin = false)
        {
            try
            {
                pluginServiceImpl = ServiceLocator.Instance.GetService<IPluginService>();
                return pluginServiceImpl.GetPermissionByUserID(accountid, webid, IsAdmin);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }

        public void LoginOut(Guid accountid, Guid webid)
        {
            try
            {
                pluginServiceImpl.LoginOut(accountid, webid);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }

        }
        //暂不启用
        public void OnlineHeartbeat(Guid accountid, Guid webid)
        {
            try
            {
                pluginServiceImpl.OnlineHeartbeat(accountid,webid);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }

        }
    }
}
