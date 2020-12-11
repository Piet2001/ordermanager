using System;
using Ordermanager_Logic.Dto;

namespace Ordermanager_Logic
{
    public class Order
    {
        public int OrderNumber {get; }
        public DateTime OrderDate {get; }
        public DateTime DeliveryDate {get; }
        public Status Status {get;private set;}
        public Customer Customer {get; }
        public Product Product {get; }

        public Order(int orderNumber, Product product, DateTime orderDate, DateTime deliveryDate, Customer customer, Status status)
        {
            this.OrderNumber = orderNumber;
            this.OrderDate = orderDate;
            this.DeliveryDate = deliveryDate;
            this.Status = status;
            this.Customer = customer;
            this.Product = product;
        }
        public Order(Product product, DateTime orderDate, DateTime deliveryDate, Customer customer, Status status)
        {
            this.OrderDate = orderDate;
            this.DeliveryDate = deliveryDate;
            this.Status = status;
            this.Customer = customer;
            this.Product = product;
        }

        public Order()
        {
        }

        public void UpdateStatus(Status newStatus)
        {
            this.Status = newStatus;
        }

        public override string ToString()
        {
            string result;
            result = "OrderNummer: " + OrderNumber + "\n";
            result += "OrderDate: " + OrderDate + "\n";
            result += "DeliveryDate: " + DeliveryDate + "\n";
            result += "Status: " + Status + "\n";
            result += "Customer: \n" + Customer + "\n";
            result += "Product: \n" + Product + "\n";

            return result;
        }
    }
}
