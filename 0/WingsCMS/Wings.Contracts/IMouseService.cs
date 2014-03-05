using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Wings.DataObjects;


namespace Wings.Contracts
{
    [ServiceContract(Namespace="www.wingscms.com")]
    public interface IMouseService
    {
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        void Cry();
    }
}
