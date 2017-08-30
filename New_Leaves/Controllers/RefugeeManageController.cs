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
            ViewBag.RID = id;
            return View(wishlist);
        }

        public ActionResult CreateWishList(int? id)

        {
            // GET: Wish_List/Create
            ViewBag.list = db.Wish_List.Where(a =>a.RID ==id);
            //Todo
            ViewBag.Item_ID = new SelectList(db.Item, "Item_ID", "Item_Name");
            ViewBag.RID = new SelectList(db.Refugee, "RID", "RefugeeFName");
            return View();
        }
        // POST: Wish_List/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWishList([Bind(Include = "Wish_List_ID,RID,Item_ID,List_Submit_Date,Status")] Wish_List wish_List)
        {
            if (ModelState.IsValid)
            {
                db.Wish_List.Add(wish_List);
                db.SaveChanges();
                return RedirectToAction("CreateWishList");
            }

            ViewBag.Item_ID = new SelectList(db.Item, "Item_ID", "Item_Name", wish_List.Item_ID);
            ViewBag.RID = new SelectList(db.Refugee, "RID", "RefugeeFName", wish_List.RID);
            return View(wish_List);
        }
    }
}