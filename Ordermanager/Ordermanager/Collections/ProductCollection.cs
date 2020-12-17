using Ordermanager_Logic.Interfaces;
using System.Collections.Generic;

namespace Ordermanager_Logic.Collections
{
    public class ProductCollection
    {
        private readonly IProductProvider _provider;

        public ProductCollection(IProductProvider provider)
        {
            _provider = provider;
        }
        public IReadOnlyCollection<Product> GetAllProducts()
        {
            return _provider.GetAllProducts();
        }

        public Product GetProductById(int id)
        {
            return _provider.GetProductById(id);
        }

        public void AddProduct(Product product)
        {
            _provider.AddProduct(product);
        }

        public void UpdatePrice(int id, double price)
        {
            _provider.UpdatePrice(id, price);
        }
    }
}
