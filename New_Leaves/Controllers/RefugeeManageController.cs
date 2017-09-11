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
        private newleavesdatabaseEntities1 db = new newleavesdatabaseEntities1();

        [Authorize]
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
        [Authorize]
        public ActionResult RefugeeDetailsAfter(String code)
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
            ViewData["Title1"] = "Change Password Successfully";
            return View("RefugeeDetails",refugee);
        }


        [Authorize]
        public ActionResult ShowWishList(string code)
        {
            if (code == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var wishlist = db.Wish_List.Where(a => a.AuthorityCode == code);
            ViewBag.RID = code;
            return View(wishlist);
        }
        //get the wishlist id
        //1, delete the wishlist in wishlist table
        //2,chage the value in donation table
        public ActionResult Received(int id)
        {
           
            //delete the wishlist(make this record invisible)
            Wish_List wish_List = db.Wish_List.Find(id);
            wish_List.Status = "Completed";
            db.Entry(wish_List).State = EntityState.Modified;
            db.SaveChanges();
            //change information in donation table
            Donation donation = wish_List.Donation.Where(d=>d.Wish_List_ID==id).FirstOrDefault();
            donation.Status = "Completed";
            db.Entry(donation).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ShowWishList", new { code = User.Identity.Name });
        }
        [Authorize]
        public ActionResult CreateWishList(string code)
          
        {
            if (code == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Refugee refugee = db.Refugee.Where(a => a.AuthorityCode == code).FirstOrDefault();
            if (refugee == null)
            {
                return HttpNotFound();
            }            
                int id = refugee.RID;
                // GET: Wish_List/Create                       
                ViewBag.list = db.Wish_List.Where(a => a.RID == id);
                //Todo
                ViewBag.Item_ID = new SelectList(db.Item, "Item_ID", "Item_Name");
                ViewBag.RID = new SelectList(db.Refugee, "RID", "RefugeeFName");

                ViewBag.id = new SelectList(db.Refugee.Where(a => a.RID == id), "RID", "RefugeeFName");
                ViewBag.rid = id;
           
            return View();
        }
        // POST: Wish_List/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWishList([Bind(Include = "Wish_List_ID,RID,Item_ID,Create_Date,Hope_Delivery_Date,Status,Description")] Wish_List wish_List)
        {
            if (wish_List != null)
            {   
                wish_List.Create_Date = DateTime.Now;
                wish_List.Status = "Not deliverd";
                wish_List.AuthorityCode = User.Identity.Name;
                
            }
            if (ModelState.IsValid) {
            
                db.Wish_List.Add(wish_List);
                db.SaveChanges();
                return RedirectToAction("CreateWishList", new { code = User.Identity.Name});
            }

            ViewBag.Item_ID = new SelectList(db.Item, "Item_ID", "Item_Name", wish_List.Item_ID);
            ViewBag.RID = new SelectList(db.Refugee, "RID", "RefugeeFName", wish_List.RID);
            return View(wish_List);
        }

        [Authorize]
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
        [Authorize]
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

        [Authorize]
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

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wish_List wish_List = db.Wish_List.Find(id);
            wish_List.Status = "Deleted";
            db.Entry(wish_List).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ShowWishList",new {code = User.Identity.Name });
        }

        public ActionResult Edit(int? id)
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
            ViewBag.Item_ID = new SelectList(db.Item, "Item_ID", "Item_Name", wish_List.Item_ID);
            ViewBag.RID = new SelectList(db.Refugee.Where(r=>r.RID == wish_List.RID), "RID", "RefugeeFName", wish_List.RID);
            return View(wish_List);
        }

        // POST: Wish_List/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Wish_List_ID,RID,Item_ID,Create_Date,Hope_Delivery_Date,Status,Description,AuthorityCode")] Wish_List wish_List)
        {   
            if (wish_List != null)
            {
                wish_List.Create_Date = DateTime.Now;
            }
            if (ModelState.IsValid)
            {
                db.Entry(wish_List).State = EntityState.Modified;
                db.SaveChanges();
                
                return RedirectToAction("ShowWishList", new { code = User.Identity.Name });
            }
            ViewBag.Item_ID = new SelectList(db.Item, "Item_ID", "Item_Name", wish_List.Item_ID);
            ViewBag.RID = new SelectList(db.Refugee, "RID", "RefugeeFName", wish_List.RID);
            return View(wish_List);
        }

        public ActionResult ChangePassword(string code)
        {
            if (code == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Refugee refugee = db.Refugee.SingleOrDefault(r => r.AuthorityCode == code);
           
            // User myUser = myDBContext.Users.SingleOrDefault(user => user.Username == username);

            return View(refugee);
        }
        public ActionResult ChangePasswordNon(string code)
        {
            if (code == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Refugee refugee = db.Refugee.SingleOrDefault(r => r.AuthorityCode == code);
            ViewData["Non"] = "The old password didn't match";
            // User myUser = myDBContext.Users.SingleOrDefault(user => user.Username == username);

            return View("ChangePassword",refugee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword([Bind(Include = "RID,AuthorityCode,RefugeeFName,RefugeeLName,Password,OldConfirmPassword,ConfirmNewPassword,NewPassword,Postcode,Email,Street,Suburb,State,Phone,Family_Description,Icon")] Refugee refugee)
        {    newleavesdatabaseEntities1 db = new newleavesdatabaseEntities1();
            //     var v = db.Refugee.Where(a => a.AuthorityCode == User.Identity.Name).FirstOrDefault();

            if (string.Compare(refugee.OldConfirmPassword, refugee.Password) == 0)
           {
                if (ModelState.IsValid)
                {
                    refugee.Password = refugee.NewPassword;
                    db.Entry(refugee).State = EntityState.Modified;
                    db.SaveChanges();                                    
                    return RedirectToAction("RefugeeDetailsAfter", new { code = User.Identity.Name });
                }
           }
            else
            {
                ViewData["Non"] = "The old password didn't match";
                return View("ChangePassword", refugee);
            }
           
            return View();
        }

    }
}