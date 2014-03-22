using System.Web;
using System.Web.Mvc;

using AutoWeb;

public class LanguageChangedFilter : ActionFilterAttribute {
  public override void OnActionExecuting(ActionExecutingContext filterContext) {
      if (HttpContext.Current.Request.RequestContext.RouteData.Values["lang"] != null && HttpContext.Current.Request.RequestContext.RouteData.Values["lang"].ToString().Length < 3)
      {
          string newLanguage = HttpContext.Current.Request.RequestContext.RouteData.Values["lang"].ToString();
          object lang = Cookies.Get("__auto", "ulang");
          string currentLanguage = lang != null ? lang.ToString() : null;

          if (!string.IsNullOrEmpty(currentLanguage) && !currentLanguage.Equals(newLanguage) && !filterContext.IsChildAction)
          {
              App.CurrentUserLanguage = newLanguage;
              App.Lang = newLanguage;

              HttpResponseBase response = filterContext.HttpContext.Response;
              string RedirectUrl = "/";
              RedirectUrl = filterContext.HttpContext.Session["ReturnUrl"] != null ? filterContext.HttpContext.Session["ReturnUrl"].ToString() : filterContext.HttpContext.Request.Url.ToString();
                  if (RedirectUrl.IndexOf("/en/") > 0)
                      RedirectUrl = RedirectUrl.Replace("/en/", "/" + App.CurrentUserLanguage + "/");
                  if (RedirectUrl.IndexOf("/fr/") > 0)
                      RedirectUrl = RedirectUrl.Replace("/fr/", "/" + App.CurrentUserLanguage + "/");
                  filterContext.Result = new RedirectResult(RedirectUrl);
                  filterContext.HttpContext.Session.Remove("ReturnUrl");
              //} 
          }
      }

    base.OnActionExecuting(filterContext);
  }
}
