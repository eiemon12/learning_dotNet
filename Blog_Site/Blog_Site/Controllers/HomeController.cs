using AutoMapper;
using Blog_Site.DTOs;
using Blog_Site.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog_Site.Controllers
{
    public class HomeController : Controller
    {
        labtaskEntities db = new labtaskEntities();
        public ActionResult Index()
        {
            //list of all Blogs
            var data = db.Blogs.ToList();
            var mapper = getMapper();
            var data2 = mapper.Map<List<BlogDTO>>(data);
            //map to DTO
            return View(data2);
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

        public static Mapper getMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Blog, BlogDTO>();
                cfg.CreateMap<BlogDTO, Blog>();
            });
            return new Mapper(config);
        }
    }
}