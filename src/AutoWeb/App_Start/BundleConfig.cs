using System.Web;
using System.Web.Optimization;

namespace AutoWeb
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            //            "~/Scripts/jquery-ui-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.unobtrusive*",
            //            "~/Scripts/jquery.validate*"));

            // add on JS
            // ordering of the following JS includes matters!
            bundles.Add(new ScriptBundle("~/bundles/base-js").Include(

                // vendor
             "~/Scripts/jquery-{version}.js",
             "~/Public/js/vendor/jquery.easing.1.3.js",
             "~/Public/js/vendor/underscore-min.js",
             "~/Public/js/vendor/backbone-min.js",
             "~/Public/js/vendor/bootstrap.min.js",
             "~/Public/js/vendor/ui.js",
             "~/Public/js/vendor/jquery.cookie.js",
                //"~/Public/js/vendor/jquery.liquidcarousel.js",

             // base
             "~/Public/js/auto-app.js",

             // plugins
             "~/Public/js/plugin/jquery.browser.js",
             "~/Public/js/plugin/console.log.js",
              "~/Public/js/plugin/followwindow.js",

             "~/Public/js/auto-global.js"

            ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.menu.css",
                        "~/Content/themes/base/jquery.ui.spinner.css",
                        "~/Content/themes/base/jquery.ui.tooltip.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}