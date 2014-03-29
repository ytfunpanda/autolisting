using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auto.Web.Models
{
    public class ListingViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ListingID { get; set; }
        public int UserID { get; set; }
    }
}
