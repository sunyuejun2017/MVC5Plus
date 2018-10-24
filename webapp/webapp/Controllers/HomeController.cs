using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webapp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult AddInfo(string name, string age, string sex)
        {
            
            return Content($"姓名：{name} 年龄:{age} 性别:{sex}");
        }

        [HttpPost]
        public ActionResult AddInfo2()
        {

            return Content("姓名：" + Request["name"] + "年龄:" + Request["age"] + "性别:" + Request["sex"]);
        }

        [HttpPost]
        public ActionResult AddInfo3(FormCollection fcl)
        {

            return Content("姓名：" + fcl["name"] + "年龄:" + fcl["age"] + "性别:" + fcl["sex"]);
        }
    }
}