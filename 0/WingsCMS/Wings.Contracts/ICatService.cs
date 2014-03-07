using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Wings.Framework.Infrastructure;
using Wings.DataObjects;

namespace Wings.Contracts
{
    [ServiceContract]
    public interface ICatService:ICoreServiceContract
    {
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        void Run(Guid id);
    }
}
