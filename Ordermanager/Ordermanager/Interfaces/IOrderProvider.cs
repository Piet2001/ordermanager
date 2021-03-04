using System.Collections.Generic;

namespace Ordermanager_Logic.Interfaces
{
    public interface IOrderProvider
    {
        List<Order> GetAllOrders();
        Order GetOrderById(int id);
        void AddOrder(Order order);
        void UpdateStatus(int id, Status status);
        IReadOnlyCollection<Order> GetOrdersOnStatus(int statusId);
    }
}