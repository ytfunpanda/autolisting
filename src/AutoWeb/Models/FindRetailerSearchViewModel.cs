using System.Collections.Generic;
using System.Linq;
using System.Web.WebPages.Html;
using AutoWeb;
using AutoWeb.Models;

namespace MINI.Models {
  public class FindRetailerSearchViewModel {
    public string PostalLocation { get; set; }
    public string RetailerName { get; set; }
    public string ServicesOffered { get; set; }

    public IEnumerable<SelectListItem> Services {
      get {

              return new[] {
                  new SelectListItem() { Text=Resources.Retailers.Index.AllSelectLbl, Value="ALL"},
                  new SelectListItem() { Text=Resources.Retailers.Index.SalesSelectLbl, Value="SALES"},
                  new SelectListItem() { Text=Resources.Retailers.Index.NextSelectLbl, Value="NEXT"},
                  new SelectListItem() { Text=Resources.Retailers.Index.ServiceSelectLbl, Value="SERVICE"},
                  new SelectListItem() { Text=Resources.Retailers.Index.PartsSelectLbl, Value="PARTS"}
              };
      }
    }

    //public IEnumerable<GroupDropListItem> GroupedRetailers {
    //  get {
    //    List<RetailerViewModel> retailers = App.Cache.Get(string.Format(App._cacheKeyEn, "RETAILERS", App.CurrentUserLanguage)) as List<RetailerViewModel>;
    //    IEnumerable<GroupedRetailerViewModel> groupedRetailers = from r in retailers
    //                                                             where r.Lang == App.Lang
    //                                                             group r by r.Province into g
    //                                                             select new GroupedRetailerViewModel(g.Key, g.OrderBy(r => r.Name).ToList());

    //    return groupedRetailers.Select(r => new GroupDropListItem {
    //      Name = r.Province,
    //      Items = r.Retailers.Select(l => new OptionItem {
    //        Text = l.Name,
    //        Value = l.InternalRetailerID} ).ToList()
    //      });
    //    }
    //  }
    }

  public class GroupDropListItem {
    public string Name { get; set; }
    public List<OptionItem> Items { get; set; }
  }

  public class OptionItem {
    public string Text { get; set; }
    public int Value { get; set; }
  }
}