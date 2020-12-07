using Ordermanager_Logic;
using System;

namespace View.Models
{
    public class OrderViewModel
    {
        public int OrderNr { get; set; }
        public string Product { get; set; }
        public double ProductPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Customer { get; set; }
        public string CustomerAdress { get; set; }
        public Status Status { get; set; }
    }
}
