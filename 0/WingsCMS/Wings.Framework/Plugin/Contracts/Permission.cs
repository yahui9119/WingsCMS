using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Framework.Plugin.Contracts
{
    /// <summary>
    /// 权限数据契约
    /// </summary>
    [DataContract]
    public class Permission
    {
        /// <summary>
        /// 模块标示
        /// </summary>
        [DataMember]
        public Guid ModuleID { get; set; }
        /// <summary>
        /// 模块名字
        /// </summary>
        [DataMember]
        public string ModuleName { get; set; }
        /// <summary>
        /// 控制器
        /// </summary>
        [DataMember]
        public string Controller { get; set; }
        /// <summary>
        /// 访问点
        /// </summary>
        [DataMember]
        public string Action { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [DataMember]
        public string Description { get; set; }
        /// <summary>
        /// 是否是post提交的action
        /// </summary>
        [DataMember]
        public bool IsPost { get; set; }
    }
}
