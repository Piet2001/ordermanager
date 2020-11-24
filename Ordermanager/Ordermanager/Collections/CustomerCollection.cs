using System.Collections.Generic;
using Ordermanager_Logic.Dto;
using Ordermanager_Logic.Interfaces;

namespace Ordermanager_Logic.Collections
{
    public class CustomerCollection
    {
        private ICustomerProvider _provider;

        public CustomerCollection(ICustomerProvider provider)
        {
            _provider = provider;
        }


        public IReadOnlyCollection<CustomerDto> GetAllOrders()
        {
            return _provider.GetAllCustomers();
        }

    }
}
