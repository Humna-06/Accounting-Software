using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting_Software
{
    internal class Invoice
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime IssueDate { get; set; }
        public List<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();
        public decimal TotalAmount => Items.Sum(item => item.Amount);
    }
}
