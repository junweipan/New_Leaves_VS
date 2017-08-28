using New_Leaves.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace New_Leaves.Controllers
{
    public class HomeController : Controller
    {
        private icontest2Entities db = new icontest2Entities();
        //Get refugee by email
        public ActionResult Details(String email)
        {

            if (email == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Refugee refugee = db.Refugee.SingleOrDefault(r => r.Email == email);
            // User myUser = myDBContext.Users.SingleOrDefault(user => user.Username == username);
            if (refugee == null)
            {
                return HttpNotFound();
            }
            //Store your email (in the TempData)
            //TempData["id"] = refugee.RID;

            //Store your Student (in the Session)
            //Session["Student"] = oStudent;

            //return RedirectToAction("Details", "Refugees");
            return RedirectToAction("Details", "Refugees", new { id = refugee.RID });
            // return View(refugee);
        }
        public ActionResult IndexLogin()
        {
            return View("IndexLogin");

        }

        public ActionResult RefugeeIndex()
        {
            return View("RefugeeIndex");

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