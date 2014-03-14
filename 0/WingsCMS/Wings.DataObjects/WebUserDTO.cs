using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wings.Data
{
    public class WebUserDTO:BaseDTO
    {
        /// <summary>
        /// 获取或设置拥有站点的用户实体
        /// </summary>
        public virtual UserDTO user { get; set; }
        /// <summary>
        /// 获取或设置该所有的站点
        /// </summary>
        public virtual WebDTO web { get; set; }
        ///// <summary>
        ///// 站点标识
        ///// </summary>
        //public Guid WebID { get; set; }
        ///// <summary>
        ///// 用户标识
        ///// </summary>
        //public Guid UserID { get; set; }
        /// <summary>
        /// 是否拥有此站点的管理权限
        /// </summary>
        public bool IsActive { get; set; }
    }
}
