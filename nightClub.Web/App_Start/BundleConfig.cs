using System.Web.Optimization;

namespace nightClub.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Vendor CSS Files 
            bundles.Add(new StyleBundle("~/bundles/aos/css").Include(
                "~/Vendor/aos/aos.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include(
                "~/Content/bootstrap.min.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/bootstrap_icons/css").Include(
                "~/Vendor/bootstrap-icons/bootstrap-icons.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/boxicons/css").Include(
                "~/Vendor/boxicons/css/boxicons.min.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/glightbox/css").Include(
                "~/Vendor/glightbox/css/glightbox.min.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/remixicon/css").Include(
                "~/Vendor/remixicon/remixicon.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/swiper_bundle/css").Include(
                "~/Vendor/swiper/swiper-bundle.min.css", new CssRewriteUrlTransform()));

            //Template Main CSS File 
            bundles.Add(new StyleBundle("~/bundles/main/css").Include(
                "~/Content/css/style.css", new CssRewriteUrlTransform()));

            //Vendor JS Files
            bundles.Add(new ScriptBundle("~/bundles/purecounter_vanilla/js").Include(
                "~/Vendor/purecounter/purecounter_vanilla.js"));
            bundles.Add(new ScriptBundle("~/bundles/aos/js").Include(
                "~/Vendor/aos/aos.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap/js").Include(
                "~/Scripts/bootstrap.bundle.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/glightbox/js").Include(
                "~/Vendor/glightbox/js/glightbox.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/isotope/js").Include(
                "~/Vendor/isotope-layout/isotope.pkgd.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/swiper_bundle/js").Include(
                "~/Vendor/swiper/swiper-bundle.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/validate/js").Include(
                "~/Vendor/php-email-form/validate.js"));

            //Template Main JS File
            bundles.Add(new ScriptBundle("~/bundles/main/js").Include(
                "~/Scripts/js/main.js"));
        }
    }
}


