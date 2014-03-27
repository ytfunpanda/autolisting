using System;
using System.Collections.Generic;
using System.Linq;

using AutoMapper;

using AutoWeb.Data;
using AutoWeb.Models;

namespace AutoWeb {
    public class Bootstrap {

        public static void Step1() {
            AutoEntities stdCtx = StandardContextFactory.GetContextPerRequest();
            List<VehicleTypeViewModel> VehicleTypes = Mapper.Map<List<VehicleTypeViewModel>>(stdCtx.VehicleTypes.Where(x=>x.VehicleTypeID>0).OrderBy(x=>x.SortOrder));
            App.Cache.Add(string.Format(App._cacheKeyEn, "VEHICLETYPES", "en"), VehicleTypes, DateTime.Today.AddHours(App._cacheExpiry));

            //List<ListingViewModel> listings = Mapper.Map<List<ListingViewModel>>(stdCtx.Listings.Where(m => m.ListingID > 0));
            //App.Cache.Add(string.Format(App._cacheKeyEn, "LISTINGS", "en"), listings, DateTime.Today.AddHours(App._cacheExpiry));
        }

        public static void Step2() {
            AutoEntities stdCtx = StandardContextFactory.GetContextPerRequest();
           
        }
    }
}
