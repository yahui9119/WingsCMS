using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wings.DataObjects
{
    public class Pagination
    {
        /// <summary>
        /// 页索引
        /// </summary>
        public int PageNumber { get; set; }
        /// <summary>
        /// 单页显示大小
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 总共多少页
        /// </summary>
        public int? TotalPages { get; set; }
        /// <summary>
        /// 数据开始时间
        /// </summary>
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// 排序字段
        /// </summary>
        public string OrderField { get; set; }
        /// <summary>
        /// 是否倒叙排列
        /// </summary>
        public bool IsDesc { get; set; }
         
    }
}
