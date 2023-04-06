using System.Web.Mvc;

namespace nightClub.Web.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            //Pagina destinată contactarii si recenziilor... Necesită implimentarea procesului de lasare a feedback-ului.
            return View();
        }
    }
}