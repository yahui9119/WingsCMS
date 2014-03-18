using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wings.DataObjects
{
    public class WebDTOList : List<WebDTO>
    { }
    public class WebDTO:BaseDTO
    {
     public WebDTO()
        {
            Users = new List<UserDTO>();
            Modules = new List<ModuleDTO>();
        }
        /// <summary>
        /// 站点名字
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 简介说明
        /// </summary>
        public virtual string Description { get; set; }
        /// <summary>
        /// 域名
        /// </summary>
        public virtual string Domain { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public virtual bool IsActive { get; set; }
        /// <summary>
        /// 可管理该站点的用户列表
        /// </summary>
        public virtual List<UserDTO> Users { get; set; }
        /// <summary>
        /// 站点下菜单模块列表
        /// </summary>
        public virtual List<ModuleDTO> Modules { get; set; }
        /// <summary>
        /// 该站点拥有的访问点
        /// </summary>
        public virtual List<ActionDTO> Actions { get; set; }
    }
}
