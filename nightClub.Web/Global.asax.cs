using nightClub.Web.App_Start;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using nightClub.BusinessLogic.DBModel.Seed;

namespace nightClub.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            System.Data.Entity.Database.SetInitializer(new GalleryDbInitializer());
            System.Data.Entity.Database.SetInitializer(new StaffDbInitializer());
            System.Data.Entity.Database.SetInitializer(new UserDbInitializer());
            System.Data.Entity.Database.SetInitializer(new EventDbInitializer());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}