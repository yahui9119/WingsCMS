﻿using System;
using System.Web;
using System.Web.Mvc;
using Omu.AwesomeMvc;
using Omu.ProDinner.Core.Model;
using Omu.ProDinner.Core.Service;
using Omu.ProDinner.WebUI.Dto;
using Omu.ProDinner.WebUI.Mappers;

namespace Omu.ProDinner.WebUI.Controllers
{
    public class MealController : Cruder<Meal, MealInput>
    {
        private new readonly IMealService service;
        private readonly IFileManagerService fileManagerService;

        public MealController(IMealService service, IMapper<Meal, MealInput> v, IFileManagerService fileManagerService)
            : base(service, v)
        {
            this.service = service;
            this.fileManagerService = fileManagerService;
        }

        public override ActionResult Index()
        {
            return View();
        }

        protected override string RowViewName
        {
            get { return "ListItems/Meal"; }
        }
        
        public ActionResult GetMeal(int id)
        {
            return Json(new { Id = id, Content = this.RenderView(RowViewName, new[] { service.Get(id) }), Type = "meal" });
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            int w, h;
            var name = fileManagerService.SaveTempJpeg(Globals.PicturesPath, file.InputStream, out w, out h);
            return Json(new {name, type = file.ContentType, size = file.ContentLength, w, h});
        }

        public ActionResult ChangePicture(int id)
        {
            return View(service.Get(id));
        }

        [HttpPost]
        public ActionResult Crop(int x, int y, int w, int h, string filename, int id)
        {
            service.SetPicture(id, Globals.PicturesPath, filename, x, y, w, h);
            return Json(new {name = filename});
        }

        #region used only by internet explorer and opera (in header.ascx .cool and .notcool from rows are hidden/showed)

        public ActionResult OChangePicture(int id)
        {
            return View(service.Get(id));
        }

        [HttpPost]
        public ActionResult OChangePicture()
        {
            var file = Request.Files["fileUpload"];
            var id = Convert.ToInt32(Request.Form["id"]);

            if (file.ContentLength > 0)
            {
                int w, h;
                var name = fileManagerService.SaveTempJpeg(Globals.PicturesPath, file.InputStream, out w, out h);
                return RedirectToAction("ocrop",
                                        new CropInput {ImageWidth = w, ImageHeight = h, Id = id, FileName = name});
            }

            return RedirectToAction("Index");
        }

        public ActionResult OCrop(CropInput cropDisplay)
        {
            return View(cropDisplay);
        }

        [HttpPost]
        public ActionResult OCrop(int x, int y, int w, int h, int id, string filename)
        {
            service.SetPicture(id, Globals.PicturesPath, filename, x, y, w, h);
            return RedirectToAction("ochangepicture", new {id});
        }

        #endregion
        
    }
}