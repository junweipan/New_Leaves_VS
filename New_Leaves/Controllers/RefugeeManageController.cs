using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using New_Leaves.Models;
using System.Collections;

namespace New_Leaves.Controllers
{

    public class RefugeeManageController : Controller
    {
        // GET: RefugeeManage
        public ActionResult WishListIndex()
        {
            return View("ShowWishList");
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
            //List<object> list = new List<object>();
            //list.Add(id);
            //IEnumerable<object> fakeID = list;
            //ViewBag.fakeID = fakeID;
            ViewBag.id = new SelectList(db.Refugee.Where(a =>a.RID ==id), "RID", "RefugeeFName");
            ViewBag.id2 = id;
            return View();
        }
        // POST: Wish_List/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWishList([Bind(Include = "Wish_List_ID,RID,Item_ID,List_Submit_Date,Status")] Wish_List wish_List)
        {
           
            
               // wish_List.List_Submit_Date = DateTime.Now;
                if (ModelState.IsValid) {
               
                db.Wish_List.Add(wish_List);
                db.SaveChanges();
                return RedirectToAction("CreateWishList");
            }

            ViewBag.Item_ID = new SelectList(db.Item, "Item_ID", "Item_Name", wish_List.Item_ID);
            ViewBag.RID = new SelectList(db.Refugee, "RID", "RefugeeFName", wish_List.RID);
            return View(wish_List);
        }

        public ActionResult RefugeeModifyAccount(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Refugee refugee = db.Refugee.Find(id);
            if (refugee == null)
            {
                return HttpNotFound();
            }
            return View(refugee);
        }

        // POST: Refugees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RefugeeModifyAccount([Bind(Include = "RID,AthorityCode,RefugeeFName,RefugeeLName,Password,Postcode,Email,Street,Suburb,State,Phone,Family_Description,Icon")] Refugee refugee, int id)
        {
            int rid = id;
            if (ModelState.IsValid)
            {
                db.Entry(refugee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("RefugeeIndex","Home");
            }
            return View(refugee);
        }
    }
}