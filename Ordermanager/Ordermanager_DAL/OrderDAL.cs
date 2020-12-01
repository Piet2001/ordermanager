using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Ordermanager_Logic;
using Ordermanager_Logic.Dto;
using Ordermanager_Logic.Interfaces;

namespace Ordermanager_DAL
{
    public class OrderDal : IOrderProvider
    {
        private readonly string connectionString = "Server=127.0.0.1;Database=ordermanager;Uid=root;Pwd=;";

        public IReadOnlyCollection<OrderDto> GetAllOrders()
        {
            var orders = new List<OrderDto>();

            using (var conn = new MySqlConnection(connectionString))
            {
                using (var query = new MySqlCommand(
                    "SELECT `order`.OrderNr, product.Name, product.Price, `order`.Orderdate, `order`.DeliveryDate, customer.Name, customer.Adress, `order`.`Status` FROM `order`, product, customer WHERE order.ProductID = product.ID AND order.CustomerID = customer.ID",
                    conn))
                {
                    conn.Open();

                    var reader = query.ExecuteReader();
                    while (reader.Read())
                    {
                        var order = new OrderDto
                        {
                            OrderNr = reader.GetInt32(0),
                            Product = new Product(reader.GetString(1), reader.GetDouble(2)),
                            OrderDate = reader.GetDateTime(3),
                            DeliveryDate = reader.GetDateTime(4),
                            Customer = new Customer(reader.GetString(5), reader.GetString(6)),
                            Status = (Status)reader.GetInt32(7)
                        };
                        orders.Add(order);
                    }
                }
            }

            return orders.AsReadOnly();
        }

        public OrderDto GetOrderByID(int id)
        {
            var order = new OrderDto();
            using (var conn = new MySqlConnection(connectionString))
            {
                var query = conn.CreateCommand();
                conn.Open();
                query.CommandText =
                    @"SELECT `order`.OrderNr, product.Name, product.Price, `order`.Orderdate, `order`.DeliveryDate, customer.Name, customer.Adress, `order`.`Status` 
                                    FROM `order`, product, customer 
                                    WHERE order.OrderNr = @OrderID 
                                    AND order.ProductID = product.ID 
                                    AND order.CustomerID = customer.ID";
                query.Parameters.AddWithValue("OrderID", id);

                var reader = query.ExecuteReader();
                while (reader.Read())
                {
                    order.OrderNr = reader.GetInt32(0);
                    order.Product = new Product(reader.GetString(1), reader.GetDouble(2));
                    order.OrderDate = reader.GetDateTime(3);
                    order.DeliveryDate = reader.GetDateTime(4);
                    order.Customer = new Customer(reader.GetString(5), reader.GetString(6));
                    order.Status = (Status)reader.GetInt32(7);
                }
            }

            return order;
        }

        public void AddOrder(CreateDto order)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                var query = conn.CreateCommand();
                conn.Open();
                query.CommandText =
                    @"INSERT INTO `ordermanager`.`order` (`OrderNr`, `ProductID`, `OrderDate`, `DeliveryDate`, `CustomerID`, `Status`) 
                    VALUES (@OrderNr, @ProductID, @OrderDate, @DeliveryDate, @CustomerID, @Status);";
                query.Parameters.AddWithValue("OrderNr", order.OrderNr);
                query.Parameters.AddWithValue("ProductID", order.Product);
                query.Parameters.AddWithValue("OrderDate", order.OrderDate);
                query.Parameters.AddWithValue("DeliveryDate", order.DeliveryDate);
                query.Parameters.AddWithValue("CustomerID", order.Customer);
                query.Parameters.AddWithValue("Status", (int)order.Status);
                query.ExecuteNonQuery();
            }
        }

        public void UpdateStatus(UpdateDto order)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                var query = conn.CreateCommand();
                conn.Open();
                query.CommandText =
                    @"UPDATE `ordermanager`.`order` SET `Status`=@Status WHERE  `OrderNr`=@OrderNr;";
                query.Parameters.AddWithValue("OrderNr", order.Id);
                query.Parameters.AddWithValue("Status", (int)order.Status);
                query.ExecuteNonQuery();
            }
        }

        public IReadOnlyCollection<OrderDto> GetOrdersOnStatus(int statusId)
        {
            var orders = new List<OrderDto>();

            using (var conn = new MySqlConnection(connectionString))
            {
                var query = conn.CreateCommand();
                conn.Open();
                query.CommandText =
                    @"SELECT `order`.OrderNr, product.Name, product.Price, `order`.Orderdate, `order`.DeliveryDate, customer.Name, customer.Adress, `order`.`Status` 
                    FROM `order`, product, customer 
                    WHERE order.ProductID = product.ID 
                    AND order.CustomerID = customer.ID 
                    AND Status = @Status";
                query.Parameters.AddWithValue("Status", statusId);

                var reader = query.ExecuteReader();
                while (reader.Read())
                {
                    var order = new OrderDto
                    {
                        OrderNr = reader.GetInt32(0),
                        Product = new Product(reader.GetString(1), reader.GetDouble(2)),
                        OrderDate = reader.GetDateTime(3),
                        DeliveryDate = reader.GetDateTime(4),
                        Customer = new Customer(reader.GetString(5), reader.GetString(6)),
                        Status = (Status)reader.GetInt32(7)
                    };
                    orders.Add(order);
                }
            }

            return orders.AsReadOnly();
        }
    }
}