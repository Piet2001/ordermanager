using System.Collections.Generic;
using Ordermanager_Logic.Dto;

namespace Ordermanager_Logic.Interfaces
{
    public interface IProductProvider
    {
        IReadOnlyCollection<Product> GetAllProducts();
        Product GetProductByID(int id);
        void AddProduct(Product product);
        void UpdatePrice(int id, double price);
    }
}
