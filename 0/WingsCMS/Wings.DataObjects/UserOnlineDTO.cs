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
        public UserDTO user { get; set; }
        /// <summary>
        /// 已经在线的时间
        /// </summary>
        public DateTime OnlineTime { get; set; }
        /// <summary>
        /// 在线的站点
        /// </summary>
        public WebDTO web { get; set; }
        /// <summary>
        /// 当前是否在线
        /// </summary>
        public bool IsOnline { get; set; }
    }
}
