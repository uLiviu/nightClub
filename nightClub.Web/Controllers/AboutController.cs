using nightClub.Web.Filters;
using System.Web.Mvc;

namespace nightClub.Web.Controllers
{
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