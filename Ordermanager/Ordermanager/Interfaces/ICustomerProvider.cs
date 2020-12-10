using System.Collections.Generic;
using Ordermanager_Logic.Dto;

namespace Ordermanager_Logic.Interfaces
{
    public interface ICustomerProvider
    {
        IReadOnlyCollection<CustomerDto> GetAllCustomers();
        CustomerDto GetCustomerByID(int id);
        void AddCustomer(CustomerCreateDto customer);
        void UpdateAdress(CustomerUpdateDto customer);
    }
}
