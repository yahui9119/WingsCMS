using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Wings.DataObjects;

namespace Wings.Contracts
{
    /// <summary>
    /// 标示“站点扩展”的领域的服务
    /// </summary>
    [ServiceContract(Name = "http://www.wings.com")]
    public interface IPluginService
    {
        /// <summary>
        /// 初始化一个站点扩展
        /// </summary>
        /// <param name="web"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        void InstallPlugin(WebDTO web);
        /// <summary>
        /// 插件更新
        /// </summary>
        /// <param name="web"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        void UpdatePlugin(WebDTO web);
        /// <summary>
        /// 禁用一个插件
        /// </summary>
        /// <param name="web"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        void UnstallPlugin(WebDTO web);
    }
}
