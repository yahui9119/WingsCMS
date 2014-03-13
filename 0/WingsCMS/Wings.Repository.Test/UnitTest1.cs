using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wings.Domain.Repositories.EntityFramework;
using Wings.Domain.Model;
using Wings.Domain.Specifications;
using System.Collections.Generic;

namespace Wings.Repository.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InitDB()
        {
            List<string> strs=new List<string> ();
            strs.Add("test11");
            strs.Add("test22");
            EntityFrameworkRepositoryContext context = new EntityFrameworkRepositoryContext();
            UserRepository ur = new UserRepository(context);
            User user = new User();
            user.Name = "test11";
            user.Password = "123456";
            user.PhoneNum = "15267189886";
            user.QQ = "123123123";
            user.Zip = "450000";
            user.Address = "sdfd";
            user.CreateDate = DateTime.Now;
            user.Creator = Guid.NewGuid();
            user.EditDate = DateTime.Now;
            user.Email = "sdf@df.com";
            user.LastloginTime = DateTime.Now;
             ur.Add(user);
           
            var getuser =ur.GetUserByEmail("sdf@df.com");
            var user2= ur.Find(Specification<User>.Eval(u => strs.Contains(u.Name)));
            
           
            user2.Name = "test11";
            user2.Password = "123456";
            user2.PhoneNum = "15267189886";
            user2.QQ = "123123123";
            user2.Zip = "450000";
            user2.Address = "sdfd";
            user2.CreateDate = DateTime.Now;
            user2.Creator = Guid.NewGuid();
            user2.EditDate = DateTime.Now;
            user2.Email = "sdf@df.com";
            user2.LastloginTime = DateTime.Now;
            ur.Remove(user2);
            context.Commit();
        }
    }
}
