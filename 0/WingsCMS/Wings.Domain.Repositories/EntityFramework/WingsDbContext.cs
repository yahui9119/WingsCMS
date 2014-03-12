using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;
using Wings.Domain.Repositories.EntityFramework.ModelConfig;

namespace Wings.Domain.Repositories.EntityFramework
{
    public sealed class WingsDbContext : DbContext
    {
        public WingsDbContext()
            : base("Wings")
        {
            this.Configuration.AutoDetectChangesEnabled = true;
            this.Configuration.LazyLoadingEnabled = true;

        }
        public DbSet<User> Users
        {
            get { return Set<User>(); }
        }
        public DbSet<Wings.Domain.Model.Action> Actions
        {
            get { return Set<Wings.Domain.Model.Action>(); }
        }
        public DbSet<Web> Webs
        {
            get { return Set<Web>(); }
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfig());
            modelBuilder.Configurations.Add(new ActionConfig());
            modelBuilder.Configurations.Add(new WebConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
