﻿using System.Collections.Generic;
using Ordermanager_Logic.Dto;
using Ordermanager_Logic.Interfaces;

namespace Ordermanager_Logic.Collections
{
    public class ProductCollection
    {
        private readonly IProductProvider _provider;

        public ProductCollection(IProductProvider provider)
        {
            _provider = provider;
        }


        public List<ProductDto> GetAllProducts()
        {
            return _provider.GetAllProducts();
        }
    }
}
