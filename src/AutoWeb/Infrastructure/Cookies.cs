using System;
using System.Web;

public static class Cookies {
  public static void Set(string cookieIdentifier, string cookieKeyIdentifier, string cookieKeyValue, DateTime? expiry) {
    //Destroy(cookieIdentifier);
    HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(cookieIdentifier);
    if (cookie == null) cookie = new HttpCookie(cookieIdentifier);

    if (!string.IsNullOrEmpty(cookie.Values[cookieKeyIdentifier])) cookie.Values.Remove(cookieKeyIdentifier);
    cookie.Values.Set(cookieKeyIdentifier, cookieKeyValue);

    if (expiry != null && expiry.HasValue) cookie.Expires = expiry.Value;

    HttpContext.Current.Response.Cookies.Add(cookie);
  }

  public static object Get(string cookieIdentifier, string cookieKeyIdentifier) {
    HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(cookieIdentifier);

    if (cookie == null)
      return null;

    try {
      return cookie.Values[cookieKeyIdentifier];
    } catch {
      return null;
    }
  }

  public static void Destroy(string cookieIdentifier) {
    HttpCookie myCookie = new HttpCookie(cookieIdentifier);
    HttpContext.Current.Response.Cookies.Remove(cookieIdentifier);
    HttpContext.Current.Response.Cookies.Add(myCookie);
    HttpContext.Current.Response.Cookies[cookieIdentifier].Expires = DateTime.Now.AddDays(-15);
  }
}
