using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Domain.Model
{
    /// <summary>
    /// 标示模块的领域的实体
    /// </summary>
    public class Module:AggregateRoot
    {
        /// <summary>
        /// 模块控制器
        /// </summary>
        public string Controller { get; set; }
        /// <summary>
        /// 模块访问点
        /// </summary>
        public string Action { get; set; }
        /// <summary>
        /// 说明 简介
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 父模块id
        /// </summary>
        public Guid PID { get; set; }
        /// <summary>
        /// 是否是按钮
        /// </summary>
        public bool IsButton { get; set; }
        /// <summary>
        /// 是否是扩展模块
        /// </summary>
        public bool IsPlugin { get; set; }
        /// <summary>
        /// 是否激活启用
        /// </summary>
        public bool IsActivate { get; set; }
    }
}
