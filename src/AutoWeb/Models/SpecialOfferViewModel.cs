
namespace MINI.Models {
  public class SpecialOfferViewModel {
    public string CACode { get; set; }
    public string LeaseFrom { get; set; }
    public string FinanceFrom { get; set; }
    
    public VehicleViewModel Vehicle { get; set; }
  }
}