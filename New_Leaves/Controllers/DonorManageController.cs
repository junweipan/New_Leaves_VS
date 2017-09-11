using New_Leaves.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace New_Leaves.Controllers
{
    public class DonorManageController : Controller
    {
        private newleavesdatabaseEntities1 db = new newleavesdatabaseEntities1();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DonorDetails(String code)
        {
            if (code == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donor donor = db.Donor.SingleOrDefault(d => d.Email==code);
            // User myUser = myDBContext.Users.SingleOrDefault(user => user.Username == username);
            if (donor == null)
            {
                return HttpNotFound();
            }
            return View(donor);
           // return View();
        }
        public ActionResult Edit(String email)
        {
            if (email == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donor donor = db.Donor.SingleOrDefault(d => d.Email == email);
            if (donor == null)
            {
                return HttpNotFound();
            }
            return View(donor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DID,FirstName,LastName,Email,Password,ConfirmPassword,IsEmailVerified,ActivationCode,Street,Suburb,State,Postcode,Phone,Icon")] Donor donor)
        {
          //  donor.ConfirmPassword = donor.Password;
            if (ModelState.IsValid)
            {
                donor.Password = Crypto.Hash(donor.Password);
                db.Entry(donor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DonorDetails", new { code = donor.Email });
            }
            return View(donor);
        }
    }
}