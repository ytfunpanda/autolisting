using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MINI.Models {
    public class AltFeaturesViewModel {
        public VehicleViewModel Vehicle { get; set; }
        public List<VehicleSpecGroupViewModel> SpecGroups { get; set; }
        public string Type { get; set; }
    }
}