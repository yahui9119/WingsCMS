using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Domain.Model
{
    /// <summary>
    /// 标示模块领域的实体
    /// </summary>
    public class Module:AggregateRoot
    {
        public Module()
        {
            ChildModule = new List<Module>();
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
        public virtual Module ParentModule { get; set; }
        /// <summary>
        /// 子菜单
        /// </summary>
        public virtual List<Module> ChildModule { get; set; }
        /// <summary>
        /// 是否是菜单
        /// </summary>
        public virtual bool IsMenus { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public virtual bool IsActive { get; set; }
    }
}
