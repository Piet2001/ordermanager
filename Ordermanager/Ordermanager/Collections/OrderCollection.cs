using Ordermanager_Logic.Interfaces;
using System.Collections.Generic;

namespace Ordermanager_Logic.Collections
{
    public class OrderCollection
    {
        private readonly IOrderProvider provider;

        public OrderCollection(IOrderProvider provider)
        {
            this.provider = provider;
        }

        public IReadOnlyCollection<Order> GetAllOrders()
        {
            return provider.GetAllOrders();
        }

        public Order GetOrderById(int id)
        {
            return provider.GetOrderById(id);
        }

        public void AddOrder(Order order)
        {
            provider.AddOrder(order);
        }

        public void UpdateStatus(int id, Status status)
        {
            provider.UpdateStatus(id, status);
        }

        public IReadOnlyCollection<Order> GetOnStatus(int statusId)
        {
            return provider.GetOrdersOnStatus(statusId);
        }
    }
}
