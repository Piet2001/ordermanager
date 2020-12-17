using Ordermanager_Logic.Interfaces;
using System.Collections.Generic;

namespace Ordermanager_Logic.Collections
{
    public class CustomerCollection
    {
        private readonly ICustomerProvider _provider;

        public CustomerCollection(ICustomerProvider provider)
        {
            _provider = provider;
        }


        public IReadOnlyCollection<Customer> GetAllCustomers()
        {
            return _provider.GetAllCustomers();
        }

        public Customer GetCustomerById(int id)
        {
            return _provider.GetCustomerById(id);
        }

        public void AddCustomer(Customer customer)
        {
            _provider.AddCustomer(customer);
        }

        public void UpdateAdress(int id, string adress)
        {
            _provider.UpdateAdress(id, adress);
        }

    }
}
