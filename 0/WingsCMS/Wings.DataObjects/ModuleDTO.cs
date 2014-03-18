using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wings.DataObjects
{
    public class ModuleDTOList : List<ModuleDTO>
    { }
    public class ModuleDTO:BaseDTO
    {
        public ModuleDTO()
        {
            ChildModule = new List<ModuleDTO>();
        }
        /// <summary>
        /// 菜单名
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 详情
        /// </summary>
        public virtual string Description { get; set; }
        /// <summary>
        /// 可访问点的id 
        /// </summary>
        public virtual Action Action { get; set; }
        ///// <summary>
        ///// 访问点的id
        ///// </summary>
        //public Guid ActionID { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public virtual string ICON { get; set; }
        /// <summary>
        /// 转跳链接
        /// </summary>
        public virtual string Url { get; set; }
        /// <summary>
        /// 排序索引
        /// </summary>
        public virtual int Index { get; set; }
        ///// <summary>
        ///// 父菜单标示
        ///// </summary>
        //public Guid ParentID { get; set; }
        /// <summary>
        /// 父栏目
        /// </summary>
        public virtual ModuleDTO ParentModule { get; set; }
        /// <summary>
        /// 子菜单
        /// </summary>
        public virtual List<ModuleDTO> ChildModule { get; set; }
        /// <summary>
        /// 是否是菜单
        /// </summary>
        public virtual bool IsMenus { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public virtual bool IsActive { get; set; }
        /// <summary>
        /// 拥有着的分组
        /// </summary>
        public virtual List<GroupDTO> Groups { get; set; }
        /// <summary>
        /// 拥有着的角色
        /// </summary>
        public virtual List<RoleDTO> Roles { get; set; }
        public virtual List<UserDTO> UserAllow { get; set; }
        public virtual List<UserDTO> UserBan { get; set; }
    }
}
