
namespace MINI.Models {
  public class AllInclusivePricingViewModel {
    public decimal FreightAndPDI { get; set; }
    public decimal AirConditioningTax { get; set; }
    public decimal MotorVehicleIndustryCouncilFee { get; set; }
    public decimal RegistrationFeePPSA { get; set; }
    public decimal RetailAdministrationFee { get; set; }
    public decimal TireTax { get; set; }
    public string Province { get; set; }
    public string ProvinceShort { get; set; }
  }
}