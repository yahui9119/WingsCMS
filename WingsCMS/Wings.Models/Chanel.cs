using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Wings.Models
{
    [Table("Chanel")]
    public class Chanel
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20),MinLength(2)]
        [Required]
        [DataType(DataType.Text)] 
        public string ChanelName { get; set; }
        [Required]
        public int ChanelType{get;set;}
        [Required]
        public int ChanelIndex { get; set; }
        public virtual List<Content> Contexts { get; set; }
    }
}
