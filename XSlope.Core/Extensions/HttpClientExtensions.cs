using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace XSlope.Core.Extensions
{
    public static class HttpClientExtensions
    {
        static string Patch = "PATCH";

        public static Task<HttpResponseMessage> PatchAsync(this HttpClient client, Uri uri, HttpContent content)
        {
            var request = new HttpRequestMessage(new HttpMethod(Patch), uri)
            {
                Content = content
            };

            return client.SendAsync(request);
        }
    }
}
