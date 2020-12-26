using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HRM.Rest.Services.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "hi";
        }
    }
}
