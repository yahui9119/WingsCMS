﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Omu.AwesomeMvc;
using Omu.ProDinner.Core.Model;
using Omu.ProDinner.Core.Repository;

namespace Omu.ProDinner.WebUI.Controllers
{
    public class MealsMultiLookupController : Controller
    {
        private readonly IRepo<Meal> repo;

        public MealsMultiLookupController(IRepo<Meal> repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        public ActionResult Search(string search, int[] selected, int page)
        {
            const int PageSize = 9;
            var list = repo.Where(o => o.Name.Contains(search));

            if (selected != null) list = list.Where(o => !selected.Contains(o.Id)).AsQueryable();
            list = list.OrderByDescending(o => o.Id);

            return Json(new AjaxListResult
                            {
                                Content = this.RenderView("ListItems/MealItem", list.Page(page, PageSize).ToList()),
                                More = list.Count() > page * PageSize
                            });
        }

        public ActionResult Selected(IEnumerable<int> selected)
        {
            var items = (selected != null)
                            ? repo.GetAll().Where(o => selected.Contains(o.Id)).ToList()
                            : new List<Meal>();

            return Json(new AjaxListResult
                         {
                             Content = this.RenderView("ListItems/MealItem", items)
                         });
        }

        public ActionResult GetItems(IEnumerable<int> v)
        {
            return Json(repo.GetAll().Where(o => v.Contains(o.Id)).ToArray().Select(o => new KeyContent
            {
                Key = o.Id,
                Content = @"<img  src='" + Url.Content("~/pictures/Meals/" + Pic(o.Picture)) + "' class='mthumb' />" + o.Name,
                Encode = false
            }));
        }

        private static string Pic(string o)
        {
            return string.IsNullOrEmpty(o) ? "m0.jpg" : "m" + o;
        }

    }
}