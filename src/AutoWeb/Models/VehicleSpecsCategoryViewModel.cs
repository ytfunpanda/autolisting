using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MINI.Models {
    public class VehicleSpecsCategoryViewModel {
        public string Category { get; set; }
        public string Category_fr { get; set; }
        public string SpecLabel { get; set; }
        public string VehicleSpec { get; set; }
        public int? SortOrder { get; set; }
    }
}