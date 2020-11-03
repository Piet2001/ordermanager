using System.Collections.Generic;

namespace Ordermanager_Logic
{
    public class OrderCollection
    {
        private IOrderProvider provider;

        public OrderCollection(IOrderProvider q)
        {
            provider = q;
        }


        public List<Order> GetAllOrders()
        {
            return provider.GetAllOrders();
        }
    }
}
