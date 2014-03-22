
using System.Collections.Generic;
namespace MINI.Models {
  public class ModelViewModel {
    public int ModelID { get; set; }
    public string ModelSlug { get; set; }
    public string Name { get; set; }
    public string ShortName { get; set; }
    public string Tagline { get; set; }
    public decimal BasePrice { get; set; }
    public int SortOrder { get; set; }
    public string ECode { get; set; }
    public List<ModelHighlightGroupViewModel> Highlights { get; set; }
  }
}