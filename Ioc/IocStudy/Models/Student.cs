﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IocStudy.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Student> Students { get; set; }
    }

    [Table("Student")]
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}