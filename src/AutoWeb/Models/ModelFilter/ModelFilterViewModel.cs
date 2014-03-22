using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MINI.Models.ModelFilter {
    public class ModelFilterViewModel {
        public List<ModelViewModel> Models { get; set; }

        public string[] PriceRange { get; set; }
        public string[] OutputRange { get; set; }
        public string[] CombinedAccelerationRange { get; set; }
        public string[] AutomaticAccelerationRange { get; set; }
        public string[] ManualAccelerationRange { get; set; }
        public string[] ConsumptionRange { get; set; }
        public string[] LuggageSpaceRange { get; set; }

    }
}