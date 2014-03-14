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
    /// 标示“用户相关的应用层服务契约”
    /// </summary>
    [ServiceContract(Name="http://www.wings.com")]
    public interface IUserService : ICoreServiceContract
    {
        /// <summary>
        /// 验证用户名和密码是否在正确
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        bool CheckPassword(string UserName, string Password);
    }
}
