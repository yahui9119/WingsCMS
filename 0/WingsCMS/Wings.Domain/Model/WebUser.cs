using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Domain.Model
{
    /// <summary>
    /// 标示站点和用户对应关系的领域实体
    /// </summary>
    public class WebUser:AggregateRoot
    {
        public WebUser() { }
        ///// <summary>
        ///// 初始化一个新的WebUser实体
        ///// </summary>
        ///// <param name="webid">站点标示</param>
        ///// <param name="userid">用户标示</param>
        //public WebUser(Guid webid, Guid userid)
        //{
        //    this.WebID = webid;
        //    this.UserID = userid;
        //}
        /// <summary>
        /// 获取或设置拥有站点的用户实体
        /// </summary>
        public virtual User user { get; set; }
        /// <summary>
        /// 获取或设置该所有的站点
        /// </summary>
        public virtual List<Web> webs { get; set; }
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
