using System.Collections.Generic;
using Ordermanager_Logic.Dto;
using Ordermanager_Logic.Interfaces;

namespace Ordermanager_Logic.Collections
{
    public class CustomerCollection
    {
        private ICustomerProvider provider;

        public CustomerCollection(ICustomerProvider provider)
        {
            this.provider = provider;
        }


        public IReadOnlyCollection<CustomerDto> GetAllCustomers()
        {
            return provider.GetAllCustomers();
        }

        public CustomerDto GetCustomerById(int id)
        {
            return provider.GetCustomerByID(id);
        }

        public void AddCustomer(CustomerCreateDto customer)
        {
            provider.AddCustomer(customer);
        }

        public void UpdateAdress(CustomerUpdateDto update)
        {
            provider.UpdateAdress(update);
        }

    }
}
