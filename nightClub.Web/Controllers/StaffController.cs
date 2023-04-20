using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nightClub.BusinessLogic.Interfaces;
using nightClub.Domain.Enums;
using nightClub.Web.Models;

namespace nightClub.Web.Controllers
{
    public class StaffController : Controller
    {
        private readonly IStaff _staffBL;

        public StaffController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _staffBL = bl.GetStaffBL();
        }
        
        //GET: Staff
        public ActionResult Index()
        {
            return View();
        }
    }
}