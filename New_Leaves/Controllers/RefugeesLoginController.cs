using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using New_Leaves.Models;
using System.Net;
using System.Web.Security;

namespace New_Leaves.Controllers
{
    public class RefugeesLoginController : Controller
    {
        // GET: RefugeesLogin
        public ActionResult Index()
        {
            return View();
        }

        //Login 
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //Login POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(RefugeeLogin login, string ReturnUrl = "")
        {
            string message = "";
            using (newleavesdatabaseEntities1 dc = new newleavesdatabaseEntities1())
            {
                var v = dc.Refugee.Where(a => a.AuthorityCode == login.AuthorityCode).FirstOrDefault();
                if (v != null)
                {
                    if (string.Compare(login.Password, v.Password) == 0)
                       
                    {   
                        int timeout = login.RememberMe ? 525600 : 20;
                        var ticket = new FormsAuthenticationTicket(login.AuthorityCode, login.RememberMe, timeout);
                       
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                       
                        Response.Cookies.Add(cookie);


                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("RefugeeIndex", "Home");
                        }
                    }
                    else
                    {
                        message = "Invalid credential provided";
                    }
                }
                else
                {
                    message = "Invalid credential provided";
                }
            }
            ViewBag.Message = message;
            return View();
        }

        //Logout
        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}