using System.Collections.Generic;
using System.Linq;
using System.Web.WebPages.Html;

namespace MINI.Models {
  public class CCRCSearchViewModel {
    public string PostalLocation { get; set; }
    public string RetailerName { get; set; }
    public string ServicesOffered { get; set; }

    public IEnumerable<GroupDropListItem> GroupedLocations {
      get {
          List<CCRCLocationViewModel> retailers = App.Cache.Get(string.Format(App._cacheKeyEn, "CCRCLOCATIONS", App.CurrentUserLanguage.ToLower())) as List<CCRCLocationViewModel>;
          IEnumerable<GroupedCCRCLocationViewModel> groupedRetailers = from r in retailers
                                                                 where r.Language == App.CurrentUserLanguage
                                                                 group r by r.Province into g
                                                                 select new GroupedCCRCLocationViewModel(g.Key, g.OrderBy(r => r.Name).ToList());

        return groupedRetailers.Select(r => new GroupDropListItem {
          Name = r.Province,
          Items = r.Retailers.Select(l => new OptionItem {
            Text = l.Name,
            Value = l.LocationID} ).ToList()
          });
        }
      }
    }
}