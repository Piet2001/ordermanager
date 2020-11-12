using System;
using System.Net.Http.Headers;

namespace Ordermanager_Logic
{
    public class Order
    {
        private int orderNumber;
        private DateTime orderDate;
        private DateTime deliveryDate;
        private Status status;
        private Customer customer;
        private Product product;

        public Order(int orderNumber, DateTime orderDate, DateTime deliveryDate, Status status, Customer customer, Product product)
        {
            this.orderNumber = orderNumber;
            this.orderDate = orderDate;
            this.deliveryDate = deliveryDate;
            this.status = status;
            this.customer = customer;
            this.product = product;
        }

        public void updateStatus(Status status)
        {
            this.status = status;
        }

        public override string ToString()
        {
            string result;
            result = "OrderNummer: " + orderNumber + "\n";
            result += "OrderDate: " + orderDate + "\n";
            result += "DeliveryDate: " + deliveryDate + "\n";
            result += "Status: " + status + "\n";
            result += "Customer: \n" + customer + "\n";
            result += "Product: \n" + product + "\n";

            return result;
        }
    }
}
