using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wings.Data
{
    public class GroupDTO:BaseDTO
    {
        /// <summary>
        /// 分组名字
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 简介说明
        /// </summary>
        public string Description { get; set; }
        ///// <summary>
        ///// 父分组的标示
        ///// </summary>
        //public Guid ParentID { get; set; }
        ///// <summary>
        ///// 父组
        ///// </summary>
        //public Group ParentGroup { get; set; }
        /// <summary>
        /// 子分组
        /// </summary>
        public List<GroupDTO> ChildGroup { get; set; }
    }
}
