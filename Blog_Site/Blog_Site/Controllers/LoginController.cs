using Blog_Site.DTOs;
using Blog_Site.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Blog_Site.Controllers
{
    public class LoginController : Controller
    {
        labtaskEntities db = new labtaskEntities();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginDTO l)
        {
            if (ModelState.IsValid)
            {
                var user = (from u in db.Users
                            where u.Email.Equals(l.Email) &&
                            u.Password.Equals(l.Password)
                            select u).SingleOrDefault();
                if (user == null)
                {
                    TempData["Msg"] = "User not found / Uname pass mismatch";
                    return RedirectToAction("Index");
                }
                Session["user"] = user;
                TempData["Msg"] = "Login Successfull";
                if (user.UserType.Equals("Admin"))
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (user.UserType.Equals("User"))
                {
                    return RedirectToAction("Index", "User");
                }
            }
            return View(l);
        }

        public ActionResult Logout()
        {
          
            FormsAuthentication.SignOut(); // Sign out the user

            // Optionally, clear session or any other user-specific data
            Session.Clear();

            // Redirect to the login page or home page after logout
            return RedirectToAction("Index", "Home");
        }
    }
}