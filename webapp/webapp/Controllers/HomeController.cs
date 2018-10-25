using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using webapp.Models;

using PagedList;

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

        //通过参数传递
        [HttpPost]
        public ActionResult AddInfo(string name, string age, string sex)
        {
            
            return Content($"姓名：{name} 年龄:{age} 性别:{sex}");
        }

        //通过Request来实现数据传递
        [HttpPost]
        public ActionResult AddInfo2()
        {

            return Content("姓名：" + Request["name"] + "年龄:" + Request["age"] + "性别:" + Request["sex"]);
        }

        //通过FormCollection传递
        [HttpPost]
        public ActionResult AddInfo3(FormCollection fcl)
        {

            return Content("姓名：" + fcl["name"] + "年龄:" + fcl["age"] + "性别:" + fcl["sex"]);
        }

        //通过类来传递
        [HttpPost]
        public ActionResult AddInfo4(UserInfo user)
        {

            //return Content("姓名：" + user.name + "年龄:" + user.age + "性别:" + user.sex);

            return View(user);

        }

        [HttpPost]
        public ActionResult AddInfo5(UserInfo user)
        {
         
            List<UserInfo> userlist = new List<UserInfo>();

            for (int i = 0; i < 100; i++)
            {
              

                userlist.Add(new UserInfo {
                    name = $"{i}-user",
                    age = i + 18,
                    sex = (i % 2) > 0 ? "男" : "女"

            });
            }
            int pageindex = 1;
            
            int pagesize = 10;

            return View(userlist.ToPagedList(pageindex,pagesize));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserInfo user)
        {
            return View("Details", user);
        }
        public ActionResult AddInfo6(int? page)
        {

            List<UserInfo> userlist = new List<UserInfo>();

            for (int i = 0; i < 100; i++)
            {


                userlist.Add(new UserInfo
                {
                    name = $"{i}-user",
                    age = i + 18,
                    sex = (i % 2) > 0 ? "男" : "女"

                });
            }
            int pageindex;
            if(page == null)
            { pageindex = 1; }
            else
            {
                 pageindex = (int)page;
            }
           
            int pagesize = 10;

            return View("AddInfo5",userlist.ToPagedList(pageindex, pagesize));
        }
    }
}