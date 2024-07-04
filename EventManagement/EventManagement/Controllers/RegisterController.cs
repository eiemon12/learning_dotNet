using AutoMapper;
using EventManagement.DTOs;
using EventManagement.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagement.Controllers
{
    public class RegisterController : Controller
    {
        EventManagementEntities db = new EventManagementEntities();

        // GET: Register
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(RegisterDTO r)
        {
            if (ModelState.IsValid)
            {
                // Validate phone number format
                string phoneStr = r.Phone.ToString();
                if (!System.Text.RegularExpressions.Regex.IsMatch(phoneStr, @"^01[3-9]\d{8}$"))
                {
                    ModelState.AddModelError("Phone", "Phone number must start with 013-019 and be exactly 11 digits.");
                }
                // Check if email or phone number already exists
                var existingUser = db.Users.FirstOrDefault(u => u.Email == r.Email || u.Phone == r.Phone);
                if (existingUser != null)
                {
                    if (existingUser.Email == r.Email)
                    {
                        ModelState.AddModelError("Email", "This email is already registered.");
                    }
                }
                else
                {
                    // Convert RegisterDTO to User
                    var mapper = getMapper();
                    var user = mapper.Map<User>(r);
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Login");
                }
            }
            return View(r);
        }

        public static Mapper getMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<User, RegisterDTO>();
                cfg.CreateMap<RegisterDTO, User>();
            });
            return new Mapper(config);
        }
    }
}