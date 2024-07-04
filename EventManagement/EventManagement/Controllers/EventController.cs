using AutoMapper;
using EventManagement.EF;
using EventManagement.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace EventManagement.Controllers
{
    public class EventController : Controller
    {
        EventManagementEntities db = new EventManagementEntities();
        // GET: Event
        public ActionResult Index()
        {
            //list of all Events
            var data = db.Events.ToList();
            var mapper = getMapper();
            var data2 = mapper.Map<List<EventDTO>>(data);
            //map to DTO
            return View(data2);
        }

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            var data = db.Events.FirstOrDefault(b => b.Id == id);
            var mapper = getMapper();
            var bd = mapper.Map<EventDTO>(data); 
            return View(bd);
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        [HttpPost]
        public ActionResult Create(EventDTO e)
        {
            if (ModelState.IsValid)
            {
                //convert postDTO to Post
                var mapper = getMapper();
                var post = mapper.Map<Event>(e);
                db.Events.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(e);
        }

    // GET: Event/Edit/5
    public ActionResult Edit(int id)
        {
            var exobj = db.Events.Find(id);
            var mapper = getMapper();
            var data = mapper.Map<EventDTO>(exobj);
            return View(data);
        }

        // POST: Event/Edit/5
        [HttpPost]
        public ActionResult Edit(EventDTO obj)
        {
            var exobj = db.Events.Find(obj.Id);
            //db.Entry(exobj).CurrentValues.SetValues(obj);
            exobj.Title = obj.Title;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            var obj = db.Events.Find(id);
            db.Events.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
        public static Mapper getMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Event, EventDTO>();
                cfg.CreateMap<EventDTO, Event>();
            });
            return new Mapper(config);
        }
    }
}
