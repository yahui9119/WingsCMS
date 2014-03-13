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
        public DbSet<Group> Groups
        {
            get { return Set<Group>(); }
        }
        public DbSet<Module> Modules
        {
            get { return Set<Module>(); }
        }
        public DbSet<Permission> Permissions
        {
            get { return Set<Permission>(); }
        }
        public DbSet<Role> Roles
        {
            get { return Set<Role>(); }
        }
        public DbSet<UserGroup> UserGroups
        {
            get { return Set<UserGroup>(); }
        }
        public DbSet<UserOnline> UserOnlines
        {
            get { return Set<UserOnline>(); }
        }
        public DbSet<UserRole> UserRoles
        {
            get { return Set<UserRole>(); }
        }
        public DbSet<Web> Webs
        {
            get { return Set<Web>(); }
        }
        public DbSet<WebModule> WebModules
        {
            get { return Set<WebModule>(); }
        }
        public DbSet<WebUser> WebUsers
        {
            get { return Set<WebUser>(); }
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfig());
            modelBuilder.Configurations.Add(new ActionConfig());
            modelBuilder.Configurations.Add(new GroupConfig());

            modelBuilder.Configurations.Add(new ModuleConfig());
            modelBuilder.Configurations.Add(new PermissionConfig());
            modelBuilder.Configurations.Add(new RoleConfig());

            modelBuilder.Configurations.Add(new UserGroupConfig());
            modelBuilder.Configurations.Add(new UserOnlineConfig());
            modelBuilder.Configurations.Add(new UserRoleConfig());

            modelBuilder.Configurations.Add(new WebConfig());
            modelBuilder.Configurations.Add(new WebModuleConfig());
            modelBuilder.Configurations.Add(new WebUserConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
