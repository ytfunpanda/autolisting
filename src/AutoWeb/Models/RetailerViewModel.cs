
using System.Collections.Generic;
namespace AutoWeb.Models {
    public class RetailerViewModel {
        public int RetailerID { get; set; }
        public string Lang { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string ProvinceShort { get; set; }
        public string Postal { get; set; }
        public string RetailPhone { get; set; }
        public string SalesPhone { get; set; }
        public string ServicePhone { get; set; }
        public string Email { get; set; }
        public string Email_Fr { get; set; }
        public string Website { get; set; }
        public string MapLink { get; set; }
        public int InternalRetailerID { get; set; }
        public string Lng { get; set; }
        public string Lat { get; set; }
        public string ServicesOffered { get; set; }
        public List<RetailerTeamViewModel> TeamMembers { get; set; }
    }
}