using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IocStudy.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var studentRepository = new StudentRepository();
            var students = studentRepository.GetStudents();//调用数据层方法，获取数据
            return View(students);
            return View();
        }

    }
}
