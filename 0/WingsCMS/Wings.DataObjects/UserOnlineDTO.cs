using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wings.DataObjects
{
    public class UserOnlineDTOList : List<UserOnlineDTO>
    { }
    public class UserOnlineDTO:BaseDTO
    {
        /// <summary>
        /// 在线的用户
        /// </summary>
        public virtual UserDTO user { get; set; }
        /// <summary>
        /// 已经在线的时间
        /// </summary>
        public virtual DateTime OnlineTime { get; set; }
        /// <summary>
        /// 在线的站点
        /// </summary>
        public virtual WebDTO web { get; set; }
        /// <summary>
        /// 当前是否在线
        /// </summary>
        public virtual bool IsOnline { get; set; }
    }
}
