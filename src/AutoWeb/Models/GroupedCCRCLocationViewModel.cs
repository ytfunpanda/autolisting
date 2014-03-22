using System.Collections.Generic;

namespace MINI.Models {
  public class GroupedRetailerViewModel {
    public string Province { get; set; }
    public List<RetailerViewModel> Retailers { get; set; }

    public GroupedRetailerViewModel(string provinceName, List<RetailerViewModel> retailers) {
      Province = provinceName;
      Retailers = retailers;
    }

  }
}