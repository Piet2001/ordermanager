using MySql.Data.MySqlClient;
using Ordermanager_Logic;
using Ordermanager_Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Ordermanager_DAL
{
    public class OrderManager : IOrderProvider
    {
        private readonly string connectionString;

        public OrderManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IReadOnlyCollection<Order> GetAllOrders()
        {

            var orders = new List<Order>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    using (var query = new MySqlCommand(
                        @"SELECT `order`.OrderNr, product.id, product.Name, product.Price, `order`.Orderdate, `order`.DeliveryDate, 
                        customer.Name, customer.Adress, `order`.`Status` 
                        FROM `order`
                        INNER JOIN product ON order.ProductID = product.ID 
                        INNER JOIN customer ON order.CustomerID = customer.ID
                        Order by `order`.OrderNr",
                        conn))
                    {
                        conn.Open();

                        var reader = query.ExecuteReader();
                        while (reader.Read())
                        {
                            var order = new Order(
                                new Product(reader.GetString(2), reader.GetDouble(3), reader.GetInt32(1)),
                                reader.GetDateTime(4),
                                reader.GetDateTime(5),
                                new Customer(reader.GetString(6), reader.GetString(7)),
                                (Status)reader.GetInt32(8),
                                reader.GetInt32(0)
                            );
                            orders.Add(order);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }


            return orders.AsReadOnly();
        }

        public Order GetOrderById(int id)
        {
            Order order = null;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    var query = conn.CreateCommand();
                    conn.Open();
                    query.CommandText =
                        @"SELECT `order`.OrderNr, product.Name, product.Price, `order`.Orderdate, `order`.DeliveryDate, customer.Name, customer.Adress, `order`.`Status` 
                                    FROM `order`                                    
                                    INNER JOIN product ON order.ProductID = product.ID 
                                    INNER JOIN customer ON order.CustomerID = customer.ID
                                    WHERE order.OrderNr = @OrderID ";
                    query.Parameters.AddWithValue("OrderID", id);

                    var reader = query.ExecuteReader();
                    while (reader.Read())
                    {
                        order = new Order(
                            new Product(reader.GetString(1), reader.GetDouble(2)),
                            reader.GetDateTime(3),
                            reader.GetDateTime(4),
                            new Customer(reader.GetString(5), reader.GetString(6)),
                            (Status)reader.GetInt32(7),
                            reader.GetInt32(0)
                        );
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return order;
        }

        public void AddOrder(Order order)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    var query = conn.CreateCommand();
                    conn.Open();
                    query.CommandText =
                        @"INSERT INTO `ordermanager`.`order` (`ProductID`, `OrderDate`, `DeliveryDate`, `CustomerID`, `Status`) 
                    VALUES (@ProductID, @OrderDate, @DeliveryDate, @CustomerID, @Status);";
                    query.Parameters.AddWithValue("ProductID", order.Product.Id);
                    query.Parameters.AddWithValue("OrderDate", order.OrderDate);
                    query.Parameters.AddWithValue("DeliveryDate", order.DeliveryDate);
                    query.Parameters.AddWithValue("CustomerID", order.Customer.Id);
                    query.Parameters.AddWithValue("Status", (int)order.Status);
                    query.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        public void UpdateStatus(int id, Status status)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    var query = conn.CreateCommand();
                    conn.Open();
                    query.CommandText =
                        @"UPDATE `ordermanager`.`order` SET `Status`=@Status WHERE  `OrderNr`=@OrderNr;";
                    query.Parameters.AddWithValue("OrderNr", id);
                    query.Parameters.AddWithValue("Status", (int)status);
                    query.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        public IReadOnlyCollection<Order> GetOrdersOnStatus(int statusId)
        {
            var orders = new List<Order>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    var query = conn.CreateCommand();
                    conn.Open();
                    query.CommandText =
                        @"SELECT `order`.OrderNr, product.Name, product.Price, `order`.Orderdate, `order`.DeliveryDate, customer.Name, customer.Adress, `order`.`Status` 
                    FROM `order` 
                    INNER JOIN product ON order.ProductID = product.ID 
                    INNER JOIN customer ON order.CustomerID = customer.ID 
                    WHERE Status = @Status
                    Order by `order`.OrderNr";
                    query.Parameters.AddWithValue("Status", statusId);

                    var reader = query.ExecuteReader();
                    while (reader.Read())
                    {
                        Order order = new Order(
                            new Product(reader.GetString(1), reader.GetDouble(2)),
                            reader.GetDateTime(3),
                            reader.GetDateTime(4),
                            new Customer(reader.GetString(5), reader.GetString(6)),
                            (Status)reader.GetInt32(7),
                            reader.GetInt32(0)
                        );
                        orders.Add(order);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return orders.AsReadOnly();
        }
    }
}