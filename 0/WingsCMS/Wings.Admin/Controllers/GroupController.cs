using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wings.Contracts;
using Wings.DataObjects;
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
            DataObjectListWithPagination<RoleDTOList> pageData = new DataObjectListWithPagination<RoleDTOList>();
            using (ServiceProxy<IUserService> proxy = new ServiceProxy<IUserService>())
            {
                pageData = proxy.Channel.GetRolesByPage(p);
            }
            var result = new DataGrid() { total = pageData.pagination.TotalRecords, rows = pageData.DataObjectList };
            return Json(result);
        }
        [HttpPost]
        public ActionResult Add(RoleDTO role)
        {
            Result result = new Result();
            result.message = "添加角色失败";
            using (ServiceProxy<IUserService> proxy = new ServiceProxy<IUserService>())
            {
                role.CreateDate = DateTime.Now;
                role.EditDate = DateTime.Now;
                role.Status = Status.Active;
                role.Creator = null;
                RoleDTOList dtolist = new RoleDTOList();
                dtolist.Add(role);
                proxy.Channel.CreateRole(dtolist);
                if (!string.IsNullOrEmpty(role.ID))
                {
                    result.success = true;
                    result.message = "添加角色成功";
                }
            }
            return Json(result);
        }
        [HttpPost]
        public ActionResult Edit(RoleDTO role)
        {
            Result result = new Result();
            result.message = "修改角色失败";
            using (ServiceProxy<IUserService> proxy = new ServiceProxy<IUserService>())
            {
                role.EditDate = DateTime.Now;
                RoleDTOList dtolist = new RoleDTOList();
                dtolist.Add(role);
                proxy.Channel.EditRole(dtolist);
                if (!string.IsNullOrEmpty(role.ID))
                {
                    result.success = true;
                    result.message = "修改角色成功";
                }
            }
            return Json(result);
        }
        [HttpPost]
        public ActionResult Get(Guid ID)
        {
            RoleDTO roledto = new RoleDTO();
            using (ServiceProxy<IUserService> proxy = new ServiceProxy<IUserService>())
            {
                roledto = proxy.Channel.GetRoleByID(ID);
            }
            return Json(roledto);
        }
        [HttpPost]
        public ActionResult Delete(IDList idlist)
        {
            Result result = new Result();
            result.message = "删除角色失败";


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
            using (ServiceProxy<IUserService> proxy = new ServiceProxy<IUserService>())
            {
                try
                {

                    proxy.Channel.DeleteRole(ids);
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