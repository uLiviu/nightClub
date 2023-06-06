using AutoMapper;
using nightClub.BusinessLogic.Interfaces;
using nightClub.Domain.Entities.Event;
using nightClub.Domain.Entities.Ticket;
using nightClub.Helpers;
using nightClub.Web.Filters;
using nightClub.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace nightClub.Web.Controllers
{
    public class EventController : BaseController
    {
        private readonly IEvent _eventBl;
        private readonly ITicketBooking _tBookingBl;

        public EventController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _eventBl = bl.GetEventBL();
            _tBookingBl = bl.GetTicketBookingBL();
        }

        // GET: Event
        public ActionResult Index()
        {
            SessionStatus();
            IMapper mapper = MappingHelper.Configure<EventModel, Event>();

            var eventsList = mapper.Map<List<Event>>(_eventBl.GetAll());
            return View(eventsList);
        }

        //GET: Event/Create
        [AdminMod]
        public ActionResult Create()
        {
            SessionStatus();
            return View();
        }

        [AdminMod]
        [HttpPost]
        public ActionResult Create(Event newEvent)
        {
            SessionStatus();
            if (ModelState.IsValid)
            {
                IMapper mapper = MappingHelper.Configure<Event, EventModel>();

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

        //Pagina de detalii pt Admin
        // GET: Event/Details/1      
        [AdminMod]
        public ActionResult Details(int id)
        {
            SessionStatus();
            var evDetails = _eventBl.GetById(id);
            if (evDetails != null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<EventModel, Event>());
                IMapper mapper = config.CreateMapper();
                var data = mapper.Map<Event>(evDetails);
                return View(data);
            }

            return View("NotFound");
        }

        //Pagina de detalii pt Utilizatori
        // GET: Event/EventDetail/1 
        public ActionResult EventDetail(int id)
        {
            SessionStatus();
            var evDetails = _eventBl.GetById(id);
            if (evDetails != null)
            {
                IMapper mapper = MappingHelper.Configure<EventModel, Event>();
                var data = mapper.Map<Event>(evDetails);
                return View(data);
            }

            return View("NotFound");
        }

        // GET: Event/Edit/1 
        [AdminMod]
        public ActionResult Edit(int id)
        {
            SessionStatus();
            var evDetails = _eventBl.GetById(id);
            if (evDetails != null)
            {
                IMapper mapper = MappingHelper.Configure<EventModel, Event>();
                var data = mapper.Map<Event>(evDetails);
                return View(data);
            }

            return View("NotFound");
        }

        [HttpPost]
        [AdminMod]
        public ActionResult Edit(Event newEvent)
        {
            SessionStatus();
            if (ModelState.IsValid)
            {
                IMapper mapper = MappingHelper.Configure<Event, EventModel>();

                var eventAdded = _eventBl.Update(mapper.Map<EventModel>(newEvent));
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

        [AdminMod]
        public ActionResult Delete(int id)
        {
            var eventDetail = _eventBl.GetById(id);
            if (eventDetail == null) return View("NotFound");
            _eventBl.Delete(id);
            return RedirectToAction("Index");
        }

        //GET: Event/BookTicket/1
        public ActionResult BookTicket(int id)
        {
            SessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
            {
                return RedirectToAction("Index", "Login");
            }

            var evDetails = _eventBl.GetById(id);
            if (evDetails != null)
            {
                ViewBag.Event = evDetails;
                var ticket = new Ticket
                {
                    UserId = ViewBag.CurrentUser.Id,
                    FullName = ViewBag.CurrentUser.Username,
                    Email = ViewBag.CurrentUser.Email,
                    Quantity = 1,
                    EventId = evDetails.Id,
                };
                return View(ticket);
            }

            return View("NotFound");
        }

        [Authenticated]
        [HttpPost]
        public ActionResult BookTicket(Ticket ticket)
        {
            SessionStatus();
            var eventDetail = _eventBl.GetById(ticket.EventId);
            ViewBag.Event = eventDetail;

            if (ModelState.IsValid)
            {
                if (eventDetail == null) return View("NotFound");

                IMapper mapper = MappingHelper.Configure<Ticket, TicketModel>();
                var ticketModel = mapper.Map<TicketModel>(ticket);

                var bookingResult = _tBookingBl.Book(ticket.EventId, ticketModel);

                if (bookingResult.Status)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", bookingResult.StatusMsg);
                return View(ticket);
            }
            return View(ticket);
        }
    }
}