using System.Collections.Generic;

namespace MINI.Models {
  public class GroupedCCRCLocationViewModel {
    public string Province { get; set; }
    public List<CCRCLocationViewModel> Retailers { get; set; }

    public GroupedCCRCLocationViewModel(string provinceName, List<CCRCLocationViewModel> retailers) {
      Province = provinceName;
      Retailers = retailers;
    }

  }
}