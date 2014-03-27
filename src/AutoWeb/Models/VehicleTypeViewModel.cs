using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace AutoWeb.Models
{
    public class VehicleTypesContext : DbContext
    {
        public VehicleTypesContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<VehicleTypeViewModel> VehicleTypes { get; set; }
    }

    [Table("VehicleType")]
    public class VehicleTypeViewModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int VehicleTypeID { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }
    }
}
