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
        /// <summary>
        /// 菜单名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 详情
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 可访问点的id 
        /// </summary>
        public Action Action { get; set; }
        ///// <summary>
        ///// 访问点的id
        ///// </summary>
        //public Guid ActionID { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string ICON { get; set; }
        /// <summary>
        /// 转跳链接
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 排序索引
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// 子菜单
        /// </summary>
        public List<ModuleDTO> ChildModule { get; set; }
        /// <summary>
        /// 是否是菜单
        /// </summary>
        public bool IsMenus { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsActive { get; set; }
    }
}
