using System;

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

        public Order(Product product, DateTime orderDate, DateTime deliveryDate, Customer customer, Status status, int orderNumber = 0)
        {
            this.OrderDate = orderDate;
            this.DeliveryDate = deliveryDate;
            this.Status = status;
            this.Customer = customer;
            this.Product = product;
            this.OrderNumber = orderNumber;
        }

        //public override string ToString()
        //{
        //    string result;
        //    result = "OrderNummer: " + OrderNumber + "\n";
        //    result += "OrderDate: " + OrderDate + "\n";
        //    result += "DeliveryDate: " + DeliveryDate + "\n";
        //    result += "Status: " + Status + "\n";
        //    result += "Customer: \n" + Customer + "\n";
        //    result += "Product: \n" + Product + "\n";

        //    return result;
        //}
    }
}
