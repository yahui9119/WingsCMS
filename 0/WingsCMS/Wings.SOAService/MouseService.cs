using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wings.Contracts;
using Wings.Framework;


namespace Wings.SOAService
{
    public class MouseService:IMouseService
    {
        private readonly IMouseService service = ServiceLocator.Instance.GetService<IMouseService>();
        public void Cry()
        {
            
        }

        public void Dispose()
        {
            service.Dispose();
        }
    }
}