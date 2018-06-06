using Akavache;
using System;
using XSlope.Core.Providers.Interfaces;
using XSlope.Core.Managers.Interfaces;
using XSlope.Core.Providers;

namespace XSlope.Core.Managers
{
    public class AkavacheCacheManager : ICacheManager
    {
        const string AppCacheFilename = "app.sqlite3";

        public AkavacheCacheManager(IAppNameProvider appNameProvider)
        {
            BlobCache.ApplicationName = appNameProvider.AppName;
            BlobCache.ForcedDateTimeKind = DateTimeKind.Local;

            AppCache = new AkavacheCacheProvider(BlobCache.Secure);
        }

        #region ICacheManager

        public ICacheProvider AppCache { get; private set; }

        #endregion
    }
}
