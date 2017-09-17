using System.Web;
using System.Web.Optimization;

namespace New_Leaves
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jquery.fancybox.pack").Include(
                        "~/Scripts/jquery-fancybox.pack.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery.fancybox-media").Include(
                        "~/Scripts/jquery-fancybox.media.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery.dataTables").Include(
                        "~/Scripts/jquery-dataTables.js"));

            bundles.Add(new ScriptBundle("~/bundles/owl").Include(
                        "~/Scripts/owl.js"));

            bundles.Add(new ScriptBundle("~/bundles/appear").Include(
                        "~/Scripts/appear.js"));

            bundles.Add(new ScriptBundle("~/bundles/wow").Include(
                        "~/Scripts/wow.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-ui").Include(
                        "~/Scripts/jquery-ui.js"));

            bundles.Add(new ScriptBundle("~/bundles/script").Include(
                        "~/Scripts/script.js"));

            bundles.Add(new ScriptBundle("~/bundles/revolution").Include(
                        "~/Scripts/revolution.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/mixitup").Include(
                        "~/Scripts/mixitup.js"));

            bundles.Add(new ScriptBundle("~/bundles/validate").Include(
                        "~/Scripts/validate.js"));

            bundles.Add(new ScriptBundle("~/bundles/map-script").Include(
                        "~/Scripts/map-script.js"));

            bundles.Add(new ScriptBundle("~/bundles/newLeavesViz").Include(
                        "~/Scripts/newLeavesViz.js"));

            bundles.Add(new ScriptBundle("~/bundles/d3").Include(
                        "~/Scripts/d3.js"));

            bundles.Add(new ScriptBundle("~/bundles/chart").Include(
                       "~/Scripts/chart.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css",
                      "~/Content/style.css",
                      "~/Content/animate.css",
                      "~/Content/flaticon.css",
                      "~/Content/font-awesome.css",
                      "~/Content/hover.css",
                      "~/Content/jquery-ui.css",
                      "~/Content/jquery-bootstap-touchspin.css",
                      "~/Content/jquery-fancybox.css",
                      "~/Content/jquery-dataTables.css",
                      "~/Content/nouislider.css",
                      "~/Content/nouislider-pips.css",
                      "~/Content/owl.css",
                      "~/Content/responsive.css",
                      "~/Content/revolution-slider.css"));
        }
    }
}
