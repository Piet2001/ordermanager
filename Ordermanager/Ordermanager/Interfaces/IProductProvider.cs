using System;
using System.Collections.Generic;
using System.Text;

namespace Ordermanager_Logic.Interfaces
{
    public interface IProductProvider
    {
        List<Product> GetAllProducts();
    }
}
