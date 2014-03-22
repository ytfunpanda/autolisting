
using System.Collections.Generic;
namespace MINI.Models {
    public class PackageViewModel {
        public string WebsitePackageGroups { get; set; }
        public string Code { get; set; }
        public string FullName { get; set; }
        public string FullName_Fr { get; set; }
        //public string Description { get; set; }
        //public string Description_Fr { get; set; }
        public string Price { get; set; }
        public string Category { get; set; }

        public List<OptionViewModel> PackageOptions { get; set; }

        public bool Merged { get; set; }
    }
}