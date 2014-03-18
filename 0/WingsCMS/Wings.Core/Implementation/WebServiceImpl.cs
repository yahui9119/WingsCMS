using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Contracts;

namespace Wings.Core.Implementation
{
    public class WebServiceImpl:IWebService
    {
        public void CreateWeb(DataObjects.WebDTO webdto)
        {
            throw new NotImplementedException();
        }

        public void EditWeb(DataObjects.WebDTO webdto)
        {
            throw new NotImplementedException();
        }

        public void DeleteWeb(Guid webid)
        {
            throw new NotImplementedException();
        }

        public DataObjects.UserDTOList GetUsersByWeb(Guid webid)
        {
            throw new NotImplementedException();
        }

        public DataObjects.DataObjectListWithPagination<DataObjects.WebDTOList> GetWebsByPage(DataObjects.Pagination pagination)
        {
            throw new NotImplementedException();
        }

        public void CreateModule(Guid webid, DataObjects.ModuleDTO moduledto)
        {
            throw new NotImplementedException();
        }

        public void EditModule(DataObjects.ModuleDTO moduledto)
        {
            throw new NotImplementedException();
        }

        public void DeleteModule(Guid webid, Guid moduleid)
        {
            throw new NotImplementedException();
        }
    }
}
