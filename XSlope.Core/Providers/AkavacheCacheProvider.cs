using System;
using System.Collections.Generic;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using Akavache;
using XSlope.Core.Providers.Interfaces;

namespace XSlope.Core.Providers
{
    public class AkavacheCacheProvider : ICacheProvider
    {
        readonly IBlobCache _cache;

        public AkavacheCacheProvider(IBlobCache cache)
        {
            _cache = cache;
        }

        public void InsertObject<T>(string key, T value, DateTimeOffset? absoluteExpiration = null)
        {
            _cache.InsertObject(key, value, absoluteExpiration).ToTask().Wait();
        }

        public void DeleteAll()
        {
            _cache.InvalidateAll().ToTask().Wait();
        }

        public void Delete<T>(string key)
        {
            _cache.InvalidateObject<T>(key).ToTask().Wait();
        }

        public T GetObject<T>(string key)
        {
            try
            {
                return _cache.GetObject<T>(key).ToTask().Result;
            }
            catch (AggregateException ex)
            {
                if (ex.InnerExceptions.Count == 1 && ex.InnerExceptions[0] is KeyNotFoundException)
                {
                    return default(T);
                }
                throw ex;
            }
        }

        public Task<T> GetOrFetchObject<T>(string key, Func<Task<T>> fetchFunc)
        {
            return _cache.GetOrFetchObject(key, fetchFunc).ToTask();
        }
    }
}
