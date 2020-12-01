using MySql.Data.MySqlClient;
using Ordermanager_Logic;
using Ordermanager_Logic.Dto;
using Ordermanager_Logic.Interfaces;
using System.Collections.Generic;
using static Ordermanager_DAL.Connection;

namespace Ordermanager_DAL
{
    public class ProductDal : IProductProvider
    {
        public IReadOnlyCollection<ProductDto> GetAllProducts()
        {
            List<ProductDto> customers = new List<ProductDto>();

            using (MySqlConnection conn = Conn())
            {
                using (MySqlCommand query = new MySqlCommand("SELECT product.Id, product.Name, product.Price FROM product", conn))
                {
                    conn.Open();

                    var reader = query.ExecuteReader();
                    while (reader.Read())
                    {
                        ProductDto customer = new ProductDto
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Price = reader.GetDouble(2)
                        };
                        customers.Add(customer);
                    }
                }
            }
            return customers.AsReadOnly();
        }

        public void AddProduct(Product product)
        {
           
        }
    }
}
