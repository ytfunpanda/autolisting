using System;
using System.Collections.Generic;

namespace AutoWeb.Models {
    public class RetailerSiteViewModel {
        public int RetailerSiteID { get; set; }
        public RetailerViewModel Retailer { get; set; }
        public List<string> Domains { get; set; }
        public string WelcomeMessage { get; set; }
        public string WelcomeMessageFr { get; set; }
        public string About { get; set; }
        public string AboutFr { get; set; }
        public string Hours { get; set; }
        public DateTime CreatedOn { get; set; }
        public string AnalyticsID { get; set; }
        public bool IsActive { get; set; }

        
    }
}