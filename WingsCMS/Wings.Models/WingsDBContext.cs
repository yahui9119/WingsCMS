using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Wings.Models
{
    public class WingsDBContext:DbContext
    {
        public WingsDBContext() : base("WingsDBContext")
        { }
        public DbSet<Chanel> Chanels { get; set; }
        public DbSet<Content> Content { get; set; }
        public DbSet<Module> Module { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
