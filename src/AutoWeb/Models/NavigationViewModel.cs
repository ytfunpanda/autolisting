using System.Collections.Generic;

namespace MINI.Models {
  public class NavigationViewModel {
    public string Label { get; set; }
    public string Slug { get; set; }
    public string ECode { get; set; }
    public string Tagline { get; set; }
    public string Price { get; set; }
    public List<NavigationViewModel> SubPages { get; set; }
  }
}