using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.WebPages;
using AutoWeb;
using AutoWeb.Models;

namespace AutoWeb {
  public class App : System.Web.HttpApplication {

    // {0} is the type of data being cached (VEHICLES, MODELS, COLOURS) uppercase please.
    // {1} is replaced with a language id (en or fr)
    public static string _cacheKeyEn = "AutoWebData-{0}-{1}";
    public static int _cacheExpiry = 24; // # of hours the cache should be valid for.
    
    public static string CacheBuster {
      get {
        
        string jsBundle = BundleTable.Bundles.ResolveBundleUrl("~/bundles/base-js");
        return jsBundle.Substring(jsBundle.LastIndexOf("=") + 1);
      } 
    }

    public static string Lang {
      get {
        try {
            return App.CurrentUserLanguage;
        } catch { return "en"; }
      }
      set {
        try {
          App.CurrentUserLanguage = value;
        } catch { }
      }
    }

    public static string BaseUrl {
      get {
        string url = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/");
        return url.EndsWith("/") ? url.TrimEnd('/') : url;
      }
    }

    public static RetailerSiteViewModel CurrentRetailerSite {
      get {
        return HttpContext.Current.Session["RetailerSite"] as RetailerSiteViewModel;
      }
      set {
        HttpContext.Current.Session["RetailerSite"] = value;
      }
    }
    
    /// <summary>
    /// This cookie stores the users selected language (2 chars, en or fr)
    /// </summary>
    public static string CurrentUserLanguage {
      get {
        try {
          return Cookies.Get("__auto", "ulang").ToString();
        } catch {
          return "";
        }
      }
      set {
        Cookies.Set("__auto", "ulang", value, DateTime.Today.AddYears(1));
      }
    }

    /// <summary>
    /// Stores the users selected province (2 char format)
    /// </summary>
    public static string CurrentUserProvince {
      get {
        try {
          return Cookies.Get("__auto", "uprov").ToString();
        } catch {
          return "";
        }
      }
      set {
        Cookies.Set("__auto", "uprov", value, DateTime.Today.AddYears(1));
      }
    }

    /// <summary>
    /// Global cache helper, all the site data will be set, get through this.
    /// </summary>
    private static CacheHelper _cache;
    public static CacheHelper Cache {
      get {
        if (_cache == null)
          _cache = new CacheHelper(HttpContext.Current.Cache);

        return _cache;
      }
    }

    protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
        
      BundleConfig.RegisterBundles(BundleTable.Bundles);
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      WebApiConfig.Register(GlobalConfiguration.Configuration);
      AuthConfig.RegisterAuth();

      // Map and bootstrap supporting entities (colours, options etc).
      DataMapping.Step1();
      Bootstrap.Step1();
      
      // Map and bootstrap vehicle data.
      DataMapping.Step2();
      Bootstrap.Step2();

      DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("Mobile") {
        ContextCondition = (context => context.GetOverriddenUserAgent().IndexOf
           ("Android", StringComparison.OrdinalIgnoreCase) >= 0)
      });

      DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("Mobile") {
        ContextCondition = (context => context.GetOverriddenUserAgent().IndexOf
           ("BB", StringComparison.OrdinalIgnoreCase) >= 0)
      });
      
    }

    protected void Application_End() {
        RouteTable.Routes.Clear();
    }
    protected void Application_AcquireRequestState(object sender, EventArgs e) {
      if (HttpContext.Current != null && HttpContext.Current.Session != null) {

        // only check the domain and set the language once
        if (!HttpContext.Current.Request.Url.AbsoluteUri.Contains(".css")
          || !HttpContext.Current.Request.Url.AbsoluteUri.Contains(".js")
          || !HttpContext.Current.Request.Url.AbsoluteUri.Contains(".gif")
          || !HttpContext.Current.Request.Url.AbsoluteUri.Contains(".jpg")
          || !HttpContext.Current.Request.Url.AbsoluteUri.Contains(".png")) {

              string cultureString = "en-ca";
              if (App.CurrentUserLanguage.ToUpperInvariant() == "FR") {
                  cultureString = "fr-ca";
              }
          CultureInfo ci = (CultureInfo)new CultureInfo(cultureString);
          //Checking first if there is no value in session and set default language this can happen for first user's request
          if (ci == null) {
            string langName = "en";

            if (HttpContext.Current.Request.UserLanguages != null && HttpContext.Current.Request.UserLanguages.Length != 0) {
              langName = HttpContext.Current.Request.UserLanguages[0].Substring(0, 2);
            }

            ci = new CultureInfo(langName);
            this.Session["Culture"] = langName;
          }

          //Finally setting culture for each request
          Thread.CurrentThread.CurrentUICulture = ci;
          Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);
        }
      }
    }

    protected void Session_Start() {
      List<RetailerSiteViewModel> retailerSites = App.Cache.Get(string.Format(App._cacheKeyEn, "RETAILERSITES", "en")) as List<RetailerSiteViewModel>;
      if (retailerSites == null) {
          Application_End();
          Application_Start();
      }
      //App.CurrentRetailerSite = retailerSites.FindByDomain(App.BaseUrl);
    }
  }
}