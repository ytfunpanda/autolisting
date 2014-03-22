using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoWeb.Controllers
{
    public class PermanentRedirectResult : ActionResult
    {
        private const string RedirectPath = "";


        private string _url;

        public PermanentRedirectResult(string url)
        {
            if (url == null)
                throw new ArgumentNullException("url");

            _url = RedirectPath + url;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            context.HttpContext.Response.StatusCode = 301;
            context.HttpContext.Response.RedirectLocation = _url;
            context.HttpContext.Response.End();
        }
    }
}
