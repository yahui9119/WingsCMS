using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wings.Contracts;
using Wings.DataObjects;
using Wings.DataObjects.Custom;
using Wings.Framework.Communication;

namespace Wings.Admin.Controllers
{
    public class ModuleController : Controller
    {
        //
        // GET: /Module/
        [Description("[菜单管理【主页】]")]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Description("[分组管理【获取分组列表】]")]
        public ActionResult GetDataGrid(Pagination p)
        {
            var webid = Guid.Empty;
            ModuleDTOList groupdata = new ModuleDTOList();
            using (ServiceProxy<IWebService> proxy = new ServiceProxy<IWebService>())
            {
                groupdata = proxy.Channel.GetAllWebModules(webid);
            }
            groupdata.ForEach(g => g.ChildGroup = null);
            var result = new DataGrid() { total = groupdata.Count, rows = groupdata };
            return Json(result);
        }
        [HttpPost]
        [Description("[分组管理【获取树形列表】]")]
        public ActionResult Tree()
        {
            ModuleDTOList  ModuleDTOlist;
            using (ServiceProxy<IWebService> proxy = new ServiceProxy<IWebService>())
            {

                 ModuleDTOlist = proxy.Channel.GetGroupParentID(null);

            }
            return Json( ModuleDTOlist.ToTree());
        }

        [HttpPost]
        [Description("[分组管理【添加】]")]
        public ActionResult Add(ModuleDTO  ModuleDTO)
        {
            Result result = new Result();
            result.message = "添加部门失败";
            using (ServiceProxy<IWebService> proxy = new ServiceProxy<IWebService>())
            {
                 ModuleDTO.CreateDate = DateTime.Now;
                 ModuleDTO.EditDate = DateTime.Now;
                 ModuleDTO.Creator = null;
                 ModuleDTOList dtolist = new  ModuleDTOList();
                dtolist.Add( ModuleDTO);
                proxy.Channel.CreateGroup(dtolist);
                if (!string.IsNullOrEmpty( ModuleDTO.ID))
                {
                    result.success = true;
                    result.message = "添加部门成功";
                }
            }
            return Json(result);
        }
        [HttpPost]
        [Description("[分组管理【编辑】]")]
        public ActionResult Edit( ModuleDTO group)
        {
            Result result = new Result();
            result.message = "修改部门失败";
            using (ServiceProxy<IWebService> proxy = new ServiceProxy<IWebService>())
            {
                group.EditDate = DateTime.Now;
                ModuleDTOList dtolist = new ModuleDTOList();
                dtolist.Add(group);
                proxy.Channel.EditGroup(dtolist);
                if (!string.IsNullOrEmpty(group.ID))
                {
                    result.success = true;
                    result.message = "修改部门成功";
                }
            }
            return Json(result);
        }
        [HttpPost]
        [Description("[分组管理【获取】]")]
        public ActionResult Get(Guid ID)
        {
             ModuleDTO  ModuleDTO = new  ModuleDTO();
            using (ServiceProxy<IWebService> proxy = new ServiceProxy<IWebService>())
            {
                 ModuleDTO = proxy.Channel.GetGroupByID(ID);
            }
            return Json( ModuleDTO);
        }
        [HttpPost]
        [Description("[分组管理【标记删除】]")]
        public ActionResult Delete(IDList idlist)
        {
            Result result = new Result();
            result.message = "删除部门失败";


            if (idlist == null || idlist.Count == 0)
            {
                result.message = "您提交的数据为空，请重新选择!";
                return Json(result);
            }
            ModuleDTOList dtolist = new ModuleDTOList();
            idlist.Where(f => !string.IsNullOrEmpty(f)).ToList().ForEach(s =>
            {
                Guid temp = Guid.Empty;
                s.Split(',').ToList().ForEach(g =>
                {

                    if (Guid.TryParse(g, out temp))
                    {
                        dtolist.Add(new  ModuleDTO() { ID = g }); ;
                    }
                }
                    );
            });
            using (ServiceProxy<IWebService> proxy = new ServiceProxy<IWebService>())
            {
                try
                {

                    proxy.Channel.DeleteModule(dtolist);
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
