using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Wings.Models
{
    /// <summary>
    /// 权限模块
    /// </summary>
    [Table("Module")]
    public class Module
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 权限名
        /// </summary>
        [DataType(DataType.Text)] 
        [MaxLength(50)]
        public string Name { get; set; }
        /// <summary>
        /// 对应角色
        /// </summary>
        public int RId { get; set; }
        [ForeignKey("RId")]
        public virtual Role Role { get; set; }
        /// <summary>
        /// 权限操作Url
        /// </summary>
        [DataType(DataType.Text)]
        [MaxLength(200)]
        public string Url { get; set; }
        [Required]//父模版的id
        public int PId { get; set; }
        [Required]
        public int ModuleType { get; set; }
    }
    //模版类型
    public enum ModuleType
    {
        Root=0,
        Action=1,
        ActionGroup=2
    }
}
