using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.Rest.Services.Util
{
    public class HRMEnums
    {
        public enum Roles {
            Admin = 1,
            Employee = 2
        }
        public enum Departments {
            HumanResources = 1,
            Devops = 2,
            CustomerSupport = 3
        }
        public enum FinanceTypes {
            AdvanceSalary = 1,
            Bonus = 2,
            Loan = 3
        }

    }
}
