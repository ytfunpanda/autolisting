using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

using AutoWeb.Data;


[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
public class RequiresAuthentication : ActionFilterAttribute {
  public bool IsAdmin { get; set; }
  public string AccessDeniedMessage { get; set; }

  private RouteValueDictionary HomepageRouteDictionary {
    get {
      RouteValueDictionary homepageRouteDictionary = new RouteValueDictionary();
      homepageRouteDictionary.Add("action", "index");
      homepageRouteDictionary.Add("controller", "security");

      return homepageRouteDictionary;
    }
  }

  public override void OnActionExecuting(ActionExecutingContext filterContext) {
    //BaseController controller = (BaseController)filterContext.Controller;
    //AutoEntities ctx = StandardContextFactory.GetContextPerRequest();
    //AdminUser user = ctx.AdminUsers.FirstOrDefault(u => u.AdminUserID == controller.CurrentUserID);;
    
    //if (user == null) {
    //  filterContext.Controller.TempData["Message"] = !string.IsNullOrEmpty(AccessDeniedMessage) 
    //    ? AccessDeniedMessage
    //    : "You must be logged in to access this page";
    //  filterContext.Controller.TempData["CSS"] = "alert-info";

    //  filterContext.Result = new RedirectToRouteResult(HomepageRouteDictionary);
    //}

    base.OnActionExecuting(filterContext);
  }

  private RouteValueDictionary BuildLoginRouteDictionary(string returnUrl) {
    RouteValueDictionary loginpageRouteDictionary = new RouteValueDictionary();
    loginpageRouteDictionary.Add("action", "Index");
    loginpageRouteDictionary.Add("controller", "Login");

    if (!string.IsNullOrEmpty(returnUrl))
      loginpageRouteDictionary.Add("returnUrl", returnUrl);

    return loginpageRouteDictionary;
  }
}
