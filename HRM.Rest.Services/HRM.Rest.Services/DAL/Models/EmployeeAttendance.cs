using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.Rest.Services.DAL.Models
{
    [Table("EMPLOYEE_ATTENDANCE")]
    public class EmployeeAttendance
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime? ClockIn { get; set; }
        public DateTime? ClockOut { get; set; }
        public bool isEmployeeOnLeave { get; set; }
        public bool isApproved { get; set; }
    }
}
