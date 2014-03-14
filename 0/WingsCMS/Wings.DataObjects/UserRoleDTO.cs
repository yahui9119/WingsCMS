using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wings.Data
{
    public class UserRoleDTO:BaseDTO
    {
        public Guid UserID { get; set; }
        public Dictionary<Guid, string> RoleIDs { }
        /// <summary>
        /// 获取或设置站点用户
        /// </summary>
        public virtual UserDTO user { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public virtual List<RoleDTO> roles { get; set; }
    }
}

