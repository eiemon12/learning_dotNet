using Blog_Site.DTOs;
using Blog_Site.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog_Site.Controllers
{
    public class RegisterController : Controller
    {
        labtaskEntities db = new labtaskEntities();
        // GET: Register
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(RegisterDTO r)
        {

            return View();
        }
    }
}