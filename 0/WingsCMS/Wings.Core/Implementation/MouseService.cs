using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Contracts;
using Wings.Domain.Repositories;
using Wings.Domain.Services;

namespace Wings.Core.Implementation
{
    /// <summary>
    /// 实现
    /// </summary>
    public class MouseService : CoreService, IMouseService
    {
        private readonly IMouseRepository mouseRepository;
        private readonly IDomainService domainService;

        public MouseService(IRepositoryContext context, IMouseRepository mouseRepository, IDomainService domainService)
            : base(context)
        {
            this.domainService = domainService;
            this.mouseRepository = mouseRepository;
        }
        public void Cry(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
