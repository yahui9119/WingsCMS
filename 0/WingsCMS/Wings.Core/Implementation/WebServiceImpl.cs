using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Contracts;
using Wings.DataObjects;
using Wings.Domain.Model;
using Wings.Domain.Repositories;
using Wings.Domain.Specifications;
using Wings.Events.Bus;
using Wings.Framework;

namespace Wings.Core.Implementation
{
    public class WebServiceImpl : CoreService, IWebService
    {
        private readonly IModuleRepository moduleRepository;
        private readonly IWebRepository webRepository;
        private readonly IUserRepository userRepository;
        private readonly IEventBus bus;
        public WebServiceImpl(IRepositoryContext context,
            IWebRepository webRepository,
            IModuleRepository moduleRepository,
            IEventBus bus
            )
            : base(context)
        {
            this.bus = bus;
            this.moduleRepository = moduleRepository;
            this.webRepository = webRepository;
        }
        public void CreateWeb(DataObjects.WebDTO webdto)
        {
            throw new NotImplementedException();
        }

        public void EditWeb(DataObjects.WebDTO webdto)
        {
            throw new NotImplementedException();
        }

        public void DeleteWeb(Guid webid)
        {
            throw new NotImplementedException();
        }

        public UserDTOList GetUsersByWeb(Guid webid)
        {
            UserDTOList udtolist = new UserDTOList();
            var web = webRepository.GetByKey(webid);
            var users = userRepository.FindAll(Specification<User>.Eval(u => u.Webs.Contains(web)));
            foreach (var item in users)
            {
                udtolist.Add(Mapper.Map<User, UserDTO>(item));
            }
            return udtolist;
        }

        public DataObjects.DataObjectListWithPagination<DataObjects.WebDTOList> GetWebsByPage(DataObjects.Pagination pagination)
        {
            Specification<Web> starttime = Specification<Web>.Eval(u => pagination.StartTime != null ? u.CreateDate < pagination.StartTime : true);
            Specification<Web> endtime = Specification<Web>.Eval(u => pagination.EndTime != null ? u.CreateDate > pagination.EndTime : true);
            Specification<Web> likeword = Specification<Web>.Eval(u => (string.IsNullOrEmpty(pagination.LikeWord) ? u.Name.Contains(pagination.LikeWord) : true));
            PagedResult<Web> userpages = webRepository.GetAll(starttime.And(endtime).And(likeword), u => u.CreateDate, SortOrder.Descending, pagination.PageNumber, pagination.PageSize);
            DataObjectListWithPagination<WebDTOList> result = new DataObjectListWithPagination<WebDTOList>();
            if (userpages.Data != null)
            {
                userpages.Data.ForEach(u =>
                {
                    result.DataObjectList.Add(Mapper.Map<Web, WebDTO>(u));
                });
            }
            else { result.DataObjectList = new WebDTOList(); }
            result.pagination.PageNumber = userpages.PageNumber;
            result.pagination.PageSize = userpages.PageSize;
            result.pagination.TotalPages = userpages.TotalPages;
            result.pagination.TotalRecords = userpages.TotalRecords;
            return result;
        }

        public ModuleDTO CreateModule(Guid webid, DataObjects.ModuleDTO moduledto)
        {
            var module = Mapper.Map<ModuleDTO, Module>(moduledto);
            if (module.ParentModule != null && module.ParentModule.ID != null)
            {
                module.ParentModule = moduleRepository.Find(Specification<Module>.Eval(m => m.ID.Equals(module.ParentModule.ID)));
            }
            moduleRepository.Add(module);
            Context.Commit();
            return Mapper.Map<Module, ModuleDTO>(module);
        }

        public ModuleDTO EditModule(DataObjects.ModuleDTO moduledto)
        {
            var module = moduleRepository.Find(Specification<Module>.Eval(m => m.ID.Equals(Guid.Parse(moduledto.ID))));
            if (moduledto.ParentModule != null && moduledto.ParentModule.ID != null)
            {
                module.ParentModule = moduleRepository.Find(Specification<Module>.Eval(m => m.ID.Equals(Guid.Parse(moduledto.ParentModule.ID))));
            }
            module.Name = moduledto.Name;
            module.Description = moduledto.Description;
            module.EditDate = DateTime.Now;
            moduleRepository.Update(module);
            Context.Commit();
            return Mapper.Map<Module, ModuleDTO>(module);
        }

        public void DeleteModule(Guid moduleid)
        {
            var module = moduleRepository.Find(Specification<Module>.Eval(m => m.ID.Equals(moduleid)));
            module.Status = Wings.Domain.Model.Status.Deleted;
            moduleRepository.Update(module);
            Context.Commit();
        }


        public WebDTOList GetAllWebModules()
        {
            throw new NotImplementedException();
        }
    }
}
