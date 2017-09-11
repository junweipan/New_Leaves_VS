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
    public class RefugeesController : Controller
    {
        private newleavesdatabaseEntities1 db = new newleavesdatabaseEntities1();

        // GET: Refugees
        public ActionResult Index()
        {
            return View(db.Refugee.ToList());
        }

        // GET: Refugees/Details/5
        public ActionResult Details(int? id)
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

        // GET: Refugees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Refugees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RID,RefugeeFName,RefugeeLName,AuthorityCode,Password,Street,Suburb,State,Email,Postcode,Phone,Family_Description,Icon")] Refugee refugee)
        {
            refugee.Password = Crypto.Hash(refugee.Password);
            if (ModelState.IsValid)
            {
                db.Refugee.Add(refugee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(refugee);
        }

        // GET: Refugees/Edit/5
        public ActionResult Edit(int? id)
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
        public ActionResult Edit([Bind(Include = "RID,RefugeeFName,RefugeeLName,AuthorityCode,Password,Street,Suburb,State,Email,Postcode,Phone,Family_Description,Icon")] Refugee refugee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(refugee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(refugee);
        }

        // GET: Refugees/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Refugees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Refugee refugee = db.Refugee.Find(id);
            db.Refugee.Remove(refugee);
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
