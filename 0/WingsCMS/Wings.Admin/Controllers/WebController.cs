using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wings.Contracts;
using Wings.DataObjects;
using Wings.DataObjects.Custom;
using Wings.Framework.Communication;
using Wings.Framework.Plugin;

namespace Wings.Admin.Controllers
{
    public class WebController : WingsController
    {
        //
        // GET: /Web/

        //
        // GET: /Web/
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult GetDataGrid(Pagination p)
        {
            DataObjectListWithPagination<WebDTOList> pageData = new DataObjectListWithPagination<WebDTOList>();
            using (ServiceProxy<IWebService> proxy = new ServiceProxy<IWebService>())
            {
                pageData = proxy.Channel.GetWebsByPage(p);
            }
            var result = new DataGrid() { total = pageData.pagination.TotalRecords, rows = pageData.DataObjectList };
            return Json(result);
        }
        [HttpPost]
        public ActionResult Tree()
        {
            WebDTOList groupdtolist;
            using (ServiceProxy<IWebService> proxy = new ServiceProxy<IWebService>())
            {

                groupdtolist = proxy.Channel.GetAllWebs();

            }
            return Json(groupdtolist.ToTree());
        }
        [HttpPost]
        public ActionResult Add(WebDTO Web)
        {
            Result result = new Result();
            result.message = "添加站点失败";
            using (ServiceProxy<IWebService> proxy = new ServiceProxy<IWebService>())
            {
                Web.CreateDate = DateTime.Now;
                Web.EditDate = DateTime.Now;
                Web.Status = Status.Active;
                Web.Creator = null;
                WebDTOList dtolist = new WebDTOList();
                dtolist.Add(Web);
                proxy.Channel.CreateWeb(dtolist);
                if (!string.IsNullOrEmpty(Web.ID))
                {
                    result.success = true;
                    result.message = "添加站点成功";
                }
            }
            return Json(result);
        }
        [HttpPost]
        public ActionResult Edit(WebDTO Web)
        {
            Result result = new Result();
            result.message = "修改站点失败";
            using (ServiceProxy<IWebService> proxy = new ServiceProxy<IWebService>())
            {
                Web.EditDate = DateTime.Now;
                WebDTOList dtolist = new WebDTOList();
                dtolist.Add(Web);
                proxy.Channel.EditWeb(dtolist);
                if (!string.IsNullOrEmpty(Web.ID))
                {
                    result.success = true;
                    result.message = "修改站点成功";
                }
            }
            return Json(result);
        }
        [HttpPost]
        public ActionResult Get(Guid ID)
        {
            WebDTO Webdto = new WebDTO();
            using (ServiceProxy<IWebService> proxy = new ServiceProxy<IWebService>())
            {
                Webdto = proxy.Channel.GetWebByID(ID);
            }
            return Json(Webdto);
        }
        [HttpPost]
        public ActionResult Delete(IDList idlist)
        {
            Result result = new Result();
            result.message = "删除站点失败";


            if (idlist == null || idlist.Count == 0)
            {
                result.message = "您提交的数据为空，请重新选择!";
                return Json(result);
            }
            IDList ids = new IDList();

            idlist.Where(f => !string.IsNullOrEmpty(f)).ToList().ForEach(s =>
            {
                Guid temp = Guid.Empty;
                s.Split(',').ToList().ForEach(g =>
                {

                    if (Guid.TryParse(g, out temp))
                    {
                        ids.Add(g);
                    }
                }
                    );
            });
            using (ServiceProxy<IWebService> proxy = new ServiceProxy<IWebService>())
            {
                try
                {

                    proxy.Channel.DeleteWeb(ids);
                    result.success = true;
                    result.message = "删除成功";
                }
                catch (Exception ex)
                {
                    result.message = ex.Message;
                }

            }
            return Json(result);
        }

    }
}
