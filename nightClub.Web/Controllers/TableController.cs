using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nightClub.Web.Controllers
{
    public class TableController : BaseController
    {
        private readonly ITable _tableBl;

        public TableController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _tableBl = bl.GetTableBL();
        }
        // GET: Table
        public ActionResult Index()
        {
            SessionStatus();
            return View();
        }
    }
}