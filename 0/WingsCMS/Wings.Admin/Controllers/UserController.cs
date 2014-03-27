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
    public class UserController : WingsController
    {
        //
        // GET: /User/

        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult GetDataGrid(Pagination p)
        {
            DataObjectListWithPagination<UserDTOList> pageData = new DataObjectListWithPagination<UserDTOList>();
            using (ServiceProxy<IUserService> proxy = new ServiceProxy<IUserService>())
            {
                pageData = proxy.Channel.GetUsersByPage(p);
            }
            var result = new DataGrid() { total = pageData.pagination.TotalRecords, rows = pageData.DataObjectList };
            return Json(result);
        }
        [HttpPost]
        public ActionResult Add(UserDTO user)
        {
            Result result = new Result();
            result.message = "添加用户失败";
            using (ServiceProxy<IUserService> proxy = new ServiceProxy<IUserService>())
            {
                user.CreateDate = DateTime.Now;
                user.EditDate = DateTime.Now;
                
                user.Creator = null;
                user.LastloginTime = DateTime.Now;
                UserDTOList dtolist = new UserDTOList();
                dtolist.Add(user);
                proxy.Channel.CreateUser(dtolist);
                if (!string.IsNullOrEmpty(user.ID))
                {
                    result.success = true;
                    result.message = "添加角色成功";
                }
            }
            return Json(result);
        }
        [HttpPost]
        public ActionResult Edit(UserDTO user)
        {
            Result result = new Result();
            result.message = "修改用户失败";
            using (ServiceProxy<IUserService> proxy = new ServiceProxy<IUserService>())
            {
                user.EditDate = DateTime.Now;
                UserDTOList dtolist = new UserDTOList();
                dtolist.Add(user);
                proxy.Channel.EidtUser(dtolist);
                if (!string.IsNullOrEmpty(user.ID))
                {
                    result.success = true;
                    result.message = "修改用户成功";
                }
            }
            return Json(result);
        }
        [HttpPost]
        public ActionResult Get(Guid ID)
        {
            UserDTO userdto = new UserDTO();
            using (ServiceProxy<IUserService> proxy = new ServiceProxy<IUserService>())
            {
                userdto = proxy.Channel.GetUserByID(ID);
            }
            return Json(userdto);
        }
        [HttpPost]
        public ActionResult Delete(IDList idlist)
        {
            Result result = new Result();
            result.message = "删除用户失败";
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

                    proxy.Channel.DeleteUser(ids);
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
