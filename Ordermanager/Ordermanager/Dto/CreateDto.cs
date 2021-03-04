using System;

namespace Ordermanager_Logic.Dto
{
    public class CreateDto
    {
        public int Product { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Customer { get; set; }
        public Status Status { get; set; }
    }
}
