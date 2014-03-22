
namespace MINI.Models {
  public class RateViewModel {
    public int RateID { get; set; }
    public string CACode { get; set; }
    public double InterestRate { get; set; }
    public double ResidualRate { get; set; }
    public int Term { get; set; }
    public double DownPayment { get; set; }
    public string ProvinceShort { get; set; }
    public string RateType { get; set; }
  }
}