using BlogSite.DTOs;
using BlogSite.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Register(RegisterDTO r)
        {
            labtaskEntities db = new labtaskEntities();
            if (ModelState.IsValid) {
               var data = Convert(r);
               db.Users.Add(data);
               db.SaveChanges();
               return RedirectToAction("Login","Home");
            }
            return View();
        }
        public static RegisterDTO Convert(User r)
        {
            return new RegisterDTO
            {
                UId = r.UId,
                Name = r.Name,
                Email = r.Email,
                Phone = r.Phone,
                Password = r.Password,
                Dob = r.Dob,
                Gender = r.Gender
            };
        }
        public static User Convert(RegisterDTO r)
        {
            return new User
            {
                UId = r.UId,
                Name = r.Name,
                Email = r.Email,
                Phone = r.Phone,
                Password = r.Password,
                Dob = r.Dob,
                Gender = r.Gender
            };
        }
    }
}