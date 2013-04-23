using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Wings.Models
{
    /// <summary>
    /// 用户角色
    /// </summary>
    [Table("Role")]
    public class Role
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 角色名
        /// </summary>
        public int Name { get; set; }
        /// <summary>
        /// 角色对应模块
        /// </summary>
        public virtual List<Module> Modules { get; set; }
    }
}
