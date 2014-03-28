using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Wings.DataObjects
{

    public class RoleDTOList : List<RoleDTO>
    { }
    [DataContract]
    public class RoleDTO : BaseDTO
    {
         public RoleDTO()
        {
            Users = new List<UserDTO>();
        }
        [DataMember]
        /// <summary>
        /// 角色名
        /// </summary>
        public virtual string Name { get; set; }
        [DataMember]
        /// <summary>
        /// 简介说明
        /// </summary>
        public virtual string Description { get; set; }
        [DataMember]
        /// <summary>
        /// 拥有的用户列表
        /// </summary>
        public virtual List<UserDTO> Users { get; set; }
        [DataMember]
        /// <summary>
        /// 该角色拥有的模块
        /// </summary>
        public virtual List<ModuleDTO> Modules { get; set; }
    }
}
