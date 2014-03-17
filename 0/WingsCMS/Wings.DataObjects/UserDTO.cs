using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wings.DataObjects
{
    public class UserDTOList : List<UserDTO>
    { }
    [Serializable]
    public class UserDTO:BaseDTO
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string PhoneNum { get; set; }
        /// <summary>
        /// 邮编号码
        /// </summary>
        public string Zip { get; set; }
        /// <summary>
        /// QQ账号
        /// </summary>
        public string QQ { get; set; }
        /// <summary>
        /// 阿里旺旺账号
        /// </summary>
        public string ALiWangWang { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 最后登陆时间
        /// </summary>
        public DateTime LastloginTime { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsActive { get; set; }
    }
}
