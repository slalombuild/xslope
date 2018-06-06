using System;
using System.Threading.Tasks;

namespace XSlope.Core.Providers.Interfaces
{
    public interface ICacheProvider
    {
        void InsertObject<T>(string key, T value, DateTimeOffset? absoluteExpiration = null);
        void DeleteAll();
        void Delete<T>(string key);
        T GetObject<T>(string key);
        Task<T> GetOrFetchObject<T>(string key, Func<Task<T>> fetchFunc);
    }
}
