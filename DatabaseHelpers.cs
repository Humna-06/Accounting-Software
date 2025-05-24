using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting_Software
{
    internal class DatabaseHelpers
    {
        private readonly string _connectionString = @"Data Source=DESKTOP-MCQ2T8F\\SQLEXPRESS;Initial Catalog=AccountingSoftware;Integrated Security=True";




        public DatabaseHelpers(string connectionString)
        {
            _connectionString = connectionString;
            Console.WriteLine($"Using Connection String: {@"Data Source=DESKTOP-MCQ2T8F\\SQLEXPRESS;Initial Catalog=AccountingSoftware;Integrated Security=True"}");

        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(@"Data Source=DESKTOP-MCQ2T8F\\SQLEXPRESS;Initial Catalog=AccountingSoftware;Integrated Security=True");

        
        }

        // General method for executing Non-Query (Insert, Update, Delete)
        private bool ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                        command.Parameters.AddRange(parameters);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        // General method for executing Query (Select)
        private DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                        command.Parameters.AddRange(parameters);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

        // USER MANAGEMENT CRUD
        public bool CreateUser(string username, string passwordHash, int roleId)
        {
            string query = "INSERT INTO Users (Username, PasswordHash, RoleID) VALUES (@Username, @PasswordHash, @RoleID)";
            SqlParameter[] parameters = {
                new SqlParameter("@Username", username),
                new SqlParameter("@PasswordHash", passwordHash),
                new SqlParameter("@RoleID", roleId)
            };
            return ExecuteNonQuery(query, parameters);
        }

        public DataTable GetUsers()
        {
            return ExecuteQuery("SELECT * FROM Users");
        }

        public bool UpdateUser(int userId, string newPasswordHash)
        {
            string query = "UPDATE Users SET PasswordHash = @PasswordHash WHERE ID = @UserID";
            SqlParameter[] parameters = {
                new SqlParameter("@PasswordHash", newPasswordHash),
                new SqlParameter("@UserID", userId)
            };
            return ExecuteNonQuery(query, parameters);
        }

        public bool DeleteUser(int userId)
        {
            string query = "DELETE FROM Users WHERE ID = @UserID";
            SqlParameter[] parameters = { new SqlParameter("@UserID", userId) };
            return ExecuteNonQuery(query, parameters);
        }

        // ACCOUNTING CRUD
        public bool CreateAccount(string code, string name, string type, decimal balance)
        {
            string query = "INSERT INTO Accounts (Code, Name, Type, Balance) VALUES (@Code, @Name, @Type, @Balance)";
            SqlParameter[] parameters = {
                new SqlParameter("@Code", code),
                new SqlParameter("@Name", name),
                new SqlParameter("@Type", type),
                new SqlParameter("@Balance", balance)
            };
            return ExecuteNonQuery(query, parameters);
        }

        public DataTable GetAccounts()
        {
            return ExecuteQuery("SELECT * FROM Accounts");
        }

        public bool UpdateAccountBalance(int accountId, decimal newBalance)
        {
            string query = "UPDATE Accounts SET Balance = @Balance WHERE AccountID = @AccountID";
            SqlParameter[] parameters = {
                new SqlParameter("@Balance", newBalance),
                new SqlParameter("@AccountID", accountId)
            };
            return ExecuteNonQuery(query, parameters);
        }

        public bool DeleteAccount(int accountId)
        {
            string query = "DELETE FROM Accounts WHERE AccountID = @AccountID";
            SqlParameter[] parameters = { new SqlParameter("@AccountID", accountId) };
            return ExecuteNonQuery(query, parameters);
        }

        // CUSTOMER CRUD
        public bool CreateCustomer(string name, string phone, string address)
        {
            string query = "INSERT INTO Customers (Name, Phone, Address) VALUES (@Name, @Phone, @Address)";
            SqlParameter[] parameters = {
                new SqlParameter("@Name", name),
                new SqlParameter("@Phone", phone),
                new SqlParameter("@Address", address)
            };
            return ExecuteNonQuery(query, parameters);
        }

        public DataTable GetCustomers()
        {
            return ExecuteQuery("SELECT * FROM Customers");
        }

        public bool UpdateCustomer(int customerId, string newPhone, string newAddress)
        {
            string query = "UPDATE Customers SET Phone = @Phone, Address = @Address WHERE ID = @CustomerID";
            SqlParameter[] parameters = {
                new SqlParameter("@Phone", newPhone),
                new SqlParameter("@Address", newAddress),
                new SqlParameter("@CustomerID", customerId)
            };
            return ExecuteNonQuery(query, parameters);
        }

        public bool DeleteCustomer(int customerId)
        {
            string query = "DELETE FROM Customers WHERE ID = @CustomerID";
            SqlParameter[] parameters = { new SqlParameter("@CustomerID", customerId) };
            return ExecuteNonQuery(query, parameters);
        }

        // INVOICE CRUD
        public bool CreateInvoice(int customerId, decimal totalAmount)
        {
            string query = "INSERT INTO Invoices (CustomerID, IssueDate, TotalAmount) VALUES (@CustomerID, GETDATE(), @TotalAmount)";
            SqlParameter[] parameters = {
                new SqlParameter("@CustomerID", customerId),
                new SqlParameter("@TotalAmount", totalAmount)
            };
            return ExecuteNonQuery(query, parameters);
        }

        public DataTable GetInvoices()
        {
            return ExecuteQuery("SELECT * FROM Invoices");
        }

        public bool UpdateInvoiceTotal(int invoiceId, decimal newTotalAmount)
        {
            string query = "UPDATE Invoices SET TotalAmount = @TotalAmount WHERE ID = @InvoiceID";
            SqlParameter[] parameters = {
                new SqlParameter("@TotalAmount", newTotalAmount),
                new SqlParameter("@InvoiceID", invoiceId)
            };
            return ExecuteNonQuery(query, parameters);
        }

        public bool DeleteInvoice(int invoiceId)
        {
            string query = "DELETE FROM Invoices WHERE ID = @InvoiceID";
            SqlParameter[] parameters = { new SqlParameter("@InvoiceID", invoiceId) };
            return ExecuteNonQuery(query, parameters);
        }

        public bool CreateEmployee(string name, string phone, string address, string position, decimal salary)
        {
            string query = "INSERT INTO Employees (Name, Phone, Address, Position, Salary, HireDate) VALUES (@Name, @Phone, @Address, @Position, @Salary, GETDATE())";
            SqlParameter[] parameters = {
        new SqlParameter("@Name", name),
        new SqlParameter("@Phone", phone),
        new SqlParameter("@Address", address),
        new SqlParameter("@Position", position),
        new SqlParameter("@Salary", salary)
    };
            return ExecuteNonQuery(query, parameters);
        }

        public DataTable GetEmployees()
        {
            return ExecuteQuery("SELECT * FROM Employees");
        }

        public bool UpdateEmployee(int employeeId, string phone, string address, decimal salary)
        {
            string query = "UPDATE Employees SET Phone = @Phone, Address = @Address, Salary = @Salary WHERE ID = @EmployeeID";
            SqlParameter[] parameters = {
        new SqlParameter("@Phone", phone),
        new SqlParameter("@Address", address),
        new SqlParameter("@Salary", salary),
        new SqlParameter("@EmployeeID", employeeId)
    };
            return ExecuteNonQuery(query, parameters);
        }

        public bool DeleteEmployee(int employeeId)
        {
            string query = "DELETE FROM Employees WHERE ID = @EmployeeID";
            SqlParameter[] parameters = { new SqlParameter("@EmployeeID", employeeId) };
            return ExecuteNonQuery(query, parameters);
        }
    }
}
