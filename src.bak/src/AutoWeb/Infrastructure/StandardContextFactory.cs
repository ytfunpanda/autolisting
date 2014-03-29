using System.Data.Objects;
using System.Web;

using AutoWeb.Data;

public class StandardContextFactory {

  private static readonly string contextKey = typeof(ObjectContext).FullName;

  public static AutoEntities GetContextPerRequest() {
    HttpContext httpContext = HttpContext.Current;
    if (httpContext == null) {
        return new AutoEntities();
    } else {
        AutoEntities context = httpContext.Items[contextKey] as AutoEntities;

      if (context == null) {
          context = new AutoEntities();
        httpContext.Items[contextKey] = context;
      }

      return context;
    }
  }

  public static void Dispose() {
    HttpContext httpContext = HttpContext.Current;

    if (httpContext != null) {
        AutoEntities context = httpContext.Items[contextKey] as AutoEntities;

      if (context != null) {
        context.Dispose();
        httpContext.Items[contextKey] = null;
      }
    }
  }

}
