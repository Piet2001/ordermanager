using System.Collections.Generic;

namespace Ordermanager_Logic
{
    public class ProductCollection
    {
        private IProductProvider provider;

        public ProductCollection(IProductProvider q)
        {
            provider = q;
        }


        public List<Product> GetAllProducts()
        {
            return provider.GetAllProducts();
        }
    }
}
