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
        public DbSet<WebSite> WebSite { get; set; }
        public DbSet<Reply> Reply { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Reply>().HasRequired(u => u.User).WithMany(
              r => r.Replys).HasForeignKey(u => u.UId).WillCascadeOnDelete(false);//指定
            modelBuilder.Entity<Reply>().HasRequired(r=>r.Content);
        }
    }
}
