using System;
using System.Web.Mvc;
using System.Web.Routing;

using AutoWeb;
using AutoWeb.Controllers;
using System.Web;
using System.Globalization;
using System.Threading;

/// <summary>
/// Action filter that checks to see if the CurrentUserLanguage and CurrentUserProvince cookies are set
/// if they aren't the user is sent to the language settings page to set them.
/// </summary>
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
public class RequiresLanguageSettings : ActionFilterAttribute {

    private RouteValueDictionary SettingsRoute {
        get {
            RouteValueDictionary settingsRoute = new RouteValueDictionary();
            settingsRoute.Add("action", "index");
            settingsRoute.Add("controller", "settings");

            return settingsRoute;
        }
    }

    public override void OnActionExecuting(ActionExecutingContext filterContext) {
        // this allows a l=en&p=on set of query string parameters to be added to the request that will set the lang
        // and province

        if (!filterContext.IsChildAction) {
            
            if (App.CurrentRetailerSite != null) {
                //if (App.CurrentRetailerSite.Retailer.ProvinceShort == "QC" && string.IsNullOrEmpty(App.CurrentUserLanguage)) {
                //    Cookies.Set("__auto", "uprov", App.CurrentRetailerSite.Retailer.ProvinceShort, DateTime.Now.AddYears(1));
                //    App.CurrentUserProvince = App.CurrentRetailerSite.Retailer.ProvinceShort;

                //    Cookies.Set("__auto", "ulang", "fr", DateTime.Now.AddYears(1));
                //    App.CurrentUserLanguage = "fr";
                //}
                //if (App.CurrentRetailerSite.Retailer.ProvinceShort != "QC" && string.IsNullOrEmpty(App.CurrentUserLanguage)) {
                //    Cookies.Set("__auto", "uprov", App.CurrentRetailerSite.Retailer.ProvinceShort, DateTime.Now.AddYears(1));
                //    App.CurrentUserProvince = App.CurrentRetailerSite.Retailer.ProvinceShort;

                //    Cookies.Set("__auto", "ulang", "en", DateTime.Now.AddYears(1));
                //    App.CurrentUserLanguage = "en";
                //}

                // require to set the culture here
                CultureInfo ci = (CultureInfo)new CultureInfo(App.Lang + "-ca");
                Thread.CurrentThread.CurrentUICulture = ci;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);
            } else {
                if (!string.IsNullOrEmpty(filterContext.HttpContext.Request.QueryString["p"])) {
                    App.CurrentUserProvince = filterContext.HttpContext.Request.QueryString["p"].ToString().ToUpperInvariant().TrimEnd('/');
                    Cookies.Set("__auto", "uprov", App.CurrentUserProvince, DateTime.Now.AddYears(1));
                }

                if (string.IsNullOrEmpty(App.CurrentUserLanguage)) {
                    App.CurrentUserLanguage = filterContext.RequestContext.RouteData.Values["lang"] != null
                        ? filterContext.RequestContext.RouteData.Values["lang"].ToString().ToUpperInvariant()
                        : "en";
                    if (App.CurrentUserLanguage.Length > 2) {
                        App.CurrentUserLanguage = "en";
                    }
                    Cookies.Set("__auto", "ulang", App.CurrentUserLanguage, DateTime.Now.AddYears(1));
                }

                if (string.IsNullOrEmpty(App.CurrentUserLanguage) || string.IsNullOrEmpty(App.CurrentUserProvince)) {
                    // requesting page andfirst time on site
                    filterContext.HttpContext.Session["ReturnUrl"] = filterContext.HttpContext.Request.Url.ToString();
                    filterContext.Result = new RedirectToRouteResult(SettingsRoute);
                }
            }
        }

        base.OnActionExecuting(filterContext);
    }
}
