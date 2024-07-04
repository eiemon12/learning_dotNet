using EventManagement.DTOs;
using EventManagement.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EventManagement.Controllers
{

    public class LoginController : Controller
    {
        EventManagementEntities db = new EventManagementEntities();
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

            FormsAuthentication.SignOut();

            Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}