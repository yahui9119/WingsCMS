using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Wings.Data
{
    public interface IDbContextFactory
    {
        DbContext GetContext();
    }

    public class DbContextFactory : IDbContextFactory
    {
        private readonly DbContext dbContext;
        public DbContextFactory()
        {
            dbContext = new Db();
        }

        public DbContext GetContext()
        {
            return dbContext;
        }
    }
}