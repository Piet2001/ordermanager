using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Ordermanager_Logic;
using Ordermanager_Logic.Dto;
using Ordermanager_Logic.Interfaces;
using static Ordermanager_DAL.Connection;

namespace Ordermanager_DAL
{
    class CustomerDal : ICustomerProvider
    {
       public IReadOnlyCollection<CustomerDto> GetAllCustomers()
        {
            List<CustomerDto> customers = new List<CustomerDto>();

            using (MySqlConnection conn = Conn())
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
            return customers.AsReadOnly();
        }

        public void AddCustomer(Customer customer)
        {

        }
    }
}
