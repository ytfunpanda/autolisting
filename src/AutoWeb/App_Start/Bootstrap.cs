using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auto.Web;
using Auto.Web.Data;

public class Bootstrap
{
    
    public static void Step1()
    {
        AutoDBEntities db = new AutoDBEntities();

        var VehicleTypes = db.VehicleTypes.Where(x => x.VehicleTypeID > 0).OrderBy(x => x.SortOrder).ToList();

        App.Cache.Add(string.Format(App._cacheKeyEn, "VEHICLETYPES", "en"), VehicleTypes.Where(x => x.Lang == "en").ToList(), DateTime.Today.AddHours(App._cacheExpiry));
        App.Cache.Add(string.Format(App._cacheKeyEn, "VEHICLETYPES", "fr"), VehicleTypes.Where(x => x.Lang == "fr").ToList(), DateTime.Today.AddHours(App._cacheExpiry));
        App.Cache.Add(string.Format(App._cacheKeyEn, "VEHICLETYPES", "zh"), VehicleTypes.Where(x => x.Lang == "zh").ToList(), DateTime.Today.AddHours(App._cacheExpiry));
        App.Cache.Add(string.Format(App._cacheKeyEn, "VEHICLETYPES", "de"), VehicleTypes.Where(x => x.Lang == "de").ToList(), DateTime.Today.AddHours(App._cacheExpiry));
        App.Cache.Add(string.Format(App._cacheKeyEn, "VEHICLETYPES", "it"), VehicleTypes.Where(x => x.Lang == "it").ToList(), DateTime.Today.AddHours(App._cacheExpiry));

        //List<StatusType> StatusTypes = stdCtx.StatusTypes.Where(x => x.StatusTypeID > 0).OrderBy(x => x.Name).ToList();
        //App.Cache.Add(string.Format(App._cacheKeyEn, "VEHICLETYPES", "en"), StatusTypes, DateTime.Today.AddHours(App._cacheExpiry));

        //List<ListingViewModel> listings = stdCtx.Listings.Where(m => m.ListingID > 0).ToList();
        //App.Cache.Add(string.Format(App._cacheKeyEn, "LISTINGS", "en"), listings, DateTime.Today.AddHours(App._cacheExpiry));
    }

    public static void Step2()
    {
    }
}
