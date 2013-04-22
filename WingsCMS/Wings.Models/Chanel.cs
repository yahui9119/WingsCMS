﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Wings.Models
{
    public class Chanel
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20),MinLength(5)]
        [Required]
        public string ChanelName { get; set; }
        [Required]
        public int ChanelType{get;set;}
        [Required]
        public int ChanelIndex { get; set; }
        public virtual List<Content> Contexts { get; set; }
    }
}
