using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wings.DataObjects
{
    public class RoleDTOList : List<RoleDTO>
    { }
    public class RoleDTO : BaseDTO
    {
        /// <summary>
        /// 角色名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 简介说明
        /// </summary>
        public string Description { get; set; }
    }
}
