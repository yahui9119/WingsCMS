using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wings.Core.Model;
using Wings.Core.Service;
using Wings.UI.Dto;
using Wings.UI.Mappers;

namespace Wings.UI.Controllers
{
    public class CountryController : Cruder<Country, CountryInput>
    {
        public CountryController(ICrudService<Country> service, IMapper<Country, CountryInput> v)
            : base(service, v)
        {
        }

        protected override string RowViewName
        {
            get { return "ListItems/Country"; }
        }
    }
}
