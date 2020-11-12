using System;
using System.Collections.Generic;
using System.Text;

namespace Ordermanager_Logic.Interfaces
{
    public interface ICustomerProvider
    {
        List<Customer> GetAllCustomers();
    }
}
