using AutoMapper;
using nightClub.BusinessLogic.Interfaces;
using nightClub.Domain.Entities.Ticket;
using nightClub.Domain.Entities.User;
using nightClub.Web.Filters;
using nightClub.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using nightClub.Helpers;

namespace nightClub.Web.Controllers
{
    [AdminMod]
    public class AdminController : BaseController
    {
        private readonly IUser _userBL;
        private readonly ITicketBooking _ticketBL;
        public AdminController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _userBL = bl.GetUserBL();
            _ticketBL = bl.GetTicketBookingBL();
        }
        // GET: Admin
        public ActionResult Index(string searchCriteria)
        {
            SessionStatus();
            IMapper mapper = MappingHelper.Configure<UserMinimal, UserData>();

            var users = mapper.Map<List<UserData>>(_userBL.GetList(searchCriteria));
            return View(users);
        }

        public ActionResult Delete(int id)
        {
            var user = _userBL.GetById(id);
            if (user == null) return View("NotFound");
            _userBL.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Bookings(string searchCriteria)
        {
            SessionStatus();
            IMapper mapper = MappingHelper.Configure<TicketModel, Ticket>();

            var tickets = mapper.Map<List<Ticket>>(_ticketBL.GetTicketsList(searchCriteria));
            return View(tickets);
        }

        public ActionResult DeleteTicketBooking(int id)
        {
            var ticket = _ticketBL.GetById(id);
            if (ticket == null) return View("NotFound");
            _ticketBL.Delete(id);
            return RedirectToAction("Bookings");
        }

    }
}