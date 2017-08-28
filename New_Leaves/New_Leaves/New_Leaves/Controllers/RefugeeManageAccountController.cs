using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using New_Leaves.Models;

namespace New_Leaves.Controllers
{
    public class RefugeeManageAccountController : Controller
    {
        private icontest2Entities db = new icontest2Entities();
        // GET: RefugeeManageAccoun
        public ActionResult Index()
        {
            return View();
        }
        //Get refugee by email
        public ActionResult Details(String email)
        {
            if (email.Equals(""))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Refugee refugee = db.Refugee.SingleOrDefault(r => r.Email == email);
            // User myUser = myDBContext.Users.SingleOrDefault(user => user.Username == username);
            if (refugee == null)
            {
                return HttpNotFound();
            }
            return View(refugee);
        }
    }
}