using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wings.Data
{
    public class WebDTO:BaseDTO
    {
        /// <summary>
        /// 站点名字
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 简介说明
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 域名
        /// </summary>
        public string Domain { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsActive { get; set; }
    }
}
