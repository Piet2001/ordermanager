using System.Collections.Generic;
using Ordermanager_Logic.Dto;

namespace Ordermanager_Logic.Interfaces
{
    public interface IProductProvider
    {
        IReadOnlyCollection<ProductDto> GetAllProducts();
        ProductDto GetProductByID(int id);
        void AddProduct(ProductCreateDto product);
    }
}
