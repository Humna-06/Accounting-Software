using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting_Software
{
    internal class JournalEntry
    {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public int AccountId { get; set; }
        public bool IsDebit { get; set; }
        public decimal Amount { get; set; }
    }
}
