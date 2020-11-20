using System;
using System.Collections.Generic;
using Ordermanager_Logic;
using Ordermanager_Logic.Interfaces;

namespace Ordermanager_DAL
{
    class CustomerDal : ICustomerProvider
    {
        private readonly string connectionString = "Server=127.0.0.1;Database=ordermanager;Uid=root;Pwd=;";

        public List<Customer> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public void AddCustomer(Customer customer)
        {

        }
    }
}
