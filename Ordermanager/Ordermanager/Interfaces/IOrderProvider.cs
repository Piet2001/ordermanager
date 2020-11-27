using System.Collections.Generic;
using Ordermanager_Logic.Dto;

namespace Ordermanager_Logic.Interfaces
{
    public interface IOrderProvider
    {
        IReadOnlyCollection<OrderDto> GetAllOrders();

        OrderDto GetOrderByID(int id);
        void AddOrder(CreateDto order);
        void UpdateStatus(UpdateDto order);
    }
}
