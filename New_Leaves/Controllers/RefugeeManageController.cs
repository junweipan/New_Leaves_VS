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

        

        public ActionResult ShowWishList(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var wishlist = db.Wish_List.Where(a => a.RID == id);

            return View(wishlist);
        }

        public ActionResult CreateWishList(int? id)

        {
            ViewBag.Item_ID = new SelectList(db.Item, "Item_ID", "Item_Name");
            var wishlist = db.Wish_List.Where(a => a.RID == id);
            ViewBag.MyList = wishlist;


            // if (id == null)
            //   {
            //       return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //   }

            //   var wishlist = db.Wish_List.Where(a => a.RID == id);

            //   return View(wishlist.ToList());
            return View(wishlist);
        }

    }
}