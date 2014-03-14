using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Domain.Model
{
    /// <summary>
    /// 表示用户领域的值的对象
    /// </summary>
    public class User:AggregateRoot
    {
        public User()
        {
            Roles = new List<Role>();
            Webs = new List<Web>();
            Groups = new List<Group>();
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public virtual string Account { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public virtual string RealName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public virtual string Password { get; set; }
        /// <summary>
        /// 性别是否是男人
        /// </summary>
        public virtual bool IsMan { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public virtual DateTime Birthday { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public virtual string Email { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public virtual string PhoneNum { get; set; }
        /// <summary>
        /// 邮编号码
        /// </summary>
        public virtual string Zip { get; set; }
        /// <summary>
        /// QQ账号
        /// </summary>
        public virtual string QQ { get; set; }
        /// <summary>
        /// 阿里旺旺账号
        /// </summary>
        public virtual string ALiWangWang { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public virtual string Address { get; set; }
        /// <summary>
        /// 最后登陆时间
        /// </summary>
        public virtual DateTime LastloginTime { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public virtual bool IsActive { get; set; }
        /// <summary>
        /// 用户拥有角色列表 多对多
        /// </summary>
        public virtual List<Role> Roles { get; set; }
        /// <summary>
        /// 用户拥有站点列表 多对多
        /// </summary>
        public virtual List<Web> Webs { get; set; }
        /// <summary>
        /// 用户所属部门列表 多对多
        /// </summary>
        public virtual List<Group> Groups { get; set; }
        
    }
}
