using System;
using System.Collections.Generic;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using Ordermanager_Logic;
using Ordermanager_Logic.Dto;
using Ordermanager_Logic.Interfaces;
using static Ordermanager_DAL.Connection;

namespace Ordermanager_DAL
{
    public class CustomerDal : ICustomerProvider
    {
        public IReadOnlyCollection<CustomerDto> GetAllCustomers()
        {
            List<CustomerDto> customers = new List<CustomerDto>();

            using (MySqlConnection conn = Conn())
            {
                using (MySqlCommand query = new MySqlCommand("SELECT customer.id, customer.Name, customer.Adress FROM customer Order by Customer.Id", conn))
                {
                    conn.Open();

                    var reader = query.ExecuteReader();
                    while (reader.Read())
                    {
                        CustomerDto customer = new CustomerDto
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Adress = reader.GetString(2)
                        };
                        customers.Add(customer);
                    }
                }
            }
            return customers.AsReadOnly();
        }

        public CustomerDto GetCustomerByID(int id)
        {
            var customer = new CustomerDto();
            try
            {
                using (MySqlConnection conn = Conn())
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
                        customer.Id = reader.GetInt32(0);
                        customer.Name = reader.GetString(1);
                        customer.Adress = reader.GetString(2);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return customer;
        }

        public void AddCustomer(CustomerCreateDto customer)
        {
            try
            {
                using (MySqlConnection conn = Conn())
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

        public void UpdateAdress(CustomerUpdateDto customer)
        {
            try
            {
                using (MySqlConnection conn = Conn())
                {
                    var query = conn.CreateCommand();
                    conn.Open();
                    query.CommandText =
                        @"UPDATE `ordermanager`.`customer` SET `Adress`=@Adress WHERE  `ID`=@ID;";
                    query.Parameters.AddWithValue("ID", customer.Id);
                    query.Parameters.AddWithValue("Adress", customer.Adress);
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
