using System;
using Ordermanager_DAL;
using Ordermanager_Logic;

namespace DalFactory
{
    public static class OrderDalFact
    {
        public static IOrderProvider GetOrderDal()
        {
            return new OrderDal();
        }
    }
}
