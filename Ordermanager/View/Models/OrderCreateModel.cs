using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ordermanager_Logic;

namespace View.Models
{
    public class OrderCreateModel
    {
        public int Product { get; set; }
        public int Amount { get; set; }
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime DeliveryDate { get; set; }
        public int Customer { get; set; }
        [EnumDataType(typeof(Status))]
        public Status Status { get; set; }

        public IReadOnlyCollection<Product> Products { get; set; }
        public IReadOnlyCollection<Customer> Customers { get; set; }
    }
}
