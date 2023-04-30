using System.Web.Mvc;
using nightClub.Web.Extension;
using nightClub.Web.Models;

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