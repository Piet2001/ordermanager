using System.Collections.Generic;
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


        public List<Customer> GetAllOrders()
        {
            return _provider.GetAllCustomers();
        }
    }
}
