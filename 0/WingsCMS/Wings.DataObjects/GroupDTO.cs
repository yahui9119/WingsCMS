using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wings.DataObjects
{
    public class GroupDTOList : List<GroupDTO>
    { }
    public class GroupDTO:BaseDTO
    {
        public GroupDTO()
        {
            ChildGroup = new List<GroupDTO>();
            Users = new List<UserDTO>();
        }
        /// <summary>
        /// 分组名字
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 简介说明
        /// </summary>
        public virtual string Description { get; set; }
        /// <summary>
        /// 父组
        /// </summary>
        public virtual GroupDTO ParentGroup { get; set; }
        /// <summary>
        /// 子分组
        /// </summary>
        public virtual List<GroupDTO> ChildGroup { get; set; }
        /// <summary>
        /// 该分组下的用户
        /// </summary>
        public virtual List<UserDTO> Users { get; set; }
        /// <summary>
        /// 该用户组拥有的模块
        /// </summary>
        public virtual List<ModuleDTO> Modules { get; set; }
    }
}
