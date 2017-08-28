using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using New_Leaves.Models;

namespace New_Leaves.Controllers
{

    public class RefugeeManageController : Controller
    {
        // GET: RefugeeManage
        public ActionResult Index()
        {
            return View();
        }
        private icontest2Entities db = new icontest2Entities();
        public ActionResult RefugeeDetails(String email)
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
            return View(refugee);
        }

        public ActionResult CreateWishList(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var wish_List = db.Wish_List.Include(w => w.Item).Include(w => w.Refugee);
            // User myUser = myDBContext.Users.SingleOrDefault(user => user.Username == username);
            if (wish_List == null)
            {
                return HttpNotFound();
            }
            return View(wish_List.ToList());
        }
    }
}