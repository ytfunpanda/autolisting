using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

using MINI.Data.Product;
using MINI.Models;


public static class VehicleHelpers {
    const string COOPER = "Cooper";
    const string COOPERS = "Cooper S";
    const string JCW = "John Cooper Works";

    // generates a variant only name for a vehicle (Cooper, Cooper S or John Cooper Works)
    public static string GenerateVehicleTrimName(this string name) {
        string vehicleTrimName = name;
        bool includeAll4 = vehicleTrimName.ToUpper().EndsWith("ALL4") ? true : false;

        vehicleTrimName = vehicleTrimName.Remove(0, 10).Trim();

        if (vehicleTrimName == JCW || vehicleTrimName == COOPERS || vehicleTrimName == COOPER) {
            if (includeAll4) vehicleTrimName = IncludeAll4(vehicleTrimName);

            return vehicleTrimName.Trim();
        }

        if (vehicleTrimName.IndexOf(JCW) > -1 && vehicleTrimName.Length > JCW.Length) {
            vehicleTrimName = vehicleTrimName.Remove(18);
        } else if (vehicleTrimName.IndexOf(COOPERS) > -1 && vehicleTrimName.Length > COOPERS.Length) {
            vehicleTrimName = vehicleTrimName.Remove(8);
        } else if (vehicleTrimName.IndexOf(COOPER) > -1 && vehicleTrimName.Length > COOPER.Length && name.Length >= 15) {
            vehicleTrimName = vehicleTrimName.Remove(7);
        }

        if (includeAll4) vehicleTrimName = IncludeAll4(vehicleTrimName); ;

        return vehicleTrimName.Trim();
    }

    private static string IncludeAll4(string name) {
        return String.Concat(name.Trim(), " ALL4");
    }

    public static List<PackageViewModel> MergeGroupedPackages(this List<PackageViewModel> packages, string eCode) {
        if(packages == null || (packages != null && packages.Count == 0))
            return null;
        if (string.IsNullOrEmpty(eCode))
            return null;

        // we actually need all packages for this model, not just this trim level.
        List<PackageViewModel> modelPackages = GetModelPackages(eCode);
        List<PackageViewModel> mergedPackages = new List<PackageViewModel>();
        string[] otherPackages;
        string groupId = "";

        // now that we have our results, we have to go through and combine any items that share
        // the WebsiteProductGroups
        foreach (var item in packages) {
            // this package is part of a group of packages
            if (!item.Merged && item.WebsitePackageGroups != null && item.WebsitePackageGroups.Split(',').Length > 0) {
                otherPackages = item.WebsitePackageGroups.Split(',');
                if (otherPackages.Length > 0) {
                    groupId = otherPackages.FirstOrDefault(op => op.Substring(0, 3) == eCode);
                    List<PackageViewModel> groupedPackages = !string.IsNullOrEmpty(groupId) 
                        ? FindGroupedPackages(modelPackages, groupId)
                        : new List<PackageViewModel>();
                        
                    item.Merged = true;
                    PackageViewModel itemPackage = item;
                    itemPackage.WebsitePackageGroups = groupId;
                    foreach (var gp in groupedPackages) {
                        if (itemPackage.Code.IndexOf(gp.Code) < 0) {
                            itemPackage.Code = string.Join(",", itemPackage.Code, gp.Code);
                        }
                    }

                    itemPackage = CombineGroupedPackages(item, groupedPackages);
                    mergedPackages.Add(itemPackage);
                }
            } else {
                mergedPackages.Add(item);
            }

        }
        return mergedPackages.Distinct().ToList();
    }

    private static List<PackageViewModel> GetModelPackages(string eCode) {
        MINIEntities ctx = ContextFactory.GetContextPerRequest();
        List<PackageViewModel> modelPackages = new List<PackageViewModel>();
        
        IQueryable<Vehicle> vehicles = ctx.Vehicles.Where(v => v.Model.ECode == eCode && v.Lang == "en");
        Package package = null;
        VehiclePackage vehiclePackage = null;
        
        foreach (var item in vehicles) {
            vehiclePackage = ctx.VehiclePackages.FirstOrDefault(vp => vp.CACode == item.CACode);
            if (vehiclePackage != null) {
                foreach (var p in vehiclePackage.Packages.Split(',')) {
                    package = ctx.Packages.FirstOrDefault(pp => pp.Code == p);
                    if (package != null) {
                        PackageViewModel packageViewModel = Mapper.Map<PackageViewModel>(package);
                        packageViewModel.PackageOptions = GetPackageOptions(packageViewModel.Code);
                        modelPackages.Add(packageViewModel);
                    }
                }
            }
        }

        return modelPackages;
    }

    private static List<OptionViewModel> GetPackageOptions(string packageCode) {
        MINIEntities ctx = ContextFactory.GetContextPerRequest();
        List<OptionViewModel> packageOptions = new List<OptionViewModel>();

        PackageOption packageOption = ctx.PackageOptions.FirstOrDefault(po => po.PackageCode == packageCode);
        Option option = null;
        OptionViewModel optionViewModel = null;
        foreach (var item in packageOption.Options.Split(',')) {
            option = ctx.Options.FirstOrDefault(o => o.Code == item);
            if (option != null && packageOptions.Where(po => po.Code ==option.Code).Count() == 0) {
                optionViewModel = Mapper.Map<OptionViewModel>(option);
                packageOptions.Add(optionViewModel);
            }
        }

        return packageOptions.Distinct().ToList();
    }

    private static List<PackageViewModel> FindGroupedPackages(List<PackageViewModel> allPackages, string groupId) {
        List<PackageViewModel> relatedPackages = new List<PackageViewModel>();
        foreach (var item in allPackages) {
            if (item.WebsitePackageGroups != null && !item.Merged) {
                string[] otherPackages = item.WebsitePackageGroups.Split(',');
                if (otherPackages.Length > 0) {
                    bool exists = otherPackages.FirstOrDefault(op => op == groupId) != null;
                    if (exists) {
                        item.Merged = true;
                        relatedPackages.Add(item);
                    }
                }
            }
        }
        return relatedPackages;
    }

    private static PackageViewModel CombineGroupedPackages(PackageViewModel package, List<PackageViewModel> packages) {
        foreach (var item in packages) {
            foreach (var option in item.PackageOptions) {
                if (package.PackageOptions.Where(po => po.Code == option.Code).Count() == 0) {
                    package.PackageOptions.Add(option);
                }
            }
        }

        return package;
    }

    
    // if the App.CurrentUserProv is quebec we need to display 
    // base price + freight + pdi.  all other provinces see
    // base price
    public static string PriceForDisplay(this VehicleViewModel vehicle, string province, SpecialOffersDisplayViewModel specialOffer) {
        ModelViewModel modelFamily = vehicle.ModelFamily;

        if (specialOffer.BaseMSRPOverride > 0)
            vehicle.Price = Convert.ToDecimal(specialOffer.BaseMSRPOverride);
        return PriceForDisplay(modelFamily, vehicle, province);
    }

    public static string PriceForDisplay(ModelViewModel modelFamily, VehicleViewModel vehicle, string currentProvince) {
        AllInclusivePricingViewModel pricing = vehicle.AllInclusivePricing.FirstOrDefault(p => p.ProvinceShort == "QC");

        if (currentProvince.ToUpperInvariant() != "QC")
            return vehicle.Price.ToString("c0");
        
        //return Decimal.Add(vehicle.Price, pricing.FreightAndPDI).ToString("c0");
        // QC base MSRP is no longer displayed as base + PDI
        return vehicle.Price.ToString("c0");
    }

    public static string AllInclusivePricingDisplay(this VehicleViewModel vehicle, string province) {
        AllInclusivePricingViewModel allInPricing = vehicle.AllInclusivePricing.FirstOrDefault(p => p.ProvinceShort == province);

        return (vehicle.Price + allInPricing.AirConditioningTax + allInPricing.FreightAndPDI + allInPricing.MotorVehicleIndustryCouncilFee + allInPricing.RegistrationFeePPSA + allInPricing.RetailAdministrationFee + allInPricing.TireTax).ToString("c0");
    }

    public static bool IsAll4(this Vehicle vehicle) {
        bool isAll4 = vehicle.Name.ToUpperInvariant().IndexOf("ALL4") > -1;
        return isAll4;
    }
}
