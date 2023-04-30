using nightClub.Web.Extension;
using nightClub.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using nightClub.Domain.Entities.User;
using System.Web.UI.WebControls;

namespace nightClub.Web.Controllers
{
    public class UserController : BaseController
    {
        // GET: User
        public ActionResult Index()
        {
            SessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
            {
                return RedirectToAction("Index", "Login");
            }

            var user = System.Web.HttpContext.Current.GetMySessionObject();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserMinimal, UserData>();
            });
            IMapper mapper = config.CreateMapper();
            var data = mapper.Map<UserData>(user);

            return View(data);
        }
    }
}