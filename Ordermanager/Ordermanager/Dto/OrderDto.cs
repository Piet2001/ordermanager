using System;

namespace Ordermanager_Logic.Dto
{
    public class OrderDto
    {
        public int OrderNr { get; set; }
        public Product Product { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public Customer Customer { get; set; }
        public Status Status { get; set; }
    }
}
