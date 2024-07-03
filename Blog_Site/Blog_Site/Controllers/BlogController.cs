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
    public class BlogController : Controller
    {
        labtaskEntities db = new labtaskEntities();
        // GET: Blog
        public ActionResult Index()
        {
            //list of all Blogs
            var data = db.Blogs.ToList();
            var mapper = getMapper();
            var data2 = mapper.Map<List<BlogDTO>>(data);
            //map to DTO
            return View(data2);
        }

        // GET: Blog/Details/5
        public ActionResult Details(int id)
        {
            // Fetch the blog data from the database based on BId
            var data = db.Blogs.FirstOrDefault(b => b.BId == id);

            // Check if the blog with the specified id exists
            //if (data == null || data.Count == 0)
            //{
            //    return HttpNotFound(); // Or any appropriate action if blog is not found
            //}

            var mapper = getMapper();
            var bd = mapper.Map<BlogDTO>(data); // Map to a single BlogDTO, not List<BlogDTO>
            return View(bd);
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blog/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Blog/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Blog/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
