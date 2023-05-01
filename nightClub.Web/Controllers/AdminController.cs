using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using nightClub.BusinessLogic.Interfaces;
using nightClub.Domain.Entities.User;
using nightClub.Web.Models;

namespace nightClub.Web.Controllers
{
    public class AdminController : BaseController
    {
        private readonly IUser _userBL;
        public AdminController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _userBL = bl.GetUserBL();
        }
        // GET: Admin
        public ActionResult Index()
        {
            SessionStatus();
            var configure = new MapperConfiguration(cfg => 
                cfg.CreateMap<UserMinimal, UserData>());
            IMapper mapper = configure.CreateMapper();

            var users = mapper.Map<List<UserData>>(_userBL.GetList());
            return View(users);
        }


    }
}