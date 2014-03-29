using System;
using System.Web.Mvc;
using AutoWeb;

public static class UrlHelperExtensions {
    
    public static string ContentVersioned(this UrlHelper urlHelper, string contentPath) {
      string url = urlHelper.Content(contentPath);
      return String.Format("{0}?v={1}", url, App.CacheBuster);
    }

  }
