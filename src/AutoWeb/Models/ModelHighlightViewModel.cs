using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MINI.Models {
  public class ModelHighlightViewModel {
    public int ModelHighlightID { get; set; }
    public string HighlightTitle { get; set; }
    public string Headline { get; set; }
    public string Highlight { get; set; }
    public string HighlightGroup { get; set; }
    public int SortOrder { get; set; }

    public List<ModelHighlightHotSpotViewModel> Hotspots { get; set; }
  }
}