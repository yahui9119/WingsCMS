using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Domain.Events
{
    public class UserUpdateModuleEvent:DomainEvent
    {
        public UserUpdateModuleEvent()
        { }
        public UserUpdateModuleEvent(IEntity entity):base(entity)
        { }
        /// <summary>
        /// 此次更新是否是禁用相应模块
        /// </summary>
        public bool IsBan { get; set; }
        /// <summary>
        /// 跟新用户的用户名字
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 更新的用户id
        /// </summary>
        public Guid UserID { get; set; }

    }
}
