using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Ordermanager_Logic;
using Ordermanager_Logic.Dto;
using Ordermanager_Logic.Interfaces;

namespace Ordermanager_DAL
{
    class CustomerDal : ICustomerProvider
    {
        private readonly string connectionString = "Server=127.0.0.1;Database=ordermanager;Uid=root;Pwd=;";

        public IReadOnlyCollection<CustomerDto> GetAllCustomers()
        {
            List<CustomerDto> customers = new List<CustomerDto>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand query = new MySqlCommand("SELECT customer.Name, customer.Adress FROM customer", conn))
                {
                    conn.Open();

                    var reader = query.ExecuteReader();
                    while (reader.Read())
                    {
                        CustomerDto customer = new CustomerDto
                        {
                            Name = reader.GetString(0),
                            Adress = reader.GetString(1)
                        };
                        customers.Add(customer);
                    }
                }
            }
            return customers;
        }

        public void AddCustomer(Customer customer)
        {

        }
    }
}
