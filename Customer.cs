using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting_Software
{
    internal class Customer
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public List<SimpleTransaction> Transactions { get; set; } = new List<SimpleTransaction>();

        public Customer(string name, string phone, string address)
        {
            Name = name;
            Phone = phone;
            Address = address;
        }

        public Customer() { }

        public decimal GetBalance()

        {
            return Transactions.Sum(t => t.Type == TransactionType.Credit ? t.Amount : -t.Amount);
        }

    }
}
