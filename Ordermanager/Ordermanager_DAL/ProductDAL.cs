using System;
using MySql.Data.MySqlClient;
using Ordermanager_Logic;
using Ordermanager_Logic.Dto;
using Ordermanager_Logic.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
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

        public ProductDto GetProductByID(int id)
        {
            var product = new ProductDto();
            try
            {
                using (MySqlConnection conn = Conn())
                {
                    var query = conn.CreateCommand();
                    conn.Open();
                    query.CommandText =
                        @"SELECT product.ID, product.Name, product.Price 
                                    FROM product
                                    WHERE product.ID = @ProductID";
                    query.Parameters.AddWithValue("ProductID", id);

                    var reader = query.ExecuteReader();
                    while (reader.Read())
                    {
                        product.Id = reader.GetInt32(0);
                        product.Name = reader.GetString(1);
                        product.Price =reader.GetDouble(2);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return product;
        }

        public void AddProduct(ProductCreateDto product)
        {
            try
            {
                using (MySqlConnection conn = Conn())
                {
                    var query = conn.CreateCommand();
                    conn.Open();
                    query.CommandText =
                        @"INSERT INTO `ordermanager`.`product` (`Name`, `Price`)
                            VALUES (@Name, @Price);";
                    query.Parameters.AddWithValue("Name", product.Name);
                    query.Parameters.AddWithValue("Price", product.Price);

                    query.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}
