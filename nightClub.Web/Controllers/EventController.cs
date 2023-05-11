using AutoMapper;
using nightClub.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nightClub.BusinessLogic.Interfaces;
using nightClub.Domain.Entities.Event;

namespace nightClub.Web.Controllers
{
    public class EventController : BaseController
    {
        private readonly IEvent _eventBl;

        public EventController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _eventBl = bl.GetEventBL();
        }
        // GET: Event
        public ActionResult Index()
        {
            SessionStatus();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<EventModel, Event>());
            IMapper mapper = config.CreateMapper();

            var eventsList = mapper.Map<List<Event>>(_eventBl.GetAll());
            return View(eventsList);
        }
        //GET: Event/Create
        public ActionResult Create()
        {
            SessionStatus();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Event newEvent)
        {
            SessionStatus();
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Event, EventModel>());
                IMapper mapper = config.CreateMapper();

                var eventAdded = _eventBl.Add(mapper.Map<EventModel>(newEvent));
                if (eventAdded.Status)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", eventAdded.StatusMsg);
                    return View();
                }
            }
            return View();
        }
    }
}