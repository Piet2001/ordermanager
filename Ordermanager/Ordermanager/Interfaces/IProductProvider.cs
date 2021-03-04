﻿using System.Collections.Generic;

namespace Ordermanager_Logic.Interfaces
{
    public interface IProductProvider
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        void AddProduct(Product product);
        void UpdatePrice(int id, decimal price);
    }
}
