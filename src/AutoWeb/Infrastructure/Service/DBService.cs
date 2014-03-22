namespace AutoWeb.Infrastructure.Service {
    public class ServiceProxy : IDBService {
        private CacheHelper _cacheHelper;
        private string _cacheKey;
        private string _language;

        public ServiceProxy(CacheHelper cacheHelper, string cacheKey, string language) {
            _cacheHelper = cacheHelper;
            _cacheKey = cacheKey;
            _language = !string.IsNullOrEmpty(language) ? language : "en";
        }

        public virtual T GetData<T>(string identifier) {
            return (T) _cacheHelper.Get(string.Format(_cacheKey, identifier, _language.ToLowerInvariant()));
        }


        // sometimes we set the languate after this class has been instantiated, this method
        // allows us to pass the language in at method execution time.
        public virtual T GetData<T>(string identifier, string lang) {
            return (T)_cacheHelper.Get(string.Format(_cacheKey, identifier, lang.ToLowerInvariant()));
        }
    }
}