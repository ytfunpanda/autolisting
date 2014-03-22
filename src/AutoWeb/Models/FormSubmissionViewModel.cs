using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MINI.Models
{
    public class FormSubmissionViewModel
    {
        public int FormSubmissionID { get; set; }
        public DateTime Timestamp { get; set; }

        public int HiddenRetailerID { get; set; }

        [Required(ErrorMessageResourceName = "ReasonForContactingUsReq", ErrorMessageResourceType = typeof(Resources.Forms.Index))]
        [Display(Name = "ReasonForContactingUsLbl", ResourceType = typeof(Resources.Forms.Index))]
        public string OpportunityType { get; set; }
        public IEnumerable<SelectListItem> OpportunityTypes { get; set; }

        //[Required(ErrorMessageResourceName = "ProvinceReq", ErrorMessageResourceType = typeof(Resources.Forms.Index))]
        [Display(Name = "ProvinceLbl", ResourceType = typeof(Resources.Forms.Index))]
        public string Province { get; set; }
        public IEnumerable<SelectListItem> Provinces { get; set; }

        //[Required(ErrorMessageResourceName = "PreferredRetailerReq", ErrorMessageResourceType = typeof(Resources.Forms.Index))]
        [Display(Name = "PreferredRetailerLbl", ResourceType = typeof(Resources.Forms.Index))]
        public int RetailerNumber { get; set; }
        public IEnumerable<SelectListItem> RetailerList { get; set; }

        [Required(ErrorMessageResourceName = "SalutationReq", ErrorMessageResourceType = typeof(Resources.Forms.Index))]
        [Display(Name = "SalutationLbl", ResourceType = typeof(Resources.Forms.Index))]
        public string Salutation { get; set; }
        public IEnumerable<SelectListItem> Salutations { get; set; }

        [Required(ErrorMessageResourceName = "FirstNameReq", ErrorMessageResourceType = typeof(Resources.Forms.Index))]
        [Display(Name = "FirstNameLbl", ResourceType = typeof(Resources.Forms.Index))]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceName = "LastNameReq", ErrorMessageResourceType = typeof(Resources.Forms.Index))]
        [Display(Name = "LastNameLbl", ResourceType = typeof(Resources.Forms.Index))]
        public string LastName { get; set; }

        //[Required(ErrorMessageResourceName = "EmailAddressReq", ErrorMessageResourceType = typeof(Resources.Forms.Index))]
        [Display(Name = "EmailAddressLbl", ResourceType = typeof(Resources.Forms.Index))]
        public string Email { get; set; }

        //[Required(ErrorMessageResourceName = "PhoneNumberReq", ErrorMessageResourceType = typeof(Resources.Forms.Index))]
        [Display(Name = "PhoneNumberLbl", ResourceType = typeof(Resources.Forms.Index))]
        public string PhoneNumber { get; set; }

        //[Required(ErrorMessageResourceName = "PhoneTypeReq", ErrorMessageResourceType = typeof(Resources.Forms.Index))]
        [Display(Name = "PhoneTypeLbl", ResourceType = typeof(Resources.Forms.Index))]
        public string PhoneType { get; set; }
        public IEnumerable<SelectListItem> PhoneTypes { get; set; }

        [Required(ErrorMessageResourceName = "PreferredContactMethodReq", ErrorMessageResourceType = typeof(Resources.Forms.Index))]
        [Display(Name = "PreferredContactMethodLbl", ResourceType = typeof(Resources.Forms.Index))]
        public string PreferredContactMethod { get; set; }
        public IEnumerable<SelectListItem> PreferredContactMethods { get; set; }

        [Required(ErrorMessageResourceName = "PreferredContactTimeReq", ErrorMessageResourceType = typeof(Resources.Forms.Index))]
        [Display(Name = "PreferredContactTimeLbl", ResourceType = typeof(Resources.Forms.Index))]
        public string PreferredContactTime { get; set; }
        public IEnumerable<SelectListItem> PreferredContactTimes { get; set; }

        [Display(Name = "VehicleLbl", ResourceType = typeof(Resources.Forms.Index))]
        public string Vehicle { get; set; }
        public IEnumerable<SelectListItem> VehicleList { get; set; }

        [Display(Name = "ExpectedPurchaseTimeFrameLbl", ResourceType = typeof(Resources.Forms.Index))]
        public string ExpectedPurchaseTimeframe { get; set; }

        [Display(Name = "HasValidDriversLicenseLbl", ResourceType = typeof(Resources.Forms.Index))]
        public bool HasValidDriversLicense { get; set; }

        [Display(Name = "CommercialEmailOptInLbl", ResourceType = typeof(Resources.Forms.Index))]
        public bool CommercialEmailOptIn { get; set; }

        [Display(Name = "CommentsLbl", ResourceType = typeof(Resources.Forms.Index))]
        public string Comments { get; set; }

        public string ThankYouMessage { get; set; }
        public string Lang { get; set; }

        [Display(Name = "ServiceVehicleLbl", ResourceType = typeof(Resources.Forms.Index))]
        public string ServiceVehicle { get; set; }

        [Display(Name = "ServiceCurrentServiceIntervalLbl", ResourceType = typeof(Resources.Forms.Index))]
        public string CurrentServiceInterval { get; set; }

        [Display(Name = "AddressTypeLbl", ResourceType = typeof(Resources.Forms.Index))]
        public string AddressType { get; set; }
        public IEnumerable<SelectListItem> AddressTypes { get; set; }

        [Display(Name = "Address1Lbl", ResourceType = typeof(Resources.Forms.Index))]
        public string Address1 { get; set; }

        [Display(Name = "Address2Lbl", ResourceType = typeof(Resources.Forms.Index))]
        public string Address2 { get; set; }

        [Display(Name = "CityLbl", ResourceType = typeof(Resources.Forms.Index))]
        public string City { get; set; }

        [Display(Name = "PostalCodeLbl", ResourceType = typeof(Resources.Forms.Index))]
        public string PostalCode { get; set; }

        [Display(Name = "HomePhoneNumberLbl", ResourceType = typeof(Resources.Forms.Index))]
        public string HomePhoneNumber { get; set; }

        [Display(Name = "BusinessPhoneNumberLbl", ResourceType = typeof(Resources.Forms.Index))]
        public string BusinessPhoneNumber { get; set; }

        [Display(Name = "BusinessExtensionPhoneNumberLbl", ResourceType = typeof(Resources.Forms.Index))]
        public string BusinessPhoneNumberExtension { get; set; }

        [Display(Name = "CellPhoneNumberLbl", ResourceType = typeof(Resources.Forms.Index))]
        public string CellPhoneNumber { get; set; }

        [Display(Name = "ServiceHasYourVehicleBeenSeenServicedLbl", ResourceType = typeof(Resources.Forms.Index))]
        public bool ServiceHasYourVehicleBeenSeenServiced { get; set; }

        [Display(Name = "ServiceWhileYourVehicleIsBeingServicedLbl", ResourceType = typeof(Resources.Forms.Index))]
        public bool ServiceWhileYourVehicleIsBeingServiced { get; set; }

        [Display(Name = "MINICanadaExclusiveEventsLbl", ResourceType = typeof(Resources.Forms.Index))]
        public bool ReceiveEvents { get; set; }

        [Display(Name = "MINIRetailerPromotionsLbl", ResourceType = typeof(Resources.Forms.Index))]
        public bool ReceivePromotions { get; set; }

        [Display(Name = "CountryLbl", ResourceType = typeof(Resources.Forms.Index))]
        public string Country { get; set; }
        public IEnumerable<SelectListItem> CountryList { get; set; }

        [Display(Name = "VINLbl", ResourceType = typeof(Resources.Forms.Index))]
        public string VIN { get; set; }

        [Display(Name = "AccountNumberLbl", ResourceType = typeof(Resources.Forms.Index))]
        public string AccountNumber { get; set; }

        [Display(Name = "CommentSubjectLbl", ResourceType = typeof(Resources.Forms.Index))]
        public string CommentSubject { get; set; }
        public IEnumerable<SelectListItem> CommentSubjectList { get; set; }

        public string RetailerLink { get; set; }
    }
}