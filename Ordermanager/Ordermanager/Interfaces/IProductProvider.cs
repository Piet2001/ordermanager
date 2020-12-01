using System.Collections.Generic;
using Ordermanager_Logic.Dto;

namespace Ordermanager_Logic.Interfaces
{
    public interface IProductProvider
    {
        IReadOnlyCollection<ProductDto> GetAllProducts();
    }
}
