using MySql.Data.MySqlClient;
using Ordermanager_Logic;
using Ordermanager_Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Ordermanager_DAL
{
    public class CustomerManager : ICustomerProvider
    {
        private readonly string connectionString;

        public CustomerManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IReadOnlyCollection<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand query =
                    new MySqlCommand(
                        "SELECT customer.id, customer.Name, customer.Adress FROM customer Order by Customer.Id", conn))
                {
                    conn.Open();

                    var reader = query.ExecuteReader();
                    while (reader.Read())
                    {
                        Customer customer = new Customer
                        (
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetInt32(0)

                        );
                        customers.Add(customer);
                    }
                }
            }

            return customers.AsReadOnly();
        }

        public Customer GetCustomerById(int id)
        {
            Customer customer = null;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    var query = conn.CreateCommand();
                    conn.Open();
                    query.CommandText =
                        @"SELECT customer.ID, customer.Name, customer.Adress 
                                    FROM customer
                                    WHERE customer.ID = @CustomerID";
                    query.Parameters.AddWithValue("CustomerID", id);

                    var reader = query.ExecuteReader();
                    while (reader.Read())
                    {
                        customer = new Customer
                        (
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetInt32(0)

                        );
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return customer;
        }

        public void AddCustomer(Customer customer)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    var query = conn.CreateCommand();
                    conn.Open();
                    query.CommandText =
                        @"INSERT INTO `ordermanager`.`customer` (`Name`, `Adress`)
                            VALUES (@Name, @Adress);";
                    query.Parameters.AddWithValue("Name", customer.Name);
                    query.Parameters.AddWithValue("Adress", customer.Adress);

                    query.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        public void UpdateAdress(int id, string adress)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    var query = conn.CreateCommand();
                    conn.Open();
                    query.CommandText =
                        @"UPDATE `ordermanager`.`customer` SET `Adress`=@Adress WHERE  `ID`=@ID;";
                    query.Parameters.AddWithValue("ID", id);
                    query.Parameters.AddWithValue("Adress", adress);
                    query.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}
