using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wings.BLL;
using Wings.Common;
using Wings.Models;

namespace Wings.CMS.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        
        public ActionResult Index()
        {
            ViewBag.login = false;
            return View();
        }
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public JsonResult login(string username, string password)
        {
            if (username==password)
            {
                return Json("domain");
            }
            else
            {
                return Json("index");
            }
        }
        public ActionResult Post()
        {
            ViewData["CId"] = GetChanelSelectList();
            return View();
        }
        ChanelsBll chanelbll = new ChanelsBll();
        ContentsBll contextbll = new ContentsBll();
        /// 获取栏目列表
        private List<SelectListItem> GetChanelSelectList()
        {
            var chanels = chanelbll.Load(c => true);
            List<SelectListItem> slt = new List<SelectListItem>();
            chanels.ForEach(c =>
            {
                slt.Add(new SelectListItem() { Value = c.Id.ToString(), Text = c.ChanelName});
            });
            return slt;
        }
        [ValidateInput(false)]//这里安全验证关掉
        [HttpPost]
        public JsonResult Post(FormCollection collection)
        {
            ResultDWZ rdwz = new ResultDWZ();
            int Cid = Convert.ToInt32(collection["CId"]);
            var content = new Content()
            {
                CreateTime = DateTime.Now,
                Data = collection["Data"],
                Img = collection["Img"] == null ? "" : collection["Img"],
                Status = Convert.ToInt32(collection["Status"]),
                Tag = collection["Tag"],
                Title = collection["Title"],
                Url = collection["Url"] == null ? "http://localhost" : collection["Url"]
                ,
                CId = Cid
            };
            try
            {

                if (contextbll.Add(content).Id > 0)
                {
                    rdwz.statusCode = "200";
                    rdwz.message = "操作成功";
                    rdwz.callbackType = "closeCurrent";
                    return Json(rdwz);
                }
                else
                {
                    rdwz.statusCode = "300";
                    rdwz.message = "操作失败，请联系管理员";
                    rdwz.callbackType = "closeCurrent";
                    return Json(rdwz);
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                rdwz.statusCode = "300";
                rdwz.message = ex.ToString();
                rdwz.callbackType = "closeCurrent";
                return Json(rdwz);
            }


        }
        public ActionResult domain()
        {
            return View();
        }
    }
}
