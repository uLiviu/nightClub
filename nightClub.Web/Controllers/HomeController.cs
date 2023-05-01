using System.Web.Mvc;

namespace nightClub.Web.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            SessionStatus();
            return View();
        }
    }
}