using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Wings.Models
{
    public class Content
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string Title { get; set; }
        [Required]
        public int Status { get; set; }
        [MaxLength(500)]
        [Required]
        public string Url { get; set; }
        public string Data { get; set; }
        [Required]
        public DateTime CreateTime { get; set; }
        
        public virtual Chanel Chanel { get; set; }
    }
}
