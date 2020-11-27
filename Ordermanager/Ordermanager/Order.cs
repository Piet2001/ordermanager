using System;
using Ordermanager_Logic.Dto;

namespace Ordermanager_Logic
{
    public class Order
    {
        private readonly int orderNumber;
        private readonly DateTime orderDate;
        private readonly DateTime deliveryDate;
        private Status status;
        private readonly Customer customer;
        private readonly Product product;

        public Order(OrderDto neworder)
        {
            orderNumber = neworder.OrderNr;
            orderDate = neworder.OrderDate;
            deliveryDate = neworder.DeliveryDate;
            status = neworder.Status;
            customer = neworder.Customer;
            product = neworder.Product;
        }

        public void UpdateStatus(Status newStatus)
        {
            this.status = newStatus;
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
