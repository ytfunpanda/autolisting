using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MINI.Models
{
    public class FormSubscribeViewModel
    {
        [Required(ErrorMessageResourceName = "ProvinceReq", ErrorMessageResourceType = typeof(Resources.Forms.Index))]
        [Display(Name = "ProvinceLbl", ResourceType = typeof(Resources.Forms.Index))]
        public string Province { get; set; }
        public IEnumerable<SelectListItem> Provinces { get; set; }

        [Required(ErrorMessageResourceName = "FirstNameReq", ErrorMessageResourceType = typeof(Resources.Forms.Index))]
        [Display(Name = "FirstNameLbl", ResourceType = typeof(Resources.Forms.Index))]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceName = "LastNameReq", ErrorMessageResourceType = typeof(Resources.Forms.Index))]
        [Display(Name = "LastNameLbl", ResourceType = typeof(Resources.Forms.Index))]
        public string LastName { get; set; }

        [Required(ErrorMessageResourceName = "EmailAddressReq", ErrorMessageResourceType = typeof(Resources.Forms.Index))]
        [Display(Name = "EmailAddressLbl", ResourceType = typeof(Resources.Forms.Index))]
        public string Email { get; set; }

        [Display(Name = "MINICanadaExclusiveEventsLbl", ResourceType = typeof(Resources.Forms.Index))]
        public bool MINICanadaExclusiveEvents { get; set; }

        [Display(Name = "MINIRetailerPromotionsLbl", ResourceType = typeof(Resources.Forms.Index))]
        public bool MINIRetailerPromotions { get; set; }

        [Display(Name = "CommercialEmailOptInLbl", ResourceType = typeof(Resources.Forms.Index))]
        public bool CommercialEmailOptIn { get; set; }

        [Display(Name = "QuestionCommentLbl", ResourceType = typeof(Resources.Forms.Index))]
        public string Comments { get; set; }

        public string ThankYouMessage { get; set; }
        
        public string Lang { get; set; }

    }

    public class FormUnsubscribeViewModel
    {
        [Required(ErrorMessageResourceName = "EmailAddressReq", ErrorMessageResourceType = typeof(Resources.Forms.Index))]
        [Display(Name = "EmailAddressLbl", ResourceType = typeof(Resources.Forms.Index))]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

}