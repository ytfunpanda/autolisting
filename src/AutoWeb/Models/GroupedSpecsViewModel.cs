using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MINI.Models {
  public class GroupedSpecsViewModel {
    public string Category { get; set; }
    public string Category_fr { get; set; }
    public int SortOrder { get; set; }
    public List<Dictionary<string, string>> Specs { get; set; }
    public List<VehicleSpecsCategoryViewModel> Specs2 { get; set; }
  }
}