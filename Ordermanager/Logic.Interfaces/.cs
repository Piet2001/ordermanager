using System.Collections.Generic;

namespace Ordermanager_Logic
{
    public interface IOrderProvider
    {
        List<Order> GetAllOrders();
    }
}
