using System;
using System.Net.Http;

namespace XSlope.Core.Exceptions
{
    public class ApiClientException : Exception
    {
        public ApiClientException(HttpResponseMessage response)
        {
            HttpResponseMessage = response;
        }

        public HttpResponseMessage HttpResponseMessage { get; private set; }
    }
}
