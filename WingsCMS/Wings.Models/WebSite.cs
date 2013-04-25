using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Wings.Models
{
    [Table("WebSite")]
    public class WebSite
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Domain { get; set; }
        [MaxLength(500)]
        public string Tag { get; set; }
        [Required]
        public DateTime CreateTime { get; set; }
        [Required]//创建用户id
        public int UId{get;set;}
        //[ForeignKey("UId")]
        //public virtual User CreateUser { get; set; }

        public virtual List<Chanel> Chanels { get; set; }
    }
}
