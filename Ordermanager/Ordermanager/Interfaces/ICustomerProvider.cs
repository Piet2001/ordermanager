using System.Collections.Generic;

namespace Ordermanager_Logic.Interfaces
{
    public interface ICustomerProvider
    {
        List<Customer> GetAllCustomers();
    }
}
