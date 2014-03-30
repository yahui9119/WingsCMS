using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Wings.DataObjects
{

    public class ActionDTOList : List<ActionDTO>
    { 
    }
    /// <summary>
    /// 标示可访问点的领域的实体
    /// </summary>
    [DataContract]
    public class ActionDTO : BaseDTO
    {

          public ActionDTO()
        {
            ChildAction = new List<ActionDTO>();
        }
        [DataMember]
        public virtual WebDTO web { get; set; }
        /// <summary>
        /// 模块控制器
        /// </summary>
        [DataMember]
        public virtual  string Controller { get; set; }
        [DataMember]
        /// <summary>
        /// 模块访问点
        /// </summary>
        public virtual string ActionName { get; set; }
        [DataMember]
        /// <summary>
        /// 说明 简介
        /// </summary>
        public virtual string Description { get; set; }
        [DataMember]
        ///// <summary>
        ///// 父访问点
        ///// </summary>
        public virtual ActionDTO ParentAction { get; set; }
        [DataMember]
        /// <summary>
        /// 子访问点
        /// </summary>
        public virtual List<ActionDTO> ChildAction { get; set; }
        [DataMember]

        /// <summary>
        /// 是否是按钮
        /// </summary>
        public virtual bool IsButton { get; set; }
    }
}
