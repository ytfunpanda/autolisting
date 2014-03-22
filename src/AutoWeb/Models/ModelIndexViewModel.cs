using System.Collections.Generic;

namespace MINI.Models {
  public class ModelIndexViewModel {
    public ModelViewModel ModelFamily { get; set; }
    public List<VehicleViewModel> Vehicles { get; set; }
    public List<VehicleSpecGroupViewModel> SpecGroups { get; set; }
  }
}