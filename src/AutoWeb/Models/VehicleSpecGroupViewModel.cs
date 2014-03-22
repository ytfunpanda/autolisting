using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MINI.Data.Product;

namespace MINI.Models {
  public class VehicleSpecGroupViewModel {
    public string Category { get; set; }
    public string Category_fr { get; set; }
    public int SortOrder { get; set; }
    public List<string> SpecLabels { get; set; }
  }
}