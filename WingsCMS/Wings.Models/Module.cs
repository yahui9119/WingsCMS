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
        public int Name { get; set; }
        /// <summary>
        /// 对应角色
        /// </summary>
        public virtual Role Role { get; set; }
        /// <summary>
        /// 权限操作Url
        /// </summary>
        public string Url { get; set; }
    }
}
