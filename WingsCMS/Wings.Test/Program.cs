using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wings.Common;
using Wings.Models;

namespace Wings.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            //var blogDb = new BlogContext();
            //{
            //    Console.Write("Enter a name for a new blog:");
            //    var blogName = Console.ReadLine();
            //    var blog = new Blog { BlogName = blogName };
            //    blogDb.Blogs.Add(blog);
            //    blogDb.SaveChanges();

            //    var result = from b in blogDb.Blogs
            //                 select b;
            //    foreach (var item in result)
            //    {
            //        Console.WriteLine(item.BlogName);
            //    }
            //}
            Chanel c1=new Chanel (){  ChanelIndex=1 , ChanelName="新闻", ChanelType=1};
            Chanel c2=new Chanel (){  ChanelIndex=1 , ChanelName="体育", ChanelType=2};
            Chanel c3=new Chanel (){  ChanelIndex=1 , ChanelName="娱乐", ChanelType=3};
            using (WingsDBContext db=new WingsDBContext ())
            {
                db.Chanels.Add(c2);
                db.Chanels.Add(c3);
                db.SaveChanges();
            }
            Console.ReadKey();
        }
    }
}
