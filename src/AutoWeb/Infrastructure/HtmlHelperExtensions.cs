using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web.Routing;

using AutoWeb;
using AutoWeb.Models;

namespace System.Web.Mvc {
    public static class HtmlHelperExtensions {

        public static string GenerateConfigUrl(this HtmlHelper helper, string modelSlug, string vehicleSlug) {
            string domain = App.CurrentUserLanguage == "en" ? ConfigurationManager.AppSettings["ConfigEnglishURL"].ToString() : ConfigurationManager.AppSettings["ConfigFrenchURL"].ToString();
            string province = Cookies.Get("__auto", "uprov").ToString();
            string configUrlMask = "{0}/?p={1}#/{2}/{3}/colours";
            string returnValue = string.Format(configUrlMask, domain, province, modelSlug, vehicleSlug);

            if (string.IsNullOrEmpty(modelSlug) && string.IsNullOrEmpty(vehicleSlug)) {
                configUrlMask = "{0}?p={1}";
                returnValue = string.Format(configUrlMask, domain, province);
            }

            if(AutoWeb.App.CurrentRetailerSite != null) {
                //string retailer = AutoWeb.App.CurrentRetailerSite.Retailer.RetailerID.ToString();
                //configUrlMask = "{0}/?p={1}&r={2}/#/{3}/{4}/colours";
                //returnValue = string.Format(configUrlMask, domain, province, retailer, modelSlug, vehicleSlug);

                //if (string.IsNullOrEmpty(modelSlug) && string.IsNullOrEmpty(vehicleSlug)) {
                //    configUrlMask = "{0}/?p={1}&r={2}";
                //    returnValue = string.Format(configUrlMask, domain, province, retailer);
                //}
            }

            return returnValue;
        }

        public static MvcHtmlString ButtonLink(this HtmlHelper helper, ButtonLinkType type, string url, string label, string additionalCss, object htmlAttributes) {
            TagBuilder container = new TagBuilder("div");
            container.AddCssClass("clearfix");

            TagBuilder link = new TagBuilder("a");
            link.Attributes.Add("href", url);

            bool isModalLink = false;
            foreach (var item in HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes)) {
                if (item.Key.IndexOf("data-") > -1) isModalLink = true;
            }
            if (isModalLink) {
                link.Attributes.Add("data-backdrop", "static");
                link.Attributes.Add("data-keyboard", "false");
            }
            link.AddCssClass("generated-button btn btn-primary gradient-grey shadow ico-btn " + additionalCss);
            if (htmlAttributes != null) {
                link.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            }


            string img = CreateImage(helper, type);
            container.InnerHtml = (img + " " + label);
            link.InnerHtml = container.ToString(TagRenderMode.Normal);


            return MvcHtmlString.Create(link.ToString(TagRenderMode.Normal));
        }
        
        public static MvcHtmlString ButtonLink(this HtmlHelper helper, ButtonLinkType type, string label, string additionalCss, object htmlAttributes) {
            TagBuilder link = new TagBuilder("button");
            link.AddCssClass("btn btn-primary gradient-grey shadow ico-btn " + additionalCss);
            link.Attributes.Add("type", "submit");
            if (htmlAttributes != null) {
                link.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            }

            string img = CreateImage(helper, type);
            link.InnerHtml = (img + " " + label);

            return MvcHtmlString.Create(link.ToString(TagRenderMode.Normal));
        }

        private static string CreateImage(HtmlHelper helper, ButtonLinkType type) {
            TagBuilder img = new TagBuilder("img");
            img.MergeAttribute("width", "26");
            img.MergeAttribute("height", "23");
            string imgSrc = "";
            switch (type) {
                case ButtonLinkType.BACK:
                    imgSrc = "~/Public/img/ico/buttons/clearall.png";
                    break;
                case ButtonLinkType.CLEAR:
                    imgSrc = "~/Public/img/ico/buttons/clearall.png";
                    break;
                case ButtonLinkType.NEXT:
                    imgSrc = "~/Public/img/ico/buttons/clearall.png";
                    break;
                case ButtonLinkType.PREVIOUS:
                    imgSrc = "~/Public/img/ico/buttons/back.png";
                    break;
                default:
                    imgSrc = "~/Public/img/transp-shadow-double-chevron.png";
                    break;
            }
            img.Attributes.Add("src", UrlHelper.GenerateContentUrl(imgSrc, helper.ViewContext.HttpContext).ToString());
            return MvcHtmlString.Create(img.ToString(TagRenderMode.SelfClosing)).ToHtmlString();
        }

        public enum ButtonLinkType {
            NEXT,
            PREVIOUS,
            BACK,
            CLEAR
        }
    }
}