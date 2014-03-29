using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoWeb.Infrastructure.Enums;

namespace AutoWeb.Controllers
{
    public class SiteController : Controller
    {
        public ActionResult ChangeCulture(Culture lang, string returnUrl)
        {
            var langCookie = new HttpCookie("lang", lang.ToString()) { HttpOnly = true };
            Response.AppendCookie(langCookie);
            if (returnUrl.Length >= 3)
            {
                returnUrl = returnUrl.Substring(3);
            }
            return Redirect("/" + lang.ToString() + returnUrl);
        }
    }
}
