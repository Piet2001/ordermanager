using System.Collections.Generic;
using Ordermanager_Logic.Dto;

namespace Ordermanager_Logic.Interfaces
{
    public interface IOrderProvider
    {
        IReadOnlyCollection<Order> GetAllOrders();
        Order GetOrderById(int id);
        void AddOrder(Order order);
        void UpdateStatus(int id, Status status);
        IReadOnlyCollection<Order> GetOrdersOnStatus(int statusId);
    }
}