using Ordermanager_Logic;
using System;
using System.Collections.Generic;

namespace Ordermanager_DAL
{
    public class OrderDal : IOrderProvider
    {
        // List<OrderDTO> orders = new List<OrderDTO>();

        //public List<OrderDTO> GetAllOrders()
        //{
        //    OrderDTO order = new OrderDTO();
        //    order.orderNr = 1;
        //    order.product = "ITSD20K2";
        //    order.orderDate = new DateTime(12 - 10 - 2020);
        //    order.deliveryDate = new DateTime(19 - 10 - 2020);
        //    order.klant = "Fontys";
        //    order.status = "Geleverd";

        //    return orders;
        //}
        public List<Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }
    }
}
