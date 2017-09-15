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
    public class Wish_ListController : Controller
    {
        private newleavesdatabaseEntities1 db = new newleavesdatabaseEntities1();

        // GET: Wish_List
        public ActionResult Index()
        {
            var wish_List = db.Wish_List.Include(w => w.Item).Include(w => w.Refugee);
            return View(wish_List.ToList());
        }

        // GET: Wish_List/Details/5
        public ActionResult Details(int? id)
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

        // GET: Wish_List/Create
        public ActionResult Create()
        {
            ViewBag.Item_ID = new SelectList(db.Item, "Item_ID", "Item_Name");
            ViewBag.RID = new SelectList(db.Refugee, "RID", "RefugeeFName");
            return View();
        }

        // POST: Wish_List/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Wish_List_ID,RID,Item_ID,Create_Date,Hope_Delivery_Date,Status,Description,AuthorityCode")] Wish_List wish_List)
        {
            if (wish_List != null)
            {
                wish_List.Create_Date = DateTime.Now;
                wish_List.Status = "Not delivered";
            }
            if (ModelState.IsValid)
            {
                db.Wish_List.Add(wish_List);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Item_ID = new SelectList(db.Item, "Item_ID", "Item_Name", wish_List.Item_ID);
            ViewBag.RID = new SelectList(db.Refugee, "RID", "RefugeeFName", wish_List.RID);
            return View(wish_List);
        }

        // GET: Wish_List/Edit/5
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
            ViewBag.RID = new SelectList(db.Refugee, "RID", "RefugeeFName", wish_List.RID);
            return View(wish_List);
        }

        // POST: Wish_List/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Wish_List_ID,RID,Item_ID,Create_Date,Hope_Delivery_Date,Status,Description,AuthorityCode")] Wish_List wish_List)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wish_List).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Item_ID = new SelectList(db.Item, "Item_ID", "Item_Name", wish_List.Item_ID);
            ViewBag.RID = new SelectList(db.Refugee, "RID", "RefugeeFName", wish_List.RID);
            return View(wish_List);
        }

        // GET: Wish_List/Delete/5
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

        // POST: Wish_List/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wish_List wish_List = db.Wish_List.Find(id);
            db.Wish_List.Remove(wish_List);
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
