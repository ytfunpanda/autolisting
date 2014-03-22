using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MINI.Models {
  public class SpecsViewModel {
    [Display(Name = "OutputLabel", ResourceType = typeof(Resources.Models.VehicleSpecsViewModelStrings))]
    public string Output { get; set; }

    [Display(Name = "MaxTorqueLabel", ResourceType = typeof(Resources.Models.VehicleSpecsViewModelStrings))]
    public string MaxTorqueRevs { get; set; }

    [Display(Name = "AccelerationLabel", ResourceType = typeof(Resources.Models.VehicleSpecsViewModelStrings))]
    public string Acceleration { get; set; }

    [Display(Name = "TopSpeedLabel", ResourceType = typeof(Resources.Models.VehicleSpecsViewModelStrings))]
    public string TopSpeed { get; set; }

    [Display(Name = "FuelUrbanLabel", ResourceType = typeof(Resources.Models.VehicleSpecsViewModelStrings))]
    public string FuelConsumptionUrban { get; set; }

    [Display(Name = "FuelUrbanExtraLabel", ResourceType = typeof(Resources.Models.VehicleSpecsViewModelStrings))]
    public string FuelConsumptionExtraUrban { get; set; }

    [Display(Name = "FuelCombinedLabel", ResourceType = typeof(Resources.Models.VehicleSpecsViewModelStrings))]
    public string FuelConsumptionCombined { get; set; }

    [Display(Name = "CurbWeightLabel", ResourceType = typeof(Resources.Models.VehicleSpecsViewModelStrings))]
    public string CurbWeigth { get; set; }

    //[Display(Name = "MaxWeightLabel", ResourceType = typeof(Resources.Models.VehicleSpecsViewModelStrings))]
    //public string MaxPermissibleWeight { get; set; }

    //[Display(Name = "PermittedRoofLabel", ResourceType = typeof(Resources.Models.VehicleSpecsViewModelStrings))]
    //public string PermittedRoofLoad { get; set; }

    [Display(Name = "BootSpaceLabel", ResourceType = typeof(Resources.Models.VehicleSpecsViewModelStrings))]
    public string BootSpace { get; set; }

    [Display(Name = "TankCapacityLabel", ResourceType = typeof(Resources.Models.VehicleSpecsViewModelStrings))]
    public string TankCapacity { get; set; }

    [Display(Name = "DimensionsLabel", ResourceType = typeof(Resources.Models.VehicleSpecsViewModelStrings))]
    public string Dimensions { get; set; }

    [Display(Name = "EngineArchitectureLabel", ResourceType = typeof(Resources.Models.VehicleSpecsViewModelStrings))]
    public string EngineArchitecture { get; set; }

    [Display(Name = "DisplacementLabel", ResourceType = typeof(Resources.Models.VehicleSpecsViewModelStrings))]
    public string Displacement { get; set; }

    [Display(Name = "BoreStrokeLabel", ResourceType = typeof(Resources.Models.VehicleSpecsViewModelStrings))]
    public string BoreStroke { get; set; }

    [Display(Name = "CO2EmissionsLabel", ResourceType = typeof(Resources.Models.VehicleSpecsViewModelStrings))]
    public string CO2Emissions { get; set; }

    [Display(Name = "MaxRangeLabel", ResourceType = typeof(Resources.Models.VehicleSpecsViewModelStrings))]
    public string MaxRange { get; set; }

    [Display(Name = "EngineSpecificationsLabel", ResourceType = typeof(Resources.Models.VehicleSpecsViewModelStrings))]
    public string EngineSpecifications { get; set; }

    [Display(Name = "TransmissionLabel", ResourceType = typeof(Resources.Models.VehicleSpecsViewModelStrings))]
    public string Transmission { get; set; }

    [Display(Name = "CompressionLabel", ResourceType = typeof(Resources.Models.VehicleSpecsViewModelStrings))]
    public string Compression { get; set; }

    [Display(Name = "TowingCapacityLabel", ResourceType = typeof(Resources.Models.VehicleSpecsViewModelStrings))]
    public string TowingCapacity { get; set; }

    [Display(Name = "ChargeLabel", ResourceType = typeof(Resources.Models.VehicleSpecsViewModelStrings))]
    public string Charge { get; set; }

    [Display(Name = "PowerOutputLabel", ResourceType = typeof(Resources.Models.VehicleSpecsViewModelStrings))]
    public string PowerOutput { get; set; }

    [Display(Name = "PowerToWeightLabel", ResourceType = typeof(Resources.Models.VehicleSpecsViewModelStrings))]
    public string PowerToWeightRation { get; set; }

    [Display(Name = "FlexibilityLabel", ResourceType = typeof(Resources.Models.VehicleSpecsViewModelStrings))]
    public string Flexibility { get; set; }

    [Display(Name = "PermittedLoadLabel", ResourceType = typeof(Resources.Models.VehicleSpecsViewModelStrings))]
    public string PermittedLoad { get; set; }

    [Display(Name = "LoadPerAxleLabel", ResourceType = typeof(Resources.Models.VehicleSpecsViewModelStrings))]
    public string LoadPerAxle { get; set; }

    [Display(Name = "WheelsLabel", ResourceType = typeof(Resources.Models.VehicleSpecsViewModelStrings))]
    public string Wheels { get; set; }

    [Display(Name = "WheelSizeLabel", ResourceType = typeof(Resources.Models.VehicleSpecsViewModelStrings))]
    public string WheelSize { get; set; }

    [Display(Name = "FrontBrakesLabel", ResourceType = typeof(Resources.Models.VehicleSpecsViewModelStrings))]
    public string FrontBrakes { get; set; }

    [Display(Name = "RearBrakesLabel", ResourceType = typeof(Resources.Models.VehicleSpecsViewModelStrings))]
    public string RearBrakes { get; set; }

    [Display(Name = "WeightDistributionLabel", ResourceType = typeof(Resources.Models.VehicleSpecsViewModelStrings))]
    public string WeightDistribution { get; set; }

    [Display(Name = "WheelBaseLabel", ResourceType = typeof(Resources.Models.VehicleSpecsViewModelStrings))]
    public string Wheelbase { get; set; }

    [Display(Name = "TrackLabel", ResourceType = typeof(Resources.Models.VehicleSpecsViewModelStrings))]
    public string Track { get; set; }

    [Display(Name = "InteriorWidthLabel", ResourceType = typeof(Resources.Models.VehicleSpecsViewModelStrings))]
    public string InteriorWidth { get; set; }

    [Display(Name = "HeadroomLabel", ResourceType = typeof(Resources.Models.VehicleSpecsViewModelStrings))]
    public string Headroom { get; set; }
    
    [Display(Name = "LegroomLabel", ResourceType = typeof(Resources.Models.VehicleSpecsViewModelStrings))]
    public string Legroom { get; set; }
  }
}