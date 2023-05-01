using System.Web.Mvc;
using nightClub.Web.Filters;

namespace nightClub.Web.Controllers
{
    [Authenticated]
    public class AboutController : BaseController
    {
        // GET: About
        public ActionResult Index()
        {
            SessionStatus();
            //Pagina informativă cu privință la proiectul realizat... Necesita editare.
            return View();
        }
    }
}