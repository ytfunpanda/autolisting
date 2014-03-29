using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auto.Web.Data;
using Auto.Web.Resources;

namespace Auto.Web.Controllers
{
    public class HomeController : Controller
    {
        //IDBService _db;
        //public HomeController(ServiceProxy db) { _db = db; }
        //public HomeController() { _db = new ServiceProxy(App.Cache, App._cacheKeyEn, App.CurrentUserLanguage); }

        public ActionResult Index()
        {
            var VehicleTypes = App.Cache.Get(string.Format(App._cacheKeyEn, "VEHICLETYPES",App.CurrentUserLanguage)) as List<VehicleType>;
            foreach (var vt in VehicleTypes)
            {
                ViewBag.Message += "<div>" + vt.Name + "</div>";
            }
            return View();
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
