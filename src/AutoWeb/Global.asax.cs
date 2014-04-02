using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using GlobalisationSupport;

namespace Auto.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class App : System.Web.HttpApplication
    {
        public static string _cacheKeyEn = "AutoWebData-{0}-{1}";
        public static int _cacheExpiry = 24; // # of hours the cache should be valid for.

        public static string CacheBuster
        {
            get
            {

                string jsBundle = BundleTable.Bundles.ResolveBundleUrl("~/bundles/base-js");
                return jsBundle.Substring(jsBundle.LastIndexOf("=") + 1);
            }
        }

        private static CacheHelper _cache;
        public static CacheHelper Cache
        {
            get
            {
                if (_cache == null)
                    _cache = new CacheHelper(HttpContext.Current.Cache);

                return _cache;
            }
        }


        public static string Lang
        {
            get
            {
                try
                {
                    return App.CurrentUserLanguage;
                }
                catch { return "en"; }
            }
            set
            {
                try
                {
                    App.CurrentUserLanguage = value;
                }
                catch { }
            }
        }

        public static string BaseUrl
        {
            get
            {
                string url = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/");
                return url.EndsWith("/") ? url.TrimEnd('/') : url;
            }
        }

        public static string CurrentUserLanguage
        {
            get {
                return CultureManager.GetCulture();
            }
            set { }

            //get
            //{
            //    try
            //    {
            //        return Cookies.Get("__auto", "ulang").ToString();
            //    }
            //    catch
            //    {
            //        return "";
            //    }
            //}
            //set
            //{
            //    Cookies.Set("__auto", "ulang", value, DateTime.Today.AddYears(1));
            //}
        }

        /// <summary>
        /// Stores the users selected province (2 char format)
        /// </summary>
        public static string CurrentUserProvince
        {
            get
            {
                try
                {
                    return Cookies.Get("__auto", "uprov").ToString();
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                Cookies.Set("__auto", "uprov", value, DateTime.Today.AddYears(1));
            }
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            const string defautlRouteUrl = "{controller}/{action}/{id}";

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            RouteValueDictionary defaultRouteValueDictionary = new RouteValueDictionary(new { controller = "Home", action = "Index", id = UrlParameter.Optional });
            routes.Add("DefaultGlobalised", new GlobalisedRoute(defautlRouteUrl, defaultRouteValueDictionary));
            routes.Add("Default", new Route(defautlRouteUrl, defaultRouteValueDictionary, new MvcRouteHandler()));

            //LocalizedViewEngine: this is to support views also when named e.g. Index.de.cshtml
            routes.MapRoute(
                "Default2",
                "{culture}/{controller}/{action}/{id}",
                new
                {
                    culture = "en",
                    controller = "Home",//ControllerName
                    action = "Index",//ActionName
                    id = UrlParameter.Optional
                }
            ).RouteHandler = new LocalizedMvcRouteHandler();
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //LocalizedViewEngine: this is to support views also when named e.g. Index.de.cshtml
            ViewEngines.Engines.Insert(0, new LocalizedViewEngine());

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //standard mvc4 routing. see App_Start\RouteConfig.cs
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            // Put stuff into cache
            Bootstrap.Step1();
            //Bootstrap.Step2();
        }

        protected void Application_End()
        {
            RouteTable.Routes.Clear();
        }

        protected void Session_Start()
        {
        }
    }
}