using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.Rest.Services.DAL.Models
{
    [Table("USER_INFO")]
    public class UserInfo
    {
        public int UserId { get; set; }
        public string UserEmailId { get; set; }
        public string Password { get; set; }
        public string ContactNumber { get; set; }
        public string SecondaryContactNumber { get; set; }
        public int Compensation { get; set; }
        public Role Role { get; set; }
        public Department Department { get; set; }
        public Address Address { get; set; }
        public Address SecondaryAddress { get; set; }
        public List<EmployeeAttendance> EmployeeAttendances { get; set; }
        public List<EmployeeFinances> EmployeeFinances { get; set; }

    }
}
