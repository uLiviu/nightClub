using AutoMapper;
using nightClub.BusinessLogic.Interfaces;
using nightClub.Domain.Entities.User;
using nightClub.Helpers;
using nightClub.Web.Models;
using System;
using System.Web.Mvc;

namespace nightClub.Web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ISession _sessionBL;

        public RegisterController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _sessionBL = bl.GetSessionBL();
        }

        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserRegister register)
        {
            if (ModelState.IsValid)
            {
                IMapper mapper = MappingHelper.Configure<UserRegister, URegisterData>();
                var data = mapper.Map<URegisterData>(register);

                data.LoginIp = Request.UserHostAddress;
                data.LoginDateTime = DateTime.Now;

                var userRegister = _sessionBL.UserRegister(data);

                if (userRegister.Status)
                {
                    return RedirectToAction("Index", "Login");
                }
                ModelState.AddModelError("", userRegister.StatusMsg);
                return View();
            }
            return View();
        }
    }
}