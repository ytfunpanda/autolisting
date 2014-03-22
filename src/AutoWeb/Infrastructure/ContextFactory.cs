using System.Data.Objects;
using System.Web;

using AutoWeb.Data;

public class ContextFactory {

  private static readonly string contextKey = typeof(ObjectContext).FullName;

  public static MINIEntities GetContextPerRequest() {
    HttpContext httpContext = HttpContext.Current;
    if (httpContext == null) {
      return new MINIEntities();
    } else {
      MINIEntities context = httpContext.Items[contextKey] as MINIEntities;

      if (context == null) {
        context = new MINIEntities();
        httpContext.Items[contextKey] = context;
      }

      return context;
    }
  }

  public static void Dispose() {
    HttpContext httpContext = HttpContext.Current;

    if (httpContext != null) {
      MINIEntities context = httpContext.Items[contextKey] as MINIEntities;

      if (context != null) {
        context.Dispose();
        httpContext.Items[contextKey] = null;
      }
    }
  }

}
