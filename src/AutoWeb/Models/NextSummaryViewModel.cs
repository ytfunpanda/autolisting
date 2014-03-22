using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MINI.Models
{
    public class NextSummaryViewModel
    {
        public ModelViewModel Model { get; set; }
        public IList<NextSummaryVehicleViewModel> NextSummaryVehicleViewModels { get; set; }
        public string Image { get; set; }
        public int Count { get; set; }
    }

    public class NextSummaryVehicleViewModel
    {
        public string ShortVehicleName { get; set; }
        public string FullVehicle { get; set; }
        public int Count { get; set; }
    }
}