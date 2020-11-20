using System;
using System.Collections.Generic;
using System.Text;
using Ordermanager_Logic;
using Ordermanager_Logic.Interfaces;

namespace Ordermanager_DAL
{
    class ProductDAL : IProductProvider
    {
        private readonly string connectionString = "Server=127.0.0.1;Database=ordermanager;Uid=root;Pwd=;";

        public List<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public void addProduct(Product product)
        {

        }
    }
}
