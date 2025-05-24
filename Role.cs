using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting_Software
{
    internal class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } // "Admin", "Accountant", "Clerk"
        public List<string> Permissions { get; set; } = new List<string>();
    }
}
