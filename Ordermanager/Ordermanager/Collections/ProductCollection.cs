using Ordermanager_Logic.Interfaces;
using System.Collections.Generic;

namespace Ordermanager_Logic.Collections
{
    public class ProductCollection
    {
        private readonly IProductProvider provider;

        public ProductCollection(IProductProvider provider)
        {
            this.provider = provider;
        }
        public IReadOnlyCollection<Product> GetAllProducts()
        {
            return provider.GetAllProducts();
        }

        public Product GetProductById(int id)
        {
            return provider.GetProductById(id);
        }

        public void AddProduct(Product product)
        {
            provider.AddProduct(product);
        }

        public void UpdatePrice(int id, double price)
        {
            provider.UpdatePrice(id, price);
        }
    }
}
