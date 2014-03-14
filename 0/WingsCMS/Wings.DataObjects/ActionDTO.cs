using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wings.Data
{
    /// <summary>
    /// 标示可访问点的领域的实体
    /// </summary>
    public class ActionDTO : BaseDTO
    {

        /// <summary>
        /// 模块控制器
        /// </summary>
        public string Controller { get; set; }
        /// <summary>
        /// 模块访问点
        /// </summary>
        public string ActionName { get; set; }
        /// <summary>
        /// 说明 简介
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 子模块
        /// </summary>
        public List<ActionDTO> ChildModule { get; set; }
        /// <summary>
        /// 是否是按钮
        /// </summary>
        public bool IsButton { get; set; }
        /// <summary>
        /// 是否激活启用
        /// </summary>
        public bool IsActivate { get; set; }
    }
}
