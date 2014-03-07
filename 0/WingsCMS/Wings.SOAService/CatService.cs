using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wings.Contracts;
using Wings.Framework;

namespace Wings.SOAService
{
    public class CatService : ICatService
    {
        private readonly ICatService service = ServiceLocator.Instance.GetService<ICatService>();
        public void Run(Guid id)
        {
            service.Run(id);
        }

        public void Dispose()
        {
            service.Dispose();
        }
    }
}