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
        private newleavesdatabaseEntities db = new newleavesdatabaseEntities();

        // GET: Donations
        public ActionResult Index()
        {
            var donation = db.Donation.Include(d => d.Donor).Include(d => d.Wish_List);
            return View(donation.ToList());
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
        public ActionResult Create()
        {
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
