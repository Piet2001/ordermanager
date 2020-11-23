using MySql.Data.MySqlClient;
using Ordermanager_Logic;
using Ordermanager_Logic.Dto;
using Ordermanager_Logic.Interfaces;
using System.Collections.Generic;

namespace Ordermanager_DAL
{
    class ProductDal : IProductProvider
    {
        private readonly string connectionString = "Server=127.0.0.1;Database=ordermanager;Uid=root;Pwd=;";

        public List<ProductDto> GetAllProducts()
        {
            List<ProductDto> customers = new List<ProductDto>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand query = new MySqlCommand("SELECT product.Name, product.Price FROM product", conn))
                {
                    conn.Open();

                    var reader = query.ExecuteReader();
                    while (reader.Read())
                    {
                        ProductDto customer = new ProductDto
                        {
                            Name = reader.GetString(0),
                            Price = reader.GetInt32(1)
                        };
                        customers.Add(customer);
                    }
                }
            }
            return customers;
        }

        public void AddProduct(Product product)
        {
           
        }
    }
}
