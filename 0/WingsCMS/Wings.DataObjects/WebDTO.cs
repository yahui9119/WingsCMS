using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Wings.DataObjects
    
{

    public class WebDTOList : List<WebDTO>
    { }
    [DataContract]
    public class WebDTO:BaseDTO
    {
     public WebDTO()
        {
            Users = new List<UserDTO>();
            Modules = new List<ModuleDTO>();
        }
        [DataMember]
        /// <summary>
        /// 站点名字
        /// </summary>
        public virtual string Name { get; set; }
        [DataMember]
        /// <summary>
        /// 简介说明
        /// </summary>
        public virtual string Description { get; set; }
        [DataMember]
        /// <summary>
        /// 域名
        /// </summary>
        public virtual string Domain { get; set; }
        [DataMember]
        /// <summary>
        /// 是否启用
        /// </summary>
        public virtual bool IsActive { get; set; }
        [DataMember]
        /// <summary>
        /// 可管理该站点的用户列表
        /// </summary>
        public virtual List<UserDTO> Users { get; set; }
        [DataMember]
        /// <summary>
        /// 站点下菜单模块列表
        /// </summary>
        public virtual List<ModuleDTO> Modules { get; set; }
        [DataMember]
        /// <summary>
        /// 该站点拥有的访问点
        /// </summary>
        public virtual List<ActionDTO> Actions { get; set; }
    }
}
