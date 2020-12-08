using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ordermanager_Logic;
using Ordermanager_Logic.Dto;

namespace View.Models
{
    public class OrderCreateModel
    {
        public int OrderNr { get; set; }
        public int Product { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Customer { get; set; }
        [EnumDataType(typeof(Status))]
        public Status Status { get; set; }

        public IReadOnlyCollection<ProductDto> Products { get; set; }
    }
}
