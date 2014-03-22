using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MINI.Models {
  public class StandardFeatureGroupedViewModel {
    public string Category { get; set; }
    public List<StandardFeatureViewModel> StandardFeatures { get; set; }
  }
}