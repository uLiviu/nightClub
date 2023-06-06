using nightClub.BusinessLogic.Interfaces;
using nightClub.Domain.Enums;
using nightClub.Web.Extension;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace nightClub.Web.Filters
{
    public class AdminModAttribute : ActionFilterAttribute
    {
        private readonly ISession _session;
        public AdminModAttribute()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _session = bl.GetSessionBL();
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //var adminSession = (UserMinimal)HttpContext.Current?.Session["__SessionObject"];
            var adminSession = System.Web.HttpContext.Current.GetMySessionObject();
            if (adminSession != null)
            {

                var cookie = HttpContext.Current.Request.Cookies["X-KEY"];
                if (cookie != null)
                {
                    var profile = _session.GetUserByCookie(cookie.Value);
                    if (profile != null && profile.Level == URole.Admin)
                    {
                        HttpContext.Current.Session.Add("__SessionObject", profile);
                        return;
                    }
                }
            }
            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary(new { controller = "Error", action = "NotFound" }));
        }
    }
}