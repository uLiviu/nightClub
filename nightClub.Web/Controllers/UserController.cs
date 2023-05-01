using AutoMapper;
using nightClub.Domain.Entities.User;
using nightClub.Web.Extension;
using nightClub.Web.Filters;
using nightClub.Web.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace nightClub.Web.Controllers
{
    [Authenticated]
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

        public ActionResult Logout()
        {
            Session.Abandon();
            System.Web.HttpContext.Current.Session.Clear();
            if (ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("X-KEY"))
            {
                var cookie = ControllerContext.HttpContext.Request.Cookies["X-KEY"];
                if (cookie != null)
                {
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                }
            }
            System.Web.HttpContext.Current.Session["LoginStatus"] = "logout";
            return RedirectToAction("Index", "Home");
        }
    }
}