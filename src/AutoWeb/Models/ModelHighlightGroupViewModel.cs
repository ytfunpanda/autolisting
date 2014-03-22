using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MINI.Models {
  public class ModelHighlightGroupViewModel {
    public string HighlightGroup { get; set; }
    public List<ModelHighlightViewModel> Highlights { get; set; }
  }
}