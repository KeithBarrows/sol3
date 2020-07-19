using Microsoft.Extensions.Configuration;
using Sol3.Standard.Infrastructure.Extensions;
using Sol3.Standard.Infrastructure.Pattern.Creational;
using System;
using System.Runtime.Caching;

namespace Sol3.Core.Infrastructure.Configuration
{
    public class Config : Singleton<Config>
    {
        private ObjectCache _cache;
        private CacheItemPolicy _cacheItemPolicy;
        private bool _isProduction;
        private IConfigurationRoot _appSettings;
        private const string CACHE_CONFIG_KEY = "FacilityConfigs";
        private const string CACHE_CONFIG_VALUE = "FacilityConfigValues";


        public IConfigurationRoot AppSettings => _appSettings;
        public string ConnectionStringQa => AppSettings["ConnectionStrings:GeoTrackQa"];
        public string ConnectionStringProd => AppSettings["ConnectionStrings:GeoTrack00"];
        public string ConnectionStringProd01 => AppSettings["ConnectionStrings:GeoTrack01"];
        public string ConnectionStringProd02 => AppSettings["ConnectionStrings:GeoTrack02"];
        public string ConnectionStringNational => AppSettings["ConnectionStrings:GeoTrackNational"];
        public int CacheExpireMinutes => AppSettings["ConfigCacheExpireInMinutes"].ToInt();
        public string ContentRootPath { get; set; }


        public Config()
        {
            ContentRootPath = AppInfo.Instance.ContentRootPath;
            _appSettings = AppSettingsJson.GetAppSettings(ContentRootPath);

            _cache = MemoryCache.Default;
            _cacheItemPolicy = new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(CacheExpireMinutes) };
            _cache.Set(CACHE_CONFIG_KEY, CACHE_CONFIG_VALUE, _cacheItemPolicy);
        }
    }
}
