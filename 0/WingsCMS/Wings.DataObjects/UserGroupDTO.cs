using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wings.Data
{
    public class UserGroupDTO:BaseDTO
    {
        public Guid UserId { get; set; }
        public Dictionary<Guid, string> groupids { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public virtual UserDTO user { get; set; }
        /// <summary>
        /// 用户的分组
        /// </summary>
        public virtual List<GroupDTO> groups { get; set; }
    }
}
