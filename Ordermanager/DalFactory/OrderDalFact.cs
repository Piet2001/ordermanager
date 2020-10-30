using System;

namespace DalFactory
{
    public static class OrderDalFact
    {
        public IOrderProvider GetOrderDal()
        {
            return new OrderDal();
        }
    }
}
