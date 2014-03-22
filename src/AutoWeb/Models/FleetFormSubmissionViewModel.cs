using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MINI.Models
{
    public class FleetFormSubmissionViewModel
    {
        public int FleetID { get; set; }
        public DateTime Timestamp { get; set; }
        public string Lang { get; set; }

        //[Display(Name = "IsExecutiveAllowanceNumberLbl", ResourceType = typeof(Resources.Shopping.MINIFleet))]
        //public bool IsExecutiveAllowanceNumber { get; set; }

        //[Display(Name = "IsFleetAccountNumberLbl", ResourceType = typeof(Resources.Shopping.MINIFleet))]
        //public bool IsFleetAccountNumber { get; set; }

        [Required(ErrorMessageResourceName = "ApplicantNameReq", ErrorMessageResourceType = typeof(Resources.Shopping.MINIFleet))]
        [Display(Name = "ApplicantNameLbl", ResourceType = typeof(Resources.Shopping.MINIFleet))]
        public string ApplicantName { get; set; }

        [Required(ErrorMessageResourceName = "CompanyNameReq", ErrorMessageResourceType = typeof(Resources.Shopping.MINIFleet))]
        [Display(Name = "CompanyNameLbl", ResourceType = typeof(Resources.Shopping.MINIFleet))]
        public string CompanyName { get; set; }

        [Required(ErrorMessageResourceName = "Address1Req", ErrorMessageResourceType = typeof(Resources.Shopping.MINIFleet))]
        [Display(Name = "Address1Lbl", ResourceType = typeof(Resources.Shopping.MINIFleet))]
        public string Address1 { get; set; }

        [Display(Name = "Address2Lbl", ResourceType = typeof(Resources.Shopping.MINIFleet))]
        public string Address2 { get; set; }

        [Required(ErrorMessageResourceName = "CityReq", ErrorMessageResourceType = typeof(Resources.Shopping.MINIFleet))]
        [Display(Name = "CityLbl", ResourceType = typeof(Resources.Shopping.MINIFleet))]
        public string City { get; set; }

        [Required(ErrorMessageResourceName = "ProvinceReq", ErrorMessageResourceType = typeof(Resources.Shopping.MINIFleet))]
        [Display(Name = "ProvinceLbl", ResourceType = typeof(Resources.Shopping.MINIFleet))]
        public string Province { get; set; }
        public IEnumerable<SelectListItem> Provinces { get; set; }

        [Required(ErrorMessageResourceName = "PostalCodeReq", ErrorMessageResourceType = typeof(Resources.Shopping.MINIFleet))]
        [Display(Name = "PostalCodeLbl", ResourceType = typeof(Resources.Shopping.MINIFleet))]
        public string PostalCode { get; set; }

        [Required(ErrorMessageResourceName = "FleetHRManagerReq", ErrorMessageResourceType = typeof(Resources.Shopping.MINIFleet))]
        [Display(Name = "FleetHRManagerLbl", ResourceType = typeof(Resources.Shopping.MINIFleet))]
        public string FleetHRManager { get; set; }

        [Required(ErrorMessageResourceName = "PhoneNumberReq", ErrorMessageResourceType = typeof(Resources.Shopping.MINIFleet))]
        [Display(Name = "PhoneNumberLbl", ResourceType = typeof(Resources.Shopping.MINIFleet))]
        public string Phone { get; set; }

        [Required(ErrorMessageResourceName = "EmailAddressReq", ErrorMessageResourceType = typeof(Resources.Shopping.MINIFleet))]
        [Display(Name = "EmailAddressLbl", ResourceType = typeof(Resources.Shopping.MINIFleet))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "NumberOfVehicleReq", ErrorMessageResourceType = typeof(Resources.Shopping.MINIFleet))]
        [Display(Name = "NumberOfVehicleLbl", ResourceType = typeof(Resources.Shopping.MINIFleet))]
        public string NumberOfVehicleInFleet { get; set; }
    }
}