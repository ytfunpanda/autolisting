using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MINI.Models
{
    public class NextViewModel
    {
        public IEnumerable<SelectListItem> ModelListFiltered { get; set; }
        public IList<NextFilterViewModel> ModelList { get; set; }

        public IEnumerable<SelectListItem> VehicleListFiltered { get; set; }
        public IList<NextFilterViewModel> VehicleList { get; set; }

        public IEnumerable<SelectListItem> YearListFiltered { get; set; }
        public IList<NextFilterViewModel> YearList { get; set; }

        public string PriceRangeFiltered { get; set; }
        public IList<NextFilterViewModel> PriceRangeList { get; set; }

        public string KilometerFiltered { get; set; }
        public IList<NextFilterViewModel> KilometerRangeList { get; set; }

        public string ColourFiltered { get; set; }
        public IList<NextFilterViewModel> ColourList { get; set; }

        public string RetailerFiltered { get; set; }
        public IList<NextFilterViewModel> RetailerList { get; set; }

        public string ProvinceFiltered { get; set; }
        public IList<NextFilterViewModel> ProvinceList { get; set; }

        public List<NextVehicleResultItemViewModel> ResultList { get; set; }

        public IEnumerable<SelectListItem> TransmissionListFiltered { get; set; }
        public IList<NextFilterViewModel> TransmissionList { get; set; }

        public bool ShowNewCarOnly { get; set; }

    }
}