using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wings.Domain.Repositories.EntityFramework;

namespace Wings.Repository.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InitDB()
        {
            EntityFrameworkRepositoryContext context = new EntityFrameworkRepositoryContext();
            UserRepository ur = new UserRepository(context);
            var user= ur.GetUserByEmail("sdfsdf");
        }
    }
}
