using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting_Software
{
    internal class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; } // Securely stored
        public Role Role { get; set; }

        public User(string username, string password)
        {
            Username = username;
            PasswordHash = password;
        }

        public User() { }
    }
}
