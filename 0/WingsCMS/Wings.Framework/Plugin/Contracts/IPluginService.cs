using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Framework.Plugin.Contracts
{
    /// <summary>
    /// 插件服务契约
    /// </summary>
    
     [ServiceContract(Namespace = "http://www.wings.com", CallbackContract = typeof(IPluginServiceCallBack))]
    public interface IPluginService
    {
        /// <summary>
        /// 初始化站点的访问点信息
        ///服务端拥有的以站点实际拥有的为准
        /// </summary>
        /// <param name="webid"></param>
        /// <param name="permission"></param>
        [OperationContract(IsOneWay = true)]
        void Init(Guid webid, List<Permission> permission);
        /// <summary>
        /// 玩家在一个站点登录
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <param name="webid"></param>
        [OperationContract(IsOneWay = true)]
        void Login(string account, string password, Guid webid );
        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="account"></param>
        [OperationContract(IsOneWay = true)]
        void LoginOut(string account);
        /// <summary>
        /// 在线心跳
        /// </summary>
        /// <param name="account"></param>
        [OperationContract(IsOneWay = true)]
        void OnlineHeartbeat(string account);
    }
}
