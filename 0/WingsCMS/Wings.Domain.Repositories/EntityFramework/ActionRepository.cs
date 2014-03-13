using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Domain.Repositories.EntityFramework
{
    public class ActionRepository : EntityFrameworkRepository<Model.Action> ,IActionRepository
    {
        public ActionRepository(IRepositoryContext Context)
            : base(Context)
        {
 
        }
    }
}
