using System.Collections.Generic;
using System.Web.WebPages.Html;

namespace MINI.Models {
  public class SettingsViewModel {


    public string Lang { get; set; }
    public string EnProvince { get; set; }
    public bool ShowProvince { get; set; }

    public IEnumerable<SelectListItem> EnProvinces {
      get {
        return new[] {
          new SelectListItem() { Text="Alberta", Value="AB"},
          new SelectListItem() { Text="British Columbia", Value="BC"},
          new SelectListItem() { Text="Manitoba", Value="MB"},
          new SelectListItem() { Text="New Brunswick", Value="NB"},
          new SelectListItem() { Text="Newfoundland and Labrador", Value="NL"},
          new SelectListItem() { Text="Northwest Territories", Value="NT"},
          new SelectListItem() { Text="Nova Scotia", Value="NS"},
          new SelectListItem() { Text="Nunavut", Value="NU"} ,
          new SelectListItem() { Text="Ontario", Value="ON"},
          new SelectListItem() { Text="Prince Edward Island", Value="PEI"},
          new SelectListItem() { Text="Quebec", Value="QC"},
          new SelectListItem() { Text="Saskatchewan", Value="SK"},
          new SelectListItem() { Text="Yukon", Value="YT"}
        };
      }
    }

    public string FrProvince { get; set; }

    public IEnumerable<SelectListItem> FrProvinces {
      get {
        return new[] {
          new SelectListItem() { Text="Alberta", Value="AB"},
          new SelectListItem() { Text="Colombie-Britannique", Value="BC"},
          new SelectListItem() { Text="Manitoba", Value="MB"},
          new SelectListItem() { Text="Nouveau-Brunswick", Value="NB"},
          new SelectListItem() { Text="Terre-Neuve-et-Labrador", Value="NL"},
          new SelectListItem() { Text="Territoires du Nord-Ouest", Value="NT"},
          new SelectListItem() { Text="Nouvelle-Écosse", Value="NS"},
          new SelectListItem() { Text="Nunavut", Value="NU"} ,
          new SelectListItem() { Text="Ontario", Value="ON"},
          new SelectListItem() { Text="Île-du-Prince-Édouard", Value="PEI"},
          new SelectListItem() { Text="Québec", Value="QC"},
          new SelectListItem() { Text="Saskatchewan", Value="SK"},
          new SelectListItem() { Text="Yukon", Value="YT"}
        };
      }
    }
  }
}