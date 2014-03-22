using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoWeb.Models;


public static class DataExtensions {
  public static RetailerSiteViewModel FindByDomain(this List<RetailerSiteViewModel> retailerSites, string lookupDomain) {
    //foreach (var item in retailerSites) {
    //  foreach (var domain in item.Domains) {
    //    string d = domain.EndsWith("/") ? domain.TrimEnd('/') : domain; // we test domains without the trailing /
    //    if (d.Equals(lookupDomain)) return item;
    //  }
    //}
    return null;
  }
}
