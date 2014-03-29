using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace AutoWeb.Models
{
    public class StatusTypesContext : DbContext
    {
        public StatusTypesContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<StatusTypeViewModel> StatusTypes { get; set; }
    }

    [Table("StatusType")]
    public class StatusTypeViewModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int StatusTypeID { get; set; }
        public string Lang { get; set; }
        public string Name { get; set; }
    }
}
