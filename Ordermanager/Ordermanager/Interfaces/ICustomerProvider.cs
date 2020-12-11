using System.Collections.Generic;
using Ordermanager_Logic.Dto;

namespace Ordermanager_Logic.Interfaces
{
    public interface ICustomerProvider
    {
        IReadOnlyCollection<Customer> GetAllCustomers();
        Customer GetCustomerByID(int id);
        void AddCustomer(Customer customer);
        void UpdateAdress(int id, string adress);
    }
}
