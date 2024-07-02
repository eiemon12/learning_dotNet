using Blog_Site.DTOs;
using Blog_Site.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace Blog_Site.Controllers
{
    public class LoginController : Controller
    {
        labtaskEntities db = new labtaskEntities();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            if (Request["ReturnUrl"] != null)
            {
                ViewBag.URL = Request["ReturnUrl"];
            }
            return View(new LoginDTO());
        }
        [HttpPost]
        public ActionResult Index(LoginDTO l, string URL)
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
                if (user.UserType.Equals("User"))
                {
                    return RedirectToAction("Index", "User");
                }
            }
            return View(l);
        }
    }
}