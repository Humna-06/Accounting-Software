using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounting_Software;
using System.Configuration;
namespace Accounting_Software
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "your_connection_string_here";
            DatabaseHelpers dbHelper = new DatabaseHelpers(connectionString);

            // Create employee
            Console.WriteLine("Adding an Employee...");
            bool empCreated = dbHelper.CreateEmployee("John Doe", "1234567890", "123 Street", "Accountant", 50000);
            Console.WriteLine(empCreated ? "Employee added successfully!" : "Error adding employee.");

            // Read employees
            Console.WriteLine("\nFetching Employees...");
            DataTable employees = dbHelper.GetEmployees();
            foreach (DataRow row in employees.Rows)
            {
                Console.WriteLine($"ID: {row["ID"]}, Name: {row["Name"]}, Position: {row["Position"]}, Salary: {row["Salary"]}");
            }

            // Update employee
            Console.WriteLine("\nUpdating Employee...");
            bool empUpdated = dbHelper.UpdateEmployee(1, "0987654321", "456 Avenue", 60000);
            Console.WriteLine(empUpdated ? "Employee updated successfully!" : "Error updating employee.");

            // Delete employee
            Console.WriteLine("\nDeleting Employee...");
            bool empDeleted = dbHelper.DeleteEmployee(1);
            Console.WriteLine(empDeleted ? "Employee deleted successfully!" : "Error deleting employee.");

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
            Transaction transaction = new Transaction();
            transaction.Type = TransactionType.Credit;
            transaction.Amount = 1000;

            Console.WriteLine($"Transaction Type: {transaction.Type}, Amount: {transaction.Amount}");




        }
    }
}
