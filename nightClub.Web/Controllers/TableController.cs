using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nightClub.Web.Controllers
{
    public class TableController : BaseController
    {
        // GET: Table
        public ActionResult Index()
        {
            SessionStatus();
            return View();
        }
    }
}