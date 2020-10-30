using System;

namespace DtoCollection
{
    public class OrderDTO
    {
        public int orderNr { get; set; }
        public string product { get; set; }
        public DateTime orderDate { get; set; }
        public DateTime deliveryDate { get; set; }
        public string klant { get; set; }
        public string status { get; set; }
    }
}
