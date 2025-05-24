using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting_Software
{
    internal class Account
    {

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } // Asset, Liability, Expense, Revenue, Equity
        public decimal Balance { get; set; }
    }
}
