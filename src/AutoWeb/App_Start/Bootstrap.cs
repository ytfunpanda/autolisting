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
            //List<ModelViewModel> models = Mapper.Map<List<ModelViewModel>>(ctx.Models.Where(m => m.Lang == "en"));
            //App.Cache.Add(string.Format(App._cacheKeyEn, "MODELS", "en"), models, DateTime.Today.AddHours(App._cacheExpiry));
        }

        public static void Step2() {
            AutoEntities stdCtx = StandardContextFactory.GetContextPerRequest();
           
        }
    }
}
