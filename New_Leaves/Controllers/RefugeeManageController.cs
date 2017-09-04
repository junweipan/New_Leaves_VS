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
        private newleavesdatabaseEntities db = new newleavesdatabaseEntities();

        public ActionResult RefugeeDetails(String code)
        {

            if (code == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Refugee refugee = db.Refugee.SingleOrDefault(r => r.AuthorityCode == code);
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
           
            ViewBag.id = new SelectList(db.Refugee.Where(a =>a.RID ==id), "RID", "RefugeeFName");
            ViewBag.rid = id;
            return View();
        }
        // POST: Wish_List/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWishList([Bind(Include = "Wish_List_ID,RID,Item_ID,Create_Date,Hope_Delivery_Date,Status,Description")] Wish_List wish_List)
        {
            if (wish_List != null)
            {   
                wish_List.Create_Date = DateTime.Now;
                wish_List.Status = "Not deliverd";
            }
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
        public ActionResult RefugeeModifyAccount([Bind(Include = "RID,AuthorityCode,RefugeeFName,RefugeeLName,Password,Postcode,Email,Street,Suburb,State,Phone,Family_Description,Icon")] Refugee refugee, int id)
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

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wish_List wish_List = db.Wish_List.Find(id);
            if (wish_List == null)
            {
                return HttpNotFound();
            }
            return View(wish_List);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wish_List wish_List = db.Wish_List.Find(id);
            int rid = (int)wish_List.RID;
            db.Wish_List.Remove(wish_List);
            db.SaveChanges();
           //Refugee refugee = db.Refugee.SingleOrDefault(w => w.Wish_List == id);
            return RedirectToAction("ShowWishList",new {id = rid });
        }
    }
}