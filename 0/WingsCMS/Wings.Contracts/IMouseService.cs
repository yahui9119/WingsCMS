using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Wings.DataObjects;
using Wings.Framework.Infrastructure;


namespace Wings.Contracts
{
    [ServiceContract(Namespace="www.wingscms.com")]
    public interface IMouseService:ICoreServiceContract
    {
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        void Cry(Guid id);
    }
}
