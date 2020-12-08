using System.Collections.Generic;
using Ordermanager_Logic.Dto;
using Ordermanager_Logic.Interfaces;

namespace Ordermanager_Logic.Collections
{
    public class ProductCollection
    {
        private readonly IProductProvider provider;

        public ProductCollection(IProductProvider provider)
        {
            this.provider = provider;
        }
        public IReadOnlyCollection<ProductDto> GetAllProducts()
        {
            return provider.GetAllProducts();
        }

        public ProductDto GetProductById(int id)
        {
            return provider.GetProductByID(id);
        }

        public void AddProduct(ProductCreateDto product)
        {
            provider.AddProduct(product);
        }

        public void UpdatePrice(ProductUpdateDto update)
        {
            provider.UpdatePrice(update);
        }
    }
}
