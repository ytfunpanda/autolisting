using System.Collections.Generic;

namespace MINI.Models {
  public class VehicleViewModel {
    public int ModelID { get; set; }
    public string UrlSlug { get; set; }
    public string Name { get; set; }
    public string ShortName { get; set; }
    public string TrimName { get; set; }
    public string IntroBlurb { get; set; }
    public string Tagline { get; set; }
    public string Tagline_Fr { get; set; }
    public decimal Price { get; set; }
    public string CACode { get; set; }
    public int SortOrder { get; set; }

    public ModelViewModel ModelFamily { get; set; }
    public List<ColourViewModel> Colours { get; set; }
    public List<UpholsteryViewModel> Interiors { get; set; }
    public List<PackageViewModel> Packages { get; set; }
    public List<OptionViewModel> Options { get; set; }
    public SpecsViewModel Specs { get; set; }
    public List<StandardFeatureViewModel> StandardFeatures { get; set; }
    public List<StandardFeatureGroupedViewModel> GroupedStandardFeatures { get; set; }
    public List<GroupedSpecsViewModel> GroupedSpecs { get; set; }
    public List<RateViewModel> LeaseRates { get; set; }
    public List<RateViewModel> FinanceRates { get; set; }
    public List<AllInclusivePricingViewModel> AllInclusivePricing { get; set; }
  }
}