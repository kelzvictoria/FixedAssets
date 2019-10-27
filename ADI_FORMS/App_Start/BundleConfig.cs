using System.Web;
using System.Web.Optimization;

namespace ADI_FORMS
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery.js",
                        "~/Scripts/datatables/jquery.datatables.js",
                        "~/Scripts/datatables/datatables.bootstrap.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/hover-dropdown.js",
                        "~/Scripts/jquery.flexslider.js",
                        "~/Scripts/jquery.bxslider.js",
                        "~/Scripts/jquery.easing.min.js",
                        "~/Scripts/link-hover.js",
                        "~/Scripts/common-scripts.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/wow.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/THEME/js").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/site.css",
                      "~/Content/theme.css",
                      "~/Content/bootstrap-reset.css",
                      "~/Content/font-awesome.css",
                      "~/Content/flexslider.css",
                      "~/Content/jquery.bxslider.css",
                      "~/Content/animate.css",
                      "~/Content/style.css",
                      "~/Content/datatables/css/datatables.bootstrap.css",
                      "~/Content/style-responsive.css"));

            bundles.Add(new StyleBundle("~/Content/mbr-css").Include(
                     "~/Content/mbr-bootstrap.min.css",
                     "~/Content/site.css",
                     "~/Content/tether.min.css",
                     "~/Content/bootstrap-grid.min.css",
                     "~/Content/bootstrap-reboot.min.css",
                     "~/Content/mbr-style.css",
                     "~/Content/mbr-additional.css"
                     ));
        }
    }
}
