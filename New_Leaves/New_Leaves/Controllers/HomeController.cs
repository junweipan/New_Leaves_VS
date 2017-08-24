using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace New_Leaves.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult IndexLogin()
        {
            return View("IndexLogin");

        }
       
        public ActionResult Index()
        {
            return View("Index");

        }
        public ActionResult Team()
           
        {
           

            return View("team");
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
    }
}