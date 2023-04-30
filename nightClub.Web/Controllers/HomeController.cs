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
            if (System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}