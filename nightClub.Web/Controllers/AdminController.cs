using AutoMapper;
using nightClub.BusinessLogic.Interfaces;
using nightClub.Domain.Entities.User;
using nightClub.Web.Filters;
using nightClub.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace nightClub.Web.Controllers
{
    [AdminMod]
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

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var user = _userBL.GetById(id);
            if (user == null) return View("NotFound");
            _userBL.Delete(id);
            return RedirectToAction("Index");
        }

    }
}