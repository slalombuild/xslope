using XSlope.Core.Handlers.Interfaces;
using XSlope.Core.Managers.Interfaces;
using XSlope.Core.Providers.Interfaces;

namespace XSlope.Core.Managers
{
    public class AuthenticationManager : IAuthenticationManager
    {
        const string UsernameKey = "AuthenticationManager:Username";
        const string TokenKey = "AuthenticationManager:Token";

        readonly ICacheProvider _appCache;

        public AuthenticationManager(ICacheManager cacheManager)
        {
            _appCache = cacheManager.AppCache;
        }

        #region IAuthenticationManager

        public string Username
        {
            get => _appCache.GetObject<string>(UsernameKey);
            set => _appCache.InsertObject(UsernameKey, value);
        }

        public string Token
        {
            get => _appCache.GetObject<string>(TokenKey);
            set => _appCache.InsertObject(TokenKey, value);
        }

        public bool IsAuthenticated => Token != null;

        public IAuthenticationHandler AuthenticationHandler { get; set; }

        #endregion
    }
}
