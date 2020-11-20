using System.Collections.Generic;
using Ordermanager_Logic.Dto;
using Ordermanager_Logic.Interfaces;

namespace Ordermanager_Logic.Collections
{
    public class OrderCollection
    {
        private IOrderProvider _provider;

        public OrderCollection(IOrderProvider provider)
        {
            _provider = provider;
        }

        public List<OrderDto> GetAllOrders()
        {
            return _provider.GetAllOrders();
        }
    }
}
