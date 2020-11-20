using System.Collections.Generic;

namespace Ordermanager_Logic.Interfaces
{
    public interface IProductProvider
    {
        List<Product> GetAllProducts();
    }
}
