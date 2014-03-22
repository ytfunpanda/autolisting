using System;

namespace MINI.Models {
  public class SpecialOffersDisplayViewModel {
    public int SpecialOfferID { get; set; }
    public string CACode { get; set; }
    public int LeaseTerm { get; set; }
    public int FinanceTerm { get; set; }
    public string NameOverride { get; set; }
    public string Tagline { get; set; }
    public VehicleViewModel Vehicle { get; set; }
    public double LeasePriceOverride { get; set; }
    public double FinancePriceOverride { get; set; }
    public double LeasePercentOverride { get; set; }
    public double FinancePercentOverride { get; set; }
    public double DownPayment { get; set; }
    public double FreightPDIOverride { get; set; }
    public double DeliveryCredit { get; set; }
    public double DealerDiscount { get; set; }
    public DateTime OfferExpiryDate { get; set; }
    public DateTime DeliveryTakenDate { get; set; }
    public string CarImageURL { get; set; }
    public string BackgroundImageURL { get; set; }
    public bool IsDag { get; set; }
    public bool IsActive { get; set; }
    public double BaseMSRPOverride { get; set; }
    public int SortOrder { get; set; }
    public string DefaultColour { get; set; }
    public string NameOverrideFR { get; set; }
    public string TaglineFR { get; set; }
    public double ResidualRateOverride { get; set; }

  }
}