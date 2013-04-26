using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Wings.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  
        public int Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [MinLength(10),MaxLength(30)]
        public string UserName { get; set; }
        /// <summary>
        /// 登陆密码
        /// </summary>
        [StringLength(32)]
        [DataType(DataType.Password)] 
        public string PassWord { get; set; }
        /// <summary>
        /// 登陆ip
        /// </summary>
        [StringLength(15)]
        
        public string LogIp { get; set; }
        /// <summary>
        /// 登陆时间
        /// </summary>
        [Required]
        [DataType(DataType.DateTime)] 
        public DateTime LogTime { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        [Required]
        [DataType(DataType.DateTime)] 
        public DateTime RegTime { get; set; }
        /// <summary>
        /// QQ号
        /// </summary>
        [MaxLength(11)]
        public string QQ { get; set; }
        /// <summary>
        /// 邮箱
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        public string Email { get; set; }
        /// <summary>
        /// 账号状态 0:已删除 1 正常 2 未验证邮箱 -1 禁用
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 用户角色
        /// </summary>
        public int RId { get; set; }
        [ForeignKey("RId")]
        public virtual Role Role { get; set; }
        /// <summary>
        /// 身份证号  找回密码使用
        /// </summary>
        
        public string IDCard { get; set; }
        /// <summary>
        /// 真实姓名  找回密码使用
        /// </summary>
        [MaxLength(50)]
        public string RealName { get; set; }

        public virtual List<Reply> Replys { get; set; }
    }
    public enum StatusType
    {
        /// <summary>
        /// 已经删除
        /// </summary>
        Deleted =0,
        /// <summary>
        /// 正常
        /// </summary>
        Regular=1,
        /// <summary>
        /// 未验证，未启用
        /// </summary>
        Unverified=-1
    }
}
