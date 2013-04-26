using Wings.Core.Model;
using Wings.Core.Service;
using Wings.UI.Dto;
using Wings.UI.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wings.UI.Controllers
{
    public class HomeController : Cruder<Dinner, DinnerInput>
    {
        public HomeController(ICrudService<Dinner> service, IMapper<Dinner, DinnerInput> v)
            : base(service, v)
        {
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult ShowGrid()
        {
            return View();
        }

        protected override string RowViewName
        {
            get { return "ListItems/Dinner"; }
        }
    }
}
