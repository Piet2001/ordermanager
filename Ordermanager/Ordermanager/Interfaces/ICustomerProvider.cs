using System.Collections.Generic;

namespace Ordermanager_Logic.Interfaces
{
    public interface ICustomerProvider
    {
        IReadOnlyCollection<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void AddCustomer(Customer customer);
        void UpdateAdress(int id, string adress);
    }
}
