using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.Rest.Services.DAL.Models
{
    public class UserAuthModel : UserInfo
    {
        public string ConfirmPassword { get; set; }
        public string Token { get; set; }
        public DateTime TokenCreatedDate { get; set; }
        public DateTime TokenExpiryDate { get; set; }
    }
}
