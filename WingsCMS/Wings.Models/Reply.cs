using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Wings.Models
{
    [Table("Reply")]
    public class Reply
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(1000)]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime CreateTime { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Eamil { get; set; }
        [DataType(DataType.Text)]

        public string NickName { get; set; }
        
        public int UId { get; set; }
        [Required]
        public int CId { get; set; }
        [ForeignKey("CId")]
        public virtual Content Content { get; set; }

        [ForeignKey("UId")]
        public virtual User User { get; set; }
        /// <summary>
        /// 父留言
        /// </summary>
        public int PId { get; set; }
    }
}
