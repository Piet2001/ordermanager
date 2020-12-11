using Ordermanager_Logic.Interfaces;
using System.Collections.Generic;

namespace Ordermanager_Logic.Collections
{
    public class CustomerCollection
    {
        private ICustomerProvider provider;

        public CustomerCollection(ICustomerProvider provider)
        {
            this.provider = provider;
        }


        public IReadOnlyCollection<Customer> GetAllCustomers()
        {
            return provider.GetAllCustomers();
        }

        public Customer GetCustomerById(int id)
        {
            return provider.GetCustomerById(id);
        }

        public void AddCustomer(Customer customer)
        {
            provider.AddCustomer(customer);
        }

        public void UpdateAdress(int id, string adress)
        {
            provider.UpdateAdress(id, adress);
        }

    }
}
