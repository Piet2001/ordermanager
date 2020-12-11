using Ordermanager_Logic.Interfaces;
using System.Collections.Generic;

namespace Ordermanager_Logic.Collections
{
    public class OrderCollection
    {
        private IOrderProvider _provider;

        public OrderCollection(IOrderProvider provider)
        {
            _provider = provider;
        }

        public IReadOnlyCollection<Order> GetAllOrders()
        {
            return _provider.GetAllOrders();
        }

        public Order GetOrderById(int id)
        {
            return _provider.GetOrderById(id);
        }

        public void AddOrder(Order order)
        {
            _provider.AddOrder(order);
        }

        public void UpdateStatus(int id, Status status)
        {
            _provider.UpdateStatus(id, status);
        }

        public IReadOnlyCollection<Order> GetOnStatus(int statusId)
        {
            return _provider.GetOrdersOnStatus(statusId);
        }
    }
}
