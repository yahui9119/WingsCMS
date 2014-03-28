using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Wings.DataObjects
{
    [Serializable]
    public class UserDTOList : List<UserDTO>
    { }
    [DataContract]
    public class UserDTO : BaseDTO
    {
        public UserDTO()
        {
            Roles = new List<RoleDTO>();
            Webs = new List<WebDTO>();
            Groups = new List<GroupDTO>();
        }
        [DataMember]
        /// <summary>
        /// 用户名
        /// </summary>
        public virtual string Account { get; set; }
        [DataMember]
        /// <summary>
        /// 真实姓名
        /// </summary>
        public virtual string RealName { get; set; }
        [DataMember]
        /// <summary>
        /// 密码
        /// </summary>
        public virtual string Password { get; set; }
        [DataMember]
        private bool _isman = false;
        [DataMember]
        /// <summary>
        /// 性别是否是男人
        /// </summary>
        public virtual bool IsMan
        {
            get
            {
                return _isman;
            }
            set
            {
                _isman = value;
            }
        }
        [DataMember]
        /// <summary>
        /// 性别 1 是男的 其他是0
        /// </summary>
        public virtual int Gender
        {
            get
            {
                return _isman ? 1 : 0;
            }
            set
            {
                this._isman = value == 1;
            }
        }
        [DataMember]
        private DateTime _birthday;
        [DataMember]
        /// <summary>
        /// 生日
        /// </summary>
        public virtual DateTime Birthday
        {
            get
            {
                return _birthday;
            }
            set
            {
                _birthday = value;
            }

        }
        [DataMember]
        /// <summary>
        /// 生日 字符串显示
        /// </summary>
        public virtual string BirthDays
        {
            get
            {
                string format = "yyyy-MM-dd";
                return _birthday != null ? _birthday.ToString(format) : DateTime.MinValue.AddSeconds(1).ToString(format);
            }
            set
            {
                DateTime datetemp = DateTime.MinValue.AddSeconds(1);
                DateTime.TryParse(value, out datetemp);
                _birthday = datetemp;

            }
        }
        [DataMember]
        /// <summary>
        /// 邮箱
        /// </summary>
        public virtual string Email { get; set; }
        [DataMember]
        /// <summary>
        /// 手机号码
        /// </summary>
        public virtual string PhoneNum { get; set; }
        [DataMember]
        /// <summary>
        /// 邮编号码
        /// </summary>
        public virtual string Zip { get; set; }
        [DataMember]
        /// <summary>
        /// QQ账号
        /// </summary>
        public virtual string QQ { get; set; }
        [DataMember]
        /// <summary>
        /// 阿里旺旺账号
        /// </summary>
        public virtual string ALiWangWang { get; set; }
        [DataMember]
        /// <summary>
        /// 地址
        /// </summary>
        public virtual string Address { get; set; }
        [DataMember]
        /// <summary>
        /// 最后登陆时间
        /// </summary>
        public virtual DateTime LastloginTime { get; set; }
        [DataMember]
        ///// <summary>
        ///// 是否启用
        ///// </summary>
        //public virtual bool IsActive { get; set; }
        /// <summary>
        /// 用户拥有角色列表 多对多
        /// </summary>
        public virtual List<RoleDTO> Roles { get; set; }
        [DataMember]
        /// <summary>
        /// 用户拥有站点列表 多对多
        /// </summary>
        public virtual List<WebDTO> Webs { get; set; }
        [DataMember]
        /// <summary>
        /// 用户所属部门列表 多对多
        /// </summary>
        public virtual List<GroupDTO> Groups { get; set; }
        [DataMember]
        /// <summary>
        /// 此用户拥有的模块
        /// </summary>
        public virtual List<ModuleDTO> ModuleAllow { get; set; }
        [DataMember]
        /// <summary>
        /// 此用户禁止使用的模块
        /// </summary>
        
        public virtual List<ModuleDTO> ModuleBan { get; set; }
        [DataMember]
        /// <summary>
        /// 已经拥有的角色
        /// </summary>
        public string HaveRoles
        {
            get;
            set;
        }
        [DataMember]
        /// <summary>
        /// 已经拥有的分组
        /// </summary>
        public string HaveGroups
        {
            get;
            set;
        }
        [DataMember]
        /// <summary>
        /// 已经拥有的站点
        /// </summary>
        public string HaveWebs
        {
            get;
            set;
        }
    }
}
