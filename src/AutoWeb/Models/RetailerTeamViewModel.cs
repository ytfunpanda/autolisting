namespace AutoWeb.Models {
    public class RetailerTeamViewModel {
        public int RetailerTeamID { get; set; }
        public int RetailerTeamGroupID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Title_Fr { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }

        public string GroupName { get; set; }
        public string GroupName_Fr { get; set; }
    }
}