using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.Rest.Services.DAL.Models
{
    public class EmployeeFinances
    {
        public int Id { get; set; }
        public int AmountSanctioned { get; set; }
        public int? Tenure { get; set; }
        public decimal? InterestRate { get; set; }
        public DateTime DateRequested { get; set; }
        public DateTime DateSanctioned { get; set; }
        public bool IsApproved { get; set; }
        public bool IsClosed { get; set; }
        //public DateTime DateRequested { get; set; }
    }
}
