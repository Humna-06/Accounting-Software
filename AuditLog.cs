using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting_Software
{
    internal class AuditLog
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public string Details { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public int UserId { get; set; }
    }
}
