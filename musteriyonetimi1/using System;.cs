using System;
using System.Data.SqlClient;

namespace SqlAndCSharpExample
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string connectionString = "Data Source=CustomerDB;Initial Catalog=localhost\SQLEXPRESS;Integrated Security=True";

            
            string createTableSql = @"
                CREATE TABLE Customers (
                    CustomerID int NOT NULL PRIMARY KEY,
                    FirstName nvarchar(50),
                    LastName nvarchar(50),
                    Email nvarchar(50),
                    Address nvarchar(50),
                    City nvarchar(50),
                    Country nvarchar(50)
                )
            ";

            
            string insertCustomerSql = @"
                INSERT INTO Customers (CustomerID, FirstName, LastName, Email, Address, City, Country) 
                VALUES (1, 'John', 'Doe', 'johndoe@example.com', '123 Main St', 'Anytown', 'USA')
            ";

            
            string selectCustomersSql = "SELECT * FROM Customers";

            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                
                SqlCommand createTableCommand = new SqlCommand(createTableSql, connection);

                
                createTableCommand.ExecuteNonQuery();

                
                SqlCommand insertCustomerCommand = new SqlCommand(insertCustomerSql, connection);

                
                insertCustomerCommand.ExecuteNonQuery();

                
                SqlCommand selectCustomersCommand = new SqlCommand(selectCustomersSql, connection);

                
                SqlDataReader reader = selectCustomersCommand.ExecuteReader();

                
                while (reader.Read())
                {
                    Console.WriteLine("{0} {1} ({2})", reader["FirstName"], reader["LastName"], reader["Email"]);
                }

                
                reader.Close();
            }

            
            Console.ReadLine();
        }
    }
}