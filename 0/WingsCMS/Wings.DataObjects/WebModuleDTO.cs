using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wings.Data
{
    public class WebModuleDTO : BaseDTO
    {
        /// <summary>
        /// 站点id
        /// </summary>
        public Guid WebID { get; set; }
        /// <summary>
        /// 站点名字
        /// </summary>
        public string WebName { get; set; }
        /// <summary>
        /// 站点域名
        /// </summary>
        public string WebDomain { get; set; }
        public Dictionary<Guid, string> ModuleIDs { get; set; }

        /// <summary>
        /// 站点
        /// </summary>
        public WebDTO web { get; set; }
        /// <summary>
        /// 该站点包含的模块
        /// </summary>
        public List<ModuleDTO> Modules { get; set; }
    }
}
