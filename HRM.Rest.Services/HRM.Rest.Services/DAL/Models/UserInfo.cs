using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.Rest.Services.DAL.Models
{
    public class UserInfo
    {
        public int UserId { get; set; }
        public string UserEmailId { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }

    }
}
