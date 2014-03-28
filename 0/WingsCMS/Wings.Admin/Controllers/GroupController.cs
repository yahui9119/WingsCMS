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
    public class GroupController : WingsController
    {
        //
        // GET: /Group/

        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult GetDataGrid(Pagination p)
        {
            GroupDTOList groupdata = new GroupDTOList();
            using (ServiceProxy<IUserService> proxy = new ServiceProxy<IUserService>())
            {
                groupdata = proxy.Channel.GetAllGroups();
            }
            groupdata.ForEach(g => g.ChildGroup = null);
            var result = new DataGrid() { total = groupdata.Count, rows = groupdata };
            return Json(result);
        }
        [HttpPost]
        public ActionResult Tree()
        {
            GroupDTOList groupdtolist;
            using (ServiceProxy<IUserService> proxy = new ServiceProxy<IUserService>())
            {
               
               groupdtolist= proxy.Channel.GetGroupParentID(null);
               
            }
            return Json(groupdtolist.ToTree());
        }
        [HttpPost]
        public ActionResult Add(GroupDTO groupdto)
        {
            Result result = new Result();
            result.message = "添加部门失败";
            using (ServiceProxy<IUserService> proxy = new ServiceProxy<IUserService>())
            {
                groupdto.CreateDate = DateTime.Now;
                groupdto.EditDate = DateTime.Now;
                groupdto.Creator = null;
                GroupDTOList dtolist = new GroupDTOList();
                dtolist.Add(groupdto);
                proxy.Channel.CreateGroup(dtolist);
                if (!string.IsNullOrEmpty(groupdto.ID))
                {
                    result.success = true;
                    result.message = "添加部门成功";
                }
            }
            return Json(result);
        }
        [HttpPost]
        public ActionResult Edit(GroupDTO group)
        {
            Result result = new Result();
            result.message = "修改部门失败";
            using (ServiceProxy<IUserService> proxy = new ServiceProxy<IUserService>())
            {
                group.EditDate = DateTime.Now;
                GroupDTOList dtolist = new GroupDTOList();
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
        public ActionResult Get(Guid ID)
        {
            GroupDTO groupdto = new GroupDTO();
            using (ServiceProxy<IUserService> proxy = new ServiceProxy<IUserService>())
            {
                groupdto = proxy.Channel.GetGroupByID(ID);
            }
            return Json(groupdto);
        }
        [HttpPost]
        public ActionResult Delete(IDList idlist)
        {
            Result result = new Result();
            result.message = "删除部门失败";


            if (idlist == null || idlist.Count == 0)
            {
                result.message = "您提交的数据为空，请重新选择!";
                return Json(result);
            }
            GroupDTOList dtolist = new GroupDTOList();
            idlist.Where(f => !string.IsNullOrEmpty(f)).ToList().ForEach(s =>
            {
                Guid temp = Guid.Empty;
                s.Split(',').ToList().ForEach(g =>
                {

                    if (Guid.TryParse(g, out temp))
                    {
                        dtolist.Add(new GroupDTO() { ID = g }); ;
                    }
                }
                    );
            });
            using (ServiceProxy<IUserService> proxy = new ServiceProxy<IUserService>())
            {
                try
                {

                    proxy.Channel.DeleteGroup(dtolist);
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