﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Auto.Web.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AutoDBEntities : DbContext
    {
        public AutoDBEntities()
            : base("name=AutoDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<StatusType> StatusTypes { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<webpages_Membership> webpages_Membership { get; set; }
        public DbSet<webpages_OAuthMembership> webpages_OAuthMembership { get; set; }
        public DbSet<webpages_Roles> webpages_Roles { get; set; }
    }
}
