using System;
using System.Collections.Generic;
using System.Text;

namespace Ordermanager_Logic
{
    public class OrderCollection
    {
        IOrderProvider x;

        public OrderCollection(IOrderProvider q)
        {
            x = q;
        }


        public List<Order> GetAllOrders()
        {
            return x.GetAllOrders();
        }
    }
}
