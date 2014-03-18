using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wings.DataObjects
{
    public class ActionDTOList : List<ActionDTO>
    { 
    }
    /// <summary>
    /// 标示可访问点的领域的实体
    /// </summary>
    public class ActionDTO : BaseDTO
    {

          public ActionDTO()
        {
            ChildAction = new List<ActionDTO>();
        }
        public virtual WebDTO web { get; set; }
        /// <summary>
        /// 模块控制器
        /// </summary>
        public virtual  string Controller { get; set; }
        /// <summary>
        /// 模块访问点
        /// </summary>
        public virtual string ActionName { get; set; }
        /// <summary>
        /// 说明 简介
        /// </summary>
        public virtual string Description { get; set; }
        ///// <summary>
        ///// 父访问点
        ///// </summary>
        public virtual ActionDTO ParentAction { get; set; }
        /// <summary>
        /// 子访问点
        /// </summary>
        public virtual List<ActionDTO> ChildAction { get; set; }

        /// <summary>
        /// 是否是按钮
        /// </summary>
        public virtual bool IsButton { get; set; }
    }
}
