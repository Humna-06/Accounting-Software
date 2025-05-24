using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting_Software
{
    internal class PayrollRecord
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal TaxDeduction { get; set; }
        public decimal NetSalary => GrossSalary - TaxDeduction;
    }
}
