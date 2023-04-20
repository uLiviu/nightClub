using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using nightClub.BusinessLogic.Interfaces;
using nightClub.Domain.Entities.Staff;
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
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StaffModel, Staff>();
            });
            IMapper mapper = config.CreateMapper();
            
            var staff = mapper.Map<List<Staff>>(_staffBL.GetStaff());
            return View(staff);
        }
    }
}