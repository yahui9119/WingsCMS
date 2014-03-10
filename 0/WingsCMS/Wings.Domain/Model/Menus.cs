using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Domain.Model
{
    /// <summary>
    /// 标示菜单领域的实体
    /// </summary>
    public class Menus:AggregateRoot
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
        /// 使用模块id
        /// </summary>
        public Guid ModuleID { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string ICON { get; set; }
        /// <summary>
        /// 排序索引
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// 父菜单标示
        /// </summary>
        public Guid PID { get; set; }
        
    }
}
