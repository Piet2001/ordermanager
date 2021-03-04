﻿using Ordermanager_Logic;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace View.Models
{
    public class OrderViewModel
    {
        public int OrderNr { get; set; }
        public string Product { get; set; }
        [DisplayName("Price")]
        public decimal ProductPrice { get; set; }
        public int Amount { get; set; }
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime DeliveryDate { get; set; }
        public string Customer { get; set; }
        [DisplayName("Adress")]
        public string CustomerAdress { get; set; }
        public Status Status { get; set; }
    }
}
