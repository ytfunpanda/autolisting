using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;

    public static class ResourceHelpers {
        public static Dictionary<string, string> GetModelFilterTranslations() {
          //ResourceSet resourceSet = AutoWeb.Resources.Shopping.ModelFilter.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            Dictionary<string, string> model = new Dictionary<string,string>();
          //foreach (DictionaryEntry entry in resourceSet) {
          //  model.Add(entry.Key.ToString(), entry.Value.ToString());
          //}

          return model;
        }
    }
