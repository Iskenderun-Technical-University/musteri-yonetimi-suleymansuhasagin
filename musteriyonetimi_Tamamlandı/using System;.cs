using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CustomerManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to the Customer Management System!");
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Add a new customer");
                Console.WriteLine("2. View all customers");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");

                string input = Console.ReadLine();
                if (input == "1")
                {
                    AddCustomer();
                }
                else if (input == "2")
                {
                    ViewCustomers();
                }
                else if (input == "3")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }

        static void AddCustomer()
        {
            Console.Write("Enter customer name: ");
            string name = Console.ReadLine();
            Console.Write("Enter customer email: ");
            string email = Console.ReadLine();
            Console.Write("Enter customer phone number: ");
            string phone = Console.ReadLine();
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-NHRND48\\SQLEXPRESS;Initial Catalog=mydatabase;Integrated Security=True");
            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO Customer (PName, Email, Phone) VALUES (@PName, @Email, @Phone)", connection);
                command.Parameters.AddWithValue("@PName", name);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Phone", phone);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Customer added successfully!");
                }
                else
                {
                    Console.WriteLine("An error occurred while adding the customer.");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Dispose();
            }
            Console.WriteLine();
        }

        static void ViewCustomers()
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-NHRND48\\SQLEXPRESS;Initial Catalog=mydatabase;Integrated Security=True");
            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Customer", connection);
                SqlDataReader reader = command.ExecuteReader();

                List<Customer> customers = new List<Customer>();
                while (reader.Read())
                {
                    int id = (int)reader["Id"];
                    string name = (string)reader["PName"];
                    string email = (string)reader["Email"];
                    string phone = (string)reader["Phone"];

                    Customer customer = new Customer(id, name, email, phone);
                    customers.Add(customer);
                }
                reader.Close();

                if (customers.Count == 0)
                {
                    Console.WriteLine("There are no customers to display.");
                    Console.WriteLine();
                    return;
                }
                Console.WriteLine("Customer list:");
                foreach (Customer customer in customers)
                {
                    Console.WriteLine("Name: " + customer.Name);
                    Console.WriteLine("Email: " + customer.Email);
                    Console.WriteLine("Phone: " + customer.Phone);
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Dispose();
            }
        }
    }

    class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Customer()
        {

        }

        public Customer(int id, string name, string email, string phone)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
        }
    }
}