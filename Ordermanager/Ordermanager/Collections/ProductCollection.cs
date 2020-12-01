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
    }
}
