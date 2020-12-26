using System;
using System.Net.Http;
using System.Runtime.Serialization;

namespace HRM.Rest.Services.Controllers
{
    [Serializable]
    internal class HttpResponseException : Exception
    {
        private HttpResponseMessage resp;

        public HttpResponseException()
        {
        }

        public HttpResponseException(HttpResponseMessage resp)
        {
            this.resp = resp;
        }

        public HttpResponseException(string message) : base(message)
        {
        }

        public HttpResponseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected HttpResponseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}