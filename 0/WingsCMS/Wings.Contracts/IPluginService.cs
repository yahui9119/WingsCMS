using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Wings.DataObjects;
using Wings.Framework.Infrastructure;

namespace Wings.Contracts
{
    /// <summary>
    /// 标示“站点扩展”的领域的服务
    /// </summary>
    [ServiceContract(Name = "http://www.wings.com")]
    public interface IPluginService : ICoreServiceContract
    {
        /// <summary>
        /// 初始化一个站点扩展
        /// 提供站点action的自动添加和站点guid的初始化
        /// </summary>
        /// <param name="web"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        WebDTO InstallPlugin(WebDTO webdto);
        /// <summary>
        /// 插件更新
        /// 更新新添加或删除的action
        /// </summary>
        /// <param name="web"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        WebDTO UpdatePlugin(WebDTO webdto);
        /// <summary>
        /// 禁用一个插件
        /// 自动设置此站点的状态为未激活
        /// </summary>
        /// <param name="web"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        void UnstallPlugin(WebDTO web);
    }
}
