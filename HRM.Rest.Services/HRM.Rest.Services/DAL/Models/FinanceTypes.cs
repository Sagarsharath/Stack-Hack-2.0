using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.Rest.Services.DAL.Models
{
    [Table("FINANCE_TYPES")]
    public class FinanceTypes
    {
        public int FinanceTypeId { get; set; }
        public string FinanceTypName { get; set; }
    }
}
