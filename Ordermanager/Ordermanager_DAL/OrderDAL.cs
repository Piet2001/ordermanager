using Ordermanager_Logic;
using System;
using System.Collections.Generic;
using Ordermanager_Logic.Interfaces;

namespace Ordermanager_DAL
{
    public class OrderDal : IOrderProvider
    {
        public List<Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public void AddOrder(Order order)
        {

        }
    }
}
