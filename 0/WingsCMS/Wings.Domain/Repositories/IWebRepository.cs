﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;

namespace Wings.Domain.Repositories
{
    /// <summary>
    /// 标示站点的仓库接口
    /// </summary>
    public interface IWebRepository:IRepository<Web>
    {
    }
}
