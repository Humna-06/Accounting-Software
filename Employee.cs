﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting_Software
{
    internal class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
    }
}
