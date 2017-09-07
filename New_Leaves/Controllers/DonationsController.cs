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
    public class DonationsController : Controller
    {
        private newleavesdatabaseEntities1 db = new newleavesdatabaseEntities1();

        // GET: Donations
        public ActionResult Index()
        {
            //var donation = db.Donation.Include(d => d.Donor).Include(d => d.Wish_List);
            return View(db.Donation.ToList());
        }

        // GET: Donations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = db.Donation.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            return View(donation);
        }

        // GET: Donations/Create
        //button name: Donate
        public ActionResult Create(int id)
        {
            //get the login donor information and refugee infomation
            // write this imformation to donation table
            Wish_List wish = db.Wish_List.Find(id);
            Refugee refugee = wish.Refugee;
            String email = User.Identity.Name;
            Donor donor = db.Donor.SingleOrDefault(d=>d.Email == email);

            //update the status record in wishlist table
            wish.Status = "In processing";
            if (ModelState.IsValid)
            {
                db.Entry(wish).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
            }
            //jump to donor, rufugee check page
            ViewBag.wish = wish;
            ViewBag.Item_Name = wish.Item.Item_Name;
            //ViewBag.reugee = refugee;
            ViewBag.donor = donor;
            ViewBag.fullAddress = donor.Street + " " + donor.Suburb + " " + donor.State;

            ViewBag.DID = new SelectList(db.Donor, "DID", "FirstName");
            ViewBag.Wish_List_ID = new SelectList(db.Wish_List, "Wish_List_ID", "Status");
            return View();
        }

        // POST: Donations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DonationID,DID,Wish_List_ID,Item_Name,Donate_Date,Status")] Donation donation)
        {
            if (ModelState.IsValid)
            {
                db.Donation.Add(donation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DID = new SelectList(db.Donor, "DID", "FirstName", donation.DID);
            ViewBag.Wish_List_ID = new SelectList(db.Wish_List, "Wish_List_ID", "Status", donation.Wish_List_ID);
            return View(donation);
        }

        // GET: Donations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = db.Donation.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            ViewBag.DID = new SelectList(db.Donor, "DID", "FirstName", donation.DID);
            ViewBag.Wish_List_ID = new SelectList(db.Wish_List, "Wish_List_ID", "Status", donation.Wish_List_ID);
            return View(donation);
        }

        // POST: Donations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DonationID,DID,Wish_List_ID,Item_Name,Donate_Date,Status")] Donation donation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DID = new SelectList(db.Donor, "DID", "FirstName", donation.DID);
            ViewBag.Wish_List_ID = new SelectList(db.Wish_List, "Wish_List_ID", "Status", donation.Wish_List_ID);
            return View(donation);
        }

        // GET: Donations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = db.Donation.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            return View(donation);
        }

        // POST: Donations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Donation donation = db.Donation.Find(id);
            db.Donation.Remove(donation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
