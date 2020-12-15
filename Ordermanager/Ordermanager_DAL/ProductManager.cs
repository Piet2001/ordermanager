using MySql.Data.MySqlClient;
using Ordermanager_Logic;
using Ordermanager_Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using static Ordermanager_DAL.Connection;

namespace Ordermanager_DAL
{
    public class ProductManager : IProductProvider
    {
        public IReadOnlyCollection<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            using (MySqlConnection conn = Conn())
            {
                using (MySqlCommand query = new MySqlCommand("SELECT product.Id, product.Name, product.Price FROM product Order by product.Id", conn))
                {
                    conn.Open();

                    var reader = query.ExecuteReader();
                    while (reader.Read())
                    {
                        Product product = new Product
                        (
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetDouble(2)

                        );
                        products.Add(product);
                    }
                }
            }
            return products.AsReadOnly();
        }

        public Product GetProductById(int id)
        {
            var product = new Product();
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
                        product = new Product
                        (
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetDouble(2)

                        );
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return product;
        }

        public void AddProduct(Product product)
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

        public void UpdatePrice(int id, double price)
        {
            try
            {
                using (MySqlConnection conn = Conn())
                {
                    var query = conn.CreateCommand();
                    conn.Open();
                    query.CommandText =
                        @"UPDATE `ordermanager`.`product` SET `Price`=@Price WHERE  `ID`=@ID;";
                    query.Parameters.AddWithValue("ID", id);
                    query.Parameters.AddWithValue("Price", price);
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
