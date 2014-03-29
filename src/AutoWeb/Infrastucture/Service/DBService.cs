namespace Auto.Web.Infrastructure.Service {
    public class ServiceProxy : IDBService {
        private CacheHelper _cacheHelper;
        private string _cacheKey;
        private string _language;

        public ServiceProxy(CacheHelper cacheHelper, string cacheKey, string language) {
            _cacheHelper = cacheHelper;
            _cacheKey = cacheKey;
            _language = !string.IsNullOrEmpty(language) ? language : "en";
        }

        /// <summary>
        /// Get cached date with default lang
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public virtual T GetData<T>(string identifier) {
            return (T) _cacheHelper.Get(string.Format(_cacheKey, identifier, _language.ToLowerInvariant()));
        }

        /// <summary>
        /// Get cached data with lang override
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="identifier"></param>
        /// <param name="lang"></param>
        /// <returns></returns>
        public virtual T GetData<T>(string identifier, string lang) {
            return (T)_cacheHelper.Get(string.Format(_cacheKey, identifier, lang.ToLowerInvariant()));
        }
    }
}