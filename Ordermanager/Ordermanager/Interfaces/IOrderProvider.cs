using System.Collections.Generic;

namespace Ordermanager_Logic.Interfaces
{
    public interface IOrderProvider
    {
        List<Order> GetAllOrders();
    }
}
