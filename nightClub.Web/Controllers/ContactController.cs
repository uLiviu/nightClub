using System;
using System.Web.Mvc;
using AutoMapper;
using nightClub.BusinessLogic.Interfaces;
using nightClub.Domain.Entities.Contact;
using nightClub.Web.Models;

namespace nightClub.Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactBL;

        public ContactController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _contactBL = bl.GetContactBL();
        }
        // GET: Contact
        public ActionResult Index()
        {
            //Pagina destinată contactarii si recenziilor... Necesită implimentarea procesului de lasare a feedback-ului.
            return View();
        }

        [HttpPost]
        public ActionResult Index(Review review)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Review, ReviewModel>();
                });
                IMapper mapper = config.CreateMapper();
                var data = mapper.Map<ReviewModel>(review);

                data.Date = DateTime.Now;

                _contactBL.AddReview(data);
                return RedirectToAction("ThankYou");
            }
            return View();
        }

        public ActionResult ThankYou()
        {
            return View();
        }
    }
}