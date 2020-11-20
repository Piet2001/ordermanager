using Ordermanager_Logic;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Ordermanager_Logic.Dto;
using Ordermanager_Logic.Interfaces;

namespace Ordermanager_DAL
{
    public class OrderDal : IOrderProvider
    {
        private readonly string connectionString = "Server=127.0.0.1;Database=ordermanager;Uid=root;Pwd=;";

        public List<OrderDto> GetAllOrders()
        {
            List<OrderDto> orders = new List<OrderDto>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand query = new MySqlCommand("SELECT `order`.OrderNr, product.Name, product.Price, `order`.Orderdate, `order`.DeliveryDate, customer.Name, customer.Adress, `order`.`Status` FROM `order`, product, customer WHERE order.ProductID = product.ID AND order.CustomerID = customer.ID", conn))
                {
                    conn.Open();

                    var reader = query.ExecuteReader();
                    while (reader.Read())
                    {
                        OrderDto order = new OrderDto
                        {
                            OrderNr = reader.GetInt32(0),
                            Product = new Product(reader.GetString(1), reader.GetDouble(2)),
                            OrderDate = reader.GetDateTime(3),
                            DeliveryDate = reader.GetDateTime(4),
                            Customer = new Customer(reader.GetString(5), reader.GetString(6)),
                            Status = (Status) reader.GetInt32(7)
                        };
                        orders.Add(order);
                    }
                }
            }
            return orders;
        }

        public void AddOrder(Order order)
        {
            // TODO
        }
    }
}
