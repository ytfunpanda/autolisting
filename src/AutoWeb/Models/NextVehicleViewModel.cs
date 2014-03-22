using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MINI.Models
{
    public class NextVehicleViewModel
    {
        public int VehicleID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Trim { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public int KM { get; set; }
        public string Transmission { get; set; }
        public string BodyColour { get; set; }
        public string InteriorColour { get; set; }
        public string VIN { get; set; }
        public string StockNumber { get; set; }
        public string InstalledGoodiesEN { get; set; }
        public string InstalledGoodiesFR { get; set; }
        public string RetailerName { get; set; }
        public int RetailerID { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ShortDetails { get; set; }
        public DateTime DateAdd { get; set; }
        public bool IsActive { get; set; }
        public string Photo { get; set; }
        public int BatchNumber { get; set; }
        public string Status { get; set; }

        public string PhotoMain { get; set; }
        public string[] PhotoList { get; set; }

    }
}