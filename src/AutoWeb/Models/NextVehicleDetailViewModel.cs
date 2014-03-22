using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MINI.Models
{
    public class NextVehicleDetailViewModel
    {
        public NextVehicleViewModel NextVehicle { get; set; }
        public IList<NextVehicleViewModel> SimilarVehicleList { get; set; }
        public RetailerViewModel Retailer { get; set; }

    }
}