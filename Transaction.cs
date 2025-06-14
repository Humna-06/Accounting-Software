﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Accounting_Software.SimpleTransaction;

namespace Accounting_Software
{
    internal class Transaction
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public TransactionType Type { get; set; }
        public bool IsCredit { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
