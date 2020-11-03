using System;
using System.Collections.Generic;
using System.Text;

namespace Ordermanager_Logic
{
    public interface ICustomerProvider
    {
        List<Customer> GetAllCustomers();
    }
}
