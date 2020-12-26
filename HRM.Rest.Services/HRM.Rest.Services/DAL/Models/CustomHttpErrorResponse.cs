using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HRM.Rest.Services.DAL.Models
{
    public class CustomHttpErrorResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public string? ErrorDescription { get; set; }
    }
}
