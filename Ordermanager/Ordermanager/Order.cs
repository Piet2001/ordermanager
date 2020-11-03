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


        public void updateStatus(Status newstatus)
        {
            this.status = newstatus;
        }
    }
}
