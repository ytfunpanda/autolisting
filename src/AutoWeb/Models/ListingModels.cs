using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace AutoWeb.Models
{
    public class ListingsContext : DbContext
    {
        public ListingsContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<ListingViewModel> Listings { get; set; }
    }

    [Table("Listing")]
    public class ListingViewModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ListingID { get; set; }
        public int UserID { get; set; }
    }
}
