using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MINI.Models.ModelFilter {
    public class VehicleViewModel {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string TrimName { get; set; }
        //public string IntroBlurb { get; set; }
        public string Tagline { get; set; }
        //public string Tagline_Fr { get; set; }
        public string CACode { get; set; }
        public string UrlSlug { get; set; }

        public string EngineOutput { get; set; }

        public string AutomaticAcceleration { get; set; }
        public string ManualAcceleration { get; set; }

        public string AutomaticConsumption { get; set; }
        public string ManualConsumption { get; set; }
        public string LuggageSpace { get; set; }

        public string AutomaticPrice { get; set; }
        public string ManualPrice { get; set; } 

        public bool IsAll4 { get; set; }
        public bool Is4Door { get; set; }
        public bool IsTopless { get; set; }
    }
}