using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ModernHttpClient;
using Newtonsoft.Json;
using XSlope.Core.Exceptions;
using XSlope.Core.Extensions;
using XSlope.Core.Helpers;

namespace XSlope.Core.Clients
{
    public abstract class BaseClient
    {
        const string JsonContentType = "application/json";

        static readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
        {
            DateTimeZoneHandling = DateTimeZoneHandling.Local
        };

        protected BaseClient(string baseAddress)
        {
            Client = new HttpClient(new NativeMessageHandler())
            {
                BaseAddress = new Uri(baseAddress)
            };
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JsonContentType));
        }

        protected HttpClient Client { get; private set; }

        protected async Task<TResponse> GetAsync<TResponse>(string url, bool allowAnonymous = false)
        {
            HandleAuthorizationHeader(allowAnonymous);
            var response = await Client.GetAsync(url);
            return await HandleResponse<TResponse>(response);
        }

        protected async Task PatchAsync(string url, HttpContent content, bool allowAnonymous = false)
        {
            HandleAuthorizationHeader(allowAnonymous);
            var response = await Client.PatchAsync(new Uri(url), content);
            EnsureSuccess(response);
        }

        protected async Task PostAsync(string url, object requestObject, bool allowAnonymous = false)
        {
            HandleAuthorizationHeader(allowAnonymous);
            var content = CreateStringContent(requestObject);
            var response = await Client.PostAsync(url, content);
            EnsureSuccess(response);
        }

        protected async Task<TResponse> PostAsync<TResponse>(string url, object requestObject, bool allowAnonymous = false)
        {
            HandleAuthorizationHeader(allowAnonymous);
            var content = CreateStringContent(requestObject);
            var response = await Client.PostAsync(url, content);
            return await HandleResponse<TResponse>(response);
        }

        protected async Task<TResponse> PutAsync<TResponse>(string url, object requestObject, bool allowAnonymous = false)
        {
            HandleAuthorizationHeader(allowAnonymous);
            var content = CreateStringContent(requestObject);
            var response = await Client.PutAsync(url, content);
            return await HandleResponse<TResponse>(response);
        }

        protected async Task PutAsync(string url, object requestObject, bool allowAnonymous = false)
        {
            HandleAuthorizationHeader(allowAnonymous);
            var content = CreateStringContent(requestObject);
            var response = await Client.PutAsync(url, content);
            EnsureSuccess(response);
        }

        protected async Task DeleteAsync(string url, bool allowAnonymous = false)
        {
            HandleAuthorizationHeader(allowAnonymous);
            var response = await Client.DeleteAsync(url);
            EnsureSuccess(response);
        }

        protected async Task<T> DeserializeContent<T>(HttpResponseMessage response)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync(), _jsonSerializerSettings);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return default(T);
            }
        }

        protected StringContent CreateStringContent(object content)
        {
            return new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, JsonContentType);
        }

        void HandleAuthorizationHeader(bool allowAnonymous)
        {
            if (!allowAnonymous)
            {
                AddAuthorizationHeader();
            }
        }

        Task<T> HandleResponse<T>(HttpResponseMessage response)
        {
            EnsureSuccess(response);
            return DeserializeContent<T>(response);
        }

        void EnsureSuccess(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new ApiClientException(response);
            }
        }

        protected virtual void AddAuthorizationHeader() { }
    }
}
