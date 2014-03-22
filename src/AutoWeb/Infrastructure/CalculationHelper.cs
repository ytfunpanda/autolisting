using System;
using Microsoft.VisualBasic;

using MINI.Data.Product;

using System.Globalization;
using System.Threading;

//using MINI.Models;

public static class CalculationHelper
{

    #region Lease

    [Flags]
    public enum CalculateLeaseType
    {
        MonthlyPayment,
        CapitalizedCostNet,
        SellingPriceWithFreightPDI,
        SellingPriceSpecialOfferLegal,
        PurchasePrice,
        TotalObligation,
        DueOnDelivery,
        ResidualValue
    }

    [Flags]
    public enum CalculateFinanceType
    {
        BiWeeklyPayment,
        CapitalizedCostNet,
        SellingPriceWithFreightPDI,
        TotalObligation,
        CostOfBorrowing
    }

    [Flags]
    public enum RateType
    {
        Lease,
        Finance,
        Owner
    }

    /// <summary>
    /// Calculates the monthly payment
    /// </summary>
    /// <param name="SubvenedInterestRate">Full interest rate. Ex. 1.9</param>
    /// <param name="Term">Number of months. Ex. 48</param>
    /// <param name="MSRP">MSRP price with options. Ex. 25950</param>
    /// <param name="Prepayment">Down payment amount. Ex. 1300</param>
    /// <param name="DeliveryCredit">Ex. 750</param>
    /// <param name="DealerDiscount">Ex. 0</param>
    /// <param name="FreightPDI">Freight & PDI cost. Ex. 0</param>
    /// <param name="ResidialValueRate">Full interest redidual value rate. Ex. 45</param>
    /// <returns>monthly payment for lease</returns>
    public static double CalculateLease_Monthly(
        double SubvenedInterestRate,
        int Term,
        double MSRP,
        double Prepayment,
        double DeliveryCredit,
        double DealerDiscount,
        double FreightPDI,
        double ResidialValueRate)
    {
        double ResidialValue = MSRP * (ResidialValueRate / 100);
        double SellingPrice = MSRP;
        double CapitalizedCost = SellingPrice - DealerDiscount - DeliveryCredit - Prepayment;
        double MonthlyPayment = Financial.Pmt((SubvenedInterestRate / 100) / 12, Term, -CapitalizedCost, ResidialValue, DueDate.BegOfPeriod);
        return MonthlyPayment;
    }

    public static double CalculateFinance(Price price, Rate rate, double MSRP, double Option, double DownPayment, double DeliveryCredit, double DealerDiscount, double FreightPDI, CalculateFinanceType calculate)
    {
        double amount = 0;
        MSRP = Option != 0 ? MSRP + Option : MSRP;
        switch (calculate)
        {
            case CalculateFinanceType.BiWeeklyPayment:
                double CapitalizedCost = MSRP - DealerDiscount - DeliveryCredit - DownPayment;
                double MonthlyPmt = Financial.Pmt(((double)rate.InterestRate / 100) / 12, (Int32)rate.Term, -CapitalizedCost, 0, DueDate.EndOfPeriod);
                amount = (MonthlyPmt * 12) / 26;
                break;
            case CalculateFinanceType.CapitalizedCostNet:
                double SellingPrice = MSRP + (double)price.FreightAndPDI;
                amount = SellingPrice - DealerDiscount - DeliveryCredit - DownPayment;
                break;
            case CalculateFinanceType.SellingPriceWithFreightPDI:
                amount = MSRP + (double)price.FreightAndPDI;
                break;
            case CalculateFinanceType.TotalObligation:
                double Calculated_BiWeeklyPayment = CalculationHelper.CalculateFinance(price, rate, MSRP, Option, DownPayment, DeliveryCredit, DealerDiscount, FreightPDI, CalculationHelper.CalculateFinanceType.BiWeeklyPayment);
                amount = Calculated_BiWeeklyPayment * (((Int32)rate.Term / 12) * 26) + DownPayment;
                break;
            case CalculateFinanceType.CostOfBorrowing:
                amount = CalculationHelper.CalculateFinance(price, rate, MSRP, Option, DownPayment, DeliveryCredit, DealerDiscount, FreightPDI, CalculationHelper.CalculateFinanceType.TotalObligation) - MSRP;
                break;
            default:
                amount = 0;
                break;
        }
        return amount;
    }

    public static double CalculateLease(Price price, Rate rate, double MSRP, double Option, double Prepayment, double DeliveryCredit, double DealerDiscount, double FreightPDI, CalculateLeaseType calculate)
    {
        double amount, MonthlyPayment = 0;
        MSRP = Option != 0 ? MSRP + Option : MSRP;
        switch (calculate)
        {
            case CalculateLeaseType.ResidualValue:
                amount = MSRP * ((double)rate.ResidualRate / 100);
                break;
            case CalculateLeaseType.MonthlyPayment:
                amount = CalculateLease_Monthly((double)rate.InterestRate, (Int32)rate.Term, (double)MSRP, (double)Prepayment, (double)DeliveryCredit, (double)DealerDiscount, FreightPDI, (double)rate.ResidualRate);
                break;
            case CalculateLeaseType.CapitalizedCostNet:
                double SellingPrice = MSRP + FreightPDI;
                amount = SellingPrice - DealerDiscount - DeliveryCredit - Prepayment;
                break;
            case CalculateLeaseType.SellingPriceWithFreightPDI:
                amount = MSRP + FreightPDI;
                break;
            case CalculateLeaseType.SellingPriceSpecialOfferLegal:
                amount = MSRP + FreightPDI + (double)price.AirConditioningTax + (double)price.MotorVehicleIndustryCouncilFee + (double)price.TireTax;
                break;
            case CalculateLeaseType.PurchasePrice:
                amount = MSRP + (double)price.AirConditioningTax + (double)price.MotorVehicleIndustryCouncilFee + (double)price.RetailAdministrationFee + (double)price.TireTax + (double)+price.RegistrationFeePPSA;
                break;
            case CalculateLeaseType.TotalObligation:
                MonthlyPayment = CalculateLease_Monthly((double)rate.InterestRate, (Int32)rate.Term, (double)MSRP, (double)Prepayment, (double)DeliveryCredit, (double)DealerDiscount, FreightPDI, (double)rate.ResidualRate);
                // accurate for October ????
                //amount = (MonthlyPayment * (Int32)rate.Term) + MonthlyPayment + (double)price.FreightAndPDI + (double)price.AirConditioningTax + (double)price.MotorVehicleIndustryCouncilFee + (double)price.RetailAdministrationFee + (double)price.TireTax + (double)+price.RegistrationFeePPSA;

                // accurate for november ????
                amount = (MonthlyPayment * (Int32)rate.Term) + MonthlyPayment + MonthlyPayment + Prepayment + FreightPDI + (double)price.AirConditioningTax + (double)price.MotorVehicleIndustryCouncilFee + (double)price.RetailAdministrationFee + (double)price.TireTax + (double)+price.RegistrationFeePPSA;

                break;
            case CalculateLeaseType.DueOnDelivery:
                MonthlyPayment = CalculateLease_Monthly((double)rate.InterestRate, (Int32)rate.Term, (double)MSRP, (double)Prepayment, (double)DeliveryCredit, (double)DealerDiscount, FreightPDI, (double)rate.ResidualRate);
                amount = MonthlyPayment + MonthlyPayment + FreightPDI + (double)price.AirConditioningTax + (double)price.MotorVehicleIndustryCouncilFee + (double)price.RetailAdministrationFee + (double)price.TireTax + (double)+price.RegistrationFeePPSA;
                break;
            default:
                amount = 0;
                break;
        }
        return amount;
    }

    #endregion

    public static double CalculateLeaseResidualValue(double MSRP, double ResidualRate) {
        double amount = 0;
        amount = MSRP * ((double)ResidualRate / 100);

        return amount;
    }

    public static double CalculateLeaseMonthlyPayment(double InterestRate, Int32 Term, double MSRP, double Prepayment, double DeliveryCredit, double DealerDiscount, double FreightPDI, double ResidualRate) {
        double amount = 0;
        amount = amount = CalculateLease_Monthly((double)InterestRate, (Int32)Term, (double)MSRP, (double)Prepayment, (double)DeliveryCredit, (double)DealerDiscount, FreightPDI, (double)ResidualRate);
        
        return amount;
    }

    public static double CalculateLeaseCapitalizedCostNet(double MSRP, double FreightPDI, double DealerDiscount, double DeliveryCredit, double Prepayment) {
        double amount = 0;
        double SellingPrice = MSRP + FreightPDI;
        amount = SellingPrice - DealerDiscount - DeliveryCredit - Prepayment;

        return amount;
    }

    public static double CalculateLeaseSellingPriceWithFreightPDI(double MSRP, double FreightPDI) {
        double amount = 0;
        amount = MSRP + FreightPDI;

        return amount;
    }

    public static double CalculateLeasePurchasePrice(double MSRP, double AirConditioningTax, double MotorVehicleIndustryCouncilFee, double RetailAdministrationFee, double TireTax, double RegistrationFeePPSA) {
        double amount = 0;
        amount = MSRP + (double)AirConditioningTax + (double)MotorVehicleIndustryCouncilFee + (double)RetailAdministrationFee + (double)TireTax + (double)+RegistrationFeePPSA;

        return amount;
    }

    public static double CalculateLeaseTotalObligation(double InterestRate, Int32 Term, double MSRP, double Prepayment, double DeliveryCredit, double DealerDiscount, double FreightPDI, double ResidualRate, double AirConditioningTax, double MotorVehicleIndustryCouncilFee, double RetailAdministrationFee, double TireTax, double RegistrationFeePPSA) {
        double amount = 0;
        double MonthlyPayment = CalculateLease_Monthly((double)InterestRate, (Int32)Term, (double)MSRP, (double)Prepayment, (double)DeliveryCredit, (double)DealerDiscount, FreightPDI, (double)ResidualRate);
        amount = (MonthlyPayment * (Int32)Term) + MonthlyPayment + MonthlyPayment + Prepayment + FreightPDI + (double)AirConditioningTax + (double)MotorVehicleIndustryCouncilFee + (double)RetailAdministrationFee + (double)TireTax + (double)+RegistrationFeePPSA;

        return amount;
    }

    public static double CalculateLeaseDueOnDelivery(double InterestRate, Int32 Term, double MSRP, double Prepayment, double DeliveryCredit, double DealerDiscount, double FreightPDI, double ResidualRate, double AirConditioningTax, double MotorVehicleIndustryCouncilFee, double RetailAdministrationFee, double TireTax, double RegistrationFeePPSA) {
        double amount = 0;
        double MonthlyPayment = CalculateLease_Monthly((double)InterestRate, (Int32)Term, (double)MSRP, (double)Prepayment, (double)DeliveryCredit, (double)DealerDiscount, FreightPDI, (double)ResidualRate);
        amount = MonthlyPayment + MonthlyPayment + FreightPDI + (double)AirConditioningTax + (double)MotorVehicleIndustryCouncilFee + (double)RetailAdministrationFee + (double)TireTax + (double)+RegistrationFeePPSA;

        return amount;
    }

    public static double CalculateFinanceBiWeeklyPayment(double MSRP, double DealerDiscount, double DownPayment, double DeliveryCredit, decimal InterestRate, int Term) {
        
        double amount = 0;
        double CapitalizedCost = MSRP - DealerDiscount - DeliveryCredit - DownPayment;
        double MonthlyPmt = Financial.Pmt(((double)InterestRate / 100) / 12, (Int32)Term, -CapitalizedCost, 0, DueDate.EndOfPeriod);
        amount = (MonthlyPmt * 12) / 26;

        return amount;

    }

    public static double CalculateFinaceCapitalizedCostNet(double MSRP, double FreightAndPDI, double DealerDiscount, double DeliveryCredit, double DownPayment) {
        double amount = 0;
        double SellingPrice = MSRP + (double)FreightAndPDI;
        amount = SellingPrice - DealerDiscount - DeliveryCredit - DownPayment;

        return amount;
    }

    public static double CalculateFinanceSellingPriceWithFreightPDI(double MSRP, double FreightAndPDI) {
        double amount = 0;

        return amount;
    }

    public static double CalculateFinanceTotalObligation(double MSRP, double DealerDiscount, double DownPayment, double DeliveryCredit, decimal InterestRate, int Term) {
        double amount = 0;
        double Calculated_BiWeeklyPayment = CalculationHelper.CalculateFinanceBiWeeklyPayment(MSRP, DealerDiscount, DownPayment, DeliveryCredit, InterestRate, Term);
        amount = Calculated_BiWeeklyPayment * (((Int32)Term / 12) * 26) + DownPayment;

        return amount;
    }

    public static double CalculateFinanceCostOfBorrowing(double MSRP, double DealerDiscount, double DownPayment, double DeliveryCredit, decimal InterestRate, int Term) {
        double amount = CalculationHelper.CalculateFinanceTotalObligation(MSRP, DealerDiscount, DownPayment, DeliveryCredit, InterestRate, Term) - MSRP;
        
        return amount;
    }

    #region Legal

    public static string GenerateSpecialOfferLegal(Vehicle Vehicle, Price Price, Rate RateLease, Rate RateFinance,
        string Name,
        string TotalSellingPrice,
        string Price_FeeAndLevies,
        string DownPayment,
        string FreightAndPDI,
        string FinanceBiweeklyPrice,
        string FinanceCostOfBorrowing,
        string FinanceTotalObligation,
        string LeaseMonthlyPayment,
        string LeaseTotalObligation,
        string LeaseResidualValue,
        string OfferExpiryDate,
        string DeliveryTakenDate,
        string CultureName)
    {
        string cultureString = "en-ca";
        if (CultureName.ToUpperInvariant() == "FR") {
            cultureString = "fr-ca";
        }
        CultureInfo newCulture = new CultureInfo(cultureString);
        Thread.CurrentThread.CurrentCulture = newCulture;
        Thread.CurrentThread.CurrentUICulture = newCulture;
        string legal = MINI.Resources.SpecialOffers.Legal.SpecialOfferLegal;

        legal = legal.Replace("[Name]", Name);
        legal = legal.Replace("[TotalSellingPrice]", TotalSellingPrice);
        legal = legal.Replace("[Vehicle_Price]", Convert.ToDouble(Vehicle.Price).ToString("C"));
        legal = legal.Replace("[Price_FreightAndPDI]", FreightAndPDI);
        legal = legal.Replace("[Price_FeeAndLevies]", Price_FeeAndLevies);
        legal = legal.Replace("[Price_AirConditioningTax]", Price.AirConditioningTax.ToString("C"));
        legal = legal.Replace("[Price_MotorVehicleIndustryCouncilFee]", Price.MotorVehicleIndustryCouncilFee.ToString("C"));
        legal = legal.Replace("[Price_TireTax]", Price.TireTax.ToString("C"));
        legal = legal.Replace("[Rate_FinancePercent]", RateFinance.InterestRate.ToString());
        legal = legal.Replace("[Rate_FinanceTerm]", RateFinance.Term.ToString());
        legal = legal.Replace("[FinanceBiweeklyPrice]", FinanceBiweeklyPrice);
        legal = legal.Replace("[FinanceCostOfBorrowing]", FinanceCostOfBorrowing);
        legal = legal.Replace("[FinanceTotalObligation]", FinanceTotalObligation);
        legal = legal.Replace("[Price_RegistrationFeePPSA]", Price.RegistrationFeePPSA.ToString("C"));
        legal = legal.Replace("[Rate_LeasePercent]", RateLease.InterestRate.ToString());
        legal = legal.Replace("[Rate_LeaseTerm]", RateLease.Term.ToString());
        legal = legal.Replace("[LeaseMonthlyPayment]", LeaseMonthlyPayment);
        legal = legal.Replace("[DownPayment]", DownPayment);
        legal = legal.Replace("[Price_RetailAdministrationFee]", Price.RetailAdministrationFee.ToString("C"));
        legal = legal.Replace("[LeaseTotalObligation]", LeaseTotalObligation);
        legal = legal.Replace("[LeaseResidualValue]", LeaseResidualValue);
        legal = legal.Replace("[OfferExpiryDate]", OfferExpiryDate);
        legal = legal.Replace("[DeliveryTakenDate]", DeliveryTakenDate);

        return legal;
    }

    public static string GenerateSpecialOfferLegal(VehicleViewModel Vehicle, AllInclusivePricingViewModel Price, RateViewModel RateLease, RateViewModel RateFinance,
          string Name,
          string TotalSellingPrice,
          string Price_FeeAndLevies,
          string DownPayment,
          string FreightAndPDI,
          string FinanceBiweeklyPrice,
          string FinanceCostOfBorrowing,
          string FinanceTotalObligation,
          string LeaseMonthlyPayment,
          string LeaseTotalObligation,
          string LeaseResidualValue,
          string OfferExpiryDate,
          string DeliveryTakenDate,
          string CultureName) {

        string cultureString = "en-ca";
        if (CultureName.ToUpperInvariant() == "FR") {
            cultureString = "fr-ca";
        }
      CultureInfo newCulture = new CultureInfo(cultureString);
      Thread.CurrentThread.CurrentCulture = newCulture;
      Thread.CurrentThread.CurrentUICulture = newCulture;
      string legal = MINI.Resources.SpecialOffers.Legal.SpecialOfferLegal;
      if (MINI.App.CurrentUserProvince == "AB") {
          legal = MINI.Resources.SpecialOffers.Legal.SpecialOfferLegal_AB;
      }

      legal = legal.Replace("[Name]", Name);
      legal = legal.Replace("[TotalSellingPrice]", TotalSellingPrice);
      legal = legal.Replace("[Vehicle_Price]", Convert.ToDouble(Vehicle.Price).ToString("C"));
      legal = legal.Replace("[Price_FreightAndPDI]", FreightAndPDI);
      legal = legal.Replace("[Price_FeeAndLevies]", Price_FeeAndLevies);
      legal = legal.Replace("[Price_AirConditioningTax]", Price.AirConditioningTax.ToString("C"));
      legal = legal.Replace("[Price_MotorVehicleIndustryCouncilFee]", Price.MotorVehicleIndustryCouncilFee.ToString("C"));
      legal = legal.Replace("[Price_TireTax]", Price.TireTax.ToString("C"));
      legal = legal.Replace("[Rate_FinancePercent]", RateFinance.InterestRate.ToString());
      legal = legal.Replace("[Rate_FinanceTerm]", RateFinance.Term.ToString());
      legal = legal.Replace("[FinanceBiweeklyPrice]", FinanceBiweeklyPrice);
      legal = legal.Replace("[FinanceCostOfBorrowing]", FinanceCostOfBorrowing);
      legal = legal.Replace("[FinanceTotalObligation]", FinanceTotalObligation);
      legal = legal.Replace("[Price_RegistrationFeePPSA]", Price.RegistrationFeePPSA.ToString("C"));
      legal = legal.Replace("[Rate_LeasePercent]", RateLease.InterestRate.ToString());
      legal = legal.Replace("[Rate_LeaseTerm]", RateLease.Term.ToString());
      legal = legal.Replace("[LeaseMonthlyPayment]", LeaseMonthlyPayment);
      legal = legal.Replace("[DownPayment]", DownPayment);
      legal = legal.Replace("[Price_RetailAdministrationFee]", Price.RetailAdministrationFee.ToString("C"));
      legal = legal.Replace("[LeaseTotalObligation]", LeaseTotalObligation);
      legal = legal.Replace("[LeaseResidualValue]", LeaseResidualValue);
      legal = legal.Replace("[OfferExpiryDate]", Convert.ToDateTime(OfferExpiryDate).ToString(cultureString=="en-ca"?"MMMM d, yyyy":" d MMMM yyyy"));
      legal = legal.Replace("[DeliveryTakenDate]", Convert.ToDateTime(DeliveryTakenDate).ToString(cultureString == "en-ca" ? "MMMM d, yyyy" : " d MMMM yyyy"));

      return legal;
    }

    #endregion
}