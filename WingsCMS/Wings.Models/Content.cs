using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Wings.Models
{
    [Table("Content")]
    public class Content
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        [DataType(DataType.Text)] 
        public string Title { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string EnglishTitle { get; set; }
        [Required]
        public int Status { get; set; }
        [MaxLength(500)]
        [Required]
        [DataType(DataType.Url)] 
        public string Url { get; set; }
        [MaxLength(500)]
        [DataType(DataType.ImageUrl)]
        public string Img { get; set; }
        [Required]
        [DataType(DataType.MultilineText)] 
        public string Data { get; set; }
        [Required]
        [DataType(DataType.DateTime)] 
        public DateTime CreateTime { get; set; }
        [MaxLength(100)]
        [DataType(DataType.Text)] 
        public string Tag { get; set; }
        [Required]
        public int CId { get;set; }
        [ForeignKey("CId")]
        public virtual Chanel Chanel { get; set; }

        public virtual List<Reply> Replys { get; set; }
    }
}
