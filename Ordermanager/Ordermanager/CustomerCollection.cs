using System.Collections.Generic;

namespace Ordermanager_Logic
{
    public class CustomerCollection
    {
        private ICustomerProvider provider;

        public CustomerCollection(ICustomerProvider q)
        {
            provider = q;
        }


        public List<Customer> GetAllOrders()
        {
            return provider.GetAllCustomers();
        }
    }
}
